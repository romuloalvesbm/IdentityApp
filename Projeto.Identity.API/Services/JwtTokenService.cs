using Microsoft.IdentityModel.Tokens;
using Projeto.Identity.API.Settings;
using Projeto.Identity.Domain.Dtos;
using Projeto.Identity.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Projeto.Identity.API.Services
{

    public class JwtTokenService
    {
        private readonly JwtTokenSettings _jwtTokenSettings;

        public JwtTokenService(JwtTokenSettings jwtTokenSettings)
        {
            _jwtTokenSettings = jwtTokenSettings;
        }

        /// <summary>
        /// Método para criar e retornar um TOKEN JWT para um usuário
        /// </summary>
        public string CreateToken(UsuarioPermissaoDTO usuarioPermissao)
        {
            var expiration = DateTime.UtcNow.AddHours(int.Parse(_jwtTokenSettings.ExpirationInHours));
            var token = CreateJwtToken(
                CreateClaims(usuarioPermissao),
                CreateSigningCredentials(),
                expiration
            );
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }

        private JwtSecurityToken CreateJwtToken(List<Claim> claims, SigningCredentials credentials, DateTime expiration) =>
            new(
                _jwtTokenSettings.Issuer,
                _jwtTokenSettings.Audience,
                claims,
                expires: expiration,
                signingCredentials: credentials
            );

        private List<Claim> CreateClaims(UsuarioPermissaoDTO usuarioPermissao)
        {
            var jwtSub = _jwtTokenSettings.JwtClaimNamesSub;
            try
            {
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, jwtSub),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
                    new Claim(ClaimTypes.NameIdentifier, usuarioPermissao.Id.ToString()),
                    new Claim(ClaimTypes.Name, usuarioPermissao.Nome),
                    new Claim(ClaimTypes.Email, usuarioPermissao.Email),
                };

                foreach (var item in usuarioPermissao.Permissoes)
                {
                    claims.Add(new Claim("CustomizePermission", item));
                }

                return claims;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private SigningCredentials CreateSigningCredentials()
        {
            var symmetricSecurityKey = _jwtTokenSettings.SecurityKey;

            return new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(symmetricSecurityKey)
                ),
                SecurityAlgorithms.HmacSha256
            );
        }
    }
}