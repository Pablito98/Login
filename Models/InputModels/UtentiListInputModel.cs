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
       
        public string Search {get; set;}

        public string Email {get; set;}

        public string Nazione {get;set;}

        public string Password {get;set;}

        public string Nome {get;set;}


        public UtentiListInputModel(string nome, string email, string nazione, string password, string search)
        {
            Search = search ?? "";
            this.Nome=nome;
            this.Email=email;
            this.Nazione=nazione;
            this.Password=password;
        } 

       /* public UtentiListInputModel(string search)
        {
            Search = search ?? "";
        } */
    }
}