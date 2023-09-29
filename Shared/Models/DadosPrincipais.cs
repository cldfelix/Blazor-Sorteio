using Shared.Models.Validations;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class DadosPrincipais
{
    [Required, Key]
    [Cpf(ErrorMessage = "CPF inválido.")]
    public string Cpf { get; set; }
    [Required]
    public string Nome { get; set; }
    public string Cota { get; protected set; }
}