using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTAnalytics.Data;
using TTAnalytics.Model;
using TTAnalytics.RepositoryInterface;

namespace TTAnalytics.Repository
{
    public class PlayingStyleRepository : IPlayingStyleRepository
    {
        private TTAnalyticsContext context;

        public PlayingStyleRepository(TTAnalyticsContext context)
        {
            this.context = context;
        }

        public ICollection<PlayingStyle> GetAll()
        {
            return context.PlayingStyles.ToList();
        }

        public PlayingStyle Get(int id)
        {
            return context.PlayingStyles.Where(p => p.Id == id).FirstOrDefault();
        }


        public void Add(PlayingStyle playingStyle)
        {
            context.PlayingStyles.Add(playingStyle);

            Save();
        }

        public void Update(PlayingStyle playingStyle)
        {
            context.Entry(playingStyle).State = System.Data.Entity.EntityState.Modified;

            Save();
        }


        public void Delete(int id)
        {
            PlayingStyle playingStyle = context.PlayingStyles.Find(id);
            context.PlayingStyles.Remove(playingStyle);

            Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
