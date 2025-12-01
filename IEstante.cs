using System;
using System.Collections.Generic;

namespace personalLibrary {

    public interface IEstante
    {
        void AddItem(ItemEstante item);
        void RemoverItem(string titulo);
        void ListarItens();
        void ListarStatus(ItemEstante.StatusLeitura status);
        void BuscarTitulo(string titulo);
        ItemEstante BuscaIndice(int indice);
        int qtdeItens();
    }
}