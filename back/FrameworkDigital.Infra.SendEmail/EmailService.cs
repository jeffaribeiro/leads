namespace FrameworkDigital.Infra.SendEmail
{
    public class EmailService : IEmailService
    {
        public void SendEmailToSalesDepartment()
        {
            var from = "noreply@test.com";
            var to = "vendas@test.com";
            SendEmail(from, to);
        }

        private void SendEmail(string from, string to)
        {
            // aqui será feita a rotina de envio de e-mail
        }
    }
}
