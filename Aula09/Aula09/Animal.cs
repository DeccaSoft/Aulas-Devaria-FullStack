using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula09
{
    public class Animal
    {
        protected string Nome { get; set; }
        protected string Especie { get; set; }

        protected void Respirar()
        {
            Console.WriteLine("Animal Respirando...");
        }
    }
}
