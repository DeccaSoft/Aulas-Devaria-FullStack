using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula09
{
    public class Reptil : Animal
    {
        public bool Venenoso { get; set; }

        public Reptil(string nome, string especie)
        {
            Nome = nome;
            Especie = especie;
        }

        public void BotarOvo()
        {
            Respirar();
            if (Venenoso)
            {
                Console.WriteLine($"Animal {Nome} da Espécie {Especie} está Botando Ovo e É Venenoso!");
            }
            else
            {
                Console.WriteLine($"Animal {Nome} da Espécie {Especie} está Botando Ovo e NÃO é Venenoso!");
            }
        }
    }
}
