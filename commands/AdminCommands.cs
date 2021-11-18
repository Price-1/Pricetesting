using System;
using System.Collections.Generic;
using GTANetworkAPI;

namespace Pricetesting{
    public class AdminCommands:Script
    {
        [Command("spawnvehicle", Alias = "sv", GreedyArg = true)]
        public void ACMD_SpawnVehicle(Player player, string vname)
        {
            if (Data.ReturnData(player).adminRank == AData.AdminRank.None)
            {  
             player.SendChatMessage("~r~Error: This command is restricted for Admins only!");
             return;
            }
            VehicleHash hash = NAPI.Util.VehicleNameToModel(vname);
            if (hash == 0)
            {
                player.SendChatMessage("~r~Invalid Vehicle Name!");
            }

            Random random = new Random();
            Vehicle vehicle = NAPI.Vehicle.CreateVehicle(hash, player.Position, player.Rotation.Z, random.Next(100), random.Next(100));
            player.SendChatMessage("~o~Vehicle successfully created!");
            NAPI.Util.ConsoleOutput($"{player.Name} has created a {vname} as a {player.GetData<Data>(Data.GameData).adminRank} Admin!");


        }

        [Command("vehiclelivery", Alias = "vl", GreedyArg = false)]
        public void ACMD_SetLivery(Player player, int livery)
        {
            if (Data.ReturnData(player).adminRank == AData.AdminRank.None)
            {
                player.SendChatMessage("~r~Error: This command is restricted for Admins only!");
                return;
            }

            Vehicle vehicle = NAPI.Player.GetPlayerVehicle(player);
            NAPI.Vehicle.SetVehicleLivery(vehicle, livery);
            player.SendChatMessage("~o~Vhicle livery set successfully!");
            NAPI.Util.ConsoleOutput($"{player.Name} has set {vehicle}'s livery to ID {livery} as a {player.GetData<Data>(Data.GameData).adminRank} Admin!");

        }

        


        [Command("setadmin", Alias = "sa", GreedyArg = false)]
        public void ACMD_SetAdmin(Player player, AData.AdminRank rank)
        {
            Data.ReturnData(player).adminRank = rank;
            player.SendChatMessage($"You've set your rank to{Data.ReturnData(player).adminRank}");

        }
    }
}