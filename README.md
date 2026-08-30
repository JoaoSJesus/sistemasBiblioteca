# Sistema de Biblioteca (Console)

Aplicação console em C# para gerenciamento simples de empréstimos de livros. Permite registrar um usuário, escolher um livro, informar datas e gerar um relatório com cálculo de desconto por tipo de conta.

## Stack
- C# (.NET)
- TargetFramework: net10.0 (verifique seu SDK .NET)

## Como rodar
```bash
dotnet build Sistema-de-Biblioteca/Sistema-de-Biblioteca.csproj
dotnet run --project Sistema-de-Biblioteca/Sistema-de-Biblioteca.csproj
```

## Fluxo de uso
1. Informe o nome do usuário.
2. Informe o tipo de conta (Ouro, Prata, Bronze) — afeta o desconto.
3. Escolha o livro (ex.: "O Senhor dos Anéis", "Harry Potter", "O Hobbit").
4. Informe a data de empréstimo (dd/MM/yyyy).
5. Informe quantos dias para devolução.
6. Visualize o relatório gerado.

## Estrutura do código
- Biblioteca.cs: modelos e lógica (Livro, Usuario, Emprestimo).
- Program.cs: interface de console e orquestração.

## Modificações comuns
- Adicionar novos títulos e valores em Emprestimo.ValorLivros().
- Usar PrecoDiaria do Livro para cálculo por dias.
- Implementar persistência ou atualização de QuantDisponivel para controlar estoque.
