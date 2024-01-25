using LibraryAPIv2.Models.Dtos;

namespace LibraryAPIv2.Repositories
{
    public interface IEmailService
    {
        void SendEmail(EmailDTO request);
    }
}
