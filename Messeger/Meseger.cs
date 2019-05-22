namespace Messeger
{
    using Messeger.Model;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Meseger : DbContext
    {
        public Meseger()
            : base("name=Meseger")
        {
            Database.SetInitializer<Meseger>(new Custom<Meseger>());
        }


        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Chat> Chats { get; set; }
       // public virtual DbSet<Loger> Logers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }
        public virtual DbSet<Sender> Senders { get; set; }
        public virtual DbSet<Receiver> Receivers { get; set; }

        public virtual DbSet<File> Files { get; set; }

    }


}