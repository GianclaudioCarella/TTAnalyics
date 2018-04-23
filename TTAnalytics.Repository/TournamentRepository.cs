using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TTAnalytics.Data;
using TTAnalytics.Model;
using TTAnalytics.RepositoryInterface;

namespace TTAnalytics.Repository
{
    public class TournamentRepository : ITournamentRepository
    {
        private TTAnalyticsContext context;
        private IOrganizerRepository organizerRepository;
        private ICategoryRepository categoryRepository;
        private IVenueRepository venueRepository;

        public TournamentRepository(TTAnalyticsContext context, IOrganizerRepository organizerRepository, ICategoryRepository categoryRepository, IVenueRepository venueRepository)
        {
            this.context = context;
            this.organizerRepository = organizerRepository;
            this.categoryRepository = categoryRepository;
            this.venueRepository = venueRepository;
        }

        public ICollection<Tournament> GetAll()
        {
            return context.Tournaments
                .Include(c => c.Organizer)
                .Include(c => c.Categories)
                .Include(c => c.Venue)
                .ToList();
        }

        public Tournament Get(int id)
        {
            return context.Tournaments
                .Where(p => p.Id == id)
                .Include(c => c.Organizer)
                .Include(c => c.Categories)
                .Include(c => c.Venue)
                .FirstOrDefault();
        }


        public Tournament Add(Tournament tournament)
        {
            Organizer organizer;
            if (tournament.Organizer == null)
            {
                organizer = organizerRepository.Add(tournament.Organizer); 
            }
            else
            {
                organizer = organizerRepository.Get(tournament.Organizer.Id);
            }

            Venue venue;
            if (tournament.Venue == null)
            {
                venue = venueRepository.Add(tournament.Venue);
            }
            else
            {
                venue = venueRepository.Get(tournament.Venue.Id);
            }

            ICollection<Category> categories = new List<Category>();
            if (tournament.Categories != null && tournament.Categories.Count > 0)
            {
                foreach (Category category in tournament.Categories)
                {
                    var categoryFromDb = categoryRepository.Get(category.Id);

                    if (categoryFromDb == null)
                    {
                        categories.Add(categoryRepository.Add(category));
                    }
                    else
                    {
                        categories.Add(categoryFromDb);
                    }
                }
            }

            tournament.Organizer = organizer;
            tournament.Venue = venue;
            tournament.Categories = categories;

            var result = context.Tournaments.Add(tournament);

            Save();

            return result;
        }

        public Tournament Update(Tournament tournament)
        {
            context.Entry(tournament).State = EntityState.Modified;

            Save();

            return tournament;
        }
        
        public void Delete(int id)
        {
            Tournament tournament = context.Tournaments.Find(id);
            context.Tournaments.Remove(tournament);

            Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
