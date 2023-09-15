using GangstaMod.Content.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace GangstaMod.Common.GlobalNPCs
{
    class NPCShop : GlobalNPC
    {
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            // If the npc is zoologist (bestiary girl)
            if (type == NPCID.BestiaryGirl)
            {
                // and if expert mode
                if(Main.expertMode)
                {
                    // sell ladybugs
                    shop.item[nextSlot].SetDefaults(ItemID.LadyBug);
                    shop.item[nextSlot].shopCustomPrice = 112; // price
                    nextSlot++;

                    // sell garden gnomes
                    shop.item[nextSlot].SetDefaults(ItemID.GardenGnome);
                    shop.item[nextSlot].shopCustomPrice = 211; // price
                    nextSlot++;
                }
            }
        }
    }
}
