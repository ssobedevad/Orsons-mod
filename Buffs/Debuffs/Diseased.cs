using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace OrsonsMod.Buffs.Debuffs
{
    public class Diseased : ModBuff
    {




        public override void SetDefaults()
        {
            DisplayName.SetDefault("Diseased");
            Description.SetDefault("Reduced damage, speed and unable to use healing potions");
            Main.debuff[Type] = true;
            longerExpertDebuff = true;



        }
       
        public override void Update(Player player, ref int buffIndex)
        {
            player.velocity *= 0.85f;
            player.allDamage *= 0.75f;
            player.potionDelay = player.buffTime[buffIndex];


            int Dustid = Dust.NewDust(new Vector2(player.position.X, player.position.Y + 2f), player.width + 1, player.height + 1, DustID.Marble, player.velocity.X * 0.2f, player.velocity.Y * 0.2f, 120, default(Color), 2f);
            Main.dust[Dustid].noGravity = true;




        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.velocity *= 0.85f;
            

            int Dustid = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 2f), npc.width + 1, npc.height + 1, DustID.Marble, npc.velocity.X * 0.2f, npc.velocity.Y * 0.2f, 120, default(Color), 2f);
            Main.dust[Dustid].noGravity = true;




        }





    }
}
