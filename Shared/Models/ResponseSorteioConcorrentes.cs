namespace Shared.Models;

public class ResponseSorteioConcorrentes
{
    public ResponseSorteioConcorrentes()
    {
        Geral = new List<Concorrentes?>();
    }
    public Concorrentes? Idoso { get; set; }
    public Concorrentes? Deficiente { get; set; }
    public List<Concorrentes?> Geral { get; set; } 
}