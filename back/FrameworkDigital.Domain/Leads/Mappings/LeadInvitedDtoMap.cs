using FrameworkDigital.Application.Leads.DTO;
using FrameworkDigital.Domain.Leads.Entities;

namespace FrameworkDigital.Domain.Leads.Mappings
{
    public static class LeadInvitedDtoMap
    {
        public static LeadInvitedDto ToDto(Lead entity)
        {
            var dto = new LeadInvitedDto
            {
                Category = entity.Category,
                ContactFirstName = entity.ContactFirstName,
                DateCreated = entity.DateCreated,
                Description = entity.Description,
                Id = entity.Id,
                Price = entity.Price,
                Suburb = entity.Suburb
            };

            return dto;
        }
    }
}
