using System.Collections.Generic;
using Terraria.Achievements;

namespace Terraria
{
	public sealed class Recipe
	{
		public enum Category : byte
		{
			STRUCTURES,
			TOOLS,
			WEAPONS,
			ARMOR,
			POTIONS,
			MISC,
			NUM_CATEGORIES
		}

		public enum SubCategory : byte
		{
			NONE = 0,
			// No idea what Engine's logic was behind defining only 2 other 0-value entries.
			TABLEWARE = 0,
			TORCHES = 1,
			WALLS = 2,
			BRICKS = 3,
			LANTERNS = 4,
			CHANDELIERS = 5,
			CHESTS = 6,
			CRAFTING_STATIONS = 7,
			ANVILS = 8,
			STATUES = 9,
			MECHANISM = 10,
			TIMERS = 11,
			PUMPS = 12,
			// ---
			PICKAXES = 1,
			DRILLS = 2,
			AXES = 3, // Palladium Chainsaw is here for some reason
			CHAINSAWS = 4,
			HAMMERS = 5,
			HAMAXES = 6,
			BARS = 7,
			GRAPPLING = 8,
			// ---
			SWORDS = 1,
			BROADSWORDS = 2,
			SHORTSWORDS = 3,
			FLAILS = 4,
			BOOMERANGS = 5,
			BOWS = 6,
			ARROWS = 7,
			GUNS = 8,
			MAGIC_GUNS = 9,
			SPELLS = 10,
			REPEATERS = 11,
			BULLETS = 12,
			PHASEBLADES = 13,
			PHASESABERS = 14,
			SPEARS = 15,
			EXPLOSIVES = 16,
			// ---
			BOOTS = 0,
			HEADGEAR = 1,
			HELMETS = 2,
			MASKS = 3,
			HOODS = 4,
			HATS = 5, // Featuring the Platinum Crown since the Gold Crown is in 0
			GOGGLES = 6,
			BODY = 7,
			SHIRTS = 8,
			LEGS = 9,
			PANTS = 10,
			WINGS = 11,
			// ---
			HEALING = 1,
			MANA = 2,
			RESTORATION = 3,
			// ---
			BANNERS = 1,
			WATCHES = 2,
			MUSICBOXES = 3,
			EYES = 4,
			SKULLS = 5
		}

		public sealed class SubCategoryList
		{
			public bool CanCraft;

			public List<short> RecipeList;

			public SubCategoryList(int ReserveIdx)
			{
				CanCraft = false;
				RecipeList = new List<short>(ReserveIdx);
			}

			public void Add(Player CurPlayer, int RecipeIdx)
			{
				RecipeList.Add((short)RecipeIdx);
				if (!CanCraft)
				{
					CanCraft = CurPlayer.CanCraftRecipe(Main.ActiveRecipe[RecipeIdx]);
				}
			}
		}

		public const int MaxItemRequirements = 12;

		public const int MaxTileRequirements = 3;

#if VERSION_INITIAL
		public const int MaxNumRecipes = 342;
#elif VERSION_101
		public const int MaxNumRecipes = 358;
#else

#endif

		public static Recipe NewRecipe = new Recipe();

		public Item CraftedItem = default;

		public Item[] RequiredItem = new Item[MaxItemRequirements];

		public short[] RequiredTile = new short[MaxTileRequirements];

		public byte NumRequiredItems;

		public byte NumRequiredTiles;

		public bool NeedsWater;

		public Category RecipeCategory;

		public SubCategory RecipeSubCategory;

		public static int NumRecipes = 0;

		public static Dictionary<int, SubCategoryList> CurrentRecipes = new Dictionary<int, SubCategoryList>();

		public Recipe()
		{
			for (int ItemSlot = 0; ItemSlot < MaxItemRequirements; ItemSlot++)
			{
				RequiredItem[ItemSlot].Init();
			}
			for (int TileSlot = 0; TileSlot < MaxTileRequirements; TileSlot++)
			{
				RequiredTile[TileSlot] = -1;
			}
		}

		public void Create(UI ActiveUI)
		{
			for (int ItemSlot = 0; ItemSlot < NumRequiredItems; ItemSlot++)
			{
				int ItemCount = RequiredItem[ItemSlot].Stack;
				for (int InvIdx = 0; InvIdx < Player.MaxNumInventory; InvIdx++)
				{
					if (ActiveUI.ActivePlayer.Inventory[InvIdx].NetID == RequiredItem[ItemSlot].NetID)
					{
						if (ActiveUI.ActivePlayer.Inventory[InvIdx].Stack > ItemCount)
						{
							ActiveUI.ActivePlayer.Inventory[InvIdx].Stack -= (short)ItemCount;
							ItemCount = 0;
						}
						else
						{
							ItemCount -= ActiveUI.ActivePlayer.Inventory[InvIdx].Stack;
							ActiveUI.ActivePlayer.Inventory[InvIdx].Init();
						}
					}
					if (ItemCount <= 0)
					{
						break;
					}
				}
			}
			if ((RequiredTile[0] == (int)EntityID.TileID.ANVIL || RequiredTile[0] == (int)EntityID.TileID.MYTHRIL_ANVIL) && ++ActiveUI.TotalAnvilCrafting == (int)Achievement.AnvilItemsGoal)
			{
				ActiveUI.AchievementTriggers.SetState(Trigger.UsedLotsOfAnvils, State: true);
			}
			switch (RecipeCategory)
			{
				case Category.STRUCTURES:
					ActiveUI.Statistics.IncreaseStat(StatisticEntry.FurnitureCrafted);
					break;
				case Category.TOOLS:
					ActiveUI.Statistics.IncreaseStat(StatisticEntry.ToolsCrafted);
					break;
				case Category.WEAPONS:
					ActiveUI.Statistics.IncreaseStat(StatisticEntry.WeaponsCrafted);
					break;
				case Category.ARMOR:
					ActiveUI.Statistics.IncreaseStat(StatisticEntry.ArmorCrafted);
					break;
				case Category.POTIONS:
					ActiveUI.Statistics.IncreaseStat(StatisticEntry.ConsumablesCrafted);
					break;
				default:
					ActiveUI.Statistics.IncreaseStat(StatisticEntry.MiscCrafted);
					break;
			}
			switch ((EntityID.ItemID)CraftedItem.Type)
			{
				case EntityID.ItemID.TORCH:
				case EntityID.ItemID.BLUE_TORCH:
				case EntityID.ItemID.RED_TORCH:
				case EntityID.ItemID.GREEN_TORCH:
				case EntityID.ItemID.PURPLE_TORCH:
				case EntityID.ItemID.WHITE_TORCH:
				case EntityID.ItemID.YELLOW_TORCH:
				case EntityID.ItemID.DEMON_TORCH:
					ActiveUI.TotalTorchesCrafted += (uint)CraftedItem.Stack;
					break;
				case EntityID.ItemID.WOOD_PLATFORM:
					ActiveUI.TotalWoodPlatformsCrafted += (uint)CraftedItem.Stack;
					break;
				case EntityID.ItemID.STONE_WALL:
				case EntityID.ItemID.DIRT_WALL:
				case EntityID.ItemID.WOOD_WALL:
				case EntityID.ItemID.PLANKED_WALL:
					ActiveUI.TotalWallsCrafted += (uint)CraftedItem.Stack;
					break;
				case EntityID.ItemID.GOLD_BAR:
				case EntityID.ItemID.COPPER_BAR:
				case EntityID.ItemID.SILVER_BAR:
				case EntityID.ItemID.IRON_BAR:
				case EntityID.ItemID.DEMONITE_BAR:
				case EntityID.ItemID.METEORITE_BAR:
				case EntityID.ItemID.HELLSTONE_BAR:
				case EntityID.ItemID.COBALT_BAR:
				case EntityID.ItemID.MYTHRIL_BAR:
				case EntityID.ItemID.ADAMANTITE_BAR:
					ActiveUI.TotalBarsCrafted += (uint)CraftedItem.Stack;
					if (ActiveUI.TotalBarsCrafted >= (int)Achievement.SmelterBarsGoal)
					{
						ActiveUI.ActivePlayer.AchievementTrigger(Trigger.CreatedLotsOfBars);
					}
					break;
			}
		}

		public static void FindRecipes(UI ActiveUI, Category RecipeCategory, bool IsCraftable)
		{
			// Slight discrepancy exists, as while the SetupRecipes is identical, the sorting code for the recipes is not when checked against v1.01. This means that recipes will appear in different positions, but the same ones will be featured.
			// Until I can somehow read the code a bit better between versions, this is remaining as-is.
			// int Counter = 0;
			int Spacer = 1024;
			ActiveUI.ActivePlayer.UpdateRecipes();
			for (int RecipeIdx = 0; RecipeIdx < MaxNumRecipes; RecipeIdx++)
			{
				Recipe PotentialRecipe = Main.ActiveRecipe[RecipeIdx];
				if (RecipeCategory != PotentialRecipe.RecipeCategory)
				{
					continue;
				}
				if (IsCraftable)
				{
					if (!ActiveUI.ActivePlayer.CanCraftRecipe(PotentialRecipe))
					{
						continue;
					}
				}
				else if (ActiveUI.CraftGuide)
				{
					bool IsMatched = false;
					for (int ItemSlot = PotentialRecipe.NumRequiredItems - 1; ItemSlot >= 0; ItemSlot--)
					{
						if (PotentialRecipe.RequiredItem[ItemSlot].NetID == ActiveUI.GuideItem.NetID)
						{
							IsMatched = true;
							break;
						}
					}
					if (!IsMatched)
					{
						continue;
					}
				}
#if USE_ORIGINAL_CODE
				else if (!ActiveUI.ActivePlayer.RecipesFound[RecipeIdx])
				{
					continue;
				}
#else
				else if (!Main.UnlockAllRecipes)
				{
					if (!ActiveUI.ActivePlayer.RecipesFound[RecipeIdx])
					{
						continue;
					}

				}
#endif
				int ItemSubCategory = (int)PotentialRecipe.RecipeSubCategory;
				if (ItemSubCategory == 0)
				{
					// Counter++;
					ItemSubCategory = Spacer++;
					CurrentRecipes.Add(ItemSubCategory, new SubCategoryList(1));
				}
				else if (!CurrentRecipes.ContainsKey(ItemSubCategory))
				{
					// Counter++;
					CurrentRecipes.Add(ItemSubCategory, new SubCategoryList(32));
				}
				CurrentRecipes[ItemSubCategory].Add(ActiveUI.ActivePlayer, RecipeIdx);
			}
			Dictionary<int, SubCategoryList>.ValueCollection PassedRecipes = CurrentRecipes.Values;
			ActiveUI.CurrentRecipeCategory.Clear();
			foreach (SubCategoryList ItemType in PassedRecipes)
			{
				if (ItemType.CanCraft)
				{
					ActiveUI.CurrentRecipeCategory.Add(ItemType);
				}
			}
			foreach (SubCategoryList ItemType in PassedRecipes)
			{
				if (!ItemType.CanCraft)
				{
					ActiveUI.CurrentRecipeCategory.Add(ItemType);
				}
			}
			int Count = CurrentRecipes.Count;
			if (Count == 0)
			{
				ActiveUI.CraftingRecipe = NewRecipe;
				ActiveUI.CraftingRecipeX = 0;
				ActiveUI.CraftingRecipeY = 0;
			}
			else
			{
				if (ActiveUI.CraftingRecipeY >= Count)
				{
					ActiveUI.CraftingRecipeY = (sbyte)(Count - 1);
				}
				int CategoryCount = ActiveUI.CurrentRecipeCategory[ActiveUI.CraftingRecipeY].RecipeList.Count;
				if (ActiveUI.CraftingRecipeX >= CategoryCount)
				{
					ActiveUI.CraftingRecipeX = (sbyte)(CategoryCount - 1);
				}
			}
			CurrentRecipes.Clear();
		}

		public static void SetupRecipes()
		{
			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.CRAFTING_STATIONS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.WORK_BENCH);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.WOOD, 10);
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.TORCHES;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.TORCH, 3);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.GEL);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.WOOD);
			AddRecipe();

			NewRecipe.RecipeCategory = Category.MISC;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MUG);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.GLASS);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.FURNACE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.POTIONS;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.BOWL_OF_SOUP);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.BOWL);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.MUSHROOM);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.GOLDFISH);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.COOKING_POT;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.MISC;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.BOTTLE, 2);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.GLASS);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.FURNACE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.POTIONS;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.BOTTLED_WATER);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.BOTTLE);
			NewRecipe.NeedsWater = true;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.POTIONS;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.HOLY_WATER, 5);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.BOTTLED_WATER);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.PIXIE_DUST, 5);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.HALLOWED_SEEDS);
			AddRecipe();

			NewRecipe.RecipeCategory = Category.POTIONS;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.UNHOLY_WATER, 5);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.BOTTLED_WATER);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.EBONSAND_BLOCK);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.CORRUPT_SEEDS);
			AddRecipe();

			NewRecipe.RecipeCategory = Category.POTIONS;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.ALE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.MUG);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.KEG;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.POTIONS;
			NewRecipe.RecipeSubCategory = SubCategory.HEALING;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.LESSER_HEALING_POTION, 2);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.MUSHROOM);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.GEL, 2);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.BOTTLE, 2);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.BOTTLE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.POTIONS;
			NewRecipe.RecipeSubCategory = SubCategory.HEALING;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.HEALING_POTION);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.LESSER_HEALING_POTION, 2);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.GLOWING_MUSHROOM);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.BOTTLE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.POTIONS;
			NewRecipe.RecipeSubCategory = SubCategory.HEALING;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.GREATER_HEALING_POTION);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.BOTTLED_WATER);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.PIXIE_DUST, 3);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.CRYSTAL_SHARD);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.BOTTLE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.POTIONS;
			NewRecipe.RecipeSubCategory = SubCategory.MANA;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.LESSER_MANA_POTION, 2);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.FALLEN_STAR);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.GEL, 2);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.BOTTLE, 2);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.BOTTLE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.POTIONS;
			NewRecipe.RecipeSubCategory = SubCategory.MANA;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MANA_POTION);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.LESSER_MANA_POTION, 2);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.GLOWING_MUSHROOM);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.BOTTLE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.POTIONS;
			NewRecipe.RecipeSubCategory = SubCategory.RESTORATION;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.LESSER_RESTORATION_POTION);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.LESSER_HEALING_POTION);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.LESSER_MANA_POTION);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.BOTTLE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.POTIONS;
			NewRecipe.RecipeSubCategory = SubCategory.RESTORATION;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.RESTORATION_POTION);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.HEALING_POTION);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.MANA_POTION);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.BOTTLE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.POTIONS;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.OBSIDIAN_SKIN_POTION);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.BOTTLED_WATER);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.FIREBLOSSOM);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.WATERLEAF);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.OBSIDIAN);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.BOTTLE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.POTIONS;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.REGENERATION_POTION);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.BOTTLED_WATER);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.DAYBLOOM);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.MUSHROOM);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.BOTTLE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.POTIONS;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.SWIFTNESS_POTION);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.BOTTLED_WATER);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.BLINKROOT);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.CACTUS);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.BOTTLE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.POTIONS;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.GILLS_POTION);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.BOTTLED_WATER);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.WATERLEAF);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.CORAL);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.BOTTLE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.POTIONS;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.IRONSKIN_POTION);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.BOTTLED_WATER);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.DAYBLOOM);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.IRON_ORE);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.BOTTLE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.POTIONS;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MANA_REGENERATION_POTION);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.BOTTLED_WATER);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.MOONGLOW);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.DAYBLOOM);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.FALLEN_STAR);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.BOTTLE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.POTIONS;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MAGIC_POWER_POTION);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.BOTTLED_WATER);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.MOONGLOW);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.DEATHWEED);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.FALLEN_STAR);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.BOTTLE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.POTIONS;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.FEATHERFALL_POTION);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.BOTTLED_WATER);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.DAYBLOOM);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.BLINKROOT);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.FEATHER);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.BOTTLE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.POTIONS;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.SPELUNKER_POTION);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.BOTTLED_WATER);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.BLINKROOT);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.MOONGLOW);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.GOLD_ORE);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.BOTTLE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.POTIONS;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.INVISIBILITY_POTION);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.BOTTLED_WATER);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.BLINKROOT);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.MOONGLOW);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.BOTTLE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.POTIONS;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.SHINE_POTION);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.BOTTLED_WATER);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.DAYBLOOM);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.GLOWING_MUSHROOM);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.BOTTLE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.POTIONS;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.NIGHT_OWL_POTION);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.BOTTLED_WATER);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.DAYBLOOM);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.BLINKROOT);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.BOTTLE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.POTIONS;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.BATTLE_POTION);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.BOTTLED_WATER);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.DEATHWEED);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.ROTTEN_CHUNK);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.BOTTLE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.POTIONS;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.THORNS_POTION);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.BOTTLED_WATER);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.DEATHWEED);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.CACTUS);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.WORM_TOOTH);
			NewRecipe.RequiredItem[4].SetDefaults((int)EntityID.ItemID.STINGER);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.BOTTLE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.POTIONS;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.WATER_WALKING_POTION);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.BOTTLED_WATER);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.WATERLEAF);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.SHARK_FIN);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.BOTTLE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.POTIONS;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.ARCHERY_POTION);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.BOTTLED_WATER);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.DAYBLOOM);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.LENS);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.BOTTLE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.POTIONS;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.HUNTER_POTION);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.BOTTLED_WATER);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.DAYBLOOM);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.BLINKROOT);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.SHARK_FIN);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.BOTTLE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.POTIONS;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.GRAVITATION_POTION);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.BOTTLED_WATER);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.FIREBLOSSOM);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.DEATHWEED);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.BLINKROOT);
			NewRecipe.RequiredItem[4].SetDefaults((int)EntityID.ItemID.FEATHER);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.BOTTLE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.ARROWS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.WOODEN_ARROW, 5);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.WOOD);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.STONE_BLOCK);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.ARROWS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.FLAMING_ARROW, 3);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.WOODEN_ARROW, 3);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.TORCH);
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.ARROWS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.UNHOLY_ARROW, 3);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.WOODEN_ARROW, 3);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.WORM_TOOTH);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.ARROWS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.HELLFIRE_ARROW, 10);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.WOODEN_ARROW, 10);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.HELLSTONE_BAR);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.TORCH, 5);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.ARROWS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.CURSED_ARROW, 15);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.WOODEN_ARROW, 15);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.CURSED_FLAME);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.ARROWS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.HOLY_ARROW, 35);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.WOODEN_ARROW, 35);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.PIXIE_DUST, 6);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.UNICORN_HORN);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.BULLETS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.METEOR_SHOT, 25);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.MUSKET_BALL, 25);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.METEORITE_BAR);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.BULLETS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.CRYSTAL_BULLET, 25);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.MUSKET_BALL, 25);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.CRYSTAL_SHARD);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.BULLETS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.CURSED_BULLET, 25);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.MUSKET_BALL, 25);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.CURSED_FLAME);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.MISC;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.PURPLE_THREAD);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.BOTTLE);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.MUSHROOM_GRASS_SEEDS, 3);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.BOTTLE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.MISC;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.VILE_POWDER, 5);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.VILE_MUSHROOM);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.BOTTLE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.POISONED_KNIFE, 20);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.THROWING_KNIFE, 20);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.VILE_POWDER);
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.TORCHES;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.BLUE_TORCH, 3);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.TORCH, 3);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.SAPPHIRE);
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.TORCHES;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.RED_TORCH, 3);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.TORCH, 3);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.RUBY);
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.TORCHES;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.GREEN_TORCH, 3);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.TORCH, 3);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.EMERALD);
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.TORCHES;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.YELLOW_TORCH, 3);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.TORCH, 3);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.TOPAZ);
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.TORCHES;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.PURPLE_TORCH, 3);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.TORCH, 3);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.AMETHYST);
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.TORCHES;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.WHITE_TORCH, 3);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.TORCH, 3);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.DIAMOND);
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.TORCHES;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.CURSED_TORCH, 33);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.TORCH, 33);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.CURSED_FLAME);
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.LANTERNS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.CHINESE_LANTERN);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.SILK, 5);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.TORCH, 1);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.LANTERNS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.TIKI_TORCH);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.TORCH);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.WOOD, 3);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.LANTERNS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.LAMP_POST);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.IRON_BAR, 3);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.GLASS, 2);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.TORCH);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.LANTERNS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.SKULL_LANTERN, 1);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.BONE, 10);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.TORCH);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.EXPLOSIVES;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.STICKY_BOMB);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.BOMB);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.GEL, 5);
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.STICKY_GLOWSTICK);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.GLOWSTICK);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.GEL);
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.GLASS, 1);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.SAND_BLOCK, 2);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.FURNACE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.WALLS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.GLASS_WALL, 4);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.GLASS);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.TABLEWARE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.CLAY_POT);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.CLAY_BLOCK, 6);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.FURNACE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.TABLEWARE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.PINK_VASE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.CLAY_BLOCK, 4);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.FURNACE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.TABLEWARE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.BOWL);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.CLAY_BLOCK, 2);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.FURNACE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.BRICKS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.GRAY_BRICK);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.STONE_BLOCK, 2);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.FURNACE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.WALLS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.GRAY_BRICK_WALL, 4);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.GRAY_BRICK);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.BRICKS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.RED_BRICK);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.CLAY_BLOCK, 2);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.FURNACE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.WALLS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.RED_BRICK_WALL, 4);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.RED_BRICK);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.BRICKS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.COPPER_BRICK);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.STONE_BLOCK, 1);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.COPPER_ORE, 1);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.FURNACE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.WALLS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.COPPER_BRICK_WALL, 4);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COPPER_BRICK);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.BRICKS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.SILVER_BRICK);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.STONE_BLOCK, 1);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.SILVER_ORE, 1);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.FURNACE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.WALLS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.SILVER_BRICK_WALL, 4);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.SILVER_BRICK);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.BRICKS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.GOLD_BRICK);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.STONE_BLOCK, 1);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.GOLD_ORE, 1);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.FURNACE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.WALLS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.GOLD_BRICK_WALL, 4);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.GOLD_BRICK);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.BRICKS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.HELLSTONE_BRICK);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.HELLSTONE);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.STONE_BLOCK);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.FURNACE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.BRICKS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.OBSIDIAN_BRICK);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.OBSIDIAN, 2);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.FURNACE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.WALLS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.OBSIDIAN_BRICK_WALL, 4);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.OBSIDIAN_BRICK);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.FURNACE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.BRICKS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.SNOW_BRICK);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.SNOW_BLOCK, 2);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.WALLS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.SNOW_BRICK_WALL, 4);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.SNOW_BRICK);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.WALLS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.CANDY_CANE_WALL, 4);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.CANDY_CANE_BLOCK);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.WALLS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.GREEN_CANDY_CANE_WALL, 4);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.GREEN_CANDY_CANE_BLOCK);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.BRICKS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.PEARLSTONE_BRICK);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.PEARLSAND_BLOCK);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.PEARLSTONE_BLOCK);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.FURNACE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.WALLS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.PEARLSTONE_BRICK_WALL, 4);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.PEARLSTONE_BRICK);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.BRICKS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.IRIDESCENT_BRICK);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.STONE_BLOCK);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.ASH_BLOCK);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.FURNACE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.WALLS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.IRIDESCENT_BRICK_WALL, 4);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.IRIDESCENT_BRICK);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.BRICKS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MUDSTONE_BRICK);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.STONE_BLOCK);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.MUD_BLOCK);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.FURNACE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.WALLS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MUDSTONE_BRICK_WALL, 4);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.MUDSTONE_BRICK);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.BRICKS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.COBALT_BRICK);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.STONE_BLOCK);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.COBALT_ORE);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.FURNACE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.WALLS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.COBALT_BRICK_WALL, 4);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COBALT_BRICK);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.BRICKS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MYTHRIL_BRICK);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.STONE_BLOCK);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.MYTHRIL_ORE);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.FURNACE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.WALLS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MYTHRIL_BRICK_WALL, 4);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.MYTHRIL_BRICK);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.BRICKS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.DEMONITE_BRICK, 5);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.DEMONITE_ORE);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.EBONSTONE_BLOCK, 5);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.FURNACE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MUD_BLOCK);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.DIRT_BLOCK);
			NewRecipe.NeedsWater = true;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.WALLS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.DIRT_WALL, 4);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.DIRT_BLOCK);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.WALLS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.STONE_WALL, 4);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.STONE_BLOCK);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.WALLS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.WOOD_WALL, 4);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.WOOD);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.WOOD_PLATFORM);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.WOOD);
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.WOODEN_DOOR);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.WOOD, 6);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.WOODEN_CHAIR);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.WOOD, 4);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.SIGN);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.WOOD, 6);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.CHESTS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.CHEST);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.WOOD, 8);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.IRON_BAR, 2);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.TABLEWARE; 
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.WOODEN_TABLE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.WOOD, 8);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.WALLS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.PLANKED_WALL, 4);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.STONE_BLOCK, 1);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.WOOD, 1);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.SAWMILL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.WOODEN_BEAM, 2);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.WOOD, 1);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.SAWMILL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MANNEQUIN);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.WOOD, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.SAWMILL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.BED);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.WOOD, 15);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.SILK, 5);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.SAWMILL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.BOOKCASE, 1);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.WOOD, 20);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.BOOK, 10);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.SAWMILL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.BARREL);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.WOOD, 9);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.IRON_BAR, 1);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.SAWMILL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.GRANDFATHER_CLOCK);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.GOLD_BAR, 3);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.GLASS, 6);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.WOOD, 10);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.SAWMILL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.CRAFTING_STATIONS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.KEG);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.WOOD, 14);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.SAWMILL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.PIANO);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.BONE, 4);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.WOOD, 15);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.BOOK);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.SAWMILL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.CRAFTING_STATIONS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.LOOM);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.WOOD, 12);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.SAWMILL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.DRESSER);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.WOOD, 16);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.SAWMILL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.BENCH);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.WOOD, 8);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.SAWMILL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.CRAFTING_STATIONS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.SAWMILL);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.WOOD, 10);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.IRON_BAR, 2);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.CHAIN);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

#if VERSION_101
			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.HELMETS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.WOOD_HELMET);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.WOOD, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.BODY;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.WOOD_BREASTPLATE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.WOOD, 30);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.LEGS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.WOOD_GREAVES);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.WOOD, 25);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();
#endif

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.SWORDS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.WOODEN_SWORD);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.WOOD, 7);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.HAMMERS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.WOODEN_HAMMER);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.WOOD, 8);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.BOWS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.WOODEN_BOW);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.WOOD, 10);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.MISC;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.GOBLIN_BATTLE_STANDARD);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.TATTERED_CLOTH, 10);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.WOOD, 5);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.LOOM;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.MISC;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.SILK);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COBWEB, 10);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.LOOM;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.MISC;
			NewRecipe.RecipeSubCategory = SubCategory.BANNERS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.RED_BANNER);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.SILK, 3);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.LOOM;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.MISC;
			NewRecipe.RecipeSubCategory = SubCategory.BANNERS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.GREEN_BANNER);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.SILK, 3);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.LOOM;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.MISC;
			NewRecipe.RecipeSubCategory = SubCategory.BANNERS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.BLUE_BANNER);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.SILK, 3);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.LOOM;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.MISC;
			NewRecipe.RecipeSubCategory = SubCategory.BANNERS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.YELLOW_BANNER);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.SILK, 3);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.LOOM;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.HATS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.HEROS_HAT);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.SILK, 20);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.PURPLE_THREAD, 3);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.LOOM;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.SHIRTS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.HEROS_SHIRT);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.SILK, 20);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.PURPLE_THREAD, 3);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.LOOM;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.PANTS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.HEROS_PANTS);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.SILK, 20);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.PURPLE_THREAD, 3);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.LOOM;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.SHIRTS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.TUXEDO_SHIRT);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.SILK, 20);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.BLACK_THREAD, 3);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.LOOM;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.PANTS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.TUXEDO_PANTS);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.SILK, 20);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.BLACK_THREAD, 3);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.LOOM;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.ROBE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.SILK, 30);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.RUBY, 3);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.LOOM;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.MISC;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.LEATHER);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.ROTTEN_CHUNK, 5);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.SHIRTS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.ARCHAEOLOGISTS_JACKET);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.LEATHER, 15);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.PANTS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.ARCHAEOLOGISTS_PANTS);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.LEATHER, 15);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.TABLEWARE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.FISH_BOWL);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.GOLDFISH, 2);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.BOTTLED_WATER);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.CRAFTING_STATIONS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.FURNACE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.STONE_BLOCK, 20);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.WOOD, 4);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.TORCH, 3);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.STATUES;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.STATUE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.STONE_BLOCK, 100);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.BARS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.COPPER_BAR);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COPPER_ORE, 3);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.FURNACE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.PICKAXES;
			NewRecipe.CraftedItem.NetDefaults((int)EntityID.ItemID.COPPER_PICKAXE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COPPER_BAR, 12);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.WOOD, 4);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.AXES;
			NewRecipe.CraftedItem.NetDefaults((int)EntityID.ItemID.COPPER_AXE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COPPER_BAR, 9);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.WOOD, 3);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.HAMMERS;
			NewRecipe.CraftedItem.NetDefaults((int)EntityID.ItemID.COPPER_HAMMER);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COPPER_BAR, 10);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.WOOD, 3);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.BROADSWORDS;
			NewRecipe.CraftedItem.NetDefaults((int)EntityID.ItemID.COPPER_BROADSWORD);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COPPER_BAR, 8);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.SHORTSWORDS;
			NewRecipe.CraftedItem.NetDefaults((int)EntityID.ItemID.COPPER_SHORTSWORD);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COPPER_BAR, 7);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.BOWS;
			NewRecipe.CraftedItem.NetDefaults((int)EntityID.ItemID.COPPER_BOW);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COPPER_BAR, 7);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.HELMETS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.COPPER_HELMET);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COPPER_BAR, 15);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.BODY;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.COPPER_CHAINMAIL);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COPPER_BAR, 25);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.LEGS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.COPPER_GREAVES);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COPPER_BAR, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.MISC;
			NewRecipe.RecipeSubCategory = SubCategory.WATCHES;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.COPPER_WATCH);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COPPER_BAR, 10);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.CHAIN);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.TABLE;
			NewRecipe.RequiredTile[1] = (int)EntityID.TileID.CHAIR;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.CHANDELIERS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.COPPER_CHANDELIER);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COPPER_BAR, 4);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.TORCH, 4);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.CHAIN);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.BARS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.IRON_BAR);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.IRON_ORE, 3);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.FURNACE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.ANVILS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.IRON_ANVIL);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.IRON_BAR, 5);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.EMPTY_BUCKET);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.IRON_BAR, 3);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.TRASH_CAN);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.IRON_BAR, 8);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.BATHTUB);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.IRON_BAR, 14);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.TOILET);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.IRON_BAR, 6);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.CRAFTING_STATIONS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.COOKING_POT);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.IRON_BAR, 10);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.WOOD, 2);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.PICKAXES;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.IRON_PICKAXE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.IRON_BAR, 12);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.WOOD, 3);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.AXES;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.IRON_AXE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.IRON_BAR, 9);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.WOOD, 3);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.HAMMERS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.IRON_HAMMER);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.IRON_BAR, 10);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.WOOD, 3);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.BROADSWORDS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.IRON_BROADSWORD);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.IRON_BAR, 8);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.SHORTSWORDS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.IRON_SHORTSWORD);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.IRON_BAR, 7);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.BOWS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.IRON_BOW);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.IRON_BAR, 7);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.HELMETS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.IRON_HELMET);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.IRON_BAR, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.BODY;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.IRON_CHAINMAIL);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.IRON_BAR, 30);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.LEGS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.IRON_GREAVES);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.IRON_BAR, 25);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.CHAIN);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.IRON_BAR, 3);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.BARS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.SILVER_BAR);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.SILVER_ORE, 4);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.FURNACE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.PICKAXES;
			NewRecipe.CraftedItem.NetDefaults((int)EntityID.ItemID.SILVER_PICKAXE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.SILVER_BAR, 12);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.WOOD, 4);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.AXES;
			NewRecipe.CraftedItem.NetDefaults((int)EntityID.ItemID.SILVER_AXE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.SILVER_BAR, 9);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.WOOD, 3);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.HAMMERS;
			NewRecipe.CraftedItem.NetDefaults((int)EntityID.ItemID.SILVER_HAMMER);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.SILVER_BAR, 10);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.WOOD, 3);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.BROADSWORDS;
			NewRecipe.CraftedItem.NetDefaults((int)EntityID.ItemID.SILVER_BROADSWORD);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.SILVER_BAR, 8);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.SHORTSWORDS;
			NewRecipe.CraftedItem.NetDefaults((int)EntityID.ItemID.SILVER_SHORTSWORD);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.SILVER_BAR, 6);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.BOWS;
			NewRecipe.CraftedItem.NetDefaults((int)EntityID.ItemID.SILVER_BOW);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.SILVER_BAR, 7);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.HELMETS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.SILVER_HELMET);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.SILVER_BAR, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.BODY;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.SILVER_CHAINMAIL);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.SILVER_BAR, 30);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.LEGS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.SILVER_GREAVES);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.SILVER_BAR, 25);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.MISC;
			NewRecipe.RecipeSubCategory = SubCategory.WATCHES;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.SILVER_WATCH);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.SILVER_BAR, 10);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.CHAIN);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.TABLE;
			NewRecipe.RequiredTile[1] = (int)EntityID.TileID.CHAIR;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.CHANDELIERS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.SILVER_CHANDELIER);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.SILVER_BAR, 4);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.TORCH, 4);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.CHAIN);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.BARS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.GOLD_BAR);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.GOLD_ORE, 4);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.FURNACE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.PICKAXES;
			NewRecipe.CraftedItem.NetDefaults((int)EntityID.ItemID.GOLD_PICKAXE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.GOLD_BAR, 12);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.WOOD, 4);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.AXES;
			NewRecipe.CraftedItem.NetDefaults((int)EntityID.ItemID.GOLD_AXE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.GOLD_BAR, 9);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.WOOD, 3);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.HAMMERS;
			NewRecipe.CraftedItem.NetDefaults((int)EntityID.ItemID.GOLD_HAMMER);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.GOLD_BAR, 10);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.WOOD, 3);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.BROADSWORDS;
			NewRecipe.CraftedItem.NetDefaults((int)EntityID.ItemID.GOLD_BROADSWORD);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.GOLD_BAR, 8);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.SHORTSWORDS;
			NewRecipe.CraftedItem.NetDefaults((int)EntityID.ItemID.GOLD_SHORTSWORD);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.GOLD_BAR, 7);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.BOWS;
			NewRecipe.CraftedItem.NetDefaults((int)EntityID.ItemID.GOLD_BOW);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.GOLD_BAR, 7);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.HELMETS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.GOLD_HELMET);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.GOLD_BAR, 25);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.BODY;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.GOLD_CHAINMAIL);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.GOLD_BAR, 35);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.LEGS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.GOLD_GREAVES);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.GOLD_BAR, 30);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.MISC;
			NewRecipe.RecipeSubCategory = SubCategory.WATCHES;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.GOLD_WATCH);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.GOLD_BAR, 10);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.CHAIN);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.TABLE;
			NewRecipe.RequiredTile[1] = (int)EntityID.TileID.CHAIR;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.GOLD_CROWN);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.GOLD_BAR, 30);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.RUBY);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.CHANDELIERS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.GOLD_CHANDELIER);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.GOLD_BAR, 4);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.TORCH, 4);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.CHAIN);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.THRONE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.SILK, 20);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.GOLD_BAR, 30);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.LANTERNS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.CANDLE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.GOLD_BAR);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.TORCH);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.LANTERNS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.CANDELABRA, 1);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.GOLD_BAR, 5);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.TORCH, 3);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.BARS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.DEMONITE_BAR);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.DEMONITE_ORE, 4);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.FURNACE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.BOWS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.DEMON_BOW);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.DEMONITE_BAR, 8);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.AXES;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.WAR_AXE_OF_THE_NIGHT);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.DEMONITE_BAR, 10);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.BROADSWORDS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.LIGHTS_BANE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.DEMONITE_BAR, 10);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.HELMETS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.SHADOW_HELMET);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.DEMONITE_BAR, 15);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.SHADOW_SCALE, 10);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.BODY;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.SHADOW_SCALEMAIL);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.DEMONITE_BAR, 25);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.SHADOW_SCALE, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.LEGS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.SHADOW_GREAVES);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.DEMONITE_BAR, 20);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.SHADOW_SCALE, 15);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.PICKAXES;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.NIGHTMARE_PICKAXE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.DEMONITE_BAR, 12);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.SHADOW_SCALE, 6);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.HAMMERS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.THE_BREAKER);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.DEMONITE_BAR, 10);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.SHADOW_SCALE, 5);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.GRAPPLING;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.GRAPPLING_HOOK);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.CHAIN, 3);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.HOOK, 1);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.BARS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.METEORITE_BAR);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.METEORITE, 4);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.FURNACE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.PHASEBLADES;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.BLUE_PHASEBLADE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.METEORITE_BAR, 20);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.SAPPHIRE, 10);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.PHASEBLADES;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.RED_PHASEBLADE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.METEORITE_BAR, 20);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.RUBY, 10);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.PHASEBLADES;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.GREEN_PHASEBLADE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.METEORITE_BAR, 20);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.EMERALD, 10);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.PHASEBLADES;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.PURPLE_PHASEBLADE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.METEORITE_BAR, 20);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.AMETHYST, 10);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.PHASEBLADES;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.WHITE_PHASEBLADE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.METEORITE_BAR, 20);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.DIAMOND, 10);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.PHASEBLADES;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.YELLOW_PHASEBLADE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.METEORITE_BAR, 20);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.TOPAZ, 10);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.PHASESABERS;
			NewRecipe.CraftedItem.NetDefaults((int)EntityID.ItemID.BLUE_PHASESABER);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.BLUE_PHASEBLADE);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.CRYSTAL_SHARD, 50);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.PHASESABERS;
			NewRecipe.CraftedItem.NetDefaults((int)EntityID.ItemID.RED_PHASESABER);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.RED_PHASEBLADE);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.CRYSTAL_SHARD, 50);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.PHASESABERS;
			NewRecipe.CraftedItem.NetDefaults((int)EntityID.ItemID.GREEN_PHASESABER);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.GREEN_PHASEBLADE);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.CRYSTAL_SHARD, 50);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.PHASESABERS;
			NewRecipe.CraftedItem.NetDefaults((int)EntityID.ItemID.PURPLE_PHASESABER);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.PURPLE_PHASEBLADE);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.CRYSTAL_SHARD, 50);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.PHASESABERS;
			NewRecipe.CraftedItem.NetDefaults((int)EntityID.ItemID.WHITE_PHASESABER);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.WHITE_PHASEBLADE);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.CRYSTAL_SHARD, 50);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.PHASESABERS;
			NewRecipe.CraftedItem.NetDefaults((int)EntityID.ItemID.YELLOW_PHASESABER);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.YELLOW_PHASEBLADE);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.CRYSTAL_SHARD, 50);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.HAMAXES;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.METEOR_HAMAXE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.METEORITE_BAR, 35);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.MAGIC_GUNS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.SPACE_GUN);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.FLINTLOCK_PISTOL);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.METEORITE_BAR, 30);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.FALLEN_STAR, 10);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.REPEATERS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.STAR_CANNON);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.MINISHARK);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.METEORITE_BAR, 20);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.FALLEN_STAR, 5);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.HELMETS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.METEOR_HELMET);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.METEORITE_BAR, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.BODY;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.METEOR_SUIT);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.METEORITE_BAR, 30);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.LEGS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.METEOR_LEGGINGS);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.METEORITE_BAR, 25);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.HELMETS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.NECRO_HELMET);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.BONE, 40);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.COBWEB, 40);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.BODY;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.NECRO_BREASTPLATE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.BONE, 60);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.COBWEB, 50);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.LEGS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.NECRO_GREAVES);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.BONE, 50);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.COBWEB, 45);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.BROADSWORDS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.BLADE_OF_GRASS);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.JUNGLE_SPORES, 12);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.STINGER, 15);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.BOOMERANGS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.THORN_CHAKRAM);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.JUNGLE_SPORES, 6);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.STINGER, 15);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.GRAPPLING;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.IVY_WHIP);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.GRAPPLING_HOOK);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.JUNGLE_SPORES, 12);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.VINE, 3);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.HEADGEAR;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.JUNGLE_HAT);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.EMERALD, 1);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.SAPPHIRE, 1);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.JUNGLE_SPORES, 8);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.BODY;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.JUNGLE_SHIRT);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.RUBY, 1);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.DIAMOND, 1);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.JUNGLE_SPORES, 16);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.STINGER, 12);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.LEGS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.JUNGLE_PANTS);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.AMETHYST, 1);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.TOPAZ, 1);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.JUNGLE_SPORES, 8);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.VINE, 2);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.BARS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.HELLSTONE_BAR);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.HELLSTONE, 4);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.OBSIDIAN, 1);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.HELLFORGE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.BOOMERANGS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.FLAMARANG);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.HELLSTONE_BAR, 15);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.ENCHANTED_BOOMERANG);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.BOWS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MOLTEN_FURY);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.HELLSTONE_BAR, 25);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.BROADSWORDS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.FIERY_GREATSWORD);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.HELLSTONE_BAR, 35);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.PICKAXES;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MOLTEN_PICKAXE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.HELLSTONE_BAR, 35);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.HAMAXES;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MOLTEN_HAMAXE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.HELLSTONE_BAR, 35);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.GUNS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.PHOENIX_BLASTER);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.HELLSTONE_BAR, 20);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.HANDGUN);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.HELMETS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MOLTEN_HELMET);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.HELLSTONE_BAR, 25);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.BODY;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MOLTEN_BREASTPLATE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.HELLSTONE_BAR, 35);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.LEGS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MOLTEN_GREAVES);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.HELLSTONE_BAR, 30);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.BROADSWORDS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.NIGHTS_EDGE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.LIGHTS_BANE);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.MURAMASA);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.BLADE_OF_GRASS);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.FIERY_GREATSWORD);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.DEMON_ALTAR;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.FLAILS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.DAO_OF_POW);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.DARK_SHARD);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.LIGHT_SHARD);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.SOUL_OF_NIGHT, 10);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.SOUL_OF_LIGHT, 10);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.BARS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.COBALT_BAR);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COBALT_ORE, 3);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.FURNACE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.HELMETS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.COBALT_HELMET);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COBALT_BAR, 10);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.MASKS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.COBALT_MASK);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COBALT_BAR, 10);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.HEADGEAR;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.COBALT_HAT);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COBALT_BAR, 10);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.BODY;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.COBALT_BREASTPLATE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COBALT_BAR, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.LEGS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.COBALT_LEGGINGS);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COBALT_BAR, 15);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.DRILLS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.COBALT_DRILL);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COBALT_BAR, 15);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.CHAINSAWS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.COBALT_CHAINSAW);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COBALT_BAR, 10);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.REPEATERS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.COBALT_REPEATER);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COBALT_BAR, 10);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.SWORDS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.COBALT_SWORD);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COBALT_BAR, 10);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.SPEARS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.COBALT_NAGINATA);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COBALT_BAR, 10);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.BARS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MYTHRIL_BAR);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.MYTHRIL_ORE, 4);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.FURNACE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.HELMETS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MYTHRIL_HELMET);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.MYTHRIL_BAR, 10);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.HELMETS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MYTHRIL_HAT);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.MYTHRIL_BAR, 10);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.HEADGEAR;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MYTHRIL_HOOD);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.MYTHRIL_BAR, 10);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.BODY;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MYTHRIL_CHAINMAIL);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.MYTHRIL_BAR, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.LEGS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MYTHRIL_GREAVES);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.MYTHRIL_BAR, 15);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.DRILLS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MYTHRIL_DRILL);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.MYTHRIL_BAR, 15);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.CHAINSAWS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MYTHRIL_CHAINSAW);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.MYTHRIL_BAR, 10);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.REPEATERS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MYTHRIL_REPEATER);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.MYTHRIL_BAR, 10);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.SWORDS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MYTHRIL_SWORD);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.MYTHRIL_BAR, 10);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.SPEARS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MYTHRIL_HALBERD);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.MYTHRIL_BAR, 10);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.ANVILS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MYTHRIL_ANVIL);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.MYTHRIL_BAR, 10);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.BARS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.ADAMANTITE_BAR);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.ADAMANTITE_ORE, 5);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ADAMANTITE_FORGE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.HELMETS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.ADAMANTITE_HELMET);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.ADAMANTITE_BAR, 12);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.MASKS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.ADAMANTITE_MASK);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.ADAMANTITE_BAR, 12);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.HEADGEAR;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.ADAMANTITE_HEADGEAR);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.ADAMANTITE_BAR, 12);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.BODY;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.ADAMANTITE_BREASTPLATE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.ADAMANTITE_BAR, 24);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.LEGS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.ADAMANTITE_LEGGINGS);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.ADAMANTITE_BAR, 18);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.DRILLS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.ADAMANTITE_DRILL);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.ADAMANTITE_BAR, 18);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.CHAINSAWS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.ADAMANTITE_CHAINSAW);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.ADAMANTITE_BAR, 12);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.REPEATERS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.ADAMANTITE_REPEATER);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.ADAMANTITE_BAR, 12);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.SWORDS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.ADAMANTITE_SWORD);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.ADAMANTITE_BAR, 12);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.SPEARS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.ADAMANTITE_GLAIVE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.ADAMANTITE_BAR, 12);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.CRAFTING_STATIONS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.ADAMANTITE_FORGE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.ADAMANTITE_ORE, 30);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.HELLFORGE);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.MASKS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.HALLOWED_MASK);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COBALT_HELMET);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.MYTHRIL_HELMET);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.ADAMANTITE_HELMET);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.SOUL_OF_SIGHT, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.HEADGEAR;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.HALLOWED_HEADGEAR);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COBALT_HAT);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.MYTHRIL_HOOD);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.ADAMANTITE_HEADGEAR);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.SOUL_OF_SIGHT, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.HELMETS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.HALLOWED_HELMET);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COBALT_MASK);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.MYTHRIL_HAT);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.ADAMANTITE_MASK);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.SOUL_OF_SIGHT, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.BODY;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.HALLOWED_PLATE_MAIL);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COBALT_BREASTPLATE);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.MYTHRIL_CHAINMAIL);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.ADAMANTITE_BREASTPLATE);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.SOUL_OF_MIGHT, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.LEGS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.HALLOWED_GREAVES);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COBALT_LEGGINGS);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.MYTHRIL_GREAVES);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.ADAMANTITE_LEGGINGS);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.SOUL_OF_FRIGHT, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.HAMDRAX);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COBALT_DRILL);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.MYTHRIL_DRILL);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.ADAMANTITE_DRILL);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.COBALT_CHAINSAW);
			NewRecipe.RequiredItem[4].SetDefaults((int)EntityID.ItemID.MYTHRIL_CHAINSAW);
			NewRecipe.RequiredItem[5].SetDefaults((int)EntityID.ItemID.ADAMANTITE_CHAINSAW);
			NewRecipe.RequiredItem[6].SetDefaults((int)EntityID.ItemID.SOUL_OF_FRIGHT, 5);
			NewRecipe.RequiredItem[7].SetDefaults((int)EntityID.ItemID.SOUL_OF_MIGHT, 5);
			NewRecipe.RequiredItem[8].SetDefaults((int)EntityID.ItemID.SOUL_OF_SIGHT, 5);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.REPEATERS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.HALLOWED_REPEATER);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COBALT_REPEATER);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.MYTHRIL_REPEATER);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.ADAMANTITE_REPEATER);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.SOUL_OF_SIGHT, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.SWORDS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.EXCALIBUR);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COBALT_SWORD);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.MYTHRIL_SWORD);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.ADAMANTITE_SWORD);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.SOUL_OF_MIGHT, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.SPEARS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.GUNGNIR);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COBALT_NAGINATA);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.MYTHRIL_HALBERD);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.ADAMANTITE_GLAIVE);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.SOUL_OF_FRIGHT, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.REPEATERS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MEGASHARK);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.MINISHARK);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.ILLEGAL_GUN_PARTS);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.SHARK_FIN, 5);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.SOUL_OF_MIGHT, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.BOOMERANGS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.LIGHT_DISC);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COBALT_BAR, 10);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.MYTHRIL_BAR, 10);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.SOUL_OF_LIGHT, 5);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.SOUL_OF_MIGHT, 5);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.REPEATERS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.FLAMETHROWER);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COPPER_BAR, 20);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.IRON_BAR, 20);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.ILLEGAL_GUN_PARTS);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.CURSED_FLAME, 35);
			NewRecipe.RequiredItem[4].SetDefaults((int)EntityID.ItemID.SOUL_OF_FRIGHT, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MAGICAL_HARP);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.HARP);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.CRYSTAL_SHARD, 25);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.SOUL_OF_NIGHT, 15);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.GOLD_BAR, 15);
			NewRecipe.RequiredItem[4].SetDefaults((int)EntityID.ItemID.SOUL_OF_SIGHT, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.MISC;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.FAIRY_BELL);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.BELL);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.PIXIE_DUST, 80);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.SOUL_OF_LIGHT, 15);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.GOLD_BAR, 15);
			NewRecipe.RequiredItem[4].SetDefaults((int)EntityID.ItemID.SOUL_OF_SIGHT, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.MISC;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.NEPTUNES_SHELL);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.CORAL, 15);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.SHARK_FIN, 5);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.GOLDFISH, 15);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.SOUL_OF_LIGHT, 5);
			NewRecipe.RequiredItem[4].SetDefaults((int)EntityID.ItemID.SOUL_OF_NIGHT, 5);
			NewRecipe.RequiredItem[5].SetDefaults((int)EntityID.ItemID.SOUL_OF_FRIGHT, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.RAINBOW_ROD);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.CRYSTAL_SHARD, 30);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.UNICORN_HORN, 4);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.PIXIE_DUST, 60);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.SOUL_OF_LIGHT, 10);
			NewRecipe.RequiredItem[4].SetDefaults((int)EntityID.ItemID.SOUL_OF_SIGHT, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.WINGS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.ANGEL_WINGS);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.FEATHER, 10);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.SOUL_OF_FLIGHT, 25);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.SOUL_OF_LIGHT, 30);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.WINGS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.DEMON_WINGS);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.FEATHER, 10);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.SOUL_OF_FLIGHT, 25);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.SOUL_OF_NIGHT, 30);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.DIVING_GEAR);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.FLIPPER);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.DIVING_HELMET);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.TINKERERS_WORKSHOP;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.MISC;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.GPS);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.GOLD_WATCH);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.DEPTH_METER);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.COMPASS);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.TINKERERS_WORKSHOP;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.MISC;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.OBSIDIAN_HORSESHOE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.LUCKY_HORSESHOE);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.OBSIDIAN_SKULL);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.TINKERERS_WORKSHOP;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.OBSIDIAN_SHIELD);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COBALT_SHIELD);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.OBSIDIAN_SKULL);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.TINKERERS_WORKSHOP;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.MISC;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.CLOUD_IN_A_BALLOON);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.CLOUD_IN_A_BOTTLE);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.SHINY_RED_BALLOON);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.TINKERERS_WORKSHOP;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.BOOTS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.SPECTRE_BOOTS);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.HERMES_BOOTS);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.ROCKET_BOOTS);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.TINKERERS_WORKSHOP;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.MISC;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MANA_FLOWER);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.NATURES_GIFT);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.MANA_POTION);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.TINKERERS_WORKSHOP;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.MECHANISM;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.ACTIVE_STONE_BLOCK);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.STONE_BLOCK);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.WIRE);
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.MECHANISM;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.INACTIVE_STONE_BLOCK);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.STONE_WALL, 4);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.WIRE);
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.MECHANISM;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.EXPLOSIVES);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.DYNAMITE, 3);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.WIRE);
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.PUMPS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.INLET_PUMP);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.IRON_BAR, 10);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.WIRE, 2);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.PUMPS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.OUTLET_PUMP);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.IRON_BAR, 10);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.WIRE, 2);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.TIMERS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.ONE_SECOND_TIMER);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.GOLD_WATCH);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.IRON_BAR, 5);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.WIRE, 1);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.TIMERS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.THREE_SECOND_TIMER);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.SILVER_WATCH);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.IRON_BAR, 5);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.WIRE, 1);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.TIMERS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.FIVE_SECOND_TIMER);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COPPER_WATCH);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.IRON_BAR, 5);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.WIRE, 1);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.BOULDER);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.STONE_BLOCK, 6);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.TINKERERS_WORKSHOP;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.MISC;
			NewRecipe.RecipeSubCategory = SubCategory.MUSICBOXES;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MUSIC_BOX_TITLE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.MUSIC_BOX_OVERWORLD_DAY);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.MUSIC_BOX_EERIE);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.MUSIC_BOX_NIGHT);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.MUSIC_BOX_UNDERGROUND);
			NewRecipe.RequiredItem[4].SetDefaults((int)EntityID.ItemID.MUSIC_BOX_BOSS1);
			NewRecipe.RequiredItem[5].SetDefaults((int)EntityID.ItemID.MUSIC_BOX_JUNGLE);
			NewRecipe.RequiredItem[6].SetDefaults((int)EntityID.ItemID.MUSIC_BOX_CORRUPTION);
			NewRecipe.RequiredItem[7].SetDefaults((int)EntityID.ItemID.MUSIC_BOX_UNDERGROUND_CORRUPTION);
			NewRecipe.RequiredItem[8].SetDefaults((int)EntityID.ItemID.MUSIC_BOX_THE_HALLOW);
			NewRecipe.RequiredItem[9].SetDefaults((int)EntityID.ItemID.MUSIC_BOX_BOSS2);
			NewRecipe.RequiredItem[10].SetDefaults((int)EntityID.ItemID.MUSIC_BOX_UNDERGROUND_HALLOW);
			NewRecipe.RequiredItem[11].SetDefaults((int)EntityID.ItemID.MUSIC_BOX_BOSS3);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.TINKERERS_WORKSHOP;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.MISC;
			NewRecipe.RecipeSubCategory = SubCategory.MUSICBOXES;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MUSIC_BOX_TUTORIAL);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.MUSIC_BOX_DESERT);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.MUSIC_BOX_SPACE);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.MUSIC_BOX_BOSS4);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.MUSIC_BOX_OCEAN);
			NewRecipe.RequiredItem[4].SetDefaults((int)EntityID.ItemID.MUSIC_BOX_SNOW);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.TINKERERS_WORKSHOP;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.MISC;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.DEPTH_METER);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.COPPER_BAR, 10);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.SILVER_BAR, 8);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.GOLD_BAR, 6);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.TABLE;
			NewRecipe.RequiredTile[1] = (int)EntityID.TileID.CHAIR;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.MISC;
			NewRecipe.RecipeSubCategory = SubCategory.SKULLS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.OBSIDIAN_SKULL);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.OBSIDIAN, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.FURNACE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.SPELLS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.CRYSTAL_STORM);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.SPELL_TOME);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.CRYSTAL_SHARD, 30);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.SOUL_OF_LIGHT, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.BOOKCASE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.SPELLS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.CURSED_FLAMES);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.SPELL_TOME);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.CURSED_FLAME, 30);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.SOUL_OF_NIGHT, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.BOOKCASE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.GUNS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.SANDGUN);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.ILLEGAL_GUN_PARTS);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.ANTLION_MANDIBLE, 10);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.TOPAZ, 5);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.FURNACE;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.GOGGLES;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.GOGGLES);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.LENS, 2);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			NewRecipe.RequiredTile[1] = (int)EntityID.TileID.CHAIR;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.GOGGLES;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.SUNGLASSES);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.BLACK_LENS, 2);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			NewRecipe.RequiredTile[1] = (int)EntityID.TileID.CHAIR;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.POTIONS;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MANA_CRYSTAL);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.FALLEN_STAR, 10);
			AddRecipe();

			NewRecipe.RecipeCategory = Category.MISC;
			NewRecipe.RecipeSubCategory = SubCategory.EYES;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.SUSPICIOUS_LOOKING_EYE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.LENS, 6);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.DEMON_ALTAR;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.MISC;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.WORM_FOOD);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.VILE_POWDER, 30);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.ROTTEN_CHUNK, 15);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.DEMON_ALTAR;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.MISC;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.SLIME_CROWN);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.GEL, 99);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.GOLD_CROWN);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.DEMON_ALTAR;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.MISC;
			NewRecipe.RecipeSubCategory = SubCategory.EYES;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MECHANICAL_EYE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.LENS, 3);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.COPPER_BAR, 5);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.IRON_BAR, 5);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.SOUL_OF_LIGHT, 7);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.MISC;
			NewRecipe.RecipeSubCategory = SubCategory.NONE;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MECHANICAL_WORM);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.ROTTEN_CHUNK, 6);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.COPPER_BAR, 5);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.IRON_BAR, 5);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.SOUL_OF_NIGHT, 7);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.MISC;
			NewRecipe.RecipeSubCategory = SubCategory.SKULLS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MECHANICAL_SKULL);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.BONE, 30);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.COPPER_BAR, 5);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.IRON_BAR, 5);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.SOUL_OF_LIGHT, 5);
			NewRecipe.RequiredItem[4].SetDefaults((int)EntityID.ItemID.SOUL_OF_NIGHT, 5);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.MISC;
			NewRecipe.RecipeSubCategory = SubCategory.SKULLS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.SUSPICIOUS_LOOKING_SKULL);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.MECHANICAL_EYE, 2);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.MECHANICAL_SKULL, 1);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.ADAMANTITE_BAR, 20);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.SOUL_OF_NIGHT, 10);
			NewRecipe.RequiredItem[4].SetDefaults((int)EntityID.ItemID.SOUL_OF_LIGHT, 10);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.MASKS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.DRAGON_MASK);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.HALLOWED_MASK, 1);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.COBALT_HELMET, 1);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.MYTHRIL_HELMET, 1);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.ADAMANTITE_HELMET, 1);
			NewRecipe.RequiredItem[4].SetDefaults((int)EntityID.ItemID.SOUL_OF_BLIGHT, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.BODY;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.DRAGON_BREASTPLATE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.HALLOWED_PLATE_MAIL, 1);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.COBALT_BREASTPLATE, 1);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.MYTHRIL_CHAINMAIL, 1);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.ADAMANTITE_BREASTPLATE, 1);
			NewRecipe.RequiredItem[4].SetDefaults((int)EntityID.ItemID.SOUL_OF_MIGHT, 20);
			NewRecipe.RequiredItem[5].SetDefaults((int)EntityID.ItemID.SOUL_OF_BLIGHT, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.LEGS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.DRAGON_GREAVES);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.HALLOWED_GREAVES, 1);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.COBALT_LEGGINGS, 1);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.MYTHRIL_GREAVES, 1);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.ADAMANTITE_LEGGINGS, 1);
			NewRecipe.RequiredItem[4].SetDefaults((int)EntityID.ItemID.SOUL_OF_MIGHT, 20);
			NewRecipe.RequiredItem[5].SetDefaults((int)EntityID.ItemID.SOUL_OF_BLIGHT, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.HELMETS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.TITAN_HELMET);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.HALLOWED_HELMET, 1);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.COBALT_MASK, 1);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.MYTHRIL_HAT, 1);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.ADAMANTITE_MASK, 1);
			NewRecipe.RequiredItem[4].SetDefaults((int)EntityID.ItemID.SOUL_OF_BLIGHT, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.BODY;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.TITAN_MAIL);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.HALLOWED_PLATE_MAIL, 1);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.COBALT_BREASTPLATE, 1);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.MYTHRIL_CHAINMAIL, 1);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.ADAMANTITE_BREASTPLATE, 1);
			NewRecipe.RequiredItem[4].SetDefaults((int)EntityID.ItemID.SOUL_OF_SIGHT, 20);
			NewRecipe.RequiredItem[5].SetDefaults((int)EntityID.ItemID.SOUL_OF_BLIGHT, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.LEGS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.TITAN_LEGGINGS);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.HALLOWED_GREAVES, 1);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.COBALT_LEGGINGS, 1);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.MYTHRIL_GREAVES, 1);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.ADAMANTITE_LEGGINGS, 1);
			NewRecipe.RequiredItem[4].SetDefaults((int)EntityID.ItemID.SOUL_OF_SIGHT, 20);
			NewRecipe.RequiredItem[5].SetDefaults((int)EntityID.ItemID.SOUL_OF_BLIGHT, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.HEADGEAR;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.SPECTRAL_HEADGEAR);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.HALLOWED_HEADGEAR, 1);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.COBALT_HAT, 1);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.MYTHRIL_HOOD, 1);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.ADAMANTITE_HEADGEAR, 1);
			NewRecipe.RequiredItem[4].SetDefaults((int)EntityID.ItemID.SOUL_OF_BLIGHT, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.BODY;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.SPECTRAL_ARMOR);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.HALLOWED_PLATE_MAIL, 1);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.COBALT_BREASTPLATE, 1);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.MYTHRIL_CHAINMAIL, 1);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.ADAMANTITE_BREASTPLATE, 1);
			NewRecipe.RequiredItem[4].SetDefaults((int)EntityID.ItemID.SOUL_OF_FRIGHT, 20);
			NewRecipe.RequiredItem[5].SetDefaults((int)EntityID.ItemID.SOUL_OF_BLIGHT, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.LEGS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.SPECTRAL_SUBLIGAR);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.HALLOWED_GREAVES, 1);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.COBALT_LEGGINGS, 1);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.MYTHRIL_GREAVES, 1);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.ADAMANTITE_LEGGINGS, 1);
			NewRecipe.RequiredItem[4].SetDefaults((int)EntityID.ItemID.SOUL_OF_FRIGHT, 20);
			NewRecipe.RequiredItem[5].SetDefaults((int)EntityID.ItemID.SOUL_OF_BLIGHT, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.SWORDS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.TIZONA);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.EXCALIBUR, 2);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.SOUL_OF_BLIGHT, 15);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.ADAMANTITE_BAR, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.SPEARS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.TONBOGIRI);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.GUNGNIR, 2);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.SOUL_OF_BLIGHT, 15);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.ADAMANTITE_BAR, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.BOWS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.SHARANGA);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.MOLTEN_FURY, 2);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.HELLSTONE_BAR, 10);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.REPEATERS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.VULCAN_REPEATER);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.HALLOWED_REPEATER, 2);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.SOUL_OF_BLIGHT, 15);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.ADAMANTITE_BAR, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

#if VERSION_101
			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.WINGS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.SPARKLY_WINGS);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.FEATHER, 10);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.SOUL_OF_FLIGHT, 25);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.SOUL_OF_BLIGHT, 30);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.MYTHRIL_ANVIL;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.TORCHES;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.CAMPFIRE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.WOOD, 20);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.TORCH, 5);
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.HELMETS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.CACTUS_HELMET);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.CACTUS, 20);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.BODY;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.CACTUS_BREASTPLATE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.CACTUS, 30);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.ARMOR;
			NewRecipe.RecipeSubCategory = SubCategory.LEGS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.CACTUS_LEGGINGS);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.CACTUS, 25);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.WEAPONS;
			NewRecipe.RecipeSubCategory = SubCategory.SWORDS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.CACTUS_SWORD);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.CACTUS, 10);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.TOOLS;
			NewRecipe.RecipeSubCategory = SubCategory.PICKAXES;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.CACTUS_PICKAXE);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.CACTUS, 15);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.WALLS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.PURPLE_STAINED_GLASS_WALL, 20);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.GLASS_WALL, 20);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.AMETHYST);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.WALLS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.YELLOW_STAINED_GLASS_WALL, 20);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.GLASS_WALL, 20);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.TOPAZ);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.WALLS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.BLUE_STAINED_GLASS_WALL, 20);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.GLASS_WALL, 20);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.SAPPHIRE);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.WALLS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.GREEN_STAINED_GLASS_WALL, 20);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.GLASS_WALL, 20);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.EMERALD);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.WALLS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.RED_STAINED_GLASS_WALL, 20);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.GLASS_WALL, 20);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.RUBY);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();

			NewRecipe.RecipeCategory = Category.STRUCTURES;
			NewRecipe.RecipeSubCategory = SubCategory.WALLS;
			NewRecipe.CraftedItem.SetDefaults((int)EntityID.ItemID.MULTICOLORED_STAINED_GLASS_WALL, 50);
			NewRecipe.RequiredItem[0].SetDefaults((int)EntityID.ItemID.GLASS_WALL, 50);
			NewRecipe.RequiredItem[1].SetDefaults((int)EntityID.ItemID.AMETHYST);
			NewRecipe.RequiredItem[2].SetDefaults((int)EntityID.ItemID.TOPAZ);
			NewRecipe.RequiredItem[3].SetDefaults((int)EntityID.ItemID.SAPPHIRE);
			NewRecipe.RequiredItem[4].SetDefaults((int)EntityID.ItemID.EMERALD);
			NewRecipe.RequiredItem[5].SetDefaults((int)EntityID.ItemID.RUBY);
			NewRecipe.RequiredTile[0] = (int)EntityID.TileID.WORK_BENCH;
			AddRecipe();
#endif

			for (int RecipeIdx = 0; RecipeIdx < NumRecipes; RecipeIdx++)
			{
				for (int ItemSlot = 0; ItemSlot < MaxItemRequirements && Main.ActiveRecipe[RecipeIdx].RequiredItem[ItemSlot].Type > 0; ItemSlot++)
				{
					Main.ActiveRecipe[RecipeIdx].RequiredItem[ItemSlot].CheckMaterial();
				}
				Main.ActiveRecipe[RecipeIdx].CraftedItem.CheckMaterial();
			}
		}

		private static void AddRecipe()
		{
			for (int ItemSlot = 0; ItemSlot < MaxItemRequirements && NewRecipe.RequiredItem[ItemSlot].Type > 0; ItemSlot++)
			{
				NewRecipe.NumRequiredItems++;
			}
			for (int TileSlot = 0; TileSlot < MaxTileRequirements && NewRecipe.RequiredTile[TileSlot] >= 0; TileSlot++)
			{
				NewRecipe.NumRequiredTiles++;
			}
			Main.ActiveRecipe[NumRecipes++] = NewRecipe;
			NewRecipe = new Recipe();
		}
	}
}