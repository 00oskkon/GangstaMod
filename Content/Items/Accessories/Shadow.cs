using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace GangstaMod.Content.Items.Accessories
{
    public class Shadow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Void");
            Tooltip.SetDefault("this is op\n" + "+177 max minions\n" + "+10000% summon damage");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            //Item.value = Item.sellPrice(gold: 100);
            Item.rare = 11;
            Item.accessory = true;
        }

        // public override void ModifyTooltips(List<TooltipLine> tooltips)
        // {
        //     //rarity 12 (Turquoise) = new Color(0, 255, 200)
        //     //rarity 13 (Pure Green) = new Color(0, 255, 0)
        //     //rarity 14 (Dark Blue) = new Color(43, 96, 222)
        //     //rarity 15 (Violet) = new Color(108, 45, 199)
        //     //rarity 16 (Hot Pink/Developer) = new Color(255, 0, 255)
        //     //rarity rainbow (no expert tag on item) = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB)
        //     //rarity rare variant = new Color(255, 140, 0)
        //     //rarity dedicated(patron items) = new Color(139, 0, 0)
        //     //look at https://calamitymod.gamepedia.com/Rarity to know where to use the colors
        //     foreach (TooltipLine tooltipLine in tooltips)
        //     {
        //         if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
        //         {
        //             tooltipLine.overrideColor = new Color(108, 45, 199); //change the color accordingly to above
        //         }
        //     }
        // }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.maxMinions += 177;
            player.GetDamage(DamageClass.Summon) += 100f;
        }

        public override void AddRecipes()
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");

            Recipe recipe = CreateRecipe();

            if (calamityMod != null && calamityMod.TryFind<ModItem>("ShadowspecBar", out ModItem ShadowspecBar) && calamityMod.TryFind<ModItem>("CosmiliteBar", out ModItem CosmiliteBar) && calamityMod.TryFind<ModTile>("DraedonsForge", out ModTile DraedonsForge))
            {
                recipe.AddIngredient(ShadowspecBar.Type, 15);
                recipe.AddIngredient(CosmiliteBar.Type, 15);
                recipe.AddTile(DraedonsForge.Type);
            }
            recipe.Register();

            // recipe.AddIngredient(calamityMod.ItemType("ShadowspecBar"), 15);
            // recipe.AddIngredient(calamityMod.ItemType("CosmiliteBar"), 15);
            // recipe.AddTile(calamityMod.TileType("DraedonsForge"));
            // recipe.SetResult(this);
            // recipe.AddRecipe();
        }
    }
}
