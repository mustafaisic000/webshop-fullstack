using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Models;


namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<AdresaKorisnika> AdresaKorisnika { get; set; }
        public DbSet<AdresaZaDostavu> AdresaZaDostavu { get; set; }
        public DbSet<Drzava> Drzava { get; set; }
        public DbSet<Grad> Grad { get; set; }
        public DbSet<Izuzetak> Izuzetak { get; set; }
        public DbSet<Kategorija> Kategorija { get; set; }
      
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<KorpaProdukt> KorpaProdukt { get; set; }
        public DbSet<Notifikacija> Notifikacija { get; set; }
        public DbSet<Ozbiljnost> Ozbiljnost { get; set; }
        
        public DbSet<Produkt> Produkt { get; set; }
        public DbSet<TipNotifikacije> TipNotifikacije { get; set; }
        public DbSet<Transakcija> Transakcija { get; set; }
        public DbSet<TransakcijaProdukt> TransakcijaProdukt { get; set; }
        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<Obavijesti> Obavijesti { get; set; }
        public DbSet<KorisnikObavijesti> KorisnikObavijesti { get; set; }
        public DbSet<KorisnickiNalog> KorisnickiNalog { get; set; }
        public DbSet<AutentifikacijaToken> AutentifikacijaToken { get; set; }
        public DbSet<LogKretanjePoSistemu> LogKretanjePoSistemu { get; set; }
        public ApplicationDbContext(
           DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produkt>()
                .Property(p => p.Cijena)
                .HasColumnType("decimal(18, 2)"); // Prilagodite tip i preciznost prema vašim potrebama

            modelBuilder.Entity<Transakcija>()
                .Property(t => t.UkupnaCijena)
                .HasColumnType("decimal(18, 2)"); // Prilagodite tip i preciznost prema vašim potrebama
        }

    }
}
