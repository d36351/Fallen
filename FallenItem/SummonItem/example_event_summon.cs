using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using fallen.Buff;
using Steamworks;

namespace fallen.FallenItem.SummonItem
{
    public class example_event_summon : ModItem
    {
        public override void SetDefaults()
        {

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
