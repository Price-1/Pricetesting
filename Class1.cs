using System;
using System.Collections.Generic;
using GTANetworkAPI;

namespace Pricetesting
{
    public class Class1:Script
    {
       [ServerEvent(Event.ResourceStart)]
       public void OnStartGame(){
           NAPI.Util.ConsoleOutput("Resource Files Loaded!");
       }
       [ServerEvent(Event.PlayerConnected)]
       public void ConnectedPlayer(Player player){
            if(player.HasData(Data.GameData))
                player.ResetData(Data.GameData);
            player.SetData<Data>(Data.GameData, new Data()); 
       }
       
    }
}
