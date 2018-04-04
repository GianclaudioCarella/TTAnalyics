namespace TTAnalytics.Data.Migrations
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.IO;
    using TTAnalytics.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<TTAnalyticsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TTAnalyticsContext context)
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            baseDir = baseDir.Substring(0, baseDir.IndexOf("bin"));

            var countriesPath = string.Format(@"{0}\InitialData\Country.json", baseDir);
            List<Country> listCountries = JsonConvert.DeserializeObject<List<Country>>(File.ReadAllText(countriesPath));

            context.Country.AddRange(listCountries);

            context.SaveChanges();
        }
    }
}
