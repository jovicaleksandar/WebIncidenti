using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebIncidenti.Models
{
    public class Incidenti
    {
        public Dictionary<string, Incident> collection { get; set; }

        public Incidenti()
        {
            collection = new Dictionary<string, Incident>();
        }

        public Incidenti(Dictionary<string, Incident> collection)
        {
            this.collection = collection;
        }
    }
}