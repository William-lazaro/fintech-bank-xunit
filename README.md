# FintechBank - Garantia da Qualidade de Software

## Visão Geral

O FintechBank é um projeto acadêmico desenvolvido para a disciplina de Garantia da Qualidade de Software. A aplicação implementa regras de negócio relacionadas a contas correntes e empréstimos bancários, utilizando C# e testes unitários com xUnit.

## Objetivos

- Implementar regras de negócio para contas correntes.
- Calcular parcelas de empréstimos de acordo com o score de crédito.
- Validar a aprovação de empréstimos conforme a renda mensal.
- Verificar o funcionamento das regras por meio de testes unitários parametrizados.

## Requisitos Técnicos

- .NET 10 SDK
- C#
- xUnit
- Git
- GitHub

## Estrutura do Projeto

```text
FintechBank/
├── FintechBank.slnx
├── FintechBank.App/
│   ├── FintechBank.App.csproj
│   ├── ContaCorrenteService.cs
│   ├── EmprestimoService.cs
│   └── Program.cs
├── FintechBank.Tests/
│   ├── FintechBank.Tests.csproj
│   ├── ContaCorrenteServiceTests.cs
│   └── EmprestimoServiceTests.cs
├── .gitignore
├── LICENSE
└── README.md
```

## Regras de Negócio

### ContaCorrenteService

Responsável pelas regras relacionadas à conta corrente.

**CalcularTaxaManutencao(decimal saldo, bool clienteEspecial)**

- Saldo igual ou superior a R$ 5.000,00: isenção da taxa.
- Cliente especial: isenção da taxa.
- Saldo entre R$ 1.000,00 e R$ 4.999,99, sem condição especial: taxa de R$ 12,50.
- Saldo inferior a R$ 1.000,00, sem condição especial: taxa de R$ 25,00.

**PodeRealizarSaque(decimal saldo, decimal limiteChequeEspecial, decimal valorSaque)**

Permite o saque quando o valor solicitado é menor ou igual à soma do saldo disponível com o limite do cheque especial.

### EmprestimoService

Responsável pelas regras relacionadas ao cálculo e à aprovação de empréstimos.

**CalcularValorParcela(decimal valorTotal, int parcelas, int scoreCredito)**

Aplica a taxa de juros total conforme o score de crédito:

- Score igual ou superior a 700: juros de 5%.
- Score entre 500 e 699: juros de 12%.
- Score inferior a 500: juros de 20%.

O valor total com juros é dividido pela quantidade de parcelas.

**AprovarEmprestimo(decimal rendaMensal, decimal valorParcela)**

Aprova o empréstimo quando o valor da parcela compromete, no máximo, 30% da renda mensal.

## Como Clonar o Repositório

Requisitos: Git instalado no computador.

Execute no terminal:

```bash
git clone https://github.com/William-lazaro/fintech-bank-xunit.git
cd fintech-bank-xunit
```

## Como Compilar a Solução

Com o .NET 10 SDK instalado, execute na pasta raiz do projeto:

```bash
dotnet restore
dotnet build
```

## Como Executar os Testes

Para executar os testes unitários da solução, utilize:

```bash
dotnet test
```

O comando executa os testes configurados no projeto FintechBank.Tests. Na execução realizada durante o desenvolvimento, os 12 testes passaram, sem falhas ou testes ignorados.

## Testes Unitários Parametrizados

Os testes utilizam xUnit com os atributos `[Theory]` e `[InlineData]`.

- **[Theory]** permite executar um mesmo método de teste com diferentes conjuntos de dados.
- **[InlineData]** fornece os valores utilizados em cada execução do teste.

Essa abordagem permite verificar diferentes cenários das regras de negócio, como saldos altos e baixos, limites de saque, scores de crédito e percentuais de comprometimento da renda.

## Licença

Este projeto está disponibilizado sob a licença MIT. Consulte o arquivo [LICENSE](https://github.com/William-lazaro/fintech-bank-xunit/blob/main/LICENSE) para conhecer seus termos.
