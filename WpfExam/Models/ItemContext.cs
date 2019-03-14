using System.Data.Entity;

namespace WpfExam.Models
{
    public class ItemContext : DbContext
    {
        public ItemContext(): base("connectionString")
        {

        }
        public DbSet<Item> Items { get; set; }
    }
}
