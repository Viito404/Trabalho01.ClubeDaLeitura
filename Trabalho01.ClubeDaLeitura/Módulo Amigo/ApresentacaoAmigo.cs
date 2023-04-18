using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho01.ClubeDaLeitura.Módulo_Caixa;
using Trabalho01.ClubeDaLeitura.Módulo_Revista;
using Trabalho01.ClubeDaLeitura.Utilitários;
namespace Trabalho01.ClubeDaLeitura.Módulo_Amigo
{
     internal class ApresentacaoAmigo : Tela
     {
          RepositorioAmigo repositorioAmigo = null;
          public ApresentacaoAmigo(RepositorioAmigo repositorioAmigo)
          {
               this.repositorioAmigo = repositorioAmigo;
          }

          public void MenuAmigo()
          {
               int saida = 1;
               do
               {
                    string opcaoAmigo = GerarMenu("AMIGOS", ConsoleColor.Blue, 1);

                    switch (opcaoAmigo)
                    {
                         case "0":
                              ImprimirTexto("\nSaindo de Amigos...", ConsoleColor.Red, 1);
                              saida--;
                              break;

                         case "1":
                              CadastrarAmigo();
                              break;

                         case "2":
                              VisualizarAmigo();
                              break;

                         case "3":
                              AtualizarAmigo();
                              break;

                         case "4":
                              RemoverAmigo();
                              break;

                         default:
                              ImprimirTexto("\nInsira uma opção inválida!", ConsoleColor.Red, 1);
                              break;
                    }
               } while (saida > 0);
          }

          private void CadastrarAmigo()
          {
               Console.Clear();
               ImprimirTexto("Cadastrando amigo...", ConsoleColor.DarkGray, 0);

               Console.Write("\nEntre com o seu NOME:\n> ");
               string nome = Console.ReadLine();

               Console.Write("\nEntre com o nome do RESPONSÁVEL:\n> ");
               string nomeResponsavel = Console.ReadLine();

               Console.Write("\nEntre com o seu ENDEREÇO:\n> ");
               string endereco = Console.ReadLine();

               Console.Write("\nEntre com o seu TELEFONE:\n> ");
               string telefone = Console.ReadLine();

               Console.Write("\nEntre com a ID DE USUÁRIO:\n> ");
               int id = Convert.ToInt32(Console.ReadLine());

               bool idInvalido = repositorioAmigo.ValidarIdAmigos(id);

               if (idInvalido)
               {
                    ImprimirTexto("\nID já registrada!", ConsoleColor.Red, 1);
                    CadastrarAmigo();
                    return;
               }

               NegocioAmigo amigo = new NegocioAmigo(nome, nomeResponsavel, endereco, telefone, id);

              repositorioAmigo.GravarAmigos(amigo);
               ImprimirTexto("\nCadastro Finalizado!", ConsoleColor.Green, 1);
          }
          
          private void VisualizarAmigo()
          {
               bool validacao = repositorioAmigo.ValidarAmigos();

               if (validacao)
                    return;

               repositorioAmigo.ExibirAmigos("Exibindo Amigos...\n");
               Console.ReadLine();
          }

          private void AtualizarAmigo()
          {
               bool validacao = repositorioAmigo.ValidarAmigos();

               if (validacao)
                    return;

               repositorioAmigo.ExibirAmigos("Atualizando Amigos...\n");

          idatualizacao:
               Console.Write("\nEntre com o número da caixa que deseja atualizar:\n> ");
               int idAmigo = Convert.ToInt32(Console.ReadLine());

               NegocioAmigo atualizarAmigo = repositorioAmigo.PegarIdAmigos(idAmigo);

               if (atualizarAmigo == null)
               {
                    ImprimirTexto("\nEntre com uma ID válida!", ConsoleColor.Red, 1);
                    goto idatualizacao;
               }

               Console.Write("\nEntre com o novo NOME:\n> ");
               string novoNome = Console.ReadLine();

               Console.Write("\nEntre com o novo nome do RESPONSÁVEL:\n> ");
               string novoResponsável = Console.ReadLine();

               Console.Write("\nEntre com o seu novo ENDEREÇO:\n> ");
               string novoEndereco = Console.ReadLine();

               Console.Write("\nEntre com o seu novo TELEFONE:\n> ");
               string novoTelefone = Console.ReadLine();

               Console.Write("\nEntre com a nova ID de usuário:\n> ");
               int novaID = Convert.ToInt32(Console.ReadLine());

               bool idInvalido = repositorioAmigo.ValidarIdAmigos(novaID);

               if (idInvalido)
               {
                    ImprimirTexto("\nID já registrada!", ConsoleColor.Red, 1);
                    AtualizarAmigo();
                    return;
               }

               atualizarAmigo.Nome = novoNome;
               atualizarAmigo.NomeResponsavel = novoResponsável;
               atualizarAmigo.Endereco = novoEndereco;
               atualizarAmigo.Telefone = novoTelefone;
               atualizarAmigo.IdAmigo = novaID;
               ImprimirTexto("\nAtualização Finalizada!", ConsoleColor.Green, 1);
          }

          private void RemoverAmigo()
          {
               bool validacao = repositorioAmigo.ValidarAmigos();

               if (validacao)
                    return;

               repositorioAmigo.ExibirAmigos("Removendo Amigos...\n");

          idremocao:
               Console.Write("\nEntre com o número da ID do amigo que deseja remover:\n> ");
               int idAmigo = Convert.ToInt32(Console.ReadLine());
               NegocioAmigo removerAmigo = repositorioAmigo.PegarIdAmigos(idAmigo);

               if (removerAmigo == null)
               {
                    ImprimirTexto("\nEntre com um número válido!", ConsoleColor.Red, 1);
                    goto idremocao;
               }

               repositorioAmigo.RemoverAmigos(removerAmigo);
               ImprimirTexto("\nRemoção finalizada!", ConsoleColor.Green, 1);
          }
     }
}
