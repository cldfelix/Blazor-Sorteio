using System.ComponentModel.DataAnnotations;
using Shared.Models.Validations;

namespace Shared.Models;

public class Concorrentes: DadosPrincipais
{
    [Required]
    public DateTime DataNascimento { get; set; }
       
    [Required]
    public double Renda { get; set; }

    [MaxLength(3)]       
    public string? Cid { get; set; }
        
 

    public void DefinirCota()
    {
        var dataHoje = DateTime.Now.AddYears(-60);
        Cota = "GERAL";

        if (DataNascimento < dataHoje)
            Cota = "IDOSO";

        else if (!string.IsNullOrEmpty(Cid))
            Cota = "DEFICIENTE FÍSICO";
    }
}

public class ResponseConcorrentes
{
    public IQueryable<Concorrentes?> Idosos { get; set; }
    public IQueryable<Concorrentes?> Deficientes { get; set; } 
    public IQueryable<Concorrentes?> Geral { get; set; } 
    public int Total { get; private set; }
    public void SetTotal()=> Total =  Geral.Count();
}
