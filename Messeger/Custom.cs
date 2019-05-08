using System.Data.Entity;

namespace Messeger
{
    internal class Custom<T> : DropCreateDatabaseAlways<Meseger>
    {
        protected override void Seed(Meseger context)
        {
            base.Seed(context);
        }
    }
}