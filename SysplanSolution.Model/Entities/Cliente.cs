using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SysplanSolution.Model
{
    public class Cliente : IEntityBase
    {
        public Cliente()
        {
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
    }
}
