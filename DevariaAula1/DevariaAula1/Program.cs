using System;

namespace DevariaAula1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Aula 01

            const string OLA = "Olá, ";
            string nomeCompleto;
            int idade;
            Console.WriteLine("Bom dia! Qual o seu Nome Completo?");
            nomeCompleto = Console.ReadLine().ToString();
            Console.WriteLine("E qual a sua Idade?");
            idade = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(OLA + nomeCompleto + "!");
            Console.WriteLine("Sua Idade Atual: " + idade);

            //Aula 02

            bool valido = true;
            bool invalido = !valido;
            Console.WriteLine("Válido:"  + valido);
            Console.WriteLine("Inválido:"  + invalido);
            Console.WriteLine("Não Inválido:"  + !invalido);

            if(idade == 47 && nomeCompleto == "André Morais de Azevedo")
            {
                Console.WriteLine(nomeCompleto + ", você é o cara!!!");
            }
            else if (nomeCompleto.Contains("André") || nomeCompleto.Contains("Morais") || nomeCompleto.Contains("Azevedo"))
            {
                Console.WriteLine(nomeCompleto + ", você pode ser o cara!!!");
            }
            else
            {
                Console.WriteLine("Show de Bola");
            }

            switch (nomeCompleto)
            {
                case "André":
                case "Andre":
                    Console.WriteLine("Você pode ser o Cara!");
                    break;
                case "André Morais":
                case "Andre Morais":
                    Console.WriteLine("Acho que você é o Cara!");
                    break;
                case "André Morais de Azevedo":
                case "Andre Morais de Azevedo":
                    Console.WriteLine("Você é o Cara!");
                    break;
                default:
                    Console.WriteLine("Quase!!!");
                    break;
            }
        }
    }
}
