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

https://app.pluralsight.com/player?course=csharp-fundamentals-dev&author=scott-allen&name=21d914d0-b0ef-4232-b4de-e1a0802dec94&clip=10&mode=live

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

[Best Practices - Collections and Generics 2015](https://app.pluralsight.com/library/courses/csharp-best-practices-collections-generics/table-of-contents)


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

### Generic List

Declarando:
```c
var colorOptions = new List<string>();
```

Inserindo:
```c
colorOptions.Add("Navy");
colorOptions.Insert(2, "purple");
```
Passando o indice no insert, o item o restando da lista passa para a proxima posição

Removendo:
```c
colorOptions.Remove("white");
```
Remove apenas a primeira ocorrência

Inicializando em massa:

```c
var colorOptions = new List<string>() { "white", "Espresso", "Navy", "purple" };
```

Lista de objeto (como inicializacao de atributos de um objeto em massa)

```c
var expected = new List<Vendor>();

expected.Add(new Vendor()
{ VendorId = 1, CompanyName = "Test", Email = "teste@teste.com" });
expected.Add(new Vendor()
{ VendorId = 2, CompanyName = "Test", Email = "teste1@teste.com" });
```

Para pegar um elemento especifico, basta utlizar o indice da lista: expected[1]

Tipos de listas:
System.Collections.Generics.List<T>
System.Collections.Generics.LinkedList<T>
System.Collections.Generics.Queue<T>
System.Collections.Generics.Stack<T>

### Generic Dictionaries

Possuem chave e valor, os tipos dos dois devem ser passados ao instanciar um dicionario

```c
var states = new Dictionary<string, string>();
states.Add("CA", "California");
states.Add("WA", "Washington");
states.Add("NY", "New York");

```


É possivel inicializar em massa um dicionario

```c
var vendors = new Dictionary<string, Vendor>()
{
    {"ABC Corp", new Vendor()
         { VendorId= 1, CompanyName = "ABC coorp", Email= "abc@coorp.com" }
    },
    {"XYZ Corp", new Vendor()
         { VendorId= 2, CompanyName = "XYZ coorp", Email= "abc@coorp.com" }
    }
};
```
Para recuperar um item do dicionario pela chave(exemplo utilizando metodo do dicionario que verifica se uma chave existe):

```c
if (vendors.ContainsKey("ABC Corp"))
{
    Console.WriteLine(vendors["ABC Corp"]);
}
```

Para iterar nos valores do dicionario, basta usar o metodo value

```c
foreach (var vendor in vendors.Values)
{
    Console.WriteLine(vendor);
}
```

Para iterar em chave e valor:

```
foreach (var element in vendors)
{
    var vendor = element.Value;
    var key = element.Key;
    Console.WriteLine($"Key: {key} Value: {vendor}")
}
```

Dicionarios usados normalmente são:
System.Collections.Generic.Dictionary<Tkey,TValue>
System.Collections.Generic.SortedList<Tkey,TValue>
System.Collections.Generic.SortedDictionary<Tkey,TValue>

### Generic Collection Interfaces

Intefaces utilizadas em generic collections:

![](https://raw.githubusercontent.com/brunorsantos/dotnetcoreestudo/master/genericcolletcioninterfaces.png)

Sendo que as classes Array, list, dictionary implentam as seguintes:

![](https://raw.githubusercontent.com/brunorsantos/dotnetcoreestudo/master/genericcolletcioninterfaces1.png)

Sendo que o array implementa os metodos em tempo de execução, o que faz permitir que os metodos só sejam utilizados quando passados como parametro ou retornados como uma instancia da interface de IList ou ICollection

Quando o tipo retornado é IEnumerable<T> a generic collection retornada, será imutavel, e nao terá metodos de informacao da lista como 'count'

## Building Applications with ASP.NET MVC 4]
[Building Applications with ASP.NET MVC 4](https://app.pluralsight.com/library/courses/mvc4-building/table-of-contents)

### Intro

Necessarios: Vistual Studio, ISS...

Utiliza o Razor para processar Views em HTML, em que é necessario tipificar a model passada como parametro no incio do aquivo chtml.

Na raiz do projeto principal da solucao WEB MVC criada no Visual studio estão os diretorios:
Controllers
Models
View
Scripts - (Utilizados para o js)
Content - (CSS e imagens)

### Controllers

No arquivo Global.asax.cs, são registradas configurações da aplicacao. Em cada requisição o metodo "Applicaction_Start()" da classe é executado. Em que se encontra o metodo estatico RegisterRoutes da Classe RouteConfig.

```c
public static void RegisterRoutes(RouteCollection routes)
{
    routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

    routes.MapRoute(
        name: "Default",
        url: "{controller}/{action}/{id}",
        defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
    );
}
}
```

No arquivo possuirá uma rota default em que se é exgida no URL um texto para o controller um para action e um para ID. 
Em que ao utilizar seremos redirecionados para o que foi passado na URL.

Nos controllers temos acesso a uma 'fachada' RouteData em que podemos pegar os valores construidos como: RouteData.Values["controller"].

Definindo nova rota, para a URL /cuisine/[valor], que procurará o controller:

```p
routes.MapRoute("Cuisine",
    "cuisine/{name}",
    new { controller = "Cuisine", action = "Search", name = "" });
```

Action de exemplo no controller:

```c
public ActionResult Search(string name = "French")
{
    var ret = Server.HtmlEncode(name);
    return Content(ret);
}
```

Pode ser usar selectors antes dos metodos para definis ação: [HttpGet] [HttpPost]

Filtros podem ser registrados para a ação, o controller, ou globalmente para a aplicacao (feito no arquivo de configuracao global)


Sendo que o parametro name pode ser passado na rota definida, ou ate como queryString

Possiveis Action Results:
![](https://raw.githubusercontent.com/brunorsantos/dotnetcoreestudo/master/actionresult.png)


### Razor Views

Quando um controller retorna uma view, como padrao o aquivo é procurado na mesma estrutura da action do controller na diretorio 'view'.

São passados como padrão para a view, o objeto ViewBag e o objeto da model que é passado como parametro no controller

### CLI

https://docs.microsoft.com/pt-br/dotnet/core/tools/dotnet-new?tabs=netcore21

Com dotnet new é possivel criar vários tipos de projeto. (Console, api, mvc...)

Na fachada HTML existem medodos para rederizar html com utilidades como escapar tags html...

```
@Html.DisplayNameFor(model => model.Name)
```

É possivel também criar bloco de codigos (soltos ou com foreach):

```
@{
    ViewBag.Title = "Index";
}
```

```html
@foreach (var item in Model) {
    @:Review
    <div>
    <h4>@item.Id</h4>
    </div>
}

```

O arquivo de layout (master) é definido em view/_ViewStart.cshtml. (que pode ser definido em cada diretorio)
No arquivo de layout no metodo @RenderBody(), é o local que a pagina chamada do Razor é renderizada.
No arquivo de layout é possivel definir sessoes em @RenderSession() para definirmos locais para sessoes serem utilizadas.


No metido ActionLink podemos criar uma ancora diretamente para um action de um controller

```
@Html.ActionLink("Contact", "Contact", "Home")
```

### Working with data

Em System.Data.Entity


### Estrutura basica

no arquivo csproj na raiz do projeto, é descrito o tipo de projeto e determina as dependencias do projeto


dotnet build - faz o build (Compilacao do projeto)
dotnet run -  executa 
dotnet restore - Restaura dependencias do projeto
dotnet watch run
dotnet add package - inclui uma dependencia no projeto
