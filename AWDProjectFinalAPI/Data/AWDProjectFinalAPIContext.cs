using AWDProjectFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace AWDProjectFinal.Data
{
    public class AWDProjectFinalAPIContext :DbContext
    {
        public AWDProjectFinalAPIContext(DbContextOptions<AWDProjectFinalAPIContext> options ): base(options)
        {

        }
        public DbSet<ApartmentModel> ApartmentModels { get; set; }
        public DbSet<OwnerApartment> OwnerApartments { get; set; }
        public DbSet<User> User { get; set; }
    }
}
