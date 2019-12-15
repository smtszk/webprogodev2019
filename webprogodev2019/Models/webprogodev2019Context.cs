using System;
using Microsoft.EntityFrameworkCore;
namespace webprogodev2019.Models
{
    public class webprogodev2019Context: DbContext
    {
        public webprogodev2019Context(DbContextOptions<webprogodev2019Context> options) : base(options) { }
        public DbSet<webprogodev2019.Models.Haber> Haber { get; set; }
    }
}
