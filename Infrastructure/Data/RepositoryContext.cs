using BetPay.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class RepositoryContext : DbContext
{
    public DbSet<Bet> Bets { get; set; }
}