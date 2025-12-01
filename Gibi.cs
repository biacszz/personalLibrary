using System;
using System.Collections.Generic;

namespace personalLibrary {

    public class Gibi : ItemEstante
    {
        public string Editora;
        public int NumeroEdicao;

        public Gibi(string titulo, string autor, int anoPublicacao, int paginas, string editora, int numeroEdicao) 
        : base(titulo, autor, anoPublicacao, paginas)
        {
            this.Editora = editora;
            this.NumeroEdicao = numeroEdicao;
        }

        // sobrescrevendo o método para informações específicas de Gibi
        public override string ObterDescricao()
        {
            return $"[GIBI] {this.Editora} #{this.NumeroEdicao}\n{base.ObterDescricao()}";
        }
    }
}