namespace Myblazorapp.Services
{
    using Myblazorapp.Models;

    public class EventService
    {
        private List<Event> events = new()
        {
            new Event
            {
                Id = 1,
                Name = "Annual Corporate Summit",
                Description = "Join us for our flagship corporate summit featuring industry leaders and networking opportunities.",
                Date = new DateTime(2025, 3, 15),
                Location = "New York Convention Center",
                Category = "Corporate",
                AvailableSeats = 150,
                Price = 199.99m,
                ImageUrl = "https://via.placeholder.com/400x250?text=Corporate+Summit"
            },
            new Event
            {
                Id = 2,
                Name = "Tech Innovation Conference",
                Description = "Explore the latest innovations in technology with talks from renowned engineers and entrepreneurs.",
                Date = new DateTime(2025, 4, 10),
                Location = "San Francisco Tech Hub",
                Category = "Technology",
                AvailableSeats = 200,
                Price = 149.99m,
                ImageUrl = "https://via.placeholder.com/400x250?text=Tech+Conference"
            },
            new Event
            {
                Id = 3,
                Name = "Spring Networking Gala",
                Description = "An elegant evening to connect with professionals from various industries.",
                Date = new DateTime(2025, 5, 22),
                Location = "Downtown Grand Hotel",
                Category = "Social",
                AvailableSeats = 100,
                Price = 79.99m,
                ImageUrl = "https://via.placeholder.com/400x250?text=Networking+Gala"
            },
            new Event
            {
                Id = 4,
                Name = "Leadership Workshop",
                Description = "Develop your leadership skills through interactive workshops and mentoring sessions.",
                Date = new DateTime(2025, 6, 5),
                Location = "Business Innovation Center",
                Category = "Workshop",
                AvailableSeats = 50,
                Price = 299.99m,
                ImageUrl = "https://via.placeholder.com/400x250?text=Leadership+Workshop"
            }
        };

        public Task<List<Event>> GetAllEventsAsync()
        {
            return Task.FromResult(events);
        }

        public Task<Event?> GetEventByIdAsync(int id)
        {
            var @event = events.FirstOrDefault(e => e.Id == id);
            return Task.FromResult(@event);
        }

        public Task<bool> RegisterForEventAsync(int eventId)
        {
            var @event = events.FirstOrDefault(e => e.Id == eventId);
            if (@event != null && @event.AvailableSeats > 0)
            {
                @event.AvailableSeats--;
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
