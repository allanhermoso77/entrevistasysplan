using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SysplanSolution.Model;
using SysplanSolution.Data;
using SysplanSolution.Data.Repositories;
using SysplanSolution.Data.Abstract;

namespace SysplanSolution.Data.Repositories
{
    public class ClienteRepository : EntityBaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(SysplanSolutionContext context)
            : base(context)
        { }
    }
}
