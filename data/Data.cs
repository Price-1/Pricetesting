using System;
using System.Collections.Generic;
using GTANetworkAPI;

namespace Pricetesting{

    public class Data
    {
        public const string GameData = "Game_Data";

        public int Frequency;
        public bool LEO;
        public AData.AdminRank adminRank;

        public Data()
        {
            this.LEO = false;
            this.Frequency = 0;
            this.adminRank = AData.AdminRank.None;

        }

        public static bool ReturnLEO(Player player)
        {
            return player.GetData<Data>(GameData).LEO; 
        }

        public static void SetLEO(Player player, bool status)
        {
            player.GetData<Data>(GameData).LEO = status;
        }
        
        public static Data ReturnData(Player player)
        {
            if (!player.HasData(GameData))
                player.SetData(GameData, new Data());
            return player.GetData<Data>(GameData); 
        }
    }
}