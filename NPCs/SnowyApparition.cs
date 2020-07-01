using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;

namespace OrsonsMod.NPCs
{
    public class SnowyApparition : ModNPC
    {

        public override void SetDefaults()
        {

            npc.width = 26;
            npc.height = 48;
            npc.damage = 27;
            npc.defense = 7;
            npc.value = 70;
            npc.lifeMax = 70;
            npc.aiStyle = 22;
            npc.knockBackResist = 0.5f;
            npc.HitSound = SoundID.NPCHit6;
            npc.DeathSound = SoundID.NPCDeath5;

            npc.noGravity = true;
            npc.noTileCollide = true;
            
            banner = npc.type;
            bannerItem = mod.ItemType("SnowyApparitionBanner");

        }
        public override void AI()
        {
            npc.spriteDirection = npc.direction;
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if(Main.expertMode || Main.rand.NextBool()) { target.AddBuff(BuffID.Slow, 180); }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

            return spawnInfo.player.ZoneSnow ? 0.4f : 0f;



        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {


            for (int i = 4; i >= 0; i--)
            {
                Vector2 oldV = npc.velocity * i;
                Vector2 vect = new Vector2(npc.position.X + npc.width / 2 - Main.screenPosition.X - oldV.X, npc.position.Y + npc.height / 2 - Main.screenPosition.Y - oldV.Y);
                Rectangle rect = npc.frame;

                Color alpha9 = npc.GetAlpha(Color.White);
                alpha9.R = (byte)(alpha9.R * (10 - (2 * i)) / 20);
                alpha9.G = (byte)(alpha9.G * (10 - (2 * i)) / 20);
                alpha9.B = (byte)(alpha9.B * (10 - (2 * i)) / 20);
                alpha9.A = (byte)(alpha9.A * (10 - (2 * i)) / 20);
                spriteBatch.Draw(
                    mod.GetTexture(Texture),
                     vect, rect, alpha9, npc.rotation, new Vector2(npc.width / 2, npc.height / 2), 1f, SpriteEffects.None, 0f);



                //SpriteBatch.Draw(mod.GetTexture("NPCs/Boss/Triplet"),
                //new Vector2(npc.oldPos[i].X - Main.screenPosition.X + (float)(npc.width / 2) - (float)110 / 2f + npc.Center.X , npc.oldPos[i].Y - Main.screenPosition.Y + (float)npc.height - (float)162 / (float)Main.npcFrameCount[npc.type] + 4f + npc.Center.Y + 30f),
                //npc.frame, alpha9, npc.rotation, npc.Center, 1f, SpriteEffects.None, 0f);
            }
            Vector2 vect2 = new Vector2(npc.position.X + npc.width / 2 - Main.screenPosition.X, npc.position.Y + npc.height / 2 - Main.screenPosition.Y);
            Rectangle rect2 = npc.frame;
            spriteBatch.Draw(
                    mod.GetTexture(Texture),
                     vect2, rect2, Color.White, npc.rotation, new Vector2(npc.width / 2, npc.height / 2), 1f, SpriteEffects.None, 0f);
            return false;

        }

    }
}