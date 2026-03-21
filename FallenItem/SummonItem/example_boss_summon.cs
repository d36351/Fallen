using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace fallen.FallenItem.SummonItem
{
    public class example_boss_summon : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 18;
            Item.useAnimation = 10;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = false;
            
        }
        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 13;
        }
        public override bool ConsumeItem(Player player)
        {
        
            return !NPC.AnyNPCs(NPCID.EyeofCthulhu) && !Main.dayTime;
        }

        public override bool? UseItem(Player player)
        {
            NPC.SpawnBoss((int)player.Center.X, (int)player.Center.Y, NPCID.EyeofCthulhu, player.whoAmI);
            return true;
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
