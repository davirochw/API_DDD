using System.IdentityModel.Tokens.Jwt;

namespace WebAPI.Token
{
    public class TokenJWT
    {
        private JwtSecurityToken token;
        public DateTime ValidTo => token.ValidTo;
        public string value => new JwtSecurityTokenHandler().WriteToken(this.token);

        internal TokenJWT(JwtSecurityToken token)
        {
            this.token = token;
        }
    }
}
