namespace Messeger
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Meseger : DbContext
    {
        public Meseger()
            : base("name=Meseger")
        {
        }


        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<Loger> Logers { get; set; }
        public virtual DbSet<User> Users { get; set; }

    }


}