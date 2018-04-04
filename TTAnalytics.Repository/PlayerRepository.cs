using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TTAnalytics.Data;
using TTAnalytics.Model;
using TTAnalytics.RepositoryInterface;

namespace TTAnalytics.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private TTAnalyticsContext context;

        public PlayerRepository(TTAnalyticsContext context)
        {
            this.context = context;
        }

        public ICollection<Player> GetAll()
        {
            return context.Players
                .Include(p => p.Club)
                .Include(p => p.Country)
                .Include(p => p.Grip)
                .Include(p => p.Gender)
                .Include(p => p.Handedness)
                .Include(p => p.PlayingStyle)
                .ToList();
        }

        public Player Get(int id)
        {
            return context.Players
                .Where(p => p.Id == id)
                .Include(p => p.Club)
                .Include(p => p.Country)
                .Include(p => p.Grip)
                .Include(p => p.Gender)
                .Include(p => p.Handedness)
                .Include(p => p.PlayingStyle)
                .FirstOrDefault();
        }

        public ICollection<Player> GetByClub(int clubId)
        {
            return context.Players
                .Where(p => p.Club.Id == clubId)
                .Include(p => p.Club)
                .Include(p => p.Country)
                .Include(p => p.Grip)
                .Include(p => p.Gender)
                .Include(p => p.Handedness)
                .Include(p => p.PlayingStyle)
                .ToList();
        }
        
        public void Add(Player player)
        {
            context.Players.Add(player);

            Save();
        }

        public void Update(Player player)
        {
            context.Entry(player).State = System.Data.Entity.EntityState.Modified;

            Save();
        }


        public void Delete(int id)
        {
            Player player = context.Players.Find(id);
            context.Players.Remove(player);

            Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
