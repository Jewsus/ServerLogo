using System;
using Terraria;
using TerrariaApi.Server;
using System.IO;
using TShockAPI;

namespace ServerLogo

{
    [ApiVersion(1, 23)]
    public class ServerLogo : TerrariaPlugin
    {
        public static ServerLogoConfigFile ServerLogoConfig { get; set; }
        internal static string ServerLogoConfigPath { get { return Path.Combine(TShock.SavePath, "ServerLogoconfig.json"); } }
        public override string Author
        {
            get
            {
                return "Jewsus";
            }
        }

        public override string Description
        {
            get
            {
                return "Provides useless but shiny Server Logo";
            }
        }

        public override string Name
        {
            get
            {
                return "ServerLogo";
            }
        }

        public override Version Version
        {
            get
            {
                return new Version("1.0");
            }
        }

        public ServerLogo(Main Game) : base(Game)
        {
            Order = -50;
            ServerLogoConfig = new ServerLogoConfigFile();
        }

        public override void Initialize()
        {
            SetupConfig();
            Console.WriteLine();
            foreach (string line in ServerLogoConfig.logo)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(line);
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" Copyright (C) Jewsus, 2016 - ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("http://geck-forums.com");
            Console.WriteLine("\r\n");
        }

        public static void SetupConfig()
        {
            try
            {
                if (File.Exists(ServerLogoConfigPath))
                {
                    ServerLogoConfig = ServerLogoConfigFile.Read(ServerLogoConfigPath);
                }
                ServerLogoConfig.Write(ServerLogoConfigPath);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error in ServerLogo config file");
                Console.ForegroundColor = ConsoleColor.Gray;

                TShock.Log.ConsoleError("ServerLogo Config Exception");
                TShock.Log.ConsoleError(ex.ToString());
            }
        }
    }
}
