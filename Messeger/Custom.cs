using System.Data.Entity;

namespace Messeger
{
    internal class Custom<T> : DropCreateDatabaseIfModelChanges<Meseger>//DropCreateDatabaseAlways<Meseger>
    {
        protected override void Seed(Meseger context)
        {
            context.Users.Add(new User { Login = "Server" });
            base.Seed(context);
        }
    }
}