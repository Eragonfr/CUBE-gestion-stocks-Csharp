using System;

namespace server.Entities {
    public class Article {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public string Producttype { get; set; }
        public string Provenance { get; set; }
        public string Medaille { get; set; }
        public DateTime Annee { get; set; }
        public string Domaine { get; set; }
    }
}
