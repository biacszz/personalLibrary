using System;
using System.Collections.Generic;

namespace personalLibrary {

    public abstract class ItemEstante
    {
        public enum StatusLeitura
        {
            NaoDefinido,
            QueroLer,
            Lendo,
            Lido,
            Abandonado
        }

        public string Titulo;
        public string Autor;
        public int AnoPublicacao;
        public int Paginas;
        public int Avaliacao; 
        public StatusLeitura Status;

        protected ItemEstante(string titulo, string autor, int anoPublicacao, int paginas)
        {
            this.Titulo = titulo;
            this.Autor = autor;
            this.AnoPublicacao = anoPublicacao;
            this.Paginas = paginas;
            this.Avaliacao = 0; // Sem avaliação inicial
            this.Status = StatusLeitura.NaoDefinido;
        }

        public virtual string ObterDescricao()
        {
            //new string(caractere, quantidade_de_vezes)
            string estrelas = this.Avaliacao > 0 ? new string('*', this.Avaliacao) : "Sem avaliacao";
            //$ garante interpolação de strings
            return $"[{this.Status}] '{this.Titulo}'\n{this.Autor} ({this.AnoPublicacao})\n{this.Paginas}pags\n{estrelas}";
        }

        public void Avaliar(int estrelas)
        {
            if (estrelas < 0 || estrelas > 5)
            {
                Console.WriteLine("Avaliacao deve ser entre 0 e 5 estrelas!");
                return;
            }
            
            this.Avaliacao = estrelas;
            Console.WriteLine($"Avaliacao de '{this.Titulo}' atualizada para {estrelas} estrela(s)!");
        }

        public void RegistrarLeitura(StatusLeitura novoStatus)
        {
            this.Status = novoStatus;
            
            switch (novoStatus)
            {
                case StatusLeitura.Lendo:
                    Console.WriteLine($"'{this.Titulo}' marcado como EM LEITURA");
                    break;
                    
                case StatusLeitura.Lido:
                    Console.WriteLine($"'{this.Titulo}' marcado como LIDO!");
                    break;
                    
                case StatusLeitura.Abandonado:
                    Console.WriteLine($"'{this.Titulo}' marcado como ABANDONADO");
                    break;
                    
                case StatusLeitura.QueroLer:
                    Console.WriteLine($"'{this.Titulo}' adicionado à lista de QUERO LER");
                    break;
            }
        }
    }
}