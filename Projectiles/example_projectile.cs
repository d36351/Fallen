using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.CodeAnalysis.CSharp.Syntax;
namespace fallen.Projectiles
{
    public class example_projectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.timeLeft = 200; 
            Projectile.Size = new(100, 100);
            Projectile.aiStyle = -1; 
            AIType = -1; 
            Projectile.friendly = true;
    
            Projectile.hostile = false; 
            Projectile.hide = false; 
            Projectile.ownerHitCheck = false; 
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = false;
        }
        public override void AI()
        {
            const float l = 200.0f;
            const float r = 50.0f;
            float a = 0f,b=0f,f_s=0f; 
            var rand = new Random();
            if (Projectile.ai[0] == 0f)
            {
                Projectile.rotation = Projectile.velocity.ToRotation();
                a = rand.Next(0, 7);   
                f_s = r * r + l * l - 2 * r * l * (float)Math.Cos(a);
                b = (float)Math.Acos(-(r * r + f_s - l * l) / (2 * r * Math.Sqrt(f_s)));
                if (a > 3) b = -b;
                Projectile.ai[1] = a;
                Projectile.ai[2] = b;              
            }
            else
            {         
                a = Projectile.ai[1];
                b=Projectile.ai[2];
            }
            var n = Projectile.rotation;
            Projectile.ai[0] += 0.1f;
            if (Projectile.ai[0] <= 3.0f)
            {
                Projectile.velocity = (- a).ToRotationVector2().RotatedBy(Projectile.rotation) * 5;
            }
            
            else if(Projectile.ai[0] > 3.0f && Projectile.ai[0] <=6.0f) {
                Projectile.velocity *= 0;
            }
            else
            {
                Projectile.velocity = (-a + b).ToRotationVector2().RotatedBy(Projectile.rotation) * 12;
            }
        }
    }
}












