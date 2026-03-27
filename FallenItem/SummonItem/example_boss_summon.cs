using fallen.NPCs.FakeScripture;
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
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 19;
        }

        public override bool CanUseItem(Player player)
        {

            bool n = !Main.dayTime;
            return NPC.AnyNPCs(ModContent.NPCType<FakeScripture>()) ? false : true && !n;
        }

        public override bool? UseItem(Player player)
        {
            if (!CanUseItem(player))
                return false;

            NPC.SpawnBoss((int)player.Center.X+50, (int)player.Center.Y+50, ModContent.NPCType<FakeScripture>(), player.whoAmI);
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
