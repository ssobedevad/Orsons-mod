using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Enums;
using Terraria.ModLoader;

namespace OrsonsMod.Projectiles.Friendly.Magic
{
    // The following laser shows a channeled ability, after charging up the laser will be fired
    // Using custom drawing, dust effects, and custom collision checks for tiles
    public class NeonFlash : LaserClass
    {
        public override void SafeSetDefaults()
        {
            SpecialEffectType = 1;
            bodyDimensions = new Vector2(22,4);
            headDimensions = new Vector2(22, 6);
            headDimensions = new Vector2(22, 14);
            MaxDist = 500;
        }
    }
}