using System;
using System.IO;
using Newtonsoft.Json;

namespace ServerLogo
{
    public class ServerLogoConfigFile
    {
        public string logo1 = " █░░▒▓▓▒░░░░░▒▓▀▄▀▄▀▄▓▒░░░░░▒▓▓▒░░█ ";
        public string logo2 = " █                                █ ";
        public string logo3 = " █              ╔╗   ╔═══╗  ╔═══╗ █ ";
        public string logo4 = " █              ║║   ║╔═╗║  ║╔═╗║ █ ";
        public string logo5 = " █ ╔══╗╔═══╗╔══╗║║╔╗ ╚╝╔╝║  ║║║║║ █ ";
        public string logo6 = " █ ║╔╗║╠══║║║╔═╝║╚╝╝ ╔═╝╔╝  ║║║║║ █ ";
        public string logo7 = " █ ║╚╝║║║══╣║╚═╗║╔╗╗ ║║╚═╗╔╗║╚═╝║ █ ";
        public string logo8 = " █ ╚═╗║╚═══╝╚══╝╚╝╚╝ ╚═══╝╚╝╚═══╝ █ ";
        public string logo9 = " █ ╔═╝║╔╗ ┬ ┬   ╦┌─┐┬ ┬┌─┐┬ ┬┌─┐  █ ";
        public string logo10 = " █ ╚══╝╠╩╗└┬┘   ║├┤ │││└─┐│ │└─┐  █ ";
        public string logo11 = " █     ╚═╝ ┴   ╚╝└─┘└┴┘└─┘└─┘└─┘  █ ";
        public string logo12 = " █                                █ ";
        public string logo13 = " █░░▒▓▓▒░░░░░▒▓▀▄▀▄▀▄▓▒░░░░░▒▓▓▒░░█ ";


        public static ServerLogoConfigFile Read(string path)
        {
            if (!File.Exists(path))
                return new ServerLogoConfigFile();
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                return Read(fs);
            }
        }
        public static ServerLogoConfigFile Read(Stream stream)
        {
            using (var sr = new StreamReader(stream))
            {
                var cf = JsonConvert.DeserializeObject<ServerLogoConfigFile>(sr.ReadToEnd());
                if (ConfigRead != null)
                    ConfigRead(cf);
                return cf;
            }
        }
        public void Write(string path)
        {
            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                Write(fs);
            }
        }
        public void Write(Stream stream)
        {
            var str = JsonConvert.SerializeObject(this, Formatting.Indented);
            using (var sw = new StreamWriter(stream))
            {
                sw.Write(str);
            }
        }
        public static Action<ServerLogoConfigFile> ConfigRead;
    }
}