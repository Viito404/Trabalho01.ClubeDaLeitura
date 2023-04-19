using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho01.ClubeDaLeitura.Módulo_Amigo;
using Trabalho01.ClubeDaLeitura.Módulo_Caixa;
using Trabalho01.ClubeDaLeitura.Módulo_Revista;
using Trabalho01.ClubeDaLeitura.Utilitários;

namespace Trabalho01.ClubeDaLeitura.Módulo_Empréstimo
{
     internal class ApresentacaoEmprestimo : Tela
     {
          private RepositorioAmigo repositorioAmigo = null;
          private RepositorioRevista repositorioRevista = null;
          private RepositorioEmprestimo repositorioEmprestimo = null;

          public ApresentacaoEmprestimo(RepositorioEmprestimo repositorioEmprestimo, RepositorioAmigo repositorioAmigo, RepositorioRevista repositorioRevista)
          {
               this.repositorioEmprestimo = repositorioEmprestimo;
               this.repositorioAmigo = repositorioAmigo;
               this.repositorioRevista = repositorioRevista;
          }

          public void MenuEmprestimo()
          {
               int saida = 1;
               do
               {
                    string opcaoEmprestimo = GerarMenu("EMPRÉSTIMOS", ConsoleColor.Blue, 2);

                    switch (opcaoEmprestimo)
                    {
                         case "0":
                              ImprimirTexto("\nSaindo de Empréstimos...", ConsoleColor.Red, 1);
                              saida--;
                              break;

                         case "1":
                              CadastrarEmprestimo();
                              break;

                         case "2":
                              VisualizarEmprestimosMes();
                              break;

                         case "3":
                              VisualizarEmprestimoAberto();
                              break;

                         default:
                              ImprimirTexto("\nInsira uma opção inválida!", ConsoleColor.Red, 1);
                              break;
                    }
               } while (saida > 0);
          }
          private void CadastrarEmprestimo()
          {
               repositorioAmigo.ExibirAmigos("Mostrando amigos...\n");
               Console.Write("\nEntre com a ID do amigo que pegará uma revista emprestada:\n> ");
               int idAmigo = Convert.ToInt32(Console.ReadLine());
               NegocioAmigo amigo = repositorioAmigo.PegarIdAmigos(idAmigo);

               if (amigo == null)
               {
                    ImprimirTexto("\nAmigo inválido!", ConsoleColor.Red, 1);
                    return;
               }

               repositorioRevista.ExibirRevistas("Mostrando revistas...\n");
               Console.Write("\nEntre com a ID da revista que será pega pelo amigo:\n> ");
               int idRevista = Convert.ToInt32(Console.ReadLine());
               NegocioRevista revista = repositorioRevista.PegarIdRevistas(idRevista);

               if (revista == null)
               {
                    ImprimirTexto("\nRevista inválida!", ConsoleColor.Red, 1);
                    return;
               }

               Console.Write("\nEntre com a DATA de empréstimo:\n> ");
               string dataEmprestimo = Console.ReadLine();

               Console.Write("\nEntre com a DATA de devolução:\n> ");
               string dataDevolucao = Console.ReadLine();

               bool validarRevista = repositorioEmprestimo.VerificarRevistaDisponivel(revista);

               if (!validarRevista)
               {
                    ImprimirTexto("\nA revista não está disponível!", ConsoleColor.Red, 1);
                    return;
               }

               bool validarEmprestimo = repositorioEmprestimo.VerificarAmigosRevistas(idAmigo);
               if (validarEmprestimo)
               {
                    ImprimirTexto("\nApenas um livro por empréstimo!", ConsoleColor.Red, 1);
                    return;
               }

               NegocioEmprestimo emprestimo = new NegocioEmprestimo(amigo, revista, dataEmprestimo, dataDevolucao);
               repositorioEmprestimo.Gravar(emprestimo);

               ImprimirTexto("\nCadastrado com sucesso!", ConsoleColor.Green, 1);
          }
          private void VisualizarEmprestimosMes()
          {
               bool validacaoCaixas = repositorioEmprestimo.ValidarEmprestimo();
               if (validacaoCaixas)
                    return;

               repositorioEmprestimo.EmprestimosMes();
          }
          private void VisualizarEmprestimoAberto()
          {
               bool validarEmprestimo = repositorioEmprestimo.ValidarEmprestimo();
               if (validarEmprestimo)
                    return;

               repositorioEmprestimo.EmprestimosAbertos();

          }
     }
}
