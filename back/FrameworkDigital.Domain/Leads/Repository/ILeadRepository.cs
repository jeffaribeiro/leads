using FrameworkDigital.Domain.Leads.Entities;

namespace FrameworkDigital.Domain.Leads.Repository
{
    public interface ILeadRepository
    {
        Lead GetById(long id);
        void Update(Lead lead);

        IList<Lead> GetInviteds();
        IList<Lead> GetAccepteds();
    }
}
