using Colegio.App.Extensions;
using Colegio.Business.Interfaces;
using Colegio.Business.Notificacoes;
using Colegio.Business.Services;
using Colegio.Data;
using Colegio.Data.Context;
using Colegio.Data.Repository;

namespace Colegio.App.Configurations
{
    /// <summary>
    /// Classe de configuração de injeção de dependência
    /// </summary>
    public static class DependencyInjectionConfig
    {
        /// <summary>
        /// Resolve as dependências necessárias
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            // Data
            services.AddScoped<ColegioDbContext>();
            services.AddScoped<IDBInitializer, DBInitializer>();
            services.AddScoped<IUnidadeEnsinoRepository, UnidadeEnsinoRepository>();
            services.AddScoped<ITurmaRepository, TurmaRepository>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<ICoordenadorRepository, CoordenadorRepository>();

            // Business
            services.AddScoped<IUnidadeEnsinoService, UnidadeEnsinoService>();
            services.AddScoped<ITurmaService, TurmaService>();
            services.AddScoped<IProfessorService, ProfessorService>();
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<ICoordenadorService, CoordenadorService>();

            services.AddScoped<INotificador, Notificador>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();


            return services;
        }
    }
}
