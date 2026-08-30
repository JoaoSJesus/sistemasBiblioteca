using Sistema_de_Biblioteca;
using static Sistema_de_Biblioteca.Biblioteca;

Console.WriteLine("\n--BIBLIOTECA - SISTEMA DE EMPRÉSTIMOS--\n");
Console.WriteLine("");

var biblioteca = new Biblioteca();
var usuario = new Biblioteca.Usuario();
var emprestimo = new Biblioteca.Emprestimo();

Console.WriteLine($"Digite o nome do usuário: ");
usuario.Nome = Console.ReadLine();

Console.WriteLine($"\nBem-vindo(a), {usuario.Nome}!");

Console.WriteLine("\nQual seu tipo de Conta [Ouro, Prata, Bronze]?\n");
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

// ligando o empréstimo ao usuário (útil se Relatorio() usa dados do usuário)
emprestimo.usuario = usuario;

Console.WriteLine("Quando você pretende pegar o livro emprestado? (formato: dd/MM/yyyy): ");
emprestimo.DataEmprestimo = DateTime.Parse(Console.ReadLine());

Console.WriteLine("Em quantos dias você pretende devolver o livro? ");
var diasEmprestimo = int.Parse(Console.ReadLine());
emprestimo.DataDevolucao = emprestimo.DataEmprestimo.AddDays(diasEmprestimo);

Console.WriteLine("\n----Aqui está o relatório do seu empréstimo: ---\n");
Console.WriteLine($"{emprestimo.Relatorio()}");