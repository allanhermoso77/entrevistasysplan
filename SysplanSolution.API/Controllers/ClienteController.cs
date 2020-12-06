using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SysplanSolution.Data.Abstract;
using SysplanSolution.Model;
using SysplanSolution.API.ViewModels;
using AutoMapper;
using SysplanSolution.API.Core;

namespace SysplanSolution.API.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        int page = 1;
        int pageSize = 10;
        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IActionResult Get()
        {
            var pagination = Request.Headers["Pagination"];

            if (!string.IsNullOrEmpty(pagination))
            {
                string[] vals = pagination.ToString().Split(',');
                int.TryParse(vals[0], out page);
                int.TryParse(vals[1], out pageSize);
            }

            int currentPage = page;
            int currentPageSize = pageSize;
            var totalCliente = _clienteRepository.Count();
            var totalPages = (int)Math.Ceiling((double)totalCliente / pageSize);

            IEnumerable<Cliente> _clientes = _clienteRepository.GetAll()
                .OrderBy(u => u.Id)
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();

            IEnumerable<ClienteViewModel> _clientesVM = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clientes);

            Response.AddPagination(page, pageSize, totalCliente, totalPages);

            return new OkObjectResult(_clientesVM);
        }

        [HttpGet("{id}", Name = "GetCliente")]
        public IActionResult Get(Guid id)
        {
            Cliente _cliente = _clienteRepository.GetSingle(u => u.Id == id);

            if (_cliente != null)
            {
                ClienteViewModel _clienteVM = Mapper.Map<Cliente, ClienteViewModel>(_cliente);
                return new OkObjectResult(_clienteVM);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody]ClienteViewModel cliente)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Cliente _newCliente = new Cliente { Nome = cliente.Nome, Idade = cliente.Idade };

            _clienteRepository.Add(_newCliente);
            _clienteRepository.Commit();

            cliente = Mapper.Map<Cliente, ClienteViewModel>(_newCliente);

            CreatedAtRouteResult result = CreatedAtRoute("GetCliente", new { controller = "Cliente", id = cliente.Id }, cliente);
            return result;
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]ClienteViewModel cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Cliente _clienteDb = _clienteRepository.GetSingle(id);

            if (_clienteDb == null)
            {
                return NotFound();
            }
            else
            {
                _clienteDb.Nome = cliente.Nome;
                _clienteDb.Idade = cliente.Idade;
            }

            _clienteRepository.Update(_clienteDb);
            _clienteRepository.Commit();

            cliente = Mapper.Map<Cliente, ClienteViewModel>(_clienteDb);

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            Cliente _clienteDb = _clienteRepository.GetSingle(id);

            if (_clienteDb == null)
            {
                return new NotFoundResult();
            }
            else
            {
                _clienteRepository.Delete(_clienteDb);

                _clienteRepository.Commit();

                return new NoContentResult();
            }
        }

    }

}
