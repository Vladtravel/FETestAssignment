using Microsoft.EntityFrameworkCore;
using FETestAssignment.Models;

namespace FETestAssignment.Data
{
    public class FETestAssignmentContext : DbContext
    {
        public FETestAssignmentContext (DbContextOptions<FETestAssignmentContext> options)
            : base(options)
        {
        }

        public DbSet<Company> Company { get; set; }
    }
}
