using System;
using System.Collections.Generic;

namespace personalLibrary {

    public class Leitor
    {
        public string Nome;
        public Estante MinhaEstante;

        public Leitor(string nome)
        {
            this.Nome = nome;
            this.MinhaEstante = new Estante($"Estante de {nome}");
        }
    }
}