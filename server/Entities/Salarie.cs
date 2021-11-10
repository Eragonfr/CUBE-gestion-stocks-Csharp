namespace server.Entities {
    public partial class Salarie {
        public int Users { get; set; }
        public string Poste { get; set; }

        public virtual User UsersNavigation { get; set; }
    }
}
