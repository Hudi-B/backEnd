using emailSend.Models.DTOs;

namespace emailSend.Service.IEmailServices
{
    public interface IEmailService
    {
        void SendEmail(EmailDTO request);
    }
}
