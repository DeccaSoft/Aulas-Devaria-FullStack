using System;

namespace Aula09
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal animal = new Animal();
            //animal.Respirar();

            Mamifero mamifero = new Mamifero("Gato", "Felino");
            mamifero.Mamar();

            Reptil reptil = new Reptil("Cobra", "Corales");
            reptil.Venenoso = true;
            reptil.BotarOvo();
        }
    }
}
