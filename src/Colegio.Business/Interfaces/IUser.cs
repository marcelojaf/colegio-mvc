using System.Security.Claims;

namespace Colegio.Business.Interfaces
{
    /// <summary>
    /// Interface para Usuário Autenticado
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// Nome do Usuário
        /// </summary>
        string GetUserName();

        /// <summary>
        /// Retorna o Id do Usuário
        /// </summary>
        /// <returns></returns>
        Guid GetUserId();

        /// <summary>
        /// Retorna o Email do Usuário
        /// </summary>
        /// <returns></returns>
        string GetUserEmail();

        /// <summary>
        /// Verifica se o Usuário está autenticado
        /// </summary>
        /// <returns></returns>
        bool IsAuthenticated();

        /// <summary>
        /// Verifica se o Usuário possui uma Role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        bool IsInRole(string role);

        /// <summary>
        /// Retorna uma lista de Claims de um Usuário
        /// </summary>
        /// <returns></returns>
        IEnumerable<Claim> GetClaimsIdentity();


        /// <summary>
        /// Obtém o endereço IP remoto do usuário.
        /// </summary>
        /// <returns>O endereço IP remoto do usuário.</returns>
        string GetRemoteIpAddress();

        /// <summary>
        /// Obtém o endereço IP local.
        /// </summary>
        /// <returns>O endereço IP local.</returns>
        string GetLocalIpAddress();
    }
}
