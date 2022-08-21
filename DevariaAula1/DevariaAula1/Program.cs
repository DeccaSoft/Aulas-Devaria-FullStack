using System;

namespace DevariaAula1
{
    class Program
    {
        static void Main(string[] args)
        {
            const string OLA = "Olá, ";
            string nomeCompleto;
            int idade;
            Console.WriteLine("Bom dia! Qual o seu Nome Completo?");
            nomeCompleto = Console.ReadLine().ToString();
            Console.WriteLine("E qual a sua Idade?");
            idade = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(OLA + nomeCompleto + "!");
            Console.WriteLine("Sua Idade Atual: " + idade);
        }
    }
}
