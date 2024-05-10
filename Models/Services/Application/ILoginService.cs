using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Login.Models.InputModels;
using Login.Models.ViewModels;

namespace Login.Models.Services.Application
{
    public interface ILoginService
    {
          Task<List<UtentiViewModel>> GetUtentiAsync(SearchListInputModel model);
          //Task<bool> RegistraUtenteAsync(string nome, string email, string nazione, string password);
          Task<bool> RegistraUtenteAsync(UtentiListInputModel model);

          Task<int> EliminaUtenteAsync(int id);

          Task<bool> LoginUtente(string email, string password);
    }

}