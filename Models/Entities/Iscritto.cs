﻿using System;
using System.Collections.Generic;

namespace Login.Models.Entities
{
    public partial class Iscritto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Nazione { get; set; }
        public string Password { get; set; }
    }
}