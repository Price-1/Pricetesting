using System;
using System.Collections.Generic;
using GTANetworkAPI;

namespace Pricetesting.radio
{
    public class radio:Script
    {
        [Command("radio", Alias = "r", GreedyArg = true)] //Creates a new command
        public void SendRadio(Player player, string message) //Sending, receiving and message
        {

            List<Player> TunedPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(1500, player);


            if (Data.ReturnData(player).LEO != true){ //Checks whether the player is a LEO or not
                player.SendChatMessage($"~r~ You are not law enforcement!");
                return;}
            
            else{
                foreach (Player Hearing in TunedPlayers)
                {
                    var hearing = Hearing.GetData<Data>(Data.GameData);
                    if (hearing.LEO == true && hearing.Frequency == player.GetData<Data>(Data.GameData).Frequency) //If both the player and the target are LEO, the receiver hears the message
                    Hearing.SendChatMessage($"~o~ {player.Name} radios: {message}");
                    else
                    return;
                }
            }
        }
    }
}
