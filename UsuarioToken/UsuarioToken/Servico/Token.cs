using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.IO;
using System;
using Microsoft.IdentityModel.Tokens;
using UsuarioToken.Model;

namespace UsuarioToken.Servico
{
	public class Token
	{
		public static string GerarToken(UsuarioModel adm)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			//JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));
			var key = Encoding.ASCII.GetBytes("umsegredo2198230283728930723089732");
			//var expirationTime = Convert.ToInt32(jAppSettings["TempoExpiracao"]);
            var tokenDescriptor = new SecurityTokenDescriptor()
			{
				Subject = new ClaimsIdentity(new Claim[]{
						new Claim(ClaimTypes.Name, adm.nome),
						new Claim(ClaimTypes.Role, adm.funcao),
					}),
				Expires = DateTime.UtcNow.AddMinutes(60),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}
}
