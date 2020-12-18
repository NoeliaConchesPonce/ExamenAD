using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AE5.Models
{
    public class PlaceMyBetContext : DbContext
    {


        /*eso crea una tabla con todas las propiedades de esta clase */
        public DbSet<Evento> Evento { get; set; } //tabla
        public DbSet<Mercado> Mercado { get; set; } //tabla
        public DbSet<Apuesta> Apuesta { get; set; } //tabla
        public DbSet<Usuario> Usuario { get; set; } //tabla
        public DbSet<Cuenta> Cuenta { get; set; } //tabla
        public DbSet<EventoDTO> EventoDTO { get; set; } //tabla

        /*constructor*/
        public PlaceMyBetContext()
        {
        }

        /*constructor con herencia*/
        public PlaceMyBetContext(DbContextOptions options)
        : base(options)
        {
        }

        //Mètode de configuración
        /*conexion que va a tener*/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Database=placemybet3;Uid=root;Pwd=''; SslMode = none");

            }
        }

        /*Lo que añade a las tablas creadas*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evento>().HasData(new Evento(1, "Valencia", "Barcelona", DateTime.Now));
            modelBuilder.Entity<Mercado>().HasData(new Mercado(1000, 1.9, 1.9, 1));//modificado por examen ejercicio 1
            modelBuilder.Entity<Usuario>().HasData(new Usuario("usuario1@gmail.com", "Noelia", "Conches", 21));
            modelBuilder.Entity<Apuesta>().HasData(new Apuesta(12, 1.5, "over", 1.9, 20, DateTime.Now, 1, 1000, "usuario1@gmail.com"));
            modelBuilder.Entity<Cuenta>().HasData(new Cuenta("12345678", "BBVA", 360.25, "usuario1@gmail.com"));
        }
    }
}