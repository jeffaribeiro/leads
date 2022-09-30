using FrameworkDigital.Domain.Leads.Enums;

namespace FrameworkDigital.Domain.Leads.Entities
{
    public class Lead
    {
        public long Id { get; private set; }
        public string ContactFirstName { get; private set; }
        public string ContactLastName { get; private set; }
        public string ContactFullName { get { return $"{ContactFirstName} {ContactLastName}"; } }
        public string ContactPhoneNumber { get; private set; }
        public string ContactEmail { get; private set; }
        public DateTimeOffset DateCreated { get; private set; }
        public string Suburb { get; private set; }
        public string Category { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public StatusEnum Status { get; private set; }

        public Lead(string contactFirstName, string contactLastName, string contactPhoneNumber, string contactEmail, string suburb, string category, string description, decimal price)
        {
            ContactFirstName = contactFirstName;
            ContactLastName = contactLastName;
            ContactPhoneNumber = contactPhoneNumber;
            ContactEmail = contactEmail;
            DateCreated = DateTimeOffset.Now;
            Suburb = suburb;
            Category = category;
            Description = description;
            Price = price;
            Status = StatusEnum.Invited;
        }

        public void Accept()
        {
            Status = StatusEnum.Accepted;
            ApplyDiscount();
        }
        public void Decline() => Status = StatusEnum.Declined;

        private void ApplyDiscount()
        {
            if (Price > 500)
                Price = Price - Price / 100 * 10;
        }
    }
}
