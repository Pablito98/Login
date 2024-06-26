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
    [ModelBinder(BinderType = typeof(SearchListInputModelBinder))]  
    public class SearchListInputModel
    {
        public string Search {get;}

        public SearchListInputModel(string search)
        {
            this.Search = search ?? "";
        } 
        
    }
}