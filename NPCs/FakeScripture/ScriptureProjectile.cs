using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace fallen.NPCs.FakeScripture
{
    public class ScriptureProjectile : ModNPC
    {
        public override void SetDefaults()
        {
            NPC.width = 160;
            NPC.height = 240;
            NPC.damage = 0;
            NPC.defense = 0;
            NPC.lifeMax = 10000;
            NPC.HitSound = SoundID.NPCHit2;
            NPC.DeathSound = SoundID.NPCDeath2;
            NPC.value = 10000f;
            NPC.knockBackResist = 0f;
            NPC.boss = false;
            NPC.scale = 1f;
       
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.netAlways = true;

            NPC.aiStyle = -1;
        }

        Vector2 Phase2Dir;
        public override void AI()

        {
 
            var rand = new Random();
            
            if (NPC.ai[0] == 0f)
            {



                NPC.ai[2] = rand.Next(0,3 );
                
      
            }
            else
            {
                NPC.velocity = (NPC.ai[1]).ToRotationVector2().RotatedBy(NPC.rotation) *(1/ (float)(NPC.ai[0]+20)*20);
                
            }
            //Dust.NewDustPerfect(NPC.Center, DustID.Firefly);
            if (NPC.ai[3] == 1)
            {

                if (NPC.ai[0] < 80f)
                {
                    Vector2 playerCenter = NPC.Center;
                    int idx = Player.FindClosest(NPC.Center, 1, 1);
                    if (idx >= 0 && Main.player[idx].active)
                    {
                        playerCenter = Main.player[idx].Center;
                    }
                    if (Vector2.Distance(NPC.Center, playerCenter) >= 500)
                    {
                        NPC.velocity = Vector2.Normalize(playerCenter - NPC.Center) * 10f;
                    }
                    else
                    {
                        NPC.velocity *= 0;
                    }
                    NPC.rotation = (playerCenter - NPC.Center).ToRotation();
                }
                if (NPC.ai[0] >= 80f) NPC.velocity *= 0;
                if (NPC.ai[0] == 100f)
                {
                    NPC.velocity *= 0;
                    int s = Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, NPC.rotation.ToRotationVector2(), ModContent.ProjectileType<ScriptureChildProjectile1>(), 20, 0f, Main.myPlayer);
                    Main.projectile[s].Center = NPC.Center;
                }
                if (NPC.ai[0] > 200f)
                {
                    NPC.active = false;
                }
            }
            else if (NPC.ai[3] == 2) {
                Player player;
                Vector2 playerCenter = NPC.Center;
                int idx = Player.FindClosest(NPC.Center, 1, 1);
                if (idx >= 0 && Main.player[idx].active)
                {
                    playerCenter = Main.player[idx].Center;
                    player = Main.player[idx];
                }
                else
                {
                    player = null;
                }
               Phase2Dir= player.Center +player.velocity*70;
                
                if (NPC.ai[0] < 90f)
                {

                    if (Vector2.Distance(NPC.Center, playerCenter) >= 300)
                    {
                        NPC.velocity = Vector2.Normalize(Phase2Dir - NPC.Center) * 30f;
                    }
                    else
                    {
                        NPC.velocity *= 0;
                    }
                    //NPC.rotation = (Phase2Dir - NPC.Center).ToRotation();
                    NPC.rotation = (Phase2Dir - NPC.Center).ToRotation();
                }
          
                if (NPC.ai[0] == 100f)
                {
                    NPC.velocity *= 0;
                    int s = Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, NPC.rotation.ToRotationVector2(), ModContent.ProjectileType<ScriptureChildProjectile1>(), 20, 0f, Main.myPlayer);
                    Main.projectile[s].Center = NPC.Center;
                }
                if (NPC.ai[0] >= 200f)
                {
                    NPC.active = false;
                }
            
            }
            NPC.ai[0]++;


        }
        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
            return false;
        }
        public override bool? CanBeHitByItem(Player player, Item item)
        {
            return false;
        }

        public override bool? CanBeHitByProjectile(Projectile projectile)
        {
            return false;
        }
    }
}