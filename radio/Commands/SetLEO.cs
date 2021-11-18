using System;
using System.Collections.Generic;
using GTANetworkAPI;

namespace Pricetesting.radio
{
    public class SetPlayerLEO:Script
    {
        [Command("leo", Alias = "l", GreedyArg = false)]
        public void SetLeoStatus(Player player)
        {
         player.SendChatMessage("You've became a law enforcement officer!");
         Data.ReturnData(player).LEO = true; //Sets the LEO data
        }

    }
}