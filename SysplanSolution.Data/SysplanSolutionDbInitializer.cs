using SysplanSolution.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace SysplanSolution.Data
{
    public class SysplanSolutionDbInitializer
    {
        private static SysplanSolutionContext context;
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<SysplanSolutionContext>();
                InitializeSysplanSolutions(context);
            }
        }

        private static void InitializeSysplanSolutions(SysplanSolutionContext context)
        {
            if(!context.Clientes.Any())
            {
                Cliente cliente_01 = new Cliente { Nome = "Chris Rock", Idade = 25 };

                Cliente cliente_02 = new Cliente { Nome = "Dwayne Johnson", Idade = 44 };

                Cliente cliente_03 = new Cliente { Nome = "Mike Tyson", Idade = 53 };
                
                context.Clientes.Add(cliente_01);
                context.Clientes.Add(cliente_02);
                context.Clientes.Add(cliente_03);

                context.SaveChanges();
            }

            context.SaveChanges();
        }
    }
}
