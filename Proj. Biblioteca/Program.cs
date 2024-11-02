using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Biblioteca
{
    internal class Program
    {
        private static List<Livro> livros = new List<Livro>();
        static void Main(string[] args)
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("| 0. Sair                            |");
                Console.WriteLine("| 1. Adicionar livro                 |");
                Console.WriteLine("| 2. Pesquisar livro (sintético)     |");
                Console.WriteLine("| 3. Pesquisar livro (analítico)     |");
                Console.WriteLine("| 4. Adicionar exemplar              |");
                Console.WriteLine("| 5. Registrar empréstimo            |");
                Console.WriteLine("| 6. Registrar devolução             |");
                Console.WriteLine("--------------------------------------");
                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        AdicionarLivro();
                        break;
                    case 2:
                        PesquisarLivroSintetico();
                        break;
                    case 3:
                        PesquisarLivroAnalitico();
                        break;
                    case 4:
                        AdicionarExemplar();
                        break;
                    case 5:
                        RegistrarEmprestimo();
                        break;
                    case 6:
                        RegistrarDevolucao();
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                Console.WriteLine("Pressione uma tecla para continuar...");
                Console.ReadKey();
            } while (opcao != 0);
        }

        private static void AdicionarLivro()
        {
            Console.Write("Informe o ISBN: ");
            int isbn = int.Parse(Console.ReadLine());
            Console.Write("Informe o título: ");
            string titulo = Console.ReadLine();
            Console.Write("Informe o autor: ");
            string autor = Console.ReadLine();
            Console.Write("Informe a editora: ");
            string editora = Console.ReadLine();

            livros.Add(new Livro(isbn, titulo, autor, editora));
            Console.WriteLine("Livro adicionado com sucesso!");
        }

        private static void PesquisarLivroSintetico()
        {
            Console.Write("Informe o título do livro: ");
            string titulo = Console.ReadLine();

            var livro = livros.FirstOrDefault(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
            if (livro != null)
            {
                Console.WriteLine($"Título: {livro.Titulo}");
                Console.WriteLine($"Total de Exemplares: {livro.qtdeExemplares()}");
                Console.WriteLine($"Exemplares Disponíveis: {livro.qtdeDisponiveis()}");
                Console.WriteLine($"Total de Empréstimos: {livro.qtdeEmprestimos()}");
                Console.WriteLine($"Percentual de Disponibilidade: {livro.percDisponibilidade():F2}%");
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }

        private static void PesquisarLivroAnalitico()
        {
            Console.Write("Informe o título do livro: ");
            string titulo = Console.ReadLine();

            var livro = livros.FirstOrDefault(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
            if (livro != null)
            {
                Console.WriteLine($"Título: {livro.Titulo}");
                Console.WriteLine($"Total de Exemplares: {livro.qtdeExemplares()}");
                Console.WriteLine($"Exemplares Disponíveis: {livro.qtdeDisponiveis()}");
                Console.WriteLine($"Total de Empréstimos: {livro.qtdeEmprestimos()}");
                Console.WriteLine($"Percentual de Disponibilidade: {livro.percDisponibilidade():F2}%");

                foreach (var exemplar in livro.Exemplares)
                {
                    Console.WriteLine($"Exemplar Tombo: {exemplar.Tombo}, Disponível: {exemplar.disponivel()}");
                    // Adicione mais informações sobre os empréstimos do exemplar, se necessário
                }
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }

        private static void AdicionarExemplar()
        {
            Console.Write("Informe o ISBN do livro: ");
            int isbn = int.Parse(Console.ReadLine());
            var livro = livros.FirstOrDefault(l => l.ISBN == isbn);
            if (livro != null)
            {
                livro.adicionarExemplar(new Exemplar());
                Console.WriteLine("Exemplar adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }

        private static void RegistrarEmprestimo()
        {
            Console.Write("Informe o ISBN do livro: ");
            int isbn = int.Parse(Console.ReadLine());
            var livro = livros.FirstOrDefault(l => l.ISBN == isbn);
            if (livro != null && livro.qtdeDisponiveis() > 0)
            {
                var exemplar = livro.Exemplares.FirstOrDefault(ex => ex.disponivel());
                if (exemplar != null)
                {
                    exemplar.emprestar();
                    Console.WriteLine("Empréstimo registrado com sucesso!");
                }
            }
            else
            {
                Console.WriteLine("Livro não encontrado ou sem exemplares disponíveis.");
            }
        }

        private static void RegistrarDevolucao()
        {
            Console.Write("Informe o ISBN do livro: ");
            int isbn = int.Parse(Console.ReadLine());
            var livro = livros.FirstOrDefault(l => l.ISBN == isbn);
            if (livro != null)
            {
                var exemplar = livro.Exemplares.FirstOrDefault(ex => !ex.disponivel());
                if (exemplar != null)
                {
                    exemplar.devolver();
                    Console.WriteLine("Devolução registrada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Não há empréstimos em aberto para este livro.");
                }
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }
    }
}
