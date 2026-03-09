namespace PaymentDomain.Entities;

public class Fatura
{
    public Fatura() { } // EF
    public Guid IdFatura { get; set; }
    public Guid IdAssinatura { get; set; } = default!; // FK
    public DateTime DataEmissao { get; set; }
    public DateTime DataVencimento { get; set; }
    public decimal ValorTotal { get; set; }

    // Relacionamentos
    public ICollection<Pagamento?> Pagamentos { get; set; } = [];

    public Fatura(Guid idFatura, Guid idAssinatura, DateTime emissao, DateTime vencimento, decimal valor)
    {
        IdFatura = idFatura;
        IdAssinatura = idAssinatura;
        DataEmissao = emissao;
        DataVencimento = vencimento;
        ValorTotal = valor;
    }

    public void AdicionarPagamento(Pagamento pagamento)
        => Pagamentos.Add(pagamento);

    public void AlteraVencimento(DateTime novaDataVencimento)
    {
        if (novaDataVencimento <= DataEmissao)
            throw new ArgumentException("A nova data de vencimento deve ser posterior à data de emissão.");

        DataVencimento = novaDataVencimento;
    }

    public decimal SaldoDevedor()
        => ValorTotal - Pagamentos.Sum(p => p!.ValorPago);
    public decimal TotalPago()
        => Pagamentos.Sum(p => p!.ValorPago);
    public decimal ValorExcedente()
        => Pagamentos.Sum(p => p!.ValorPago) > ValorTotal ? Pagamentos.Sum(p => p!.ValorPago) - ValorTotal : 0;

    public bool FaturaPaga()
        => Pagamentos.Sum(p => p!.ValorPago) == ValorTotal;

    public bool FaturaParcialmentePaga()
        => Pagamentos.Sum(p => p!.ValorPago) > 0 && Pagamentos.Sum(p => p!.ValorPago) < ValorTotal;

    public bool FaturaVencida()
        => DateTime.UtcNow > DataVencimento && !FaturaPaga();
}
