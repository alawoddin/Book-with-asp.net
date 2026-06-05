
namespace Book.Controllers
{
    internal class ApplicationDbContext
    {
        public object Categories { get; internal set; }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}