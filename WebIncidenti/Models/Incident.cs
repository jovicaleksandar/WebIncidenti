using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebIncidenti.Models
{
    public class Incident
    {
        public string naziv { get; set; }
        public string opis { get; set; }
        public string boja { get; set; }

        public int prioritet { get; set; }

        public Incident()
        {
            this.prioritet = 0;
        }

        public Incident(string naziv, string opis, string boja, int prioritet)
        {
            this.naziv = naziv;
            this.opis = opis;
            this.boja = boja;
            this.prioritet = prioritet;
        }
    }
}