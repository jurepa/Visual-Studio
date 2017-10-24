using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SaludatorBot
{
    public class CommandHandler
    {
        private DiscordSocketClient client;
        private CommandService service;
        public CommandHandler(DiscordSocketClient client)
        {
            this.client = client;
            service = new CommandService();
            service.AddModulesAsync(Assembly.GetEntryAssembly());
            client.MessageReceived +=HandleCommandAsync;
        }


        private async Task HandleCommandAsync(SocketMessage s)
        {
            int argPos = 0;
            SocketUserMessage msg = (SocketUserMessage)s;
            SocketCommandContext context = new SocketCommandContext(client,msg);
            if (msg.HasCharPrefix('!', ref argPos))
            {
               var result= await service.ExecuteAsync(context, argPos);

                if (!result.IsSuccess && result.Error!=CommandError.UnknownCommand)
                {
                    await context.Channel.SendMessageAsync(result.ErrorReason);
                }
            }
        }
    }
}
