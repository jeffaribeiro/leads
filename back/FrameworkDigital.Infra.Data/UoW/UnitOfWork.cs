using FrameworkDigital.Domain.UoW;
using FrameworkDigital.Infra.Data.Context;

namespace FrameworkDigital.Infra.Data.UoW
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyContext _context;

        public UnitOfWork(MyContext context)
        {
            _context = context;
        }

        public void Commit() => _context.SaveChanges();
    }
}
