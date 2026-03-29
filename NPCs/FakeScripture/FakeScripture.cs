//using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Xna.Framework;
using System;

//using System.Numerics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
namespace fallen.NPCs.FakeScripture
{
    public class FakeScripture : ModNPC
    {
        public override void SetDefaults()
        {
            NPC.width = 160;
            NPC.height = 240;
            NPC.damage = 50;
            NPC.scale = 2.0f;
            NPC.defense = 20;
            NPC.lifeMax = 100000;
            NPC.HitSound = SoundID.NPCHit2;
            NPC.DeathSound = SoundID.NPCDeath2;
            NPC.value = 10000f;
            NPC.knockBackResist = 0f;
            NPC.boss = true;

            NPC.townNPC = false;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.netAlways = true;

            NPC.aiStyle = -1;
        }
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 6;
        }

        int scripture_projectile_conter = 0;
        int stright_down_projectile_conter = 0;
        
        int phase = 1;
        public override void AI() 
        {
            Vector2 vectorCenter = NPC.Center;
            if (NPC.life / (double)NPC.lifeMax > 0.5f)
            {
                phase = 1;
            }
            else if (NPC.life / (double)NPC.lifeMax <= 0.5f )
            {
                phase = 2;
            }
            if (NPC.target < 0 || NPC.target == Main.maxPlayers || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
                NPC.TargetClosest();
            Player player = Main.player[NPC.target];
            float high=400;
            Vector2 dir  = Vector2.Normalize(new Vector2(player.Center.X, player.Center.Y - high) - NPC.Center);
            float dis =Vector2.Distance(player.Center, NPC.Center);
            double Speed = 7.0f*((phase ==2)?1.5:1);
            if ((dis>100.0f))
            {
                if (player.Center.Y - NPC.Center.Y <= high-20 || player.Center.Y - NPC.Center.Y >= high+20)
                {
                    NPC.velocity = dir * (float)Speed;
                    dir = Vector2.Normalize(new Vector2(player.Center.X, player.Center.Y - 400) - NPC.Center);
                }
                else
                {
                    NPC.velocity = new Vector2(dir.X,0) * (float)Speed;
                }
          
                NPC.rotation = NPC.velocity.X * 0.07f;
                float playerLocation = NPC.Center.X - player.Center.X;
                NPC.direction = playerLocation < 0f ? 1 : -1;
                if (Math.Abs(player.Center.X - NPC.Center.X) >= 20) NPC.spriteDirection = NPC.direction;
               
            }
            if (!player.active || player.dead || Vector2.Distance(player.Center, vectorCenter) > 6400f)
            {
                NPC.TargetClosest(false);
                player = Main.player[NPC.target];
                if (!player.active || player.dead || Vector2.Distance(player.Center, vectorCenter) > 6400f)
                {
                    if (NPC.velocity.Y > 3f)
                        NPC.velocity.Y = 3f;
                    NPC.velocity.Y -= 0.15f;
                    if (NPC.velocity.Y < -12f)
                        NPC.velocity.Y = -12f;
                    NPC.active = false;
                    NPC.netUpdate = true;
                    return;
                }
            }
            else if (NPC.timeLeft < 1800)
                NPC.timeLeft = 1800; 
            stright_down_projectile_conter--;
            scripture_projectile_conter--;

            if (stright_down_projectile_conter <= 0&&phase==1)
            {
                var rand = new Random();
                float theta = ((float)rand.Next(-30,30 )) * 2 * (float)Math.PI / 360;
                Projectile.NewProjectile(NPC.GetSource_FromAI(), new Vector2(NPC.Center.X, NPC.Center.Y+50), new Vector2((float)Math.Sin(theta), (float)Math.Cos(theta)), ModContent.ProjectileType<FakeScriptureProjectile1>(), 20, 0f, Main.myPlayer);
                stright_down_projectile_conter = 100;
            }else if (stright_down_projectile_conter <= 0 && phase == 2)
            {
                var rand = new Random();
                float theta = ((float)rand.Next(-90, 90))*2*(float)Math.PI/360;
                Projectile.NewProjectile(NPC.GetSource_FromAI(), new Vector2(NPC.Center.X, NPC.Center.Y + 50), new Vector2((float)Math.Sin(theta), (float)Math.Cos(theta)), ModContent.ProjectileType<FakeScriptureProjectile1>(), 20, 0f, Main.myPlayer);
                stright_down_projectile_conter = 30;
            }

            if (scripture_projectile_conter <= 0)
            {
                var rand = new Random();
                float theta = ((float)rand.Next(0, 360));
                Vector2 tar = new Vector2(player.Center.X + (float)(400 * Math.Sin(theta)), player.Center.Y + (float)(400 * Math.Cos(theta)));
                int n=NPC.NewNPC(NPC.GetSource_FromAI(),(int)tar.X,(int)tar.Y, ModContent.NPCType<ScriptureProjectile>());
                Main.npc[n].ai[3]=phase;
            
                scripture_projectile_conter = 120;
            }
        }
public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter += NPC.IsABestiaryIconDummy ? 1.65 : 1.0;
            if (NPC.ai[0] == 4f)
            {
                if (NPC.frameCounter > 72.0) //12
                {
                    NPC.frameCounter = 0.0;
                }
            }
            else
            {
                int frameY = 196;
                if (NPC.frameCounter > 72.0)
                {
                    NPC.frameCounter = 0.0;
                }
                NPC.frame.Y = frameY * (int)(NPC.frameCounter / 12.0); //1 to 6
                if (NPC.frame.Y >= frameHeight * 6)
                {
                    NPC.frame.Y = 0;
                }
            }
        }
    }
}

