using ITExpert.Models;
using Microsoft.EntityFrameworkCore;

namespace ITExpert.DAL.Context;

public class ApplicationDbContext : DbContext
{
    public DbSet<Data> Datas { get; set; } = default!;
    public DbSet<Client> Clients { get; set; } = default!;
    public DbSet<ClientContact> ClientContacts { get; set; } = default!;
    public DbSet<RequestInfo> RequestInfos { get; set; } = default!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }
}