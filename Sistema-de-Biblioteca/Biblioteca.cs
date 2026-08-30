using System;
using System.Security.Cryptography.X509Certificates;

namespace Sistema_de_Biblioteca
{
    class Biblioteca
    {
        public class Livro
        {
            public string Titulo { get; set; } = string.Empty;
            public string Autor { get; set; } = string.Empty;
            public int AnoPublicacao { get; set; }
            public int QuantDisponivel { get; set; }
            public double PrecoDiaria { get; set; }

            public double CalcularCustoEmprestimo(int diasEmprestimo)
            {
                return PrecoDiaria * diasEmprestimo;
            }

            public bool PodePegarEmprestado()
            {
                return QuantDisponivel > 0;
            }

            public int AtualizarQuantidade(int quantidade)
            {
                QuantDisponivel += quantidade;
                return QuantDisponivel;
            }
        }

        public class Usuario
        {
            public string Nome { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string Telefone { get; set; } = string.Empty;
            public string Tipo { get; set; } = string.Empty;
            public double DescontoMembro { get; set; }

            public int TipagemUsuario()
            {
                if (Tipo == "Bronze")
                {
                    return 1;
                }
                else if (Tipo == "Prata")
                {
                    return 2;
                }
                else if (Tipo == "Ouro")
                {
                    return 3;
                }
                else
                {
                    return 4;
                }
            }

            public double CalcularDesconto()
            {
               if (Tipo == "Bronze")
                {
                    return 0.00;
                }
                else if (Tipo == "Prata")
                {
                    return 0.10;
                }
                else if (Tipo == "Ouro")
                {
                    return 0.15;
                }
                else
                {
                    return 0.00;
                }
            }

        }

        public class Emprestimo
        {
            public Livro Livro { get; set; } = new Livro();
            public Usuario usuario { get; set; } = new Usuario();
            public DateTime DataEmprestimo { get; set; }
            public DateTime DataDevolucao { get; set; }

            public string livros()
            {
                var titulo = Livro?.Titulo ?? string.Empty;
                return titulo switch
                {
                    "O Senhor dos Anéis" => "O Senhor dos Anéis",
                    "Harry Potter" => "Harry Potter",
                    "O Hobbit" => "O Hobbit",
                    _ => "Livro não encontrado."
                };
            }

            public double ValorLivros()
            {
                return livros() switch
                {
                    "O Senhor dos Anéis" => 50.0,
                    "Harry Potter" => 75.0,
                    "O Hobbit" => 60.0,
                    _ => 0.0
                };
            }

            public double AplicarDesconto(double valor)
            {
                return valor - (valor * usuario.CalcularDesconto());
            }

            public int CalcularDiasEmprestimo()
            {
                TimeSpan diferençaData = DataDevolucao - DataEmprestimo;
                return diferençaData.Days;
            }

            public double CalcularValorFinal()
            {
                return AplicarDesconto(ValorLivros());
            }

            public string Relatorio()
            {
                string nome = usuario.Nome;
                string book = Livro.Titulo;
                int dias = CalcularDiasEmprestimo();
                double valorSemDesconto = ValorLivros();
                double desconto = usuario.CalcularDesconto();
                double value = CalcularValorFinal();

                return ($"Usuário: {nome}\nLivro: {book}\nDias: {dias}\nDesconto (%): {desconto}\nValor sem Descontos: {valorSemDesconto}\nValor final: {value}");
            }
        }
    }
}

