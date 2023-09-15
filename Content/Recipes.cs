using ExtraRecipes.Content;
using Terraria.ID;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace ExtraRecipes.Content
{
    public class Recipes : ModSystem
    {
        public override void AddRecipes()
        {
            // Get calamity mod
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            // Get thorium mod
            Mod thoriumMod = ModLoader.GetMod("ThoriumMod");
            // Get magic storage
            Mod magicStorage = ModLoader.GetMod("MagicStorage");

            // Trophy for Betsy
            Recipe recipe = Recipe.Create(ItemID.BossTrophyBetsy);
            recipe.AddIngredient(ItemID.BossBagBetsy);
            recipe.AddTile(TileID.Solidifier);
            recipe.Register();

            // Mana pots
            recipe = Recipe.Create(ItemID.LesserManaPotion, 50);
            recipe.AddIngredient(ItemID.ManaCrystal, 10);
            recipe.AddIngredient(ItemID.BottledWater, 50);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.Register();

            // Magic conch (konk)
            recipe = Recipe.Create(ItemID.MagicConch);
            recipe.AddIngredient(ItemID.SandBlock, 10);
            recipe.AddIngredient(ItemID.Coral, 10);
            recipe.AddIngredient(ItemID.Seashell, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

            // Boomstick
            recipe = Recipe.Create(ItemID.Boomstick);
            recipe.AddIngredient(ItemID.IllegalGunParts);
            recipe.AddIngredient(ItemID.Dynamite);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            // A safe for some reason
            recipe = Recipe.Create(ItemID.Safe);
            recipe.AddIngredient(ItemID.PiggyBank);
            recipe.AddRecipeGroup("IronBar", 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            // Snowball cannon because
            recipe = Recipe.Create(ItemID.SnowballCannon);
            recipe.AddIngredient(ItemID.SlimeGun);
            recipe.AddRecipeGroup("IronBar", 3);
            recipe.AddIngredient(ItemID.SnowBlock, 50);
            recipe.AddIngredient(ItemID.IceBlock, 50);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            // Modded recipe for gel (calamity dependent)
            recipe = Recipe.Create(ItemID.Gel, 100);
            if (calamityMod != null && calamityMod.TryFind<ModItem>("StatigelBlock", out ModItem StatigelBlock) && calamityMod.TryFind<ModTile>("StaticRefiner", out ModTile StaticRefiner))
            {
                recipe.AddIngredient(StatigelBlock.Type);
                recipe.AddTile(StaticRefiner.Type);
            }
            recipe.Register();

            // Black ink because farming sucks
            recipe = Recipe.Create(ItemID.BlackInk, 2);
            if (thoriumMod != null && thoriumMod.TryFind<ModItem>("SmoothCoal", out ModItem SmoothCoal))
            {
                recipe.AddIngredient(SmoothCoal.Type);
                recipe.AddTile(TileID.DyeVat);
            }
            recipe.Register();

            // Recipe for tactical shotgun because can't find in dungeon
            // Still needs post-plantera dungeaon stuff
            // And thorium things
            recipe = Recipe.Create(ItemID.TacticalShotgun);
            if (thoriumMod != null && thoriumMod.TryFind<ModItem>("DarkMatter", out ModItem DarkMatter) && thoriumMod.TryFind<ModItem>("aDarksteelAlloy", out ModItem aDarksteelAlloy))
            {
                recipe.AddIngredient(DarkMatter.Type, 6);
                recipe.AddIngredient(aDarksteelAlloy.Type, 12);
                recipe.AddIngredient(ItemID.Ectoplasm, 8);
                recipe.AddTile(TileID.AdamantiteForge);
                recipe.Register();
            }

            // Magic storage stuff, because OG recipes suck
            // Also code below sucks, fix when haves the time
            if (magicStorage != null && magicStorage.TryFind<ModItem>("StorageHeart", out ModItem StorageHeart))
            {
                if (magicStorage.TryFind<ModItem>("StorageComponent", out ModItem StorageComponent))
                {
                    recipe = Recipe.Create(StorageHeart.Type);
                    recipe.AddIngredient(StorageComponent.Type);
                    recipe.AddIngredient(ItemID.Gel, 10);
                    recipe.AddIngredient(ItemID.SilverBar, 2);
                    recipe.AddTile(TileID.Anvils);
                    recipe.Register();
                }
            }
            if (magicStorage != null && magicStorage.TryFind<ModItem>("CraftingAccess", out ModItem CraftingAccess))
            {
                if (magicStorage.TryFind<ModItem>("StorageComponent", out ModItem StorageComponent))
                {
                    recipe = Recipe.Create(CraftingAccess.Type);
                    recipe.AddIngredient(StorageComponent.Type);
                    recipe.AddIngredient(ItemID.Gel, 10);
                    recipe.AddIngredient(ItemID.GoldBar, 2);
                    recipe.AddTile(TileID.Anvils);
                    recipe.Register();
                }
            }
        }
    }
}
