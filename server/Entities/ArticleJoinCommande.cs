namespace server.Entities {
    public class ArticleJoinCommande {
        public int Article { get; set; }
        public int Commande { get; set; }

        public virtual Article ArticleNavigation { get; set; }
        public virtual Commande CommandeNavigation { get; set; }
    }
}
