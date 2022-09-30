using FrameworkDigital.Application.Leads.DTO;
using FrameworkDigital.Domain.Leads.Entities;

namespace FrameworkDigital.Domain.Leads.Mappings
{
    public static class LeadAcceptedDtoMap
    {
        public static LeadAcceptedDto ToDto(Lead entity)
        {
            var dto = new LeadAcceptedDto
            {
                Category = entity.Category,
                ContactEmail = entity.ContactEmail,
                ContactFullName = $"{entity.ContactFirstName} {entity.ContactLastName}",
                ContactPhoneNumber = entity.ContactPhoneNumber,
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
