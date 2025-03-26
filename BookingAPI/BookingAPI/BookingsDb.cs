using Microsoft.EntityFrameworkCore;

namespace BookingAPI
{
    public class BookingsDb : DbContext
    {
        public BookingsDb(DbContextOptions<BookingsDb> options) 
            : base(options) { }
        public DbSet<Booking> Bookings => Set<Booking>();
    }
}
