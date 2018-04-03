namespace TTAnalytics.Data.Migrations
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Reflection;
    using TTAnalytics.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<TTAnalytics.Data.TTAnalyticsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TTAnalytics.Data.TTAnalyticsContext context)
        {
            var countriesPath = @"C:\_project\TTAnalytics\TTAnalytics.Data\TTAnalytics.Data\InitialSeed\Country.json";
            List<Country> listCountries = JsonConvert.DeserializeObject<List<Country>>(File.ReadAllText(countriesPath));

            context.Country.AddRange(listCountries);

            context.SaveChanges();
        }
    }
}
