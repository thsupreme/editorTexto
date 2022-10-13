using System;
using System.IO;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("---------- O que você deseja fazer? ----------");
            Console.WriteLine("");
            Console.WriteLine("1 - Abrir um Texto");
            Console.WriteLine("2 - Criar um novo arquivo");
            Console.WriteLine("0 - Sair");

            var opcao = short.Parse(Console.ReadLine()!);

            switch (opcao)
            {
                case 0:
                    System.Environment.Exit(0);
                    break;

                case 1:
                    Abrir();
                    break;

                case 2:
                    Editar();
                    break;

                default:
                    Menu();
                    break;

            }
        }
        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho para abrir o arquivo");
            Console.WriteLine("");
            Console.WriteLine("-----------------------------------");


            var path = Console.ReadLine();

            using (var file = new StreamReader(path!))
            {
                var texto = file.ReadToEnd();
                Console.WriteLine(texto);
            }
            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo(ESQ para sair");
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("");

            var texto = "";

            do
            {
                texto += Console.ReadLine();
                texto += Environment.NewLine;
            }

            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Salvar(texto);
        }

        static void Salvar(string texto)
        {
            Console.Clear();
            Console.WriteLine($"Qual caminho para salvar ??");
            Console.WriteLine("");
            Console.WriteLine("----------------------------");

            var path = Console.ReadLine();

            using (var arquivo = new StreamWriter(path!))
            {
                arquivo.Write(texto);
            }
            Console.WriteLine("");
            Console.WriteLine($"Arquivo {path} salvo com sucesso!! ");
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------");
            Console.ReadLine();

            Menu();

        }

    }
}