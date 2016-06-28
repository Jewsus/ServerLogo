using System;
using System.IO;
using Newtonsoft.Json;

namespace ServerLogo
{
    public class ServerLogoConfigFile
    {
        public string logo = string.Join(
            Environment.NewLine,

            " █░░▒▓▓▒░░░░░▒▓▀▄▀▄▀▄▓▒░░░░░▒▓▓▒░░█ ",
            " █                                █ ",
            " █              ╔╗   ╔═══╗  ╔═══╗ █ ",
            " █              ║║   ║╔═╗║  ║╔═╗║ █ ",
            " █ ╔══╗╔═══╗╔══╗║║╔╗ ╚╝╔╝║  ║║║║║ █ ",
            " █ ║╔╗║╠══║║║╔═╝║╚╝╝ ╔═╝╔╝  ║║║║║ █ ",
            " █ ║╚╝║║║══╣║╚═╗║╔╗╗ ║║╚═╗╔╗║╚═╝║ █ ",
            " █ ╚═╗║╚═══╝╚══╝╚╝╚╝ ╚═══╝╚╝╚═══╝ █ ",
            " █ ╔═╝║╔╗ ┬ ┬   ╦┌─┐┬ ┬┌─┐┬ ┬┌─┐  █ ",
            " █ ╚══╝╠╩╗└┬┘   ║├┤ │││└─┐│ │└─┐  █ ",
            " █     ╚═╝ ┴   ╚╝└─┘└┴┘└─┘└─┘└─┘  █ ",
            " █                                █ ",
            " █░░▒▓▓▒░░░░░▒▓▀▄▀▄▀▄▓▒░░░░░▒▓▓▒░░█ ");

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
