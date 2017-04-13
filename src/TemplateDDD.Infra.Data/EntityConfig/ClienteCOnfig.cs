using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using TemplateDDD.Domain.Entities;

namespace TemplateDDD.Infra.Data.EntityConfig
{
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            HasKey(c => c.ClienteId);

            //Se for utilizar chave composta
            //HasKey(c => new { c.ClienteId, c.CPF });

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.CPF)
                .IsRequired()
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IndiceClienteCpf") { IsUnique = true }));

            Property(c => c.DataNascimento)
                .IsRequired();

            Property(c => c.Ativo)
                .IsRequired();

            ToTable("Clientes");
        }
    }
}
