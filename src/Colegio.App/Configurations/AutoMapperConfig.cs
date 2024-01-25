using AutoMapper;
using Colegio.App.DTO;
using Colegio.Business.Models;
using Colegio.Business.Models.Enums;

namespace Colegio.App.Configurations
{
    /// <summary>
    /// Classe de configuração do AutoMapper
    /// </summary>
    public class AutoMapperConfig : Profile
    {
        /// <summary>
        /// Construtor da classe
        /// </summary>
        public AutoMapperConfig()
        {
            CreateMap<UnidadeEnsino, UnidadeEnsinoDTO>().ReverseMap();

            CreateMap<TurmaDTO, Turma>();
            CreateMap<Turma, TurmaDTO>()
                .ForMember(dest => dest.NomeUnidadeEnsino,
                    opt => opt.MapFrom(src => src.UnidadeEnsino == null ? string.Empty : src.UnidadeEnsino.Nome))
                .ForMember(dest => dest.PeriodoNome,
                    opt => opt.MapFrom(src => Enum.GetName(typeof(PeriodoEnum), src.Periodo)));

            CreateMap<ProfessorDTO, Professor>();
            CreateMap<Professor, ProfessorDTO>()
                .ForMember(dest => dest.NomeUnidadeEnsino,
                    opt => opt.MapFrom(src => src.UnidadeEnsino == null ? string.Empty : src.UnidadeEnsino.Nome));
            CreateMap<ProfessorDTOAtualizar, Professor>();
            CreateMap<Professor, ProfessorDTOAtualizar>()
                .ForMember(dest => dest.NomeUnidadeEnsino,
                    opt => opt.MapFrom(src => src.UnidadeEnsino == null ? string.Empty : src.UnidadeEnsino.Nome));

            CreateMap<CoordenadorDTO, Coordenador>();
            CreateMap<Coordenador, CoordenadorDTO>()
                .ForMember(dest => dest.NomeUnidadeEnsino,
                    opt => opt.MapFrom(src => src.UnidadeEnsino == null ? string.Empty : src.UnidadeEnsino.Nome));
            CreateMap<CoordenadorDTOAtualizar, Coordenador>();
            CreateMap<Coordenador, CoordenadorDTOAtualizar>()
                .ForMember(dest => dest.NomeUnidadeEnsino,
                    opt => opt.MapFrom(src => src.UnidadeEnsino == null ? string.Empty : src.UnidadeEnsino.Nome));

            CreateMap<AlunoDTO, Aluno>();
            CreateMap<Aluno, AlunoDTO>()
                .ForMember(dest => dest.NomeUnidadeEnsino,
                                   opt => opt.MapFrom(src => src.UnidadeEnsino == null ? string.Empty : src.UnidadeEnsino.Nome));
        }
    }
}
