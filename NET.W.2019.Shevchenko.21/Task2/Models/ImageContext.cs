using System.Data.Entity;

namespace Task2.Models
{
    public class ImageContext : DbContext
    {
        public ImageContext()
            : base("ImageConnection")
        {
        }

        public DbSet<Image> Images { get; set; }
    }
}