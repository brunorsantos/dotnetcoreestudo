# Dot net core Estudo


## C# Fundamentals

### Intruducao

CLR (Common Language Runtime) - Ambiente de execução para a linguagem, reponsavel pela execucao. Cuida do gerenciamento de memoria, gerenciamento de hardware e sistema operacional e gerencia a linguagem que está a aplicacao (C#, Visual Basic, S#...).


FCL (Framework Class Library) - Provem a funcionalidades para codificar a aplicação

O CLR procura a metodo estatico main da classe Program para iniciar a execução.

Namespaces são separado utilizando '.'

```c
using System;

public class Program
{
    static void Main(){
        Console.WriteLine("Hello World");
        // System.Console.WriteLine('Hello World');
    }
}
```

Toda variavel no C# precisa ser declarada com tipo.

### Classes

Generic Lists devem ser instanciadas antes de utilizar

Metodos e atributos estaticos são chamados utilizando apenas '.' após o nome da classe

### CLI

https://docs.microsoft.com/pt-br/dotnet/core/tools/dotnet-new?tabs=netcore21

Com dotnet new é possivel criar vários tipos de projeto. (Console, api, mvc...)


### Estrutura basica

no arquivo csproj na raiz do projeto, é descrito o tipo de projeto e determina as dependencias do projeto


dotnet build - faz o build (Compilacao do projeto)
dotnet run -  executa 
dotnet restore - Restaura dependencias do projeto
dotnet watch run
dotnet add package - inclui uma dependencia no projeto
