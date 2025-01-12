using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using P_Galchis_Cristian.Models;

namespace P_Galchis_Cristian.Data
{
    public class P_Galchis_CristianContext : IdentityDbContext
    {
        public P_Galchis_CristianContext(DbContextOptions<P_Galchis_CristianContext> options)
            : base(options)
        {
        }

        public DbSet<Obiectiv> Obiectiv { get; set; } = default!;
        public DbSet<Client> Client { get; set; } = default!;
        public DbSet<Bilet> Bilet { get; set; } = default!;
        public DbSet<Stil> Stil { get; set; } = default!;

        public DbSet<Review> Review { get; set; } = default!; 

    }
}
