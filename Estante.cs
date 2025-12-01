using System;
using System.Collections.Generic;

namespace personalLibrary {

    public class Estante : IEstante
    {
        private List<ItemEstante> itens = new List<ItemEstante>();
        public string Nome;

        public List<ItemEstante> GetItens()
        {
        return new List<ItemEstante>(this.itens); // devolve cópia para não permitir edição externa
        }

        public Estante(string nome)
        {
            this.Nome = nome;
        }

        public void AddItem(ItemEstante item)
        {
            this.itens.Add(item);
            Console.WriteLine($"'{item.Titulo}' adicionado à estante '{this.Nome}'!");
        }

        public void RemoverItem(string titulo)
        {
            itens.RemoveAll(x => x.Titulo.Contains(titulo, StringComparison.OrdinalIgnoreCase));
        }

        public void ListarItens()
        {
            Console.WriteLine($"\n--- MINHA ESTANTE: {this.Nome} ---");
            if (this.itens.Count == 0)
            {
                Console.WriteLine("A estante esta vazia... que tal adicionar um livro?");
            }
            else
            {
                for (int i = 0; i < this.itens.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {this.itens[i].ObterDescricao()}");
                }
            }
            Console.WriteLine($"Total de itens: {this.itens.Count}\n");
        }

        public void ListarStatus(ItemEstante.StatusLeitura status)
        {
            Console.WriteLine($"\n--- {status.ToString().ToUpper()} ---");
            var filtrados = itens.FindAll(i => i.Status == status);

            if (filtrados.Count == 0)
            {
                Console.WriteLine("Nenhum item encontrado.");
                return;
            }

            foreach (var item in filtrados)
                Console.WriteLine(" • " + item.ObterDescricao());
        }


        public void BuscarTitulo(string titulo)
        {
            var resultados = this.itens.FindAll(item => 
                item.Titulo.Contains(titulo, StringComparison.OrdinalIgnoreCase));
            
            Console.WriteLine($"\n--- Busca por '{titulo}' ---");
            if (resultados.Count == 0)
            {
                Console.WriteLine("Nenhum item encontrado.");
            }
            else
            {
                foreach (var item in resultados)
                {
                    Console.WriteLine($" • {item.ObterDescricao()}");
                }
            }
        }

        public ItemEstante BuscaIndice(int indice)
        {
            if (indice >= 0 && indice < this.itens.Count)
                return this.itens[indice];
            return null;
        }

        public int qtdeItens()
        {
            return this.itens.Count;
        }
    }
}
