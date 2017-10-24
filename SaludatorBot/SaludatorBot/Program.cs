using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace SaludatorBot
{
    class Program

    {
        private DiscordSocketClient client;
        private CommandHandler handler;
        static void Main(string[] args)
        => new Program().StartAsync().GetAwaiter().GetResult();
        public async Task StartAsync()
        {
            client = new DiscordSocketClient();
            new CommandHandler(client);
            await client.LoginAsync(Discord.TokenType.Bot, "MzcyNDI2NzUyMzM4ODIxMTIw.DNEA9A.0pAr324Jlo-G0v3D0nfSLrpas0Q");
            await client.StartAsync();
            handler = new CommandHandler(client);
            await Task.Delay(-1);
            
        }
    }


}
