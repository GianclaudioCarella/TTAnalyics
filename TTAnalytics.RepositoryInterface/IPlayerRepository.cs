using System.Collections.Generic;
using TTAnalytics.Model;

namespace TTAnalytics.RepositoryInterface
{
    public interface IPlayerRepository
    {
        ICollection<Player> GetAll();
        Player Get(int id);
        ICollection<Player> GetByClub(int clubId);
        Player Add(Player player);
        Player Update(Player player);
        void Delete(int id);
    }
}
