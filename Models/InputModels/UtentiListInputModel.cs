using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Login.Customizations.ModelBinders;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Login.Models.InputModels
{
    [ModelBinder(BinderType = typeof(UtentiListInputModelBinder))]  
    public class UtentiListInputModel
    {
        public string Email {get;}

        public string Nazione {get;}

        public string Password {get;}

        public string Nome {get;}
        public int Id {get;}


        public UtentiListInputModel(string nome, string email, string nazione, string password, int id)
        {
            this.Nome=nome;
            this.Email=email;
            this.Nazione=nazione;
            this.Password=password;
            this.Id = id;
        } 
    }
}