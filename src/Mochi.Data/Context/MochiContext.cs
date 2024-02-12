namespace Mochi.Data.Context;

public partial class MochiContext : DbContext
{
    //private readonly IConfiguration _configuration;

    //public MochiContext(IConfiguration configuration)
    //{
    //    _configuration = configuration;
    //}

    public MochiContext(DbContextOptions<MochiContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //if (!optionsBuilder.IsConfigured)
        //{
        //    optionsBuilder.UseSqlServer(_configuration[ConfigurationConstants.DefaultConnectionStringName]);
        //}
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
