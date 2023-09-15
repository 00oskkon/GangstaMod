using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace GangstaMod.Content.Items.Placeable
{
    public class UnrealiumBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
            ItemID.Sets.SortingPriorityMaterials[Item.type] = 59;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 99;
            Item.value = 3000;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.UnrealiumBar>();
            Item.placeStyle = 0;
            Item.rare = ItemRarityID.Cyan;
        }

            public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<UnrealiumOre>(1)
                .AddIngredient(ItemID.FragmentVortex)
                .AddIngredient(ItemID.FragmentNebula)
                .AddIngredient(ItemID.FragmentSolar)
                .AddIngredient(ItemID.FragmentStardust)
                .AddTile(TileID.AdamantiteForge)
                .Register();
		}
    }
}
