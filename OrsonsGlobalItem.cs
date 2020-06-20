
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod
{

    public class OrsonsGlobalItem : GlobalItem
    {
        public int grabbedBySlimeWhip = -1;
        public override bool InstancePerEntity => true;
        public override bool CloneNewInstances => true; 
        public override void Update(Item item, ref float gravity, ref float maxFallSpeed)
        {
            if(grabbedBySlimeWhip >= 0) 
            { 
                Vector2 diff = (Main.player[grabbedBySlimeWhip].Center - item.Center);
                float Mag = (float)Math.Sqrt(diff.X * diff.X + diff.Y * diff.Y);
                if(Mag < 18f) { grabbedBySlimeWhip = -1; }
                 Mag = 18f / Mag;
                item.position += diff * Mag;
                item.noGrabDelay = 0;
                

            }
        }
        
        public override void UpdateInventory(Item item, Player player)
        {
            grabbedBySlimeWhip = -1;
        }
    }
}
