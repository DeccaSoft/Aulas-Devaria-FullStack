using System;
using System.Collections.Generic;
using System.Linq;

namespace DevariaAula5
{
    class Program
    {
        static void Main(string[] args)
        {
            int idade = 0;
            Console.WriteLine("Digite sua Idade");
            try
            {
                idade = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Ooops! Aconteceu a seguinte Exceção: " + e.Message);
                Console.WriteLine("Provavelmente vc não digitou um número válido!");
                Console.WriteLine("O programa Não será interrompido, portanto os dados não são válidos!");
            }
            finally
            {
                Console.WriteLine("Continuando...");
            }

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
                //string[] jogadores = { "Fulano", "Sicrano", "Beltrano" };
                List<string> jogadores = new List<string>() { "Fulano", "Sicrano", "Beltrano" };

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

            //Aula 2.4

            int[] notas = { 90, 71, 82, 93, 75, 82 };
            int qtdNotasAcima80 = notas.Where(notas => notas > 80).Count();

            Console.WriteLine($"{qtdNotasAcima80} notas acima de 80");
        }
    }
}
