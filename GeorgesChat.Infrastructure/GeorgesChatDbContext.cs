using GeorgesChat.Infrastructure.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeorgesChat.Infrastructure;

public class GeorgesChatDbContext : IdentityDbContext<User>
{
	public GeorgesChatDbContext()
	{}

	public GeorgesChatDbContext(DbContextOptions<GeorgesChatDbContext> options)
		:base(options) { }

    public DbSet<Message> Messages => Set<Message>();

    public DbSet<Group> Groups => Set<Group>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=GeorgesChat;Integrated Security=true;");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
