using Discord;
using System;
using System.IO;

namespace Doggo.Discord
{
    public class Configuration : ConfigurationBase
    {
        public string ModulePath { get; set; } = Path.Combine(AppContext.BaseDirectory, "modules");
        public AuthTokens Token { get; set; } = new AuthTokens();

        public Configuration() : base("configuration.json") { }

        public static Configuration Load()
            => Load<Configuration>();

        public static void EnsureExists()
        {
            string file = Path.Combine(AppContext.BaseDirectory, FileName);
            if (!File.Exists(file))
            {
                string path = Path.GetDirectoryName(file);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                var config = new Configuration();

                PrettyConsole.Log(LogSeverity.Warning, "Doggo", "Please enter discord token: ");
                string token = Console.ReadLine();

                config.Token.Discord = token;
                config.SaveJson();
            }
            PrettyConsole.Log(LogSeverity.Info, "Doggo", "Configuration Loaded");
        }
    }

    public class AuthTokens
    {
        public string Discord { get; set; }
        public string Github { get; set; }

    }
}
