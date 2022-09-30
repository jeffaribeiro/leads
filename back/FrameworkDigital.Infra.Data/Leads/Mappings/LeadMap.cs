using FrameworkDigital.Domain.Leads.Entities;
using FrameworkDigital.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FrameworkDigital.Infra.Data.Leads.Mappings
{
    public class LeadMap : EntityTypeConfiguration<Lead>
    {
        public override void Map(EntityTypeBuilder<Lead> builder)
        {
            builder.ToTable("Lead");
        }
    }
}
