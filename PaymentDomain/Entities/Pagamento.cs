using DomainObjects.Enums;

namespace PaymentDomain.Entities;

public class Pagamento
{
    public Pagamento() { } // EF
    public Guid IdPagamento { get; set; }
    public Guid IdFatura { get; set; } = default!; // FK
    public DateTime DataPagamento { get; set; }
    public decimal ValorPagamento { get; set; }
    public decimal ValorPago { get; set; }
    public MetodoPagamento MetodoPagamento { get; set; } = default!;
    public string? NumeroTransacao { get; set; }
    public string? Observacao { get; set; }
    // Relacionamentos
    public Fatura? Fatura { get; set; }
    // Regras de Negócio
    public Pagamento(Guid idFatura, DateTime dataPagamento, decimal valorPago, MetodoPagamento metodoPagamento, string? numeroTransacao = null, string? observacao = null)
    {
        IdPagamento = Guid.NewGuid();
        IdFatura = idFatura;
        DataPagamento = dataPagamento;
        ValorPago = valorPago;
        MetodoPagamento = metodoPagamento;
        NumeroTransacao = numeroTransacao;
        Observacao = observacao;
    }
}