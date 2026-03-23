
using fallen.Buff;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
namespace fallen.FallenItem.GrabBag
{
    public class example_grab_bag : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(gold: 1);
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
        }
        public override bool CanRightClick()
        {



            return true;
        }

        public override void RightClick(Player player)
        {
          
        }
        public override void ModifyItemLoot(ItemLoot itemLoot)
        {
            //给战利品池子添加：不受玩家幸运影响的有1/7概率掉落的猪鲨翅膀
            //这个方法有四个参数，物品id，掉率分母，也就是1/分母的掉率
            //最小掉落数量，默认1，最大掉落数量，默认1
            itemLoot.Add(ItemDropRule.NotScalingWithLuck(ItemID.FishronWings, 7));
            //添加：受玩家幸运影响的，1 / 2 = 50%概率掉落（这个概率将被幸运修正提高）的叶绿矿，30~60个
            itemLoot.Add(ItemDropRule.Common(ItemID.ChlorophyteOre, 2, 30, 60));
            //添加：掉落基于世纪之花价值的钱币
            itemLoot.Add(ItemDropRule.CoinsBasedOnNPCValue(NPCID.Plantera));
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
