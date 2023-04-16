using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho01.ClubeDaLeitura.Módulo_Caixa
{
     internal class NegocioCaixa
     {
          private string cor, etiqueta;
          private int numero;

          public string Cor { get { return cor; } set { cor = value; } }
          public string Etiqueta { get { return etiqueta; } set { etiqueta = value; } }
          public int Numero { get { return numero; } set { numero = value; } }

          public NegocioCaixa(string cor, string etiqueta, int numero)
          {
               this.cor = cor;
               this.etiqueta = etiqueta;
               this.numero = numero;
          }

     }
}
