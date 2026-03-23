using Microsoft.Xna.Framework;
using System;

namespace Terraria
{
	public struct Item
	{
		public const int MaxNumItemTypes = (int)EntityID.ItemID.NUM_TYPES;

		public const uint PotionDelay = 3600u;

		public const uint PotionDelayPhilosopher = 2700u;

		public static short[] HeadType = new short[Player.MaxNumArmorHead];

		public static short[] BodyType = new short[Player.MaxNumArmorBody];

		public static short[] LegType = new short[Player.MaxNumArmorLegs];

		public short Type;

		public byte Active;

		public bool BeingGrabbed;

		public bool WornArmor;

		public bool Mech;

		public bool IsWet;

		public byte WetCount;

		public bool IsInLava;

		public bool Channelling;

		public bool IsAccessory;

		public bool IsPotion;

		public bool IsConsumable;

		public bool AutoReuse;

		public bool CanUseTurn;

		public bool OnlyBuyOnce;

		public bool NoUseGraphic;

		public bool NoMelee;

		public bool CanBuy;

		public bool IsSocial;

		public bool IsVanity;

		public bool IsMaterial;

		public bool CantTouchLiquid;

		public bool IsMelee;

		public bool IsMagic;

		public bool IsRanged;

		public byte PrefixType;

		public byte NoGrabDelay;

		public byte HoldStyle;

		public byte UseStyle;

		public byte UseAnimation;

		public byte UseTime;

		public byte PickPower;

		public byte AxePower;

		public byte HammerPower;

		public sbyte TileBoost;

		public byte PlaceStyle;

		public byte Alpha;

		public byte Owner;

		public byte OwnIgnore;

		public byte OwnTime;

		public byte KeepTime;

		public byte UseSound;

		public short Stack;

		public short MaxStack;

		public short CreateTile;

		public short CreateWall;

		public short Damage;

		public short HealLife;

		public short HealMana;

		public uint SpawnTime;

		public ushort Width;

		public ushort Height;

		public Vector2 Position;

		public Vector2 Velocity;

		public float Knockback;

		public Color Colour;

		public float Scale;

		public short Defense;

		public short HeadSlot;

		public short BodySlot;

		public short LegSlot;

		public ushort BuffTime;

		public byte BuffType;

		public byte ReuseDelay;

		public short NetID;

		public short Crit;

		public sbyte Rarity;

		public byte Ammo;

		public byte UseAmmo;

		public byte Shoot;

		public float ShootSpeed;

		public byte LifeRegen;

		public byte Mana;

		public ushort Release;

		public int Value;

		private static readonly EntityID.PrefixID[] ToolPrefixs = new EntityID.PrefixID[40]
		{
			EntityID.PrefixID.LARGE,
			EntityID.PrefixID.MASSIVE,
			EntityID.PrefixID.DANGEROUS,
			EntityID.PrefixID.SAVAGE,
			EntityID.PrefixID.SHARP,
			EntityID.PrefixID.POINTY,
			EntityID.PrefixID.TINY,
			EntityID.PrefixID.TERRIBLE,
			EntityID.PrefixID.SMALL,
			EntityID.PrefixID.DULL,
			EntityID.PrefixID.UNHAPPY,
			EntityID.PrefixID.BULKY,
			EntityID.PrefixID.SHAMEFUL,
			EntityID.PrefixID.HEAVY,
			EntityID.PrefixID.LIGHT,
			EntityID.PrefixID.KEEN,
			EntityID.PrefixID.SUPERIOR,
			EntityID.PrefixID.FORCEFUL,
			EntityID.PrefixID.HURTFUL,
			EntityID.PrefixID.STRONG,
			EntityID.PrefixID.UNPLEASANT,
			EntityID.PrefixID.BROKEN,
			EntityID.PrefixID.DAMAGED,
			EntityID.PrefixID.WEAK,
			EntityID.PrefixID.SHODDY,
			EntityID.PrefixID.RUTHLESS,
			EntityID.PrefixID.QUICK,
			EntityID.PrefixID.DEADLY2,
			EntityID.PrefixID.AGILE,
			EntityID.PrefixID.NIMBLE,
			EntityID.PrefixID.MURDEROUS,
			EntityID.PrefixID.SLOW,
			EntityID.PrefixID.SLUGGISH,
			EntityID.PrefixID.LAZY,
			EntityID.PrefixID.ANNOYING,
			EntityID.PrefixID.NASTY,
			EntityID.PrefixID.GODLY,
			EntityID.PrefixID.DEMONIC,
			EntityID.PrefixID.ZEALOUS,
			EntityID.PrefixID.LEGENDARY,
			// EntityID.PrefixID.PIERCING
		};

		private static readonly EntityID.PrefixID[] SpearPrefixs = new EntityID.PrefixID[14]
		{
			EntityID.PrefixID.KEEN,
			EntityID.PrefixID.SUPERIOR,
			EntityID.PrefixID.FORCEFUL,
			EntityID.PrefixID.HURTFUL,
			EntityID.PrefixID.STRONG,
			EntityID.PrefixID.UNPLEASANT,
			EntityID.PrefixID.BROKEN,
			EntityID.PrefixID.DAMAGED,
			EntityID.PrefixID.WEAK,
			EntityID.PrefixID.SHODDY,
			EntityID.PrefixID.RUTHLESS,
			EntityID.PrefixID.GODLY,
			EntityID.PrefixID.DEMONIC,
			EntityID.PrefixID.ZEALOUS,
			// EntityID.PrefixID.PIERCING
		};

		private static readonly EntityID.PrefixID[] GunPrefixs = new EntityID.PrefixID[36]
		{
			EntityID.PrefixID.SIGHTED,
			EntityID.PrefixID.RAPID,
			EntityID.PrefixID.HASTY,
			EntityID.PrefixID.INTIMIDATING,
			EntityID.PrefixID.DEADLY,
			EntityID.PrefixID.STAUNCH,
			EntityID.PrefixID.AWFUL,
			EntityID.PrefixID.LETHARGIC,
			EntityID.PrefixID.AWKWARD,
			EntityID.PrefixID.POWERFUL,
			EntityID.PrefixID.FRENZYING,
			EntityID.PrefixID.KEEN,
			EntityID.PrefixID.SUPERIOR,
			EntityID.PrefixID.FORCEFUL,
			EntityID.PrefixID.HURTFUL,
			EntityID.PrefixID.STRONG,
			EntityID.PrefixID.UNPLEASANT,
			EntityID.PrefixID.BROKEN,
			EntityID.PrefixID.DAMAGED,
			EntityID.PrefixID.WEAK,
			EntityID.PrefixID.SHODDY,
			EntityID.PrefixID.RUTHLESS,
			EntityID.PrefixID.QUICK,
			EntityID.PrefixID.DEADLY2,
			EntityID.PrefixID.AGILE,
			EntityID.PrefixID.NIMBLE,
			EntityID.PrefixID.MURDEROUS,
			EntityID.PrefixID.SLOW,
			EntityID.PrefixID.SLUGGISH,
			EntityID.PrefixID.LAZY,
			EntityID.PrefixID.ANNOYING,
			EntityID.PrefixID.NASTY,
			EntityID.PrefixID.GODLY,
			EntityID.PrefixID.DEMONIC,
			EntityID.PrefixID.ZEALOUS,
			EntityID.PrefixID.UNREAL
		};

		private static readonly EntityID.PrefixID[] MagicPrefixs = new EntityID.PrefixID[36]
		{
			EntityID.PrefixID.MYSTIC,
			EntityID.PrefixID.ADEPT,
			EntityID.PrefixID.MASTERFUL,
			EntityID.PrefixID.INEPT,
			EntityID.PrefixID.IGNORANT,
			EntityID.PrefixID.DERANGED,
			EntityID.PrefixID.INTENSE,
			EntityID.PrefixID.TABOO,
			EntityID.PrefixID.CELESTIAL,
			EntityID.PrefixID.FURIOUS,
			EntityID.PrefixID.MANIC,
			EntityID.PrefixID.KEEN,
			EntityID.PrefixID.SUPERIOR,
			EntityID.PrefixID.FORCEFUL,
			EntityID.PrefixID.HURTFUL,
			EntityID.PrefixID.STRONG,
			EntityID.PrefixID.UNPLEASANT,
			EntityID.PrefixID.BROKEN,
			EntityID.PrefixID.DAMAGED,
			EntityID.PrefixID.WEAK,
			EntityID.PrefixID.SHODDY,
			EntityID.PrefixID.RUTHLESS,
			EntityID.PrefixID.QUICK,
			EntityID.PrefixID.DEADLY2,
			EntityID.PrefixID.AGILE,
			EntityID.PrefixID.NIMBLE,
			EntityID.PrefixID.MURDEROUS,
			EntityID.PrefixID.SLOW,
			EntityID.PrefixID.SLUGGISH,
			EntityID.PrefixID.LAZY,
			EntityID.PrefixID.ANNOYING,
			EntityID.PrefixID.NASTY,
			EntityID.PrefixID.GODLY,
			EntityID.PrefixID.DEMONIC,
			EntityID.PrefixID.ZEALOUS,
			EntityID.PrefixID.MYTHICAL,
			// EntityID.PrefixID.PIERCING
		};

		private static readonly EntityID.PrefixID[] BoomerangPrefixs = new EntityID.PrefixID[14] // This is identical to SpearPrefixs, not sure why they did not just merge the two.
		{
			EntityID.PrefixID.KEEN,
			EntityID.PrefixID.SUPERIOR,
			EntityID.PrefixID.FORCEFUL,
			EntityID.PrefixID.HURTFUL,
			EntityID.PrefixID.STRONG,
			EntityID.PrefixID.UNPLEASANT,
			EntityID.PrefixID.BROKEN,
			EntityID.PrefixID.DAMAGED,
			EntityID.PrefixID.WEAK,
			EntityID.PrefixID.SHODDY,
			EntityID.PrefixID.RUTHLESS,
			EntityID.PrefixID.GODLY,
			EntityID.PrefixID.DEMONIC,
			EntityID.PrefixID.ZEALOUS,
			// EntityID.PrefixID.PIERCING
		};

#if !USE_ORIGINAL_CODE
		public static readonly EntityID.ItemID[] ArmorIDs =
		{
			EntityID.ItemID.MINING_HELMET,
			EntityID.ItemID.MINING_SHIRT,
			EntityID.ItemID.MINING_PANTS,

#if VERSION_103 || VERSION_FINAL // BUG: In 1.01, they added Cactus and Wood as armours from PC 1.2, but they didn't account for the armour achievement until Console 1.2.
			EntityID.ItemID.WOOD_HELMET,
			EntityID.ItemID.WOOD_BREASTPLATE,
			EntityID.ItemID.WOOD_GREAVES,
			EntityID.ItemID.CACTUS_HELMET,
			EntityID.ItemID.CACTUS_BREASTPLATE,
			EntityID.ItemID.CACTUS_LEGGINGS,
#endif

			EntityID.ItemID.COPPER_HELMET,
			EntityID.ItemID.COPPER_CHAINMAIL,
			EntityID.ItemID.COPPER_GREAVES,
			EntityID.ItemID.IRON_HELMET,
			EntityID.ItemID.IRON_CHAINMAIL,
			EntityID.ItemID.IRON_GREAVES,
			EntityID.ItemID.SILVER_HELMET,
			EntityID.ItemID.SILVER_CHAINMAIL,
			EntityID.ItemID.SILVER_GREAVES,
			EntityID.ItemID.GOLD_HELMET,
			EntityID.ItemID.GOLD_CHAINMAIL,
			EntityID.ItemID.GOLD_GREAVES,
			EntityID.ItemID.METEOR_HELMET,
			EntityID.ItemID.METEOR_SUIT,
			EntityID.ItemID.METEOR_LEGGINGS,
			EntityID.ItemID.SHADOW_HELMET,
			EntityID.ItemID.SHADOW_SCALEMAIL,
			EntityID.ItemID.SHADOW_GREAVES,
			EntityID.ItemID.JUNGLE_HAT,
			EntityID.ItemID.JUNGLE_SHIRT,
			EntityID.ItemID.JUNGLE_PANTS,
			EntityID.ItemID.NECRO_HELMET,
			EntityID.ItemID.NECRO_BREASTPLATE,
			EntityID.ItemID.NECRO_GREAVES,
			EntityID.ItemID.MOLTEN_HELMET,
			EntityID.ItemID.MOLTEN_BREASTPLATE,
			EntityID.ItemID.MOLTEN_GREAVES,
			EntityID.ItemID.COBALT_HAT,
			EntityID.ItemID.COBALT_HELMET,
			EntityID.ItemID.COBALT_MASK,
			EntityID.ItemID.COBALT_BREASTPLATE,
			EntityID.ItemID.COBALT_LEGGINGS,
			EntityID.ItemID.MYTHRIL_HOOD,
			EntityID.ItemID.MYTHRIL_HELMET,
			EntityID.ItemID.MYTHRIL_HAT,
			EntityID.ItemID.MYTHRIL_CHAINMAIL,
			EntityID.ItemID.MYTHRIL_GREAVES,
			EntityID.ItemID.ADAMANTITE_HEADGEAR,
			EntityID.ItemID.ADAMANTITE_MASK,
			EntityID.ItemID.ADAMANTITE_HELMET,
			EntityID.ItemID.ADAMANTITE_BREASTPLATE,
			EntityID.ItemID.ADAMANTITE_LEGGINGS,
			EntityID.ItemID.HALLOWED_HEADGEAR,
			EntityID.ItemID.HALLOWED_MASK,
			EntityID.ItemID.HALLOWED_HELMET,
			EntityID.ItemID.HALLOWED_PLATE_MAIL,
			EntityID.ItemID.HALLOWED_GREAVES,
			EntityID.ItemID.DRAGON_MASK,
			EntityID.ItemID.DRAGON_BREASTPLATE,
			EntityID.ItemID.DRAGON_GREAVES,
			EntityID.ItemID.TITAN_HELMET,
			EntityID.ItemID.TITAN_MAIL,
			EntityID.ItemID.TITAN_LEGGINGS,
			EntityID.ItemID.SPECTRAL_HEADGEAR,
			EntityID.ItemID.SPECTRAL_ARMOR,
			EntityID.ItemID.SPECTRAL_SUBLIGAR,
		};
#endif

		private static uint LastItemIndex = 0;

		public void Init()
		{
			Active = 0;
			Owner = 8;
			Type = 0;
			NetID = 0;
			PrefixType = 0;
			Crit = 0;
			WornArmor = false;
			Mech = false;
			ReuseDelay = 0;
			IsMelee = false;
			IsMagic = false;
			IsRanged = false;
			PlaceStyle = 0;
			BuffTime = 0;
			BuffType = 0;
			IsMaterial = false;
			CantTouchLiquid = false;
			IsVanity = false;
			Mana = 0;
			IsWet = false;
			WetCount = 0;
			IsInLava = false;
			Channelling = false;
			OnlyBuyOnce = false;
			IsSocial = false;
			Release = 0;
			NoMelee = false;
			NoUseGraphic = false;
			LifeRegen = 0;
			ShootSpeed = 0f;
			Alpha = 0;
			Ammo = 0;
			UseAmmo = 0;
			AutoReuse = false;
			IsAccessory = false;
			AxePower = 0;
			HealMana = 0;
			BodySlot = -1;
			LegSlot = -1;
			HeadSlot = -1;
			IsPotion = false;
			IsConsumable = false;
			CreateTile = -1;
			CreateWall = -1;
			Damage = 0;
			Defense = 0;
			HammerPower = 0;
			HealLife = 0;
			Knockback = 0f;
			PickPower = 0;
			Rarity = (sbyte)EntityID.RarityID.WHITE;
			Scale = 1f;
			Shoot = 0;
			Stack = 0;
			MaxStack = 0;
			TileBoost = 0;
			HoldStyle = 0;
			UseStyle = 0;
			UseSound = 0;
			UseTime = 100;
			UseAnimation = 100;
			Value = 0;
			CanUseTurn = false;
			CanBuy = false;
			OwnIgnore = 8;
			OwnTime = 0;
			KeepTime = 0;
		}

		public bool IsLocal()
		{
			if (Owner < 8)
			{
				return Main.PlayerSet[Owner].isLocal();
			}
			return false;
		}

		public bool IsEquipable()
		{
			if (!IsAccessory && HeadSlot < 0 && BodySlot < 0)
			{
				return LegSlot >= 0;
			}
			return true;
		}

		public bool SetPrefix(int Setting)
		{
			if (Setting == (byte)EntityID.PrefixID.NONE || Type == 0)
			{
				return false;
			}
			int PrefixID = Setting;
			float PrefixDamage = 1f;
			float PrefixKB = 1f;
			float PrefixDelay = 1f;
			float PrefixScale = 1f;
			float PrefixFireRate = 1f;
			float PrefixManaSave = 1f;
			int PrefixCrit = 0;
			bool flag = true;
			while (flag)
			{
				PrefixDamage = 1f;
				PrefixKB = 1f;
				PrefixDelay = 1f;
				PrefixScale = 1f;
				PrefixFireRate = 1f;
				PrefixManaSave = 1f;
				PrefixCrit = 0;
				flag = false;
				if (PrefixID == -1 && Main.Rand.Next(4) == 0)
				{
					PrefixID = (int)EntityID.PrefixID.NONE;
				}
				if (Setting < -1)
				{
					PrefixID = -1;
				}
				if (PrefixID == -1 || PrefixID == -2 || PrefixID == -3)
				{
					if (Array.BinarySearch(EntityID.ToolItems, (EntityID.ItemID)Type) >= 0)
					{
						PrefixID = (byte)ToolPrefixs[Main.Rand.Next(ToolPrefixs.Length)];
					}
					else if (Array.BinarySearch(EntityID.SpearItems, (EntityID.ItemID)Type) >= 0)
					{
						PrefixID = (byte)SpearPrefixs[Main.Rand.Next(SpearPrefixs.Length)];
					}
					else if (Array.BinarySearch(EntityID.GunItems, (EntityID.ItemID)Type) >= 0)
					{
						PrefixID = (byte)GunPrefixs[Main.Rand.Next(GunPrefixs.Length)];
					}
					else if (Array.BinarySearch(EntityID.MagicItems, (EntityID.ItemID)Type) >= 0)
					{
						PrefixID = (byte)MagicPrefixs[Main.Rand.Next(MagicPrefixs.Length)];
					}
					else if (Array.BinarySearch(EntityID.BoomerangItems, (EntityID.ItemID)Type) >= 0)
					{
						PrefixID = (byte)BoomerangPrefixs[Main.Rand.Next(BoomerangPrefixs.Length)];
					}
					else
					{
						if (!IsAccessory || Array.BinarySearch(EntityID.ExcludedEquips, (EntityID.ItemID)Type) >= 0)
						// BUG: Despite adding the checks for the cactus sword and pick, they do not exclude the exclusive music boxes in either 1.0 or 1.01. This means you can get accessory modifiers on the console music boxes.
						{
							return false;
						}
						PrefixID = Main.Rand.Next((byte)EntityID.PrefixID.HARD, (byte)EntityID.PrefixID.VIOLENT + 1);  // 62 to 80 inclusive marks the range of accessory prefixes.
					}
				}

				switch (Setting)
				{
					case -3:
						return true;
					case -1:
						// This part ensures that bad prefixes are less likely to appear than good ones upon crafting an item. This is done by giving them a 33% chance to appear when compared to other prefixes.
						// Fun fact: If you check the prefixes, you'll find that 'Annoying', which slows and weakens your weapon, is not included in this list. This is the case in every version of the game up to, and including PC 1.4.4.9.
						if ((Array.BinarySearch(EntityID.BadPrefixes, (EntityID.PrefixID)PrefixID) >= 0) && Main.Rand.Next(3) != 0)
						{
							PrefixID = (byte)EntityID.PrefixID.NONE;
						}
						break;
				}

				switch ((EntityID.PrefixID)PrefixID)
				{
					case EntityID.PrefixID.LARGE:
						PrefixScale = 1.12f;
						break;
					case EntityID.PrefixID.MASSIVE:
						PrefixScale = 1.18f;
						break;
					case EntityID.PrefixID.DANGEROUS:
						PrefixDamage = 1.05f;
						PrefixCrit = 2;
						PrefixScale = 1.05f;
						break;
					case EntityID.PrefixID.SAVAGE:
						PrefixDamage = 1.1f;
						PrefixScale = 1.1f;
						PrefixKB = 1.1f;
						break;
					case EntityID.PrefixID.SHARP:
						PrefixDamage = 1.15f;
						break;
					case EntityID.PrefixID.POINTY:
						PrefixDamage = 1.1f;
						break;
					case EntityID.PrefixID.TINY:
						PrefixScale = 0.82f;
						break;
					case EntityID.PrefixID.TERRIBLE:
						PrefixKB = 0.85f;
						PrefixDamage = 0.85f;
						PrefixScale = 0.87f;
						break;
					case EntityID.PrefixID.SMALL:
						PrefixScale = 0.9f;
						break;
					case EntityID.PrefixID.DULL:
						PrefixDamage = 0.85f;
						break;
					case EntityID.PrefixID.UNHAPPY:
						PrefixDelay = 1.1f;
						PrefixKB = 0.9f;
						PrefixScale = 0.9f;
						break;
					case EntityID.PrefixID.BULKY:
						PrefixKB = 1.1f;
						PrefixDamage = 1.05f;
						PrefixScale = 1.1f;
						PrefixDelay = 1.15f;
						break;
					case EntityID.PrefixID.SHAMEFUL:
						PrefixKB = 0.8f;
						PrefixDamage = 0.9f;
						PrefixScale = 1.1f;
						break;
					case EntityID.PrefixID.HEAVY:
						PrefixKB = 1.15f;
						PrefixDelay = 1.1f;
						break;
					case EntityID.PrefixID.LIGHT:
						PrefixKB = 0.9f;
						PrefixDelay = 0.85f;
						break;
					case EntityID.PrefixID.SIGHTED:
						PrefixDamage = 1.1f;
						PrefixCrit = 3;
						break;
					case EntityID.PrefixID.RAPID:
						PrefixDelay = 0.85f;
						PrefixFireRate = 1.1f;
						break;
					case EntityID.PrefixID.HASTY:
						PrefixDelay = 0.9f;
						PrefixFireRate = 1.15f;
						break;
					case EntityID.PrefixID.INTIMIDATING:
						PrefixKB = 1.15f;
						PrefixFireRate = 1.05f;
						break;
					case EntityID.PrefixID.DEADLY:
						PrefixKB = 1.05f;
						PrefixFireRate = 1.05f;
						PrefixDamage = 1.1f;
						PrefixDelay = 0.95f;
						PrefixCrit = 2;
						break;
					case EntityID.PrefixID.STAUNCH:
						PrefixKB = 1.15f;
						PrefixDamage = 1.1f;
						break;
					case EntityID.PrefixID.AWFUL:
						PrefixKB = 0.9f;
						PrefixFireRate = 0.9f;
						PrefixDamage = 0.85f;
						break;
					case EntityID.PrefixID.LETHARGIC:
						PrefixDelay = 1.15f;
						PrefixFireRate = 0.9f;
						break;
					case EntityID.PrefixID.AWKWARD:
						PrefixDelay = 1.1f;
						PrefixKB = 0.8f;
						break;
					case EntityID.PrefixID.POWERFUL:
						PrefixDelay = 1.1f;
						PrefixDamage = 1.15f;
						PrefixCrit = 1;
						break;
					case EntityID.PrefixID.MYSTIC:
						PrefixManaSave = 0.85f;
						PrefixDamage = 1.1f;
						break;
					case EntityID.PrefixID.ADEPT:
						PrefixManaSave = 0.85f;
						break;
					case EntityID.PrefixID.MASTERFUL:
						PrefixManaSave = 0.85f;
						PrefixDamage = 1.15f;
						PrefixKB = 1.05f;
						break;
					case EntityID.PrefixID.INEPT:
						PrefixManaSave = 1.1f;
						break;
					case EntityID.PrefixID.IGNORANT:
						PrefixManaSave = 1.2f;
						PrefixDamage = 0.9f;
						break;
					case EntityID.PrefixID.DERANGED:
						PrefixKB = 0.9f;
						PrefixDamage = 0.9f;
						break;
					case EntityID.PrefixID.INTENSE:
						PrefixManaSave = 1.15f;
						PrefixDamage = 1.1f;
						break;
					case EntityID.PrefixID.TABOO:
						PrefixManaSave = 1.1f;
						PrefixKB = 1.1f;
						PrefixDelay = 0.9f;
						break;
					case EntityID.PrefixID.CELESTIAL:
						PrefixManaSave = 0.9f;
						PrefixKB = 1.1f;
						PrefixDelay = 1.1f;
						PrefixDamage = 1.1f;
						break;
					case EntityID.PrefixID.FURIOUS:
						PrefixManaSave = 1.2f;
						PrefixDamage = 1.15f;
						PrefixKB = 1.15f;
						break;
					case EntityID.PrefixID.KEEN:
						PrefixCrit = 3;
						break;
					case EntityID.PrefixID.SUPERIOR:
						PrefixDamage = 1.1f;
						PrefixCrit = 3;
						PrefixKB = 1.1f;
						break;
					case EntityID.PrefixID.FORCEFUL:
						PrefixKB = 1.15f;
						break;
					case EntityID.PrefixID.BROKEN:
						PrefixDamage = 0.7f;
						PrefixKB = 0.8f;
						break;
					case EntityID.PrefixID.DAMAGED:
						PrefixDamage = 0.85f;
						break;
					case EntityID.PrefixID.SHODDY:
						PrefixKB = 0.85f;
						PrefixDamage = 0.9f;
						break;
					case EntityID.PrefixID.QUICK:
						PrefixDelay = 0.9f;
						break;
					case EntityID.PrefixID.DEADLY2:
						PrefixDamage = 1.1f;
						PrefixDelay = 0.9f;
						break;
					case EntityID.PrefixID.AGILE:
						PrefixDelay = 0.9f;
						PrefixCrit = 3;
						break;
					case EntityID.PrefixID.NIMBLE:
						PrefixDelay = 0.95f;
						break;
					case EntityID.PrefixID.MURDEROUS:
						PrefixCrit = 3;
						PrefixDelay = 0.94f;
						PrefixDamage = 1.07f;
						break;
					case EntityID.PrefixID.SLOW:
						PrefixDelay = 1.15f;
						break;
					case EntityID.PrefixID.SLUGGISH:
						PrefixDelay = 1.2f;
						break;
					case EntityID.PrefixID.LAZY:
						PrefixDelay = 1.08f;
						break;
					case EntityID.PrefixID.ANNOYING:
						PrefixDamage = 0.8f;
						PrefixDelay = 1.15f;
						break;
					case EntityID.PrefixID.NASTY:
						PrefixKB = 0.9f;
						PrefixDelay = 0.9f;
						PrefixDamage = 1.05f;
						PrefixCrit = 2;
						break;
					case EntityID.PrefixID.MANIC:
						PrefixManaSave = 0.9f;
						PrefixDamage = 0.9f;
						PrefixDelay = 0.9f;
						break;
					case EntityID.PrefixID.HURTFUL:
						PrefixDamage = 1.1f;
						break;
					case EntityID.PrefixID.STRONG:
						PrefixKB = 1.15f;
						break;
					case EntityID.PrefixID.UNPLEASANT:
						PrefixKB = 1.15f;
						PrefixDamage = 1.05f;
						break;
					case EntityID.PrefixID.WEAK:
						PrefixKB = 0.8f;
						break;
					case EntityID.PrefixID.RUTHLESS:
						PrefixKB = 0.9f;
						PrefixDamage = 1.18f;
						break;
					case EntityID.PrefixID.FRENZYING:
						PrefixDelay = 0.85f;
						PrefixDamage = 0.85f;
						break;
					case EntityID.PrefixID.GODLY:
						PrefixKB = 1.15f;
						PrefixDamage = 1.15f;
						PrefixCrit = 5;
						break;
					case EntityID.PrefixID.DEMONIC:
						PrefixDamage = 1.15f;
						PrefixCrit = 5;
						break;
					case EntityID.PrefixID.ZEALOUS:
						PrefixCrit = 5;
						break;
					case EntityID.PrefixID.LEGENDARY:
						PrefixKB = 1.15f;
						PrefixDamage = 1.15f;
						PrefixCrit = 5;
						PrefixDelay = 0.9f;
						PrefixScale = 1.1f;
						break;
					case EntityID.PrefixID.UNREAL:
						PrefixKB = 1.15f;
						PrefixDamage = 1.15f;
						PrefixCrit = 5;
						PrefixDelay = 0.9f;
						PrefixFireRate = 1.1f;
						break;
					case EntityID.PrefixID.MYTHICAL:
						PrefixKB = 1.15f;
						PrefixDamage = 1.15f;
						PrefixCrit = 5;
						PrefixDelay = 0.9f;
						PrefixManaSave = 0.9f;
						break;
					/*
					case EntityID.PrefixID.PIERCING:
						PrefixDamage = 1.1f;
						PrefixCrit = 10;
						break;
					*/
				}

				if (PrefixDamage != 1f && Math.Round(Damage * PrefixDamage) == Damage)
				{
					flag = true;
					PrefixID = -1;
				}
				if (PrefixDelay != 1f && Math.Round(UseAnimation * PrefixDelay) == UseAnimation)
				{
					flag = true;
					PrefixID = -1;
				}
				if (PrefixManaSave != 1f && Math.Round(Mana * PrefixManaSave) == Mana)
				{
					flag = true;
					PrefixID = -1;
				}
				if (PrefixKB != 1f && Knockback == 0f)
				{
					flag = true;
					PrefixID = -1;
				}
				if (Setting == -2 && PrefixID == (byte)EntityID.PrefixID.NONE)
				{
					PrefixID = -1;
					flag = true;
				}
			}
			Damage = (short)Math.Round(Damage * PrefixDamage);
			UseAnimation = (byte)Math.Round(UseAnimation * PrefixDelay);
			UseTime = (byte)Math.Round(UseTime * PrefixDelay);
			ReuseDelay = (byte)Math.Round(ReuseDelay * PrefixDelay);
			Mana = (byte)Math.Round(Mana * PrefixManaSave);
			Knockback *= PrefixKB;
			Scale *= PrefixScale;
			ShootSpeed *= PrefixFireRate;
			Crit += (short)PrefixCrit;
			float FinalMultiplier = PrefixDamage * (2f - PrefixDelay) * (2f - PrefixManaSave) * PrefixScale * PrefixKB * PrefixFireRate * (1f + Crit * 0.02f);
			switch ((EntityID.PrefixID)PrefixID)
			{
				case EntityID.PrefixID.HARD:
				case EntityID.PrefixID.JAGGED:
				case EntityID.PrefixID.BRISK:
				case EntityID.PrefixID.WILD:
					FinalMultiplier *= 1.05f;
					break;
				case EntityID.PrefixID.GUARDING:
				case EntityID.PrefixID.PRECISE:
				case EntityID.PrefixID.SPIKED:
				case EntityID.PrefixID.FLEETING:
				case EntityID.PrefixID.RASH:
					FinalMultiplier *= 1.1f;
					break;
				case EntityID.PrefixID.ARMORED:
				case EntityID.PrefixID.ARCANE:
				case EntityID.PrefixID.ANGRY:
				case EntityID.PrefixID.HASTY2:
				case EntityID.PrefixID.INTREPID:
					FinalMultiplier *= 1.15f;
					break;
				case EntityID.PrefixID.WARDING:
				case EntityID.PrefixID.LUCKY:
				case EntityID.PrefixID.MENACING:
				case EntityID.PrefixID.QUICK2:
				case EntityID.PrefixID.VIOLENT:
					FinalMultiplier *= 1.2f;
					break;
			}
			PrefixType = (byte)PrefixID;
			if (FinalMultiplier >= 1.2f)
			{
				Rarity += 2;
			}
			else if (FinalMultiplier >= 1.05f)
			{
				Rarity++;
			}
			else if (FinalMultiplier <= 0.8f)
			{
				Rarity -= 2;
			}
			else if (FinalMultiplier <= 0.95f)
			{
				Rarity--;
			}
			if (Rarity < (sbyte)EntityID.RarityID.GREY)
			{
				Rarity = (sbyte)EntityID.RarityID.GREY;
			}
			else if (Rarity > (sbyte)EntityID.RarityID.LIGHT_PURPLE)
			{
				Rarity = (sbyte)EntityID.RarityID.LIGHT_PURPLE;
			}
			FinalMultiplier *= FinalMultiplier;
			Value = (int)(Value * FinalMultiplier);
			return true;
		}

		public string Name()
		{
			return Lang.ItemName(NetID);
		}

		public string AffixName()
		{
			return Lang.ItemAffixName(PrefixType, NetID);
		}

		public void SetDefaults(string ItemName)
		{
			bool IsNotMaterial = false;
			switch (ItemName)
			{
				case "Gold Pickaxe":
					SetDefaults((int)EntityID.ItemID.IRON_PICKAXE);
					Colour = new Color(210, 190, 0, 100);
					UseTime = 17;
					PickPower = 55;
					UseAnimation = 20;
					Scale = 1.05f;
					Damage = 6;
					Value = 10000;
					NetID = (short)EntityID.ItemID.GOLD_PICKAXE;
					break;
				case "Gold Broadsword":
					SetDefaults((int)EntityID.ItemID.IRON_BROADSWORD);
					Colour = new Color(210, 190, 0, 100);
					UseAnimation = 20;
					Damage = 13;
					Scale = 1.05f;
					Value = 9000;
					NetID = (short)EntityID.ItemID.GOLD_BROADSWORD;
					break;
				case "Gold Shortsword":
					SetDefaults((int)EntityID.ItemID.IRON_SHORTSWORD);
					Colour = new Color(210, 190, 0, 100);
					Damage = 11;
					UseAnimation = 11;
					Scale = 0.95f;
					Value = 7000;
					NetID = (short)EntityID.ItemID.GOLD_SHORTSWORD;
					break;
				case "Gold Axe":
					SetDefaults((int)EntityID.ItemID.IRON_AXE);
					Colour = new Color(210, 190, 0, 100);
					UseTime = 18;
					AxePower = 11;
					UseAnimation = 26;
					Scale = 1.15f;
					Damage = 7;
					Value = 8000;
					NetID = (short)EntityID.ItemID.GOLD_AXE;
					break;
				case "Gold Hammer":
					SetDefaults((int)EntityID.ItemID.IRON_HAMMER);
					Colour = new Color(210, 190, 0, 100);
					UseAnimation = 28;
					UseTime = 23;
					Scale = 1.25f;
					Damage = 9;
					HammerPower = 55;
					Value = 8000;
					NetID = (short)EntityID.ItemID.GOLD_HAMMER;
					break;
				case "Gold Bow":
					SetDefaults((int)EntityID.ItemID.IRON_BOW);
					UseAnimation = 26;
					UseTime = 26;
					Colour = new Color(210, 190, 0, 100);
					Damage = 11;
					Value = 7000;
					NetID = (short)EntityID.ItemID.GOLD_BOW;
					break;
				case "Silver Pickaxe":
					SetDefaults((int)EntityID.ItemID.IRON_PICKAXE);
					Colour = new Color(180, 180, 180, 100);
					UseTime = 11;
					PickPower = 45;
					UseAnimation = 19;
					Scale = 1.05f;
					Damage = 6;
					Value = 5000;
					NetID = (short)EntityID.ItemID.SILVER_PICKAXE;
					break;
				case "Silver Broadsword":
					SetDefaults((int)EntityID.ItemID.IRON_BROADSWORD);
					Colour = new Color(180, 180, 180, 100);
					UseAnimation = 21;
					Damage = 11;
					Value = 4500;
					NetID = (short)EntityID.ItemID.SILVER_BROADSWORD;
					break;
				case "Silver Shortsword":
					SetDefaults((int)EntityID.ItemID.IRON_SHORTSWORD);
					Colour = new Color(180, 180, 180, 100);
					Damage = 9;
					UseAnimation = 12;
					Scale = 0.95f;
					Value = 3500;
					NetID = (short)EntityID.ItemID.SILVER_SHORTSWORD;
					break;
				case "Silver Axe":
					SetDefaults((int)EntityID.ItemID.IRON_AXE);
					Colour = new Color(180, 180, 180, 100);
					UseTime = 18;
					AxePower = 10;
					UseAnimation = 26;
					Scale = 1.15f;
					Damage = 6;
					Value = 4000;
					NetID = (short)EntityID.ItemID.SILVER_AXE;
					break;
				case "Silver Hammer":
					SetDefaults((int)EntityID.ItemID.IRON_HAMMER);
					Colour = new Color(180, 180, 180, 100);
					UseAnimation = 29;
					UseTime = 19;
					Scale = 1.25f;
					Damage = 9;
					HammerPower = 45;
					Value = 4000;
					NetID = (short)EntityID.ItemID.SILVER_HAMMER;
					break;
				case "Silver Bow":
					SetDefaults((int)EntityID.ItemID.IRON_BOW);
					UseAnimation = 27;
					UseTime = 27;
					Colour = new Color(180, 180, 180, 100);
					Damage = 9;
					Value = 3500;
					NetID = (short)EntityID.ItemID.SILVER_BOW;
					break;
				case "Copper Pickaxe":
					SetDefaults((int)EntityID.ItemID.IRON_PICKAXE);
					Colour = new Color(180, 100, 45, 80);
					UseTime = 15;
					PickPower = 35;
					UseAnimation = 23;
					Damage = 4;
					Scale = 0.9f;
					TileBoost = -1;
					Value = 500;
					NetID = (short)EntityID.ItemID.COPPER_PICKAXE;
					break;
				case "Copper Broadsword":
					SetDefaults((int)EntityID.ItemID.IRON_BROADSWORD);
					Colour = new Color(180, 100, 45, 80);
					UseAnimation = 23;
					Damage = 8;
					Value = 450;
					NetID = (short)EntityID.ItemID.COPPER_BROADSWORD;
					break;
				case "Copper Shortsword":
					SetDefaults((int)EntityID.ItemID.IRON_SHORTSWORD);
					Colour = new Color(180, 100, 45, 80);
					Damage = 5;
					UseAnimation = 13;
					Scale = 0.8f;
					Value = 350;
					NetID = (short)EntityID.ItemID.COPPER_SHORTSWORD;
					break;
				case "Copper Axe":
					SetDefaults((int)EntityID.ItemID.IRON_AXE);
					Colour = new Color(180, 100, 45, 80);
					UseTime = 21;
					AxePower = 7;
					UseAnimation = 30;
					Scale = 1f;
					Damage = 3;
					TileBoost = -1;
					Value = 400;
					NetID = (short)EntityID.ItemID.COPPER_AXE;
					break;
				case "Copper Hammer":
					SetDefaults((int)EntityID.ItemID.IRON_HAMMER);
					Colour = new Color(180, 100, 45, 80);
					UseAnimation = 33;
					UseTime = 23;
					Scale = 1.1f;
					Damage = 4;
					HammerPower = 35;
					TileBoost = -1;
					Value = 400;
					NetID = (short)EntityID.ItemID.COPPER_HAMMER;
					break;
				case "Copper Bow":
					SetDefaults((int)EntityID.ItemID.IRON_BOW);
					UseAnimation = 29;
					UseTime = 29;
					Colour = new Color(180, 100, 45, 80);
					Damage = 6;
					Value = 350;
					NetID = (short)EntityID.ItemID.COPPER_BOW;
					break;
				case "Blue Phasesaber":
					SetDefaults((int)EntityID.ItemID.BLUE_PHASEBLADE);
					Damage = 41;
					Scale = 1.15f;
					IsNotMaterial = true;
					AutoReuse = true;
					CanUseTurn = true;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					NetID = (short)EntityID.ItemID.BLUE_PHASESABER;
					break;
				case "Red Phasesaber":
					SetDefaults((int)EntityID.ItemID.RED_PHASEBLADE);
					Damage = 41;
					Scale = 1.15f;
					IsNotMaterial = true;
					AutoReuse = true;
					CanUseTurn = true;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					NetID = (short)EntityID.ItemID.RED_PHASESABER;
					break;
				case "Green Phasesaber":
					SetDefaults((int)EntityID.ItemID.GREEN_PHASEBLADE);
					Damage = 41;
					Scale = 1.15f;
					IsNotMaterial = true;
					AutoReuse = true;
					CanUseTurn = true;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					NetID = (short)EntityID.ItemID.GREEN_PHASESABER;
					break;
				case "Purple Phasesaber":
					SetDefaults((int)EntityID.ItemID.PURPLE_PHASEBLADE);
					Damage = 41;
					Scale = 1.15f;
					IsNotMaterial = true;
					AutoReuse = true;
					CanUseTurn = true;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					NetID = (short)EntityID.ItemID.PURPLE_PHASESABER;
					break;
				case "White Phasesaber":
					SetDefaults((int)EntityID.ItemID.WHITE_PHASEBLADE);
					Damage = 41;
					Scale = 1.15f;
					IsNotMaterial = true;
					AutoReuse = true;
					CanUseTurn = true;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					NetID = (short)EntityID.ItemID.WHITE_PHASESABER;
					break;
				case "Yellow Phasesaber":
					SetDefaults((int)EntityID.ItemID.YELLOW_PHASEBLADE);
					Damage = 41;
					Scale = 1.15f;
					IsNotMaterial = true;
					AutoReuse = true;
					CanUseTurn = true;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					NetID = (short)EntityID.ItemID.YELLOW_PHASESABER;
					break;
			}
			if (IsNotMaterial)
			{
				IsMaterial = false;
			}
			else
			{
				CheckMaterial();
			}
		}

		public bool CheckMaterial()
		{
			if (CanBePlacedInCoinSlot())
			{
				IsMaterial = false;
				return false;
			}
			for (int RecipeIdx = 0; RecipeIdx < Recipe.NumRecipes; RecipeIdx++)
			{
				int NumRecipeItems = Main.ActiveRecipe[RecipeIdx].NumRequiredItems - 1;
				do
				{
					if (NetID == Main.ActiveRecipe[RecipeIdx].RequiredItem[NumRecipeItems].NetID)
					{
						IsMaterial = true;
						return true;
					}
				}
				while (--NumRecipeItems >= 0);
			}
			IsMaterial = false;
			return false;
		}

		public void NetDefaults(int Type, int Stack = 1)
		{
			if (Type < 0)
			{
				switch ((EntityID.ItemID)Type)
				{
					case EntityID.ItemID.GOLD_PICKAXE:
						SetDefaults("Gold Pickaxe");
						break;
					case EntityID.ItemID.GOLD_BROADSWORD:
						SetDefaults("Gold Broadsword");
						break;
					case EntityID.ItemID.GOLD_SHORTSWORD:
						SetDefaults("Gold Shortsword");
						break;
					case EntityID.ItemID.GOLD_AXE:
						SetDefaults("Gold Axe");
						break;
					case EntityID.ItemID.GOLD_HAMMER:
						SetDefaults("Gold Hammer");
						break;
					case EntityID.ItemID.GOLD_BOW:
						SetDefaults("Gold Bow");
						break;
					case EntityID.ItemID.SILVER_PICKAXE:
						SetDefaults("Silver Pickaxe");
						break;
					case EntityID.ItemID.SILVER_BROADSWORD:
						SetDefaults("Silver Broadsword");
						break;
					case EntityID.ItemID.SILVER_SHORTSWORD:
						SetDefaults("Silver Shortsword");
						break;
					case EntityID.ItemID.SILVER_AXE:
						SetDefaults("Silver Axe");
						break;
					case EntityID.ItemID.SILVER_HAMMER:
						SetDefaults("Silver Hammer");
						break;
					case EntityID.ItemID.SILVER_BOW:
						SetDefaults("Silver Bow");
						break;
					case EntityID.ItemID.COPPER_PICKAXE:
						SetDefaults("Copper Pickaxe");
						break;
					case EntityID.ItemID.COPPER_BROADSWORD:
						SetDefaults("Copper Broadsword");
						break;
					case EntityID.ItemID.COPPER_SHORTSWORD:
						SetDefaults("Copper Shortsword");
						break;
					case EntityID.ItemID.COPPER_AXE:
						SetDefaults("Copper Axe");
						break;
					case EntityID.ItemID.COPPER_HAMMER:
						SetDefaults("Copper Hammer");
						break;
					case EntityID.ItemID.COPPER_BOW:
						SetDefaults("Copper Bow");
						break;
					case EntityID.ItemID.BLUE_PHASESABER:
						SetDefaults("Blue Phasesaber");
						break;
					case EntityID.ItemID.RED_PHASESABER:
						SetDefaults("Red Phasesaber");
						break;
					case EntityID.ItemID.GREEN_PHASESABER:
						SetDefaults("Green Phasesaber");
						break;
					case EntityID.ItemID.PURPLE_PHASESABER:
						SetDefaults("Purple Phasesaber");
						break;
					case EntityID.ItemID.WHITE_PHASESABER:
						SetDefaults("White Phasesaber");
						break;
					case EntityID.ItemID.YELLOW_PHASESABER:
						SetDefaults("Yellow Phasesaber");
						break;
				}
			}
			else
			{
				SetDefaults(Type, Stack);
			}
		}

		public void SetDefaults(int ItemType, int ItemStack = 1, bool NoMaterialCheck = false)
		{
			Active = 1;
			Owner = Player.MaxNumPlayers;
			Type = (short)ItemType;
			NetID = (short)ItemType;
			PrefixType = 0;
			Crit = 0;
			WornArmor = false;
			Mech = false;
			ReuseDelay = 0;
			IsMelee = false;
			IsMagic = false;
			IsRanged = false;
			PlaceStyle = 0;
			BuffTime = 0;
			BuffType = 0;
			IsMaterial = false;
			CantTouchLiquid = false;
			IsVanity = false;
			Mana = 0;
			IsWet = false;
			WetCount = 0;
			IsInLava = false;
			Channelling = false;
			OnlyBuyOnce = false;
			IsSocial = false;
			Release = 0;
			NoMelee = false;
			NoUseGraphic = false;
			LifeRegen = 0;
			ShootSpeed = 0f;
			Alpha = 0;
			Ammo = 0;
			UseAmmo = 0;
			AutoReuse = false;
			IsAccessory = false;
			AxePower = 0;
			HealMana = 0;
			BodySlot = -1;
			LegSlot = -1;
			HeadSlot = -1;
			IsPotion = false;
			Colour = default;
			IsConsumable = false;
			CreateTile = -1;
			CreateWall = -1;
			Damage = 0;
			Defense = 0;
			HammerPower = 0;
			HealLife = 0;
			Knockback = 0f;
			PickPower = 0;
			Rarity = (sbyte)EntityID.RarityID.WHITE;
			Scale = 1f;
			Shoot = 0;
			Stack = (short)ItemStack;
			MaxStack = (short)ItemStack;
			TileBoost = 0;
			HoldStyle = 0;
			UseStyle = 0;
			UseSound = 0;
			UseTime = 100;
			UseAnimation = 100;
			Value = 0;
			CanUseTurn = false;
			CanBuy = false;
			OwnIgnore = Player.MaxNumPlayers;
			OwnTime = 0;
			KeepTime = 0;
			switch ((EntityID.ItemID)ItemType)
			{
				case EntityID.ItemID.IRON_PICKAXE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 20;
					UseTime = 13;
					AutoReuse = true;
					Width = 24;
					Height = 28;
					Damage = 5;
					PickPower = 40;
					UseSound = 1;
					Knockback = 2f;
					Value = 2000;
					IsMelee = true;
					break;
				case EntityID.ItemID.DIRT_BLOCK:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.DIRT;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.STONE_BLOCK:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STONE;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.IRON_BROADSWORD:
					UseStyle = 1;
					CanUseTurn = false;
					UseAnimation = 21;
					UseTime = 21;
					Width = 24;
					Height = 28;
					Damage = 10;
					Knockback = 5f;
					UseSound = 1;
					Scale = 1f;
					Value = 1800;
					IsMelee = true;
					break;
				case EntityID.ItemID.MUSHROOM:
					UseStyle = 2;
					UseSound = 2;
					CanUseTurn = false;
					UseAnimation = 17;
					UseTime = 17;
					Width = 16;
					Height = 18;
					HealLife = 15;
					MaxStack = 99;
					IsConsumable = true;
					IsPotion = true;
					Value = 25;
					break;
				case EntityID.ItemID.IRON_SHORTSWORD:
					UseStyle = 3;
					CanUseTurn = false;
					UseAnimation = 12;
					UseTime = 12;
					Width = 24;
					Height = 28;
					Damage = 8;
					Knockback = 4f;
					Scale = 0.9f;
					UseSound = 1;
					CanUseTurn = true;
					Value = 1400;
					IsMelee = true;
					break;
				case EntityID.ItemID.IRON_HAMMER:
					AutoReuse = true;
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 30;
					UseTime = 20;
					HammerPower = 45;
					Width = 24;
					Height = 28;
					Damage = 7;
					Knockback = 5.5f;
					Scale = 1.2f;
					UseSound = 1;
					Value = 1600;
					IsMelee = true;
					break;
				case EntityID.ItemID.TORCH:
					CantTouchLiquid = true;
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					HoldStyle = 1;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.TORCH;
					Width = 10;
					Height = 12;
					Value = 50;
					break;
				case EntityID.ItemID.WOOD:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.WOOD;
					Width = 8;
					Height = 10;
					break;
				case EntityID.ItemID.IRON_AXE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 27;
					Knockback = 4.5f;
					UseTime = 19;
					AutoReuse = true;
					Width = 24;
					Height = 28;
					Damage = 5;
					AxePower = 9;
					Scale = 1.1f;
					UseSound = 1;
					Value = 1600;
					IsMelee = true;
					break;
				case EntityID.ItemID.IRON_ORE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.IRON_ORE;
					Width = 12;
					Height = 12;
					Value = 500;
					break;
				case EntityID.ItemID.COPPER_ORE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.COPPER_ORE;
					Width = 12;
					Height = 12;
					Value = 250;
					break;
				case EntityID.ItemID.GOLD_ORE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.GOLD_ORE;
					Width = 12;
					Height = 12;
					Value = 2000;
					break;
				case EntityID.ItemID.SILVER_ORE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.SILVER_ORE;
					Width = 12;
					Height = 12;
					Value = 1000;
					break;
				case EntityID.ItemID.COPPER_WATCH:
					Width = 24;
					Height = 28;
					IsAccessory = true;
					Value = 1000;
					break;
				case EntityID.ItemID.SILVER_WATCH:
					Width = 24;
					Height = 28;
					IsAccessory = true;
					Value = 5000;
					break;
				case EntityID.ItemID.GOLD_WATCH:
					Width = 24;
					Height = 28;
					IsAccessory = true;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 10000;
					break;
				case EntityID.ItemID.DEPTH_METER:
					Width = 24;
					Height = 18;
					IsAccessory = true;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 10000;
					break;
				case EntityID.ItemID.GOLD_BAR:
					Width = 20;
					Height = 20;
					MaxStack = 99;
					Value = 6000;
					break;
				case EntityID.ItemID.COPPER_BAR:
					Width = 20;
					Height = 20;
					MaxStack = 99;
					Value = 750;
					break;
				case EntityID.ItemID.SILVER_BAR:
					Width = 20;
					Height = 20;
					MaxStack = 99;
					Value = 3000;
					break;
				case EntityID.ItemID.IRON_BAR:
					Width = 20;
					Height = 20;
					MaxStack = 99;
					Value = 1500;
					break;
				case EntityID.ItemID.GEL:
					Width = 10;
					Height = 12;
					MaxStack = 250;
					Alpha = 175;
					Ammo = 23;
					Colour = new Color(0, 80, 255, 100);
					Value = 5;
					break;
				case EntityID.ItemID.WOODEN_SWORD:
					UseStyle = 1;
					CanUseTurn = false;
					UseAnimation = 25;
					Width = 24;
					Height = 28;
					Damage = 7;
					Knockback = 4f;
					Scale = 0.95f;
					UseSound = 1;
					Value = 100;
					IsMelee = true;
					break;
				case EntityID.ItemID.WOODEN_DOOR:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.DOOR_CLOSED;
					Width = 14;
					Height = 28;
					Value = 200;
					break;
				case EntityID.ItemID.STONE_WALL:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 7;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateWall = (short)EntityID.WallID.STONE;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.ACORN:
					CanUseTurn = true;
					UseStyle = 1;
					UseAnimation = 15;
					UseTime = 10;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.SAPLING;
					Width = 18;
					Height = 18;
					Value = 10;
					break;
				case EntityID.ItemID.LESSER_HEALING_POTION:
					UseSound = 3;
					HealLife = 50;
					UseStyle = 2;
					CanUseTurn = true;
					UseAnimation = 17;
					UseTime = 17;
					MaxStack = 30;
					IsConsumable = true;
					Width = 14;
					Height = 24;
					IsPotion = true;
					Value = 300;
					break;
				case EntityID.ItemID.LIFE_CRYSTAL:
					MaxStack = 99;
					IsConsumable = true;
					Width = 18;
					Height = 18;
					UseStyle = 4;
					UseTime = 30;
					UseSound = 4;
					UseAnimation = 30;
					Rarity = (sbyte)EntityID.RarityID.GREEN;
					Value = 75000;
					break;
				case EntityID.ItemID.DIRT_WALL:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 7;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateWall = (short)EntityID.WallID.DIRT;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.BOTTLE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.BOTTLE;
					Width = 16;
					Height = 24;
					Value = 20;
					break;
				case EntityID.ItemID.WOODEN_TABLE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.TABLE;
					Width = 26;
					Height = 20;
					Value = 300;
					break;
				case EntityID.ItemID.FURNACE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.FURNACE;
					Width = 26;
					Height = 24;
					Value = 300;
					break;
				case EntityID.ItemID.WOODEN_CHAIR:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.CHAIR;
					Width = 12;
					Height = 30;
					Value = 150;
					break;
				case EntityID.ItemID.IRON_ANVIL:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.ANVIL;
					Width = 28;
					Height = 14;
					Value = 5000;
					break;
				case EntityID.ItemID.WORK_BENCH:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.WORK_BENCH;
					Width = 28;
					Height = 14;
					Value = 150;
					break;
				case EntityID.ItemID.GOGGLES:
					Width = 28;
					Height = 12;
					Defense = 1;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_GOGGLES;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 1000;
					break;
				case EntityID.ItemID.LENS:
					Width = 12;
					Height = 20;
					MaxStack = 99;
					Value = 500;
					break;
				case EntityID.ItemID.WOODEN_BOW:
					UseStyle = 5;
					UseAnimation = 30;
					UseTime = 30;
					Width = 12;
					Height = 28;
					Shoot = (byte)EntityID.ProjectileID.WOODEN_ARROW_FRIENDLY;
					UseAmmo = 1;
					UseSound = 5;
					Damage = 4;
					ShootSpeed = 6.1f;
					NoMelee = true;
					Value = 100;
					IsRanged = true;
					break;
				case EntityID.ItemID.WOODEN_ARROW:
					ShootSpeed = 3f;
					Shoot = (byte)EntityID.ProjectileID.WOODEN_ARROW_FRIENDLY;
					Damage = 4;
					Width = 10;
					Height = 28;
					MaxStack = 250;
					IsConsumable = true;
					Ammo = 1;
					Knockback = 2f;
					Value = 10;
					IsRanged = true;
					break;
				case EntityID.ItemID.FLAMING_ARROW:
					ShootSpeed = 3.5f;
					Shoot = (byte)EntityID.ProjectileID.FIRE_ARROW;
					Damage = 6;
					Width = 10;
					Height = 28;
					MaxStack = 250;
					IsConsumable = true;
					Ammo = 1;
					Knockback = 2f;
					Value = 15;
					IsRanged = true;
					break;
				case EntityID.ItemID.SHURIKEN:
					UseStyle = 1;
					ShootSpeed = 9f;
					Shoot = (byte)EntityID.ProjectileID.SHURIKEN;
					Damage = 10;
					Width = 18;
					Height = 20;
					MaxStack = 250;
					IsConsumable = true;
					UseSound = 1;
					UseAnimation = 15;
					UseTime = 15;
					NoUseGraphic = true;
					NoMelee = true;
					Value = 20;
					IsRanged = true;
					break;
				case EntityID.ItemID.SUSPICIOUS_LOOKING_EYE:
					UseStyle = 4;
					Width = 22;
					Height = 14;
					IsConsumable = true;
					UseAnimation = 45;
					UseTime = 45;
					MaxStack = 20;
					break;
				case EntityID.ItemID.SUSPICIOUS_LOOKING_SKULL:
					UseStyle = 4;
					Width = 26;
					Height = 26;
					IsConsumable = true;
					UseAnimation = 45;
					UseTime = 45;
					MaxStack = 20;
					break;
				case EntityID.ItemID.DEMON_BOW:
					UseStyle = 5;
					UseAnimation = 25;
					UseTime = 25;
					Width = 12;
					Height = 28;
					Shoot = (byte)EntityID.ProjectileID.WOODEN_ARROW_FRIENDLY;
					UseAmmo = 1;
					UseSound = 5;
					Damage = 14;
					ShootSpeed = 6.7f;
					Knockback = 1f;
					Alpha = 30;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					NoMelee = true;
					Value = 18000;
					IsRanged = true;
					break;
				case EntityID.ItemID.WAR_AXE_OF_THE_NIGHT:
					AutoReuse = true;
					UseStyle = 1;
					UseAnimation = 30;
					Knockback = 6f;
					UseTime = 15;
					Width = 24;
					Height = 28;
					Damage = 20;
					AxePower = 15;
					Scale = 1.2f;
					UseSound = 1;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 13500;
					IsMelee = true;
					break;
				case EntityID.ItemID.LIGHTS_BANE:
					UseStyle = 1;
					UseAnimation = 20;
					Knockback = 5f;
					Width = 24;
					Height = 28;
					Damage = 17;
					Scale = 1.1f;
					UseSound = 1;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 13500;
					IsMelee = true;
					break;
				case EntityID.ItemID.UNHOLY_ARROW:
					ShootSpeed = 3.4f;
					Shoot = (byte)EntityID.ProjectileID.UNHOLY_ARROW;
					Damage = 8;
					Width = 10;
					Height = 28;
					MaxStack = 250;
					IsConsumable = true;
					Ammo = 1;
					Knockback = 3f;
					Alpha = 30;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 40;
					IsRanged = true;
					break;
				case EntityID.ItemID.CHEST:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.CHEST;
					Width = 26;
					Height = 22;
					Value = 500;
					break;
				case EntityID.ItemID.BAND_OF_REGENERATION:
					Width = 22;
					Height = 22;
					IsAccessory = true;
					LifeRegen = 1;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 50000;
					break;
				case EntityID.ItemID.MAGIC_MIRROR:
					Mana = 20;
					CanUseTurn = true;
					Width = 20;
					Height = 20;
					UseStyle = 4;
					UseTime = 90;
					UseSound = 6;
					UseAnimation = 90;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 50000;
					break;
				case EntityID.ItemID.JESTERS_ARROW:
					ShootSpeed = 0.5f;
					Shoot = (byte)EntityID.ProjectileID.JESTERS_ARROW;
					Damage = 9;
					Width = 10;
					Height = 28;
					MaxStack = 250;
					IsConsumable = true;
					Ammo = 1;
					Knockback = 4f;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 100;
					IsRanged = true;
					break;
				case EntityID.ItemID.ANGEL_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 1;
					break;
				case EntityID.ItemID.CLOUD_IN_A_BOTTLE:
					Width = 16;
					Height = 24;
					IsAccessory = true;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 50000;
					break;
				case EntityID.ItemID.HERMES_BOOTS:
					Width = 28;
					Height = 24;
					IsAccessory = true;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 50000;
					break;
				case EntityID.ItemID.ENCHANTED_BOOMERANG:
					NoMelee = true;
					UseStyle = 1;
					ShootSpeed = 10f;
					Shoot = (byte)EntityID.ProjectileID.ENCHANTED_BOOMERANG;
					Damage = 13;
					Knockback = 8f;
					Width = 14;
					Height = 28;
					UseSound = 1;
					UseAnimation = 15;
					UseTime = 15;
					NoUseGraphic = true;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 50000;
					IsMelee = true;
					break;
				case EntityID.ItemID.DEMONITE_ORE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.DEMONITE_ORE;
					Width = 12;
					Height = 12;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 4000;
					break;
				case EntityID.ItemID.DEMONITE_BAR:
					Width = 20;
					Height = 20;
					MaxStack = 99;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 16000;
					break;
				case EntityID.ItemID.HEART:
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.CORRUPT_SEEDS:
					CanUseTurn = true;
					UseStyle = 1;
					UseAnimation = 15;
					UseTime = 10;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.CORRUPT_GRASS;
					Width = 14;
					Height = 14;
					Value = 500;
					break;
				case EntityID.ItemID.VILE_MUSHROOM:
					Width = 16;
					Height = 18;
					MaxStack = 99;
					Value = 50;
					break;
				case EntityID.ItemID.EBONSTONE_BLOCK:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.EBONSTONE;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.GRASS_SEEDS:
					CanUseTurn = true;
					UseStyle = 1;
					UseAnimation = 15;
					UseTime = 10;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.GRASS;
					Width = 14;
					Height = 14;
					Value = 20;
					break;
				case EntityID.ItemID.SUNFLOWER:
					CanUseTurn = true;
					UseStyle = 1;
					UseAnimation = 15;
					UseTime = 10;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.SUNFLOWER;
					Width = 26;
					Height = 26;
					Value = 200;
					break;
				case EntityID.ItemID.VILETHORN:
					Mana = 12;
					Damage = 8;
					UseStyle = 1;
					ShootSpeed = 32f;
					Shoot = (byte)EntityID.ProjectileID.VILETHORN_BASE;
					Width = 26;
					Height = 28;
					UseSound = 8;
					UseAnimation = 30;
					UseTime = 30;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					NoMelee = true;
					Knockback = 1f;
					Value = 10000;
					IsMagic = true;
					break;
				case EntityID.ItemID.STARFURY:
					AutoReuse = true;
					Mana = 16;
					Knockback = 5f;
					Alpha = 100;
					Colour = new Color(150, 150, 150, 0);
					Damage = 16;
					UseStyle = 1;
					Scale = 1.15f;
					ShootSpeed = 12f;
					Shoot = (byte)EntityID.ProjectileID.STARFURY;
					Width = 14;
					Height = 28;
					UseSound = 9;
					UseAnimation = 25;
					UseTime = 10;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 50000;
					IsMagic = true;
					break;
				case EntityID.ItemID.PURIFICATION_POWDER:
					UseStyle = 1;
					ShootSpeed = 4f;
					Shoot = (byte)EntityID.ProjectileID.PURIFICATION_POWDER;
					Width = 16;
					Height = 24;
					MaxStack = 99;
					IsConsumable = true;
					UseSound = 1;
					UseAnimation = 15;
					UseTime = 15;
					NoMelee = true;
					Value = 75;
					break;
				case EntityID.ItemID.VILE_POWDER:
					Damage = 0;
					UseStyle = 1;
					ShootSpeed = 4f;
					Shoot = (byte)EntityID.ProjectileID.VILE_POWDER;
					Width = 16;
					Height = 24;
					MaxStack = 99;
					IsConsumable = true;
					UseSound = 1;
					UseAnimation = 15;
					UseTime = 15;
					NoMelee = true;
					Value = 100;
					break;
				case EntityID.ItemID.ROTTEN_CHUNK:
					Width = 18;
					Height = 20;
					MaxStack = 99;
					Value = 10;
					break;
				case EntityID.ItemID.WORM_TOOTH:
					Width = 8;
					Height = 20;
					MaxStack = 99;
					Value = 100;
					break;
				case EntityID.ItemID.WORM_FOOD:
					UseStyle = 4;
					IsConsumable = true;
					UseAnimation = 45;
					UseTime = 45;
					Width = 28;
					Height = 28;
					MaxStack = 20;
					break;
				case EntityID.ItemID.COPPER_COIN:
					Width = 10;
					Height = 12;
					MaxStack = 100;
					Value = 5;
					break;
				case EntityID.ItemID.SILVER_COIN:
					Width = 10;
					Height = 12;
					MaxStack = 100;
					Value = 500;
					break;
				case EntityID.ItemID.GOLD_COIN:
					Width = 10;
					Height = 12;
					MaxStack = 100;
					Value = 50000;
					break;
				case EntityID.ItemID.PLATINUM_COIN:
					Width = 10;
					Height = 12;
					MaxStack = 100;
					Value = 5000000;
					break;
				case EntityID.ItemID.FALLEN_STAR:
					Width = 18;
					Height = 20;
					MaxStack = 100;
					Alpha = 75;
					Ammo = 15;
					Value = 500;
					UseStyle = 4;
					UseSound = 4;
					CanUseTurn = false;
					UseAnimation = 17;
					UseTime = 17;
					IsConsumable = true;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					break;
				case EntityID.ItemID.COPPER_GREAVES:
					Width = 18;
					Height = 18;
					Defense = 1;
					LegSlot = (short)EntityID.ArmorLegsID.LEGS_COPPER_GREAVES;
					Value = 750;
					break;
				case EntityID.ItemID.IRON_GREAVES:
					Width = 18;
					Height = 18;
					Defense = 2;
					LegSlot = (short)EntityID.ArmorLegsID.LEGS_IRON_GREAVES;
					Value = 3000;
					break;
				case EntityID.ItemID.SILVER_GREAVES:
					Width = 18;
					Height = 18;
					Defense = 3;
					LegSlot = (short)EntityID.ArmorLegsID.LEGS_SILVER_GREAVES;
					Value = 7500;
					break;
				case EntityID.ItemID.GOLD_GREAVES:
					Width = 18;
					Height = 18;
					Defense = 4;
					LegSlot = (short)EntityID.ArmorLegsID.LEGS_GOLD_GREAVES;
					Value = 15000;
					break;
				case EntityID.ItemID.COPPER_CHAINMAIL:
					Width = 18;
					Height = 18;
					Defense = 2;
					BodySlot = (short)EntityID.ArmorBodyID.BODY_COPPER_CHAINMAIL;
					Value = 1000;
					break;
				case EntityID.ItemID.IRON_CHAINMAIL:
					Width = 18;
					Height = 18;
					Defense = 3;
					BodySlot = (short)EntityID.ArmorBodyID.BODY_IRON_CHAINMAIL;
					Value = 4000;
					break;
				case EntityID.ItemID.SILVER_CHAINMAIL:
					Width = 18;
					Height = 18;
					Defense = 4;
					BodySlot = (short)EntityID.ArmorBodyID.BODY_SILVER_CHAINMAIL;
					Value = 10000;
					break;
				case EntityID.ItemID.GOLD_CHAINMAIL:
					Width = 18;
					Height = 18;
					Defense = 5;
					BodySlot = (short)EntityID.ArmorBodyID.BODY_GOLD_CHAINMAIL;
					Value = 20000;
					break;
				case EntityID.ItemID.GRAPPLING_HOOK:
					NoUseGraphic = true;
					Damage = 0;
					Knockback = 7f;
					UseStyle = 5;
					ShootSpeed = 11f;
					Shoot = (byte)EntityID.ProjectileID.HOOK;
					Width = 18;
					Height = 28;
					UseSound = 1;
					UseAnimation = 20;
					UseTime = 20;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					NoMelee = true;
					Value = 20000;
					break;
				case EntityID.ItemID.CHAIN:
					Width = 14;
					Height = 20;
					MaxStack = 99;
					Value = 1000;
					break;
				case EntityID.ItemID.SHADOW_SCALE:
					Width = 14;
					Height = 18;
					MaxStack = 99;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 500;
					break;
				case EntityID.ItemID.PIGGY_BANK:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.PIGGYBANK;
					Width = 20;
					Height = 12;
					Value = 10000;
					break;
				case EntityID.ItemID.MINING_HELMET:
					Width = 22;
					Height = 16;
					Defense = 1;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_MINING_HELMET;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 80000;
					break;
				case EntityID.ItemID.COPPER_HELMET:
					Width = 18;
					Height = 18;
					Defense = 1;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_COPPER_HELMET;
					Value = 1250;
					break;
				case EntityID.ItemID.IRON_HELMET:
					Width = 18;
					Height = 18;
					Defense = 2;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_IRON_HELMET;
					Value = 5000;
					break;
				case EntityID.ItemID.SILVER_HELMET:
					Width = 18;
					Height = 18;
					Defense = 3;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_SILVER_HELMET;
					Value = 12500;
					break;
				case EntityID.ItemID.GOLD_HELMET:
					Width = 18;
					Height = 18;
					Defense = 4;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_GOLD_HELMET;
					Value = 25000;
					break;
				case EntityID.ItemID.WOOD_WALL:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 7;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateWall = (short)EntityID.WallID.WOOD;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.WOOD_PLATFORM:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.PLATFORM;
					Width = 8;
					Height = 10;
					break;
				case EntityID.ItemID.FLINTLOCK_PISTOL:
					UseStyle = 5;
					UseAnimation = 16;
					UseTime = 16;
					Width = 24;
					Height = 28;
					Shoot = (byte)EntityID.ProjectileID.BULLET;
					UseAmmo = 14;
					UseSound = 11;
					Damage = 10;
					ShootSpeed = 5f;
					NoMelee = true;
					Value = 50000;
					Scale = 0.9f;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					IsRanged = true;
					break;
				case EntityID.ItemID.MUSKET:
					UseStyle = 5;
					AutoReuse = true;
					UseAnimation = 43;
					UseTime = 43;
					Width = 44;
					Height = 14;
					Shoot = (byte)EntityID.ProjectileID.PURIFICATION_POWDER;
					UseAmmo = 14;
					UseSound = 11;
					Damage = 23;
					ShootSpeed = 8f;
					NoMelee = true;
					Value = 100000;
					Knockback = 4f;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					IsRanged = true;
					break;
				case EntityID.ItemID.MUSKET_BALL:
					ShootSpeed = 4f;
					Shoot = (byte)EntityID.ProjectileID.BULLET;
					Damage = 7;
					Width = 8;
					Height = 8;
					MaxStack = 250;
					IsConsumable = true;
					Ammo = 14;
					Knockback = 2f;
					Value = 7;
					IsRanged = true;
					break;
				case EntityID.ItemID.MINISHARK:
					UseStyle = 5;
					AutoReuse = true;
					UseAnimation = 8;
					UseTime = 8;
					Width = 50;
					Height = 18;
					Shoot = (byte)EntityID.ProjectileID.PURIFICATION_POWDER;
					UseAmmo = 14;
					UseSound = 11;
					Damage = 6;
					ShootSpeed = 7f;
					NoMelee = true;
					Value = 350000;
					Rarity = (sbyte)EntityID.RarityID.GREEN;
					IsRanged = true;
					break;
				case EntityID.ItemID.IRON_BOW:
					UseStyle = 5;
					UseAnimation = 28;
					UseTime = 28;
					Width = 12;
					Height = 28;
					Shoot = (byte)EntityID.ProjectileID.WOODEN_ARROW_FRIENDLY;
					UseAmmo = 1;
					UseSound = 5;
					Damage = 8;
					ShootSpeed = 6.6f;
					NoMelee = true;
					Value = 1400;
					IsRanged = true;
					break;
				case EntityID.ItemID.SHADOW_GREAVES:
					Width = 18;
					Height = 18;
					Defense = 6;
					LegSlot = (short)EntityID.ArmorLegsID.LEGS_SHADOW_GREAVES;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 22500;
					break;
				case EntityID.ItemID.SHADOW_SCALEMAIL:
					Width = 18;
					Height = 18;
					Defense = 7;
					BodySlot = (short)EntityID.ArmorBodyID.BODY_SHADOW_SCALEMAIL;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 30000;
					break;
				case EntityID.ItemID.SHADOW_HELMET:
					Width = 18;
					Height = 18;
					Defense = 6;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_SHADOW_HELMET;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 37500;
					break;
				case EntityID.ItemID.NIGHTMARE_PICKAXE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 20;
					UseTime = 15;
					AutoReuse = true;
					Width = 24;
					Height = 28;
					Damage = 9;
					PickPower = 65;
					UseSound = 1;
					Knockback = 3f;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 18000;
					Scale = 1.15f;
					IsMelee = true;
					break;
				case EntityID.ItemID.THE_BREAKER:
					AutoReuse = true;
					UseStyle = 1;
					UseAnimation = 45;
					UseTime = 19;
					HammerPower = 55;
					Width = 24;
					Height = 28;
					Damage = 24;
					Knockback = 6f;
					Scale = 1.3f;
					UseSound = 1;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 15000;
					IsMelee = true;
					break;
				case EntityID.ItemID.CANDLE:
					CantTouchLiquid = true;
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.CANDLE;
					Width = 8;
					Height = 18;
					HoldStyle = 1;
					break;
				case EntityID.ItemID.COPPER_CHANDELIER:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.CHANDELIER;
					Width = 26;
					Height = 26;
					break;
				case EntityID.ItemID.SILVER_CHANDELIER:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.JACK_O_LANTERN;
					Width = 26;
					Height = 26;
					break;
				case EntityID.ItemID.GOLD_CHANDELIER:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.PRESENT;
					Width = 26;
					Height = 26;
					break;
				case EntityID.ItemID.MANA_CRYSTAL:
					MaxStack = 99;
					IsConsumable = true;
					Width = 18;
					Height = 18;
					UseStyle = 4;
					UseTime = 30;
					UseSound = 29;
					UseAnimation = 30;
					Rarity = (sbyte)EntityID.RarityID.GREEN;
					break;
				case EntityID.ItemID.LESSER_MANA_POTION:
					UseSound = 3;
					HealMana = 50;
					UseStyle = 2;
					CanUseTurn = true;
					UseAnimation = 17;
					UseTime = 17;
					MaxStack = 20;
					IsConsumable = true;
					Width = 14;
					Height = 24;
					Value = 100;
					break;
				case EntityID.ItemID.BAND_OF_STARPOWER:
					Width = 22;
					Height = 22;
					IsAccessory = true;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 50000;
					break;
				case EntityID.ItemID.FLOWER_OF_FIRE:
					Mana = 17;
					Damage = 44;
					UseStyle = 1;
					ShootSpeed = 6f;
					Shoot = (byte)EntityID.ProjectileID.BALL_OF_FIRE;
					Width = 26;
					Height = 28;
					UseSound = 20;
					UseAnimation = 20;
					UseTime = 20;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					NoMelee = true;
					Knockback = 5.5f;
					Value = 10000;
					IsMagic = true;
					break;
				case EntityID.ItemID.MAGIC_MISSILE:
					Mana = 10;
					Channelling = true;
					Damage = 22;
					UseStyle = 1;
					ShootSpeed = 6f;
					Shoot = (byte)EntityID.ProjectileID.MAGIC_MISSILE;
					Width = 26;
					Height = 28;
					UseSound = 9;
					UseAnimation = 17;
					UseTime = 17;
					Rarity = (sbyte)EntityID.RarityID.GREEN;
					NoMelee = true;
					Knockback = 5f;
					TileBoost = 64;
					Value = 10000;
					IsMagic = true;
					break;
				case EntityID.ItemID.DIRT_ROD:
					Mana = 5;
					Channelling = true;
					Damage = 0;
					UseStyle = 1;
					Shoot = (byte)EntityID.ProjectileID.DIRT_BALL;
					Width = 26;
					Height = 28;
					UseSound = 8;
					UseAnimation = 20;
					UseTime = 20;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					NoMelee = true;
					Knockback = 5f;
					Value = 200000;
					break;
				case EntityID.ItemID.SHADOW_ORB:
					Mana = 40;
					Channelling = true;
					Damage = 0;
					UseStyle = 4;
					Shoot = (byte)EntityID.ProjectileID.SHADOW_ORB;
					Width = 24;
					Height = 24;
					UseSound = 8;
					UseAnimation = 20;
					UseTime = 20;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					NoMelee = true;
					Value = 10000;
					BuffType = (int)EntityID.BuffID.LIGHT_ORB;
					BuffTime = 18000;
					break;
				case EntityID.ItemID.METEORITE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.METEORITE;
					Width = 12;
					Height = 12;
					Value = 1000;
					break;
				case EntityID.ItemID.METEORITE_BAR:
					Width = 20;
					Height = 20;
					MaxStack = 99;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 7000;
					break;
				case EntityID.ItemID.HOOK:
					MaxStack = 99;
					Width = 18;
					Height = 18;
					Value = 1000;
					break;
				case EntityID.ItemID.FLAMARANG:
					NoMelee = true;
					UseStyle = 1;
					ShootSpeed = 11f;
					Shoot = (byte)EntityID.ProjectileID.FLAMARANG;
					Damage = 32;
					Knockback = 8f;
					Width = 14;
					Height = 28;
					UseSound = 1;
					UseAnimation = 15;
					UseTime = 15;
					NoUseGraphic = true;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					Value = 100000;
					IsMelee = true;
					break;
				case EntityID.ItemID.MOLTEN_FURY:
					UseStyle = 5;
					UseAnimation = 25;
					UseTime = 25;
					Width = 14;
					Height = 32;
					Shoot = (byte)EntityID.ProjectileID.WOODEN_ARROW_FRIENDLY;
					UseAmmo = 1;
					UseSound = 5;
					Damage = 29;
					ShootSpeed = 8f;
					Knockback = 2f;
					Alpha = 30;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					NoMelee = true;
					Scale = 1.1f;
					Value = 27000;
					IsRanged = true;
					break;
				case EntityID.ItemID.SHARANGA:
					UseStyle = 5;
					UseAnimation = 20;
					UseTime = 20;
					Width = 14;
					Height = 32;
					Shoot = (byte)EntityID.ProjectileID.WOODEN_ARROW_FRIENDLY;
					UseAmmo = 1;
					UseSound = 5;
					Damage = 35;
					ShootSpeed = 10f;
					Knockback = 2.3f;
					Alpha = 30;
					Rarity = (sbyte)EntityID.RarityID.PINK;
					NoMelee = true;
					Scale = 1.1f;
					Value = 60000;
					IsRanged = true;
					break;
				case EntityID.ItemID.FIERY_GREATSWORD:
					UseStyle = 1;
					UseAnimation = 34;
					Knockback = 6.5f;
					Width = 24;
					Height = 28;
					Damage = 36;
					Scale = 1.3f;
					UseSound = 1;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					Value = 27000;
					IsMelee = true;
					break;
				case EntityID.ItemID.MOLTEN_PICKAXE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 25;
					UseTime = 25;
					AutoReuse = true;
					Width = 24;
					Height = 28;
					Damage = 12;
					PickPower = 100;
					Scale = 1.15f;
					UseSound = 1;
					Knockback = 2f;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					Value = 27000;
					IsMelee = true;
					break;
				case EntityID.ItemID.METEOR_HELMET:
					Width = 18;
					Height = 18;
					Defense = 3;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_METEOR_HELMET;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 45000;
					break;
				case EntityID.ItemID.METEOR_SUIT:
					Width = 18;
					Height = 18;
					Defense = 4;
					BodySlot = (short)EntityID.ArmorBodyID.BODY_METEOR_SUIT;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 30000;
					break;
				case EntityID.ItemID.METEOR_LEGGINGS:
					Width = 18;
					Height = 18;
					Defense = 3;
					LegSlot = (short)EntityID.ArmorLegsID.LEGS_METEOR_LEGGINGS;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 30000;
					break;
				case EntityID.ItemID.BOTTLED_WATER:
					UseSound = 3;
					HealLife = 20;
					UseStyle = 2;
					CanUseTurn = true;
					UseAnimation = 17;
					UseTime = 17;
					MaxStack = 30;
					IsConsumable = true;
					Width = 14;
					Height = 24;
					IsPotion = true;
					Value = 20;
					break;
				case EntityID.ItemID.SPACE_GUN:
					AutoReuse = true;
					UseStyle = 5;
					UseAnimation = 19;
					UseTime = 19;
					Width = 24;
					Height = 28;
					Shoot = (byte)EntityID.ProjectileID.GREEN_LASER;
					Mana = 8;
					UseSound = 12;
					Knockback = 0.5f;
					Damage = 17;
					ShootSpeed = 10f;
					NoMelee = true;
					Scale = 0.8f;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					IsMagic = true;
					Value = 20000;
					break;
				case EntityID.ItemID.ROCKET_BOOTS:
					Width = 28;
					Height = 24;
					IsAccessory = true;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					Value = 50000;
					break;
				case EntityID.ItemID.GRAY_BRICK:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.GRAY_BRICK;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.GRAY_BRICK_WALL:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 7;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateWall = (short)EntityID.WallID.GREY_BRICK;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.RED_BRICK:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.RED_BRICK;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.RED_BRICK_WALL:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 7;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateWall = (short)EntityID.WallID.RED_BRICK;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.CLAY_BLOCK:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.CLAY;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.BLUE_BRICK:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.BLUE_BRICK;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.BLUE_BRICK_WALL:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 7;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateWall = (short)EntityID.WallID.BLUE_DUNGEON;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.CHAIN_LANTERN:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.CHAIN_LANTERN;
					Width = 12;
					Height = 28;
					break;
				case EntityID.ItemID.GREEN_BRICK:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.GREEN_BRICK;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.GREEN_BRICK_WALL:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 7;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateWall = (short)EntityID.WallID.GREEN_DUNGEON;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.PINK_BRICK:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.PINK_BRICK;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.PINK_BRICK_WALL:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 7;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateWall = (short)EntityID.WallID.PINK_DUNGEON;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.GOLD_BRICK:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.GOLD_BRICK;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.GOLD_BRICK_WALL:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 7;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateWall = (short)EntityID.WallID.GOLD_BRICK;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.SILVER_BRICK:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.SILVER_BRICK;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.SILVER_BRICK_WALL:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 7;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateWall = (short)EntityID.WallID.SILVER_BRICK;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.COPPER_BRICK:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.COPPER_BRICK;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.COPPER_BRICK_WALL:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 7;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateWall = (short)EntityID.WallID.COPPER_BRICK;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.SPIKE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.SPIKE;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.WATER_CANDLE:
					CantTouchLiquid = true;
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.WATER_CANDLE;
					Width = 8;
					Height = 18;
					HoldStyle = 1;
					break;
				case EntityID.ItemID.BOOK:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.BOOK;
					Width = 24;
					Height = 28;
					break;
				case EntityID.ItemID.COBWEB:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.COBWEB;
					Width = 20;
					Height = 24;
					Alpha = 100;
					break;
				case EntityID.ItemID.NECRO_HELMET:
					Width = 18;
					Height = 18;
					Defense = 5;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_NECRO_HELMET;
					Rarity = (sbyte)EntityID.RarityID.GREEN;
					Value = 45000;
					break;
				case EntityID.ItemID.NECRO_BREASTPLATE:
					Width = 18;
					Height = 18;
					Defense = 6;
					BodySlot = (short)EntityID.ArmorBodyID.BODY_NECRO_BREASTPLATE;
					Rarity = (sbyte)EntityID.RarityID.GREEN;
					Value = 30000;
					break;
				case EntityID.ItemID.NECRO_GREAVES:
					Width = 18;
					Height = 18;
					Defense = 5;
					LegSlot = (short)EntityID.ArmorLegsID.LEGS_NECRO_GREAVES;
					Rarity = (sbyte)EntityID.RarityID.GREEN;
					Value = 30000;
					break;
				case EntityID.ItemID.BONE:
					MaxStack = 99;
					IsConsumable = true;
					Width = 12;
					Height = 14;
					Value = 50;
					UseAnimation = 12;
					UseTime = 12;
					UseStyle = 1;
					UseSound = 1;
					ShootSpeed = 8f;
					NoUseGraphic = true;
					Damage = 22;
					Knockback = 4f;
					Shoot = (byte)EntityID.ProjectileID.BONE;
					IsRanged = true;
					break;
				case EntityID.ItemID.MURAMASA:
					AutoReuse = true;
					CanUseTurn = true;
					UseStyle = 1;
					UseAnimation = 20;
					Width = 40;
					Height = 40;
					Damage = 18;
					Scale = 1.1f;
					UseSound = 1;
					Rarity = (sbyte)EntityID.RarityID.GREEN;
					Value = 27000;
					Knockback = 1f;
					IsMelee = true;
					break;
				case EntityID.ItemID.COBALT_SHIELD:
					Width = 24;
					Height = 28;
					Rarity = (sbyte)EntityID.RarityID.GREEN;
					Value = 27000;
					IsAccessory = true;
					Defense = 1;
					break;
				case EntityID.ItemID.AQUA_SCEPTER:
					Mana = 7;
					AutoReuse = true;
					UseStyle = 5;
					UseAnimation = 16;
					UseTime = 8;
					Knockback = 5f;
					Width = 38;
					Height = 10;
					Damage = 14;
					Scale = 1f;
					Shoot = (byte)EntityID.ProjectileID.WATER_STREAM;
					ShootSpeed = 11f;
					UseSound = 13;
					Rarity = (sbyte)EntityID.RarityID.GREEN;
					Value = 27000;
					IsMagic = true;
					break;
				case EntityID.ItemID.LUCKY_HORSESHOE:
					Width = 20;
					Height = 22;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 27000;
					IsAccessory = true;
					break;
				case EntityID.ItemID.SHINY_RED_BALLOON:
					Width = 14;
					Height = 28;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 27000;
					IsAccessory = true;
					break;
				case EntityID.ItemID.HARPOON:
					AutoReuse = true;
					UseStyle = 5;
					UseAnimation = 30;
					UseTime = 30;
					Knockback = 6f;
					Width = 30;
					Height = 10;
					Damage = 25;
					Scale = 1.1f;
					Shoot = (byte)EntityID.ProjectileID.HARPOON;
					ShootSpeed = 11f;
					UseSound = 10;
					Rarity = (sbyte)EntityID.RarityID.GREEN;
					Value = 27000;
					IsRanged = true;
					break;
				case EntityID.ItemID.SPIKY_BALL:
					UseStyle = 1;
					ShootSpeed = 5f;
					Shoot = (byte)EntityID.ProjectileID.SPIKY_BALL;
					Knockback = 1f;
					Damage = 15;
					Width = 10;
					Height = 10;
					MaxStack = 250;
					IsConsumable = true;
					UseSound = 1;
					UseAnimation = 15;
					UseTime = 15;
					NoUseGraphic = true;
					NoMelee = true;
					Value = 80;
					IsRanged = true;
					break;
				case EntityID.ItemID.BALL_O_HURT:
					UseStyle = 5;
					UseAnimation = 45;
					UseTime = 45;
					Knockback = 6.5f;
					Width = 30;
					Height = 10;
					Damage = 15;
					Scale = 1.1f;
					NoUseGraphic = true;
					Shoot = (byte)EntityID.ProjectileID.BALL_O_HURT;
					ShootSpeed = 12f;
					UseSound = 1;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 27000;
					IsMelee = true;
					Channelling = true;
					NoMelee = true;
					break;
				case EntityID.ItemID.BLUE_MOON:
					UseStyle = 5;
					UseAnimation = 45;
					UseTime = 45;
					Knockback = 7f;
					Width = 30;
					Height = 10;
					Damage = 23;
					Scale = 1.1f;
					NoUseGraphic = true;
					Shoot = (byte)EntityID.ProjectileID.BLUE_MOON;
					ShootSpeed = 12f;
					UseSound = 1;
					Rarity = (sbyte)EntityID.RarityID.GREEN;
					Value = 27000;
					IsMelee = true;
					Channelling = true;
					break;
				case EntityID.ItemID.HANDGUN:
					AutoReuse = false;
					UseStyle = 5;
					UseAnimation = 12;
					UseTime = 12;
					Width = 24;
					Height = 24;
					Shoot = (byte)EntityID.ProjectileID.BULLET;
					Knockback = 3f;
					UseAmmo = 14;
					UseSound = 11;
					Damage = 14;
					ShootSpeed = 10f;
					NoMelee = true;
					Value = 50000;
					Scale = 0.75f;
					Rarity = (sbyte)EntityID.RarityID.GREEN;
					IsRanged = true;
					break;
				case EntityID.ItemID.WATER_BOLT:
					AutoReuse = true;
					Rarity = (sbyte)EntityID.RarityID.GREEN;
					Mana = 14;
					UseSound = 21;
					UseStyle = 5;
					Damage = 17;
					UseAnimation = 17;
					UseTime = 17;
					Width = 24;
					Height = 28;
					Shoot = (byte)EntityID.ProjectileID.WATER_BOLT;
					Scale = 0.9f;
					ShootSpeed = 4.5f;
					Knockback = 5f;
					IsMagic = true;
					Value = 50000;
					break;
				case EntityID.ItemID.BOMB:
					UseStyle = 1;
					ShootSpeed = 5f;
					Shoot = (byte)EntityID.ProjectileID.BOMB;
					Width = 20;
					Height = 20;
					MaxStack = 50;
					IsConsumable = true;
					UseSound = 1;
					UseAnimation = 25;
					UseTime = 25;
					NoUseGraphic = true;
					NoMelee = true;
					Value = 500;
					Damage = 0;
					break;
				case EntityID.ItemID.DYNAMITE:
					UseStyle = 1;
					ShootSpeed = 4f;
					Shoot = (byte)EntityID.ProjectileID.DYNAMITE;
					Width = 8;
					Height = 28;
					MaxStack = 5;
					IsConsumable = true;
					UseSound = 1;
					UseAnimation = 40;
					UseTime = 40;
					NoUseGraphic = true;
					NoMelee = true;
					Value = 5000;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					break;
				case EntityID.ItemID.GRENADE:
					UseStyle = 5;
					ShootSpeed = 5.5f;
					Shoot = (byte)EntityID.ProjectileID.GRENADE;
					Width = 20;
					Height = 20;
					MaxStack = 99;
					IsConsumable = true;
					UseSound = 1;
					UseAnimation = 45;
					UseTime = 45;
					NoUseGraphic = true;
					NoMelee = true;
					Value = 400;
					Damage = 60;
					Knockback = 8f;
					IsRanged = true;
					break;
				case EntityID.ItemID.SAND_BLOCK:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.SAND;
					Width = 12;
					Height = 12;
					Ammo = 42;
					break;
				case EntityID.ItemID.GLASS:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.GLASS;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.SIGN:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.SIGN;
					Width = 28;
					Height = 28;
					break;
				case EntityID.ItemID.ASH_BLOCK:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.ASH;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.OBSIDIAN:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.OBSIDIAN;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.HELLSTONE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.HELLSTONE;
					Width = 12;
					Height = 12;
					Rarity = (sbyte)EntityID.RarityID.GREEN;
					break;
				case EntityID.ItemID.HELLSTONE_BAR:
					Width = 20;
					Height = 20;
					MaxStack = 99;
					Rarity = (sbyte)EntityID.RarityID.GREEN;
					Value = 20000;
					break;
				case EntityID.ItemID.MUD_BLOCK:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.MUD;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.AMETHYST:
					MaxStack = 99;
					Alpha = 50;
					Width = 10;
					Height = 14;
					Value = 1875;
					break;
				case EntityID.ItemID.TOPAZ:
					MaxStack = 99;
					Alpha = 50;
					Width = 10;
					Height = 14;
					Value = 3750;
					break;
				case EntityID.ItemID.SAPPHIRE:
					MaxStack = 99;
					Alpha = 50;
					Width = 10;
					Height = 14;
					Value = 5625;
					break;
				case EntityID.ItemID.EMERALD:
					MaxStack = 99;
					Alpha = 50;
					Width = 10;
					Height = 14;
					Value = 7500;
					break;
				case EntityID.ItemID.RUBY:
					MaxStack = 99;
					Alpha = 50;
					Width = 10;
					Height = 14;
					Value = 11250;
					break;
				case EntityID.ItemID.DIAMOND:
					MaxStack = 99;
					Alpha = 50;
					Width = 10;
					Height = 14;
					Value = 15000;
					break;
				case EntityID.ItemID.GLOWING_MUSHROOM:
					UseStyle = 2;
					UseSound = 2;
					CanUseTurn = false;
					UseAnimation = 17;
					UseTime = 17;
					Width = 16;
					Height = 18;
					HealLife = 25;
					MaxStack = 99;
					IsConsumable = true;
					IsPotion = true;
					Value = 50;
					break;
				case EntityID.ItemID.STAR:
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.IVY_WHIP:
					NoUseGraphic = true;
					Damage = 0;
					Knockback = 7f;
					UseStyle = 5;
					ShootSpeed = 13f;
					Shoot = (byte)EntityID.ProjectileID.IVY_WHIP;
					Width = 18;
					Height = 28;
					UseSound = 1;
					UseAnimation = 20;
					UseTime = 20;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					NoMelee = true;
					Value = 20000;
					break;
				case EntityID.ItemID.BREATHING_REED:
					Width = 44;
					Height = 44;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 10000;
					HoldStyle = 2;
					break;
				case EntityID.ItemID.FLIPPER:
					Width = 28;
					Height = 28;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 10000;
					IsAccessory = true;
					break;
				case EntityID.ItemID.HEALING_POTION:
					UseSound = 3;
					HealLife = 100;
					UseStyle = 2;
					CanUseTurn = true;
					UseAnimation = 17;
					UseTime = 17;
					MaxStack = 30;
					IsConsumable = true;
					Width = 14;
					Height = 24;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					IsPotion = true;
					Value = 1000;
					break;
				case EntityID.ItemID.MANA_POTION:
					UseSound = 3;
					HealMana = 100;
					UseStyle = 2;
					CanUseTurn = true;
					UseAnimation = 17;
					UseTime = 17;
					MaxStack = 50;
					IsConsumable = true;
					Width = 14;
					Height = 24;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 250;
					break;
				case EntityID.ItemID.BLADE_OF_GRASS:
					UseStyle = 1;
					UseAnimation = 30;
					Knockback = 3f;
					Width = 40;
					Height = 40;
					Damage = 28;
					Scale = 1.4f;
					UseSound = 1;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					Value = 27000;
					IsMelee = true;
					break;
				case EntityID.ItemID.THORN_CHAKRAM:
					NoMelee = true;
					UseStyle = 1;
					ShootSpeed = 11f;
					Shoot = (byte)EntityID.ProjectileID.THORN_CHAKRAM;
					Damage = 25;
					Knockback = 8f;
					Width = 14;
					Height = 28;
					UseSound = 1;
					UseAnimation = 15;
					UseTime = 15;
					NoUseGraphic = true;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					Value = 50000;
					IsMelee = true;
					break;
				case EntityID.ItemID.OBSIDIAN_BRICK:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.OBSIDIAN_BRICK;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.OBSIDIAN_SKULL:
					Width = 20;
					Height = 22;
					Rarity = (sbyte)EntityID.RarityID.GREEN;
					Value = 27000;
					IsAccessory = true;
					Defense = 1;
					break;
				case EntityID.ItemID.MUSHROOM_GRASS_SEEDS:
					CanUseTurn = true;
					UseStyle = 1;
					UseAnimation = 15;
					UseTime = 10;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.MUSHROOM_GRASS;
					Width = 14;
					Height = 14;
					Value = 150;
					break;
				case EntityID.ItemID.JUNGLE_GRASS_SEEDS:
					CanUseTurn = true;
					UseStyle = 1;
					UseAnimation = 15;
					UseTime = 10;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.JUNGLE_GRASS;
					Width = 14;
					Height = 14;
					Value = 150;
					break;
				case EntityID.ItemID.WOODEN_HAMMER:
					AutoReuse = true;
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 37;
					UseTime = 25;
					HammerPower = 25;
					Width = 24;
					Height = 28;
					Damage = 2;
					Knockback = 5.5f;
					Scale = 1.2f;
					UseSound = 1;
					TileBoost = -1;
					Value = 50;
					IsMelee = true;
					break;
				case EntityID.ItemID.STAR_CANNON:
					AutoReuse = true;
					UseStyle = 5;
					UseAnimation = 12;
					UseTime = 12;
					Width = 50;
					Height = 18;
					Shoot = (byte)EntityID.ProjectileID.FALLING_STAR;
					UseAmmo = 15;
					UseSound = 9;
					Damage = 55;
					ShootSpeed = 14f;
					NoMelee = true;
					Value = 500000;
					Rarity = (sbyte)EntityID.RarityID.GREEN;
					IsRanged = true;
					break;
				case EntityID.ItemID.BLUE_PHASEBLADE:
					UseStyle = 1;
					UseAnimation = 25;
					Knockback = 3f;
					Width = 40;
					Height = 40;
					Damage = 21;
					Scale = 1f;
					UseSound = 15;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 27000;
					IsMelee = true;
					break;
				case EntityID.ItemID.RED_PHASEBLADE:
					UseStyle = 1;
					UseAnimation = 25;
					Knockback = 3f;
					Width = 40;
					Height = 40;
					Damage = 21;
					Scale = 1f;
					UseSound = 15;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 27000;
					IsMelee = true;
					break;
				case EntityID.ItemID.GREEN_PHASEBLADE:
					UseStyle = 1;
					UseAnimation = 25;
					Knockback = 3f;
					Width = 40;
					Height = 40;
					Damage = 21;
					Scale = 1f;
					UseSound = 15;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 27000;
					IsMelee = true;
					break;
				case EntityID.ItemID.PURPLE_PHASEBLADE:
					UseStyle = 1;
					UseAnimation = 25;
					Knockback = 3f;
					Width = 40;
					Height = 40;
					Damage = 21;
					Scale = 1f;
					UseSound = 15;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 27000;
					IsMelee = true;
					break;
				case EntityID.ItemID.WHITE_PHASEBLADE:
					UseStyle = 1;
					UseAnimation = 25;
					Knockback = 3f;
					Width = 40;
					Height = 40;
					Damage = 21;
					Scale = 1f;
					UseSound = 15;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 27000;
					IsMelee = true;
					break;
				case EntityID.ItemID.YELLOW_PHASEBLADE:
					UseStyle = 1;
					UseAnimation = 25;
					Knockback = 3f;
					Width = 40;
					Height = 40;
					Damage = 21;
					Scale = 1f;
					UseSound = 15;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 27000;
					IsMelee = true;
					break;
				case EntityID.ItemID.METEOR_HAMAXE:
					CanUseTurn = true;
					AutoReuse = true;
					UseStyle = 1;
					UseAnimation = 30;
					UseTime = 16;
					HammerPower = 60;
					AxePower = 20;
					Width = 24;
					Height = 28;
					Damage = 20;
					Knockback = 7f;
					Scale = 1.2f;
					UseSound = 1;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 15000;
					IsMelee = true;
					break;
				case EntityID.ItemID.EMPTY_BUCKET:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					Width = 20;
					Height = 20;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_EMPTY_BUCKET;
					Defense = 1;
					break;
				case EntityID.ItemID.WATER_BUCKET:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					Width = 20;
					Height = 20;
					break;
				case EntityID.ItemID.LAVA_BUCKET:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					Width = 20;
					Height = 20;
					break;
				case EntityID.ItemID.JUNGLE_ROSE:
					Width = 20;
					Height = 20;
					Value = 100;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_JUNGLE_ROSE;
					IsVanity = true;
					break;
				case EntityID.ItemID.STINGER:
					Width = 16;
					Height = 18;
					MaxStack = 99;
					Value = 200;
					break;
				case EntityID.ItemID.VINE:
					Width = 14;
					Height = 20;
					MaxStack = 99;
					Value = 1000;
					break;
				case EntityID.ItemID.FERAL_CLAWS:
					Width = 20;
					Height = 20;
					IsAccessory = true;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					Value = 50000;
					break;
				case EntityID.ItemID.ANKLET_OF_THE_WIND:
					Width = 20;
					Height = 20;
					IsAccessory = true;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					Value = 50000;
					break;
				case EntityID.ItemID.STAFF_OF_REGROWTH:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 25;
					UseTime = 13;
					AutoReuse = true;
					Width = 24;
					Height = 28;
					Damage = 7;
					CreateTile = (short)EntityID.TileID.GRASS;
					Scale = 1.2f;
					UseSound = 1;
					Knockback = 3f;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					Value = 2000;
					IsMelee = true;
					break;
				case EntityID.ItemID.HELLSTONE_BRICK:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.HELLSTONE_BRICK;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.WHOOPIE_CUSHION:
					Width = 18;
					Height = 18;
					CanUseTurn = true;
					UseTime = 30;
					UseAnimation = 30;
					NoUseGraphic = true;
#if (!VERSION_INITIAL || IS_PATCHED)
					NoMelee = true;
#endif
					UseStyle = 10;
					UseSound = 16;
					Rarity = (sbyte)EntityID.RarityID.GREEN;
					Value = 100;
					break;
				case EntityID.ItemID.SHACKLE:
					Width = 20;
					Height = 20;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 1500;
					IsAccessory = true;
					Defense = 1;
					break;
				case EntityID.ItemID.MOLTEN_HAMAXE:
					CanUseTurn = true;
					AutoReuse = true;
					UseStyle = 1;
					UseAnimation = 27;
					UseTime = 14;
					HammerPower = 70;
					AxePower = 30;
					Width = 24;
					Height = 28;
					Damage = 20;
					Knockback = 7f;
					Scale = 1.4f;
					UseSound = 1;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					Value = 15000;
					IsMelee = true;
					break;
				case EntityID.ItemID.FLAMELASH:
					Mana = 16;
					Channelling = true;
					Damage = 34;
					UseStyle = 1;
					ShootSpeed = 6f;
					Shoot = (byte)EntityID.ProjectileID.FLAMELASH;
					Width = 26;
					Height = 28;
					UseSound = 20;
					UseAnimation = 20;
					UseTime = 20;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					NoMelee = true;
					Knockback = 6.5f;
					TileBoost = 64;
					Value = 10000;
					IsMagic = true;
					break;
				case EntityID.ItemID.PHOENIX_BLASTER:
					AutoReuse = false;
					UseStyle = 5;
					UseAnimation = 11;
					UseTime = 11;
					Width = 24;
					Height = 22;
					Shoot = (byte)EntityID.ProjectileID.BULLET;
					Knockback = 2f;
					UseAmmo = 14;
					UseSound = 11;
					Damage = 23;
					ShootSpeed = 13f;
					NoMelee = true;
					Value = 50000;
					Scale = 0.75f;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					IsRanged = true;
					break;
				case EntityID.ItemID.SUNFURY:
					NoMelee = true;
					UseStyle = 5;
					UseAnimation = 45;
					UseTime = 45;
					Knockback = 7f;
					Width = 30;
					Height = 10;
					Damage = 33;
					Scale = 1.1f;
					NoUseGraphic = true;
					Shoot = (byte)EntityID.ProjectileID.SUNFURY;
					ShootSpeed = 12f;
					UseSound = 1;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					Value = 27000;
					IsMelee = true;
					Channelling = true;
					break;
				case EntityID.ItemID.HELLFORGE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.HELLFORGE;
					Width = 26;
					Height = 24;
					Value = 3000;
					break;
				case EntityID.ItemID.CLAY_POT:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.CLAY_POT;
					Width = 14;
					Height = 14;
					Value = 100;
					break;
				case EntityID.ItemID.NATURES_GIFT:
					Width = 20;
					Height = 22;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					Value = 27000;
					IsAccessory = true;
					break;
				case EntityID.ItemID.BED:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.BED;
					Width = 28;
					Height = 20;
					Value = 2000;
					break;
				case EntityID.ItemID.SILK:
					MaxStack = 99;
					Width = 22;
					Height = 22;
					Value = 1000;
					break;
				case EntityID.ItemID.LESSER_RESTORATION_POTION:
					UseSound = 3;
					HealMana = 50;
					HealLife = 50;
					UseStyle = 2;
					CanUseTurn = true;
					UseAnimation = 17;
					UseTime = 17;
					MaxStack = 20;
					IsConsumable = true;
					Width = 14;
					Height = 24;
					IsPotion = true;
					Value = 2000;
					break;
				case EntityID.ItemID.RESTORATION_POTION:
					UseSound = 3;
					HealMana = 100;
					HealLife = 100;
					UseStyle = 2;
					CanUseTurn = true;
					UseAnimation = 17;
					UseTime = 17;
					MaxStack = 20;
					IsConsumable = true;
					Width = 14;
					Height = 24;
					IsPotion = true;
					Value = 4000;
					break;
				case EntityID.ItemID.JUNGLE_HAT:
					Width = 18;
					Height = 18;
					Defense = 4;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_JUNGLE_HAT;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					Value = 45000;
					break;
				case EntityID.ItemID.JUNGLE_SHIRT:
					Width = 18;
					Height = 18;
					Defense = 5;
					BodySlot = (short)EntityID.ArmorBodyID.BODY_JUNGLE_SHIRT;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					Value = 30000;
					break;
				case EntityID.ItemID.JUNGLE_PANTS:
					Width = 18;
					Height = 18;
					Defense = 4;
					LegSlot = (short)EntityID.ArmorLegsID.LEGS_JUNGLE_PANTS;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					Value = 30000;
					break;
				case EntityID.ItemID.MOLTEN_HELMET:
					Width = 18;
					Height = 18;
					Defense = 8;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_MOLTEN_HELMET;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					Value = 45000;
					break;
				case EntityID.ItemID.MOLTEN_BREASTPLATE:
					Width = 18;
					Height = 18;
					Defense = 9;
					BodySlot = (short)EntityID.ArmorBodyID.BODY_MOLTEN_BREASTPLATE;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					Value = 30000;
					break;
				case EntityID.ItemID.MOLTEN_GREAVES:
					Width = 18;
					Height = 18;
					Defense = 8;
					LegSlot = (short)EntityID.ArmorLegsID.LEGS_MOLTEN_GREAVES;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					Value = 30000;
					break;
				case EntityID.ItemID.METEOR_SHOT:
					ShootSpeed = 3f;
					Shoot = (byte)EntityID.ProjectileID.METEOR_SHOT;
					Damage = 9;
					Width = 8;
					Height = 8;
					MaxStack = 250;
					IsConsumable = true;
					Ammo = 14;
					Knockback = 1f;
					Value = 8;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					IsRanged = true;
					break;
				case EntityID.ItemID.STICKY_BOMB:
					UseStyle = 1;
					ShootSpeed = 5f;
					Shoot = (byte)EntityID.ProjectileID.STICKY_BOMB;
					Width = 20;
					Height = 20;
					MaxStack = 50;
					IsConsumable = true;
					UseSound = 1;
					UseAnimation = 25;
					UseTime = 25;
					NoUseGraphic = true;
					NoMelee = true;
					Value = 500;
					Damage = 0;
					break;
				case EntityID.ItemID.BLACK_LENS:
					Width = 12;
					Height = 20;
					MaxStack = 99;
					Value = 5000;
					break;
				case EntityID.ItemID.SUNGLASSES:
					Width = 28;
					Height = 12;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_SUNGLASSES;
					Rarity = (sbyte)EntityID.RarityID.GREEN;
					Value = 10000;
					IsVanity = true;
					break;
				case EntityID.ItemID.WIZARD_HAT:
					Width = 28;
					Height = 20;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_WIZARD_HAT;
					Rarity = (sbyte)EntityID.RarityID.GREEN;
					Value = 10000;
					Defense = 2;
					break;
				case EntityID.ItemID.TOP_HAT:
					Width = 18;
					Height = 18;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_TOP_HAT;
					Value = 10000;
					IsVanity = true;
					break;
				case EntityID.ItemID.TUXEDO_SHIRT:
					Width = 18;
					Height = 18;
					BodySlot = (short)EntityID.ArmorBodyID.BODY_TUXEDO_SHIRT;
					Value = 5000;
					IsVanity = true;
					break;
				case EntityID.ItemID.TUXEDO_PANTS:
					Width = 18;
					Height = 18;
					LegSlot = (short)EntityID.ArmorLegsID.LEGS_TUXEDO_PANTS;
					Value = 5000;
					IsVanity = true;
					break;
				case EntityID.ItemID.SUMMER_HAT:
					Width = 18;
					Height = 18;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_SUMMER_HAT;
					Value = 10000;
					IsVanity = true;
					break;
				case EntityID.ItemID.BUNNY_HOOD:
					Width = 18;
					Height = 18;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_BUNNY_HOOD;
					Value = 20000;
					IsVanity = true;
					break;
				case EntityID.ItemID.PLUMBERS_HAT:
					Width = 18;
					Height = 12;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_PLUMBERS_HAT;
					Value = 10000;
					IsVanity = true;
					break;
				case EntityID.ItemID.PLUMBERS_SHIRT:
					Width = 18;
					Height = 18;
					BodySlot = (short)EntityID.ArmorBodyID.BODY_PLUMBERS_SHIRT;
					Value = 250000;
					IsVanity = true;
					break;
				case EntityID.ItemID.PLUMBERS_PANTS:
					Width = 18;
					Height = 18;
					LegSlot = (short)EntityID.ArmorLegsID.LEGS_PLUMBERS_PANTS;
					Value = 250000;
					IsVanity = true;
					break;
				case EntityID.ItemID.HEROS_HAT:
					Width = 18;
					Height = 12;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_HEROS_HAT;
					Value = 10000;
					IsVanity = true;
					break;
				case EntityID.ItemID.HEROS_SHIRT:
					Width = 18;
					Height = 18;
					BodySlot = (short)EntityID.ArmorBodyID.BODY_HEROS_SHIRT;
					Value = 5000;
					IsVanity = true;
					break;
				case EntityID.ItemID.HEROS_PANTS:
					Width = 18;
					Height = 18;
					LegSlot = (short)EntityID.ArmorLegsID.LEGS_HEROS_PANTS;
					Value = 5000;
					IsVanity = true;
					break;
				case EntityID.ItemID.FISH_BOWL:
					Width = 18;
					Height = 18;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_FISH_BOWL;
					Value = 10000;
					IsVanity = true;
					break;
				case EntityID.ItemID.ARCHAEOLOGISTS_HAT:
					Width = 18;
					Height = 12;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_ARCHAEOLOGISTS_HAT;
					Value = 10000;
					IsVanity = true;
					break;
				case EntityID.ItemID.ARCHAEOLOGISTS_JACKET:
					Width = 18;
					Height = 18;
					BodySlot = (short)EntityID.ArmorBodyID.BODY_ARCHAEOLOGISTS_JACKET;
					Value = 5000;
					IsVanity = true;
					break;
				case EntityID.ItemID.ARCHAEOLOGISTS_PANTS:
					Width = 18;
					Height = 18;
					LegSlot = (short)EntityID.ArmorLegsID.LEGS_ARCHAEOLOGISTS_PANTS;
					Value = 5000;
					IsVanity = true;
					break;
				case EntityID.ItemID.BLACK_THREAD:
					MaxStack = 99;
					Width = 12;
					Height = 20;
					Value = 10000;
					break;
				case EntityID.ItemID.PURPLE_THREAD:
					MaxStack = 99;
					Width = 12;
					Height = 20;
					Value = 2000;
					break;
				case EntityID.ItemID.NINJA_HOOD:
					Width = 18;
					Height = 12;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_NINJA_HOOD;
					Value = 10000;
					IsVanity = true;
					break;
				case EntityID.ItemID.NINJA_SHIRT:
					Width = 18;
					Height = 18;
					BodySlot = (short)EntityID.ArmorBodyID.BODY_NINJA_SHIRT;
					Value = 5000;
					IsVanity = true;
					break;
				case EntityID.ItemID.NINJA_PANTS:
					Width = 18;
					Height = 18;
					LegSlot = (short)EntityID.ArmorLegsID.LEGS_NINJA_PANTS;
					Value = 5000;
					IsVanity = true;
					break;
				case EntityID.ItemID.LEATHER:
					Width = 18;
					Height = 20;
					MaxStack = 99;
					Value = 50;
					break;
				case EntityID.ItemID.RED_HAT:
					Width = 18;
					Height = 14;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_RED_HAT;
					Value = 1000;
					IsVanity = true;
					break;
				case EntityID.ItemID.GOLDFISH:
					UseStyle = 2;
					UseSound = 2;
					CanUseTurn = false;
					UseAnimation = 17;
					UseTime = 17;
					Width = 20;
					Height = 10;
					MaxStack = 99;
					HealLife = 20;
					IsConsumable = true;
					Value = 1000;
					IsPotion = true;
					break;
				case EntityID.ItemID.ROBE:
					Width = 18;
					Height = 14;
					BodySlot = (short)EntityID.ArmorBodyID.BODY_ROBE;
					Value = 2000;
					IsVanity = true;
					break;
				case EntityID.ItemID.ROBOT_HAT:
					Width = 18;
					Height = 18;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_ROBOT_HAT;
					Value = 10000;
					IsVanity = true;
					break;
				case EntityID.ItemID.GOLD_CROWN:
					Width = 18;
					Height = 18;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_GOLD_CROWN;
					Value = 10000;
					IsVanity = true;
					break;
				case EntityID.ItemID.HELLFIRE_ARROW:
					ShootSpeed = 6.5f;
					Shoot = (byte)EntityID.ProjectileID.HELLFIRE_ARROW;
					Damage = 10;
					Width = 10;
					Height = 28;
					MaxStack = 250;
					IsConsumable = true;
					Ammo = 1;
					Knockback = 8f;
					Value = 100;
					Rarity = (sbyte)EntityID.RarityID.GREEN;
					IsRanged = true;
					break;
				case EntityID.ItemID.VULCAN_BOLT:
					ShootSpeed = 6.6f;
					Shoot = (byte)EntityID.ProjectileID.VULCAN_BOLT;
					Damage = 12;
					Width = 10;
					Height = 28;
					MaxStack = 250;
					IsConsumable = true;
					Ammo = 1;
					Knockback = 8.2f;
					Value = 150;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					IsRanged = true;
					break;
				case EntityID.ItemID.SANDGUN:
					UseStyle = 5;
					UseAnimation = 16;
					UseTime = 16;
					AutoReuse = true;
					Width = 40;
					Height = 20;
					Shoot = (byte)EntityID.ProjectileID.SAND_BALL_GUN;
					UseAmmo = 42;
					UseSound = 11;
					Damage = 30;
					ShootSpeed = 12f;
					NoMelee = true;
					Knockback = 5f;
					Value = 10000;
					Rarity = (sbyte)EntityID.RarityID.GREEN;
					IsRanged = true;
					break;
				case EntityID.ItemID.GUIDE_VOODOO_DOLL:
					IsAccessory = true;
					Width = 14;
					Height = 26;
					Value = 1000;
					break;
				case EntityID.ItemID.DIVING_HELMET:
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_DIVING_HELMET;
					Defense = 2;
					Width = 20;
					Height = 20;
					Value = 1000;
					Rarity = (sbyte)EntityID.RarityID.GREEN;
					break;
				case EntityID.ItemID.FAMILIAR_SHIRT:
					BodySlot = (short)EntityID.ArmorBodyID.BODY_NORMAL;
					Width = 20;
					Height = 20;
					Value = 10000;
					if (UI.CurrentUI.ActivePlayer != null)
					{
						Colour = UI.CurrentUI.ActivePlayer.shirtColor;
					}
					break;
				case EntityID.ItemID.FAMILIAR_PANTS:
					LegSlot = (short)EntityID.ArmorLegsID.LEGS_NORMAL;
					Width = 20;
					Height = 20;
					Value = 10000;
					if (UI.CurrentUI.ActivePlayer != null)
					{
						Colour = UI.CurrentUI.ActivePlayer.pantsColor;
					}
					break;
				case EntityID.ItemID.FAMILIAR_WIG:
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_NORMAL;
					Width = 20;
					Height = 20;
					Value = 10000;
					if (UI.CurrentUI.ActivePlayer != null)
					{
						Colour = UI.CurrentUI.ActivePlayer.hairColor;
					}
					break;
				case EntityID.ItemID.DEMON_SCYTHE:
					Mana = 14;
					Damage = 35;
					UseStyle = 5;
					ShootSpeed = 0.2f;
					Shoot = (byte)EntityID.ProjectileID.DEMON_SCYTHE;
					Width = 26;
					Height = 28;
					UseSound = 8;
					UseAnimation = 20;
					UseTime = 20;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					NoMelee = true;
					Knockback = 5f;
					Scale = 0.9f;
					Value = 10000;
					IsMagic = true;
					break;
				case EntityID.ItemID.NIGHTS_EDGE:
					UseStyle = 1;
					UseAnimation = 27;
					UseTime = 27;
					Knockback = 4.5f;
					Width = 40;
					Height = 40;
					Damage = 42;
					Scale = 1.15f;
					UseSound = 1;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					Value = 27000;
					IsMelee = true;
					break;
				case EntityID.ItemID.DARK_LANCE:
					UseStyle = 5;
					UseAnimation = 25;
					UseTime = 25;
					ShootSpeed = 5f;
					Knockback = 4f;
					Width = 40;
					Height = 40;
					Damage = 27;
					Scale = 1.1f;
					UseSound = 1;
					Shoot = (byte)EntityID.ProjectileID.DARK_LANCE;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					Value = 27000;
					NoMelee = true;
					NoUseGraphic = true;
					IsMelee = true;
					break;
				case EntityID.ItemID.CORAL:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.CORAL;
					Width = 20;
					Height = 22;
					Value = 400;
					break;
				case EntityID.ItemID.CACTUS:
					MaxStack = 250;
					Width = 12;
					Height = 12;
					Value = 10;
					break;
				case EntityID.ItemID.TRIDENT:
					UseStyle = 5;
					UseAnimation = 31;
					UseTime = 31;
					ShootSpeed = 4f;
					Knockback = 5f;
					Width = 40;
					Height = 40;
					Damage = 10;
					Scale = 1.1f;
					UseSound = 1;
					Shoot = (byte)EntityID.ProjectileID.TRIDENT;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 10000;
					NoMelee = true;
					NoUseGraphic = true;
					IsMelee = true;
					break;
				case EntityID.ItemID.SILVER_BULLET:
					ShootSpeed = 4.5f;
					Shoot = (byte)EntityID.ProjectileID.BULLET;
					Damage = 9;
					Width = 8;
					Height = 8;
					MaxStack = 250;
					IsConsumable = true;
					Ammo = 14;
					Knockback = 3f;
					Value = 15;
					IsRanged = true;
					break;
				case EntityID.ItemID.THROWING_KNIFE:
					UseStyle = 1;
					ShootSpeed = 10f;
					Shoot = (byte)EntityID.ProjectileID.THROWING_KNIFE;
					Damage = 12;
					Width = 18;
					Height = 20;
					MaxStack = 250;
					IsConsumable = true;
					UseSound = 1;
					UseAnimation = 15;
					UseTime = 15;
					NoUseGraphic = true;
					NoMelee = true;
					Value = 50;
					Knockback = 2f;
					IsRanged = true;
					break;
				case EntityID.ItemID.SPEAR:
					UseStyle = 5;
					UseAnimation = 31;
					UseTime = 31;
					ShootSpeed = 3.7f;
					Knockback = 6.5f;
					Width = 32;
					Height = 32;
					Damage = 8;
					Scale = 1f;
					UseSound = 1;
					Shoot = (byte)EntityID.ProjectileID.SPEAR;
					Value = 1000;
					NoMelee = true;
					NoUseGraphic = true;
					IsMelee = true;
					break;
				case EntityID.ItemID.BLOWPIPE:
					UseStyle = 5;
					AutoReuse = true;
					UseAnimation = 45;
					UseTime = 45;
					Width = 38;
					Height = 6;
					Shoot = (byte)EntityID.ProjectileID.PURIFICATION_POWDER;
					UseAmmo = 51;
					UseSound = 5;
					Damage = 9;
					ShootSpeed = 11f;
					NoMelee = true;
					Value = 10000;
					Knockback = 4f;
					IsRanged = true;
					break;
				case EntityID.ItemID.GLOWSTICK:
					UseStyle = 1;
					ShootSpeed = 6f;
					Shoot = (byte)EntityID.ProjectileID.GLOWSTICK;
					Width = 12;
					Height = 12;
					MaxStack = 99;
					IsConsumable = true;
					UseSound = 1;
					UseAnimation = 15;
					UseTime = 15;
					NoMelee = true;
					Value = 10;
					HoldStyle = 1;
					break;
				case EntityID.ItemID.SEED:
					Shoot = (byte)EntityID.ProjectileID.SEED;
					Width = 8;
					Height = 8;
					MaxStack = 250;
					Ammo = 51;
					break;
				case EntityID.ItemID.WOODEN_BOOMERANG:
					NoMelee = true;
					UseStyle = 1;
					ShootSpeed = 6.5f;
					Shoot = (byte)EntityID.ProjectileID.WOODEN_BOOMERANG;
					Damage = 7;
					Knockback = 5f;
					Width = 14;
					Height = 28;
					UseSound = 1;
					UseAnimation = 16;
					UseTime = 16;
					NoUseGraphic = true;
					Value = 5000;
					IsMelee = true;
					break;
				case EntityID.ItemID.AGLET:
					Width = 24;
					Height = 8;
					IsAccessory = true;
					Value = 5000;
					break;
				case EntityID.ItemID.STICKY_GLOWSTICK:
					UseStyle = 1;
					ShootSpeed = 6f;
					Shoot = (byte)EntityID.ProjectileID.STICKY_GLOWSTICK;
					Width = 12;
					Height = 12;
					MaxStack = 99;
					IsConsumable = true;
					UseSound = 1;
					UseAnimation = 15;
					UseTime = 15;
					NoMelee = true;
					Value = 20;
					HoldStyle = 1;
					break;
				case EntityID.ItemID.POISONED_KNIFE:
					UseStyle = 1;
					ShootSpeed = 11f;
					Shoot = (byte)EntityID.ProjectileID.POISONED_KNIFE;
					Damage = 13;
					Width = 18;
					Height = 20;
					MaxStack = 250;
					IsConsumable = true;
					UseSound = 1;
					UseAnimation = 15;
					UseTime = 15;
					NoUseGraphic = true;
					NoMelee = true;
					Value = 60;
					Knockback = 2f;
					IsRanged = true;
					break;
				case EntityID.ItemID.OBSIDIAN_SKIN_POTION:
					UseSound = 3;
					UseStyle = 2;
					CanUseTurn = true;
					UseAnimation = 17;
					UseTime = 17;
					MaxStack = 30;
					IsConsumable = true;
					Width = 14;
					Height = 24;
					BuffType = (int)EntityID.BuffID.LAVA_IMMUNE;
					BuffTime = 14400;
					Value = 1000;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					break;
				case EntityID.ItemID.REGENERATION_POTION:
					UseSound = 3;
					UseStyle = 2;
					CanUseTurn = true;
					UseAnimation = 17;
					UseTime = 17;
					MaxStack = 30;
					IsConsumable = true;
					Width = 14;
					Height = 24;
					BuffType = (int)EntityID.BuffID.LIFE_REGEN;
					BuffTime = 18000;
					Value = 1000;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					break;
				case EntityID.ItemID.SWIFTNESS_POTION:
					UseSound = 3;
					UseStyle = 2;
					CanUseTurn = true;
					UseAnimation = 17;
					UseTime = 17;
					MaxStack = 30;
					IsConsumable = true;
					Width = 14;
					Height = 24;
					BuffType = (int)EntityID.BuffID.HASTE;
					BuffTime = 14400;
					Value = 1000;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					break;
				case EntityID.ItemID.GILLS_POTION:
					UseSound = 3;
					UseStyle = 2;
					CanUseTurn = true;
					UseAnimation = 17;
					UseTime = 17;
					MaxStack = 30;
					IsConsumable = true;
					Width = 14;
					Height = 24;
					BuffType = (int)EntityID.BuffID.GILLS;
					BuffTime = 7200;
					Value = 1000;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					break;
				case EntityID.ItemID.IRONSKIN_POTION:
					UseSound = 3;
					UseStyle = 2;
					CanUseTurn = true;
					UseAnimation = 17;
					UseTime = 17;
					MaxStack = 30;
					IsConsumable = true;
					Width = 14;
					Height = 24;
					BuffType = (int)EntityID.BuffID.IRONSKIN;
					BuffTime = 18000;
					Value = 1000;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					break;
				case EntityID.ItemID.MANA_REGENERATION_POTION:
					UseSound = 3;
					UseStyle = 2;
					CanUseTurn = true;
					UseAnimation = 17;
					UseTime = 17;
					MaxStack = 30;
					IsConsumable = true;
					Width = 14;
					Height = 24;
					BuffType = (int)EntityID.BuffID.MANA_REGEN;
					BuffTime = 7200;
					Value = 1000;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					break;
				case EntityID.ItemID.MAGIC_POWER_POTION:
					UseSound = 3;
					UseStyle = 2;
					CanUseTurn = true;
					UseAnimation = 17;
					UseTime = 17;
					MaxStack = 30;
					IsConsumable = true;
					Width = 14;
					Height = 24;
					BuffType = (int)EntityID.BuffID.MAGIC_POWER;
					BuffTime = 7200;
					Value = 1000;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					break;
				case EntityID.ItemID.FEATHERFALL_POTION:
					UseSound = 3;
					UseStyle = 2;
					CanUseTurn = true;
					UseAnimation = 17;
					UseTime = 17;
					MaxStack = 30;
					IsConsumable = true;
					Width = 14;
					Height = 24;
					BuffType = (int)EntityID.BuffID.SLOWFALL;
					BuffTime = 18000;
					Value = 1000;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					break;
				case EntityID.ItemID.SPELUNKER_POTION:
					UseSound = 3;
					UseStyle = 2;
					CanUseTurn = true;
					UseAnimation = 17;
					UseTime = 17;
					MaxStack = 30;
					IsConsumable = true;
					Width = 14;
					Height = 24;
					BuffType = (int)EntityID.BuffID.FIND_TREASURE;
					BuffTime = 18000;
					Value = 1000;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					break;
				case EntityID.ItemID.INVISIBILITY_POTION:
					UseSound = 3;
					UseStyle = 2;
					CanUseTurn = true;
					UseAnimation = 17;
					UseTime = 17;
					MaxStack = 30;
					IsConsumable = true;
					Width = 14;
					Height = 24;
					BuffType = (int)EntityID.BuffID.INVISIBLE;
					BuffTime = 7200;
					Value = 1000;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					break;
				case EntityID.ItemID.SHINE_POTION:
					UseSound = 3;
					UseStyle = 2;
					CanUseTurn = true;
					UseAnimation = 17;
					UseTime = 17;
					MaxStack = 30;
					IsConsumable = true;
					Width = 14;
					Height = 24;
					BuffType = (int)EntityID.BuffID.SHINE;
					BuffTime = 18000;
					Value = 1000;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					break;
				case EntityID.ItemID.NIGHT_OWL_POTION:
					UseSound = 3;
					UseStyle = 2;
					CanUseTurn = true;
					UseAnimation = 17;
					UseTime = 17;
					MaxStack = 30;
					IsConsumable = true;
					Width = 14;
					Height = 24;
					BuffType = (int)EntityID.BuffID.NIGHTVISION;
					BuffTime = 14400;
					Value = 1000;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					break;
				case EntityID.ItemID.BATTLE_POTION:
					UseSound = 3;
					UseStyle = 2;
					CanUseTurn = true;
					UseAnimation = 17;
					UseTime = 17;
					MaxStack = 30;
					IsConsumable = true;
					Width = 14;
					Height = 24;
					BuffType = (int)EntityID.BuffID.ENEMY_SPAWNS;
					BuffTime = 25200;
					Value = 1000;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					break;
				case EntityID.ItemID.THORNS_POTION:
					UseSound = 3;
					UseStyle = 2;
					CanUseTurn = true;
					UseAnimation = 17;
					UseTime = 17;
					MaxStack = 30;
					IsConsumable = true;
					Width = 14;
					Height = 24;
					BuffType = (int)EntityID.BuffID.THORNS;
					BuffTime = 7200;
					Value = 1000;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					break;
				case EntityID.ItemID.WATER_WALKING_POTION:
					UseSound = 3;
					UseStyle = 2;
					CanUseTurn = true;
					UseAnimation = 17;
					UseTime = 17;
					MaxStack = 30;
					IsConsumable = true;
					Width = 14;
					Height = 24;
					BuffType = (int)EntityID.BuffID.WATER_WALK;
					BuffTime = 18000;
					Value = 1000;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					break;
				case EntityID.ItemID.ARCHERY_POTION:
					UseSound = 3;
					UseStyle = 2;
					CanUseTurn = true;
					UseAnimation = 17;
					UseTime = 17;
					MaxStack = 30;
					IsConsumable = true;
					Width = 14;
					Height = 24;
					BuffType = (int)EntityID.BuffID.RANGED_DAMAGE;
					BuffTime = 14400;
					Value = 1000;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					break;
				case EntityID.ItemID.HUNTER_POTION:
					UseSound = 3;
					UseStyle = 2;
					CanUseTurn = true;
					UseAnimation = 17;
					UseTime = 17;
					MaxStack = 30;
					IsConsumable = true;
					Width = 14;
					Height = 24;
					BuffType = (int)EntityID.BuffID.DETECT_CREATURE;
					BuffTime = 18000;
					Value = 1000;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					break;
				case EntityID.ItemID.GRAVITATION_POTION:
					UseSound = 3;
					UseStyle = 2;
					CanUseTurn = true;
					UseAnimation = 17;
					UseTime = 17;
					MaxStack = 30;
					IsConsumable = true;
					Width = 14;
					Height = 24;
					BuffType = (int)EntityID.BuffID.GRAVITY_CONTROL;
					BuffTime = 10800;
					Value = 1000;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					break;
				case EntityID.ItemID.GOLD_CHEST:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.CHEST;
					PlaceStyle = 1;
					Width = 26;
					Height = 22;
					Value = 5000;
					break;
				case EntityID.ItemID.DAYBLOOM_SEEDS:
					CanUseTurn = true;
					UseStyle = 1;
					UseAnimation = 15;
					UseTime = 10;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.DAYBLOOM_GROWING;
					PlaceStyle = 0;
					Width = 12;
					Height = 14;
					Value = 80;
					break;
				case EntityID.ItemID.MOONGLOW_SEEDS:
					CanUseTurn = true;
					UseStyle = 1;
					UseAnimation = 15;
					UseTime = 10;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.DAYBLOOM_GROWING;
					PlaceStyle = 1;
					Width = 12;
					Height = 14;
					Value = 80;
					break;
				case EntityID.ItemID.BLINKROOT_SEEDS:
					CanUseTurn = true;
					UseStyle = 1;
					UseAnimation = 15;
					UseTime = 10;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.DAYBLOOM_GROWING;
					PlaceStyle = 2;
					Width = 12;
					Height = 14;
					Value = 80;
					break;
				case EntityID.ItemID.DEATHWEED_SEEDS:
					CanUseTurn = true;
					UseStyle = 1;
					UseAnimation = 15;
					UseTime = 10;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.DAYBLOOM_GROWING;
					PlaceStyle = 3;
					Width = 12;
					Height = 14;
					Value = 80;
					break;
				case EntityID.ItemID.WATERLEAF_SEEDS:
					CanUseTurn = true;
					UseStyle = 1;
					UseAnimation = 15;
					UseTime = 10;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.DAYBLOOM_GROWING;
					PlaceStyle = 4;
					Width = 12;
					Height = 14;
					Value = 80;
					break;
				case EntityID.ItemID.FIREBLOSSOM_SEEDS:
					CanUseTurn = true;
					UseStyle = 1;
					UseAnimation = 15;
					UseTime = 10;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.DAYBLOOM_GROWING;
					PlaceStyle = 5;
					Width = 12;
					Height = 14;
					Value = 80;
					break;
				case EntityID.ItemID.DAYBLOOM:
					MaxStack = 99;
					Width = 12;
					Height = 14;
					Value = 100;
					break;
				case EntityID.ItemID.MOONGLOW:
					MaxStack = 99;
					Width = 12;
					Height = 14;
					Value = 100;
					break;
				case EntityID.ItemID.BLINKROOT:
					MaxStack = 99;
					Width = 12;
					Height = 14;
					Value = 100;
					break;
				case EntityID.ItemID.DEATHWEED:
					MaxStack = 99;
					Width = 12;
					Height = 14;
					Value = 100;
					break;
				case EntityID.ItemID.WATERLEAF:
					MaxStack = 99;
					Width = 12;
					Height = 14;
					Value = 100;
					break;
				case EntityID.ItemID.FIREBLOSSOM:
					MaxStack = 99;
					Width = 12;
					Height = 14;
					Value = 100;
					break;
				case EntityID.ItemID.SHARK_FIN:
					MaxStack = 99;
					Width = 16;
					Height = 14;
					Value = 200;
					break;
				case EntityID.ItemID.FEATHER:
					MaxStack = 99;
					Width = 16;
					Height = 14;
					Value = 50;
					break;
				case EntityID.ItemID.TOMBSTONE:
					CanUseTurn = true;
					UseStyle = 1;
					UseAnimation = 15;
					UseTime = 10;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.TOMBSTONE;
					Width = 20;
					Height = 20;
					break;
				case EntityID.ItemID.MIME_MASK:
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_MIME_MASK;
					Width = 20;
					Height = 20;
					Value = 20000;
					break;
				case EntityID.ItemID.ANTLION_MANDIBLE:
					Width = 10;
					Height = 20;
					MaxStack = 99;
					Value = 50;
					break;
				case EntityID.ItemID.ILLEGAL_GUN_PARTS:
					Width = 10;
					Height = 20;
					MaxStack = 99;
					Value = 750000;
					break;
				case EntityID.ItemID.THE_DOCTORS_SHIRT:
					Width = 18;
					Height = 18;
					BodySlot = (short)EntityID.ArmorBodyID.BODY_THE_DOCTORS_SHIRT;
					Value = 200000;
					IsVanity = true;
					break;
				case EntityID.ItemID.THE_DOCTORS_PANTS:
					Width = 18;
					Height = 18;
					LegSlot = (short)EntityID.ArmorLegsID.LEGS_THE_DOCTORS_PANTS;
					Value = 200000;
					IsVanity = true;
					break;
				case EntityID.ItemID.GOLDEN_KEY:
					Width = 14;
					Height = 20;
					MaxStack = 99;
					break;
				case EntityID.ItemID.SHADOW_CHEST:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.CHEST;
					PlaceStyle = 3;
					Width = 26;
					Height = 22;
					Value = 5000;
					break;
				case EntityID.ItemID.SHADOW_KEY:
					Width = 14;
					Height = 20;
					MaxStack = 1;
					Value = 75000;
					break;
				case EntityID.ItemID.OBSIDIAN_BRICK_WALL:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 7;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateWall = (short)EntityID.WallID.OBSIDIAN_BRICK;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.JUNGLE_SPORES:
					Width = 18;
					Height = 16;
					MaxStack = 99;
					Value = 100;
					break;
				case EntityID.ItemID.LOOM:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.LOOM;
					Width = 20;
					Height = 20;
					Value = 300;
					break;
				case EntityID.ItemID.PIANO:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.PIANO;
					Width = 20;
					Height = 20;
					Value = 300;
					break;
				case EntityID.ItemID.DRESSER:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.DRESSER;
					Width = 20;
					Height = 20;
					Value = 300;
					break;
				case EntityID.ItemID.BENCH:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.BENCH;
					Width = 20;
					Height = 20;
					Value = 300;
					break;
				case EntityID.ItemID.BATHTUB:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.BATHTUB;
					Width = 20;
					Height = 20;
					Value = 300;
					break;
				case EntityID.ItemID.RED_BANNER:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.BANNER;
					PlaceStyle = 0;
					Width = 10;
					Height = 24;
					Value = 500;
					break;
				case EntityID.ItemID.GREEN_BANNER:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.BANNER;
					PlaceStyle = 1;
					Width = 10;
					Height = 24;
					Value = 500;
					break;
				case EntityID.ItemID.BLUE_BANNER:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.BANNER;
					PlaceStyle = 2;
					Width = 10;
					Height = 24;
					Value = 500;
					break;
				case EntityID.ItemID.YELLOW_BANNER:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.BANNER;
					PlaceStyle = 3;
					Width = 10;
					Height = 24;
					Value = 500;
					break;
				case EntityID.ItemID.LAMP_POST:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.LAMP_POST;
					Width = 10;
					Height = 24;
					Value = 500;
					break;
				case EntityID.ItemID.TIKI_TORCH:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.TIKI_TORCH;
					Width = 10;
					Height = 24;
					Value = 500;
					break;
				case EntityID.ItemID.BARREL:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.CHEST;
					PlaceStyle = 5;
					Width = 20;
					Height = 20;
					Value = 500;
					break;
				case EntityID.ItemID.CHINESE_LANTERN:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.CHINESE_LANTERN;
					Width = 20;
					Height = 20;
					Value = 500;
					break;
				case EntityID.ItemID.COOKING_POT:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.COOKING_POT;
					Width = 20;
					Height = 20;
					Value = 500;
					break;
				case EntityID.ItemID.SAFE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.SAFE;
					Width = 20;
					Height = 20;
					Value = 500000;
					break;
				case EntityID.ItemID.SKULL_LANTERN:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.SKULL_LANTERN;
					Width = 20;
					Height = 20;
					Value = 500;
					break;
				case EntityID.ItemID.TRASH_CAN:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.CHEST;
					PlaceStyle = 6;
					Width = 20;
					Height = 20;
					Value = 1000;
					break;
				case EntityID.ItemID.CANDELABRA:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.CANDELABRA;
					Width = 20;
					Height = 20;
					Value = 1500;
					break;
				case EntityID.ItemID.PINK_VASE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.BOTTLE;
					PlaceStyle = 3;
					Width = 16;
					Height = 24;
					Value = 70;
					break;
				case EntityID.ItemID.MUG:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.BOTTLE;
					PlaceStyle = 4;
					Width = 16;
					Height = 24;
					Value = 20;
					break;
				case EntityID.ItemID.KEG:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.KEG;
					Width = 24;
					Height = 24;
					Value = 600;
					break;
				case EntityID.ItemID.ALE:
					UseSound = 3;
					UseStyle = 2;
					CanUseTurn = true;
					UseAnimation = 17;
					UseTime = 17;
					MaxStack = 30;
					IsConsumable = true;
					Width = 10;
					Height = 10;
					BuffType = (int)EntityID.BuffID.DRUNK;
					BuffTime = 7200;
					Value = 100;
					break;
				case EntityID.ItemID.BOOKCASE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.BOOKCASE;
					Width = 20;
					Height = 20;
					Value = 300;
					break;
				case EntityID.ItemID.THRONE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.THRONE;
					Width = 20;
					Height = 20;
					Value = 300;
					break;
				case EntityID.ItemID.BOWL:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.BOWL;
					Width = 16;
					Height = 24;
					Value = 20;
					break;
				case EntityID.ItemID.BOWL_OF_SOUP:
					UseSound = 3;
					UseStyle = 2;
					CanUseTurn = true;
					UseAnimation = 17;
					UseTime = 17;
					MaxStack = 30;
					IsConsumable = true;
					Width = 10;
					Height = 10;
					BuffType = (int)EntityID.BuffID.WELL_FED;
					BuffTime = 36000;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 1000;
					break;
				case EntityID.ItemID.TOILET:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.CHAIR;
					PlaceStyle = 1;
					Width = 12;
					Height = 30;
					Value = 150;
					break;
				case EntityID.ItemID.GRANDFATHER_CLOCK:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.GRANDFATHERS_CLOCK;
					Width = 20;
					Height = 20;
					Value = 300;
					break;
				case EntityID.ItemID.STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					break;
				case EntityID.ItemID.GOBLIN_BATTLE_STANDARD:
					UseStyle = 4;
					IsConsumable = true;
					UseAnimation = 45;
					UseTime = 45;
					Width = 28;
					Height = 28;
					break;
				case EntityID.ItemID.TATTERED_CLOTH:
					MaxStack = 99;
					Width = 24;
					Height = 24;
					Value = 30;
					break;
				case EntityID.ItemID.SAWMILL:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.SAWMILL;
					Width = 20;
					Height = 20;
					Value = 300;
					break;
				case EntityID.ItemID.COBALT_ORE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.COBALT_ORE;
					Width = 12;
					Height = 12;
					Value = 3500;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					break;
				case EntityID.ItemID.MYTHRIL_ORE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.MYTHRIL_ORE;
					Width = 12;
					Height = 12;
					Value = 5500;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					break;
				case EntityID.ItemID.ADAMANTITE_ORE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.ADAMANTITE_ORE;
					Width = 12;
					Height = 12;
					Value = 7500;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					break;
				case EntityID.ItemID.PWNHAMMER:
					CanUseTurn = true;
					AutoReuse = true;
					UseStyle = 1;
					UseAnimation = 27;
					UseTime = 14;
					HammerPower = 80;
					Width = 24;
					Height = 28;
					Damage = 26;
					Knockback = 7.5f;
					Scale = 1.2f;
					UseSound = 1;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 39000;
					IsMelee = true;
					break;
				case EntityID.ItemID.EXCALIBUR:
					AutoReuse = true;
					UseStyle = 1;
					UseAnimation = 25;
					UseTime = 25;
					Knockback = 4.5f;
					Width = 40;
					Height = 40;
					Damage = 47;
					Scale = 1.15f;
					UseSound = 1;
					Rarity = (sbyte)EntityID.RarityID.PINK;
					Value = 230000;
					IsMelee = true;
					break;
				case EntityID.ItemID.TIZONA:
					AutoReuse = true;
					UseStyle = 1;
					UseAnimation = 25;
					UseTime = 25;
					Knockback = 4.6f;
					Width = 40;
					Height = 40;
					Damage = 55;
					Scale = 1.15f;
					UseSound = 1;
					Rarity = (sbyte)EntityID.RarityID.PINK;
					Value = 300000;
					IsMelee = true;
					break;
				case EntityID.ItemID.HALLOWED_SEEDS:
					CanUseTurn = true;
					UseStyle = 1;
					UseAnimation = 15;
					UseTime = 10;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.HALLOWED_GRASS;
					Width = 14;
					Height = 14;
					Value = 2000;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					break;
				case EntityID.ItemID.EBONSAND_BLOCK:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.EBONSAND;
					Width = 12;
					Height = 12;
					Ammo = 42;
					break;
				case EntityID.ItemID.COBALT_HAT:
					Width = 18;
					Height = 18;
					Defense = 2;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_COBALT_HAT;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 75000;
					break;
				case EntityID.ItemID.COBALT_HELMET:
					Width = 18;
					Height = 18;
					Defense = 11;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_COBALT_HELMET;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 75000;
					break;
				case EntityID.ItemID.COBALT_MASK:
					Width = 18;
					Height = 18;
					Defense = 4;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_COBALT_MASK;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 75000;
					break;
				case EntityID.ItemID.COBALT_BREASTPLATE:
					Width = 18;
					Height = 18;
					Defense = 8;
					BodySlot = (short)EntityID.ArmorBodyID.BODY_COBALT_BREASTPLATE;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 60000;
					break;
				case EntityID.ItemID.COBALT_LEGGINGS:
					Width = 18;
					Height = 18;
					Defense = 7;
					LegSlot = (short)EntityID.ArmorLegsID.LEGS_COBALT_LEGGINGS;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 45000;
					break;
				case EntityID.ItemID.MYTHRIL_HOOD:
					Width = 18;
					Height = 18;
					Defense = 3;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_MYTHRIL_HOOD;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 112500;
					break;
				case EntityID.ItemID.MYTHRIL_HELMET:
					Width = 18;
					Height = 18;
					Defense = 16;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_MYTHRIL_HELMET;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 112500;
					break;
				case EntityID.ItemID.MYTHRIL_HAT:
					Width = 18;
					Height = 18;
					Defense = 6;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_MYTHRIL_HAT;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 112500;
					break;
				case EntityID.ItemID.MYTHRIL_CHAINMAIL:
					Width = 18;
					Height = 18;
					Defense = 12;
					BodySlot = (short)EntityID.ArmorBodyID.BODY_MYTHRIL_CHAINMAIL;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 90000;
					break;
				case EntityID.ItemID.MYTHRIL_GREAVES:
					Width = 18;
					Height = 18;
					Defense = 9;
					LegSlot = (short)EntityID.ArmorLegsID.LEGS_MYTHRIL_GREAVES;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 67500;
					break;
				case EntityID.ItemID.COBALT_BAR:
					Width = 20;
					Height = 20;
					MaxStack = 99;
					Value = 10500;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					break;
				case EntityID.ItemID.MYTHRIL_BAR:
					Width = 20;
					Height = 20;
					MaxStack = 99;
					Value = 22000;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					break;
				case EntityID.ItemID.COBALT_CHAINSAW:
					UseStyle = 5;
					UseAnimation = 25;
					UseTime = 8;
					ShootSpeed = 40f;
					Knockback = 2.75f;
					Width = 20;
					Height = 12;
					Damage = 23;
					AxePower = 14;
					UseSound = 23;
					Shoot = (byte)EntityID.ProjectileID.COBALT_CHAINSAW;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 54000;
					NoMelee = true;
					NoUseGraphic = true;
					IsMelee = true;
					Channelling = true;
					break;
				case EntityID.ItemID.MYTHRIL_CHAINSAW:
					UseStyle = 5;
					UseAnimation = 25;
					UseTime = 8;
					ShootSpeed = 40f;
					Knockback = 3f;
					Width = 20;
					Height = 12;
					Damage = 29;
					AxePower = 17;
					UseSound = 23;
					Shoot = (byte)EntityID.ProjectileID.MYTHRIL_CHAINSAW;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 81000;
					NoMelee = true;
					NoUseGraphic = true;
					IsMelee = true;
					Channelling = true;
					break;
				case EntityID.ItemID.COBALT_DRILL:
					UseStyle = 5;
					UseAnimation = 25;
					UseTime = 13;
					ShootSpeed = 32f;
					Knockback = 0f;
					Width = 20;
					Height = 12;
					Damage = 10;
					PickPower = 110;
					UseSound = 23;
					Shoot = (byte)EntityID.ProjectileID.COBALT_DRILL;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 54000;
					NoMelee = true;
					NoUseGraphic = true;
					IsMelee = true;
					Channelling = true;
					break;
				case EntityID.ItemID.MYTHRIL_DRILL:
					UseStyle = 5;
					UseAnimation = 25;
					UseTime = 10;
					ShootSpeed = 32f;
					Knockback = 0f;
					Width = 20;
					Height = 12;
					Damage = 15;
					PickPower = 150;
					UseSound = 23;
					Shoot = (byte)EntityID.ProjectileID.MYTHRIL_DRILL;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 81000;
					NoMelee = true;
					NoUseGraphic = true;
					IsMelee = true;
					Channelling = true;
					break;
				case EntityID.ItemID.ADAMANTITE_CHAINSAW:
					UseStyle = 5;
					UseAnimation = 25;
					UseTime = 6;
					ShootSpeed = 40f;
					Knockback = 4.5f;
					Width = 20;
					Height = 12;
					Damage = 33;
					AxePower = 20;
					UseSound = 23;
					Shoot = (byte)EntityID.ProjectileID.ADAMANTITE_CHAINSAW;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 108000;
					NoMelee = true;
					NoUseGraphic = true;
					IsMelee = true;
					Channelling = true;
					break;
				case EntityID.ItemID.ADAMANTITE_DRILL:
					UseStyle = 5;
					UseAnimation = 25;
					UseTime = 7;
					ShootSpeed = 32f;
					Knockback = 0f;
					Width = 20;
					Height = 12;
					Damage = 20;
					PickPower = 180;
					UseSound = 23;
					Shoot = (byte)EntityID.ProjectileID.ADAMANTITE_DRILL;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 108000;
					NoMelee = true;
					NoUseGraphic = true;
					IsMelee = true;
					Channelling = true;
					break;
				case EntityID.ItemID.DAO_OF_POW:
					NoMelee = true;
					UseStyle = 5;
					UseAnimation = 45;
					UseTime = 45;
					Knockback = 7f;
					Width = 30;
					Height = 10;
					Damage = 49;
					Scale = 1.1f;
					NoUseGraphic = true;
					Shoot = (byte)EntityID.ProjectileID.THE_DAO_OF_POW;
					ShootSpeed = 15f;
					UseSound = 1;
					Rarity = (sbyte)EntityID.RarityID.PINK;
					Value = 144000;
					IsMelee = true;
					Channelling = true;
					break;
				case EntityID.ItemID.MYTHRIL_HALBERD:
					UseStyle = 5;
					UseAnimation = 26;
					UseTime = 26;
					ShootSpeed = 4.5f;
					Knockback = 5f;
					Width = 40;
					Height = 40;
					Damage = 35;
					Scale = 1.1f;
					UseSound = 1;
					Shoot = (byte)EntityID.ProjectileID.MYTHRIL_HALBERD;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 67500;
					NoMelee = true;
					NoUseGraphic = true;
					IsMelee = true;
					break;
				case EntityID.ItemID.ADAMANTITE_BAR:
					Width = 20;
					Height = 20;
					MaxStack = 99;
					Value = 37500;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					break;
				case EntityID.ItemID.GLASS_WALL:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 7;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateWall = (short)EntityID.WallID.GLASS;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.COMPASS:
					Width = 24;
					Height = 28;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					Value = 100000;
					IsAccessory = true;
					break;
				case EntityID.ItemID.DIVING_GEAR:
					Width = 24;
					Height = 28;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 100000;
					IsAccessory = true;
					break;
				case EntityID.ItemID.GPS:
					Width = 24;
					Height = 28;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 150000;
					IsAccessory = true;
					break;
				case EntityID.ItemID.OBSIDIAN_HORSESHOE:
					Width = 24;
					Height = 28;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 100000;
					IsAccessory = true;
					break;
				case EntityID.ItemID.OBSIDIAN_SHIELD:
					Width = 24;
					Height = 28;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 100000;
					IsAccessory = true;
					Defense = 2;
					break;
				case EntityID.ItemID.TINKERERS_WORKSHOP:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.TINKERERS_WORKSHOP;
					Width = 26;
					Height = 20;
					Value = 100000;
					break;
				case EntityID.ItemID.CLOUD_IN_A_BALLOON:
					Width = 14;
					Height = 28;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 150000;
					IsAccessory = true;
					break;
				case EntityID.ItemID.ADAMANTITE_HEADGEAR:
					Width = 18;
					Height = 18;
					Defense = 4;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_ADAMANTITE_HEADGEAR;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 150000;
					break;
				case EntityID.ItemID.ADAMANTITE_HELMET:
					Width = 18;
					Height = 18;
					Defense = 22;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_ADAMANTITE_HELMET;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 150000;
					break;
				case EntityID.ItemID.ADAMANTITE_MASK:
					Width = 18;
					Height = 18;
					Defense = 8;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_ADAMANTITE_MASK;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 150000;
					break;
				case EntityID.ItemID.ADAMANTITE_BREASTPLATE:
					Width = 18;
					Height = 18;
					Defense = 14;
					BodySlot = (short)EntityID.ArmorBodyID.BODY_ADAMANTITE_BREASTPLATE;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 120000;
					break;
				case EntityID.ItemID.ADAMANTITE_LEGGINGS:
					Width = 18;
					Height = 18;
					Defense = 10;
					LegSlot = (short)EntityID.ArmorLegsID.LEGS_ADAMANTITE_LEGGINGS;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 90000;
					break;
				case EntityID.ItemID.SPECTRE_BOOTS:
					Width = 28;
					Height = 24;
					IsAccessory = true;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 100000;
					break;
				case EntityID.ItemID.ADAMANTITE_GLAIVE:
					UseStyle = 5;
					UseAnimation = 25;
					UseTime = 25;
					ShootSpeed = 5f;
					Knockback = 6f;
					Width = 40;
					Height = 40;
					Damage = 38;
					Scale = 1.1f;
					UseSound = 1;
					Shoot = (byte)EntityID.ProjectileID.ADAMANTITE_GLAIVE;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 90000;
					NoMelee = true;
					NoUseGraphic = true;
					IsMelee = true;
					break;
				case EntityID.ItemID.TOOLBELT:
					Width = 28;
					Height = 24;
					IsAccessory = true;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					Value = 100000;
					break;
				case EntityID.ItemID.PEARLSAND_BLOCK:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.PEARLSAND;
					Width = 12;
					Height = 12;
					Ammo = 42;
					break;
				case EntityID.ItemID.PEARLSTONE_BLOCK:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.PEARLSTONE;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.MINING_SHIRT:
					Width = 18;
					Height = 18;
					Defense = 1;
					BodySlot = (short)EntityID.ArmorBodyID.BODY_MINING_SHIRT;
					Value = 5000;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					break;
				case EntityID.ItemID.MINING_PANTS:
					Width = 18;
					Height = 18;
					Defense = 1;
					LegSlot = (short)EntityID.ArmorLegsID.LEGS_MINING_PANTS;
					Value = 5000;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					break;
				case EntityID.ItemID.PEARLSTONE_BRICK:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.PEARLSTONE_BRICK;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.IRIDESCENT_BRICK:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.IRIDESCENT_BRICK;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.MUDSTONE_BRICK:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.MUDSTONE;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.COBALT_BRICK:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.COBALT_BRICK;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.MYTHRIL_BRICK:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.MYTHRIL_BRICK;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.PEARLSTONE_BRICK_WALL:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 7;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateWall = (short)EntityID.WallID.PEARLSTONE_BRICK;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.IRIDESCENT_BRICK_WALL:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 7;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateWall = (short)EntityID.WallID.IRIDESCENT_BRICK;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.MUDSTONE_BRICK_WALL:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 7;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateWall = (short)EntityID.WallID.MUDSTONE_BRICK;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.COBALT_BRICK_WALL:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 7;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateWall = (short)EntityID.WallID.COBALT_BRICK;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.MYTHRIL_BRICK_WALL:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 7;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateWall = (short)EntityID.WallID.MYTHRIL_BRICK;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.HOLY_WATER:
					UseStyle = 1;
					ShootSpeed = 9f;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					Damage = 20;
					Shoot = (byte)EntityID.ProjectileID.HOLY_WATER;
					Width = 18;
					Height = 20;
					MaxStack = 250;
					IsConsumable = true;
					Knockback = 3f;
					UseSound = 1;
					UseAnimation = 15;
					UseTime = 15;
					NoUseGraphic = true;
					NoMelee = true;
					Value = 200;
					break;
				case EntityID.ItemID.UNHOLY_WATER:
					UseStyle = 1;
					ShootSpeed = 9f;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					Damage = 20;
					Shoot = (byte)EntityID.ProjectileID.UNHOLY_WATER;
					Width = 18;
					Height = 20;
					MaxStack = 250;
					IsConsumable = true;
					Knockback = 3f;
					UseSound = 1;
					UseAnimation = 15;
					UseTime = 15;
					NoUseGraphic = true;
					NoMelee = true;
					Value = 200;
					break;
				case EntityID.ItemID.SILT_BLOCK:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.SILT;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.FAIRY_BELL:
					Mana = 40;
					Channelling = true;
					Damage = 0;
					UseStyle = 1;
					Shoot = (byte)EntityID.ProjectileID.BLUE_FAIRY;
					Width = 24;
					Height = 24;
					UseSound = 25;
					UseAnimation = 20;
					UseTime = 20;
					Rarity = (sbyte)EntityID.RarityID.PINK;
					NoMelee = true;
					Value = (Value = 250000);
					BuffType = (int)EntityID.BuffID.FAIRY;
					BuffTime = 18000;
					break;
				case EntityID.ItemID.BREAKER_BLADE:
					UseStyle = 1;
					UseAnimation = 30;
					Knockback = 8f;
					Width = 60;
					Height = 70;
					Damage = 39;
					Scale = 1.05f;
					UseSound = 1;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 150000;
					IsMelee = true;
					break;
				case EntityID.ItemID.BLUE_TORCH:
					CantTouchLiquid = true;
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					HoldStyle = 1;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.TORCH;
					PlaceStyle = 1;
					Width = 10;
					Height = 12;
					Value = 200;
					break;
				case EntityID.ItemID.RED_TORCH:
					CantTouchLiquid = true;
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					HoldStyle = 1;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.TORCH;
					PlaceStyle = 2;
					Width = 10;
					Height = 12;
					Value = 200;
					break;
				case EntityID.ItemID.GREEN_TORCH:
					CantTouchLiquid = true;
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					HoldStyle = 1;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.TORCH;
					PlaceStyle = 3;
					Width = 10;
					Height = 12;
					Value = 200;
					break;
				case EntityID.ItemID.PURPLE_TORCH:
					CantTouchLiquid = true;
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					HoldStyle = 1;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.TORCH;
					PlaceStyle = 4;
					Width = 10;
					Height = 12;
					Value = 200;
					break;
				case EntityID.ItemID.WHITE_TORCH:
					CantTouchLiquid = true;
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					HoldStyle = 1;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.TORCH;
					PlaceStyle = 5;
					Width = 10;
					Height = 12;
					Value = 500;
					break;
				case EntityID.ItemID.YELLOW_TORCH:
					CantTouchLiquid = true;
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					HoldStyle = 1;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.TORCH;
					PlaceStyle = 6;
					Width = 10;
					Height = 12;
					Value = 200;
					break;
				case EntityID.ItemID.DEMON_TORCH:
					CantTouchLiquid = true;
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					HoldStyle = 1;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.TORCH;
					PlaceStyle = 7;
					Width = 10;
					Height = 12;
					Value = 300;
					break;
				case EntityID.ItemID.CLOCKWORK_ASSAULT_RIFLE:
					AutoReuse = true;
					UseStyle = 5;
					UseAnimation = 12;
					UseTime = 4;
					ReuseDelay = 14;
					Width = 50;
					Height = 18;
					Shoot = (byte)EntityID.ProjectileID.PURIFICATION_POWDER;
					UseAmmo = 14;
					UseSound = 31;
					Damage = 19;
					ShootSpeed = 7.75f;
					NoMelee = true;
					Value = 150000;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					IsRanged = true;
					break;
				case EntityID.ItemID.COBALT_REPEATER:
					UseStyle = 5;
					AutoReuse = true;
					UseAnimation = 25;
					UseTime = 25;
					Width = 50;
					Height = 18;
					Shoot = (byte)EntityID.ProjectileID.WOODEN_ARROW_FRIENDLY;
					UseAmmo = 1;
					UseSound = 5;
					Damage = 30;
					ShootSpeed = 9f;
					NoMelee = true;
					Value = 60000;
					IsRanged = true;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Knockback = 1.5f;
					break;
				case EntityID.ItemID.MYTHRIL_REPEATER:
					UseStyle = 5;
					AutoReuse = true;
					UseAnimation = 23;
					UseTime = 23;
					Width = 50;
					Height = 18;
					Shoot = (byte)EntityID.ProjectileID.WOODEN_ARROW_FRIENDLY;
					UseAmmo = 1;
					UseSound = 5;
					Damage = 34;
					ShootSpeed = 9.5f;
					NoMelee = true;
					Value = 90000;
					IsRanged = true;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Knockback = 2f;
					break;
				case EntityID.ItemID.DUAL_HOOK:
					NoUseGraphic = true;
					Damage = 0;
					Knockback = 7f;
					UseStyle = 5;
					ShootSpeed = 14f;
					Shoot = (byte)EntityID.ProjectileID.DUAL_HOOK_BLUE;
					Width = 18;
					Height = 28;
					UseSound = 1;
					UseAnimation = 20;
					UseTime = 20;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					NoMelee = true;
					Value = 200000;
					break;
				case EntityID.ItemID.STAR_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 2;
					break;
				case EntityID.ItemID.SWORD_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 3;
					break;
				case EntityID.ItemID.SLIME_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 4;
					break;
				case EntityID.ItemID.GOBLIN_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 5;
					break;
				case EntityID.ItemID.SHIELD_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 6;
					break;
				case EntityID.ItemID.BAT_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 7;
					break;
				case EntityID.ItemID.FISH_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 8;
					break;
				case EntityID.ItemID.BUNNY_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 9;
					break;
				case EntityID.ItemID.SKELETON_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 10;
					break;
				case EntityID.ItemID.REAPER_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 11;
					break;
				case EntityID.ItemID.WOMAN_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 12;
					break;
				case EntityID.ItemID.IMP_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 13;
					break;
				case EntityID.ItemID.GARGOYLE_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 14;
					break;
				case EntityID.ItemID.GLOOM_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 15;
					break;
				case EntityID.ItemID.HORNET_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 16;
					break;
				case EntityID.ItemID.BOMB_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 17;
					break;
				case EntityID.ItemID.CRAB_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 18;
					break;
				case EntityID.ItemID.HAMMER_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 19;
					break;
				case EntityID.ItemID.POTION_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 20;
					break;
				case EntityID.ItemID.SPEAR_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 21;
					break;
				case EntityID.ItemID.CROSS_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 22;
					break;
				case EntityID.ItemID.JELLYFISH_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 23;
					break;
				case EntityID.ItemID.BOW_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 24;
					break;
				case EntityID.ItemID.BOOMERANG_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 25;
					break;
				case EntityID.ItemID.BOOT_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 26;
					break;
				case EntityID.ItemID.CHEST_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 27;
					break;
				case EntityID.ItemID.BIRD_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 28;
					break;
				case EntityID.ItemID.AXE_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 29;
					break;
				case EntityID.ItemID.CORRUPT_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 30;
					break;
				case EntityID.ItemID.TREE_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 31;
					break;
				case EntityID.ItemID.ANVIL_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 32;
					break;
				case EntityID.ItemID.PICKAXE_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 33;
					break;
				case EntityID.ItemID.MUSHROOM_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 34;
					break;
				case EntityID.ItemID.EYEBALL_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 35;
					break;
				case EntityID.ItemID.PILLAR_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 36;
					break;
				case EntityID.ItemID.HEART_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 37;
					break;
				case EntityID.ItemID.POT_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 38;
					break;
				case EntityID.ItemID.SUNFLOWER_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 39;
					break;
				case EntityID.ItemID.KING_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 40;
					break;
				case EntityID.ItemID.QUEEN_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 41;
					break;
				case EntityID.ItemID.PIRANHA_STATUE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.STATUE;
					Width = 20;
					Height = 20;
					Value = 300;
					PlaceStyle = 42;
					break;
				case EntityID.ItemID.PLANKED_WALL:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 7;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateWall = (short)EntityID.WallID.PLANKED;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.WOODEN_BEAM:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.WOODEN_BEAM;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.ADAMANTITE_REPEATER:
					UseStyle = 5;
					AutoReuse = true;
					UseAnimation = 20;
					UseTime = 20;
					Width = 50;
					Height = 18;
					Shoot = (byte)EntityID.ProjectileID.WOODEN_ARROW_FRIENDLY;
					UseAmmo = 1;
					UseSound = 5;
					Damage = 37;
					ShootSpeed = 10f;
					NoMelee = true;
					Value = 120000;
					IsRanged = true;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Knockback = 2.5f;
					break;
				case EntityID.ItemID.ADAMANTITE_SWORD:
					UseStyle = 1;
					UseAnimation = 27;
					UseTime = 27;
					Knockback = 6f;
					Width = 40;
					Height = 40;
					Damage = 44;
					Scale = 1.2f;
					UseSound = 1;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 138000;
					IsMelee = true;
					break;
				case EntityID.ItemID.COBALT_SWORD:
					CanUseTurn = true;
					AutoReuse = true;
					UseStyle = 1;
					UseAnimation = 23;
					UseTime = 23;
					Knockback = 3.85f;
					Width = 40;
					Height = 40;
					Damage = 34;
					Scale = 1.1f;
					UseSound = 1;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 69000;
					IsMelee = true;
					break;
				case EntityID.ItemID.MYTHRIL_SWORD:
					UseStyle = 1;
					UseAnimation = 26;
					UseTime = 26;
					Knockback = 6f;
					Width = 40;
					Height = 40;
					Damage = 39;
					Scale = 1.15f;
					UseSound = 1;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 103500;
					IsMelee = true;
					break;
				case EntityID.ItemID.MOON_CHARM:
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Width = 24;
					Height = 28;
					IsAccessory = true;
					Value = 150000;
					break;
				case EntityID.ItemID.RULER:
					Width = 10;
					Height = 26;
					IsAccessory = true;
					Value = 10000;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					break;
				case EntityID.ItemID.CRYSTAL_BALL:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.CRYSTAL_BALL;
					Width = 22;
					Height = 22;
					Value = 100000;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					break;
				case EntityID.ItemID.DISCO_BALL:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.DISCO_BALL;
					Width = 22;
					Height = 26;
					Value = 10000;
					break;
				case EntityID.ItemID.SORCERER_EMBLEM:
					Width = 24;
					Height = 24;
					IsAccessory = true;
					Value = 100000;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					break;
				case EntityID.ItemID.RANGER_EMBLEM:
					Width = 24;
					Height = 24;
					IsAccessory = true;
					Value = 100000;
					break;
				case EntityID.ItemID.WARRIOR_EMBLEM:
					Width = 24;
					Height = 24;
					IsAccessory = true;
					Value = 100000;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					break;
				case EntityID.ItemID.DEMON_WINGS:
				case EntityID.ItemID.ANGEL_WINGS:
#if !VERSION_INITIAL
				case EntityID.ItemID.SPARKLY_WINGS:
#endif
					Width = 24;
					Height = 8;
					IsAccessory = true;
					Value = 400000;
					Rarity = (sbyte)EntityID.RarityID.PINK;
					break;
				case EntityID.ItemID.MAGICAL_HARP:
					Rarity = (sbyte)EntityID.RarityID.PINK;
					UseStyle = 5;
					UseAnimation = 12;
					UseTime = 12;
					Width = 12;
					Height = 28;
					Shoot = (byte)EntityID.ProjectileID.QUARTER_NOTE;
					HoldStyle = 3;
					AutoReuse = true;
					Damage = 30;
					ShootSpeed = 4.5f;
					NoMelee = true;
					Value = 200000;
					Mana = 4;
					IsMagic = true;
					break;
				case EntityID.ItemID.RAINBOW_ROD:
					Rarity = (sbyte)EntityID.RarityID.PINK;
					Mana = 10;
					Channelling = true;
					Damage = 53;
					UseStyle = 1;
					ShootSpeed = 6f;
					Shoot = (byte)EntityID.ProjectileID.RAINBOW_ROD_BULLET;
					Width = 26;
					Height = 28;
					UseSound = 28;
					UseAnimation = 15;
					UseTime = 15;
					NoMelee = true;
					Knockback = 5f;
					TileBoost = 64;
					Value = 200000;
					IsMagic = true;
					break;
				case EntityID.ItemID.ICE_ROD:
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Mana = 7;
					Damage = 26;
					UseStyle = 1;
					ShootSpeed = 12f;
					Shoot = (byte)EntityID.ProjectileID.ICE_BLOCK;
					Width = 26;
					Height = 28;
					UseSound = 28;
					UseAnimation = 17;
					UseTime = 17;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					AutoReuse = true;
					NoMelee = true;
					Knockback = 0f;
					Value = 1000000;
					IsMagic = true;
					Knockback = 2f;
					break;
				case EntityID.ItemID.NEPTUNES_SHELL:
					Width = 24;
					Height = 28;
					IsAccessory = true;
					Value = 150000;
					Rarity = (sbyte)EntityID.RarityID.PINK;
					break;
				case EntityID.ItemID.MANNEQUIN:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.MANNEQUIN;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.GREATER_HEALING_POTION:
					UseSound = 3;
					HealLife = 150;
					UseStyle = 2;
					CanUseTurn = true;
					UseAnimation = 17;
					UseTime = 17;
					MaxStack = 30;
					IsConsumable = true;
					Width = 14;
					Height = 24;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					IsPotion = true;
					Value = 5000;
					break;
				case EntityID.ItemID.GREATER_MANA_POTION:
					UseSound = 3;
					HealMana = 200;
					UseStyle = 2;
					CanUseTurn = true;
					UseAnimation = 17;
					UseTime = 17;
					MaxStack = 99;
					IsConsumable = true;
					Width = 14;
					Height = 24;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					Value = 500;
					break;
				case EntityID.ItemID.PIXIE_DUST:
					Width = 16;
					Height = 14;
					MaxStack = 99;
					Value = 500;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					break;
				case EntityID.ItemID.CRYSTAL_SHARD:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.CRYSTAL_SHARD;
					Width = 24;
					Height = 24;
					Value = 8000;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					break;
				case EntityID.ItemID.CLOWN_HAT:
					Width = 18;
					Height = 18;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_CLOWN_HAT;
					Value = 20000;
					IsVanity = true;
					Rarity = (sbyte)EntityID.RarityID.GREEN;
					break;
				case EntityID.ItemID.CLOWN_SHIRT:
					Width = 18;
					Height = 18;
					BodySlot = (short)EntityID.ArmorBodyID.BODY_CLOWN_SHIRT;
					Value = 10000;
					IsVanity = true;
					Rarity = (sbyte)EntityID.RarityID.GREEN;
					break;
				case EntityID.ItemID.CLOWN_PANTS:
					Width = 18;
					Height = 18;
					LegSlot = (short)EntityID.ArmorLegsID.LEGS_CLOWN_PANTS;
					Value = 10000;
					IsVanity = true;
					Rarity = (sbyte)EntityID.RarityID.GREEN;
					break;
				case EntityID.ItemID.FLAMETHROWER:
					UseStyle = 5;
					AutoReuse = true;
					UseAnimation = 30;
					UseTime = 6;
					Width = 50;
					Height = 18;
					Shoot = (byte)EntityID.ProjectileID.FLAMES;
					UseAmmo = 23;
					UseSound = 34;
					Damage = 27;
					Knockback = 0.3f;
					ShootSpeed = 7f;
					NoMelee = true;
					Value = 500000;
					Rarity = (sbyte)EntityID.RarityID.PINK;
					IsRanged = true;
					break;
				case EntityID.ItemID.BELL:
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					UseStyle = 1;
					UseAnimation = 12;
					UseTime = 12;
					Width = 12;
					Height = 28;
					AutoReuse = true;
					NoMelee = true;
					Value = 10000;
					break;
				case EntityID.ItemID.HARP:
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					UseStyle = 5;
					UseAnimation = 12;
					UseTime = 12;
					Width = 12;
					Height = 28;
					AutoReuse = true;
					NoMelee = true;
					Value = 10000;
					break;
				case EntityID.ItemID.WRENCH:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					Width = 24;
					Height = 28;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 20000;
					Mech = true;
					break;
				case EntityID.ItemID.WIRE_CUTTER:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					Width = 24;
					Height = 28;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					Value = 20000;
					Mech = true;
					break;
				case EntityID.ItemID.ACTIVE_STONE_BLOCK:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.ACTIVE_STONE;
					Width = 12;
					Height = 12;
					Value = 1000;
					Mech = true;
					break;
				case EntityID.ItemID.INACTIVE_STONE_BLOCK:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.INACTIVE_STONE;
					Width = 12;
					Height = 12;
					Value = 1000;
					Mech = true;
					break;
				case EntityID.ItemID.LEVER:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.LEVER;
					Width = 24;
					Height = 24;
					Value = 3000;
					Mech = true;
					break;
				case EntityID.ItemID.LASER_RIFLE:
					AutoReuse = true;
					UseStyle = 5;
					UseAnimation = 12;
					UseTime = 12;
					Width = 36;
					Height = 22;
					Shoot = (byte)EntityID.ProjectileID.PURPLE_LASER;
					Mana = 8;
					UseSound = 12;
					Knockback = 2.5f;
					Damage = 29;
					ShootSpeed = 17f;
					NoMelee = true;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					IsMagic = true;
					Value = 500000;
					break;
				case EntityID.ItemID.CRYSTAL_BULLET:
					ShootSpeed = 5f;
					Shoot = (byte)EntityID.ProjectileID.CRYSTAL_BULLET;
					Damage = 9;
					Width = 8;
					Height = 8;
					MaxStack = 250;
					IsConsumable = true;
					Ammo = 14;
					Knockback = 1f;
					Value = 30;
					IsRanged = true;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					break;
				case EntityID.ItemID.HOLY_ARROW:
					ShootSpeed = 3.5f;
					Shoot = (byte)EntityID.ProjectileID.HOLY_ARROW;
					Damage = 6;
					Width = 10;
					Height = 28;
					MaxStack = 250;
					IsConsumable = true;
					Ammo = 1;
					Knockback = 2f;
					Value = 80;
					IsRanged = true;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					break;
				case EntityID.ItemID.MAGIC_DAGGER:
					UseStyle = 1;
					ShootSpeed = 10f;
					Shoot = (byte)EntityID.ProjectileID.MAGIC_DAGGER;
					Damage = 28;
					Width = 18;
					Height = 20;
					Mana = 7;
					UseSound = 1;
					UseAnimation = 15;
					UseTime = 15;
					NoUseGraphic = true;
					NoMelee = true;
					Value = 1000000;
					Knockback = 2f;
					IsMagic = true;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					break;
				case EntityID.ItemID.CRYSTAL_STORM:
					AutoReuse = true;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Mana = 5;
					UseSound = 9;
					UseStyle = 5;
					Damage = 26;
					UseAnimation = 7;
					UseTime = 7;
					Width = 24;
					Height = 28;
					Shoot = (byte)EntityID.ProjectileID.CRYSTAL_STORM;
					Scale = 0.9f;
					ShootSpeed = 16f;
					Knockback = 5f;
					IsMagic = true;
					Value = 500000;
					break;
				case EntityID.ItemID.CURSED_FLAMES:
					AutoReuse = true;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Mana = 14;
					UseSound = 20;
					UseStyle = 5;
					Damage = 35;
					UseAnimation = 20;
					UseTime = 20;
					Width = 24;
					Height = 28;
					Shoot = (byte)EntityID.ProjectileID.CURSED_FLAME_FRIENDLY;
					Scale = 0.9f;
					ShootSpeed = 10f;
					Knockback = 6.5f;
					IsMagic = true;
					Value = 500000;
					break;
				case EntityID.ItemID.SOUL_OF_LIGHT:
					Width = 18;
					Height = 18;
					MaxStack = 250;
					Value = 1000;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					break;
				case EntityID.ItemID.SOUL_OF_NIGHT:
					Width = 18;
					Height = 18;
					MaxStack = 250;
					Value = 1000;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					break;
				case EntityID.ItemID.SOUL_OF_BLIGHT:
					Width = 18;
					Height = 18;
					MaxStack = 250;
					Value = 100000;
					Rarity = (sbyte)EntityID.RarityID.PINK;
					break;
				case EntityID.ItemID.CURSED_FLAME:
					Width = 12;
					Height = 14;
					MaxStack = 99;
					Value = 4000;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					break;
				case EntityID.ItemID.CURSED_TORCH:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					HoldStyle = 1;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.TORCH;
					PlaceStyle = 8;
					Width = 10;
					Height = 12;
					Value = 300;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					break;
				case EntityID.ItemID.ADAMANTITE_FORGE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.ADAMANTITE_FORGE;
					Width = 44;
					Height = 30;
					Value = 50000;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					break;
				case EntityID.ItemID.MYTHRIL_ANVIL:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.MYTHRIL_ANVIL;
					Width = 28;
					Height = 14;
					Value = 25000;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					break;
				case EntityID.ItemID.UNICORN_HORN:
					Width = 14;
					Height = 14;
					MaxStack = 99;
					Value = 15000;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					break;
				case EntityID.ItemID.DARK_SHARD:
					Width = 14;
					Height = 14;
					MaxStack = 99;
					Value = 4500;
					Rarity = (sbyte)EntityID.RarityID.GREEN;
					break;
				case EntityID.ItemID.LIGHT_SHARD:
					Width = 14;
					Height = 14;
					MaxStack = 99;
					Value = 4500;
					Rarity = (sbyte)EntityID.RarityID.GREEN;
					break;
				case EntityID.ItemID.RED_PRESSURE_PLATE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.PRESSURE_PLATE;
					Width = 12;
					Height = 12;
					PlaceStyle = 0;
					Mech = true;
					Value = 5000;
					Mech = true;
					break;
				case EntityID.ItemID.WIRE:
					Width = 12;
					Height = 18;
					MaxStack = 250;
					Value = 500;
					Mech = true;
					break;
				case EntityID.ItemID.SPELL_TOME:
					Width = 12;
					Height = 18;
					MaxStack = 99;
					Value = 50000;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					break;
				case EntityID.ItemID.STAR_CLOAK:
					Width = 20;
					Height = 24;
					Value = 100000;
					IsAccessory = true;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					break;
				case EntityID.ItemID.MEGASHARK:
					UseStyle = 5;
					AutoReuse = true;
					UseAnimation = 7;
					UseTime = 7;
					Width = 50;
					Height = 18;
					Shoot = (byte)EntityID.ProjectileID.PURIFICATION_POWDER;
					UseAmmo = 14;
					UseSound = 11;
					Damage = 23;
					ShootSpeed = 10f;
					NoMelee = true;
					Value = 300000;
					Rarity = (sbyte)EntityID.RarityID.PINK;
					Knockback = 1f;
					IsRanged = true;
					break;
				case EntityID.ItemID.SHOTGUN:
					Knockback = 6.5f;
					UseStyle = 5;
					UseAnimation = 45;
					UseTime = 45;
					Width = 50;
					Height = 14;
					Shoot = (byte)EntityID.ProjectileID.PURIFICATION_POWDER;
					UseAmmo = 14;
					UseSound = 36;
					Damage = 18;
					ShootSpeed = 6f;
					NoMelee = true;
					Value = 700000;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					IsRanged = true;
					break;
				case EntityID.ItemID.PHILOSOPHERS_STONE:
					Width = 12;
					Height = 18;
					Value = 100000;
					IsAccessory = true;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					break;
				case EntityID.ItemID.TITAN_GLOVE:
					Width = 12;
					Height = 18;
					Value = 100000;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					IsAccessory = true;
					break;
				case EntityID.ItemID.COBALT_NAGINATA:
					UseStyle = 5;
					UseAnimation = 28;
					UseTime = 28;
					ShootSpeed = 4.3f;
					Knockback = 4f;
					Width = 40;
					Height = 40;
					Damage = 29;
					Scale = 1.1f;
					UseSound = 1;
					Shoot = (byte)EntityID.ProjectileID.COBALT_NAGINATA;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 45000;
					NoMelee = true;
					NoUseGraphic = true;
					IsMelee = true;
					break;
				case EntityID.ItemID.SWITCH:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.SWITCH;
					Width = 12;
					Height = 12;
					Value = 2000;
					Mech = true;
					break;
				case EntityID.ItemID.DART_TRAP:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.TRAP;
					Width = 12;
					Height = 12;
					Value = 10000;
					Mech = true;
					break;
				case EntityID.ItemID.BOULDER:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.BOULDER;
					Width = 12;
					Height = 12;
					Mech = true;
					break;
				case EntityID.ItemID.GREEN_PRESSURE_PLATE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.PRESSURE_PLATE;
					Width = 12;
					Height = 12;
					PlaceStyle = 1;
					Mech = true;
					Value = 5000;
					break;
				case EntityID.ItemID.GRAY_PRESSURE_PLATE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.PRESSURE_PLATE;
					Width = 12;
					Height = 12;
					PlaceStyle = 2;
					Mech = true;
					Value = 5000;
					break;
				case EntityID.ItemID.BROWN_PRESSURE_PLATE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.PRESSURE_PLATE;
					Width = 12;
					Height = 12;
					PlaceStyle = 3;
					Mech = true;
					Value = 5000;
					break;
				case EntityID.ItemID.MECHANICAL_EYE:
					UseStyle = 4;
					Width = 22;
					Height = 14;
					IsConsumable = true;
					UseAnimation = 45;
					UseTime = 45;
					MaxStack = 20;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					break;
				case EntityID.ItemID.CURSED_ARROW:
					ShootSpeed = 4f;
					Shoot = (byte)EntityID.ProjectileID.CURSED_ARROW;
					Damage = 14;
					Width = 10;
					Height = 28;
					MaxStack = 250;
					IsConsumable = true;
					Ammo = 1;
					Knockback = 3f;
					Value = 80;
					IsRanged = true;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					break;
				case EntityID.ItemID.SPECTRAL_ARROW:
					ShootSpeed = 4.2f;
					Shoot = (byte)EntityID.ProjectileID.SPECTRAL_ARROW;
					Damage = 16;
					Width = 10;
					Height = 28;
					MaxStack = 250;
					IsConsumable = true;
					Ammo = 1;
					Knockback = 3.1f;
					Value = 90;
					IsRanged = true;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					break;
				case EntityID.ItemID.CURSED_BULLET:
					ShootSpeed = 5f;
					Shoot = (byte)EntityID.ProjectileID.CURSED_BULLET;
					Damage = 12;
					Width = 8;
					Height = 8;
					MaxStack = 250;
					IsConsumable = true;
					Ammo = 14;
					Knockback = 4f;
					Value = 30;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					IsRanged = true;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					break;
				case EntityID.ItemID.SOUL_OF_FRIGHT:
					Width = 18;
					Height = 18;
					MaxStack = 250;
					Value = 100000;
					Rarity = (sbyte)EntityID.RarityID.PINK;
					break;
				case EntityID.ItemID.SOUL_OF_MIGHT:
					Width = 18;
					Height = 18;
					MaxStack = 250;
					Value = 100000;
					Rarity = (sbyte)EntityID.RarityID.PINK;
					break;
				case EntityID.ItemID.SOUL_OF_SIGHT:
					Width = 18;
					Height = 18;
					MaxStack = 250;
					Value = 100000;
					Rarity = (sbyte)EntityID.RarityID.PINK;
					break;
				case EntityID.ItemID.GUNGNIR:
					UseStyle = 5;
					UseAnimation = 22;
					UseTime = 22;
					ShootSpeed = 5.6f;
					Knockback = 6.4f;
					Width = 40;
					Height = 40;
					Damage = 42;
					Scale = 1.1f;
					UseSound = 1;
					Shoot = (byte)EntityID.ProjectileID.GUNGNIR;
					Rarity = (sbyte)EntityID.RarityID.PINK;
					Value = 1500000;
					NoMelee = true;
					NoUseGraphic = true;
					IsMelee = true;
					break;
				case EntityID.ItemID.TONBOGIRI:
					UseStyle = 5;
					UseAnimation = 20;
					UseTime = 20;
					ShootSpeed = 5.75f;
					Knockback = 6.7f;
					Width = 40;
					Height = 40;
					Damage = 50;
					Scale = 1.1f;
					UseSound = 1;
					Shoot = (byte)EntityID.ProjectileID.TONBOGIRI;
					Rarity = (sbyte)EntityID.RarityID.PINK;
					Value = 2000000;
					NoMelee = true;
					NoUseGraphic = true;
					IsMelee = true;
					break;
				case EntityID.ItemID.HALLOWED_PLATE_MAIL:
					Width = 18;
					Height = 18;
					Defense = 15;
					BodySlot = (short)EntityID.ArmorBodyID.BODY_HALLOWED_PLATE_MAIL;
					Rarity = (sbyte)EntityID.RarityID.PINK;
					Value = 200000;
					break;
				case EntityID.ItemID.HALLOWED_GREAVES:
					Width = 18;
					Height = 18;
					Defense = 11;
					LegSlot = (short)EntityID.ArmorLegsID.LEGS_HALLOWED_GREAVES;
					Rarity = (sbyte)EntityID.RarityID.PINK;
					Value = 150000;
					break;
				case EntityID.ItemID.HALLOWED_HELMET:
					Width = 18;
					Height = 18;
					Defense = 9;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_HALLOWED_HELMET;
					Rarity = (sbyte)EntityID.RarityID.PINK;
					Value = 250000;
					break;
				case EntityID.ItemID.HALLOWED_HEADGEAR:
					Width = 18;
					Height = 18;
					Defense = 5;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_HALLOWED_HEADGEAR;
					Rarity = (sbyte)EntityID.RarityID.PINK;
					Value = 250000;
					break;
				case EntityID.ItemID.HALLOWED_MASK:
					Width = 18;
					Height = 18;
					Defense = 24;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_HALLOWED_MASK;
					Rarity = (sbyte)EntityID.RarityID.PINK;
					Value = 250000;
					break;
				case EntityID.ItemID.CROSS_NECKLACE:
					Width = 20;
					Height = 24;
					Value = 1500;
					IsAccessory = true;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					break;
				case EntityID.ItemID.MANA_FLOWER:
					Width = 20;
					Height = 24;
					Value = 50000;
					IsAccessory = true;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					break;
				case EntityID.ItemID.MECHANICAL_WORM:
					UseStyle = 4;
					Width = 22;
					Height = 14;
					IsConsumable = true;
					UseAnimation = 45;
					UseTime = 45;
					MaxStack = 20;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					break;
				case EntityID.ItemID.MECHANICAL_SKULL:
					UseStyle = 4;
					Width = 22;
					Height = 14;
					IsConsumable = true;
					UseAnimation = 45;
					UseTime = 45;
					MaxStack = 20;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					break;
				case EntityID.ItemID.SLIME_CROWN:
					UseStyle = 4;
					Width = 22;
					Height = 14;
					IsConsumable = true;
					UseAnimation = 45;
					UseTime = 45;
					MaxStack = 20;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					break;
				case EntityID.ItemID.LIGHT_DISC:
					IsMelee = true;
					AutoReuse = true;
					NoMelee = true;
					UseStyle = 1;
					ShootSpeed = 13f;
					Shoot = (byte)EntityID.ProjectileID.LIGHT_DISC;
					Damage = 35;
					Knockback = 8f;
					Width = 24;
					Height = 24;
					UseSound = 1;
					UseAnimation = 15;
					UseTime = 15;
					NoUseGraphic = true;
					Rarity = (sbyte)EntityID.RarityID.PINK;
					MaxStack = 5;
					Value = 500000;
					break;
				case EntityID.ItemID.MUSIC_BOX_OVERWORLD_DAY:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.MUSIC_BOX;
					PlaceStyle = 0;
					Width = 24;
					Height = 24;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 100000;
					IsAccessory = true;
					break;
				case EntityID.ItemID.MUSIC_BOX_EERIE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.MUSIC_BOX;
					PlaceStyle = 1;
					Width = 24;
					Height = 24;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 100000;
					IsAccessory = true;
					break;
				case EntityID.ItemID.MUSIC_BOX_NIGHT:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.MUSIC_BOX;
					PlaceStyle = 2;
					Width = 24;
					Height = 24;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 100000;
					IsAccessory = true;
					break;
				case EntityID.ItemID.MUSIC_BOX_TITLE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.MUSIC_BOX;
					PlaceStyle = 3;
					Width = 24;
					Height = 24;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 100000;
					IsAccessory = true;
					break;
				case EntityID.ItemID.MUSIC_BOX_UNDERGROUND:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.MUSIC_BOX;
					PlaceStyle = 4;
					Width = 24;
					Height = 24;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 100000;
					IsAccessory = true;
					break;
				case EntityID.ItemID.MUSIC_BOX_BOSS1:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.MUSIC_BOX;
					PlaceStyle = 5;
					Width = 24;
					Height = 24;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 100000;
					IsAccessory = true;
					break;
				case EntityID.ItemID.MUSIC_BOX_JUNGLE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.MUSIC_BOX;
					PlaceStyle = 6;
					Width = 24;
					Height = 24;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 100000;
					IsAccessory = true;
					break;
				case EntityID.ItemID.MUSIC_BOX_CORRUPTION:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.MUSIC_BOX;
					PlaceStyle = 7;
					Width = 24;
					Height = 24;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 100000;
					IsAccessory = true;
					break;
				case EntityID.ItemID.MUSIC_BOX_UNDERGROUND_CORRUPTION:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.MUSIC_BOX;
					PlaceStyle = 8;
					Width = 24;
					Height = 24;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 100000;
					IsAccessory = true;
					break;
				case EntityID.ItemID.MUSIC_BOX_THE_HALLOW:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.MUSIC_BOX;
					PlaceStyle = 9;
					Width = 24;
					Height = 24;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 100000;
					IsAccessory = true;
					break;
				case EntityID.ItemID.MUSIC_BOX_BOSS2:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.MUSIC_BOX;
					PlaceStyle = 10;
					Width = 24;
					Height = 24;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 100000;
					IsAccessory = true;
					break;
				case EntityID.ItemID.MUSIC_BOX_UNDERGROUND_HALLOW:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.MUSIC_BOX;
					PlaceStyle = 11;
					Width = 24;
					Height = 24;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 100000;
					IsAccessory = true;
					break;
				case EntityID.ItemID.MUSIC_BOX_BOSS3:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.MUSIC_BOX;
					PlaceStyle = 12;
					Width = 24;
					Height = 24;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					Value = 100000;
					IsAccessory = true;
					break;
				case EntityID.ItemID.MUSIC_BOX_DESERT:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.MUSIC_BOX;
					PlaceStyle = 13;
					Width = 24;
					Height = 24;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 100000;
					IsAccessory = true;
					break;
				case EntityID.ItemID.MUSIC_BOX_SPACE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.MUSIC_BOX;
					PlaceStyle = 14;
					Width = 24;
					Height = 24;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 100000;
					IsAccessory = true;
					break;
				case EntityID.ItemID.MUSIC_BOX_TUTORIAL:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.MUSIC_BOX;
					PlaceStyle = 15;
					Width = 24;
					Height = 24;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 100000;
					IsAccessory = true;
					break;
				case EntityID.ItemID.MUSIC_BOX_BOSS4:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.MUSIC_BOX;
					PlaceStyle = 16;
					Width = 24;
					Height = 24;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 100000;
					IsAccessory = true;
					break;
				case EntityID.ItemID.MUSIC_BOX_OCEAN:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.MUSIC_BOX;
					PlaceStyle = 17;
					Width = 24;
					Height = 24;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 100000;
					IsAccessory = true;
					break;
				case EntityID.ItemID.MUSIC_BOX_SNOW:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.MUSIC_BOX;
					PlaceStyle = 18;
					Width = 24;
					Height = 24;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 100000;
					IsAccessory = true;
					break;
				case EntityID.ItemID.SOUL_OF_FLIGHT:
					Width = 18;
					Height = 18;
					MaxStack = 250;
					Value = 1000;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					break;
				case EntityID.ItemID.MUSIC_BOX:
					Width = 24;
					Height = 24;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					Value = 100000;
					IsAccessory = true;
					break;
				case EntityID.ItemID.DEMONITE_BRICK:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.DEMONITE_BRICK;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.HALLOWED_REPEATER:
					UseStyle = 5;
					AutoReuse = true;
					UseAnimation = 19;
					UseTime = 19;
					Width = 50;
					Height = 18;
					Shoot = (byte)EntityID.ProjectileID.WOODEN_ARROW_FRIENDLY;
					UseAmmo = 1;
					UseSound = 5;
					Damage = 39;
					ShootSpeed = 11f;
					NoMelee = true;
					Value = 200000;
					IsRanged = true;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Knockback = 2.5f;
					break;
				case EntityID.ItemID.VULCAN_REPEATER:
					UseStyle = 5;
					AutoReuse = true;
					UseAnimation = 18;
					UseTime = 18;
					Width = 50;
					Height = 18;
					Shoot = (byte)EntityID.ProjectileID.WOODEN_ARROW_FRIENDLY;
					UseAmmo = 1;
					UseSound = 5;
					Damage = 42;
					ShootSpeed = 12f;
					NoMelee = true;
					Value = 250000;
					IsRanged = true;
					Rarity = (sbyte)EntityID.RarityID.PINK;
					Knockback = 2.65f;
					break;
				case EntityID.ItemID.HAMDRAX:
					UseStyle = 5;
					UseAnimation = 25;
					UseTime = 7;
					ShootSpeed = 36f;
					Knockback = 4.75f;
					Width = 20;
					Height = 12;
					Damage = 35;
					PickPower = 200;
					AxePower = 22;
					HammerPower = 85;
					UseSound = 23;
					Shoot = (byte)EntityID.ProjectileID.HAMDRAX;
					Rarity = (sbyte)EntityID.RarityID.LIGHT_RED;
					Value = 220000;
					NoMelee = true;
					NoUseGraphic = true;
					IsMelee = true;
					Channelling = true;
					break;
				case EntityID.ItemID.EXPLOSIVES:
					Mech = true;
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.EXPLOSIVES;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.INLET_PUMP:
					Mech = true;
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.PUMP_IN;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.OUTLET_PUMP:
					Mech = true;
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.PUMP_OUT;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.ONE_SECOND_TIMER:
					Mech = true;
					CantTouchLiquid = true;
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.TIMER;
					PlaceStyle = 0;
					Width = 10;
					Height = 12;
					Value = 50;
					break;
				case EntityID.ItemID.THREE_SECOND_TIMER:
					Mech = true;
					CantTouchLiquid = true;
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.TIMER;
					PlaceStyle = 1;
					Width = 10;
					Height = 12;
					Value = 50;
					break;
				case EntityID.ItemID.FIVE_SECOND_TIMER:
					Mech = true;
					CantTouchLiquid = true;
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 99;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.TIMER;
					PlaceStyle = 2;
					Width = 10;
					Height = 12;
					Value = 50;
					break;
				case EntityID.ItemID.CANDY_CANE_BLOCK:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.CANDY_CANE_RED;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.CANDY_CANE_WALL:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateWall = (short)EntityID.WallID.CANDY_CANE;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.SANTA_HAT:
					Width = 18;
					Height = 12;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_SANTA_HAT;
					Value = 150000;
					IsVanity = true;
					break;
				case EntityID.ItemID.SANTA_SHIRT:
					Width = 18;
					Height = 18;
					BodySlot = (short)EntityID.ArmorBodyID.BODY_SANTA_SHIRT;
					Value = 150000;
					IsVanity = true;
					break;
				case EntityID.ItemID.SANTA_PANTS:
					Width = 18;
					Height = 18;
					LegSlot = (short)EntityID.ArmorLegsID.LEGS_SANTA_PANTS;
					Value = 150000;
					IsVanity = true;
					break;
				case EntityID.ItemID.GREEN_CANDY_CANE_BLOCK:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.CANDY_CANE_GREEN;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.GREEN_CANDY_CANE_WALL:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateWall = (short)EntityID.WallID.GREEN_CANDY_CANE;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.SNOW_BLOCK:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.SNOW;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.SNOW_BRICK:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.SNOW_BRICK;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.SNOW_BRICK_WALL:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateWall = (short)EntityID.WallID.SNOW_BRICK;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.BLUE_LIGHT:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.XMAS_LIGHT;
					PlaceStyle = 0;
					Width = 12;
					Height = 12;
					Value = 500;
					break;
				case EntityID.ItemID.RED_LIGHT:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.XMAS_LIGHT;
					PlaceStyle = 1;
					Width = 12;
					Height = 12;
					Value = 500;
					break;
				case EntityID.ItemID.GREEN_LIGHT:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 250;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.XMAS_LIGHT;
					PlaceStyle = 2;
					Width = 12;
					Height = 12;
					Value = 500;
					break;
				case EntityID.ItemID.BLUE_PRESENT:
					Width = 12;
					Height = 12;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					break;
				case EntityID.ItemID.GREEN_PRESENT:
					Width = 12;
					Height = 12;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					break;
				case EntityID.ItemID.YELLOW_PRESENT:
					Width = 12;
					Height = 12;
					Rarity = (sbyte)EntityID.RarityID.BLUE;
					break;
				case EntityID.ItemID.SNOW_GLOBE:
					UseStyle = 4;
					IsConsumable = true;
					UseAnimation = 45;
					UseTime = 45;
					Width = 28;
					Height = 28;
					Rarity = (sbyte)EntityID.RarityID.GREEN;
					break;
				case EntityID.ItemID.PET_SPAWN_1:
					Damage = 0;
					UseStyle = 1;
					Shoot = (byte)EntityID.ProjectileID.PET_BUNNY;
					Width = 16;
					Height = 30;
					UseSound = 2;
					UseAnimation = 20;
					UseTime = 20;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					NoMelee = true;
					Value = 0;
					BuffType = (int)EntityID.BuffID.PET;
					break;
				case EntityID.ItemID.PET_SPAWN_2:
					Damage = 0;
					UseStyle = 1;
					Shoot = (byte)EntityID.ProjectileID.PET_SLIME;
					Width = 16;
					Height = 30;
					UseSound = 2;
					UseAnimation = 20;
					UseTime = 20;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					NoMelee = true;
					Value = 0;
					BuffType = (int)EntityID.BuffID.PET;
					break;
				case EntityID.ItemID.PET_SPAWN_3:
					Damage = 0;
					UseStyle = 1;
					Shoot = (byte)EntityID.ProjectileID.PET_TIPHIA;
					Width = 16;
					Height = 30;
					UseSound = 2;
					UseAnimation = 20;
					UseTime = 20;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					NoMelee = true;
					Value = 0;
					BuffType = (int)EntityID.BuffID.PET;
					break;
				case EntityID.ItemID.PET_SPAWN_4:
					Damage = 0;
					UseStyle = 1;
					Shoot = (byte)EntityID.ProjectileID.PET_BAT;
					Width = 16;
					Height = 30;
					UseSound = 2;
					UseAnimation = 20;
					UseTime = 20;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					NoMelee = true;
					Value = 0;
					BuffType = (int)EntityID.BuffID.PET;
					break;
				case EntityID.ItemID.PET_SPAWN_5:
					Damage = 0;
					UseStyle = 1;
					Shoot = (byte)EntityID.ProjectileID.PET_WEREWOLF;
					Width = 16;
					Height = 30;
					UseSound = 2;
					UseAnimation = 20;
					UseTime = 20;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					NoMelee = true;
					Value = 0;
					BuffType = (int)EntityID.BuffID.PET;
					break;
				case EntityID.ItemID.PET_SPAWN_6:
					Damage = 0;
					UseStyle = 1;
					Shoot = (byte)EntityID.ProjectileID.PET_ZOMBIE;
					Width = 16;
					Height = 30;
					UseSound = 2;
					UseAnimation = 20;
					UseTime = 20;
					Rarity = (sbyte)EntityID.RarityID.ORANGE;
					NoMelee = true;
					Value = 0;
					BuffType = (int)EntityID.BuffID.PET;
					break;
				case EntityID.ItemID.DRAGON_MASK:
					Width = 26;
					Height = 18;
					Defense = 26;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_DRAGON_MASK;
					Rarity = (sbyte)EntityID.RarityID.PINK;
					Value = 500000;
					break;
				case EntityID.ItemID.TITAN_HELMET:
					Width = 26;
					Height = 22;
					Defense = 14;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_TITAN_HELMET;
					Rarity = (sbyte)EntityID.RarityID.PINK;
					Value = 500000;
					break;
				case EntityID.ItemID.SPECTRAL_HEADGEAR:
					Width = 22;
					Height = 20;
					Defense = 10;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_SPECTRAL_HEADGEAR;
					Rarity = (sbyte)EntityID.RarityID.PINK;
					Value = 500000;
					break;
				case EntityID.ItemID.DRAGON_BREASTPLATE:
					Width = 26;
					Height = 18;
					Defense = 20;
					BodySlot = (short)EntityID.ArmorBodyID.BODY_DRAGON_BREASTPLATE;
					Rarity = (sbyte)EntityID.RarityID.PINK;
					Value = 1000000;
					break;
				case EntityID.ItemID.TITAN_MAIL:
					Width = 30;
					Height = 18;
					Defense = 18;
					BodySlot = (short)EntityID.ArmorBodyID.BODY_TITAN_MAIL;
					Rarity = (sbyte)EntityID.RarityID.PINK;
					Value = 1000000;
					break;
				case EntityID.ItemID.SPECTRAL_ARMOR:
					Width = 30;
					Height = 28;
					Defense = 15;
					BodySlot = (short)EntityID.ArmorBodyID.BODY_SPECTRAL_ARMOR;
					Rarity = (sbyte)EntityID.RarityID.PINK;
					Value = 1000000;
					break;
				case EntityID.ItemID.DRAGON_GREAVES:
					Width = 22;
					Height = 18;
					Defense = 14;
					LegSlot = (short)EntityID.ArmorLegsID.LEGS_DRAGON_GREAVES;
					Rarity = (sbyte)EntityID.RarityID.PINK;
					Value = 750000;
					break;
				case EntityID.ItemID.TITAN_LEGGINGS:
					Width = 22;
					Height = 18;
					Defense = 13;
					LegSlot = (short)EntityID.ArmorLegsID.LEGS_TITAN_LEGGINGS;
					Rarity = (sbyte)EntityID.RarityID.PINK;
					Value = 750000;
					break;
				case EntityID.ItemID.SPECTRAL_SUBLIGAR:
					Width = 22;
					Height = 18;
					Defense = 15;
					LegSlot = (short)EntityID.ArmorLegsID.LEGS_SPECTRAL_SUBLIGAR;
					Rarity = (sbyte)EntityID.RarityID.PINK;
					Value = 750000;
					break;
#if VERSION_101
				case EntityID.ItemID.FABULOUS_RIBBON:
					Width = 18;
					Height = 12;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_FABULOUS_RIBBON;
					Value = 10000;
					IsVanity = true;
					break;
				case EntityID.ItemID.GEORGES_HAT:
					Width = 18;
					Height = 12;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_GEORGES_HAT;
					Value = 10000;
					IsVanity = true;
					break;
				case EntityID.ItemID.FABULOUS_TUTU:
					Width = 18;
					Height = 18;
					BodySlot = (short)EntityID.ArmorBodyID.BODY_FABULOUS_TUTU;
					Value = 250000;
					IsVanity = true;
					break;
				case EntityID.ItemID.GEORGES_TUXEDO_SHIRT:
					Width = 18;
					Height = 18;
					BodySlot = (short)EntityID.ArmorBodyID.BODY_GEORGES_TUXEDO_SHIRT;
					Value = 250000;
					IsVanity = true;
					break;
				case EntityID.ItemID.FABULOUS_SLIPPERS:
					Width = 18;
					Height = 18;
					LegSlot = (short)EntityID.ArmorLegsID.LEGS_FABULOUS_SLIPPERS;
					Value = 250000;
					IsVanity = true;
					break;
				case EntityID.ItemID.GEORGES_TUXEDO_PANTS:
					Width = 18;
					Height = 18;
					LegSlot = (short)EntityID.ArmorLegsID.LEGS_GEORGES_TUXEDO_PANTS;
					Value = 250000;
					IsVanity = true;
					break;
				case EntityID.ItemID.CAMPFIRE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 10;
					AutoReuse = true;
					MaxStack = 999;
					IsConsumable = true;
					CreateTile = (short)EntityID.TileID.CAMPFIRE;
					Width = 12;
					Height = 12;
					break;
				case EntityID.ItemID.WOOD_HELMET:
					Width = 18;
					Height = 18;
					Defense = 1;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_WOOD_HELMET;
					break;
				case EntityID.ItemID.WOOD_BREASTPLATE:
					Width = 18;
					Height = 18;
					Defense = 1;
					BodySlot = (short)EntityID.ArmorBodyID.BODY_WOOD_BREASTPLATE;
					break;
				case EntityID.ItemID.WOOD_GREAVES:
					Width = 18;
					Height = 18;
					Defense = 0;
					LegSlot = (short)EntityID.ArmorLegsID.LEGS_WOOD_GREAVES;
					break;
				case EntityID.ItemID.CACTUS_SWORD:
					UseStyle = 1;
					CanUseTurn = false;
					UseAnimation = 25;
					UseTime = 25;
					Width = 24;
					Height = 28;
					Damage = 9;
					Knockback = 5.0f;
					UseSound = 1;
					Scale = 1.0f;
					Value = 1800;
					IsMelee = true;
					break;
				case EntityID.ItemID.CACTUS_PICKAXE:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 23;
					UseTime = 15;
					AutoReuse = true;
					Width = 24;
					Height = 28;
					Damage = 5;
					PickPower = 35;
					UseSound = 1;
					Knockback = 2.0f;
					Value = 2000;
					IsMelee = true;
					break;
				case EntityID.ItemID.CACTUS_HELMET:
					Width = 18;
					Height = 18;
					Defense = 1;
					HeadSlot = (short)EntityID.ArmorHeadID.HEAD_CACTUS_HELMET;
					break;
				case EntityID.ItemID.CACTUS_BREASTPLATE:
					Width = 18;
					Height = 18;
					Defense = 2;
					BodySlot = (short)EntityID.ArmorBodyID.BODY_CACTUS_BREASTPLATE;
					break;
				case EntityID.ItemID.CACTUS_LEGGINGS:
					Width = 18;
					Height = 18;
					Defense = 1;
					LegSlot = (short)EntityID.ArmorLegsID.LEGS_CACTUS_LEGGINGS;
					break;
				case EntityID.ItemID.PURPLE_STAINED_GLASS_WALL:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 7;
					AutoReuse = true;
					MaxStack = 999;
					IsConsumable = true;
					CreateWall = (short)EntityID.WallID.PURPLE_STAINED_GLASS;
					Width = 12;
					Height = 12;
					Value = 125;
					break;
				case EntityID.ItemID.YELLOW_STAINED_GLASS_WALL:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 7;
					AutoReuse = true;
					MaxStack = 999;
					IsConsumable = true;
					CreateWall = (short)EntityID.WallID.YELLOW_STAINED_GLASS;
					Width = 12;
					Height = 12;
					Value = 125;
					break;
				case EntityID.ItemID.BLUE_STAINED_GLASS_WALL:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 7;
					AutoReuse = true;
					MaxStack = 999;
					IsConsumable = true;
					CreateWall = (short)EntityID.WallID.BLUE_STAINED_GLASS;
					Width = 12;
					Height = 12;
					Value = 125;
					break;
				case EntityID.ItemID.GREEN_STAINED_GLASS_WALL:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 7;
					AutoReuse = true;
					MaxStack = 999;
					IsConsumable = true;
					CreateWall = (short)EntityID.WallID.GREEN_STAINED_GLASS;
					Width = 12;
					Height = 12;
					Value = 125;
					break;
				case EntityID.ItemID.RED_STAINED_GLASS_WALL:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 7;
					AutoReuse = true;
					MaxStack = 999;
					IsConsumable = true;
					CreateWall = (short)EntityID.WallID.RED_STAINED_GLASS;
					Width = 12;
					Height = 12;
					Value = 125;
					break;
				case EntityID.ItemID.MULTICOLORED_STAINED_GLASS_WALL:
					UseStyle = 1;
					CanUseTurn = true;
					UseAnimation = 15;
					UseTime = 7;
					AutoReuse = true;
					MaxStack = 999;
					IsConsumable = true;
					CreateWall = (short)EntityID.WallID.RAINBOW_STAINED_GLASS;
					Width = 12;
					Height = 12;
					Value = 125;
					break;
#endif
				default:
					Active = 0;
					Stack = 0;
					break;
			}
#if VERSION_101
			if (MaxStack == 250) // Quick and easy fix for 1.01
			{
				MaxStack = 999;
			}
#endif
			if (!NoMaterialCheck)
			{
				CheckMaterial();
			}
		}

		public Color GetAlpha(Color ItemColour)
		{
			if (Type == (int)EntityID.ItemID.FALLEN_STAR)
			{
				return new Color(255, 255, 255, ItemColour.A - Alpha);
			}
			if ((Type >= (int)EntityID.ItemID.FLAMARANG && Type <= (int)EntityID.ItemID.MOLTEN_PICKAXE) || (Type >= (int)EntityID.ItemID.BLUE_PHASEBLADE && Type <= (int)EntityID.ItemID.YELLOW_PHASEBLADE) || Type == (int)EntityID.ItemID.MOLTEN_HAMAXE || Type == (int)EntityID.ItemID.FLAMELASH || Type == (int)EntityID.ItemID.PHOENIX_BLASTER || Type == (int)EntityID.ItemID.SUNFURY)
			{
				return new Color(255, 255, 255, 255);
			}
#if VERSION_103 || VERSION_FINAL // BUG: Souls of Blight are not lit up correctly in versions prior to the console 1.2 update.
			if (Type == (int)EntityID.ItemID.SOUL_OF_LIGHT || Type == (int)EntityID.ItemID.SOUL_OF_NIGHT || Type == (int)EntityID.ItemID.CURSED_FLAME || Type == (int)EntityID.ItemID.SOUL_OF_FRIGHT || Type == (int)EntityID.ItemID.SOUL_OF_MIGHT || Type == (int)EntityID.ItemID.SOUL_OF_SIGHT || Type == (int)EntityID.ItemID.SOUL_OF_FLIGHT || Type == (int)EntityID.ItemID.SOUL_OF_BLIGHT)
#else
			if (Type == (int)EntityID.ItemID.SOUL_OF_LIGHT || Type == (int)EntityID.ItemID.SOUL_OF_NIGHT || Type == (int)EntityID.ItemID.CURSED_FLAME || Type == (int)EntityID.ItemID.SOUL_OF_FRIGHT || Type == (int)EntityID.ItemID.SOUL_OF_MIGHT || Type == (int)EntityID.ItemID.SOUL_OF_SIGHT || Type == (int)EntityID.ItemID.SOUL_OF_FLIGHT)
#endif
			{
				return new Color(255, 255, 255, 50);
			}
			if (Type == (int)EntityID.ItemID.HEART || Type == (int)EntityID.ItemID.STAR || Type == (int)EntityID.ItemID.PIXIE_DUST)
			{
				return new Color(200, 200, 200, 200);
			}
			int RemainderA = 256 - Alpha;
			int R = ItemColour.R * RemainderA >> 8;
			int G = ItemColour.G * RemainderA >> 8;
			int B = ItemColour.B * RemainderA >> 8;
			int A = ItemColour.A - Alpha;
			return new Color(R, G, B, A);
		}

		public Color GetAlphaInventory(Color ItemColour)
		{
			int InvA = 256 - Alpha;
			int R = ItemColour.R * InvA >> 8;
			int G = ItemColour.G * InvA >> 8;
			int B = ItemColour.B * InvA >> 8;
			int A = ItemColour.A - Alpha;
			return new Color(R, G, B, A);
		}

		public Color GetColor(Color ItemColour)
		{
			int R = Colour.R - (255 - ItemColour.R);
			int G = Colour.G - (255 - ItemColour.G);
			int B = Colour.B - (255 - ItemColour.B);
			int A = Colour.A - (255 - ItemColour.A);
			return new Color(R, G, B, A);
		}

		public static bool MechSpawn(int ItemX, int ItemY, int ItemType) // For the statues for stars, hearts, and bombs.
		{
			int Counter1 = 0;
			int Counter2 = 0;
			int Counter3 = 0;
			for (int ItemNPCIdx = 0; ItemNPCIdx < NPC.MaxNumNPCs; ItemNPCIdx++)
			{
				if (Main.ItemSet[ItemNPCIdx].Active == 0 || Main.ItemSet[ItemNPCIdx].Type != ItemType)
				{
					continue;
				}
				Counter1++;
				Vector2 WorldCoords = new Vector2(ItemX, ItemY);
				float XCoord = Main.ItemSet[ItemNPCIdx].Position.X - WorldCoords.X;
				float YCoord = Main.ItemSet[ItemNPCIdx].Position.Y - WorldCoords.Y;
				float Marker = XCoord * XCoord + YCoord * YCoord;
				if (Marker < 640000f)
				{
					Counter3++;
					if (Marker < 90000f)
					{
						Counter2++;
					}
				}
			}
			if (Counter2 >= 3 || Counter3 >= 6 || Counter1 >= 10)
			{
				return false;
			}
			return true;
		}

		public unsafe void UpdateItem(int ActiveItemIdx)
		{
			float Acceleration = 0.1f;
			float TerminalVelocity = 7f;
			if (IsWet)
			{
				TerminalVelocity = 5f;
				Acceleration = 0.08f;
			}
			Vector2 ItemVelocity = Velocity;
			ItemVelocity.X *= 0.5f;
			ItemVelocity.Y *= 0.5f;
			if (OwnTime > 0 && --OwnTime == 0)
			{
				OwnIgnore = Player.MaxNumPlayers;
			}
			if (KeepTime > 0)
			{
				KeepTime--;
			}
			else if (IsLocal() || (Main.NetMode != (byte)NetModeSetting.CLIENT && (Owner == 8 || Main.PlayerSet[Owner].Active == 0)))
			{
				FindOwner(ActiveItemIdx);
			}
			if (!BeingGrabbed)
			{
				Velocity.X *= 0.95f;
				if (Velocity.X < 0.1f && Velocity.X > -0.1f)
				{
					Velocity.X = 0f;
				}
#if VERSION_103 || VERSION_FINAL // BUG: Souls of Blight don't float in versions prior to the console 1.2 update.
				if (Type == (int)EntityID.ItemID.SOUL_OF_LIGHT || Type == (int)EntityID.ItemID.SOUL_OF_NIGHT || Type == (int)EntityID.ItemID.SOUL_OF_FRIGHT || Type == (int)EntityID.ItemID.SOUL_OF_MIGHT || Type == (int)EntityID.ItemID.SOUL_OF_SIGHT || Type == (int)EntityID.ItemID.SOUL_OF_FLIGHT || Type == (int)EntityID.ItemID.SOUL_OF_BLIGHT)
#else
				if (Type == (int)EntityID.ItemID.SOUL_OF_LIGHT || Type == (int)EntityID.ItemID.SOUL_OF_NIGHT || Type == (int)EntityID.ItemID.SOUL_OF_FRIGHT || Type == (int)EntityID.ItemID.SOUL_OF_MIGHT || Type == (int)EntityID.ItemID.SOUL_OF_SIGHT || Type == (int)EntityID.ItemID.SOUL_OF_FLIGHT)
#endif
				{
					Velocity.Y *= 0.95f;
					if (Velocity.Y < 0.1f && Velocity.Y > -0.1f)
					{
						Velocity.Y = 0f;
					}
				}
				else
				{
					Velocity.Y += Acceleration;
					if (Velocity.Y > TerminalVelocity)
					{
						Velocity.Y = TerminalVelocity;
					}
				}
				bool HasHitLava = Collision.LavaCollision(ref Position, Width, Height);
				IsInLava |= HasHitLava;
				if (Collision.WetCollision(ref Position, Width, Height))
				{
					if (!IsWet)
					{
						if (WetCount == 0)
						{
							WetCount = 20;
							if (!HasHitLava)
							{
								for (int i = 0; i < 8; i++)
								{
									Dust* CreatedDust = Main.DustSet.NewDust((int)Position.X - 6, (int)Position.Y + (Height >> 1) - 8, Width + 12, 24, 33);
									if (CreatedDust == null)
									{
										break;
									}
									CreatedDust->Velocity.Y -= 4f;
									CreatedDust->Velocity.X *= 2.5f;
									CreatedDust->Scale = 1.3f;
									CreatedDust->Alpha = 100;
									CreatedDust->NoGravity = true;
								}
								Main.PlaySound(19, (int)Position.X, (int)Position.Y);
							}
							else
							{
								for (int j = 0; j < 4; j++)
								{
									Dust* CreatedDust = Main.DustSet.NewDust((int)Position.X - 6, (int)Position.Y + (Height >> 1) - 8, Width + 12, 24, 35);
									if (CreatedDust == null)
									{
										break;
									}
									CreatedDust->Velocity.Y -= 1.5f;
									CreatedDust->Velocity.X *= 2.5f;
									CreatedDust->Scale = 1.3f;
									CreatedDust->Alpha = 100;
									CreatedDust->NoGravity = true;
								}
								Main.PlaySound(19, (int)Position.X, (int)Position.Y);
							}
						}
						IsWet = true;
					}
				}
				else if (IsWet)
				{
					IsWet = false;
				}
				if (WetCount > 0)
				{
					WetCount--;
				}
				if (IsWet)
				{
					Vector2 CurrentVelocity = Velocity;
					Collision.TileCollision(ref Position, ref Velocity, Width, Height);
					if (Velocity.X != CurrentVelocity.X)
					{
						ItemVelocity.X = Velocity.X;
					}
					if (Velocity.Y != CurrentVelocity.Y)
					{
						ItemVelocity.Y = Velocity.Y;
					}
				}
				else
				{
					IsInLava = false;
					Collision.TileCollision(ref Position, ref Velocity, Width, Height);
				}
				if (IsInLava)
				{
					if (Type == (int)EntityID.ItemID.GUIDE_VOODOO_DOLL)
					{
						if (Main.NetMode != (byte)NetModeSetting.CLIENT)
						{
							Active = 0;
							Type = 0;
							Stack = 0;
							for (int NpcSlotIdx = 0; NpcSlotIdx < NPC.MaxNumNPCs; NpcSlotIdx++)
							{
								if (Main.NPCSet[NpcSlotIdx].Type == (int)EntityID.NPCID.GUIDE && Main.NPCSet[NpcSlotIdx].Active != 0)
								{
									NetMessage.SendNpcHurt(NpcSlotIdx, 8192, 10.0, -Main.NPCSet[NpcSlotIdx].Direction);
									Main.NPCSet[NpcSlotIdx].StrikeNPC(8192, 10f, -Main.NPCSet[NpcSlotIdx].Direction);
									NPC.SpawnWOF(ref Position);
									break;
								}
							}
							NetMessage.CreateMessage2(21, UI.MainUI.MyPlayer, ActiveItemIdx);
							NetMessage.SendMessage();
						}
					}
					else if (IsLocal() && Type != (int)EntityID.ItemID.FIREBLOSSOM_SEEDS && Type != (int)EntityID.ItemID.FIREBLOSSOM && Type != (int)EntityID.ItemID.OBSIDIAN && Type != (int)EntityID.ItemID.HELLSTONE && Type != (int)EntityID.ItemID.HELLSTONE_BAR && Rarity == (sbyte)EntityID.RarityID.WHITE)
					{
						Active = 0;
						Type = 0;
						Stack = 0;
						NetMessage.CreateMessage2(21, UI.MainUI.MyPlayer, ActiveItemIdx);
						NetMessage.SendMessage();
					}
				}
				if (Type == (int)EntityID.ItemID.SOUL_OF_LIGHT)
				{
					float LightMultiplier = Main.Rand.Next(90, 111) * 0.01f;
					LightMultiplier *= UI.PulseScale;
					Lighting.AddLight((int)Position.X + (Width >> 1) >> 4, (int)Position.Y + (Height >> 1) >> 4, new Vector3(0.5f * LightMultiplier, 0.1f * LightMultiplier, 0.25f * LightMultiplier));
				}
				else if (Type == (int)EntityID.ItemID.SOUL_OF_NIGHT)
				{
					float LightMultiplier = Main.Rand.Next(90, 111) * 0.01f;
					LightMultiplier *= UI.PulseScale;
					Lighting.AddLight((int)Position.X + (Width >> 1) >> 4, (int)Position.Y + (Height >> 1) >> 4, new Vector3(0.25f * LightMultiplier, 0.1f * LightMultiplier, 0.5f * LightMultiplier));
				}
				else if (Type == (int)EntityID.ItemID.SOUL_OF_FRIGHT)
				{
					float LightMultiplier = Main.Rand.Next(90, 111) * 0.01f;
					LightMultiplier *= UI.PulseScale;
					Lighting.AddLight((int)Position.X + (Width >> 1) >> 4, (int)Position.Y + (Height >> 1) >> 4, new Vector3(0.5f * LightMultiplier, 0.3f * LightMultiplier, 0.05f * LightMultiplier));
				}
				else if (Type == (int)EntityID.ItemID.SOUL_OF_MIGHT)
				{
					float LightMultiplier = Main.Rand.Next(90, 111) * 0.01f;
					LightMultiplier *= UI.PulseScale;
					Lighting.AddLight((int)Position.X + (Width >> 1) >> 4, (int)Position.Y + (Height >> 1) >> 4, new Vector3(0.1f * LightMultiplier, 0.1f * LightMultiplier, 0.6f * LightMultiplier));
				}
				else if (Type == (int)EntityID.ItemID.SOUL_OF_FLIGHT)
				{
					float LightMultiplier = Main.Rand.Next(90, 111) * 0.01f;
					LightMultiplier *= UI.PulseScale;
					Lighting.AddLight((int)Position.X + (Width >> 1) >> 4, (int)Position.Y + (Height >> 1) >> 4, new Vector3(0.1f * LightMultiplier, 0.3f * LightMultiplier, 0.5f * LightMultiplier));
				}
				else if (Type == (int)EntityID.ItemID.SOUL_OF_SIGHT)
				{
					float LightMultiplier = Main.Rand.Next(90, 111) * 0.01f;
					LightMultiplier *= UI.PulseScale;
					Lighting.AddLight((int)Position.X + (Width >> 1) >> 4, (int)Position.Y + (Height >> 1) >> 4, new Vector3(0.1f * LightMultiplier, 0.5f * LightMultiplier, 0.2f * LightMultiplier));
				}
#if VERSION_103 || VERSION_FINAL // BUG: Souls of Blight are not lit up correctly in versions prior to the console 1.2 update.
				else if (Type == (int)EntityID.ItemID.SOUL_OF_BLIGHT)
				{
					float LightMultiplier = Main.Rand.Next(90, 111) * 0.01f;
					LightMultiplier *= UI.PulseScale;
					Lighting.AddLight((int)Position.X + (Width >> 1) >> 4, (int)Position.Y + (Height >> 1) >> 4, new Vector3(0.4f * LightMultiplier, 0.6f * LightMultiplier, 0.1f * LightMultiplier));
				}
#endif
				else if (Type == (int)EntityID.ItemID.HEART)
				{
					float LightMultiplier = Main.Rand.Next(90, 111) * 0.01f;
					LightMultiplier *= UI.PulseScale * 0.5f;
					Lighting.AddLight((int)Position.X + (Width >> 1) >> 4, (int)Position.Y + (Height >> 1) >> 4, new Vector3(0.5f * LightMultiplier, 0.1f * LightMultiplier, 0.1f * LightMultiplier));
				}
				else if (Type == (int)EntityID.ItemID.STAR)
				{
					float LightMultiplier = Main.Rand.Next(90, 111) * 0.01f;
					LightMultiplier *= UI.PulseScale * 0.5f;
					Lighting.AddLight((int)Position.X + (Width >> 1) >> 4, (int)Position.Y + (Height >> 1) >> 4, new Vector3(0.1f * LightMultiplier, 0.1f * LightMultiplier, 0.5f * LightMultiplier));
				}
				else if (Type == (int)EntityID.ItemID.CURSED_FLAME)
				{
					float LightMultiplier = Main.Rand.Next(90, 111) * 0.01f;
					LightMultiplier *= UI.PulseScale * 0.2f;
					Lighting.AddLight((int)Position.X + (Width >> 1) >> 4, (int)Position.Y + (Height >> 1) >> 4, new Vector3(0.5f * LightMultiplier, 1f * LightMultiplier, 0.1f * LightMultiplier));
				}
				else if (Type == (int)EntityID.ItemID.FALLEN_STAR && Main.GameTime.DayTime)
				{
					for (int i = 0; i < 8; i++)
					{
						if (null == Main.DustSet.NewDust((int)Position.X, (int)Position.Y, Width, Height, 15, Velocity.X, Velocity.Y, 150, default, 1.2))
						{
							break;
						}
					}
					for (int j = 0; j < 3; j++)
					{
						Gore.NewGore(Position, Velocity, Main.Rand.Next((int)EntityID.GoreID.FALLEN_STAR_PARTICLE1, (int)EntityID.GoreID.FALLEN_STAR_PARTICLE2 + 1));
					}
					Active = 0;
					Type = 0;
					Stack = 0;
					if (Main.NetMode == (byte)NetModeSetting.SERVER)
					{
						NetMessage.CreateMessage2(21, UI.MainUI.MyPlayer, ActiveItemIdx);
						NetMessage.SendMessage();
					}
				}
			}
			else
			{
				BeingGrabbed = false;
			}
			if (Type == (int)EntityID.ItemID.PIXIE_DUST)
			{
				if (Main.Rand.Next(6) == 0)
				{
					Dust* ActiveDust = Main.DustSet.NewDust((int)Position.X, (int)Position.Y, Width, Height, 55, 0.0, 0.0, 200, Colour);
					if (ActiveDust != null)
					{
						ActiveDust->Velocity.X *= 0.3f;
						ActiveDust->Velocity.Y *= 0.3f;
						ActiveDust->Scale *= 0.5f;
					}
				}
			}
			else if (Type == (int)EntityID.ItemID.TORCH || Type == (int)EntityID.ItemID.CANDLE)
			{
				if (!IsWet)
				{
					Lighting.AddLight((int)Position.X + (Width >> 1) >> 4, (int)Position.Y + (Height >> 1) >> 4, new Vector3(1f, 0.95f, 0.8f));
				}
			}
			else if (Type == (int)EntityID.ItemID.CURSED_TORCH)
			{
				Lighting.AddLight((int)Position.X + (Width >> 1) >> 4, (int)Position.Y + (Height >> 1) >> 4, new Vector3(0.85f, 1f, 0.7f));
			}
			else if (Type >= (int)EntityID.ItemID.BLUE_TORCH && Type <= (int)EntityID.ItemID.YELLOW_TORCH)
			{
				if (!IsWet)
				{
					Vector3 TorchLight;
					switch (Type)
					{
						case (int)EntityID.ItemID.BLUE_TORCH:
							TorchLight = new Vector3(0.1f, 0.2f, 1.1f);
							break;
						case (int)EntityID.ItemID.RED_TORCH:
							TorchLight = new Vector3(1f, 0.1f, 0.1f);
							break;
						case (int)EntityID.ItemID.GREEN_TORCH:
							TorchLight = new Vector3(0f, 1f, 0.1f);
							break;
						case (int)EntityID.ItemID.PURPLE_TORCH:
							TorchLight = new Vector3(0.9f, 0f, 0.9f);
							break;
						case (int)EntityID.ItemID.WHITE_TORCH:
							TorchLight = new Vector3(1.3f, 1.3f, 1.3f);
							break;
						default: // Yellow Torch
							TorchLight = new Vector3(0.9f, 0.9f, 0f);
							break;
					}
					Lighting.AddLight((int)Position.X + (Width >> 1) >> 4, (int)Position.Y + (Height >> 1) >> 4, TorchLight);
				}
			}
			else if (Type == (int)EntityID.ItemID.FLAMING_ARROW)
			{
				if (!IsWet)
				{
					Lighting.AddLight((int)Position.X + Width >> 4, (int)Position.Y + (Height >> 1) >> 4, new Vector3(1f, 0.75f, 0.55f));
				}
			}
			else if (Type == (int)EntityID.ItemID.SPECTRAL_ARROW)
			{
				Lighting.AddLight((int)Position.X + Width >> 4, (int)Position.Y + (Height >> 1) >> 4, IsWet ? new Vector3(0.25f, 0.5f, 0.5f) : new Vector3(0.5f, 1f, 1f));
			}
			else if (Type == (int)EntityID.ItemID.GLOWSTICK)
			{
				Lighting.AddLight((int)Position.X + Width >> 4, (int)Position.Y + (Height >> 1) >> 4, new Vector3(0.7f, 1f, 0.8f));
			}
			else if (Type == (int)EntityID.ItemID.STICKY_GLOWSTICK)
			{
				Lighting.AddLight((int)Position.X + Width >> 4, (int)Position.Y + (Height >> 1) >> 4, new Vector3(0.7f, 0.8f, 1f));
			}
			else if (Type == (int)EntityID.ItemID.JUNGLE_SPORES)
			{
				Lighting.AddLight((int)Position.X + Width >> 4, (int)Position.Y + (Height >> 1) >> 4, new Vector3(0.55f, 0.75f, 0.6f));
			}
			else if (Type == (int)EntityID.ItemID.GLOWING_MUSHROOM)
			{
				Lighting.AddLight((int)Position.X + Width >> 4, (int)Position.Y + (Height >> 1) >> 4, new Vector3(0.15f, 0.45f, 0.9f));
			}
			else if (Type == (int)EntityID.ItemID.FALLEN_STAR)
			{
				Lighting.AddLight((int)Position.X + Width >> 4, (int)Position.Y + (Height >> 1) >> 4, new Vector3(0.8f, 0.7f, 0.1f));
				if (Main.Rand.Next(32) == 0)
				{
					Main.DustSet.NewDust((int)Position.X, (int)Position.Y, Width, Height, 58, Velocity.X * 0.5f, Velocity.Y * 0.5f, 150, default, 1.2);
				}
				else if (Main.Rand.Next(64) == 0)
				{
					Gore.NewGore(Position, new Vector2(Velocity.X * 0.2f, Velocity.Y * 0.2f), Main.Rand.Next((int)EntityID.GoreID.FALLEN_STAR_PARTICLE1, (int)EntityID.GoreID.FALLEN_STAR_PARTICLE2 + 1));
				}
			}
			SpawnTime++;
			if (Main.NetMode == (byte)NetModeSetting.SERVER && !IsLocal() && ++Release >= 300)
			{
				Release = 0;
				FindOwner(ActiveItemIdx);
			}
			if (IsWet)
			{
				Position.X += ItemVelocity.X;
				Position.Y += ItemVelocity.Y;
			}
			else
			{
				Position.X += Velocity.X;
				Position.Y += Velocity.Y;
			}
			if (NoGrabDelay > 0)
			{
				NoGrabDelay--;
			}
		}

		public unsafe static int NewItem(int X, int Y, int Width, int Height, int Type, int Stack = 1, bool DoNotBroadcast = false, int Prefix = 0)
		{
			int ItemLimit = Main.MaxNumItems;
			if (Main.NetMode != (byte)NetModeSetting.CLIENT)
			{
				uint LastIdx = LastItemIndex;
				uint ItemSpawnTime = Main.ItemSet[LastIdx].SpawnTime;
				uint LatestIdx = LastIdx;
				for (int i = Main.MaxNumItems - 1; i >= 0; i--)
				{
					if (Main.ItemSet[LastIdx].Active == 0)
					{
						ItemLimit = (int)LastIdx;
						break;
					}
					if (++LastIdx == Main.MaxNumItems)
					{
						LastIdx = 0;
					}
					uint PrevSpawnTime = Main.ItemSet[LastIdx].SpawnTime;
					if (PrevSpawnTime > ItemSpawnTime)
					{
						ItemSpawnTime = PrevSpawnTime;
						LatestIdx = LastIdx;
					}
				}
				if (ItemLimit == Main.MaxNumItems)
				{
					ItemLimit = (int)LatestIdx;
				}
				if (++LastIdx == Main.MaxNumItems)
				{
					LastIdx = 0;
				}
				LastItemIndex = LastIdx;
			}
			fixed (Item* ActiveItem = &Main.ItemSet[ItemLimit])
			{
				ActiveItem->SetDefaults(Type, Stack);
				ActiveItem->SetPrefix(Prefix);
				ActiveItem->Position.X = X + (Width - ActiveItem->Width >> 1);
				ActiveItem->Position.Y = Y + (Height - ActiveItem->Height >> 1);
				ActiveItem->IsWet = Collision.WetCollision(ref ActiveItem->Position, ActiveItem->Width, ActiveItem->Height);
				ActiveItem->Velocity.X = Main.Rand.Next(-30, 31) * 0.1f;
				if (Type == (int)EntityID.ItemID.SOUL_OF_LIGHT || Type == (int)EntityID.ItemID.SOUL_OF_NIGHT)
				{
					ActiveItem->Velocity.Y = Main.Rand.Next(-30, 31) * 0.1f;
				}
				else
				{
					ActiveItem->Velocity.Y = Main.Rand.Next(-40, -15) * 0.1f;
				}
				ActiveItem->SpawnTime = 0;
				if (!DoNotBroadcast && Main.NetMode != (byte)NetModeSetting.CLIENT)
				{
					NetMessage.CreateMessage2(21, UI.MainUI.MyPlayer, ItemLimit);
					NetMessage.SendMessage();
					ActiveItem->FindOwner(ItemLimit);
				}
			}
			return ItemLimit;
		}

		public unsafe void FindOwner(int WhoAmI)
		{
			if (KeepTime > 0)
			{
				return;
			}
			int OwnerIdx = Player.MaxNumPlayers;
			int RegisteredSpace = NPC.SpawnWidth;
			int XCoord = (int)Position.X - (Width >> 1);
			int YCoord = (int)Position.Y - Height;
			fixed (Item* ActiveItem = &this)
			{
				for (int CurrentIdx = 0; CurrentIdx < Player.MaxNumPlayers; CurrentIdx++)
				{
					if (OwnIgnore != CurrentIdx && Main.PlayerSet[CurrentIdx].Active != 0 && Main.PlayerSet[CurrentIdx].ItemSpace(ActiveItem))
					{
						int num5 = Math.Abs(Main.PlayerSet[CurrentIdx].XYWH.X + 10 - XCoord) + Math.Abs(Main.PlayerSet[CurrentIdx].XYWH.Y + 21 - YCoord);
						if (num5 < RegisteredSpace)
						{
							RegisteredSpace = num5;
							OwnerIdx = CurrentIdx;
						}
					}
				}
			}
			int ItemOwner = Owner;
			if (OwnerIdx != ItemOwner)
			{
				bool LocalOwner = IsLocal();
				Owner = (byte)OwnerIdx;
				if (((LocalOwner && Main.NetMode >= 1) || (ItemOwner == 8 && Main.NetMode == (byte)NetModeSetting.SERVER) || Main.PlayerSet[ItemOwner].Active == 0) && Active != 0)
				{
					NetMessage.CreateMessage1(22, WhoAmI);
					NetMessage.SendMessage();
				}
			}
		}

		public bool IsNotTheSameAs(ref Item ComparedItem)
		{
			if (NetID == ComparedItem.NetID && Stack == ComparedItem.Stack)
			{
				return PrefixType != ComparedItem.PrefixType;
			}
			return true;
		}

		public bool CanBePlacedInAmmoSlot()
		{
			if (Ammo <= 0)
			{
				return Type == (int)EntityID.ItemID.WIRE;
			}
			return true;
		}

		public bool CanBeAutoPlacedInEmptyAmmoSlot()
		{
			if (Type != (int)EntityID.ItemID.SAND_BLOCK && Type != (int)EntityID.ItemID.FALLEN_STAR && Type != (int)EntityID.ItemID.GEL && Type != (int)EntityID.ItemID.EBONSAND_BLOCK)
			{
				return Type != (int)EntityID.ItemID.PEARLSAND_BLOCK;
			}
			return false;
		}

		public bool CanBePlacedInCoinSlot()
		{
			if (Type >= (int)EntityID.ItemID.COPPER_COIN)
			{
				return Type <= (int)EntityID.ItemID.PLATINUM_COIN;
			}
			return false;
		}
	}
}
