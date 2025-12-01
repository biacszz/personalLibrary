using System;
using System.Collections.Generic;
using System.IO;

namespace personalLibrary {

    public static class Arquivos
    {
        public static void salvar(Estante estante, string arq)
        {
            try
            {
                using (StreamWriter arquivo = new StreamWriter(arq))
                {
                    // cabeçalho com nome da estante
                    arquivo.WriteLine($"ESTANTE:{estante.Nome}");
                    
                    foreach (ItemEstante item in estante.GetItens())
                    {
                        string tipo = item is Livro ? "LIVRO" : "GIBI";
                        string linha = $"{tipo};{item.Titulo};{item.Autor};{item.AnoPublicacao};{item.Paginas};{item.Avaliacao};{(int)item.Status}";
                        
                        if (item is Gibi gibi)
                        {
                            linha += $";{gibi.Editora};{gibi.NumeroEdicao}";
                        }
                        
                        arquivo.WriteLine(linha);
                    }
                }
                Console.WriteLine($"estante devidamente salva em '{arq}'!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"houve um erro ao salvar: {e.Message}");
            }
        }

        public static void load(Estante estante, string arq)
        {
            try
            {
                if (!File.Exists(arq))
                {
                    Console.WriteLine($"\narquivo '{arq}' não encontrado!");
                    return;
                }
                
                using (StreamReader reader = new StreamReader(arq))
                {
                    string cabecalho = reader.ReadLine();
                    
                    int contador = 0;
                    
                    string linha;
                    while ((linha = reader.ReadLine()) != null)
                    {
                        // split divide a linha usando ; como separador
                        string[] dados = linha.Split(';');
                        
                        // verifica se a linha tem dados suficientes
                        if (dados.Length < 7)
                            continue;
                        
                        // extrai os dados comuns a Livro e Gibi
                        string tipo = dados[0];
                        string titulo = dados[1];
                        string autor = dados[2];
                        int ano = int.Parse(dados[3]);
                        int paginas = int.Parse(dados[4]);
                        int avaliacao = int.Parse(dados[5]);
                        
                        // ex: Enum.Parse transforma "Lendo" na constante StatusLeitura.Lendo
                        ItemEstante.StatusLeitura status = (ItemEstante.StatusLeitura)
                            Enum.Parse(typeof(ItemEstante.StatusLeitura), dados[6]);
                        
                        ItemEstante item = null;
                        
                        if (tipo == "LIVRO")
                        {
                            item = new Livro(titulo, autor, ano, paginas);
                        }
                        else if (tipo == "GIBI" && dados.Length >= 9)
                        {
                            string editora = dados[7];
                            int numeroEdicao = int.Parse(dados[8]);
                            item = new Gibi(titulo, autor, ano, paginas, editora, numeroEdicao);
                        }
                        
                        // se criou um item válido, configura avaliação e status
                        if (item != null)
                        {
                            item.Avaliacao = avaliacao;
                            item.Status = status;
                            estante.AddItem(item);
                            contador++;
                        }
                    }
                    
                    Console.WriteLine($"\nestante carregada com sucesso! {contador} item(ns) adicionado(s).");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nerro ao carregar: {ex.Message}");
            }
        }
    }
}