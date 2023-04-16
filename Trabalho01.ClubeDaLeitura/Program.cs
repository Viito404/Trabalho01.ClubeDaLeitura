using Trabalho01.ClubeDaLeitura.Módulo_Caixa;
using Trabalho01.ClubeDaLeitura.Módulo_Amigo;
using Trabalho01.ClubeDaLeitura.Módulo_Revista;
using Trabalho01.ClubeDaLeitura.Módulo_Empréstimo;

namespace Trabalho01.ClubeDaLeitura
{
     internal class Program
     {
          static void Main(string[] args)
          {
               RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
               ApresentacaoCaixa exibicaoCaixa = new ApresentacaoCaixa(repositorioCaixa);

               RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
               ApresentacaoAmigo exibicaoAmigo = new ApresentacaoAmigo(repositorioAmigo);

               RepositorioRevista repositorioRevista = new RepositorioRevista();
               ApresentacaoRevista exibicaoRevista = new ApresentacaoRevista(repositorioRevista, repositorioCaixa);

               RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();
               ApresentacaoEmprestimo exibicaoEmprestimo = new ApresentacaoEmprestimo(repositorioEmprestimo, repositorioAmigo, repositorioRevista);

               while (true)
               {
                    string opcao = GerarMenu();

                    if (opcao == "0")
                    {
                         ImprimirMensagem("\nSaindo do Programa...", ConsoleColor.Red, 1);
                         break;
                    }

                    else if (opcao == "1")
                    {                   
                         exibicaoCaixa.MenuCaixa();
                    }

                    else if (opcao == "2")
                    {
                         exibicaoAmigo.MenuAmigo();
                    }

                    else if (opcao == "3")
                    {
                         exibicaoRevista.MenuRevista();
                    }

                    else if (opcao == "4")
                    {
                         exibicaoEmprestimo.MenuEmprestimo();
                    }

                    else
                    {
                         ImprimirMensagem("\nEscolha uma opção válida!", ConsoleColor.Red, 1);
                         continue;
                    }
               }
          }

          public static void ImprimirMensagem(string mensagem, ConsoleColor cor, int num)
          {
               Console.ForegroundColor = cor;
               Console.WriteLine(mensagem);
               Console.ResetColor();

               if (num == 1)
               {
                    Console.ReadLine();
               }

          }

          private static string GerarMenu()
          {
               Console.Clear();
               Console.WriteLine("| CLUBE DA LEITURA |");
               Console.ForegroundColor = ConsoleColor.Cyan;
               Console.WriteLine("\n[1] CAIXAS;\n[2] AMIGOS;\n[3] REVISTAS\n[4] EMPRÉSTIMOS;\n[0] SAIR.");
               Console.ResetColor();
               Console.Write("\nEntre com a opção desejada:\n> ");
               string opcao = Console.ReadLine();
               return opcao;
          }
     }
}