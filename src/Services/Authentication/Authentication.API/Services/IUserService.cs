using System.Threading.Tasks;

namespace Authentication.API.Services
{
    public interface IUserService
    {
        Task<Models.SecurityToken> Authenticate(string username, string password);

        Task<Models.SecurityToken> AuthenticatePatient(string username, string password);
    }
}