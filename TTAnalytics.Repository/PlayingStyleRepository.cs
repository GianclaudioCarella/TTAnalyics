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


        public PlayingStyle Add(PlayingStyle playingStyle)
        {
            var result = context.PlayingStyles.Add(playingStyle);

            Save();

            return result;
        }

        public PlayingStyle Update(PlayingStyle playingStyle)
        {
            context.Entry(playingStyle).State = System.Data.Entity.EntityState.Modified;

            Save();

            return playingStyle;
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
