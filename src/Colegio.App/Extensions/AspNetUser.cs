using Colegio.Business.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Colegio.App.Extensions
{
    /// <summary>
    /// Classe que representa um Usuário logado
    /// </summary>
    public class AspNetUser : IUser
    {
        /// <summary>
        /// Interface do AspNetCore para acessar o HttpContext
        /// </summary>
        private readonly IHttpContextAccessor _accessor;

        /// <summary>
        /// Construtor padrão com o HttpContext
        /// </summary>
        /// <param name="accessor"></param>
        public AspNetUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        /// <summary>
        /// Nome do Usuário
        /// </summary>
        public string GetUserName()
        {
            var username = _accessor.HttpContext?.User.FindFirst("username")?.Value;
            if (!string.IsNullOrEmpty(username)) return username;

            username = _accessor.HttpContext?.User.Identity?.Name;
            if (!string.IsNullOrEmpty(username)) return username;

            username = _accessor.HttpContext?.User.FindFirst(JwtRegisteredClaimNames.Name)?.Value;
            if (!string.IsNullOrEmpty(username)) return username;

            username = _accessor.HttpContext?.User.FindFirst(JwtRegisteredClaimNames.GivenName)?.Value;
            if (!string.IsNullOrEmpty(username)) return username;

            var sub = _accessor.HttpContext?.User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
            if (sub != null) return sub;

            return string.Empty;
        }

        /// <summary>
        /// Retorna o Id do Usuário
        /// </summary>
        /// <returns></returns>
        public Guid GetUserId()
        {
            if (!IsAuthenticated()) return Guid.Empty;

            var claim = _accessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(claim))
            {
                claim = _accessor.HttpContext?.User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
            }

            return claim is null ? Guid.Empty : Guid.Parse(claim);
        }

        /// <summary>
        /// Retorna o Email do Usuário
        /// </summary>
        /// <returns></returns>
        public string GetUserEmail()
        {
            return IsAuthenticated() ? _accessor.HttpContext.User.GetUserEmail() : string.Empty;
        }

        /// <summary>
        /// Verifica se o Usuário está autenticado
        /// </summary>
        /// <returns></returns>
        public bool IsAuthenticated()
        {
            return _accessor.HttpContext?.User.Identity is { IsAuthenticated: true };
        }

        /// <summary>
        /// Verifica se o Usuário possui uma Role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool IsInRole(string role)
        {
            return _accessor.HttpContext != null && _accessor.HttpContext.User.IsInRole(role);
        }

        /// <summary>
        /// Retorna uma lista de Claims de um Usuário
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }

        public string GetRemoteIpAddress()
        {
            return _accessor.HttpContext?.Connection.RemoteIpAddress?.ToString();
        }

        public string GetLocalIpAddress()
        {
            return _accessor.HttpContext?.Connection.LocalIpAddress?.ToString();
        }
    }

    /// <summary>
    /// Classe de extensão do ClaimsPrincipal
    /// </summary>
    public static class ClaimsPrincipalExtensions
    {
        /// <summary>
        /// Retorna o Id do Usuário
        /// </summary>
        /// <returns></returns>
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentNullException(nameof(principal));
            }

            var claim = principal.FindFirst(ClaimTypes.NameIdentifier);

            return claim?.Value;
        }

        /// <summary>
        /// Retorna o Email do Usuário
        /// </summary>
        /// <returns></returns>
        public static string GetUserEmail(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentNullException(nameof(principal));
            }

            var claim = principal.FindFirst(ClaimTypes.Email);

            return claim?.Value;
        }
    }
}
