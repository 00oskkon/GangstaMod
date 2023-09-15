using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace GangstaMod.Content.Items.Ammo
{
    public class PiercingAmmo : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Pierces five enemies");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.width = 14;
            Item.height = 14;

            Item.damage = 12;
            Item.DamageType = DamageClass.Ranged;

            Item.maxStack = 9999;
            Item.consumable = true;
            Item.knockBack = 2f;
            //Item.value = Item.sellPrice(0, 0, 1, 0);
            Item.rare = ItemRarityID.Blue;
            Item.shoot = ModContent.ProjectileType<Projectiles.PiercingRound>();

            Item.shootSpeed = 16f;
            Item.ammo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            CreateRecipe(70)
                .AddRecipeGroup("IronBar")
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
