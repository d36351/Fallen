using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;


namespace fallen.Buff
{
    public class example_buff:ModBuff {
        public override void SetStaticDefaults()
        {


            //这个属性决定BUFF在游戏退出后是否保留, true为不保留
            Main.buffNoSave[Type] = false;

            //用来判断这个BUFF是不是一个DEBUFF,
            //如果为true, 则会得到TR里对DEBUFF的限制, 如无法右键取消
            Main.debuff[Type] = true;

            //决定这个BUFF能不能被护士取消, true为不可以
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;

            //决定这个BUFF是不是照明宠物BUFF
            Main.lightPet[Type] = false;//为false则不是照明宠物BUFF

            //决定这个BUFF会不会显示持续时间, false为显示, 用于宠物和召唤物BUFF
            Main.buffNoTimeDisplay[Type] = false;

            //决定这个BUFF在专家模式会不会延长, true为会
            //如果为true, 专家翻倍, 大师为3倍
            BuffID.Sets.LongerExpertDebuff[Type] = false;

            //如果这个属性为true, pvp时就能给别的玩家上这个BUFF
            Main.pvpBuff[Type] = true;

            //死亡后是否清除BUFF, true为不清除
            Main.persistentBuff[Type] = false;

            //决定这个BUFF是不是宠物BUFF, 用来判定
            //比如在清除BUFF时不会清除它
        }

        public override void Update(Player player, ref int buffIndex)
        {
            //每帧有33%的概率让玩家散发诅咒焰的粒子
            if (Main.rand.NextBool(3))
            {
                Dust d = Dust.NewDustDirect(player.position, player.width, player.height, DustID.GreenFairy);
                d.velocity *= 0.5f;
            }

            //把玩家的所有生命回复清除
            if (player.lifeRegen > 0)
            {
                player.lifeRegen = 0;
            }
            player.lifeRegenTime = 0;

            //让玩家的减血速率随着时间而减少
            player.lifeRegen = player.buffTime[buffIndex];
            //如果这是一个一分钟的BUFF, 那么获得BUFF的第一帧你的生命回复速率就是-3600了
            //这意味着你下一帧就似了💀
        }
        //这是对NPC的
        public override void Update(NPC npc, ref int buffIndex)
        {


            //NPC也有lifeRegen, 要学会举一反三😡
        }

    }
   
}
