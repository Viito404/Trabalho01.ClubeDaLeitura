using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho01.ClubeDaLeitura.Utilitários;

namespace Trabalho01.ClubeDaLeitura.Módulo_Caixa
{
     internal class RepositorioCaixa : RepositorioGeral
     {
          public void GravarCaixas(NegocioCaixa caixaGravada)
          {
               dados.Add(caixaGravada);
          }

          public bool ValidarCaixas()
          {
               if (dados.Count == 0)
               {
                    ImprimirTexto("\nNenhuma caixa cadastrada!", ConsoleColor.DarkYellow, 1);
                    return true;
               }
               else
               {
                    return false;
               }

          }

          public bool ValidarIdCaixas(int idCaixa)
          {
               bool invalido = false;
               foreach (NegocioCaixa caixaID in dados)
               {
                    if(caixaID.Numero == idCaixa)
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

          public NegocioCaixa PegarIdCaixas(int idCaixa)
          {
               NegocioCaixa caixa = null;

               foreach (NegocioCaixa caixaId in dados)
               {
                    if (caixaId.Numero == idCaixa)
                    {
                         caixa = caixaId;
                    }
               }
               return caixa;
          }

          public void ExibirCaixas(string mensagem)
          {
               Console.Clear();
               ImprimirTexto(mensagem, ConsoleColor.DarkGray, 0);
               Console.BackgroundColor = ConsoleColor.Blue;
               Console.ForegroundColor = ConsoleColor.White;
               Console.WriteLine("| {0,-10} | {1,-20} | {2,-20} |","ID","COR","ETIQUETA");
               Console.ResetColor();
               Console.WriteLine();

               foreach (NegocioCaixa caixa in dados)
               {
                    Console.WriteLine("| {0,-10} | {1,-20} | {2,-20} |", caixa.Numero, caixa.Cor, caixa.Etiqueta);
               }              
          }

          public void RemoverCaixas(NegocioCaixa caixaRemovida)
          {
               dados.Remove(caixaRemovida);
          }
     }
}
