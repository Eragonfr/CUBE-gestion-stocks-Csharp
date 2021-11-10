namespace server.Entities {
    public class HistJoinCom {
        public int Users { get; set; }
        public int Commande { get; set; }

        public virtual Commande CommandeNavigation { get; set; }
        public virtual User UsersNavigation { get; set; }
    }
}
