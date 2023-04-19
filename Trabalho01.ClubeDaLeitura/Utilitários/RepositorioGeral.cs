using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho01.ClubeDaLeitura.Módulo_Caixa;
using Trabalho01.ClubeDaLeitura.Módulo_Revista;

namespace Trabalho01.ClubeDaLeitura.Utilitários
{
     public class RepositorioGeral : Tela
     {
          public ArrayList dados = new ArrayList(); 

          public void Gravar(Entidade elemento)
          {
               dados.Add(elemento);
          }

          public void Remover(Entidade elemento)
          {
               dados.Remove(elemento);
          }

          public virtual bool ValidarElementos()
          {
               if (dados.Count == 0)
               {
                    ImprimirTexto("\nNenhum elemento cadastrado!", ConsoleColor.DarkYellow, 1);
                    return true;
               }
               else
               {
                    return false;
               }
          }
     }

}
