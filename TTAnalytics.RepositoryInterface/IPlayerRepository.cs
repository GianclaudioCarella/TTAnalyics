using System.Collections.Generic;
using TTAnalytics.Model;

namespace TTAnalytics.RepositoryInterface
{
    public interface IPlayerRepository
    {
        ICollection<Player> GetAll();
        Player Get(int id);
        ICollection<Player> GetByClub(int clubId);
        void Add(Player player);
        void Update(Player player);
        void Delete(int id);
    }
}
