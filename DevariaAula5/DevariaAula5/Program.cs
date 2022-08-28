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

            ExemploFor();
            ExemploForEach();
            ExemploWhile();
            ExemploDoWhile();

            //Aula 2.3

            void ExemploFor()
            {
                string[] jogadores = { "Fulano", "Sicrano", "Beltrano" };

                for (int i = 0; i <= 2; i++)
                {
                    Console.WriteLine("Jogador: " + jogadores[i]);
                }
            }

            void ExemploForEach()
            {
                string[] jogadores = { "Fulano", "Sicrano", "Beltrano" };

                foreach(string jogador in jogadores)
                {
                    Console.WriteLine("Bem Vindo, " + jogador);
                }
            }
            
            void ExemploWhile()
            {
                int varWhile = 1;
                while (varWhile <= 10)
                {
                    Console.WriteLine(varWhile);
                    varWhile++;
                }

                while(varWhile < 10)
                {
                    Console.WriteLine("Novo While");
                }
            }

            void ExemploDoWhile()
            {
                int varDoWhile = 1;
                do
                {
                    Console.WriteLine(varDoWhile);
                    varDoWhile++;
                } while (varDoWhile <= 10);

                do
                {
                    Console.WriteLine("Novo Do While");
                } while (varDoWhile < 10);
            }
        }
    }
}
