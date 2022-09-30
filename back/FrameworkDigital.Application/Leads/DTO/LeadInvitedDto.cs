namespace FrameworkDigital.Application.Leads.DTO
{
    public class LeadInvitedDto
    {
        public long Id { get; set; }
        public string ContactFirstName { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public string Suburb { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
