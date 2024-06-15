using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PLASTIC_WARFARE_PROJ.Areas.Identity.Data;

public class Plastic_Warfare_Identity : IdentityDbContext<IdentityUser>
{
    public Plastic_Warfare_Identity(DbContextOptions<Plastic_Warfare_Identity> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
