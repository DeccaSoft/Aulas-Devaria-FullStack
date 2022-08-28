using System;

namespace DevariaAula5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite sua Idade");
            int idade = Convert.ToInt32(Console.ReadLine());

            if(idade >= 18)
            {
                Console.WriteLine("Você já é Maior de Idade... Vc DEVE pode votar.");
                if (idade >= 60)
                {
                    Console.WriteLine("Porém, vc tem mais de 60 Anos... Seu voto não é obrigatório");
                }
            }
            else if(idade < 18 && idade >= 16)
            {
                Console.WriteLine("Vc Já pode Votar... mas não é obrigatório");
            }
            else
            {
                Console.WriteLine("Você ainda Não pode votar");
            }
        }
    }
}
