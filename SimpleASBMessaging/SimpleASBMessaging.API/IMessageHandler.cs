using System.Threading.Tasks;

namespace SimpleASBMessaging.API
{
    public interface IMessageHandler
    {
        Task<string> ReceiveAsync();

        Task SendAsync(string message);
    }
}