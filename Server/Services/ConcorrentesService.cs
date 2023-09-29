using API.Contracts;
using API.Services.Extentions;
using Shared.Models;

namespace API.Services
{
    public class ConcorrentesService : IConcorrentesService
    {
        private readonly IQueryable<Concorrentes> _concorrentes;

        public ConcorrentesService()
        {
            var l = new List<Concorrentes>()
            {
                new(){
                    Nome = "Allana Marina Mariane Alves",
                    Cpf= "887.969.268-21",
                    DataNascimento = new DateTime(1980, 11, 09),
                    Renda= 5454.55
                },
                new(){Nome= "Raul Emanuel Araújo", Cpf= "531.380.488-03",
                    DataNascimento= new DateTime(1985, 12, 21), Renda= 4567.45 },
                new(){Nome= "Kaique Calebe Almeida", Cpf= "128.021.648-48",
                    DataNascimento= new DateTime(1972, 04, 27), Renda= 4488.48},
                new(){Nome= "Letícia Rita Ferreira", Cpf= "025.500.928-39",
                    DataNascimento= new DateTime(1956, 03, 13), Renda= 3675.64},
                new(){Nome= "Leandro Gustavo Viana", Cpf= "411.601.448-69",
                    DataNascimento= new DateTime(1945, 04, 26), Renda= 10999.99},
                new(){Nome= "Rodrigo Sebastião Araújo", Cpf= "785.118.978-01",
                    DataNascimento= new DateTime(1958, 05, 20), Renda= 6000.79, Cid= "H90"},
                new(){Nome= "Rebeca Rita Moura", Cpf= "325.541.788-01",
                    DataNascimento= new DateTime(1981, 08, 26), Renda= 1250.98},
                new(){Nome= "Heitor Kauê Martins", Cpf= "005.517.108-00",
                    DataNascimento= new DateTime(1986, 06, 22), Renda= 3000.58},
                new(){Nome= "Eduardo Gael Cardoso", Cpf= "737.055.718-93",
                    DataNascimento= new DateTime(1977, 03, 11), Renda= 5225.99},
                new(){Nome= "Giovanna Gabriela da Mota", Cpf= "735.196.008-97",
                    DataNascimento= new DateTime(1995, 12, 10), Renda= 1250},
                new(){Nome= "Malu Emilly Pinto", Cpf= "071.865.388-27",
                    DataNascimento= new DateTime(2002, 09, 19), Renda= 3900},
                new(){Nome= "Severino Igor Mário Barros", Cpf= "958.617.790-40",
                    DataNascimento= new DateTime(1994, 02, 21), Renda= 4000, Cid= "H90"},
                new(){Nome= "Tomás João Moreira", Cpf= "358.414.793-00",
                    DataNascimento= new DateTime(1940, 10, 26), Renda= 2500},
                new(){Nome= "Bruno Levi Dias", Cpf= "053.246.187-80",
                    DataNascimento= new DateTime(1941, 09, 13), Renda= 2500},
                new(){Nome= "Sérgio Vinicius Barros", Cpf= "479.893.965-05",
                    DataNascimento= new DateTime(1953, 07, 04), Renda= 5225, Cid= "H90"},
                new(){Nome= "Ana BRenda Esther Ramos", Cpf= "840.216.806-56",
                    DataNascimento= new DateTime(1982, 08, 23), Renda= 1790.99, Cid= "H90"},
                new(){Nome= "Hugo Manuel Novaes", Cpf= "239.964.398-49",
                    DataNascimento= new DateTime(1971, 10, 19), Renda= 7850},
                new(){Nome= "Oliver Ricardo Ribeiro", Cpf= "925.091.645-03",
                    DataNascimento= new DateTime(1980, 03, 24), Renda= 2000},
                new(){Nome= "Lavínia Mariah Jennifer dos Santos", Cpf= "843.831.525-97",
                    DataNascimento= new DateTime(2005, 10, 05), Renda= 1045},
                new(){Nome= "Sabrina Luna Laís Cavalcanti", Cpf= "945.553.979-91",
                    DataNascimento= new DateTime(1971, 11, 26), Renda= 3000, Cid= "H90"},

            };

            foreach (var concorrente in l)
                concorrente.DefinirCota();
            _concorrentes = l.AsQueryable();

        }

        public async Task<IQueryable<Concorrentes?>> GetAptosParaSorteioAsync()
        {
            return await Task.FromResult(_concorrentes.FilterByRegraGeral());
        }

        public async Task<ResponseConcorrentes> GetConcorrentesAsync()
        {
            var deficientes = _concorrentes.FilterByDeficienciaFisica();
            var idosos = _concorrentes.FilterByRegraIdosos();
            var geral = _concorrentes;

            var result = new ResponseConcorrentes()
            {
                Deficientes = deficientes,
                Idosos = idosos,
                Geral = geral
            };

            result.SetTotal();
            return await Task.FromResult(result);


        }
    }
}