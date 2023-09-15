using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace GangstaMod.Content.Items.Ammo
{
    public class UnrealAmmo : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Seeks out enemies to deal unreal damage");
            //CreativeItemSacraficesCatalog.Instance.SacraficeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.width = 7;
            Item.height = 7;

            Item.damage = 36;
            Item.DamageType = DamageClass.Ranged;

            Item.maxStack = 9999;
            Item.consumable = true;
            Item.knockBack = 2f;
            //Item.value = Item.sellPrice(0, 0, 1, 0);
            Item.rare = ItemRarityID.Cyan;
            Item.shoot = ModContent.ProjectileType<Projectiles.UnrealRound>();

            Item.shootSpeed = 16f;
            Item.ammo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
        CreateRecipe(150)
            .AddIngredient(ItemID.MusketBall, 150)
            .AddIngredient(ModContent.ItemType<Items.Placeable.UnrealiumBar>())
            .AddTile(TileID.AdamantiteForge)
            .Register();
        }
    }
}
