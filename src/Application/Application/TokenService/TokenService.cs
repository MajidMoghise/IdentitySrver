using Application.Contract.Applications;
using Application.Contract.DTOs;
using Application.Contract.DTOs.Token;
using Application.Contract.DTOs.User;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace Application.TokenService
{
    public class TokenService
    {

        #region privateField
        private static readonly string PrivateKey = "fikhlonh,kn[hk,ovn/;ihcdkfvjvhkndaifvk'bvn";

        #endregion

        public Task<string> CreateJwts(TokenJwtCreateDto acc, HttpRequest request)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(PrivateKey));
            SigningCredentials credentials = new SigningCredentials
                             (securityKey, SecurityAlgorithms.HmacSha256Signature);
            JwtHeader header = new JwtHeader(credentials);



            JwtPayload payload = new JwtPayload()
           {
                 {nameof(TokenJwtCreateDto.TokenGuid), acc.TokenGuid},
                 {nameof(TokenJwtCreateDto.UserID),acc.UserID },
                 {nameof(TokenJwtCreateDto.IPAddress),acc.IPAddress},
                 {nameof(TokenJwtCreateDto.UserAgent),acc.UserAgent

                }
           };
            JwtSecurityToken secToken = new JwtSecurityToken(header, payload);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            // Token to String so you can use it in your client
            string tokenString = handler.WriteToken(secToken);
            Incryptor sc = new Incryptor();
            string strRec = sc.Coding(tokenString);


            return Task.FromResult(strRec);

        }

        public ResponseModel OKIdentities
            (HttpRequest Request,
            UserTokenVM userToken,
            IUserTokenService _userTokenService)
        {
            string strc = Request.Headers["Token"].ToString();
            if (string.IsNullOrEmpty(strc))
            {
                return new ResponseModel { Success = false, HttpstatusCode = System.Net.HttpStatusCode.Unauthorized };


            }
            string strtoken = strc.ToString();
            Incryptor sc = new Incryptor();
            string str = sc.GetToken(strtoken);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            JwtSecurityToken token = handler.ReadJwtToken(str);
            SecurityKey sec = token.SecurityKey;


            string cr = token.RawSignature;
            string TokenID = token.Payload[nameof(TokenJwtCreateDto.TokenGuid)].ToString();
            string UserID = token.Payload[nameof(TokenJwtCreateDto.UserID)].ToString();
            string _IPAddress = token.Payload[nameof(TokenJwtCreateDto.IPAddress)].ToString();
            string SystemConnection = token.Payload[nameof(TokenJwtCreateDto.UserAgent)].ToString();

            string thisAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Microsoft.Extensions.Primitives.StringValues systemConection = Request.Headers["UserAgent"];


            if (_IPAddress != thisAddress && systemConection != SystemConnection)
            {
                return new ResponseModel { Success = false, HttpstatusCode = System.Net.HttpStatusCode.NoContent };
            }

            userToken.TokenID = Convert.ToInt32(TokenID);
            userToken.UserID = Convert.ToInt32(UserID);
            userToken.SystemUserID = Convert.ToInt32(UserID);


            ResponseModel resultU = _userTokenService.Accessbility(userToken);
            if (!resultU.Success)
            {
                return new ResponseModel { Success = false, HttpstatusCode = System.Net.HttpStatusCode.NoContent };
            }
            return new ResponseModel<UserTokenVM>
            {
                Success = true,
                Model = new UserTokenVM
                {
                    UserID = Convert.ToInt32(UserID),
                    TokenID = Convert.ToInt32(TokenID),
                    ActionName = userToken.ActionName,
                    Active = true,
                    ControllerName = userToken.ControllerName,
                    ExpireDate = userToken.ExpireDate,
                    SystemUserID = userToken.SystemUserID,
                    AriaName = userToken.AriaName,
                    SiteName = userToken.SiteName
                }
            };

        }
    }

}
