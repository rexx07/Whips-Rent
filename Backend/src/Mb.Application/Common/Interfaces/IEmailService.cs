using Mb.Application.Common.Models;

namespace Mb.Application.Common.Interfaces;

public interface IEmailService
{
    Task SendAsync(EmailRequest request);
}