# personalLibrary

## Descrição do Projeto

Este projeto é um **Sistema de Gerenciamento de Biblioteca Pessoal** (um "Minha Estante" digital) desenvolvido em C\#. Ele opera via **aplicação de console** e utiliza conceitos de Programação Orientada a Objetos (POO), como herança, classes abstratas e interfaces, para organizar e rastrear o progresso de leitura de livros e gibis.

O objetivo principal é permitir que o usuário:

  * **Adicione** diferentes tipos de itens (`Livro` e `Gibi`).
  * **Gerencie** o status de leitura (Quero Ler, Lendo, Lido, Abandonado).
  * **Avalie** itens com estrelas.
  * **Salve e carregue** os dados da estante em um arquivo de texto (`.txt`) para persistência.

-----

## Estrutura do Projeto (Modularização POO)

O código foi modularizado em classes e um único `namespace` (`BibliotecaPessoal`), refletindo uma arquitetura limpa e manutenível.

| Arquivo (`.cs`) | Tipo | Responsabilidade |
| :--- | :--- | :--- |
| `ItemEstante.cs` | Classe Abstrata/Enum | Define a base comum para todos os itens (Título, Autor, Status, Avaliação) e o enum `StatusLeitura`. |
| `Livro.cs` | Classe Concreta | Item genérico que herda de `ItemEstante`. |
| `Gibi.cs` | Classe Concreta | Item específico que herda de `ItemEstante` e adiciona `Editora` e `NumeroEdicao`. |
| `IEstante.cs` | Interface | Define o contrato de gerenciamento (Adicionar, Remover, Listar, Buscar). |
| `Estante.cs` | Classe Concreta | Implementa a interface `IEstante`, usando uma `List<ItemEstante>` para armazenar os itens. |
| `Leitor.cs` | Classe Concreta | Representa o usuário e estabelece relação de agregação para com `Estante`. |
| `Arquivos.cs` | Classe Estática | Responsável por salvar e carregar os dados no arquivo `estante.txt`. |
| `Program.cs` | Principal | Contém o método `Main()` e a lógica de interação (Menu) com o usuário. |

-----

## Como Executar o Projeto

### Pré-requisitos

Para compilar e rodar este projeto, você precisa ter instalado o **.NET SDK**.

  * [**Instalar .NET SDK** (Versão 8.0 ou superior recomendada)]

### Compilação e Execução

1.  **Clone o repositório:**

    ```bash
    git clone https://github.com/biacszz/personalLibrary
    cd [Nome da Pasta do Repositório]
    ```

2.  **Compile o projeto:**

    ```bash
    dotnet build
    ```

3.  **Execute a aplicação:**

    ```bash
    dotnet run
    ```

    O console será iniciado com a saudação e o menu principal.

-----

## Funcionalidades

O programa oferece as seguintes opções principais no menu:

| Opção | Ação | Detalhes |
| :---: | :--- | :--- |
| **1/2** | Adicionar Livro/Gibi | Cria uma nova instância de `Livro` ou `Gibi` e a adiciona à estante. |
| **3** | Listar Todos | Exibe todos os itens com suas descrições e status. |
| **4** | Remover Item | Permite remover um item da estante buscando pelo título. |
| **5** | Registrar Leitura | Altera o `StatusLeitura` de um item (Lendo, Lido, etc.). |
| **6** | Avaliar Item | Atribui uma avaliação de 0 a 5 estrelas. |
| **7** | Buscar Item | Possibilita a busca de um item da estante por meio do seu título, ou parte dele. |
| **8** | Listar por Status | Filtra e exibe itens com um status específico (ex: todos os `Lidos`). |
| **9/10** | Salvar/Carregar | Usa a classe `Persistencia` para gravar/ler o estado da estante em `estante.txt`. |

-----

## Contribuições

Este projeto foi criado com fins acadêmicos/prática de POO. Contribuições, sugestões ou *issues* são bem-vindas\!
