using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho01.ClubeDaLeitura.Módulo_Revista;
using Trabalho01.ClubeDaLeitura.Utilitários;

namespace Trabalho01.ClubeDaLeitura.Módulo_Empréstimo
{
     internal class RepositorioEmprestimo : RepositorioGeral
     {
          public bool ValidarEmprestimo()
          {
               if (dados.Count == 0)
               {
                    ImprimirTexto("\nNenhum empréstimo cadastrado!", ConsoleColor.DarkYellow, 1);
                    return true;
               }
               else
               {
                    return false;
               }

          }
          public void EmprestimosMes()
          {
               DateTime diaAtual = DateTime.Today;
               int mesAtual = diaAtual.Month;
               Console.Clear();
               ImprimirTexto("Visualizando empréstimos do mês...\n", ConsoleColor.DarkGray, 1);
               Console.WriteLine($"Empréstimo realizados desse mês ({mesAtual}):");

               foreach (NegocioEmprestimo emprestimo in dados)
               {
                    DateTime compararDataAbertura = DateTime.ParseExact(emprestimo.DataEmprestimo, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    if (compararDataAbertura.Month == mesAtual)
                    {
                         Console.ForegroundColor = ConsoleColor.DarkCyan;
                         Console.WriteLine($"Revista: {emprestimo.EmprestimoRevista.TipoColecao}\nAmigo: {emprestimo.EmprestimoAmigo.Nome}\nData abertura do empréstimo: {emprestimo.DataEmprestimo}\nData da devolução: {emprestimo.DataDevolucao}");
                         Console.WriteLine();
                         Console.ResetColor();
                    }
               }
               Console.ReadLine();
          }
          public void EmprestimosAbertos()
          {
               Console.Clear();
               ImprimirTexto("Visualizando empréstimos abertos...\n", ConsoleColor.DarkGray, 1);
               DateTime dataAtual = DateTime.Today;
               Console.WriteLine($"\nEmpréstimo abertos: ");
               foreach (NegocioEmprestimo emprestimo in dados)
               {
                    DateTime DataAberturaEmprestimo = DateTime.ParseExact(emprestimo.DataEmprestimo, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime DataDevolucao = DateTime.ParseExact(emprestimo.DataDevolucao, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    System.TimeSpan diasAberto = DataDevolucao.Subtract(DataAberturaEmprestimo);
                    if (DataAberturaEmprestimo < DataDevolucao && DataDevolucao > dataAtual)
                    {
                         Console.ForegroundColor = ConsoleColor.DarkCyan;
                         Console.WriteLine($"\nRevista: {emprestimo.EmprestimoRevista.TipoColecao}\nAmigo: {emprestimo.EmprestimoAmigo.Nome}\nData abertura do empréstimo: {emprestimo.DataEmprestimo}");
                         Console.WriteLine("Dias Aberto: {0:dd}", diasAberto);
                         Console.ResetColor();
                    }
               }
               Console.ReadLine();
          }
          public bool VerificarAmigosRevistas(int id)
          {
               bool revistaAmigo = false;

               foreach (NegocioEmprestimo emprestimo in dados)
               {
                    if (emprestimo.EmprestimoAmigo.IdAmigo == id)
                    {
                         revistaAmigo = true;
                    }
                    else
                    {
                         revistaAmigo = false;
                    }
               }
               return revistaAmigo;
          }
          public bool VerificarRevistaDisponivel(NegocioRevista revista)
          {
               bool revistaDisponivel = true;

               foreach (NegocioEmprestimo emprestimo in dados)
               {
                    if (emprestimo.EmprestimoRevista.IdRevista == revista.IdRevista)
                    {
                         revistaDisponivel = false;
                    }
                    else
                    {
                         revistaDisponivel = true;
                    }
               }

               return revistaDisponivel;
          }
     }
}
