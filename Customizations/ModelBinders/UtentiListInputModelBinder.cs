using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Login.Models.InputModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;

namespace Login.Customizations.ModelBinders
{
    public class UtentiListInputModelBinder : IModelBinder
    {
         public UtentiListInputModelBinder(){

        }
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            
            //Recuperiamo i valori grazie ai value provider
            string search = bindingContext.ValueProvider.GetValue("Search").FirstValue;
            string nome = bindingContext.ValueProvider.GetValue("Nome").FirstValue;
            string email = bindingContext.ValueProvider.GetValue("Email").FirstValue;
            string nazione = bindingContext.ValueProvider.GetValue("Nazione").FirstValue;
            string password = bindingContext.ValueProvider.GetValue("Password").FirstValue;
 
            //Creiamo l'istanza del CourseListInputModel
            var inputModel = new UtentiListInputModel(nome,email,nazione,password,search);

            //Impostiamo il risultato per notificare che la creazione è avvenuta con successo
            bindingContext.Result = ModelBindingResult.Success(inputModel);

            //Restituiamo un task completato
            return Task.CompletedTask;
        }
    }
}