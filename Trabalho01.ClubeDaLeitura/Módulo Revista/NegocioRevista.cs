using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho01.ClubeDaLeitura.Módulo_Caixa;

namespace Trabalho01.ClubeDaLeitura.Módulo_Revista
{
     internal class NegocioRevista
     {
          private string tipoColecao;
          private int numeroEdicao, idRevista;
          private int anoRevista;
          private NegocioCaixa caixaRevista;

          public string TipoColecao { get { return tipoColecao; } set { tipoColecao = value; } }
          public int NumeroEdicao { get { return numeroEdicao; } set { numeroEdicao = value; } }
          public int IdRevista { get { return idRevista; } set { idRevista = value; } }
          public int AnoRevista { get { return anoRevista; } set { anoRevista = value; } }
          public NegocioCaixa CaixaRevista { get { return caixaRevista; } set { caixaRevista = value; } }

          public NegocioRevista(string tipoColecao, int numeroEdicao, int anoRevista, int idRevista, NegocioCaixa caixaRevista)
          {
               this.tipoColecao = tipoColecao;
               this.numeroEdicao = numeroEdicao;            
               this.anoRevista = anoRevista;
               this.idRevista = idRevista;
               this.caixaRevista = caixaRevista;
          }
     }
}
