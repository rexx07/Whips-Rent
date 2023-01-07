using Mb.Application.Common.Interfaces;

namespace Mb.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
