using System;
using System.Linq;
using System.Net.Mail;
using Microsoft.Extensions.Logging;

public class Calculator
{
    private ILogger<Calculator> logger;
    public Calculator(ILogger<Calculator> logger)
    {
        this.logger = logger;
    }

    public int Sum(int num1, int num2)
    {
        return num1 + num2;
    }

    public int Resta(int num1, int num2)
    {
        return num1 - num2;
    }

    public int BusquedaCadenaLetraA(string cadena)
    {

        char letraBuscada = 'a';

        // Cuenta cuántos caracteres coinciden al pasarlos a minúsculas
        int total = cadena.Count(c => char.ToLower(c) == char.ToLower(letraBuscada));

        return total;
    }

    public bool ValidaEstructuraEmail(string cadena)
    {
        try
        {
            MailAddress m = new MailAddress(cadena);
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }
    }

    public int NumeroAleatorio()
    {
        Random rnd = new Random();
        int numeroAleatorio = rnd.Next(1, 10); // Genera un número entre 1 y 9

        return numeroAleatorio;

    }

    public int RandonNumeroEntero()
    {
        Random rnd = new Random();
        int numeroAleatorio = rnd.Next(1, 5); // Genera un número entre 1 y 4

        return numeroAleatorio;

    }

    public virtual int ContarPalabras(string texto)
    {
        if (string.IsNullOrWhiteSpace(texto))
            return 0;

        // Divide el texto usando espacios en blanco como separador
        string[] palabras = texto.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        logger.LogInformation($"Count {palabras.Length} for text {texto}");

        return palabras.Length;
    }

}