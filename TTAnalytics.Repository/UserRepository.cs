﻿using System.Collections.Generic;
using System.Linq;
using TTAnalytics.Data;
using TTAnalytics.Model;
using TTAnalytics.RepositoryInterface;

namespace TTAnalytics.Repository
{
    public class UserRepository : IUserRepository
    {
        private TTAnalyticsContext context;

        public UserRepository(TTAnalyticsContext context)
        {
            this.context = context;
        }

        public ICollection<User> GetAll()
        {
            return context.Users.ToList();
        }

        public User Get(int id)
        {
            return context.Users.Where(p => p.Id == id).FirstOrDefault();
        }


        public void Add(User user)
        {
            context.Users.Add(user);

            Save();
        }

        public void Update(User user)
        {
            context.Entry(user).State = System.Data.Entity.EntityState.Modified;

            Save();
        }


        public void Delete(int id)
        {
            User user = context.Users.Find(id);
            context.Users.Remove(user);

            Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
