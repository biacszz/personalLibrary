using System;
using System.Collections.Generic;

namespace personalLibrary {

    public class Livro : ItemEstante
    {
    // : base() é usado pra chamar o construtor da classe base
        public Livro(string titulo, string autor, int anoPublicacao, int paginas)
            : base(titulo, autor, anoPublicacao, paginas)
        {

        }

        // 
        public override string ObterDescricao()
        {
            return $"[LIVRO] {base.ObterDescricao()}";
        }
    }
}