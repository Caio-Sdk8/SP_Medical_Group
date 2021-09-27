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

        public virtual DbSet<administrador> administradors { get; set; }
        public virtual DbSet<clinica> clinicas { get; set; }
        public virtual DbSet<consultum> consulta { get; set; }
        public virtual DbSet<especialidade> especialidades { get; set; }
        public virtual DbSet<medico> medicos { get; set; }
        public virtual DbSet<paciente> pacientes { get; set; }
        public virtual DbSet<situacao> situacaos { get; set; }
        public virtual DbSet<telefone> telefones { get; set; }
        public virtual DbSet<usuario> usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=NOTE0113D2\\SQLEXPRESS; initial catalog=SP_MEDICAL_GROUP_CSDMANHA; user Id=sa; pwd=Senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<administrador>(entity =>
            {
                entity.HasKey(e => e.idAdministrador)
                    .HasName("PK__administ__EBE80EA132A98750");

                entity.ToTable("administrador");

                entity.HasIndex(e => e.idUsuario, "UQ__administ__645723A74A9153AD")
                    .IsUnique();

                entity.HasIndex(e => e.cpfAdministrador, "UQ__administ__800BC745328DA052")
                    .IsUnique();

                entity.HasIndex(e => e.rgAdministrador, "UQ__administ__92200403D43FB597")
                    .IsUnique();

                entity.Property(e => e.cpfAdministrador)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.rgAdministrador)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.HasOne(d => d.idUsuarioNavigation)
                    .WithOne(p => p.administrador)
                    .HasForeignKey<administrador>(d => d.idUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__administr__idUsu__30F848ED");
            });

            modelBuilder.Entity<clinica>(entity =>
            {
                entity.HasKey(e => e.idClinica)
                    .HasName("PK__clinica__C73A60553270E400");

                entity.ToTable("clinica");

                entity.HasIndex(e => e.enderecoClinica, "UQ__clinica__229F2191790F336F")
                    .IsUnique();

                entity.HasIndex(e => e.cnpj, "UQ__clinica__35BD3E4834603ED1")
                    .IsUnique();

                entity.HasIndex(e => e.razaoSocial, "UQ__clinica__9BF93A309CD8F694")
                    .IsUnique();

                entity.Property(e => e.cnpj)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.enderecoClinica)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.nomeClinica)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.razaoSocial)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.idAdministradorNavigation)
                    .WithMany(p => p.clinicas)
                    .HasForeignKey(d => d.idAdministrador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__clinica__idAdmin__36B12243");
            });

            modelBuilder.Entity<consultum>(entity =>
            {
                entity.HasKey(e => e.idConsulta)
                    .HasName("PK__consulta__CA9C61F54514C2A0");

                entity.Property(e => e.dataConsulta).HasColumnType("date");

                entity.Property(e => e.descricaoConsulta)
                    .HasMaxLength(800)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Sem descrição')");

                entity.HasOne(d => d.idMedicoNavigation)
                    .WithMany(p => p.consulta)
                    .HasForeignKey(d => d.idMedico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__consulta__idMedi__4BAC3F29");

                entity.HasOne(d => d.idPacienteNavigation)
                    .WithMany(p => p.consulta)
                    .HasForeignKey(d => d.idPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__consulta__idPaci__4D94879B");

                entity.HasOne(d => d.idSituacaoNavigation)
                    .WithMany(p => p.consulta)
                    .HasForeignKey(d => d.idSituacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__consulta__idSitu__4CA06362");
            });

            modelBuilder.Entity<especialidade>(entity =>
            {
                entity.HasKey(e => e.idEspecialidade)
                    .HasName("PK__especial__409698057406CFBC");

                entity.ToTable("especialidade");

                entity.HasIndex(e => e.nomeEspecialidade, "UQ__especial__EF876A5481867B05")
                    .IsUnique();

                entity.Property(e => e.nomeEspecialidade)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<medico>(entity =>
            {
                entity.HasKey(e => e.idMedico)
                    .HasName("PK__medico__4E03DEBAEBE54888");

                entity.ToTable("medico");

                entity.HasIndex(e => e.idUsuario, "UQ__medico__645723A72977683F")
                    .IsUnique();

                entity.HasIndex(e => e.crm, "UQ__medico__D836F7D1C6E6FAE5")
                    .IsUnique();

                entity.Property(e => e.crm)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.HasOne(d => d.idClinicaNavigation)
                    .WithMany(p => p.medicos)
                    .HasForeignKey(d => d.idClinica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__medico__idClinic__440B1D61");

                entity.HasOne(d => d.idEspecialidadeNavigation)
                    .WithMany(p => p.medicos)
                    .HasForeignKey(d => d.idEspecialidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__medico__idEspeci__44FF419A");

                entity.HasOne(d => d.idUsuarioNavigation)
                    .WithOne(p => p.medico)
                    .HasForeignKey<medico>(d => d.idUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__medico__idUsuari__4316F928");
            });

            modelBuilder.Entity<paciente>(entity =>
            {
                entity.HasKey(e => e.idPaciente)
                    .HasName("PK__paciente__F48A08F2629120C7");

                entity.ToTable("paciente");

                entity.HasIndex(e => e.idUsuario, "UQ__paciente__645723A7EB748F54")
                    .IsUnique();

                entity.HasIndex(e => e.rgPaciente, "UQ__paciente__6A3918E7A4601AFE")
                    .IsUnique();

                entity.HasIndex(e => e.cpfPaciente, "UQ__paciente__AC2DD3701C21E784")
                    .IsUnique();

                entity.Property(e => e.cpfPaciente)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.dataNascimento).HasColumnType("date");

                entity.Property(e => e.rgPaciente)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.idUsuarioNavigation)
                    .WithOne(p => p.paciente)
                    .HasForeignKey<paciente>(d => d.idUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__paciente__idUsua__3C69FB99");
            });

            modelBuilder.Entity<situacao>(entity =>
            {
                entity.HasKey(e => e.idSituacao)
                    .HasName("PK__situacao__12AFD1978CF953AF");

                entity.ToTable("situacao");

                entity.HasIndex(e => e.descricaoSituacao, "UQ__situacao__17A95845DE8B8BA6")
                    .IsUnique();

                entity.Property(e => e.descricaoSituacao)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<telefone>(entity =>
            {
                entity.HasKey(e => e.idTelefone)
                    .HasName("PK__telefone__39C142D596EA101C");

                entity.ToTable("telefone");

                entity.Property(e => e.numeroTelefone)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.HasOne(d => d.idPacienteNavigation)
                    .WithMany(p => p.telefones)
                    .HasForeignKey(d => d.idPaciente)
                    .HasConstraintName("FK__telefone__idPaci__48CFD27E");
            });

            modelBuilder.Entity<usuario>(entity =>
            {
                entity.HasKey(e => e.idUsuario)
                    .HasName("PK__usuario__645723A69309930F");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.emailUsuario, "UQ__usuario__ACC1DD99944483DF")
                    .IsUnique();

                entity.HasIndex(e => new { e.emailUsuario, e.senhaUsuario }, "userSenhaEmail")
                    .IsUnique();

                entity.Property(e => e.emailUsuario)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.nomeUsuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.senhaUsuario)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
