using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho01.ClubeDaLeitura.Módulo_Caixa;
using Trabalho01.ClubeDaLeitura.Utilitários;

namespace Trabalho01.ClubeDaLeitura.Módulo_Amigo
{
     internal class RepositorioAmigo : RepositorioGeral
     {
          public void GravarAmigos(NegocioAmigo amigoGravado)
          {
               dados.Add(amigoGravado);
          }

          public bool ValidarAmigos()
          {
               {
                    if (dados.Count == 0)
                    {
                         Program.ImprimirMensagem("\nNenhum amigo cadastrado!", ConsoleColor.DarkYellow, 1);
                         return true;
                    }

                    else
                    {
                         return false;
                    }
               }
          }

          public bool ValidarIdAmigos(int idAmigo)
          {
               bool invalido = false;
               foreach (NegocioAmigo amigoID in dados)
               {
                    if (amigoID.IdAmigo == idAmigo)
                    {
                         invalido = true;
                         return invalido;
                    }
                    else
                    {
                         invalido = false;
                    }
               }
               return invalido;
          }

          public NegocioAmigo PegarIdAmigos(int idAmigo)
          {
               NegocioAmigo amigo = null;

               foreach (NegocioAmigo amigoId in dados)
               {
                    if (amigoId.IdAmigo == idAmigo)
                    {
                         amigo = amigoId;
                    }
               }
               return amigo;
          }

          public void ExibirAmigos(string mensagem)
          {
               Console.Clear();
               Program.ImprimirMensagem(mensagem, ConsoleColor.DarkGray, 0);
               Console.BackgroundColor = ConsoleColor.Blue;
               Console.ForegroundColor = ConsoleColor.White;
               Console.WriteLine("| {0,-20} | {1,-20} | {2,-20} | {3,-20} | {4,-20} |", "ID", "NOME", "RESPONSÁVEL","ENDEREÇO","TELEFONE");
               Console.ResetColor();
               Console.WriteLine();

               foreach (NegocioAmigo amigo in dados)
               {
                    Console.WriteLine("| {0,-20} | {1,-20} | {2,-20} | {3,-20} | {4,-20} |", amigo.IdAmigo, amigo.Nome, amigo.NomeResponsavel, amigo.Endereco, amigo.Telefone);
               }               
          }

          public void RemoverAmigos(NegocioAmigo amigoRemovido)
          {
               dados.Remove(amigoRemovido);
          }
     }
}
