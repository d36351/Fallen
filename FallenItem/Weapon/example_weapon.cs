
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using fallen.Projectiles;

using Terraria.Localization;
namespace fallen.FallenItem.Weapon
{

    public class example_weapon : ModItem
    {
        public override void SetStaticDefaults()
        {
            // 旅途模式研究需求配置
            Item.ResearchUnlockCount = 1; // 设为0禁用研究功能
        }

        public override void SetDefaults()
        {
            // === 基础战斗属性 ===
            Item.damage = 15000;            // 基础伤害值
            Item.DamageType = DamageClass.Melee; // 伤害类型
            Item.crit = 90;              // 暴击率加成(%)
            Item.knockBack = 6;          // 击退力度

            // === 视觉与尺寸属性 ===
            Item.width = 400;             // 贴图宽度(像素)
            Item.height = 400;            // 贴图高度(像素)
            Item.rare = ItemRarityID.Blue; // 稀有度等级
            Item.value = Item.buyPrice(silver: 1); // 物品价值

            // === 使用行为参数 ===
            Item.useTime = 2;           // 使用间隔(帧)
            Item.useAnimation = 2;      // 动画时长(帧)
            Item.useStyle = ItemUseStyleID.Swing; // 使用动作类型
            Item.UseSound = SoundID.Item1; // 使用音效
            Item.autoReuse = true;       // 启用自动重复使用
            Item.useTurn = true;         // 使用时转向鼠标方向

            // === 弹药系统 ===
            Item.useAmmo = AmmoID.None;  // 消耗弹药类型
            Item.ammo = AmmoID.None;     // 自身作为弹药时的类型

            // === 其他功能参数 ===
            Item.noMelee = false;        // 禁用近战碰撞箱
            Item.noUseGraphic = false;   // 隐藏使用动画
            Item.accessory = false;      // 是否为饰品
            Item.consumable = false;     // 是否为消耗品
            Item.defense = 15000;            // 防御力加成
            Item.maxStack = 9999;           // 最大堆叠量

            // === 工具属性 ===
            Item.pick = 0;               // 镐力
            Item.axe = 0;                // 斧力
            Item.hammer = 0;             // 锤力

            // === 弹幕系统 ===
            Item.shoot = ModContent.ProjectileType<example_projectile>(); // 发射弹幕ID
            Item.shootSpeed = 10;        // 弹幕初速度
            Item.channel = false;        // 是否为蓄力武器
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