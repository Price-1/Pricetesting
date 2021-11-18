using System;
using System.Collections.Generic;
using GTANetworkAPI;

namespace Pricetesting{
    public class PlayerCommands:Script
    {
        [Command("me", GreedyArg = true)]
        public void CMD_Me(Player player, string action)
        {
            List<Player> players = NAPI.Player.GetPlayersInRadiusOfPlayer(20, player);
            
            foreach (Player player1 in players)
            {
                player.SendChatMessage($"{player}{action}");
            }

            NAPI.Util.ConsoleOutput($"{player} has ran /me {action}");
        }

    }
}