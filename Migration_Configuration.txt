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

            // Country
            var countriesPath = string.Format(@"{0}\InitialData\Country.json", baseDir);
            List<Country> listCountries = JsonConvert.DeserializeObject<List<Country>>(File.ReadAllText(countriesPath));
            context.Country.AddRange(listCountries);

            // State
            var statesPath = string.Format(@"{0}\InitialData\State.json", baseDir);
            List<State> listStates = JsonConvert.DeserializeObject<List<State>>(File.ReadAllText(statesPath));
            context.States.AddRange(listStates);

            // Gender
            var genderPath = string.Format(@"{0}\InitialData\Gender.json", baseDir);
            List<Gender> listGender = JsonConvert.DeserializeObject<List<Gender>>(File.ReadAllText(genderPath));
            context.Genders.AddRange(listGender);

            // Grip
            var gripPath = string.Format(@"{0}\InitialData\Grip.json", baseDir);
            List<Grip> listGrip = JsonConvert.DeserializeObject<List<Grip>>(File.ReadAllText(gripPath));
            context.Grips.AddRange(listGrip);

            // Handedness
            var handednessPath = string.Format(@"{0}\InitialData\Handedness.json", baseDir);
            List<Handedness> listHandedness = JsonConvert.DeserializeObject<List<Handedness>>(File.ReadAllText(handednessPath));
            context.Handedness.AddRange(listHandedness);

            // Playing Style
            var playingStylePath = string.Format(@"{0}\InitialData\PlayingStyle.json", baseDir);
            List<PlayingStyle> listPlayingStyle = JsonConvert.DeserializeObject<List<PlayingStyle>>(File.ReadAllText(playingStylePath));
            context.PlayingStyles.AddRange(listPlayingStyle);

            context.SaveChanges();
        }
    }
}
