namespace Messeger
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Meseger : DbContext
    {
        // Your context has been configured to use a 'Meseger' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Messeger.Meseger' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Meseger' 
        // connection string in the application configuration file.
        public Meseger()
            : base("name=Meseger")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<Loger> Logers { get; set; }
        public virtual DbSet<User> Users { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}