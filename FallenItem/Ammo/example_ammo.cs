using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using fallen.Buff;
namespace fallen.FallenItem.Ammo
{
    public class example_ammo: ModItem
    {
        public override void SetDefaults()
        {
            Item.ammo = AmmoID.Arrow;//将物品标记为弹药且介绍中会出现"弹药"
            Item.shoot = ProjectileID.FireArrow;
            Item.maxStack = 9999;
        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

        }



    }
}
