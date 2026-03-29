using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace fallen.NPCs.FakeScripture
{
    public class ScriptureChildProjectile1 : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.timeLeft = 100;
            Projectile.Size = new(600, 600);
            // Adjust this value to change how large the sprite is drawn (1f = original texture size)
            Projectile.scale = 1.5f; // example: half-size
            Projectile.aiStyle = -1;
            AIType = -1;
            Projectile.friendly = false;
            Projectile.hostile = true;
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
                Projectile.ai[1] = Projectile.velocity.ToRotation();
                Projectile.velocity = Vector2.Zero;
            }

            Projectile.rotation = Projectile.ai[1];
            Projectile.velocity =  Vector2.Zero;// new Vector2((float)Math.Sin(Projectile.rotation), (float)Math.Cos(Projectile.rotation));
 
            Projectile.ai[0]++;
            //Dust.NewDustPerfect(Projectile.Center, DustID.FireworkFountain_Red);
            //Dust.NewDustPerfect(Projectile.position, DustID.FireworkFountain_Red);
            if (Projectile.frameCounter++ > 4)
            {
                Projectile.frameCounter = 0;
                Projectile.frame++;

                if (Projectile.frame >= 4)
                    Projectile.frame = 3; // 或停在最後一幀
            }
        }
        public override bool CanHitPlayer(Player target) => Projectile.Opacity == 1f;
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = Terraria.GameContent.TextureAssets.Projectile[Type].Value;

            int frameHeight = texture.Height / Main.projFrames[Type];
            Rectangle frame = new Rectangle(0, frameHeight * Projectile.frame, texture.Width, frameHeight);

            Vector2 origin = frame.Size() / 2f; // ⭐ 強制中心

            Main.EntitySpriteDraw(
                texture,
                Projectile.Center - Main.screenPosition,
                frame,
                lightColor,
                Projectile.rotation,
                origin,
                Projectile.scale,
                SpriteEffects.None,
                0
            );

            return false;
        }
    }
}