using System;

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
                    return 0.5;
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

            public double AplicarDesconto(double valor)
            {
                return valor - (valor * CalcularDesconto());
            }
        }

        public class Emprestimo
        {
            public Livro Livro { get; set; }
            public Usuario Usuario { get; set; }
            public DateTime DataEmprestimo { get; set; }
            public DateTime DataDevolucao { get; set; }

            public int CalcularDiasEmprestimo()
            {
                TimeSpan diferençaData = DataDevolucao - DataEmprestimo;
                return diferençaData.Days;
            }

            public double CalcularValorFinal()
            {
                int dias = CalcularDiasEmprestimo();
                double custo = Livro.CalcularCustoEmprestimo(dias);
                double valorComDesconto = Usuario.AplicarDesconto(custo);
                return valorComDesconto;
            }
        }
    }
}
