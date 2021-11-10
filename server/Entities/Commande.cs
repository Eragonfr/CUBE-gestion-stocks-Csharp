using System;

namespace server.Entities {
    public partial class Commande {
        public int Id { get; set; }
        public DateTime Datecommande { get; set; }
        public DateTime? Datelivraison { get; set; }
        public int Quantite { get; set; }
        public decimal Prix { get; set; }
    }
}
