using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho01.ClubeDaLeitura.Utilitários
{
     public class Tela
     {
          public void ImprimirTexto(string mensagem, ConsoleColor cor, int num)
          {
               Console.ForegroundColor = cor;
               Console.WriteLine(mensagem);
               Console.ResetColor();

               if (num == 1)
               {
                    Console.ReadLine();
               }
          }

          public string GerarMenu(string titulo, ConsoleColor cor, int tipo)
          {
               string descricao;

               if (tipo == 0)
                    descricao = "\n[1] CAIXAS;\n[2] AMIGOS;\n[3] REVISTAS\n[4] EMPRÉSTIMOS;\n[0] SAIR.";
               else if (tipo == 1)
                    descricao = "\n[1] CRIAR;\n[2] VISUALIZAR;\n[3] ATUALIZAR;\n[4] REMOVER;\n[0] SAIR.";
               else
                    descricao = "\n[1] CRIAR;\n[2] VISUALIZAR EMPRÉSTIMOS MÊS;\n[3] VISUALIZAR EMPRÉSTIMOS ABERTOS;\n[0] SAIR.";
              
                    Console.Clear();
                    Console.WriteLine($"| {titulo} |");
                    Console.ForegroundColor = cor;
                    Console.WriteLine(descricao);
                    Console.ResetColor();
                    Console.Write("\nEntre com a opção desejada:\n> ");
                    string opcao = Console.ReadLine();
                    return opcao;
               }
          }
     }

