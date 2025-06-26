using Orbital_Africa_Backend_Recon.Modal.Email;

namespace Orbital_Africa_Backend_Recon.Service
{
    public interface IEmailService
    {
        Task SendEmail(MailRequest mailrequest);
    }
}
