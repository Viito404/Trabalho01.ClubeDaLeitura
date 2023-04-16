using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho01.ClubeDaLeitura.Módulo_Amigo
{
     internal class NegocioAmigo
     {
          private string nome, nomeResponsavel, endereco, telefone;
          private int idAmigo;

          public string Nome { get { return nome; } set {  nome = value; } }
          public string NomeResponsavel { get { return nomeResponsavel; } set { nomeResponsavel = value; } }
          public string Endereco { get { return endereco; } set { endereco = value; } }
          public string Telefone { get { return telefone; } set { telefone = value; } }
          public int IdAmigo { get { return idAmigo; } set { idAmigo = value; } }

          public NegocioAmigo(string nome, string nomeResponsavel, string endereco, string telefone, int idAmigo)
          {
               this.nome = nome;
               this.nomeResponsavel = nomeResponsavel;
               this.endereco = endereco;
               this.telefone = telefone;
               this.idAmigo = idAmigo;
          }
     }
}
