using System;
using System.Collections.Generic;
using System.Text;

namespace Scaffold.Api.Core.Services.Interface
{
    public interface ITokenService
    {
        string GenerateToken(string userId, string email);
    }
}
