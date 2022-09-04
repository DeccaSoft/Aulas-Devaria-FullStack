using System;
using System.Collections.Generic;

namespace Aula10
{
    class Program
    {
        static void Main(string[] args)
        {
            List<FormaGeometrica> formas = new List<FormaGeometrica>
            {
                new Circulo(),
                new Quadrado(),
                new Quadrado(),
                new Circulo()
            };

            foreach(FormaGeometrica forma in formas)
            {
                forma.Desenhar();
            }
        }
    }
}
