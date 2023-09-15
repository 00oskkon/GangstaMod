using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace GangstaMod.Content.Items.Accessories
{
    public class ReallyCoolIronsight : ModItem
    {
        public override void SetStaticDefaults()
        {
            // I keep spelling it "irosight" for some reason
            DisplayName.SetDefault("Really Cool Ironsight");
            Tooltip.SetDefault("a COOL ironsight\n" + "11% increased ranged damage");
        }

        public override void SetDefaults()
        {
            Item.width = 36;
            Item.height = 36;
            //Item.value = Item.sellPrice(gold: 100);
            Item.rare = ItemRarityID.Pink;
            Item.accessory = true;
        }

        // Add accessory buffs
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            // Increase ranged damage by 11%
            player.GetDamage(DamageClass.Ranged) += 0.11f;
        }

        // Add the recipe (obvio)(the platform reference)
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ItemID.IceBlock, 5);
            recipe.AddRecipeGroup("IronBar", 5);
            recipe.AddIngredient(ItemID.RifleScope);
            recipe.AddTile(TileID.MythrilAnvil);

            recipe.Register();
        }
    }
}
