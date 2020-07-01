using Microsoft.Xna.Framework;
using OrsonsMod.Buffs.Buffs;
using OrsonsMod.Buffs.Debuffs;
using System;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod
{
    public class OrsonsTile : GlobalTile
    {
        public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if(type == TileID.Plants || type == TileID.Plants2 || type == TileID.JunglePlants || type == TileID.JunglePlants2)

            { Player ClosestPlayer = Main.player[Player.FindClosest(new Vector2(i * 16, j * 16), 1, 1)];
                if(ClosestPlayer.GetModPlayer<OrsonsPlayer>().SeedCollect)
                { Item.NewItem(new Vector2(i * 16, j * 16),ItemID.Seed); }
            
            }
        }
    }

}