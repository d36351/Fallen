using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace fallen.FallenItem.Ammor.example_ammor
{
    [AutoloadEquip(EquipType.Body)]
    public class example_ammorBreastplate:ModItem
    {
        public static int MaxManaBoost = 200;
        public static float AmmoReduction = 0.7f;
        public static float DamageBoost = 0.15f;
        public static int CritBoost = 15; // NOTE: Tooltip shares this number with damage % as they're equal
        public static float MeleeSpeedBoost = 0.25f;
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.defense = 1000;
       

        }
        public override void SetStaticDefaults()
        {
            // 旅途模式研究需求配置
             // 设为0禁用研究功能
        }
        public override void UpdateEquip(Player player)
        {
  
            player.statManaMax2 += MaxManaBoost;
            player.GetDamage<GenericDamageClass>() += DamageBoost;
            player.GetCritChance<GenericDamageClass>() += CritBoost;
            player.GetAttackSpeed<MeleeDamageClass>() += MeleeSpeedBoost;
        }
        public override void AddRecipes()
        {
                Recipe rescipe = CreateRecipe();
            
                rescipe.AddIngredient(ItemID.DirtBlock, 10);
                rescipe.AddTile(TileID.WorkBenches);
                rescipe.Register();

        }
    }
}
