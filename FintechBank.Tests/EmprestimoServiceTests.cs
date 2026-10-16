using FintechBank.App;

namespace FintechBank.Tests;

public class EmprestimoServiceTests
{
    private readonly EmprestimoService _service = new();

    [Theory]
    [InlineData(10000, 10, 800, 1050)]
    [InlineData(10000, 10, 600, 1120)]
    [InlineData(10000, 10, 400, 1200)]
    public void CalcularValorParcela_DeveAplicarJurosConformeScore(
        decimal valorTotal,
        int parcelas,
        int scoreCredito,
        decimal valorEsperado)
    {
        decimal resultado = _service.CalcularValorParcela(
            valorTotal,
            parcelas,
            scoreCredito);

        Assert.Equal(valorEsperado, resultado);
    }

    [Theory]
    [InlineData(5000, 1500, true)]
    [InlineData(5000, 1600, false)]
    public void AprovarEmprestimo_DeveRespeitarLimiteDe30PorCento(
        decimal rendaMensal,
        decimal valorParcela,
        bool resultadoEsperado)
    {
        bool resultado = _service.AprovarEmprestimo(
            rendaMensal,
            valorParcela);

        Assert.Equal(resultadoEsperado, resultado);
    }
}