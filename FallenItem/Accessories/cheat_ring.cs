using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Terraria.Audio;
using Terraria.DataStructures;

using Terraria.Localization;

using static Terraria.ModLoader.ModContent;
namespace fallen.FallenItem.Accessories
{
    public class cheat_ring : ModItem

    {
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(10, 100, 10, 30);
        public override void SetStaticDefaults()
        {
            // 旅途模式研究需求配置
            Item.ResearchUnlockCount = 1; // 设为0禁用研究功能
        }
        public override void SetDefaults()
        {
            Item.accessory = true; // 这是饰品
            Item.width = 24; // 宽24像素
            Item.height = 24; // 高24像素
            Item.maxStack = 1; // 最大堆叠数量
            Item.DefaultToAccessory();
            Item.rare = ItemRarityID.Green; // 这是绿色的稀有度
            Item.value = Item.sellPrice(0, 10); //  10 金币

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.jumpSpeedBoost += 5.6f;

            player.GetDamage(DamageClass.Generic) += 0.1f; // 提升玩家伤害10%
            // statModifier.Additive 获得加算数值
            // statModifier.Multiplicativ 获得乘算数值

            player.statLifeMax2 += 100; // 增加玩家最大生命值100
            player.statDefense.AdditiveBonus += 0.1f; // 提升玩家护甲10%
            // AdditiveBonus专门处理加算的
            player.accRunSpeed *= 10.0f; // 增加玩家最大速度30%
                                         // 不用加算的原因是：
                                         // 1+0.3 = 1.3,所以你直接乘以1.3就行了
            player.iceSkate = true;
            player.waterWalk = true;
            player.fireWalk = true;
            player.lavaImmune = true;
            player.buffImmune[BuffID.OnFire] = true;
            player.noFallDmg = true;
        }

        public override void AddRecipes()
        {
            Recipe cheat_ringRecipe = CreateRecipe();
            cheat_ringRecipe.AddIngredient(ItemID.DirtBlock, 10);
            cheat_ringRecipe.AddTile(TileID.WorkBenches);
            cheat_ringRecipe.Register();

        }
        public void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {


        }
    }
} 

