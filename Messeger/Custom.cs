using System.Data.Entity;

namespace Messeger
{
    internal class Custom<T> : DropCreateDatabaseIfModelChanges<Meseger>//DropCreateDatabaseAlways<Meseger>
    {
        protected override void Seed(Meseger context)
        {
            base.Seed(context);
        }
    }
}