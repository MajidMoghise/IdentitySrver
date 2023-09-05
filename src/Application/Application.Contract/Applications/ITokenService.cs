using Application.Contract.DTOs.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.Applications
{
    public interface ITokenService
    {
       Task<string> CreateJwts(TokenJwtCreateDto dto);
    }
}
