using Shared.Models;

namespace API.Services.Extentions
{
    public static class ConcorrentesFilter
    {
        public static IQueryable<Concorrentes?> FilterByRegraGeral(this IQueryable<Concorrentes> concorrentes)
        {
            var dataRef = DateTime.Now.AddYears(-15);
            return concorrentes
                .Where(e =>
                    e!.DataNascimento < dataRef &&
                    e.Renda > 1045 &&
                    e.Renda < 5225 
                );
        }
        public static IQueryable<Concorrentes?> FilterByRegraIdosos(this IQueryable<Concorrentes> concorrentes)
        {
            var dataRef = DateTime.Now.AddYears(-60);
            return concorrentes.Where(e => e!.DataNascimento < dataRef);
        }
        public static IQueryable<Concorrentes?> FilterByDeficienciaFisica(this IQueryable<Concorrentes> concorrentes)=>
            concorrentes.Where(e => !string.IsNullOrEmpty(e.Cid));
     
        
        static bool ValidarCpf(string cpf)
        {
            // Remover caracteres não numéricos
            var cpfNumerico = new string(cpf.ToCharArray(), 0, 11);
            cpfNumerico = cpfNumerico.Replace(".", "").Replace("-", "");

            if (cpfNumerico.Length != 11)
            {
                return false;
            }

            // Calculo do primeiro dígito verificador
            var soma = 0;
            for (var i = 0; i < 9; i++)
            {
                soma += int.Parse(cpfNumerico[i].ToString()) * (10 - i);
            }
            var resto = soma % 11;
            var digitoVerificador1 = (resto < 2) ? 0 : (11 - resto);

            // Calculo do segundo dígito verificador
            soma = 0;
            for (var i = 0; i < 10; i++)
            {
                soma += int.Parse(cpfNumerico[i].ToString()) * (11 - i);
            }
            resto = soma % 11;
            var digitoVerificador2 = (resto < 2) ? 0 : (11 - resto);

            // Verificar se os dígitos verificadores são válidos
            return (int.Parse(cpfNumerico[9].ToString()) == digitoVerificador1) &&
                   (int.Parse(cpfNumerico[10].ToString()) == digitoVerificador2);
        }
           
    }
}