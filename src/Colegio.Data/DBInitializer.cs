using Colegio.Business.Models;
using Colegio.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Colegio.Data
{
    /// <summary>
    /// Classe responsável por inicializar o banco de dados
    /// </summary>
    public class DBInitializer : IDBInitializer
    {
        private readonly ColegioDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private string? userId;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="mapleBearDbContext"></param>
        /// <param name="userManager"></param>
        public DBInitializer(ColegioDbContext mapleBearDbContext, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = mapleBearDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        /// <summary>
        /// Inicializa o banco de dados
        /// </summary>
        public void Initialize()
        {
            _context.Database.EnsureCreated();

            SeedRoles();
            SeedUser();
            SeedUserRoles();
            SeedUnidadeEnsino();
            //SeedTurmas();
            //SeedProfessores();
            //SeedAlunos();
        }

        /// <summary>
        /// Inicializa o banco de dados com as Roles
        /// </summary>
        private void SeedRoles()
        {
            if (_context.Roles == null)
                return;

            if (!_context.Roles.Any())
            {
                var roles = new List<IdentityRole>()
                {
                    new IdentityRole()
                    {
                        Name = "Super",
                        NormalizedName = "SUPER"
                    },
                    new IdentityRole()
                    {
                        Name = "Coordenador",
                        NormalizedName = "COORDENADOR"
                    },
                    new IdentityRole()
                    {
                        Name = "Professor",
                        NormalizedName = "PROFESSOR"
                    },
                    new IdentityRole()
                    {
                        Name = "Aluno",
                        NormalizedName = "ALUNO"
                    }
                };

                foreach (var role in roles)
                {
                    _roleManager.CreateAsync(role).Wait();
                }
            }
        }

        /// <summary>
        /// Inicializa o banco de dados com um Usuário
        /// </summary>
        private void SeedUser()
        {
            if (_context.Users == null)
                return;

            if (!_context.Users.Any())
            {
                var user = new IdentityUser()
                {
                    Email = "teste@gmail.com",
                    UserName = "teste@gmail.com",
                    EmailConfirmed = true
                };

                _userManager.CreateAsync(user, "P@ssword1").Wait();
            }

            userId = _context.Users.AsNoTracking().Where(u => u.Email == "teste@gmail.com").FirstOrDefault()?.Id ?? string.Empty;
        }

        /// <summary>
        /// Inicializa o banco de dados com uma role para o usuário
        /// </summary>
        private void SeedUserRoles()
        {
            if (_context.UserRoles == null)
                return;

            if (!_context.UserRoles.Any())
            {
                if (string.IsNullOrEmpty(userId))
                    return;

                var userRole = new IdentityUserRole<string>()
                {
                    RoleId = _context.Roles.AsNoTracking().Where(r => r.Name == "Super").FirstOrDefault()?.Id ?? string.Empty,
                    UserId = userId
                };

                _context.UserRoles.Add(userRole);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Inicializa o banco de dados com Unidades de Ensino
        /// </summary>
        private void SeedUnidadeEnsino()
        {
            if (_context.UnidadesEnsino == null) return;

            if (!_context.UnidadesEnsino.Any())
            {
                var unidades = new UnidadeEnsino[]
                {
                    new UnidadeEnsino
                    {
                        Nome = "Mooca",
                        Endereco = "R. 1132, 76",
                        CEP = "74180-110",
                        Cidade = "Sao Paulo",
                        UF = "SP",
                        CreatedBy = userId
                    }
                };

                foreach (var unidade in unidades)
                {
                    _context.UnidadesEnsino.Add(unidade);
                }

                _context.SaveChangesAsync().Wait();
            }
        }
    }
}
