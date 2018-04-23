﻿using System.Collections.Generic;
using TTAnalytics.Model;

namespace TTAnalytics.RepositoryInterface
{
    public interface IGripRepository
    {
        ICollection<Grip> GetAll();
        Grip Get(int id);
        Grip Add(Grip grip);
        Grip Update(Grip grip);
        void Delete(int id);
    }
}
