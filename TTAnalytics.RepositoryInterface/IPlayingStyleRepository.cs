using System.Collections.Generic;
using TTAnalytics.Model;

namespace TTAnalytics.RepositoryInterface
{
    public interface IPlayingStyleRepository
    {
        ICollection<PlayingStyle> GetAll();
        PlayingStyle Get(int id);
        PlayingStyle Add(PlayingStyle playingStyle);
        PlayingStyle Update(PlayingStyle playingStyle);
        void Delete(int id);
    }
}
