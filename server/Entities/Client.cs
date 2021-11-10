namespace server.Entities {
    public partial class Client {
        public int Users { get; set; }
        public int Adresse { get; set; }
        public string Email { get; set; }

        public virtual Adresse AdresseNavigation { get; set; }
        public virtual User UsersNavigation { get; set; }
    }
}
