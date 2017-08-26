using System.Data.Entity;                                                               
using Metrocare.Common;                                                       
                                                                                        
namespace Metrocare.Data                                                      
{                                                                                       
    public class MetrocareContext : DbContext                         
    {                                                                                   
             public DbSet<AgendaDto> Agenda { get; set; }
             public DbSet<AltaDto> Alta { get; set; }
             public DbSet<AlteracaoDto> Alteracao { get; set; }
             public DbSet<AtendimentoDto> Atendimento { get; set; }
             public DbSet<BeneficiarioDto> Beneficiario { get; set; }
             public DbSet<CaraterAtendimentoDto> CaraterAtendimento { get; set; }
             public DbSet<CarteiraDto> Carteira { get; set; }
             public DbSet<CboDto> Cbo { get; set; }
             public DbSet<ConcelhoProfissionalDto> ConcelhoProfissional { get; set; }
             public DbSet<ContratoDto> Contrato { get; set; }
             public DbSet<CredenciadoDto> Credenciado { get; set; }
             public DbSet<CredenciadoEnderecoDto> CredenciadoEndereco { get; set; }
             public DbSet<CredenciadoEspecialidadeDto> CredenciadoEspecialidade { get; set; }
             public DbSet<DependenteDto> Dependente { get; set; }
             public DbSet<DiaDto> Dia { get; set; }
             public DbSet<EspecialidadeDto> Especialidade { get; set; }
             public DbSet<GlosasMensagensDto> GlosasMensagens { get; set; }
             public DbSet<GrauParentescoDto> GrauParentesco { get; set; }
             public DbSet<GrauParticipacaoDto> GrauParticipacao { get; set; }
             public DbSet<IndicadorAcidenteDto> IndicadorAcidente { get; set; }
             public DbSet<LogAcessoDto> LogAcesso { get; set; }
             public DbSet<LogBeneficiarioDto> LogBeneficiario { get; set; }
             public DbSet<LogContratoDto> LogContrato { get; set; }
             public DbSet<LogCredenciadoDto> LogCredenciado { get; set; }
             public DbSet<LogDependenteDto> LogDependente { get; set; }
             public DbSet<LogPlanoDto> LogPlano { get; set; }
             public DbSet<LogPrestadorDto> LogPrestador { get; set; }
             public DbSet<PeriodoDto> Periodo { get; set; }
             public DbSet<PlanoDto> Plano { get; set; }
             public DbSet<PlanoCategoriaDto> PlanoCategoria { get; set; }
             public DbSet<PlanoInativacaoDto> PlanoInativacao { get; set; }
             public DbSet<PlanoTabelaDto> PlanoTabela { get; set; }
             public DbSet<PrestadorDto> Prestador { get; set; }
             public DbSet<TabelaProcedDto> TabelaProced { get; set; }
             public DbSet<TecnicaUtilizadaDto> TecnicaUtilizada { get; set; }
             public DbSet<TempoDoencaDto> TempoDoenca { get; set; }
             public DbSet<TipoAcomodacaoDto> TipoAcomodacao { get; set; }
             public DbSet<TipoAtendimentoDto> TipoAtendimento { get; set; }
             public DbSet<TipoDoencaDto> TipoDoenca { get; set; }
             public DbSet<TipoGuiaDto> TipoGuia { get; set; }
             public DbSet<TipoGuiaSaidaDto> TipoGuiaSaida { get; set; }
             public DbSet<TipoInternacaoDto> TipoInternacao { get; set; }
             public DbSet<TussDto> Tuss { get; set; }
             public DbSet<UnidadeTempoDto> UnidadeTempo { get; set; }
             public DbSet<UsuarioDto> Usuario { get; set; }
                                                                                         
        static MetrocareContext()                                      
        {                                                                                
             Database.SetInitializer<MetrocareContext>(null);          
        }                                                                                
                                                                                         
        public MetrocareContext() : base("Name = DefaultConnection") 
        {                                                                                
             this.Configuration.AutoDetectChangesEnabled = true;                         
             this.Configuration.ValidateOnSaveEnabled = false;                           
             this.Configuration.LazyLoadingEnabled = false;                              
             this.Configuration.ProxyCreationEnabled = false;                            
             this.Configuration.UseDatabaseNullSemantics = true;                         
        }                                                                                
                                                                                         
        protected override void OnModelCreating(DbModelBuilder ModelBuilder)             
        {                                                                                
             ModelBuilder.Configurations.Add(new AgendaMapper());   
             ModelBuilder.Configurations.Add(new AltaMapper());   
             ModelBuilder.Configurations.Add(new AlteracaoMapper());   
             ModelBuilder.Configurations.Add(new AtendimentoMapper());   
             ModelBuilder.Configurations.Add(new BeneficiarioMapper());   
             ModelBuilder.Configurations.Add(new CaraterAtendimentoMapper());   
             ModelBuilder.Configurations.Add(new CarteiraMapper());   
             ModelBuilder.Configurations.Add(new CboMapper());   
             ModelBuilder.Configurations.Add(new ConcelhoProfissionalMapper());   
             ModelBuilder.Configurations.Add(new ContratoMapper());   
             ModelBuilder.Configurations.Add(new CredenciadoMapper());   
             ModelBuilder.Configurations.Add(new CredenciadoEnderecoMapper());   
             ModelBuilder.Configurations.Add(new CredenciadoEspecialidadeMapper());   
             ModelBuilder.Configurations.Add(new DependenteMapper());   
             ModelBuilder.Configurations.Add(new DiaMapper());   
             ModelBuilder.Configurations.Add(new EspecialidadeMapper());   
             ModelBuilder.Configurations.Add(new GlosasMensagensMapper());   
             ModelBuilder.Configurations.Add(new GrauParentescoMapper());   
             ModelBuilder.Configurations.Add(new GrauParticipacaoMapper());   
             ModelBuilder.Configurations.Add(new IndicadorAcidenteMapper());   
             ModelBuilder.Configurations.Add(new LogAcessoMapper());   
             ModelBuilder.Configurations.Add(new LogBeneficiarioMapper());   
             ModelBuilder.Configurations.Add(new LogContratoMapper());   
             ModelBuilder.Configurations.Add(new LogCredenciadoMapper());   
             ModelBuilder.Configurations.Add(new LogDependenteMapper());   
             ModelBuilder.Configurations.Add(new LogPlanoMapper());   
             ModelBuilder.Configurations.Add(new LogPrestadorMapper());   
             ModelBuilder.Configurations.Add(new PeriodoMapper());   
             ModelBuilder.Configurations.Add(new PlanoMapper());   
             ModelBuilder.Configurations.Add(new PlanoCategoriaMapper());   
             ModelBuilder.Configurations.Add(new PlanoInativacaoMapper());   
             ModelBuilder.Configurations.Add(new PlanoTabelaMapper());   
             ModelBuilder.Configurations.Add(new PrestadorMapper());   
             ModelBuilder.Configurations.Add(new TabelaProcedMapper());   
             ModelBuilder.Configurations.Add(new TecnicaUtilizadaMapper());   
             ModelBuilder.Configurations.Add(new TempoDoencaMapper());   
             ModelBuilder.Configurations.Add(new TipoAcomodacaoMapper());   
             ModelBuilder.Configurations.Add(new TipoAtendimentoMapper());   
             ModelBuilder.Configurations.Add(new TipoDoencaMapper());   
             ModelBuilder.Configurations.Add(new TipoGuiaMapper());   
             ModelBuilder.Configurations.Add(new TipoGuiaSaidaMapper());   
             ModelBuilder.Configurations.Add(new TipoInternacaoMapper());   
             ModelBuilder.Configurations.Add(new TussMapper());   
             ModelBuilder.Configurations.Add(new UnidadeTempoMapper());   
             ModelBuilder.Configurations.Add(new UsuarioMapper());   
        }                                                                                
    }                                                                                    
}                                                                                        

