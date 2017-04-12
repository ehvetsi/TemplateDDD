using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateDDD.Domain.Entities;
using TemplateDDD.Infra.Data.EntityConfig;

namespace TemplateDDD.Infra.Data.Context
{
    public class TemplateDDDContext : DbContext
    {
        public TemplateDDDContext()
           : base("DefaultConnection")
        {

        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(c => c.Name == c.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(c => c.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(c => c.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ClienteConfig());
            modelBuilder.Configurations.Add(new EnderencoConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
