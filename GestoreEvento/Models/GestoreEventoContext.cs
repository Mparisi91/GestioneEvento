using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GestoreEvento.Models;

public partial class GestoreEventoContext : DbContext
{
    public GestoreEventoContext()
    {
    }

    public GestoreEventoContext(DbContextOptions<GestoreEventoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<Partecipante> Partecipantes { get; set; }

    public virtual DbSet<Risorse> Risorses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ACADEMY2024-12\\SQLEXPRESS;Database=GestoreEvento;User Id=academy;Password=academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.EventoId).HasName("PK__Evento__DE07229CC5642F95");

            entity.ToTable("Evento");

            entity.Property(e => e.EventoId).HasColumnName("eventoID");
            entity.Property(e => e.CapacitaMassima).HasColumnName("capacitaMassima");
            entity.Property(e => e.DataEvento)
                .HasColumnType("datetime")
                .HasColumnName("dataEvento");
            entity.Property(e => e.Deleted)
                .HasColumnType("datetime")
                .HasColumnName("deleted");
            entity.Property(e => e.DescrizioneEvento)
                .HasColumnType("text")
                .HasColumnName("descrizioneEvento");
            entity.Property(e => e.LuogoEvento)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("luogoEvento");
            entity.Property(e => e.NomeEvento)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nomeEvento");
        });

        modelBuilder.Entity<Partecipante>(entity =>
        {
            entity.HasKey(e => e.PartecipanteId).HasName("PK__Partecip__59BAFC0E4B307CA5");

            entity.ToTable("Partecipante");

            entity.Property(e => e.PartecipanteId).HasColumnName("partecipanteID");
            entity.Property(e => e.Deleted)
                .HasColumnType("datetime")
                .HasColumnName("deleted");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nominativo)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nominativo");
            entity.Property(e => e.Telefono)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Risorse>(entity =>
        {
            entity.HasKey(e => e.RisorseId).HasName("PK__Risorse__3247FA90EBDE8667");

            entity.ToTable("Risorse");

            entity.Property(e => e.RisorseId).HasColumnName("risorseID");
            entity.Property(e => e.Costo)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("costo");
            entity.Property(e => e.Deleted)
                .HasColumnType("datetime")
                .HasColumnName("deleted");
            entity.Property(e => e.EventoRif).HasColumnName("eventoRIF");
            entity.Property(e => e.Fornitore)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("fornitore");
            entity.Property(e => e.Quantita).HasColumnName("quantita");
            entity.Property(e => e.Tipo)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("tipo");

            entity.HasOne(d => d.EventoRifNavigation).WithMany(p => p.Risorses)
                .HasForeignKey(d => d.EventoRif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Risorse__deleted__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
