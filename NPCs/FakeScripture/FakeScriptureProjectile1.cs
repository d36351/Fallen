using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

using System.Text;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.CodeAnalysis.CSharp.Syntax;
namespace fallen.NPCs.FakeScripture
{
    public class FakeScriptureProjectile1 : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.timeLeft = 200;
            Projectile.Size = new(50, 50);
            Projectile.aiStyle = -1;
            AIType = -1;
            Projectile.friendly = false;
            Projectile.hostile = false;
            Projectile.hide = false;
            Projectile.ownerHitCheck = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = false;
        }
        public override void SetStaticDefaults()
        {
            Main.projFrames[Type] = 4;
            ProjectileID.Sets.TrailCacheLength[Type] = 4;
            ProjectileID.Sets.TrailingMode[Type] = 0;
            Main.projFrames[Type] = 4;
            ProjectileID.Sets.TrailCacheLength[Type] = 4;
            ProjectileID.Sets.TrailingMode[Type] = 0;
        }
        public override void AI()
        {
 
            var rand = new Random();
            
            if (Projectile.ai[0] == 0f)
            {
                Projectile.ai[1] = (float)rand.Next(-30, 30) / 60;
                Projectile.rotation = Projectile.velocity.ToRotation();

                var n = Projectile.rotation;
                Projectile.velocity *=5;
            }
            else
            {
                //Projectile.velocity = (Projectile.rotation).ToRotationVector2().RotatedBy(Projectile.rotation) * 5;
            }
            Projectile.ai[0]++;
            if (Projectile.frameCounter++ > 8)
            {
                Projectile.frameCounter = 0;
                Projectile.frame++;

                if (Projectile.frame >= 4)
                    Projectile.frame = 0; // 或停在最後一幀
            }

        }
        }
    }




;