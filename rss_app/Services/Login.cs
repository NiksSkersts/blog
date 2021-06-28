using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Newtonsoft.Json;
using rss_app.Models;

namespace rss_app.Services
{
    public class Login
    {
        public async Task<JwtSecurityToken> LoginService(string username, string password)
        {
            var json = JsonConvert.SerializeObject(new PostData {Username = username, Password = password});
            var tokenString = await API.ConsumeLoginApi("Login", json);
            var handler = new JwtSecurityTokenHandler();
            var token = JsonConvert.DeserializeObject<Token>(tokenString);
            var innerToken = handler.ReadJwtToken(token.TokenToken.Value.Token);
            return innerToken;
        }
    }
}