using Trabalho01.ClubeDaLeitura.Módulo_Caixa;
using Trabalho01.ClubeDaLeitura.Módulo_Amigo;
using Trabalho01.ClubeDaLeitura.Módulo_Revista;
using Trabalho01.ClubeDaLeitura.Módulo_Empréstimo;
using Trabalho01.ClubeDaLeitura.Utilitários;

namespace Trabalho01.ClubeDaLeitura
{
     internal class Program
     {
          static void Main(string[] args)
          {
               Tela outros = new Tela();

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
                    string opcao = outros.GerarMenu("CLUBE DA LEITURA", ConsoleColor.Cyan, 0);

                    if (opcao == "0")
                    {
                         outros.ImprimirTexto("\nSaindo do Programa...", ConsoleColor.Red, 1);
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
                         outros.ImprimirTexto("\nEscolha uma opção válida!", ConsoleColor.Red, 1);
                         continue;
                    }
               }
          }
     }
}