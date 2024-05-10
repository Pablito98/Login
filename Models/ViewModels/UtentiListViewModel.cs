using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Login.Models.InputModels;

namespace Login.Models.ViewModels
{
    public class UtentiListViewModel
    {
        public List<UtentiViewModel> Utenti {get;set;}

        public UtentiListInputModel Input {get;set;}
    }
}