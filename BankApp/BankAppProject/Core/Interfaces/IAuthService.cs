using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IAuthService
    {
        Task<string> RegisterUserAsync(string email, string password);
        Task<string> LoginUserAsync(string email, string password);
    }
}
