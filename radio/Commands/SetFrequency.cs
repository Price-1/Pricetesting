using System;
using System.Collections.Generic;
using GTANetworkAPI;

namespace Pricetesting.radio
{
    public class SetPlayerFrequency:Script
    {
        [Command("frequency", Alias = "fr", GreedyArg = false)]
        public void SetRadioFrequency(Player player, int Frequency)
        {
            if(player.GetData<Data>(Data.GameData).LEO != true)
                player.SendChatMessage($"~r~ You're not Law Enforcement!"); //Checks if the player has the data
            else
            {
                Data.ReturnData(player).Frequency = Frequency; //Sets the frequency data
            }
        }

    }
}