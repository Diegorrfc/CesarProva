using Cesar.Domain.CesarContext.Services;

namespace Cesar.Tests.Mocks
{
    public class MockEmailService : IEmailService
    {
        public void Send(string to, string from, string subject, string body)
        {
            
        }
    }
}