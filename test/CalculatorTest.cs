using NuGet.Frameworks;
using Xunit;
using Moq;
using Microsoft.VisualBasic;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging;
//using Castle.Core.Logging;

public class CalculatorTest
{

    //private Calculator calculator;
    ILogger<Calculator> loggerTest;

    public CalculatorTest()
    {
        var mock = new Mock<ILogger<Calculator>>();
        loggerTest = mock.Object;
        // Inicializamos Calculator inyectando el Logger
        //calculator = new Calculator(NullLogger<Calculator>.Instance);
    }

    [Fact]
    public void Sum()
    {
        //Arrange
        var calculator = new Calculator(loggerTest);

        //Act
        var result = calculator.Sum(2, 3);

        //Assert
        Assert.Equal(5, result);
    }

    [Fact]
    public void Resta()
    {
        //Arrange
        var calculator = new Calculator(loggerTest);

        //Act
        var result = calculator.Resta(5, 4);

        //Assert
        Assert.NotEqual(0, result);
    }

    [Fact]
    public void Texto_DeberiaContenerLetra_InsensibleMayusculas()
    {
        // 1. Arrange (Preparar)
        string textoBase = "Manzana y Melon";
        string letraBuscada = "m";

        // 2. Act (Actuar) - Aqui logica real

        // 3. Assert (Verificar)
        // Pasamos la comparacion para ignorar mayusculas/minusculas
        Assert.Contains(letraBuscada, textoBase, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void ValidaEstructuraEmail()
    {
        //Arrange
        var calculator = new Calculator(loggerTest);
        string emailbase = "cesar@hotmail.com";

        //Act
        var result = calculator.ValidaEstructuraEmail(emailbase);

        //Assert
        Assert.True(result);
    }

    [Fact]
    public void NumeroAleatorio()
    {
        //Arrange
        var calculator = new Calculator(loggerTest);

        //Act
        int result = calculator.NumeroAleatorio();

        //Assert
        Assert.InRange(result, 1, 10);
    }

    [Fact]
    public void ValidaNumeroMenorQue()
    {
        //Arrange
        var calculator = new Calculator(loggerTest);

        //Act
        int result = calculator.RandonNumeroEntero();

        //Assert
        Assert.True(result < 5);
    }

    [Fact(Skip = "Esta prueba no es valida para el codigo actual")]
    public void CountWords()
    {
        //Arrange
        var calculator = new Calculator(loggerTest);
        var textoAContar = "Hola Mundo";

        //Act
        int result = calculator.ContarPalabras(textoAContar);

        //Assert
        Assert.True(result > 1);
        Assert.Equal(2, result);
    }

    [Fact]
    public void CountWords_NotZero()
    {
        //Arrange
        var calculator = new Calculator(loggerTest);
        var textoAContar = "Hola";

        //Act
        int result = calculator.ContarPalabras(textoAContar);

        //Assert
        Assert.NotEqual(0, result);
    }

    [Fact]
    public void CountWords_NotZero_Moq()
    {
        //Arrange
        var mock = new Mock<Calculator>(loggerTest);
        mock.Setup(p => p.ContarPalabras("Texto")).Returns(1);

        //Act
        int result = mock.Object.ContarPalabras("Texto");

        //Assert
        Assert.NotEqual(0, result);
    }

    [Theory]
    [InlineData("Hola Mundo", 2)]
    [InlineData("", 0)]
    [InlineData("Saludos a todos desde Mexico", 5)]
    public void CountWordsTheory(string text, int expected)
    {
        //Arrange
        var calculator = new Calculator(loggerTest);
        var textoAContar = text;

        //Act
        int result = calculator.ContarPalabras(textoAContar);

        //Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [ClassData(typeof(ClassDataTest))]
    public void CountWords_ClassData(string text, int expected)
    {
        //Arrange
        var calculator = new Calculator(loggerTest);
        var textoAContar = text;

        //Act
        int result = calculator.ContarPalabras(textoAContar);

        //Assert
        Assert.Equal(expected, result);
    }


}