using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using System;

namespace OrsonsMod.NPCs
{
    public class IchorEssence : ModNPC
    {
        
        
        public override void SetDefaults()
        {

            npc.width = 28;               //this is where you put the npc sprite width.     important
            npc.height = 28;              //this is where you put the npc sprite height.   important
            npc.damage = 50;
            npc.defense = 15;
            npc.value = 500;
            npc.lifeMax = 250;
            npc.aiStyle = -1;
            npc.knockBackResist = 0.2f;
            npc.HitSound = SoundID.NPCHit13;
            npc.behindTiles = true;
            npc.noTileCollide = true;
            for (int k = 0; k < npc.buffImmune.Length; k++)
            {
                npc.buffImmune[k] = true;
            }
            
            npc.noGravity = true;
            banner = npc.type;
            bannerItem = mod.ItemType("IchorEssenceBanner");

        }
        public override void AI()
        {
            npc.TargetClosest(true);
            Vector2 ThisCenter = new Vector2(npc.Center.X, npc.Center.Y);
            float Xdiff = Main.player[npc.target].Center.X - ThisCenter.X;
            float YDiff = Main.player[npc.target].Center.Y - ThisCenter.Y;
            float Magnitude = (float)Math.Sqrt((double)(Xdiff * Xdiff + YDiff * YDiff));
            float Speed = 12f;
            Magnitude = Speed / Magnitude;
            Xdiff *= Magnitude;
            YDiff *= Magnitude;
            npc.velocity.X = (npc.velocity.X * 100f + Xdiff) / 101f;
            npc.velocity.Y = (npc.velocity.Y * 100f + YDiff) / 101f;
            npc.rotation = (float)Math.Atan2((double)YDiff, (double)Xdiff) - 1.57f;
            int DustID = Dust.NewDust(npc.position, npc.width, npc.height, 55, 0f, 0f, 0, default(Color), 1f);
            Main.dust[DustID].velocity *= 0.1f;
            Main.dust[DustID].scale = 1.3f;
            Main.dust[DustID].noGravity = true;
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.Ichor, 600);
            
        }
        public override void NPCLoot()
        {
            Item.NewItem(npc.getRect(), ItemID.Ichor, Main.rand.Next(2, 4));
        }
        


    }
}
