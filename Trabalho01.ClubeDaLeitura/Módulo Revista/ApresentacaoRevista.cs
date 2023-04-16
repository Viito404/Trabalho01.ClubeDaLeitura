using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho01.ClubeDaLeitura.Módulo_Amigo;
using Trabalho01.ClubeDaLeitura.Módulo_Caixa;

namespace Trabalho01.ClubeDaLeitura.Módulo_Revista
{
     internal class ApresentacaoRevista
     {
          private RepositorioRevista repositorioRevista = null;
          private RepositorioCaixa repositorioCaixa = null;
          public ApresentacaoRevista(RepositorioRevista repositorioRevista, RepositorioCaixa repositorioCaixa)
          {
               this.repositorioRevista = repositorioRevista;
               this.repositorioCaixa = repositorioCaixa;
          }

          public void MenuRevista()
          {
               int saida = 1;
               do
               {
                    Console.Clear();
                    Console.WriteLine("| REVISTAS |");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\n[1] CRIAR;\n[2] VISUALIZAR;\n[3] ATUALIZAR;\n[4] REMOVER;\n[0] SAIR.");
                    Console.ResetColor();
                    Console.Write("\nEntre com a opção desejada:\n> ");
                    string opcaoRevista = Console.ReadLine();

                    switch (opcaoRevista)
                    {
                         case "0":
                              Program.ImprimirMensagem("\nSaindo de Revistas...", ConsoleColor.Red, 1);
                              saida--;
                              break;

                         case "1":
                              CadastrarRevista();
                              break;

                         case "2":
                              VisualizarRevista();
                              break;

                         case "3":
                              AtualizarRevista();
                              break;

                         case "4":
                              RemoverRevista();
                              break;

                         default:
                              Program.ImprimirMensagem("\nInsira uma opção inválida!", ConsoleColor.Red, 1);
                              break;
                    }
               } while (saida > 0);
          }

          private void CadastrarRevista()
          {
               Console.Clear();
               Program.ImprimirMensagem("Cadastrando revista...", ConsoleColor.DarkGray, 0);

               Console.Write("\nEntre com o TIPO DA COLEÇÃO:\n> ");
               string tipoColecao = Console.ReadLine();

               Console.Write("\nEntre com o NÚMERO DA EDIÇÃO:\n> ");
               int numeroEdicao = Convert.ToInt32(Console.ReadLine());

               Console.Write("\nEntre com o ANO DA REVISTA:\n> ");
               int anoRevista = Convert.ToInt32(Console.ReadLine());

               Console.Write("\nEntre com a ID DA REVISTA:\n> ");
               int idRevista = Convert.ToInt32(Console.ReadLine());

               bool idInvalido = repositorioRevista.ValidarIdRevistas(idRevista);

               if (idInvalido)
               {
                    Program.ImprimirMensagem("\nNúmero já registrado!", ConsoleColor.Red, 1);
                    CadastrarRevista();
                    return;
               }

               Console.Write("\nEntre com a ID DA CAIXA:\n> ");
               int idCaixa = Convert.ToInt32(Console.ReadLine());

               NegocioCaixa caixaRevista = repositorioCaixa.PegarIdCaixas(idCaixa);

               if(caixaRevista == null)
               {
                    Program.ImprimirMensagem("\nCaixa inválida!", ConsoleColor.Red, 1);                   
                    return;  
               }

               NegocioRevista revista = new NegocioRevista(tipoColecao, numeroEdicao, anoRevista, idRevista, caixaRevista);

               repositorioRevista.GravarRevistas(revista);
               Program.ImprimirMensagem("\nCadastro Finalizado!", ConsoleColor.Green, 1);
          }

          private void VisualizarRevista()
          {
               bool validacao = repositorioRevista.ValidarRevistas();

               if (validacao)
                    return;

               repositorioRevista.ExibirRevistas("Exibindo Revistas...\n");
               Console.ReadLine();
          }

          private void AtualizarRevista()
          {
               bool validacao = repositorioRevista.ValidarRevistas();

               if (validacao)
                    return;

               repositorioRevista.ExibirRevistas("Atualizando Revistas...\n");

          idatualizacao:
               Console.Write("\nEntre com o número da revista que deseja atualizar:\n> ");
               int idRevista = Convert.ToInt32(Console.ReadLine());

               NegocioRevista atualizarRevista = repositorioRevista.PegarIdRevistas(idRevista);

               if (atualizarRevista == null)
               {
                    Program.ImprimirMensagem("\nEntre com uma ID válida!", ConsoleColor.Red, 1);
                    goto idatualizacao;
               }

               Console.Write("\nEntre com o novo TIPO DA COLEÇÃO:\n> ");
               string novoTipoColecao = Console.ReadLine();

               Console.Write("\nEntre com o novo NÚMERO DA EDIÇÃO:\n> ");
               int novoNumeroEdicao = Convert.ToInt32(Console.ReadLine());

               Console.Write("\nEntre com o novo ANO DA REVISTA:\n> ");
               int novoAno = Convert.ToInt32(Console.ReadLine());

               Console.Write("\nEntre com a nova ID DA REVISTA:\n> ");
               int novaID = Convert.ToInt32(Console.ReadLine());

               bool idInvalido = repositorioRevista.ValidarIdRevistas(novaID);

               if (idInvalido)
               {
                    Program.ImprimirMensagem("\nID já registrada!", ConsoleColor.Red, 1);
                    AtualizarRevista();
                    return;
               }

               Console.Write("\nEntre com a nova ID DA CAIXA:\n> ");
               int novaIDCaixa = Convert.ToInt32(Console.ReadLine());

               NegocioCaixa caixaRevista = repositorioCaixa.PegarIdCaixas(novaIDCaixa);

               if (caixaRevista == null)
               {
                    Program.ImprimirMensagem("\nCaixa inválida!", ConsoleColor.Red, 1);
                    AtualizarRevista();
                    return;
               }

               atualizarRevista.TipoColecao = novoTipoColecao;
               atualizarRevista.NumeroEdicao = novoNumeroEdicao;
               atualizarRevista.AnoRevista = novoAno;
               atualizarRevista.IdRevista = novaID;
               atualizarRevista.CaixaRevista = caixaRevista;

               Program.ImprimirMensagem("\nAtualização Finalizada!", ConsoleColor.Green, 1);
          }

          private void RemoverRevista()
          {
               bool validacao = repositorioRevista.ValidarRevistas();

               if (validacao)
                    return;

               repositorioRevista.ExibirRevistas("Removendo Revistas...\n");

          idremocao:
               Console.Write("\nEntre com o número da ID da revista que deseja remover:\n> ");
               int idRevista = Convert.ToInt32(Console.ReadLine());
               NegocioRevista removerRevista = repositorioRevista.PegarIdRevistas(idRevista);

               if (removerRevista == null)
               {
                    Program.ImprimirMensagem("\nEntre com um número válido!", ConsoleColor.Red, 1);
                    goto idremocao;
               }

               repositorioRevista.RemoverRevistas(removerRevista);
               Program.ImprimirMensagem("\nRemoção finalizada!", ConsoleColor.Green, 1);
          }
     }
}
