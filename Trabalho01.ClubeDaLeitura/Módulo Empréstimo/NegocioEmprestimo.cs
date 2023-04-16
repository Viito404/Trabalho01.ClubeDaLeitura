using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho01.ClubeDaLeitura.Módulo_Amigo;
using Trabalho01.ClubeDaLeitura.Módulo_Caixa;
using Trabalho01.ClubeDaLeitura.Módulo_Revista;

namespace Trabalho01.ClubeDaLeitura.Módulo_Empréstimo
{
     internal class NegocioEmprestimo
     {
          private NegocioAmigo emprestimoAmigo;
          private NegocioRevista emprestimoRevista;
          private string dataEmprestimo, dataDevolucao;

          public NegocioAmigo EmprestimoAmigo { get { return emprestimoAmigo; } set { emprestimoAmigo = value; } }
          public NegocioRevista EmprestimoRevista { get { return emprestimoRevista; } set { emprestimoRevista = value; } }
          public string DataEmprestimo { get { return dataEmprestimo; } set { dataEmprestimo = value; } }
          public string DataDevolucao { get { return dataDevolucao; } set { dataDevolucao = value; } }

          public NegocioEmprestimo(NegocioAmigo emprestimoAmigo, NegocioRevista emprestimoRevista, string dataEmprestimo, string dataDevolucao)
          {
               this.emprestimoAmigo = emprestimoAmigo;
               this.emprestimoRevista = emprestimoRevista;
               this.dataEmprestimo = dataEmprestimo;
               this.dataDevolucao = dataDevolucao;
          }
     }
}
