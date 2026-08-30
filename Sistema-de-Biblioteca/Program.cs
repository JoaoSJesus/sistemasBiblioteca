using Sistema_de_Biblioteca;

Console.WriteLine("\n--BIBLIOTECA - SISTEMA DE EMPRÉSTIMOS--\n");
Console.WriteLine("");

var biblioteca = new Biblioteca();
var usuario = new Biblioteca.Usuario();
var emprestimo = new Biblioteca.Emprestimo();

Console.WriteLine($"Digite o nome do usuário: ");
usuario.Nome = Console.ReadLine();

Console.WriteLine($"\nBem-vindo(a), {usuario.Nome}!");

Console.WriteLine("Qual seu tipo de Conta [Ouro, Prata, Bronze]?");
usuario.Tipo = Console.ReadLine();
if (usuario.Tipo.Equals("Ouro", StringComparison.OrdinalIgnoreCase))
{
    Console.WriteLine("Você tem direito a 15% de desconto no valor do empréstimo.");
}
else if (usuario.Tipo.Equals("Prata", StringComparison.OrdinalIgnoreCase))
{
    Console.WriteLine("Você tem direito a 5% de desconto no valor do empréstimo.");
}
else if (usuario.Tipo.Equals("Bronze", StringComparison.OrdinalIgnoreCase))
{
    Console.WriteLine("Você não tem direito a desconto no valor do empréstimo.");
}
else
{
    Console.WriteLine("Tipo de conta inválido. Você não terá desconto no valor do empréstimo.");
}

Console.WriteLine("Digite qual dos 3 livros que deseja pegar emprestado (O Senhor dos Anéis, O Pequeno Príncipe, Dom Casmurro): ");
var livroEscolhido = Console.ReadLine();
emprestimo.Livro = new Biblioteca.Livro { Titulo = livroEscolhido };

Console.WriteLine("Digite a data de empréstimo (formato: dd/MM/yyyy): ");
emprestimo.DataEmprestimo = DateTime.Parse(Console.ReadLine());

Console.WriteLine("\n----Aqui está o relatório do seu empréstimo: ---\n");
Console.WriteLine($"{emprestimo.Relatorio()}");