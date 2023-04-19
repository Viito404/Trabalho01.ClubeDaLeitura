using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho01.ClubeDaLeitura.Utilitários;
namespace Trabalho01.ClubeDaLeitura.Módulo_Caixa
{
     internal class ApresentacaoCaixa : Tela
     {
          RepositorioCaixa repositorioCaixa = null;
          public ApresentacaoCaixa(RepositorioCaixa repositorioCaixa)
          {
               this.repositorioCaixa = repositorioCaixa;
          }

          public void MenuCaixa()
          {
               int saida = 1;
               do
               {
                    string opcaoCaixa = GerarMenu("CAIXAS", ConsoleColor.Blue, 1);

                    switch (opcaoCaixa)
                    {
                         case "0":
                              ImprimirTexto("\nSaindo de Caixas...", ConsoleColor.Red, 1);
                              saida--;
                              break;

                         case "1":
                              CadastrarCaixa();
                              break;

                         case "2":
                              VisualizarCaixa();
                              break;

                         case "3":
                              AtualizarCaixa();
                              break;

                         case "4":
                              RemoverCaixa();
                              break;

                         default:
                              ImprimirTexto("\nInsira uma opção inválida!", ConsoleColor.Red, 1);
                              break;
                    }
               } while (saida > 0);
          }

          private void CadastrarCaixa()
          {
               Console.Clear();
               ImprimirTexto("Cadastrando caixa...", ConsoleColor.DarkGray, 0);

               Console.Write("\nEntre com a COR da caixa:\n> ");
               string cor = Console.ReadLine();

               Console.Write("\nEntre com a ETIQUETA da caixa:\n> ");
               string etiqueta = Console.ReadLine();

               Console.Write("\nEntre com o NÚMERO da caixa:\n> ");
               int numero = Convert.ToInt32(Console.ReadLine());

               bool idInvalido = repositorioCaixa.ValidarIdCaixas(numero);

               if (idInvalido)
               {
                    ImprimirTexto("\nNúmero já registrado!", ConsoleColor.Red, 1);
                    CadastrarCaixa();
                    return;
               }

               NegocioCaixa caixa = new NegocioCaixa(cor, etiqueta, numero);

               repositorioCaixa.Gravar(caixa);
               ImprimirTexto("\nCadastro Finalizado!", ConsoleColor.Green, 1);
          }

          private void VisualizarCaixa()
          {
               bool validacao = repositorioCaixa.ValidarElementos();

               if (validacao)
                    return;

               repositorioCaixa.ExibirCaixas("Exibindo Caixas...\n");
               Console.ReadLine();
          }

          private void AtualizarCaixa()
          {
               bool validacao = repositorioCaixa.ValidarElementos();

               if (validacao)
                    return;

              repositorioCaixa.ExibirCaixas("Atualizando Caixas...\n");
               

          idatualizacao:
               Console.Write("\nEntre com o número da caixa que deseja atualizar:\n> ");
               int idCaixa = Convert.ToInt32(Console.ReadLine());

               NegocioCaixa atualizarCaixa = repositorioCaixa.PegarIdCaixas(idCaixa);

               if (atualizarCaixa == null)
               {
                    ImprimirTexto("\nEntre com um número válido!", ConsoleColor.Red, 1);
                    goto idatualizacao;
               }

               Console.Write("\nEntre com a nova COR da caixa:\n> ");
               string novaCor = Console.ReadLine();

               Console.Write("\nEntre com a nova ETIQUETA da caixa:\n> ");
               string novaEtiqueta = Console.ReadLine();

               Console.Write("\nEntre com o novo NÚMERO da caixa:\n> ");
               int novoNumero = Convert.ToInt32(Console.ReadLine());

               bool idInvalido = repositorioCaixa.ValidarIdCaixas(novoNumero);

               if (idInvalido)
               {
                    ImprimirTexto("\nNúmero já registrado!", ConsoleColor.Red, 1);
                    AtualizarCaixa();
                    return;
               }

               atualizarCaixa.Cor = novaCor;
               atualizarCaixa.Etiqueta = novaEtiqueta;
               atualizarCaixa.Numero = novoNumero;

               ImprimirTexto("\nAtualização Finalizada!", ConsoleColor.Green, 1);
          }

          private void RemoverCaixa()
          {
               bool validacao = repositorioCaixa.ValidarElementos();

               if (validacao)
                    return;

               repositorioCaixa.ExibirCaixas("Removendo Caixas...\n");

          idremocao:
               Console.Write("\nEntre com o número da caixa que deseja remover:\n> ");
               int idCaixa = Convert.ToInt32(Console.ReadLine());
               NegocioCaixa removerCaixa = repositorioCaixa.PegarIdCaixas(idCaixa);

               if (removerCaixa == null)
               {
                    ImprimirTexto("\nEntre com um número válido!", ConsoleColor.Red, 1);
                    goto idremocao;
               }

               repositorioCaixa.Remover(removerCaixa);
               ImprimirTexto("\nRemoção finalizada!", ConsoleColor.Green, 1);
          }
     }
}