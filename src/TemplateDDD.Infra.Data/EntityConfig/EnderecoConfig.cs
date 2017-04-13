using System.Data.Entity.ModelConfiguration;
using TemplateDDD.Domain.Entities;

namespace TemplateDDD.Infra.Data.EntityConfig
{
    public class EnderecoConfig : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfig()
        {
            HasKey(c => c.EnderecoId);

            Property(c => c.Logradouro)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Numero)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Bairro)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.CEP)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8);

            Property(c => c.Complemento)
                .HasMaxLength(100);

            //caso o endereço pudesse existir sem o cliente, no caso cliente opcional
            //HasOptional(e => e.Cliente)
            //    .WithMany(c => c.Enderecos)
            //    .HasForeignKey(e => e.ClienteId);


            HasRequired(e => e.Cliente)
                .WithMany(c => c.Enderecos)
                .HasForeignKey(e => e.ClienteId);

            ToTable("Enderecos");
        }
    }
}
