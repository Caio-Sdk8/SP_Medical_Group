using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SpMedicalGroup.WebApi.Domains;

#nullable disable

namespace SpMedicalGroup.WebApi.Contexts
{
    public partial class SpMedicalGpContext : DbContext
    {
        public SpMedicalGpContext()
        {
        }

        public SpMedicalGpContext(DbContextOptions<SpMedicalGpContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrador> Administradors { get; set; }
        public virtual DbSet<Clinica> Clinicas { get; set; }
        public virtual DbSet<Consultum> Consulta { get; set; }
        public virtual DbSet<Especialidade> Especialidades { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<Situacao> Situacaos { get; set; }
        public virtual DbSet<Telefone> Telefones { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
 //To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS; initial catalog=SP_MEDICAL_GROUP_CSDMANHA; user Id=sa; pwd=Senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.HasKey(e => e.IdAdministrador)
                    .HasName("PK__administ__EBE80EA132A98750");

                entity.ToTable("administrador");

                entity.HasIndex(e => e.IdUsuario, "UQ__administ__645723A74A9153AD")
                    .IsUnique();

                entity.HasIndex(e => e.CpfAdministrador, "UQ__administ__800BC745328DA052")
                    .IsUnique();

                entity.HasIndex(e => e.RgAdministrador, "UQ__administ__92200403D43FB597")
                    .IsUnique();

                entity.Property(e => e.IdAdministrador).HasColumnName("idAdministrador");

                entity.Property(e => e.CpfAdministrador)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("cpfAdministrador");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.RgAdministrador)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("rgAdministrador");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithOne(p => p.Administrador)
                    .HasForeignKey<Administrador>(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__administr__idUsu__30F848ED");
            });

            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.HasKey(e => e.IdClinica)
                    .HasName("PK__clinica__C73A60553270E400");

                entity.ToTable("clinica");

                entity.HasIndex(e => e.EnderecoClinica, "UQ__clinica__229F2191790F336F")
                    .IsUnique();

                entity.HasIndex(e => e.Cnpj, "UQ__clinica__35BD3E4834603ED1")
                    .IsUnique();

                entity.HasIndex(e => e.RazaoSocial, "UQ__clinica__9BF93A309CD8F694")
                    .IsUnique();

                entity.Property(e => e.IdClinica).HasColumnName("idClinica");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("cnpj");

                entity.Property(e => e.DataFinal).HasColumnName("dataFinal");

                entity.Property(e => e.EnderecoClinica)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("enderecoClinica");

                entity.Property(e => e.HorarioInicial).HasColumnName("horarioInicial");

                entity.Property(e => e.IdAdministrador).HasColumnName("idAdministrador");

                entity.Property(e => e.NomeClinica)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nomeClinica");

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("razaoSocial");

                entity.HasOne(d => d.IdAdministradorNavigation)
                    .WithMany(p => p.Clinicas)
                    .HasForeignKey(d => d.IdAdministrador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__clinica__idAdmin__36B12243");
            });

            modelBuilder.Entity<Consultum>(entity =>
            {
                entity.HasKey(e => e.IdConsulta)
                    .HasName("PK__consulta__CA9C61F54514C2A0");

                entity.ToTable("consulta");

                entity.Property(e => e.IdConsulta).HasColumnName("idConsulta");

                entity.Property(e => e.DataConsulta)
                    .HasColumnType("date")
                    .HasColumnName("dataConsulta");

                entity.Property(e => e.DescricaoConsulta)
                    .HasMaxLength(800)
                    .IsUnicode(false)
                    .HasColumnName("descricaoConsulta")
                    .HasDefaultValueSql("('Sem descrição')");

                entity.Property(e => e.HorarioConsulta).HasColumnName("horarioConsulta");

                entity.Property(e => e.IdMedico).HasColumnName("idMedico");

                entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");

                entity.Property(e => e.IdSituacao).HasColumnName("idSituacao");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdMedico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__consulta__idMedi__4BAC3F29");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__consulta__idPaci__4D94879B");

                entity.HasOne(d => d.IdSituacaoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdSituacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__consulta__idSitu__4CA06362");
            });

            modelBuilder.Entity<Especialidade>(entity =>
            {
                entity.HasKey(e => e.IdEspecialidade)
                    .HasName("PK__especial__409698057406CFBC");

                entity.ToTable("especialidade");

                entity.HasIndex(e => e.NomeEspecialidade, "UQ__especial__EF876A5481867B05")
                    .IsUnique();

                entity.Property(e => e.IdEspecialidade).HasColumnName("idEspecialidade");

                entity.Property(e => e.NomeEspecialidade)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("nomeEspecialidade");
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.IdMedico)
                    .HasName("PK__medico__4E03DEBAEBE54888");

                entity.ToTable("medico");

                entity.HasIndex(e => e.IdUsuario, "UQ__medico__645723A72977683F")
                    .IsUnique();

                entity.HasIndex(e => e.Crm, "UQ__medico__D836F7D1C6E6FAE5")
                    .IsUnique();

                entity.Property(e => e.IdMedico).HasColumnName("idMedico");

                entity.Property(e => e.Crm)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("crm");

                entity.Property(e => e.IdClinica).HasColumnName("idClinica");

                entity.Property(e => e.IdEspecialidade).HasColumnName("idEspecialidade");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdClinica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__medico__idClinic__440B1D61");

                entity.HasOne(d => d.IdEspecialidadeNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdEspecialidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__medico__idEspeci__44FF419A");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithOne(p => p.Medico)
                    .HasForeignKey<Medico>(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__medico__idUsuari__4316F928");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.IdPaciente)
                    .HasName("PK__paciente__F48A08F2629120C7");

                entity.ToTable("paciente");

                entity.HasIndex(e => e.IdUsuario, "UQ__paciente__645723A7EB748F54")
                    .IsUnique();

                entity.HasIndex(e => e.RgPaciente, "UQ__paciente__6A3918E7A4601AFE")
                    .IsUnique();

                entity.HasIndex(e => e.CpfPaciente, "UQ__paciente__AC2DD3701C21E784")
                    .IsUnique();

                entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");

                entity.Property(e => e.CpfPaciente)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("cpfPaciente");

                entity.Property(e => e.DataNascimento)
                    .HasColumnType("date")
                    .HasColumnName("dataNascimento");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.RgPaciente)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("rgPaciente");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithOne(p => p.Paciente)
                    .HasForeignKey<Paciente>(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__paciente__idUsua__3C69FB99");
            });

            modelBuilder.Entity<Situacao>(entity =>
            {
                entity.HasKey(e => e.IdSituacao)
                    .HasName("PK__situacao__12AFD1978CF953AF");

                entity.ToTable("situacao");

                entity.HasIndex(e => e.DescricaoSituacao, "UQ__situacao__17A95845DE8B8BA6")
                    .IsUnique();

                entity.Property(e => e.IdSituacao).HasColumnName("idSituacao");

                entity.Property(e => e.DescricaoSituacao)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("descricaoSituacao");
            });

            modelBuilder.Entity<Telefone>(entity =>
            {
                entity.HasKey(e => e.IdTelefone)
                    .HasName("PK__telefone__39C142D596EA101C");

                entity.ToTable("telefone");

                entity.Property(e => e.IdTelefone).HasColumnName("idTelefone");

                entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");

                entity.Property(e => e.NumeroTelefone)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("numeroTelefone");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Telefones)
                    .HasForeignKey(d => d.IdPaciente)
                    .HasConstraintName("FK__telefone__idPaci__48CFD27E");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__tipoUsua__03006BFFCF2FE05B");

                entity.ToTable("tipoUsuario");

                entity.HasIndex(e => e.NomeTipoUsuario, "UQ__tipoUsua__A017BD9F22C9FCB3")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nomeTipoUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuario__645723A69309930F");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.EmailUsuario, "UQ__usuario__ACC1DD99944483DF")
                    .IsUnique();

                entity.HasIndex(e => new { e.EmailUsuario, e.SenhaUsuario }, "userSenhaEmail")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.EmailUsuario)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("emailUsuario");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomeUsuario");

                entity.Property(e => e.SenhaUsuario)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("senhaUsuario");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__usuario__idTipoU__5DCAEF64");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
