using FluentAssertions;
using FrameworkDigital.Domain.Leads.Entities;
using FrameworkDigital.Domain.Leads.Enums;

namespace FrameworkDigital.Tests.UnitTests.Domain.Leads.Entities
{
    public class LeadTests
    {
        [Theory]
        [InlineData(600)]
        public void Lead_Accept_ShouldAcceptLeadWithDiscount(decimal price)
        {
            // Arrange
            var lead = new Lead("First Name", "Last Name", "+5521987654321", "teste@mail.com", "My Address 20", "Category", "Some Description", price);
            var priceWithDiscount = price - price / 100 * 10;

            // Act
            lead.Accept();

            // Assert
            lead.Status.Should().Be(StatusEnum.Accepted);
            lead.Price.Should().Be(priceWithDiscount);
            lead.Price.Should().NotBeInRange(0, 500);
        }

        [Theory]
        [InlineData(400)]
        [InlineData(500)]
        public void Lead_Accept_ShouldAcceptLeadWithoutDiscount(decimal price)
        {
            // Arrange
            var lead = new Lead("First Name", "Last Name", "+5521987654321", "teste@mail.com", "My Address 20", "Category", "Some Description", price);

            // Act
            lead.Accept();

            // Assert
            lead.Status.Should().Be(StatusEnum.Accepted);
            lead.Price.Should().Be(price);
            lead.Price.Should().BeInRange(0, 500);
        }


        [Fact]
        public void Lead_Decline_ShouldDeclineLead()
        {
            // Arrange
            var lead = new Lead("First Name", "Last Name", "+5521987654321", "teste@mail.com", "My Address 20", "Category", "Some Description", 100);

            // Act
            lead.Decline();

            // Assert
            lead.Status.Should().Be(StatusEnum.Declined);
        }

        [Fact]
        public void Lead_ContactFullName_ShouldReturnCorrectContactFullName()
        {
            // Arrange
            var lead = new Lead("First Name", "Last Name", "+5521987654321", "teste@mail.com", "My Address 20", "Category", "Some Description", 100);

            // Act


            // Assert
            lead.ContactFullName.Should().Be("First Name Last Name");
        }
    }
}
