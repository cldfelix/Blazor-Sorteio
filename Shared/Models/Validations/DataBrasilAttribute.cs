using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Shared.Models.Validations;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
public class DataBrasilAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value == null)
        {
            return true; // Trate valores nulos conforme necessário
        }

        // Verifique se o valor é uma string
        if (!(value is string))
        {
            return false;
        }

        var dataString = (string)value;

        // Tente fazer o parse da data
        return DateTime.TryParseExact(dataString, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
    }
}
