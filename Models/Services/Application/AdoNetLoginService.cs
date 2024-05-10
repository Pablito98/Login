using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Login.Models.Services.Infrastructure;
using System.Data;
using Login.Models.ViewModels;
using Login.Models.InputModels;

namespace Login.Models.Services.Application
{
    public class AdoNetLoginService : ILoginService
    {
        private readonly IDatabaseAccessor db; // proprieta che deve essere iniettata nel servizio applicativo

        public AdoNetLoginService(IDatabaseAccessor db) // dipendenza debole
        {
            this.db = db;
        }


        public async Task<List<UtentiViewModel>> GetUtentiAsync(UtentiListInputModel model)
        {

            FormattableString query = $"SELECT *  FROM iscritto WHERE nome LIKE {"%"+model.Search+"%"}";
            DataSet dataSet = await db.QueryAsync(query);
            var dataTable = dataSet.Tables[0]; //recupera la prima tabella del dataset
            var utentiList = new List<UtentiViewModel>(); //crea la lista di corsi che deve eseere passata all view
            // per ogni riga presente nalla datatable deve creare un oggetto di tipo CourseViewModel 
            foreach (DataRow utenteRow in dataTable.Rows)
            {
                UtentiViewModel utente = UtentiViewModel.FromDataRow(utenteRow);
                utentiList.Add(utente);
            }
            return utentiList;
        }

        public async Task<int> EliminaUtenteAsync(int id)
        {


            try
            {
                FormattableString query = $"DELETE FROM iscritto WHERE id = {id}";

                // Eseguire la query
                await db.QueryAsync(query);
                return 1; // Ritorna un valore int per indicare l'avvenuta eliminazione
            }
            catch
            {
                return 0; // Ritorna 0 se si verifica un errore durante l'eliminazione
            }


        }

       // public async Task<bool> RegistraUtenteAsync(string nome, string email, string nazione, string password)
        public async Task<bool> RegistraUtenteAsync(UtentiListInputModel model)
        {
            FormattableString query = $"INSERT INTO iscritto (nome, email, nazione, password) VALUES ({model.Nome}, {model.Email}, {model.Nazione}, {model.Password})";


            try
            {
                await db.QueryAsync(query);
                return true; // Ritorna true se la registrazione ha avuto successo
            }
            catch (Exception ex)
            {
                // Gestisci eventuali eccezioni, ad esempio registrando un errore o lanciando un'eccezione personalizzata
                Console.WriteLine($"Errore durante la registrazione dell'utente: {ex.Message}");
                return false; // Ritorna false se la registrazione ha fallito
            }
        }


        public async Task<bool> LoginUtente(string email, string password)
        {
            FormattableString query = $"SELECT COUNT(*) FROM iscritto WHERE email = {email} AND password = {password}";


            try
            {
                DataSet dataSet = await db.QueryAsync(query);
        
        // Ottieni il risultato della query
        int count = Convert.ToInt32(dataSet.Tables[0].Rows[0][0]);
        
        // Verifica se il risultato contiene almeno una riga
        // Se sì, significa che le credenziali sono corrette e l'utente può accedere
        return count > 0;


            }
            catch (Exception ex)
            {

                Console.WriteLine($"Errore durante la registrazione dell'utente: {ex.Message}");
                return false;
            }
        }

    }
}