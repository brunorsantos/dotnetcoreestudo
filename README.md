# Dot net core Estudo



## C# Fundamentals
[C# Fundamentals with Visual Studio 2015](https://app.pluralsight.com/library/courses/c-sharp-fundamentals-with-visual-studio-2015/table-of-contents)

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

### Assemblies

Pacotes sao salvos em DLL. 
Para adicionar devemos ir em references no visual Studio. Onde podemos buscar na web, em arquivos locais ou dentro da solução(Em um novo projeto de teste dentro da solução é um exemplo disso).

Após adicionar um assembly no projeto, é possivel referenciar ao seu namespace com 'using'

É possivel navegar no assembly. Basta ir na sua referencia, clicar com botao direito e em 'View in Object Browser'

### Types

Struct e enum, são tipos que são utilizados como constantes, com a vantagem e serem similares a objetos no sentido de poderem ser criados tipos para obrigar a utilizar uma passagem de parametro via enum ou struct.

Enum só permite valores numericos (utilizado para evitar numeros magicos no codigo)

Array tem tamanho fixo em C#. O tamanho até pode ser mudado, porém é uma operação cara.
Array é um tipo de referencia, isto é utlizado como objeto
```c
float[] grades;
grades = new float[3];
```

### Methods

Metodos em C# podem ser sobrecarregados, isto é podem ser criados mais um medoto com o mesmo nome, considerando que os mesmos tenham parametros diferentes (quantidade ou tipo). 

No auto preenchimento do VisualStudio, são mostrados todos os metodos com a mesmo nome(sobrecarga)

Nas assinaturas de metodos, é possivel incluir uma palavra chave 'params', sempre como o ultimo parametro para indicar a possibilidade de passar qualquer numero de parametros para o metodo. Que será interpretado como um array de parametros

```c
static void WriteResult(string description, params float[] result)
{
    Console.WriteLine("{0}: {1}", description, result);
}
```

No exemplo acima, "Console.WriteLine" tambem se comporta como um metodo sendo chamado com a keyword params na assintatura para aceitar um numero de parametros variavel (do tipo objeto)

### Fields and Properties

C# possui implementações para getters e setters.

```c
public string Name
{
    get; set;
}
```

```c
private string _name;
public string Name
{
    get
    {
        reuturn _name    
    }
    set
    {
        if(!String.IsNullOrEmpty(value))
        {
            _name = value
        }
    }
}
```

Os dois exemplos são duas formas de usar getter e setters. em que na chamada basta utlizar classe.Name;



### Events
Explicar delegates

### Using (finaly ou catch)

https://docs.microsoft.com/pt-br/dotnet/csharp/language-reference/keywords/using-statement

### Polimorfismo

Para utilizar o polimorfirsmo é necessario declarar o metodos como virtuais.
A clausula virtual permite que o metodo seja sobrescrito por um metodo de classe filha. (Utilizando clasula overrides).

Em tempo de execucao quando um metodo virtual é executado, ele verifica se o objeto é uma instancia de uma classe filha com medodo que sobrescreve o metodo como virtual.

Metodos de classes abstratas são sempre virtuais

Explicar virtual e overrides, explicar que metodos de classes abstratas são virtuais

### Interfaces

Interfaces são declaradas sempre com a letra I no inicio. 
Elas são estendidas na mesma sintaxe que heranças. Caso uma interface seja usada junto com uma herança, ela deve ser extendida por ultimo.

Interfaces importantes: 

IDisposable, IEnumerable, INotifyPropertyChanges, IComparable




## Best Practices - Collections and Generics

### Intro

Dois tipo de collection, lists e dictinaries.

### Array

Possui tamanho fixo que deve ser definido no incio do codigo
Declarando um array:
```C
string[] colorOptions = new string[5]
```

Pode se utilizar 'var' como tipo implicito para declarar um array, em que o tipo será o mesmo tipo utilizado na instancia

```c
var colorOptions = new string[5]
```

Inicializando array:

```c
string[] colorOptions = { "Red", "Espresso", "white", "Navy"};
```

Existem metodos estaticos da classe System.Array como 'indexOf()' e metodos de instancia como 'setValue()'


### Generic

Permite definir um tipo de dado a ser passado ao instanciar uma classe. Por convenção se utliza 'T'.

```c
public class OperationResult<T>
{
    public OperationResult()
    {
    }

    public OperationResult(T success, string message) : this()
    {
        this.Success = success;
        this.Message = message;
    }

    public T Success { get; set; }
    public string Message { get; set; }
}
```

Para utlizar a classe, tanto ao instanciar, quanto para definir um tipo, deve se passar o tipo do 'T'

```c
public OperationResult<decimal> CalculateSuggestedPrice(decimal markupPercent) {
    var message = "";
    if (markupPercent <= 0m) 
    {
        message = "Invalid";
    } else if (markupPercent < 10) {
        message = "Bellow recomended";
    }
    var value = this.Cost + (this.Cost * markupPercent / 100);
    var operationalResult = new OperationResult<decimal>(value, message);
    return operationalResult;
}
```

Para metodos genericos, o tipo 'T' poder ser definido tanto na classe, ou entao na propria chamada do metodo.

```c
public T RetrieveValue<T>(string sql, T defaulValue)
{
    T value = defaulValue;

    return value;
}
```

```c
var actual = repository.RetrieveValue<string>("Select...", "test");
```

Generic constraints servem para limitar que qual o tipo da generic

https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/where-generic-type-constraint

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
