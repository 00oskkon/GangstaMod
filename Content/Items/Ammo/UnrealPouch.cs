using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace GangstaMod.Content.Items.Ammo
{
    public class UnrealPouch : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endless Unreal Pouch");
            Tooltip.SetDefault("Seeks out enemies to deal unreal damage");
            //CreativeItemSacraficesCatalog.Instance.SacraficeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ModContent.ItemType<Items.Ammo.UnrealAmmo>());
            Item.consumable = false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<Items.Ammo.UnrealAmmo>(), 3996)
                .AddTile(TileID.CrystalBall)
                .Register();
        }
    }
}
