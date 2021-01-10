using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading.Tasks;
using Impostor.Api.Events;
using Impostor.Api.Events.Player;
using Impostor.Api.Net;
using Impostor.Api.Net.Inner.Objects;

namespace EM.Plugins.TestPlugin.Handlers
{
    public class GameEventListener : IEventListener
    {
        private async Task ServerSendChatToPlayerAsync(string text, IInnerPlayerControl player)
        {
            string playerName = player.PlayerInfo.PlayerName;
            await player.SetNameAsync($"PrivateMsg").ConfigureAwait(false);
            await player.SendChatToPlayerAsync($"{text}", player).ConfigureAwait(false);
            await player.SetNameAsync(playerName);
        }

        private async Task MakePlayerLookAtChat(IClientPlayer player)
        {
            await Task.Delay(TimeSpan.FromSeconds(0.5)).ConfigureAwait(false);
            string playername = player.Character.PlayerInfo.PlayerName;
            await player.Character.SetNameAsync($"OPEN CHAT").ConfigureAwait(false);
            await Task.Delay(TimeSpan.FromSeconds(3)).ConfigureAwait(false);
            await player.Character.SetNameAsync(playername).ConfigureAwait(false);
        }

        [EventListener(EventPriority.Monitor)]
        public void OnGame(IGameEvent e)
        {
            Console.WriteLine(e.GetType().Name + " triggered");
        }

        [EventListener]
        public void OnGameCreated(IGameCreatedEvent e)
        {
            Console.WriteLine("Game > created");
            Task.Run(async () =>
                     {
                         await Task.Delay(TimeSpan.FromSeconds(3));
                         e.Game.Host.Character.SendChatAsync("GAME CREATED UWU.");
                     });
        }

        [EventListener]
        public void OnGameStarting(IGameStartingEvent e)
        {
            Console.WriteLine("Game > starting");
            // foreach (IClientPlayer player in e.Game.Players)
            // {
            //     e.Game.SetInfectedAsync(e.Game.Players.Select(clientPlayer => clientPlayer.Character));
            //     // player.Character.SetMurderedByAsync(imposter);
            // }
            // List<IInnerPlayerControl> list = new List<IInnerPlayerControl>();
            // list.Add(e.Game.Host.Character);
            // e.Game.SetInfectedAsync(list);
            // int i = 0;
            // IClientPlayer imp = null;
            // foreach (IClientPlayer player in e.Game.Players)
            // {
            //     if (i == 1)
            //     {
            //         imp = player;
            //         break;
            //     }
            //
            //     i++;
            // }
            //
            // e.Game.SetInfectedAsync(new List<IInnerPlayerControl> {imp.Character});
        }

        [EventListener]
        public void OnSetStartCounter(IPlayerSetStartCounterEvent e)
        {
            if (e.SecondsLeft == 5)
            {
                // List<IInnerPlayerControl> list = new List<IInnerPlayerControl>();
                // list.Add(e.PlayerControl);
                // e.Game.SetInfectedAsync(list);
                // // foreach (IClientPlayer player in e.Game.Players)
                // // {
                // //     e.Game.SetInfectedAsync(e.Game.Players.Select(clientPlayer => clientPlayer.Character));
                // //     // player.Character.SetMurderedByAsync(imposter);
                // // }
                // //e.Game.SetInfectedAsync(e.Game.Players.Select(clientPlayer => clientPlayer.Character));
                // int i = 0;
                // IClientPlayer imp = null;
                // foreach (IClientPlayer player in e.Game.Players)
                // {
                //     if (i == 1)
                //     {
                //         imp = player;
                //         break;
                //     }
                //
                //     i++;
                // }
                //
                // e.Game.SetInfectedAsync(new List<IInnerPlayerControl> {imp.Character});
            }
        }

        [EventListener]
        public void OnGameStarted(IGameStartedEvent e)
        {
            Console.WriteLine("Game > started");

            IClientPlayer imposter = null;
            foreach (var player in e.Game.Players)
            {
                var info = player.Character.PlayerInfo;

                if (player.Character.PlayerInfo.IsImpostor)
                    imposter = player.Client.Player;

                Console.WriteLine($"- {info.PlayerName} {info.IsImpostor}");
            }

            // List<IInnerPlayerControl> list = new List<IInnerPlayerControl>();
            // list.Add(e.Game.Host.Character);
            // e.Game.SetInfectedAsync(list);

            // foreach (IClientPlayer player in e.Game.Players)
            // {
            //     e.Game.SetInfectedAsync(e.Game.Players.Select(clientPlayer => clientPlayer.Character));
            //     // player.Character.SetMurderedByAsync(imposter);
            // }
            // e.Game.SetInfectedAsync(e.Game.Players.Select(clientPlayer => clientPlayer.Character));
        }

        [EventListener]
        public void OnGameEnded(IGameEndedEvent e)
        {
            Console.WriteLine("Game > ended");
            Console.WriteLine("- Reason: " + e.GameOverReason);
        }

        [EventListener]
        public void OnGameDestroyed(IGameDestroyedEvent e)
        {
            Console.WriteLine("Game > destroyed");
        }

        [EventListener]
        public void OnPlayerJoined(IGamePlayerJoinedEvent e)
        {
            Console.WriteLine("Player joined a game.");
        }

        [EventListener]
        public void OnPlayerLeftGame(IGamePlayerLeftEvent e)
        {
            Console.WriteLine("Player left a game.");
        }
    }
}
