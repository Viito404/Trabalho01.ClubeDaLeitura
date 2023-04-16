using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho01.ClubeDaLeitura.Módulo_Caixa;
using Trabalho01.ClubeDaLeitura.Utilitários;

namespace Trabalho01.ClubeDaLeitura.Módulo_Revista
{
     internal class RepositorioRevista : RepositorioGeral
     {
          public void GravarRevistas(NegocioRevista revistaGravada)
          {
               dados.Add(revistaGravada);
          }

          public bool ValidarRevistas()
          {
               if (dados.Count == 0)
               {
                    Program.ImprimirMensagem("\nNenhuma revista cadastrada!", ConsoleColor.DarkYellow, 1);
                    return true;
               }
               else
               {
                    return false;
               }

          }

          public bool ValidarIdRevistas(int idRevista)
          {
               bool invalido = false;
               foreach (NegocioRevista RevistaID in dados)
               {
                    if (RevistaID.IdRevista == idRevista)
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

          public NegocioRevista PegarIdRevistas(int idRevista)
          {
               NegocioRevista revista = null;

               foreach (NegocioRevista revistaId in dados)
               {
                    if (revistaId.IdRevista == idRevista)
                    {
                         revista = revistaId;
                    }
               }
               return revista;
          }

          public void ExibirRevistas(string mensagem)
          {
               Console.Clear();
               Program.ImprimirMensagem(mensagem, ConsoleColor.DarkGray, 0);
               Console.BackgroundColor = ConsoleColor.Blue;
               Console.ForegroundColor = ConsoleColor.White;
               Console.WriteLine("| {0,-10} | {1,-20} | {2,-15} | {3,-20} | {4,-25} |", "ID", "COLEÇÃO", "EDIÇÃO", "ANO REVISTA", "CAIXA");
               Console.ResetColor();
               Console.WriteLine();

               foreach (NegocioRevista revista in dados)
               {
                    Console.WriteLine("| {0,-10} | {1,-20} | {2,-15} | {3,-20} | {4,-25} |", revista.IdRevista, revista.TipoColecao, revista.NumeroEdicao, revista.AnoRevista, $"{revista.CaixaRevista.Numero} : {revista.CaixaRevista.Etiqueta} : {revista.CaixaRevista.Cor}");
               }
          }

          public void RemoverRevistas(NegocioRevista revistaRemovida)
          {
               dados.Remove(revistaRemovida);
          }
     }
}
