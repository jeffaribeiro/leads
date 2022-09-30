using FrameworkDigital.Domain.Leads.Entities;
using FrameworkDigital.Domain.Leads.Enums;
using FrameworkDigital.Domain.Leads.Repository;
using FrameworkDigital.Infra.Data.Context;

namespace FrameworkDigital.Infra.Data.Leads.Repository
{
    public class LeadRepository : ILeadRepository
    {

        private readonly MyContext _context;

        public LeadRepository(MyContext context)
        {
            _context = context;
        }

        public Lead GetById(long id) => _context.Lead.Find(id);

        public void Update(Lead lead) => _context.Lead.Update(lead);

        public IList<Lead> GetAccepteds() => _context.Lead.Where(x => x.Status == StatusEnum.Accepted).ToList();

        public IList<Lead> GetInviteds() => _context.Lead.Where(x => x.Status == StatusEnum.Invited).ToList();
    }
}
