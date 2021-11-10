namespace server.Entities {
    public class ArticleJoinFournisseur {
        public int Article { get; set; }
        public int Fournisseur { get; set; }

        public virtual Article ArticleNavigation { get; set; }
        public virtual Fournisseur FournisseurNavigation { get; set; }
    }
}
