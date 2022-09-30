using FluentAssertions;
using FrameworkDigital.Domain.Leads.Entities;
using FrameworkDigital.Domain.Leads.Repository;
using FrameworkDigital.Domain.Leads.Services;
using FrameworkDigital.Domain.Notification;
using FrameworkDigital.Domain.UoW;
using FrameworkDigital.Infra.SendEmail;
using MediatR;
using Moq;

namespace FrameworkDigital.Tests.UnitTests.Domain.Services
{
    public class LeadServiceTests
    {
        private readonly Mock<ILeadRepository> _leadRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly Mock<INotificationHandler<DomainNotification>> _notificationHandler;
        private readonly Mock<IEmailService> _emailService;

        private LeadService _leadService;

        public LeadServiceTests()
        {
            _leadRepository = new Mock<ILeadRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _notificationHandler = new Mock<INotificationHandler<DomainNotification>>();
            _emailService = new Mock<IEmailService>();

            _leadService = new LeadService(_leadRepository.Object, _unitOfWork.Object, _notificationHandler.Object, _emailService.Object);
        }

        [Fact]
        public async void LeadService_AcceptLead_ShouldUpdateLeadStatus()
        {
            // Arrange
            var lead = new Lead("First Name", "Last Name", "+5521987654321", "teste@mail.com", "My Address 20", "Category", "Some Description", 100);

            _leadRepository.Setup(x => x.GetById(lead.Id)).Returns(lead);

            // Act
            await _leadService.AcceptLead(lead.Id);

            // Assert
            _leadRepository.Verify(x => x.GetById(lead.Id), Times.Once);
            _notificationHandler.Verify(x => x.Handle(It.IsAny<DomainNotification>(), It.IsAny<CancellationToken>()), Times.Never);
            _leadRepository.Verify(x => x.Update(lead), Times.Once);
            _unitOfWork.Verify(x => x.Commit(), Times.Once);
            _emailService.Verify(x => x.SendEmailToSalesDepartment(), Times.Once);
        }

        [Fact]
        public async void LeadService_AcceptLead_ShouldReturnNotificationIdDoesntExists()
        {
            // Arrange
            Lead lead = null;
            var id = 5;

            _leadRepository.Setup(x => x.GetById(id)).Returns(lead);

            // Act
            await _leadService.AcceptLead(id);

            // Assert
            _leadRepository.Verify(x => x.GetById(id), Times.Once);
            _notificationHandler.Verify(x => x.Handle(It.IsAny<DomainNotification>(), It.IsAny<CancellationToken>()), Times.Once);
            _leadRepository.Verify(x => x.Update(lead), Times.Never);
            _unitOfWork.Verify(x => x.Commit(), Times.Never);
            _emailService.Verify(x => x.SendEmailToSalesDepartment(), Times.Never);
        }

        [Fact]
        public async void LeadService_DeclineLead_ShouldUpdateLeadStatus()
        {
            // Arrange
            var lead = new Lead("First Name", "Last Name", "+5521987654321", "teste@mail.com", "My Address 20", "Category", "Some Description", 100);

            _leadRepository.Setup(x => x.GetById(lead.Id)).Returns(lead);

            // Act
            await _leadService.DeclineLead(lead.Id);

            // Assert
            _leadRepository.Verify(x => x.GetById(lead.Id), Times.Once);
            _notificationHandler.Verify(x => x.Handle(It.IsAny<DomainNotification>(), It.IsAny<CancellationToken>()), Times.Never);
            _leadRepository.Verify(x => x.Update(lead), Times.Once);
            _unitOfWork.Verify(x => x.Commit(), Times.Once);
        }

        [Fact]
        public async void LeadService_DeclineLead_ShouldReturnNotificationIdDoesntExists()
        {
            // Arrange
            Lead lead = null;
            var id = 5;

            _leadRepository.Setup(x => x.GetById(id)).Returns(lead);

            // Act
            await _leadService.DeclineLead(id);

            // Assert
            _leadRepository.Verify(x => x.GetById(id), Times.Once);
            _notificationHandler.Verify(x => x.Handle(It.IsAny<DomainNotification>(), It.IsAny<CancellationToken>()), Times.Once);
            _leadRepository.Verify(x => x.Update(lead), Times.Never);
            _unitOfWork.Verify(x => x.Commit(), Times.Never);
        }

        [Fact]
        public void LeadService_GetAllLeadsAccepted_ShouldReturnAllLeadsAccepted()
        {
            // Arrange
            var leadsAcceptedFixture = new List<Lead>
            {
                new Lead("First Name", "Last Name", "+5521987654321", "teste@mail.com", "My Address 20", "Category", "Some Description", 100),
                new Lead("First Name", "Last Name", "+5521987654321", "fake@mail.com", "My Address 30", "Category", "Some Description", 200)
            };

            foreach (var lead in leadsAcceptedFixture)
                lead.Accept();

            _leadRepository.Setup(x => x.GetAccepteds()).Returns(leadsAcceptedFixture);

            // Act
            var result = _leadService.GetAllLeadsAccepted();

            // Assert
            _leadRepository.Verify(x => x.GetAccepteds(), Times.Once);
            result.Count.Should().Be(leadsAcceptedFixture.Count);
            result.Count.Should().NotBe(0);
        }

        [Fact]
        public void LeadService_GetAllLeadsAccepted_ShouldNotReturnLeadsAccepted()
        {
            // Arrange
            var leadsAcceptedFixture = new List<Lead>();

            _leadRepository.Setup(x => x.GetAccepteds()).Returns(leadsAcceptedFixture);

            // Act
            var result = _leadService.GetAllLeadsAccepted();

            // Assert
            _leadRepository.Verify(x => x.GetAccepteds(), Times.Once);
            result.Count.Should().Be(0);
        }

        [Fact]
        public void LeadService_GetAllLeadsInvited_ShouldReturnAllLeadsInvited()
        {
            // Arrange
            var leadsInvitedFixture = new List<Lead>
            {
                new Lead("First Name", "Last Name", "+5521987654321", "teste@mail.com", "My Address 20", "Category", "Some Description", 100),
                new Lead("First Name", "Last Name", "+5521987654321", "fake@mail.com", "My Address 30", "Category", "Some Description", 200)
            };

            _leadRepository.Setup(x => x.GetInviteds()).Returns(leadsInvitedFixture);

            // Act
            var result = _leadService.GetAllLeadsInvited();

            // Assert
            _leadRepository.Verify(x => x.GetInviteds(), Times.Once);
            result.Count.Should().Be(leadsInvitedFixture.Count);
            result.Count.Should().NotBe(0);
        }

        [Fact]
        public void LeadService_GetAllLeadsInvited_ShouldNotReturnLeadsInvited()
        {
            // Arrange
            var leadsInvitedFixture = new List<Lead>();

            _leadRepository.Setup(x => x.GetInviteds()).Returns(leadsInvitedFixture);

            // Act
            var result = _leadService.GetAllLeadsInvited();

            // Assert
            _leadRepository.Verify(x => x.GetInviteds(), Times.Once);
            result.Count.Should().Be(0);
        }
    }
}
