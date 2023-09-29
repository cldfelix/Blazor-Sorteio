using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Shared.Models.Validations;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
public class CpfAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value == null)
        {
            return true; // Trate valores nulos conforme necessário
        }

        // Verifique se o valor é uma string
        var cpf = value as string;
        if (cpf == null)
        {
            return false;
        }

        // Remove todos os caracteres não numéricos do CPF
        cpf = Regex.Replace(cpf, @"[^\d]", "");

        // Verifica se o CPF tem 11 dígitos numéricos
        if (cpf.Length != 11)
        {
            return false;
        }

        // Calculo dos dígitos verificadores
        var digitos = cpf.Select(c => int.Parse(c.ToString())).ToArray();
        var soma1 = 0;
        var soma2 = 0;

        for (var i = 0; i < 9; i++)
        {
            soma1 += digitos[i] * (10 - i);
            soma2 += digitos[i] * (11 - i);
        }

        var resto1 = soma1 % 11;
        var digito1 = (resto1 < 2) ? 0 : (11 - resto1);

        soma2 += digito1 * 2;
        var resto2 = soma2 % 11;
        var digito2 = (resto2 < 2) ? 0 : (11 - resto2);

        // Verifica se os dígitos verificadores estão corretos
        return digitos[9] == digito1 && digitos[10] == digito2;
    }
}