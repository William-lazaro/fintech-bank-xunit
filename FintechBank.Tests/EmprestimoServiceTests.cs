
using FintechBank.App;

namespace FintechBank.Tests;

public class EmprestimoServiceTests
{
    private readonly EmprestimoService _service = new();

    [Theory]
    [InlineData(1000, 10, 700, 105)]
    [InlineData(1000, 10, 500, 112)]
    [InlineData(1000, 10, 400, 120)]
    public void CalcularValorParcela_DeveAplicarJurosConformeScore(
        decimal valorTotal,
        int parcelas,
        int scoreCredito,
        decimal valorEsperado)
    {
        // Act
        decimal resultado = _service.CalcularValorParcela(
            valorTotal,
            parcelas,
            scoreCredito);

        // Assert
        Assert.Equal(valorEsperado, resultado);
    }

    [Theory]
    [InlineData(3000, 900, true)]
    [InlineData(3000, 901, false)]
    [InlineData(3000, 500, true)]
    public void AprovarEmprestimo_DeveRespeitarLimiteDe30PorCento(
        decimal rendaMensal,
        decimal valorParcela,
        bool resultadoEsperado)
    {
        // Act
        bool resultado = _service.AprovarEmprestimo(
            rendaMensal,
            valorParcela);

        // Assert
        Assert.Equal(resultadoEsperado, resultado);
    }
}
