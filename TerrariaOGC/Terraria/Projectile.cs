using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Net;
using System;

namespace Terraria
{
	public struct Projectile
	{
		private struct PetAnim
		{
			private byte startFrame;

			private byte endFrame;

			private byte frameDelay;

			public PetAnim(int s, int e, int d)
			{
				startFrame = (byte)s;
				endFrame = (byte)e;
				frameDelay = (byte)d;
			}

			public void Update(ref Projectile p)
			{
				if (p.frame < startFrame || p.frame > endFrame)
				{
					p.frame = startFrame;
					p.frameCounter = 0;
				}
				else if (++p.frameCounter >= frameDelay)
				{
					p.frameCounter = 0;
					if (++p.frame > endFrame)
					{
						p.frame = startFrame;
					}
				}
			}
		}

		public const int MaxNumProjTypes = (int)EntityID.ProjectileID.NUM_TYPES;

		public const int MaxNumProjs = 512;

		public const int NUM_OLD_POS = 10;

		public const uint TOMBSTONE_TEXT_QUEUE = Player.MaxNumPlayers;

		private static byte[] projFrameH = new byte[MaxNumProjTypes];

		public static readonly byte[] petProj = new byte[6]
		{
			(byte)EntityID.ProjectileID.PET_BUNNY,
			(byte)EntityID.ProjectileID.PET_SLIME,
			(byte)EntityID.ProjectileID.PET_TIPHIA,
			(byte)EntityID.ProjectileID.PET_BAT,
			(byte)EntityID.ProjectileID.PET_WEREWOLF,
			(byte)EntityID.ProjectileID.PET_ZOMBIE,
		};

		private static readonly PetAnim[] petAnimIdle = new PetAnim[6]
		{
			new PetAnim(0, 0, 255),
			new PetAnim(0, 1, 24),
			new PetAnim(0, 2, 2),
			new PetAnim(0, 4, 4),
			new PetAnim(0, 0, 255),
			new PetAnim(0, 0, 255)
		};

		private static readonly PetAnim[] petAnimMove = new PetAnim[6]
		{
			new PetAnim(0, 6, 6),
			new PetAnim(0, 1, 14),
			new PetAnim(0, 2, 1),
			new PetAnim(0, 4, 3),
			new PetAnim(2, 15, 4),
			new PetAnim(0, 2, 14)
		};

		private static readonly PetAnim[] petAnimFall = new PetAnim[6]
		{
			new PetAnim(4, 4, 255),
			new PetAnim(1, 1, 255),
			new PetAnim(0, 2, 1),
			new PetAnim(0, 4, 3),
			new PetAnim(1, 1, 255),
			new PetAnim(2, 2, 255)
		};

		private static readonly PetAnim[] petAnimJump = new PetAnim[6]
		{
			new PetAnim(6, 6, 255),
			new PetAnim(1, 1, 255),
			new PetAnim(0, 2, 1),
			new PetAnim(0, 4, 3),
			new PetAnim(1, 1, 255),
			new PetAnim(2, 2, 255)
		};

		private static readonly PetAnim[] petAnimFly = new PetAnim[6]
		{
			new PetAnim(7, 7, 255),
			new PetAnim(1, 1, 255),
			new PetAnim(0, 2, 1),
			new PetAnim(0, 4, 3),
			new PetAnim(8, 8, 255),
			new PetAnim(1, 1, 255)
		};

		public static readonly short[] petItem = new short[6]
		{
			(short)EntityID.ItemID.PET_SPAWN_1,
			(short)EntityID.ItemID.PET_SPAWN_2,
			(short)EntityID.ItemID.PET_SPAWN_3,
			(short)EntityID.ItemID.PET_SPAWN_4,
			(short)EntityID.ItemID.PET_SPAWN_5,
			(short)EntityID.ItemID.PET_SPAWN_6
		};

		private static uint lastProjectileIndex = 0;

		public static uint tombstoneTextIndex = 0;

		public static string[] tombstoneText = new string[Player.MaxNumPlayers];

		public byte active;

		public byte type;

		public bool wet;

		public bool lavaWet;

		public bool hostile;

		public bool friendly;

		public bool tileCollide;

		public bool ignoreWater;

		public bool hide;

		public bool ownerHitCheck;

		public bool melee;

		public bool ranged;

		public bool magic;

		public byte maxUpdates;

		public sbyte numUpdates;

		public byte wetCount;

#if VERSION_INITIAL && !IS_PATCHED
		public byte alpha;
#else
		public short alpha;
#endif

		public byte aiStyle;

		public sbyte direction;

		public sbyte spriteDirection;

		public sbyte penetrate;

		public byte owner;

		public ushort width;

		public ushort height;

		public short whoAmI;

		public Rectangle XYWH;

		public float knockBack;

		public float light;

		public Vector2 position;

		public Vector2 lastPosition;

		public Vector2 velocity;

		public float scale;

		public float rotation;

		public float ai0;

		public int ai1;

		public int timeLeft;

		public short soundDelay;

		public short damage;

		public ushort identity;

		public bool netUpdate;

		private sbyte localAI0;

		public byte tombstoneTextId;

		public byte frameCounter;

		public byte frame;

		public unsafe fixed sbyte playerImmune[Player.MaxNumPlayers];

		public unsafe fixed float oldPos[20];

		public static void Initialize()
		{
			for (int i = 1; i < MaxNumProjTypes; i++)
			{
				projFrameH[i] = 0;
			}
			projFrameH[(int)EntityID.ProjectileID.BLUE_FAIRY] = (byte)(SpriteSheet<_sheetSprites>.Source[(int)_sheetSprites.ID.PROJECTILE_72].Height / 4);
			projFrameH[(int)EntityID.ProjectileID.PINK_FAIRY] = (byte)(SpriteSheet<_sheetSprites>.Source[(int)_sheetSprites.ID.PROJECTILE_86].Height / 4);
			projFrameH[(int)EntityID.ProjectileID.GREEN_FAIRY] = (byte)(SpriteSheet<_sheetSprites>.Source[(int)_sheetSprites.ID.PROJECTILE_87].Height / 4);
			projFrameH[(int)EntityID.ProjectileID.BOMB_SKELETRON_PRIME] = (byte)(SpriteSheet<_sheetSprites>.Source[(int)_sheetSprites.ID.PROJECTILE_102].Height / 2);
			projFrameH[(int)EntityID.ProjectileID.PET_BUNNY] = (byte)(SpriteSheet<_sheetSprites>.Source[(int)_sheetSprites.ID.PROJECTILE_111].Height / 8);
			projFrameH[(int)EntityID.ProjectileID.PET_SLIME] = (byte)(SpriteSheet<_sheetSprites>.Source[(int)_sheetSprites.ID.PROJECTILE_115].Height / 2);
			projFrameH[(int)EntityID.ProjectileID.PET_TIPHIA] = (byte)(SpriteSheet<_sheetSprites>.Source[(int)_sheetSprites.ID.PROJECTILE_116].Height / 3);
			projFrameH[(int)EntityID.ProjectileID.PET_BAT] = (byte)(SpriteSheet<_sheetSprites>.Source[(int)_sheetSprites.ID.PROJECTILE_117].Height / 5);
			projFrameH[(int)EntityID.ProjectileID.PET_WEREWOLF] = (byte)(SpriteSheet<_sheetSprites>.Source[(int)_sheetSprites.ID.PROJECTILE_118].Height / 16);
			projFrameH[(int)EntityID.ProjectileID.PET_ZOMBIE] = (byte)(SpriteSheet<_sheetSprites>.Source[(int)_sheetSprites.ID.PROJECTILE_119].Height / 3);
		}

		public void Init()
		{
			active = 0;
			type = 0;
			direction = (spriteDirection = 1);
		}

		public bool isLocal()
		{
			if (owner != Player.MaxNumPlayers || Main.NetMode == (byte)NetModeSetting.CLIENT)
			{
				return Main.PlayerSet[owner].isLocal();
			}
			return true;
		}

		public unsafe void SetDefaults(int Type)
		{
			ai0 = 0f;
			ai1 = 0;
			localAI0 = 0;
			fixed (sbyte* ptr = playerImmune)
			{
				for (int i = 0; i < Player.MaxNumPlayers; i++)
				{
					ptr[i] = 0;
				}
			}
			soundDelay = 0;
			spriteDirection = 1;
			melee = false;
			ranged = false;
			magic = false;
			ownerHitCheck = false;
			hide = false;
			lavaWet = false;
			wetCount = 0;
			wet = false;
			ignoreWater = false;
			hostile = false;
			netUpdate = false;
			numUpdates = 0;
			maxUpdates = 0;
			identity = 0;
			light = 0f;
			penetrate = 1;
			tileCollide = true;
			position = default;
			velocity = default;
			aiStyle = 0;
			alpha = 0;
			type = (byte)Type;
			active = 1;
			rotation = 0f;
			scale = 1f;
			owner = Player.MaxNumPlayers;
			timeLeft = 3600;
			friendly = true;
			damage = 0;
			knockBack = 0f;

			switch ((EntityID.ProjectileID)type)
			{
				case EntityID.ProjectileID.WOODEN_ARROW_FRIENDLY:
					width = 10;
					height = 10;
					aiStyle = (byte)EntityID.ProjStyleID.ARROWS_BULLETS;
					ranged = true;
					break;

				case EntityID.ProjectileID.FIRE_ARROW:
					width = 10;
					height = 10;
					aiStyle = (byte)EntityID.ProjStyleID.ARROWS_BULLETS;
					light = 1f;
					ranged = true;
					break;

				case EntityID.ProjectileID.SHURIKEN:
					width = 22;
					height = 22;
					aiStyle = (byte)EntityID.ProjStyleID.SHURIKEN;
					penetrate = 4;
					ranged = true;
					break;

				case EntityID.ProjectileID.UNHOLY_ARROW:
					width = 10;
					height = 10;
					aiStyle = (byte)EntityID.ProjStyleID.ARROWS_BULLETS;
					light = 0.35f;
					penetrate = 5;
					ranged = true;
					break;

				case EntityID.ProjectileID.JESTERS_ARROW:
					width = 10;
					height = 10;
					aiStyle = (byte)EntityID.ProjStyleID.ARROWS_BULLETS;
					light = 0.4f;
					penetrate = -1;
					timeLeft = 40;
					alpha = 100;
					ignoreWater = true;
					ranged = true;
					break;

				case EntityID.ProjectileID.ENCHANTED_BOOMERANG:
					width = 22;
					height = 22;
					aiStyle = (byte)EntityID.ProjStyleID.BOOMERANG;
					penetrate = -1;
					melee = true;
					light = 0.4f;
					break;

				case EntityID.ProjectileID.VILETHORN_BASE:
				case EntityID.ProjectileID.VILETHORN_TIP:
					width = 28;
					height = 28;
					aiStyle = (byte)EntityID.ProjStyleID.VILETHORN;
					penetrate = -1;
					tileCollide = false;
					alpha = 255;
					ignoreWater = true;
					magic = true;
					break;

				case EntityID.ProjectileID.STARFURY:
					width = 24;
					height = 24;
					aiStyle = (byte)EntityID.ProjStyleID.STARFURY;
					penetrate = 2;
					alpha = 50;
					scale = 0.8f;
					tileCollide = false;
					magic = true;
					break;

				case EntityID.ProjectileID.PURIFICATION_POWDER:
					width = 64;
					height = 64;
					aiStyle = (byte)EntityID.ProjStyleID.POWDERS;
					tileCollide = false;
					penetrate = -1;
					alpha = 255;
					ignoreWater = true;
					break;

				case EntityID.ProjectileID.VILE_POWDER:
					width = 48;
					height = 48;
					aiStyle = (byte)EntityID.ProjStyleID.POWDERS;
					tileCollide = false;
					penetrate = -1;
					alpha = 255;
					ignoreWater = true;
					break;

				case EntityID.ProjectileID.FALLING_STAR:
					width = 16;
					height = 16;
					aiStyle = (byte)EntityID.ProjStyleID.STARFURY;
					penetrate = -1;
					alpha = 50;
					light = 1f;
					break;

				case EntityID.ProjectileID.HOOK:
					width = 18;
					height = 18;
					aiStyle = (byte)EntityID.ProjStyleID.GRAPPLING_HOOK;
					penetrate = -1;
					tileCollide = false;
					timeLeft *= 10;
					break;

				case EntityID.ProjectileID.BULLET:
					width = 4;
					height = 4;
					aiStyle = (byte)EntityID.ProjStyleID.ARROWS_BULLETS;
					penetrate = 1;
					light = 0.5f;
					alpha = 255;
					maxUpdates = 1;
					scale = 1.2f;
					timeLeft = 600;
					ranged = true;
					break;

				case EntityID.ProjectileID.BALL_OF_FIRE:
					width = 16;
					height = 16;
					aiStyle = (byte)EntityID.ProjStyleID.BALL_OF_FIRE;
					light = 0.8f;
					alpha = 100;
					magic = true;
					break;

				case EntityID.ProjectileID.MAGIC_MISSILE:
					width = 10;
					height = 10;
					aiStyle = (byte)EntityID.ProjStyleID.MAGIC_MISSILE;
					light = 0.8f;
					alpha = 100;
					magic = true;
					break;

				case EntityID.ProjectileID.DIRT_BALL:
					width = 10;
					height = 10;
					aiStyle = (byte)EntityID.ProjStyleID.DIRT_BALL;
					break;

				case EntityID.ProjectileID.SHADOW_ORB:
					width = 32;
					height = 32;
					aiStyle = (byte)EntityID.ProjStyleID.SHADOW_ORB;
					light = 0.45f;
					alpha = 150;
					tileCollide = false;
					penetrate = -1;
					timeLeft = 18000;
					ignoreWater = true;
					scale = 0.8f;
					break;

				case EntityID.ProjectileID.FLAMARANG:
					width = 22;
					height = 22;
					aiStyle = (byte)EntityID.ProjStyleID.BOOMERANG;
					penetrate = -1;
					light = 1f;
					melee = true;
					break;

				case EntityID.ProjectileID.GREEN_LASER:
					width = 4;
					height = 4;
					aiStyle = (byte)EntityID.ProjStyleID.ARROWS_BULLETS;
					penetrate = 3;
					light = 0.75f;
					alpha = 255;
					maxUpdates = 2;
					scale = 1.4f;
					timeLeft = 600;
					magic = true;
					break;

				case EntityID.ProjectileID.BONE:
					width = 16;
					height = 16;
					aiStyle = (byte)EntityID.ProjStyleID.SHURIKEN;
					scale = 1.2f;
					ranged = true;
					break;

				case EntityID.ProjectileID.WATER_STREAM:
					width = 18;
					height = 18;
					aiStyle = (byte)EntityID.ProjStyleID.WATER_STREAM;
					alpha = 255;
					penetrate = -1;
					maxUpdates = 2;
					ignoreWater = true;
					magic = true;
					break;

				case EntityID.ProjectileID.HARPOON:
					width = 4;
					height = 4;
					aiStyle = (byte)EntityID.ProjStyleID.HARPOON;
					penetrate = -1;
					alpha = 255;
					ranged = true;
					break;

				case EntityID.ProjectileID.SPIKY_BALL:
					width = 14;
					height = 14;
					aiStyle = (byte)EntityID.ProjStyleID.SPIKY_BALL;
					penetrate = 6;
					ranged = true;
					break;

				case EntityID.ProjectileID.BALL_O_HURT:
					width = 22;
					height = 22;
					aiStyle = (byte)EntityID.ProjStyleID.FLAIL;
					penetrate = -1;
					melee = true;
					scale = 0.8f;
					break;

				case EntityID.ProjectileID.BLUE_MOON:
					width = 22;
					height = 22;
					aiStyle = (byte)EntityID.ProjStyleID.FLAIL;
					penetrate = -1;
					melee = true;
					scale = 0.8f;
					break;

				case EntityID.ProjectileID.WATER_BOLT:
					width = 16;
					height = 16;
					aiStyle = (byte)EntityID.ProjStyleID.BALL_OF_FIRE;
					light = 0.8f;
					alpha = 200;
					timeLeft = 1800;
					penetrate = 10;
					magic = true;
					break;

				case EntityID.ProjectileID.BOMB:
					width = 22;
					height = 22;
					aiStyle = (byte)EntityID.ProjStyleID.BOMB;
					penetrate = -1;
					break;

				case EntityID.ProjectileID.DYNAMITE:
					width = 10;
					height = 10;
					aiStyle = (byte)EntityID.ProjStyleID.BOMB;
					penetrate = -1;
					break;

				case EntityID.ProjectileID.GRENADE:
					width = 14;
					height = 14;
					aiStyle = (byte)EntityID.ProjStyleID.BOMB;
					penetrate = -1;
					ranged = true;
					break;

				case EntityID.ProjectileID.SAND_BALL_FALLING:
					knockBack = 6f;
					width = 10;
					height = 10;
					aiStyle = (byte)EntityID.ProjStyleID.DIRT_BALL;
					hostile = true;
					penetrate = -1;
					break;

				case EntityID.ProjectileID.IVY_WHIP:
					width = 18;
					height = 18;
					aiStyle = (byte)EntityID.ProjStyleID.GRAPPLING_HOOK;
					penetrate = -1;
					tileCollide = false;
					timeLeft = 36000;
					break;

				case EntityID.ProjectileID.THORN_CHAKRAM:
					width = 28;
					height = 28;
					aiStyle = (byte)EntityID.ProjStyleID.BOOMERANG;
					scale = 0.9f;
					penetrate = -1;
					melee = true;
					break;

				case EntityID.ProjectileID.FLAMELASH:
					width = 14;
					height = 14;
					aiStyle = (byte)EntityID.ProjStyleID.MAGIC_MISSILE;
					light = 0.8f;
					alpha = 100;
					penetrate = 1;
					magic = true;
					break;

				case EntityID.ProjectileID.SUNFURY:
					width = 22;
					height = 22;
					aiStyle = (byte)EntityID.ProjStyleID.FLAIL;
					penetrate = -1;
					melee = true;
					scale = 0.8f;
					break;

				case EntityID.ProjectileID.METEOR_SHOT:
					width = 4;
					height = 4;
					aiStyle = (byte)EntityID.ProjStyleID.ARROWS_BULLETS;
					penetrate = 2;
					light = 0.6f;
					alpha = 255;
					maxUpdates = 1;
					scale = 1.4f;
					timeLeft = 600;
					ranged = true;
					break;

				case EntityID.ProjectileID.STICKY_BOMB:
					width = 22;
					height = 22;
					aiStyle = (byte)EntityID.ProjStyleID.BOMB;
					penetrate = -1;
					tileCollide = false;
					break;

				case EntityID.ProjectileID.HARPY_FEATHER:
					width = 14;
					height = 14;
					aiStyle = (byte)EntityID.ProjStyleID.NONE;
					hostile = true;
					penetrate = -1;
					aiStyle = (byte)EntityID.ProjStyleID.ARROWS_BULLETS;
					tileCollide = true;
					friendly = false;
					break;

				case EntityID.ProjectileID.MUD_BALL:
					knockBack = 6f;
					width = 10;
					height = 10;
					aiStyle = (byte)EntityID.ProjStyleID.DIRT_BALL;
					hostile = true;
					penetrate = -1;
					break;

				case EntityID.ProjectileID.ASH_BALL_FALLING:
					knockBack = 6f;
					width = 10;
					height = 10;
					aiStyle = (byte)EntityID.ProjStyleID.DIRT_BALL;
					hostile = true;
					penetrate = -1;
					break;

				case EntityID.ProjectileID.HELLFIRE_ARROW:
					width = 10;
					height = 10;
					aiStyle = (byte)EntityID.ProjStyleID.ARROWS_BULLETS;
					penetrate = -1;
					ranged = true;
					light = 0.3f;
					break;

				case EntityID.ProjectileID.VULCAN_BOLT:
					width = 10;
					height = 10;
					aiStyle = (byte)EntityID.ProjStyleID.ARROWS_BULLETS;
					penetrate = -1;
					ranged = true;
					light = 0.4f;
					break;

				case EntityID.ProjectileID.SAND_BALL_GUN:
					knockBack = 8f;
					width = 10;
					height = 10;
					aiStyle = (byte)EntityID.ProjStyleID.DIRT_BALL;
					maxUpdates = 1;
					break;

				case EntityID.ProjectileID.TOMBSTONE:
					knockBack = 12f;
					width = 24;
					height = 24;
					aiStyle = (byte)EntityID.ProjStyleID.TOMBSTONE;
					penetrate = -1;
					friendly = false;
					break;

				case EntityID.ProjectileID.DEMON_SICKLE:
					width = 48;
					height = 48;
					alpha = 100;
					light = 0.2f;
					aiStyle = (byte)EntityID.ProjStyleID.DEMON_SICKLE;
					hostile = true;
					penetrate = -1;
					tileCollide = true;
					scale = 0.9f;
					friendly = false;
					break;

				case EntityID.ProjectileID.DEMON_SCYTHE:
					width = 48;
					height = 48;
					alpha = 100;
					light = 0.2f;
					aiStyle = (byte)EntityID.ProjStyleID.DEMON_SICKLE;
					penetrate = 5;
					tileCollide = true;
					scale = 0.9f;
					magic = true;
					break;

				case EntityID.ProjectileID.DARK_LANCE:
					width = 20;
					height = 20;
					aiStyle = (byte)EntityID.ProjStyleID.SPEAR;
					penetrate = -1;
					tileCollide = false;
					scale = 1.1f;
					hide = true;
					ownerHitCheck = true;
					melee = true;
					break;

				case EntityID.ProjectileID.TRIDENT:
					width = 18;
					height = 18;
					aiStyle = (byte)EntityID.ProjStyleID.SPEAR;
					penetrate = -1;
					tileCollide = false;
					scale = 1.1f;
					hide = true;
					ownerHitCheck = true;
					melee = true;
					break;

				case EntityID.ProjectileID.THROWING_KNIFE:
					width = 12;
					height = 12;
					aiStyle = (byte)EntityID.ProjStyleID.SHURIKEN;
					penetrate = 2;
					ranged = true;
					break;

				case EntityID.ProjectileID.SPEAR:
					width = 18;
					height = 18;
					aiStyle = (byte)EntityID.ProjStyleID.SPEAR;
					penetrate = -1;
					tileCollide = false;
					scale = 1.2f;
					hide = true;
					ownerHitCheck = true;
					melee = true;
					break;

				case EntityID.ProjectileID.GLOWSTICK:
					width = 6;
					height = 6;
					aiStyle = (byte)EntityID.ProjStyleID.SPIKY_BALL;
					penetrate = -1;
					alpha = 75;
					light = 1f;
					timeLeft = 18000;
					friendly = false;
					break;

				case EntityID.ProjectileID.SEED:
					width = 8;
					height = 8;
					aiStyle = (byte)EntityID.ProjStyleID.ARROWS_BULLETS;
					break;

				case EntityID.ProjectileID.WOODEN_BOOMERANG:
					width = 22;
					height = 22;
					aiStyle = (byte)EntityID.ProjStyleID.BOOMERANG;
					penetrate = -1;
					melee = true;
					break;

				case EntityID.ProjectileID.STICKY_GLOWSTICK:
					width = 6;
					height = 6;
					aiStyle = (byte)EntityID.ProjStyleID.SPIKY_BALL;
					penetrate = -1;
					alpha = 75;
					light = 1f;
					timeLeft = 18000;
					tileCollide = false;
					friendly = false;
					break;

				case EntityID.ProjectileID.POISONED_KNIFE:
					width = 12;
					height = 12;
					aiStyle = (byte)EntityID.ProjStyleID.SHURIKEN;
					penetrate = 2;
					ranged = true;
					break;

				case EntityID.ProjectileID.STINGER:
					width = 10;
					height = 10;
					aiStyle = (byte)EntityID.ProjStyleID.NONE;
					hostile = true;
					friendly = false;
					penetrate = -1;
					aiStyle = (byte)EntityID.ProjStyleID.ARROWS_BULLETS;
					tileCollide = true;
					break;

				case EntityID.ProjectileID.EBONSAND_BALL_FALLING:
					knockBack = 6f;
					width = 10;
					height = 10;
					aiStyle = (byte)EntityID.ProjStyleID.DIRT_BALL;
					hostile = true;
					penetrate = -1;
					break;

				case EntityID.ProjectileID.COBALT_CHAINSAW:
					width = 18;
					height = 18;
					aiStyle = (byte)EntityID.ProjStyleID.CHAINSAW;
					penetrate = -1;
					tileCollide = false;
					hide = true;
					ownerHitCheck = true;
					melee = true;
					break;

				case EntityID.ProjectileID.MYTHRIL_CHAINSAW:
					width = 18;
					height = 18;
					aiStyle = (byte)EntityID.ProjStyleID.CHAINSAW;
					penetrate = -1;
					tileCollide = false;
					hide = true;
					ownerHitCheck = true;
					melee = true;
					scale = 1.08f;
					break;

				case EntityID.ProjectileID.COBALT_DRILL:
					width = 22;
					height = 22;
					aiStyle = (byte)EntityID.ProjStyleID.CHAINSAW;
					penetrate = -1;
					tileCollide = false;
					hide = true;
					ownerHitCheck = true;
					melee = true;
					scale = 0.9f;
					break;

				case EntityID.ProjectileID.MYTHRIL_DRILL:
					width = 22;
					height = 22;
					aiStyle = (byte)EntityID.ProjStyleID.CHAINSAW;
					penetrate = -1;
					tileCollide = false;
					hide = true;
					ownerHitCheck = true;
					melee = true;
					scale = 0.9f;
					break;

				case EntityID.ProjectileID.ADAMANTITE_CHAINSAW:
					width = 18;
					height = 18;
					aiStyle = (byte)EntityID.ProjStyleID.CHAINSAW;
					penetrate = -1;
					tileCollide = false;
					hide = true;
					ownerHitCheck = true;
					melee = true;
					scale = 1.16f;
					break;

				case EntityID.ProjectileID.ADAMANTITE_DRILL:
					width = 22;
					height = 22;
					aiStyle = (byte)EntityID.ProjStyleID.CHAINSAW;
					penetrate = -1;
					tileCollide = false;
					hide = true;
					ownerHitCheck = true;
					melee = true;
					scale = 0.9f;
					break;

				case EntityID.ProjectileID.THE_DAO_OF_POW:
					width = 22;
					height = 22;
					aiStyle = (byte)EntityID.ProjStyleID.FLAIL;
					penetrate = -1;
					melee = true;
					break;

				case EntityID.ProjectileID.MYTHRIL_HALBERD:
					width = 18;
					height = 18;
					aiStyle = (byte)EntityID.ProjStyleID.SPEAR;
					penetrate = -1;
					tileCollide = false;
					scale = 1.25f;
					hide = true;
					ownerHitCheck = true;
					melee = true;
					break;

				case EntityID.ProjectileID.EBONSAND_BALL_GUN:
					knockBack = 6f;
					width = 10;
					height = 10;
					aiStyle = (byte)EntityID.ProjStyleID.DIRT_BALL;
					penetrate = -1;
					maxUpdates = 1;
					break;

				case EntityID.ProjectileID.ADAMANTITE_GLAIVE:
					width = 18;
					height = 18;
					aiStyle = (byte)EntityID.ProjStyleID.SPEAR;
					penetrate = -1;
					tileCollide = false;
					scale = 1.27f;
					hide = true;
					ownerHitCheck = true;
					melee = true;
					break;

				case EntityID.ProjectileID.PEARL_SAND_BALL_FALLING:
					knockBack = 6f;
					width = 10;
					height = 10;
					aiStyle = (byte)EntityID.ProjStyleID.DIRT_BALL;
					hostile = true;
					penetrate = -1;
					break;

				case EntityID.ProjectileID.PEARL_SAND_BALL_GUN:
					knockBack = 6f;
					width = 10;
					height = 10;
					aiStyle = (byte)EntityID.ProjStyleID.DIRT_BALL;
					penetrate = -1;
					maxUpdates = 1;
					break;

				case EntityID.ProjectileID.HOLY_WATER:
					width = 14;
					height = 14;
					aiStyle = (byte)EntityID.ProjStyleID.SHURIKEN;
					penetrate = 1;
					break;

				case EntityID.ProjectileID.UNHOLY_WATER:
					width = 14;
					height = 14;
					aiStyle = (byte)EntityID.ProjStyleID.SHURIKEN;
					penetrate = 1;
					break;

				case EntityID.ProjectileID.SILT_BALL:
					knockBack = 6f;
					width = 10;
					height = 10;
					aiStyle = (byte)EntityID.ProjStyleID.DIRT_BALL;
					hostile = true;
					penetrate = -1;
					break;

				case EntityID.ProjectileID.BLUE_FAIRY:
					width = 18;
					height = 18;
					aiStyle = (byte)EntityID.ProjStyleID.FAIRY;
					light = 0.9f;
					tileCollide = false;
					penetrate = -1;
					timeLeft = 18000;
					ignoreWater = true;
					scale = 0.8f;
					break;

				case EntityID.ProjectileID.DUAL_HOOK_BLUE:
				case EntityID.ProjectileID.DUAL_HOOK_RED:
					width = 18;
					height = 18;
					aiStyle = (byte)EntityID.ProjStyleID.GRAPPLING_HOOK;
					penetrate = -1;
					tileCollide = false;
					timeLeft = 36000;
					light = 0.4f;
					break;

				case EntityID.ProjectileID.HAPPY_BOMB:
					width = 22;
					height = 22;
					aiStyle = (byte)EntityID.ProjStyleID.BOMB;
					hostile = true;
					friendly = false;
					penetrate = -1;
					break;

				case EntityID.ProjectileID.QUARTER_NOTE:
				case EntityID.ProjectileID.EIGHTH_NOTE:
				case EntityID.ProjectileID.TIED_EIGHTH_NOTE:
					if (type == (byte)EntityID.ProjectileID.QUARTER_NOTE)
					{
						width = 10;
						height = 22;
					}
					else if (type == (byte)EntityID.ProjectileID.EIGHTH_NOTE)
					{
						width = 18;
						height = 24;
					}
					else
					{
						width = 22;
						height = 24;
					}

					aiStyle = (byte)EntityID.ProjStyleID.NOTE;
					ranged = true;
					alpha = 100;
					light = 0.3f;
					penetrate = -1;
					timeLeft = 180;
					break;

				case EntityID.ProjectileID.RAINBOW_ROD_BULLET:
					width = 10;
					height = 10;
					aiStyle = (byte)EntityID.ProjStyleID.MAGIC_MISSILE;
					light = 0.8f;
					alpha = 255;
					magic = true;
					break;

				case EntityID.ProjectileID.ICE_BLOCK:
					width = 16;
					height = 16;
					aiStyle = (byte)EntityID.ProjStyleID.ICE_BLOCK;
					magic = true;
					tileCollide = false;
					light = 0.5f;
					break;

				case EntityID.ProjectileID.WOODEN_ARROW_HOSTILE:
					width = 10;
					height = 10;
					aiStyle = (byte)EntityID.ProjStyleID.ARROWS_BULLETS;
					hostile = true;
					friendly = false;
					ranged = true;
					break;

				case EntityID.ProjectileID.FLAMING_ARROW:
					width = 10;
					height = 10;
					aiStyle = (byte)EntityID.ProjStyleID.ARROWS_BULLETS;
					hostile = true;
					friendly = false;
					ranged = true;
					break;

				case EntityID.ProjectileID.EYE_LASER:
					width = 4;
					height = 4;
					aiStyle = (byte)EntityID.ProjStyleID.ARROWS_BULLETS;
					hostile = true;
					friendly = false;
					penetrate = 3;
					light = 0.75f;
					alpha = 255;
					maxUpdates = 2;
					scale = 1.7f;
					timeLeft = 600;
					magic = true;
					break;

				case EntityID.ProjectileID.PINK_LASER:
					width = 4;
					height = 4;
					aiStyle = (byte)EntityID.ProjStyleID.ARROWS_BULLETS;
					hostile = true;
					friendly = false;
					penetrate = 3;
					light = 0.75f;
					alpha = 255;
					maxUpdates = 2;
					scale = 1.2f;
					timeLeft = 600;
					magic = true;
					break;

				case EntityID.ProjectileID.FLAMES:
					width = 6;
					height = 6;
					aiStyle = (byte)EntityID.ProjStyleID.FLAMES;
					alpha = 255;
					penetrate = 3;
					maxUpdates = 2;
					magic = true;
					break;

				case EntityID.ProjectileID.PINK_FAIRY:
					width = 18;
					height = 18;
					aiStyle = (byte)EntityID.ProjStyleID.FAIRY;
					light = 0.9f;
					tileCollide = false;
					penetrate = -1;
					timeLeft = 18000;
					ignoreWater = true;
					scale = 0.8f;
					break;

				case EntityID.ProjectileID.GREEN_FAIRY:
					width = 18;
					height = 18;
					aiStyle = (byte)EntityID.ProjStyleID.FAIRY;
					light = 0.9f;
					tileCollide = false;
					penetrate = -1;
					timeLeft = 18000;
					ignoreWater = true;
					scale = 0.8f;
					break;

				case EntityID.ProjectileID.PURPLE_LASER:
					width = 6;
					height = 6;
					aiStyle = (byte)EntityID.ProjStyleID.ARROWS_BULLETS;
					penetrate = 3;
					light = 0.75f;
					alpha = 255;
					maxUpdates = 4;
					scale = 1.4f;
					timeLeft = 600;
					magic = true;
					break;

				case EntityID.ProjectileID.CRYSTAL_BULLET:
					width = 4;
					height = 4;
					aiStyle = (byte)EntityID.ProjStyleID.ARROWS_BULLETS;
					penetrate = 1;
					light = 0.5f;
					alpha = 255;
					maxUpdates = 1;
					scale = 1.2f;
					timeLeft = 600;
					ranged = true;
					break;

				case EntityID.ProjectileID.CRYSTAL_SHARD:
					width = 6;
					height = 6;
					aiStyle = (byte)EntityID.ProjStyleID.CRYSTAL_SHARD;
					penetrate = 1;
					light = 0.5f;
					alpha = 50;
					scale = 1.2f;
					timeLeft = 600;
					ranged = true;
					tileCollide = false;
					break;

				case EntityID.ProjectileID.HOLY_ARROW:
					width = 10;
					height = 10;
					aiStyle = (byte)EntityID.ProjStyleID.ARROWS_BULLETS;
					ranged = true;
					break;

				case EntityID.ProjectileID.HALLOW_STAR:
					width = 24;
					height = 24;
					aiStyle = (byte)EntityID.ProjStyleID.STARFURY;
					penetrate = 2;
					alpha = 50;
					scale = 0.8f;
					tileCollide = false;
					magic = true;
					break;

				case EntityID.ProjectileID.MAGIC_DAGGER:
					light = 0.15f;
					width = 12;
					height = 12;
					aiStyle = (byte)EntityID.ProjStyleID.SHURIKEN;
					penetrate = 2;
					magic = true;
					break;

				case EntityID.ProjectileID.CRYSTAL_STORM:
					ignoreWater = true;
					width = 8;
					height = 8;
					aiStyle = (byte)EntityID.ProjStyleID.CRYSTAL_SHARD;
					light = 0.5f;
					alpha = 50;
					scale = 1.2f;
					timeLeft = 600;
					magic = true;
					tileCollide = true;
					penetrate = 1;
					fixed (float* ptr2 = oldPos)
					{
						for (int num = 19; num >= 0; num--)
						{
							ptr2[num] = 0f;
						}
					}
					break;

				case EntityID.ProjectileID.CURSED_FLAME_FRIENDLY:
					width = 16;
					height = 16;
					aiStyle = (byte)EntityID.ProjStyleID.BALL_OF_FIRE;
					light = 0.8f;
					alpha = 100;
					magic = true;
					penetrate = 2;
					break;

				case EntityID.ProjectileID.CURSED_FLAME_HOSTILE:
					width = 16;
					height = 16;
					aiStyle = (byte)EntityID.ProjStyleID.BALL_OF_FIRE;
					hostile = true;
					friendly = false;
					light = 0.8f;
					alpha = 100;
					magic = true;
					penetrate = -1;
					scale = 0.9f;
					scale = 1.3f;
					break;

				case EntityID.ProjectileID.COBALT_NAGINATA:
					width = 18;
					height = 18;
					aiStyle = (byte)EntityID.ProjStyleID.SPEAR;
					penetrate = -1;
					tileCollide = false;
					scale = 1.1f;
					hide = true;
					ownerHitCheck = true;
					melee = true;
					break;

				case EntityID.ProjectileID.POISON_DART:
					width = 10;
					height = 10;
					aiStyle = (byte)EntityID.ProjStyleID.ARROWS_BULLETS;
					hostile = true;
					ranged = true;
					penetrate = -1;
					break;

				case EntityID.ProjectileID.BOULDER:
					width = 31;
					height = 31;
					aiStyle = (byte)EntityID.ProjStyleID.BOULDER;
					hostile = true;
					ranged = true;
					penetrate = -1;
					break;

				case EntityID.ProjectileID.DEATH_LASER:
					width = 4;
					height = 4;
					aiStyle = (byte)EntityID.ProjStyleID.ARROWS_BULLETS;
					hostile = true;
					friendly = false;
					penetrate = 3;
					light = 0.75f;
					alpha = 255;
					maxUpdates = 2;
					scale = 1.8f;
					timeLeft = 1200;
					magic = true;
					break;

				case EntityID.ProjectileID.EYE_FIRE:
					width = 6;
					height = 6;
					aiStyle = (byte)EntityID.ProjStyleID.FLAMES;
					hostile = true;
					friendly = false;
					alpha = 255;
					penetrate = -1;
					maxUpdates = 3;
					magic = true;
					break;

				case EntityID.ProjectileID.BOMB_SKELETRON_PRIME:
					width = 22;
					height = 22;
					aiStyle = (byte)EntityID.ProjStyleID.BOMB;
					hostile = true;
					friendly = false;
					penetrate = -1;
					ranged = true;
					break;

				case EntityID.ProjectileID.CURSED_ARROW:
					width = 10;
					height = 10;
					aiStyle = (byte)EntityID.ProjStyleID.ARROWS_BULLETS;
					light = 1f;
					ranged = true;
					break;

				case EntityID.ProjectileID.SPECTRAL_ARROW:
					width = 10;
					height = 10;
					aiStyle = (byte)EntityID.ProjStyleID.ARROWS_BULLETS;
					light = 1f;
					ranged = true;
					break;

				case EntityID.ProjectileID.CURSED_BULLET:
					width = 4;
					height = 4;
					aiStyle = (byte)EntityID.ProjStyleID.ARROWS_BULLETS;
					penetrate = 1;
					light = 0.5f;
					alpha = 255;
					maxUpdates = 1;
					scale = 1.2f;
					timeLeft = 600;
					ranged = true;
					break;

				case EntityID.ProjectileID.GUNGNIR:
					width = 18;
					height = 18;
					aiStyle = (byte)EntityID.ProjStyleID.SPEAR;
					penetrate = -1;
					tileCollide = false;
					scale = 1.3f;
					hide = true;
					ownerHitCheck = true;
					melee = true;
					break;

				case EntityID.ProjectileID.TONBOGIRI:
					width = 18;
					height = 18;
					aiStyle = (byte)EntityID.ProjStyleID.SPEAR;
					penetrate = -1;
					tileCollide = false;
					scale = 1.3f;
					hide = true;
					ownerHitCheck = true;
					melee = true;
					break;

				case EntityID.ProjectileID.LIGHT_DISC:
					width = 32;
					height = 32;
					aiStyle = (byte)EntityID.ProjStyleID.BOOMERANG;
					penetrate = -1;
					melee = true;
					light = 0.4f;
					break;

				case EntityID.ProjectileID.HAMDRAX:
					width = 22;
					height = 22;
					aiStyle = (byte)EntityID.ProjStyleID.CHAINSAW;
					penetrate = -1;
					tileCollide = false;
					hide = true;
					ownerHitCheck = true;
					melee = true;
					scale = 1.1f;
					break;

				case EntityID.ProjectileID.EXPLOSIVES:
					width = 260;
					height = 260;
					aiStyle = (byte)EntityID.ProjStyleID.BOMB;
					hostile = true;
					penetrate = -1;
					tileCollide = false;
					alpha = 255;
					timeLeft = 2;
					break;

				case EntityID.ProjectileID.SNOW_BALL_HOSTILE:
					knockBack = 6f;
					width = 10;
					height = 10;
					aiStyle = (byte)EntityID.ProjStyleID.DIRT_BALL;
					hostile = true;
					friendly = false;
					scale = 0.9f;
					penetrate = -1;
					break;

				case EntityID.ProjectileID.BULLET_SNOWMAN:
					width = 4;
					height = 4;
					aiStyle = (byte)EntityID.ProjStyleID.ARROWS_BULLETS;
					hostile = true;
					friendly = false;
					penetrate = -1;
					light = 0.5f;
					alpha = 255;
					maxUpdates = 1;
					scale = 1.2f;
					timeLeft = 600;
					ranged = true;
					break;

				case EntityID.ProjectileID.PET_BUNNY:
					width = 18;
					height = 18;
					aiStyle = (byte)EntityID.ProjStyleID.PETS;
					penetrate = -1;
					timeLeft = 18000;
					break;

				case EntityID.ProjectileID.PET_SLIME:
					width = 18;
					height = 10;
					aiStyle = (byte)EntityID.ProjStyleID.PETS;
					penetrate = -1;
					timeLeft = 18000;
					localAI0 = 1;
					break;

				case EntityID.ProjectileID.PET_TIPHIA:
					width = 12;
					height = 72;
					scale = 0.5f;
					aiStyle = (byte)EntityID.ProjStyleID.FLYING_PETS;
					penetrate = -1;
					timeLeft = 18000;
					damage = 2;
					localAI0 = 2;
					break;

				case EntityID.ProjectileID.PET_BAT:
					width = 16;
					height = 48;
					aiStyle = (byte)EntityID.ProjStyleID.FLYING_PETS;
					penetrate = -1;
					timeLeft = 18000;
					damage = 4;
					localAI0 = 3;
					break;

				case EntityID.ProjectileID.PET_WEREWOLF:
					width = 18;
					height = 26;
					aiStyle = (byte)EntityID.ProjStyleID.PETS;
					penetrate = -1;
					timeLeft = 18000;
					damage = 10;
					localAI0 = 4;
					break;

				case EntityID.ProjectileID.PET_ZOMBIE:
					width = 18;
					height = 24;
					aiStyle = (byte)EntityID.ProjStyleID.PETS;
					penetrate = -1;
					timeLeft = 18000;
					damage = 8;
					localAI0 = 5;
					break;

				default:
					active = 0;
					break;
			}

			width = (ushort)(width * scale);
			height = (ushort)(height * scale);
			XYWH.Width = width;
			XYWH.Height = height;
		}

		public unsafe static int NewProjectile(float X, float Y, float SpeedX, float SpeedY, int Type, int Damage, float KnockBack, int Owner = 8, bool send = true)
		{
			for (int i = 0; i < MaxNumProjs; i++)
			{
				uint num = lastProjectileIndex++ & (MaxNumProjs - 1);
				fixed (Projectile* ptr = &Main.ProjectileSet[num])
				{
					if (ptr->active != 0)
					{
						continue;
					}
					ptr->SetDefaults(Type);
					ptr->position.X = X - (ptr->width >> 1);
					ptr->position.Y = Y - (ptr->height >> 1);
					ptr->XYWH.X = (int)ptr->position.X;
					ptr->XYWH.Y = (int)ptr->position.Y;
					ptr->owner = (byte)Owner;
					ptr->velocity.X = SpeedX;
					ptr->velocity.Y = SpeedY;
					if (Damage != 0)
					{
						ptr->damage = (short)Damage;
					}
					ptr->knockBack = KnockBack;
					ptr->identity = (ushort)i;
					ptr->wet = Collision.WetCollision(ref ptr->position, ptr->width, ptr->height);
					if (ptr->isLocal())
					{
						switch ((EntityID.ProjectileID)Type)
						{
							case EntityID.ProjectileID.DYNAMITE:
								ptr->timeLeft = 300;
								break;
							case EntityID.ProjectileID.BOMB:
							case EntityID.ProjectileID.GRENADE:
							case EntityID.ProjectileID.STICKY_BOMB:
							case EntityID.ProjectileID.HAPPY_BOMB:
								ptr->timeLeft = 180;
								break;
						}
						if (send)
						{
							NetMessage.SendProjectile((int)num);
						}
					}
					return (int)num;
				}
			}
			return -1;
		}

		public unsafe int NewClonedProjectile(int newType)
		{
			for (int i = 0; i < MaxNumProjs; i++)
			{
				uint num = lastProjectileIndex++ & (Player.MaxNumPlayers - 1);
				fixed (Projectile* ptr = &Main.ProjectileSet[num])
				{
					if (ptr->active != 0)
					{
						continue;
					}
					ptr->SetDefaults(newType);
					ptr->position = position;
					ptr->XYWH.X = (int)position.X;
					ptr->XYWH.Y = (int)position.Y;
					ptr->owner = owner;
					ptr->velocity = velocity;
					ptr->damage = damage;
					ptr->knockBack = knockBack;
					ptr->identity = (ushort)i;
					ptr->wet = wet;
					if (ptr->isLocal())
					{
						switch ((EntityID.ProjectileID)newType)
						{
							case EntityID.ProjectileID.DYNAMITE:
								ptr->timeLeft = 300;
								break;
							case EntityID.ProjectileID.BOMB:
							case EntityID.ProjectileID.GRENADE:
							case EntityID.ProjectileID.STICKY_BOMB:
							case EntityID.ProjectileID.HAPPY_BOMB:
								ptr->timeLeft = 180;
								break;
						}
					}
					return (int)num;
				}
			}
			return -1;
		}

		public unsafe void Damage()
		{
			if (type == (byte)EntityID.ProjectileID.SHADOW_ORB || type == (byte)EntityID.ProjectileID.BLUE_FAIRY || type == (byte)EntityID.ProjectileID.PINK_FAIRY || type == (byte)EntityID.ProjectileID.GREEN_FAIRY || type == (byte)EntityID.ProjectileID.PET_BUNNY || type == (byte)EntityID.ProjectileID.PET_SLIME)
			{
				return;
			}
			Rectangle rectangle = XYWH;
			if (type == (byte)EntityID.ProjectileID.FLAMES || type == (byte)EntityID.ProjectileID.EYE_FIRE)
			{
				rectangle.X -= 30;
				rectangle.Y -= 30;
				rectangle.Width += 60;
				rectangle.Height += 60;
			}
			if (friendly && isLocal())
			{
				if ((aiStyle == (byte)EntityID.ProjStyleID.BOMB || type == (byte)EntityID.ProjectileID.HELLFIRE_ARROW || type == (byte)EntityID.ProjectileID.VULCAN_BOLT) && (timeLeft <= 1 || type == (byte)EntityID.ProjectileID.EXPLOSIVES))
				{
					Player player = Main.PlayerSet[owner];
					if (player.Active != 0 && !player.IsDead && !player.immune && rectangle.Intersects(player.XYWH))
					{
						if (player.XYWH.X + (Player.width / 2) < XYWH.X + (width >> 1))
						{
							direction = -1;
						}
						else
						{
							direction = 1;
						}
						int dmg = Main.DamageVar(damage);
						player.ApplyProjectileBuff(type);
						player.Hurt(dmg, direction, pvp: true, quiet: false, Lang.DeathMsgPtr(owner, 0, type));
						NetMessage.SendPlayerHurt(player.WhoAmI, direction, dmg, pvp: true, critical: false, Lang.DeathMsgPtr(owner, 0, type));
					}
				}
				if (type < (byte)EntityID.ProjectileID.PET_TIPHIA && type != (byte)EntityID.ProjectileID.HOLY_WATER && type != (byte)EntityID.ProjectileID.UNHOLY_WATER && type != (byte)EntityID.ProjectileID.PURIFICATION_POWDER && type != (byte)EntityID.ProjectileID.VILE_POWDER)
				{
					int num = XYWH.X >> 4;
					int num2 = (XYWH.X + width >> 4) + 1;
					int num3 = XYWH.Y >> 4;
					int num4 = (XYWH.Y + height >> 4) + 1;
					if (num < 0)
					{
						num = 0;
					}
					if (num2 > Main.MaxTilesX)
					{
						num2 = Main.MaxTilesX;
					}
					if (num3 < 0)
					{
						num3 = 0;
					}
					if (num4 > Main.MaxTilesY)
					{
						num4 = Main.MaxTilesY;
					}
					for (int i = num; i < num2; i++)
					{
						for (int j = num3; j < num4; j++)
						{
							if (Main.TileCut[Main.TileSet[i, j].Type] && Main.TileSet[i, j + 1].Type != (int)EntityID.TileID.CLAY_POT)
							{
								WorldGen.KillTile(i, j);
								NetMessage.CreateMessage5((int)NetMessageId.MSG_WORLD_CHANGED, 0, i, j, 0);
								NetMessage.SendMessage();
							}
						}
					}
				}
			}
			if (isLocal())
			{
				Player player2 = Main.PlayerSet[owner];
				if (damage > 0)
				{
					for (int k = 0; k < NPC.MaxNumNPCs; k++)
					{
						NPC nPC = Main.NPCSet[k];
						if (nPC.Active == 0 || nPC.DontTakeDamage || ((!friendly || (nPC.IsFriendly && (nPC.Type != (int)EntityID.NPCID.GUIDE || !player2.killGuide))) && (!nPC.IsFriendly || !hostile)) || nPC.Immunities[owner] != 0 || (type == (byte)EntityID.ProjectileID.VILE_POWDER && (nPC.Type == (int)EntityID.NPCID.CORRUPT_BUNNY || nPC.Type == (int)EntityID.NPCID.CORRUPT_GOLDFISH)) || (type == (byte)EntityID.ProjectileID.SAND_BALL_FALLING && nPC.Type == (int)EntityID.NPCID.ANTLION) || (!nPC.HasNoTileCollide && ownerHitCheck && !Collision.CanHit(ref player2.XYWH, ref nPC.XYWH)) || !rectangle.Intersects(nPC.XYWH))
						{
							continue;
						}
						if (aiStyle == (byte)EntityID.ProjStyleID.BOOMERANG)
						{
							if (ai0 == 0f)
							{
								velocity.X = 0f - velocity.X;
								velocity.Y = 0f - velocity.Y;
								netUpdate = true;
							}
							ai0 = 1f;
						}
						else if (aiStyle == (byte)EntityID.ProjStyleID.BOMB)
						{
							if (timeLeft > 3)
							{
								timeLeft = 3;
							}
							if (nPC.XYWH.X + (nPC.Width >> 1) < XYWH.X + (width >> 1))
							{
								direction = -1;
							}
							else
							{
								direction = 1;
							}
						}
						if ((type == (byte)EntityID.ProjectileID.HELLFIRE_ARROW || type == (byte)EntityID.ProjectileID.VULCAN_BOLT) && timeLeft > 1)
						{
							timeLeft = 1;
						}
						bool flag = false;
						if (melee && Main.Rand.Next(1, 101) <= player2.meleeCrit)
						{
							flag = true;
						}
						else if (ranged && Main.Rand.Next(1, 101) <= player2.rangedCrit)
						{
							flag = true;
						}
						else if (magic && Main.Rand.Next(1, 101) <= player2.magicCrit)
						{
							flag = true;
						}
						int dmg2 = Main.DamageVar(damage);
						nPC.ApplyProjectileBuff(type);
						nPC.StrikeNPC(dmg2, knockBack, direction, flag);
						NetMessage.SendNpcHurt(k, dmg2, knockBack, direction, flag);
						if (nPC.Active == 0 && player2.ui != null)
						{
							StatisticEntry statisticEntryFromNetID = Statistics.GetStatisticEntryFromNetID(nPC.NetID);
							player2.ui.Statistics.IncreaseStat(statisticEntryFromNetID);
						}
						if (penetrate != 1)
						{
							nPC.Immunities[owner] = 10;
						}
						if (penetrate > 0 && --penetrate == 0)
						{
							break;
						}
						if (aiStyle == (byte)EntityID.ProjStyleID.GRAPPLING_HOOK)
						{
							ai0 = 1f;
							damage = 0;
							netUpdate = true;
						}
						else if (aiStyle == (byte)EntityID.ProjStyleID.HARPOON)
						{
							ai0 = 1f;
							netUpdate = true;
						}
					}
					if (player2.hostile)
					{
						for (int l = 0; l < Player.MaxNumPlayers; l++)
						{
							if (l == owner || Main.PlayerSet[l].Active == 0 || Main.PlayerSet[l].IsDead || Main.PlayerSet[l].immune || !Main.PlayerSet[l].hostile)
							{
								continue;
							}
							while (true)
							{
								fixed (sbyte* ptr = playerImmune)
								{
									if (ptr[l] <= 0)
									{
										break;
									}
									do
									{
										l++;
										if (l < 8)
										{
											continue;
										}
										if (type == (byte)EntityID.ProjectileID.VILE_POWDER && Main.NetMode != (byte)NetModeSetting.CLIENT)
										{
											for (int m = 0; m < NPC.MaxNumNPCs; m++)
											{
												if (Main.NPCSet[m].Active == 0)
												{
													continue;
												}
												if (Main.NPCSet[m].Type == (int)EntityID.NPCID.BUNNY)
												{
													if (rectangle.Intersects(Main.NPCSet[m].XYWH))
													{
														Main.NPCSet[m].Transform((int)EntityID.NPCID.CORRUPT_BUNNY);
													}
												}
												else if (Main.NPCSet[m].Type == (int)EntityID.NPCID.GOLDFISH && rectangle.Intersects(Main.NPCSet[m].XYWH))
												{
													Main.NPCSet[m].Transform((int)EntityID.NPCID.CORRUPT_GOLDFISH);
												}
											}
										}
										if (!hostile || damage <= 0)
										{
											return;
										}
										for (int n = 0; n < Player.MaxNumPlayers; n++)
										{
											Player player3 = Main.PlayerSet[n];
											if (!player3.isLocal() || player3.Active == 0 || player3.IsDead || player3.immune)
											{
												continue;
											}
											Rectangle value = new Rectangle((int)player3.Position.X, (int)player3.Position.Y, Player.width, Player.height);
											if (rectangle.Intersects(value))
											{
												int num5 = direction;
												num5 = ((player3.XYWH.X + (Player.width / 2) >= XYWH.X + (width >> 1)) ? 1 : (-1));
												int num6 = Main.DamageVar(damage);
												if (!player3.immune)
												{
													player3.ApplyProjectileBuff(type);
												}
												player3.Hurt(num6 * 2, num5, false, false, Lang.DeathMsgPtr(-1, 0, type));
											}
										}
										return;
									}
									while (l == owner || Main.PlayerSet[l].Active == 0 || Main.PlayerSet[l].IsDead || Main.PlayerSet[l].immune || !Main.PlayerSet[l].hostile);
									continue;
								}
							}
							if ((player2.team != 0 && player2.team == Main.PlayerSet[l].team) || (ownerHitCheck && !Collision.CanHit(ref player2.XYWH, ref Main.PlayerSet[l].XYWH)) || !rectangle.Intersects(Main.PlayerSet[l].XYWH))
							{
								continue;
							}
							if (aiStyle == (byte)EntityID.ProjStyleID.BOOMERANG)
							{
								if (ai0 == 0f)
								{
									velocity.X = 0f - velocity.X;
									velocity.Y = 0f - velocity.Y;
									netUpdate = true;
								}
								ai0 = 1f;
							}
							else if (aiStyle == (byte)EntityID.ProjStyleID.BOMB)
							{
								if (timeLeft > 3)
								{
									timeLeft = 3;
								}
								if (Main.PlayerSet[l].XYWH.X + 10 < XYWH.X + (width >> 1))
								{
									direction = -1;
								}
								else
								{
									direction = 1;
								}
							}
							if ((type == (byte)EntityID.ProjectileID.HELLFIRE_ARROW || type == (byte)EntityID.ProjectileID.VULCAN_BOLT) && timeLeft > 1)
							{
								timeLeft = 1;
							}
							bool flag2 = false;
							if (melee && Main.Rand.Next(1, 101) <= player2.meleeCrit)
							{
								flag2 = true;
							}
							int num7 = Main.DamageVar(damage);
							if (!Main.PlayerSet[l].immune)
							{
								Main.PlayerSet[l].ApplyProjectileBuffPvP(type);
							}
							Main.PlayerSet[l].Hurt(num7, direction, pvp: true, quiet: false, Lang.DeathMsgPtr(owner, 0, type), flag2);
							NetMessage.SendPlayerHurt(l, direction, num7, pvp: true, flag2, Lang.DeathMsgPtr(owner, 0, type));
							fixed (sbyte* ptr2 = playerImmune)
							{
								ptr2[l] = 40;
							}
							if (penetrate > 0 && --penetrate == 0)
							{
								break;
							}
							if (aiStyle == (byte)EntityID.ProjStyleID.GRAPPLING_HOOK)
							{
								ai0 = 1f;
								damage = 0;
								netUpdate = true;
							}
							else if (aiStyle == (byte)EntityID.ProjStyleID.HARPOON)
							{
								ai0 = 1f;
								netUpdate = true;
							}
						}
					}
				}
			}
			if (type == (byte)EntityID.ProjectileID.VILE_POWDER && Main.NetMode != (byte)NetModeSetting.CLIENT)
			{
				for (int m = 0; m < NPC.MaxNumNPCs; m++)
				{
					if (Main.NPCSet[m].Active == 0)
					{
						continue;
					}
					if (Main.NPCSet[m].Type == (int)EntityID.NPCID.BUNNY)
					{
						if (rectangle.Intersects(Main.NPCSet[m].XYWH))
						{
							Main.NPCSet[m].Transform((int)EntityID.NPCID.CORRUPT_BUNNY);
						}
					}
					else if (Main.NPCSet[m].Type == (int)EntityID.NPCID.GOLDFISH && rectangle.Intersects(Main.NPCSet[m].XYWH))
					{
						Main.NPCSet[m].Transform((int)EntityID.NPCID.CORRUPT_GOLDFISH);
					}
				}
			}
			if (!hostile || damage <= 0)
			{
				return;
			}
			for (int n = 0; n < Player.MaxNumPlayers; n++)
			{
				Player player3 = Main.PlayerSet[n];
				if (!player3.isLocal() || player3.Active == 0 || player3.IsDead || player3.immune)
				{
					continue;
				}
				Rectangle value = new Rectangle((int)player3.Position.X, (int)player3.Position.Y, Player.width, Player.height);
				if (rectangle.Intersects(value))
				{
					int num5 = direction;
					num5 = ((player3.XYWH.X + (Player.width / 2) >= XYWH.X + (width >> 1)) ? 1 : (-1));
					int num6 = Main.DamageVar(damage);
					if (!player3.immune)
					{
						player3.ApplyProjectileBuff(type);
					}
					player3.Hurt(num6 * 2, num5, pvp: false, quiet: false, Lang.DeathMsgPtr(-1, 0, type));
				}
			}
		}

		public unsafe void Update(int i)
		{
			if (XYWH.X <= 0 || XYWH.X + width >= Main.RightWorld || XYWH.Y <= 0 || XYWH.Y + height >= Main.BottomWorld)
			{
				active = 0;
				return;
			}
			whoAmI = (short)i;
			while (true)
			{
				if (soundDelay > 0)
				{
					soundDelay--;
				}
				netUpdate = false;
				fixed (sbyte* ptr = playerImmune)
				{
					for (int j = 0; j < Player.MaxNumPlayers; j++)
					{
						if (ptr[j] > 0)
						{
							ptr[j]--;
						}
					}
				}
				switch ((EntityID.ProjStyleID)aiStyle)
				{
					case EntityID.ProjStyleID.ARROWS_BULLETS:
						ArrowAI();
						break;
					case EntityID.ProjStyleID.SHURIKEN:
						ShurikenAI();
						break;
					case EntityID.ProjStyleID.BOOMERANG:
						BoomerangAI();
						break;
					case EntityID.ProjStyleID.VILETHORN:
						VilethornAI();
						break;
					case EntityID.ProjStyleID.STARFURY:
						StarfuryAI();
						break;
					case EntityID.ProjStyleID.POWDERS:
						PowderAI();
						break;
					case EntityID.ProjStyleID.GRAPPLING_HOOK:
						GrapplingAI();
						break;
					case EntityID.ProjStyleID.BALL_OF_FIRE:
						BallOfFireAI();
						break;
					case EntityID.ProjStyleID.MAGIC_MISSILE:
						MagicMissileAI();
						break;
					case EntityID.ProjStyleID.DIRT_BALL:
						DirtBallAI();
						break;
					case EntityID.ProjStyleID.SHADOW_ORB:
						OrbOfLightAI();
						break;
					case EntityID.ProjStyleID.WATER_STREAM:
						BlueFlameAI();
						break;
					case EntityID.ProjStyleID.HARPOON:
						HarpoonAI();
						break;
					case EntityID.ProjStyleID.SPIKY_BALL:
						SpikyBallAI();
						break;
					case EntityID.ProjStyleID.FLAIL:
						FlailAI();
						break;
					case EntityID.ProjStyleID.BOMB:
						BombAI();
						break;
					case EntityID.ProjStyleID.TOMBSTONE:
						TombstoneAI();
						break;
					case EntityID.ProjStyleID.DEMON_SICKLE:
						DemonSickleAI();
						break;
					case EntityID.ProjStyleID.SPEAR:
						SpearAI();
						break;
					case EntityID.ProjStyleID.CHAINSAW:
						ChainsawAI();
						break;
					case EntityID.ProjStyleID.NOTE:
						NoteAI();
						break;
					case EntityID.ProjStyleID.ICE_BLOCK:
						IceBlockAI();
						break;
					case EntityID.ProjStyleID.FLAMES:
						FlameAI();
						break;
					case EntityID.ProjStyleID.CRYSTAL_SHARD:
						CrystalShardAI();
						break;
					case EntityID.ProjStyleID.BOULDER:
						BoulderAI();
						break;
					case EntityID.ProjStyleID.PETS:
						PetAI();
						break;
					case EntityID.ProjStyleID.FAIRY:
						FairyAI();
						break;
					case EntityID.ProjStyleID.FLYING_PETS:
						FlyingPetAI();
						break;
				}
				if (owner < Player.MaxNumPlayers && Main.PlayerSet[owner].Active == 0)
				{
					Kill();
				}
				if (!ignoreWater)
				{
					bool flag;
					bool flag2;
					try
					{
						flag = Collision.LavaCollision(ref position, width, height);
						flag2 = Collision.WetCollision(ref position, width, height);
						if (flag)
						{
							lavaWet = true;
						}
					}
					catch
					{
						active = 0;
						return;
					}
					if (wet && !lavaWet)
					{
						if (type == (byte)EntityID.ProjectileID.FLAMES || type == (byte)EntityID.ProjectileID.BALL_OF_FIRE || type == (byte)EntityID.ProjectileID.FLAMELASH)
						{
							Kill();
						}
						else if (type == (byte)EntityID.ProjectileID.FIRE_ARROW || type == (byte)EntityID.ProjectileID.FLAMING_ARROW)
						{
							type--;
							light = 0f;
						}
					}
					if (type == (byte)EntityID.ProjectileID.ICE_BLOCK)
					{
						flag2 = false;
						wet = false;
						if (flag && ai0 >= 0f)
						{
							Kill();
						}
					}
					else if (flag2)
					{
						if (wetCount == 0)
						{
							wetCount = 10;
							if (!wet)
							{
								wet = true;
								Main.PlaySound(19, XYWH.X, XYWH.Y);
								if (!flag)
								{
									for (int k = 0; k < 8; k++)
									{
										Dust* ptr2 = Main.DustSet.NewDust(XYWH.X - 6, XYWH.Y + (height >> 1) - 8, width + 12, 24, 33);
										if (ptr2 == null)
										{
											break;
										}
										ptr2->Velocity.Y -= 4f;
										ptr2->Velocity.X *= 2.5f;
										ptr2->Scale = 1.3f;
										ptr2->Alpha = 100;
										ptr2->NoGravity = true;
									}
								}
								else
								{
									for (int l = 0; l < 8; l++)
									{
										Dust* ptr3 = Main.DustSet.NewDust(XYWH.X - 6, XYWH.Y + (height >> 1) - 8, width + 12, 24, 35);
										if (ptr3 == null)
										{
											break;
										}
										ptr3->Velocity.Y -= 1.5f;
										ptr3->Velocity.X *= 2.5f;
										ptr3->Scale = 1.3f;
										ptr3->Alpha = 100;
										ptr3->NoGravity = true;
									}
								}
							}
						}
					}
					else if (wet)
					{
						wet = false;
						if (wetCount == 0)
						{
							wetCount = 10;
							Main.PlaySound(19, XYWH.X, XYWH.Y);
							if (!lavaWet)
							{
								for (int m = 0; m < 8; m++)
								{
									Dust* ptr4 = Main.DustSet.NewDust(XYWH.X - 6, XYWH.Y + (height >> 1), width + 12, 24, 33);
									if (ptr4 == null)
									{
										break;
									}
									ptr4->Velocity.Y -= 4f;
									ptr4->Velocity.X *= 2.5f;
									ptr4->Scale = 1.3f;
									ptr4->Alpha = 100;
									ptr4->NoGravity = true;
								}
							}
							else
							{
								for (int n = 0; n < 8; n++)
								{
									Dust* ptr5 = Main.DustSet.NewDust(XYWH.X - 6, XYWH.Y + (height >> 1) - 8, width + 12, 24, 35);
									if (ptr5 == null)
									{
										break;
									}
									ptr5->Velocity.Y -= 1.5f;
									ptr5->Velocity.X *= 2.5f;
									ptr5->Scale = 1.3f;
									ptr5->Alpha = 100;
									ptr5->NoGravity = true;
								}
							}
						}
					}
					if (!wet)
					{
						lavaWet = false;
					}
					if (wetCount > 0)
					{
						wetCount--;
					}
				}
				lastPosition = position;
				Vector2 vector = velocity;
				if (tileCollide)
				{
					Vector2 value = velocity;
					bool flag3 = type != (byte)EntityID.ProjectileID.STARFURY && type != (byte)EntityID.ProjectileID.FALLING_STAR && type != (byte)EntityID.ProjectileID.BALL_OF_FIRE && type != (byte)EntityID.ProjectileID.HOOK && type != (byte)EntityID.ProjectileID.SAND_BALL_FALLING && type != (byte)EntityID.ProjectileID.MUD_BALL && type != (byte)EntityID.ProjectileID.ASH_BALL_FALLING && aiStyle != (byte)EntityID.ProjStyleID.PETS;
					if (aiStyle == (byte)EntityID.ProjStyleID.DIRT_BALL)
					{
						if (type == (byte)EntityID.ProjectileID.SAND_BALL_GUN || type == (byte)EntityID.ProjectileID.EBONSAND_BALL_GUN || type == (byte)EntityID.ProjectileID.PEARL_SAND_BALL_GUN || (type == (byte)EntityID.ProjectileID.SAND_BALL_FALLING && ai0 == 2f))
						{
							Collision.TileCollision(ref position, ref velocity, width, height, flag3, flag3);
						}
						else
						{
							Collision.AnyCollision(ref position, ref velocity, width, height);
						}
					}
					else if (aiStyle == (byte)EntityID.ProjStyleID.DEMON_SICKLE)
					{
						int num = width - 36;
						int num2 = height - 36;
						Vector2 Position = new Vector2(position.X + (width >> 1) - (num >> 1), position.Y + (height >> 1) - (num2 >> 1));
						Collision.TileCollision(ref Position, ref velocity, num, num2, flag3, flag3);
					}
					else if (wet)
					{
						Vector2 vector2 = velocity;
						Collision.TileCollision(ref position, ref velocity, width, height, flag3, flag3);
						vector = velocity;
						vector.X *= 0.5f;
						vector.Y *= 0.5f;
						if (velocity.X != vector2.X)
						{
							vector.X = velocity.X;
						}
						if (velocity.Y != vector2.Y)
						{
							vector.Y = velocity.Y;
						}
					}
					else
					{
						Collision.TileCollision(ref position, ref velocity, width, height, flag3, flag3);
					}
					if (value != velocity)
					{
						if (type == (byte)EntityID.ProjectileID.CRYSTAL_STORM)
						{
							if (velocity.X != value.X)
							{
								velocity.X = 0f - value.X;
							}
							if (velocity.Y != value.Y)
							{
								velocity.Y = 0f - value.Y;
							}
						}
						else if (type == (byte)EntityID.ProjectileID.BOULDER)
						{
							if (velocity.Y != value.Y && value.Y > 5f)
							{
								Collision.HitTiles(position, velocity, width, height);
								Main.PlaySound(0, XYWH.X, XYWH.Y);
								velocity.Y = (0f - value.Y) * 0.2f;
							}
							if (velocity.X != value.X)
							{
								Kill();
							}
						}
						else if (type == (byte)EntityID.ProjectileID.METEOR_SHOT)
						{
							if (penetrate > 1)
							{
								Collision.HitTiles(position, velocity, width, height);
								Main.PlaySound(2, XYWH.X, XYWH.Y, 10);
								penetrate--;
								if (velocity.X != value.X)
								{
									velocity.X = 0f - value.X;
								}
								if (velocity.Y != value.Y)
								{
									velocity.Y = 0f - value.Y;
								}
							}
							else
							{
								Kill();
							}
						}
						else if (aiStyle == (byte)EntityID.ProjStyleID.NOTE)
						{
							if (velocity.X != value.X)
							{
								velocity.X = 0f - value.X;
							}
							if (velocity.Y != value.Y)
							{
								velocity.Y = 0f - value.Y;
							}
						}
						else if (aiStyle == (byte)EntityID.ProjStyleID.TOMBSTONE)
						{
							if (velocity.X != value.X)
							{
								velocity.X = value.X * -0.75f;
							}
							if (velocity.Y != value.Y && value.Y > 1.5)
							{
								velocity.Y = value.Y * -0.7f;
							}
						}
						else if (aiStyle == (byte)EntityID.ProjStyleID.FLAIL)
						{
							bool flag4 = false;
							if (value.X != velocity.X)
							{
								if (Math.Abs(value.X) > 4f)
								{
									flag4 = true;
								}
								position.X += velocity.X;
								velocity.X = (0f - value.X) * 0.2f;
							}
							if (value.Y != velocity.Y)
							{
								if (Math.Abs(value.Y) > 4f)
								{
									flag4 = true;
								}
								position.Y += velocity.Y;
								velocity.Y = (0f - value.Y) * 0.2f;
							}
							ai0 = 1f;
							if (flag4)
							{
								netUpdate = true;
								Collision.HitTiles(position, velocity, width, height);
								Main.PlaySound(0, XYWH.X, XYWH.Y);
							}
						}
						else if (aiStyle == (byte)EntityID.ProjStyleID.BOOMERANG || aiStyle == (byte)EntityID.ProjStyleID.HARPOON)
						{
							Collision.HitTiles(position, velocity, width, height);
							if (type == (byte)EntityID.ProjectileID.THORN_CHAKRAM || type == (byte)EntityID.ProjectileID.LIGHT_DISC)
							{
								if (velocity.X != value.X)
								{
									velocity.X = 0f - value.X;
								}
								if (velocity.Y != value.Y)
								{
									velocity.Y = 0f - value.Y;
								}
							}
							else
							{
								ai0 = 1f;
								if (aiStyle == (byte)EntityID.ProjStyleID.BOOMERANG)
								{
									velocity.X = 0f - value.X;
									velocity.Y = 0f - value.Y;
								}
							}
							netUpdate = true;
							Main.PlaySound(0, XYWH.X, XYWH.Y);
						}
						else if (aiStyle == (byte)EntityID.ProjStyleID.BALL_OF_FIRE && type != (byte)EntityID.ProjectileID.CURSED_FLAME_HOSTILE)
						{
							Main.PlaySound(2, XYWH.X, XYWH.Y, 10);
							ai0 += 1f;
							if (ai0 >= 5f)
							{
								position.X += velocity.X;
								position.Y += velocity.Y;
								Kill();
							}
							else
							{
								if (type == (byte)EntityID.ProjectileID.BALL_OF_FIRE && velocity.Y > 4f)
								{
									if (velocity.Y != value.Y)
									{
										velocity.Y = (0f - value.Y) * 0.8f;
									}
								}
								else if (velocity.Y != value.Y)
								{
									velocity.Y = 0f - value.Y;
								}
								if (velocity.X != value.X)
								{
									velocity.X = 0f - value.X;
								}
							}
						}
						else if (aiStyle == (byte)EntityID.ProjStyleID.SPIKY_BALL)
						{
							if (type == (byte)EntityID.ProjectileID.GLOWSTICK)
							{
								if (velocity.X != value.X)
								{
									velocity.X = value.X * -0.2f;
								}
								if (velocity.Y != value.Y && value.Y > 1.5)
								{
									velocity.Y = value.Y * -0.2f;
								}
							}
							else
							{
								if (velocity.X != value.X)
								{
									velocity.X = value.X * -0.5f;
								}
								if (velocity.Y != value.Y && value.Y > 1f)
								{
									velocity.Y = value.Y * -0.5f;
								}
							}
						}
						else if (aiStyle == (byte)EntityID.ProjStyleID.BOMB)
						{
							if (velocity.X != value.X)
							{
								velocity.X = value.X * -0.4f;
								if (type == (byte)EntityID.ProjectileID.DYNAMITE)
								{
									velocity.X *= 0.8f;
								}
							}
							if (velocity.Y != value.Y && value.Y > 0.7 && type != (byte)EntityID.ProjectileID.BOMB_SKELETRON_PRIME)
							{
								velocity.Y = value.Y * -0.4f;
								if (type == (byte)EntityID.ProjectileID.DYNAMITE)
								{
									velocity.Y *= 0.8f;
								}
							}
						}
						else if ((aiStyle != (byte)EntityID.ProjStyleID.MAGIC_MISSILE || isLocal()) && type != (byte)EntityID.ProjectileID.PET_BUNNY && (type < (byte)EntityID.ProjectileID.PET_SLIME || type > (byte)EntityID.ProjectileID.PET_ZOMBIE))
						{
							position.X += velocity.X;
							position.Y += velocity.Y;
							Kill();
						}
					}
				}
				if (type != (byte)EntityID.ProjectileID.VILETHORN_BASE && type != (byte)EntityID.ProjectileID.VILETHORN_TIP)
				{
					if (wet)
					{
						position.X += vector.X;
						position.Y += vector.Y;
					}
					else
					{
						position.X += velocity.X;
						position.Y += velocity.Y;
					}
					XYWH.X = (int)position.X;
					XYWH.Y = (int)position.Y;
				}
				if ((aiStyle != (byte)EntityID.ProjStyleID.BOOMERANG || ai0 != 1f) && (aiStyle != (byte)EntityID.ProjStyleID.GRAPPLING_HOOK || ai0 != 1f) && (aiStyle != (byte)EntityID.ProjStyleID.HARPOON || ai0 != 1f) && (aiStyle != (byte)EntityID.ProjStyleID.FLAIL || ai0 != 1f) && aiStyle != (byte)EntityID.ProjStyleID.FLAIL && aiStyle != (byte)EntityID.ProjStyleID.PETS)
				{
					direction = (sbyte)((!(velocity.X < 0f)) ? 1 : (-1));
				}
				if (active == 0)
				{
					return;
				}
				if (light > 0f)
				{
					float num3 = light;
					float num4 = light;
					float num5 = light;
					switch ((EntityID.ProjectileID)type)
					{
						case EntityID.ProjectileID.FIRE_ARROW:
						case EntityID.ProjectileID.FLAMING_ARROW:
							num4 *= 0.75f;
							num5 *= 0.55f;
							break;

						case EntityID.ProjectileID.CRYSTAL_STORM:
							num3 *= 0.5f;
							num4 = 0f;
							break;

						case EntityID.ProjectileID.CURSED_FLAME_FRIENDLY:
						case EntityID.ProjectileID.CURSED_FLAME_HOSTILE:
						case EntityID.ProjectileID.CURSED_ARROW:
						case EntityID.ProjectileID.CURSED_BULLET:
							num3 *= 0.35f;
							num5 = 0f;
							break;

						case EntityID.ProjectileID.UNHOLY_ARROW:
							num4 *= 0.1f;
							num3 *= 0.5f;
							break;

						case EntityID.ProjectileID.STARFURY:
							num4 *= 0.1f;
							num5 *= 0.6f;
							break;

						case EntityID.ProjectileID.HALLOW_STAR:
							num4 *= 0.6f;
							num3 *= 0.8f;
							break;

						case EntityID.ProjectileID.MAGIC_DAGGER:
							num4 *= 1f;
							num3 *= 1f;
							num5 *= 0.01f;
							break;

						case EntityID.ProjectileID.FALLING_STAR:
							num3 *= 0.9f;
							num4 *= 0.8f;
							num5 *= 0.1f;
							break;

						case EntityID.ProjectileID.BULLET:
						case EntityID.ProjectileID.BULLET_SNOWMAN:
							num4 *= 0.7f;
							num5 *= 0.1f;
							break;

						case EntityID.ProjectileID.BALL_OF_FIRE:
							num4 *= 0.4f;
							num5 *= 0.1f;
							num3 = 1f;
							break;

						case EntityID.ProjectileID.MAGIC_MISSILE:
							num3 *= 0.1f;
							num4 *= 0.4f;
							num5 = 1f;
							break;

						case EntityID.ProjectileID.SPECTRAL_ARROW:
							num3 *= 0.1f;
							num5 = 1f;
							break;

						case EntityID.ProjectileID.SHADOW_ORB:
							num4 *= 0.7f;
							num5 *= 0.3f;
							break;

						case EntityID.ProjectileID.FLAMARANG:
							num4 *= 0.5f;
							num5 *= 0.1f;
							break;

						case EntityID.ProjectileID.GREEN_LASER:
							num3 *= 0.1f;
							num5 *= 0.3f;
							break;

						case EntityID.ProjectileID.WATER_STREAM:
							num3 = 0f;
							num4 = 0f;
							break;

						case EntityID.ProjectileID.WATER_BOLT:
							num3 = 0f;
							num4 *= 0.3f;
							num5 = 1f;
							break;

						case EntityID.ProjectileID.FLAMELASH:
							num4 *= 0.1f;
							num5 *= 0.1f;
							break;

						case EntityID.ProjectileID.METEOR_SHOT:
							num3 = 0.8f;
							num4 *= 0.2f;
							num5 *= 0.6f;
							break;

						case EntityID.ProjectileID.HELLFIRE_ARROW:
							num4 *= 0.8f;
							num5 *= 0.6f;
							break;

						case EntityID.ProjectileID.VULCAN_BOLT:
							num3 = 1f;
							num4 = 1f;
							num5 *= 0.25f;
							break;

						case EntityID.ProjectileID.DEMON_SICKLE:
						case EntityID.ProjectileID.DEMON_SCYTHE:
							num5 = 1f;
							num3 *= 0.6f;
							num4 *= 0.1f;
							break;

						case EntityID.ProjectileID.GLOWSTICK:
							num3 *= 0.7f;
							num5 *= 0.8f;
							break;

						case EntityID.ProjectileID.STICKY_GLOWSTICK:
							num3 *= 0.7f;
							num4 *= 0.8f;
							break;

						case EntityID.ProjectileID.BLUE_FAIRY:
							num3 *= 0.45f;
							num4 *= 0.75f;
							num5 = 1f;
							break;

						case EntityID.ProjectileID.PINK_FAIRY:
							num4 *= 0.45f;
							num5 = 0.75f;
							break;

						case EntityID.ProjectileID.GREEN_FAIRY:
							num3 *= 0.45f;
							num4 = 1f;
							num5 *= 0.75f;
							break;

						case EntityID.ProjectileID.DUAL_HOOK_BLUE:
							num3 *= 0.4f;
							num4 *= 0.6f;
							break;

						case EntityID.ProjectileID.DUAL_HOOK_RED:
							num4 *= 0.4f;
							num5 *= 0.6f;
							break;

						case EntityID.ProjectileID.QUARTER_NOTE:
						case EntityID.ProjectileID.EIGHTH_NOTE:
						case EntityID.ProjectileID.TIED_EIGHTH_NOTE:
							num4 *= 0.3f;
							num5 *= 0.6f;
							break;

						case EntityID.ProjectileID.RAINBOW_ROD_BULLET:
							num3 = Main.DiscoRGB.X;
							num4 = Main.DiscoRGB.Y;
							num5 = Main.DiscoRGB.Z;
							break;

						case EntityID.ProjectileID.ICE_BLOCK:
							num3 = 0f;
							num4 *= 0.8f;
							num5 *= 1f;
							break;

						case EntityID.ProjectileID.EYE_LASER:
						case EntityID.ProjectileID.PURPLE_LASER:
							num3 *= 0.7f;
							num4 = 0f;
							num5 *= 1f;
							break;

						case EntityID.ProjectileID.DEATH_LASER:
							num4 *= 0.5f;
							num5 = 0f;
							break;

						case EntityID.ProjectileID.PINK_LASER:
							num3 *= 0.8f;
							num4 = 0f;
							num5 *= 0.5f;
							break;

						case EntityID.ProjectileID.CRYSTAL_BULLET:
						case EntityID.ProjectileID.CRYSTAL_SHARD:
							num4 *= 0.2f;
							num3 *= 0.05f;
							break;

						case EntityID.ProjectileID.LIGHT_DISC:
							num3 = 0f;
							num4 *= 0.5f;
							break;

					}
					Lighting.AddLight(XYWH.X + (width >> 1) >> 4, XYWH.Y + (height >> 1) >> 4, new Vector3(num3, num4, num5));
				}
				if ((Main.FrameCounter & 1) == 1)
				{
					if (type == (byte)EntityID.ProjectileID.FIRE_ARROW || type == (byte)EntityID.ProjectileID.FLAMING_ARROW)
					{
						Main.DustSet.NewDust(6, ref XYWH, 0.0, 0.0, 100);
					}
					else if (type == (byte)EntityID.ProjectileID.CURSED_ARROW)
					{
						Dust* ptr6 = Main.DustSet.NewDust(75, ref XYWH, 0.0, 0.0, 100);
						if (Main.Rand.Next(2) == 0 && ptr6 != null)
						{
							ptr6->NoGravity = true;
							ptr6->Scale *= 2f;
						}
					}
					else if (type == (byte)EntityID.ProjectileID.UNHOLY_ARROW)
					{
						if (Main.Rand.Next(3) == 0)
						{
							Main.DustSet.NewDust(14, ref XYWH, 0.0, 0.0, 150, default, 1.1f);
						}
					}
					else if (type == (byte)EntityID.ProjectileID.JESTERS_ARROW)
					{
						int num6 = Main.Rand.Next(3);
						num6 = ((num6 != 0) ? (num6 + 56) : 15);
						Main.DustSet.NewDust(num6, ref XYWH, velocity.X * 0.5f, velocity.Y * 0.5f, 150, default, 1.2f);
					}
				}
				Damage();
				if (type == (byte)EntityID.ProjectileID.BOULDER)
				{
					if (Main.NetMode != (byte)NetModeSetting.CLIENT)
					{
						Collision.SwitchTiles(position, width, height, lastPosition);
					}
				}
				else if (type == (byte)EntityID.ProjectileID.CRYSTAL_STORM)
				{
					fixed (float* ptr7 = oldPos)
					{
						Vector2* ptr8 = (Vector2*)ptr7;
						for (int num7 = 9; num7 > 0; num7--)
						{
							ptr8[num7] = ptr8[num7 - 1];
						}
						*ptr8 = position;
					}
				}
				if (--timeLeft <= 0)
				{
					Kill();
					break;
				}
				if (penetrate == 0)
				{
					Kill();
					break;
				}
				if (active == 0)
				{
					break;
				}
				if (isLocal() && netUpdate)
				{
					NetMessage.SendProjectile(i, SendDataOptions.InOrder);
				}
				if (maxUpdates <= 0)
				{
					break;
				}
				if (--numUpdates < 0)
				{
					numUpdates = (sbyte)maxUpdates;
					break;
				}
			}
			netUpdate = false;
		}

		private unsafe void PetAI()
		{
			Player player = Main.PlayerSet[owner];
			if (isLocal())
			{
				if (player.IsDead)
				{
					player.pet = -1;
				}
				else if (player.pet >= 0)
				{
					timeLeft = 2;
				}
			}
			if (player.rocketDelay2 > 0)
			{
				ai0 = 1f;
			}
			Vector2 vector = new Vector2(position.X + width * 0.5f, position.Y + height * 0.5f);
			float num = player.Position.X + (Player.width / 2) - vector.X;
			float num2 = player.Position.Y + (Player.height / 2) - vector.Y;
			float num3 = (float)Math.Sqrt(num * num + num2 * num2);
			if (num3 > 2000f)
			{
				position.X = player.Position.X + (Player.width / 2) - (width >> 1);
				position.Y = player.Position.Y + (Player.height / 2) - (height >> 1);
				XYWH.X = (int)position.X;
				XYWH.Y = (int)position.Y;
			}
			else if (num3 > 500f || Math.Abs(num2) > 300f)
			{
				ai0 = 1f;
				if (num2 > 0f && velocity.Y < 0f)
				{
					velocity.Y = 0f;
				}
				if (num2 < 0f && velocity.Y > 0f)
				{
					velocity.Y = 0f;
				}
			}
			if (ai0 != 0f)
			{
				tileCollide = false;
				Vector2 vector2 = new Vector2(position.X + width * 0.5f, position.Y + height * 0.5f);
				float num4 = player.Position.X + (Player.width / 2) - vector2.X;
				float num5 = player.Position.Y + (Player.height / 2) - vector2.Y;
				float num6 = (float)Math.Sqrt(num4 * num4 + num5 * num5);
				float num7 = 10f;
				if (num6 < 200f && player.velocity.Y == 0f && position.Y + height <= player.Position.Y + 42f)
				{
					Vector2 Velocity = velocity;
					Collision.TileCollision(ref position, ref Velocity, width, height);
					tileCollide = velocity.X != Velocity.X || velocity.Y != Velocity.Y;
					if (!tileCollide)
					{
						ai0 = 0f;
						if (velocity.Y < -6f)
						{
							velocity.Y = -6f;
						}
					}
				}
				if (num6 < 60f)
				{
					num4 = velocity.X;
					num5 = velocity.Y;
				}
				else
				{
					num6 = num7 / num6;
					num4 *= num6;
					num5 *= num6;
				}
				if (velocity.X < num4)
				{
					velocity.X += 0.2f;
					if (velocity.X < 0f)
					{
						velocity.X += 0.3f;
					}
				}
				if (velocity.X > num4)
				{
					velocity.X -= 0.2f;
					if (velocity.X > 0f)
					{
						velocity.X -= 0.3f;
					}
				}
				if (velocity.Y < num5)
				{
					velocity.Y += 0.2f;
					if (velocity.Y < 0f)
					{
						velocity.Y += 0.3f;
					}
				}
				if (velocity.Y > num5)
				{
					velocity.Y -= 0.2f;
					if (velocity.Y > 0f)
					{
						velocity.Y -= 0.3f;
					}
				}
				petAnimFly[localAI0].Update(ref this);
				if (velocity.X > 0.5)
				{
					spriteDirection = -1;
				}
				else if (velocity.X < -0.5)
				{
					spriteDirection = 1;
				}
				if (type < (byte)EntityID.ProjectileID.PET_TIPHIA)
				{
					if (spriteDirection == -1)
					{
						rotation = (float)Math.Atan2(velocity.Y, velocity.X);
					}
					else
					{
						rotation = (float)(Math.Atan2(velocity.Y, velocity.X) + Math.PI);
					}
				}
				if ((Main.FrameCounter & 1) == 1)
				{
					Dust* ptr = Main.DustSet.NewDust((int)(position.X - velocity.X) + (width >> 1) - 4, (int)(position.Y - velocity.Y) + (height >> 1) - 4, 8, 8, 16, velocity.X * -0.5f, velocity.Y * 0.5f, 50, default, 1.7f);
					if (ptr != null)
					{
						ptr->Velocity *= 0.2f;
						ptr->NoGravity = true;
					}
				}
				return;
			}
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			rotation = 0f;
			tileCollide = true;
			if (player.XYWH.X + (Player.width / 2) < XYWH.X + (width >> 1) - 60)
			{
				if (velocity.X > -3.5)
				{
					velocity.X -= 0.08f;
				}
				else
				{
					velocity.X -= 0.02f;
				}
				flag = true;
			}
			else if (player.Position.X + (Player.width / 2) > position.X + (width >> 1) + 60f)
			{
				if (velocity.X < 3.5)
				{
					velocity.X += 0.08f;
				}
				else
				{
					velocity.X += 0.02f;
				}
				flag2 = true;
			}
			else
			{
				velocity.X *= 0.9f;
				if (velocity.X >= -0.08 && velocity.X <= 0.08)
				{
					velocity.X = 0f;
				}
			}
			if (flag || flag2)
			{
				int num8 = XYWH.X + (width >> 1) >> 4;
				int j = XYWH.Y + (height >> 1) >> 4;
				num8 = ((!flag) ? (num8 + 1) : (num8 - 1));
				num8 += (int)velocity.X;
				if (WorldGen.CanStandOnTop(num8, j))
				{
					flag4 = true;
				}
			}
			if (player.Position.Y + Player.height > position.Y + height)
			{
				flag3 = true;
			}
			if (velocity.Y == 0f)
			{
				if (!flag3 && (velocity.X < 0f || velocity.X > 0f))
				{
					int num9 = XYWH.X + (width >> 1) >> 4;
					int j2 = (XYWH.Y + (height >> 1) >> 4) + 1;
					if (flag)
					{
						num9--;
					}
					if (flag2)
					{
						num9++;
					}
					if (!WorldGen.CanStandOnTop(num9, j2))
					{
						flag4 = true;
					}
				}
				if (flag4)
				{
					int i = XYWH.X + (width >> 1) >> 4;
					int j3 = (XYWH.Y + (height >> 1) >> 4) + 1;
					if (WorldGen.CanStandOnTop(i, j3))
					{
						velocity.Y = -9.1f;
					}
				}
			}
			if (velocity.X > 6.5f)
			{
				velocity.X = 6.5f;
			}
			else if (velocity.X < -6.5f)
			{
				velocity.X = -6.5f;
			}
			if (velocity.X > 0.07 && flag2)
			{
				direction = 1;
			}
			else if (velocity.X < -0.07 && flag)
			{
				direction = -1;
			}
			spriteDirection = (sbyte)(-direction);
			if (velocity.Y == 0f)
			{
				if ((double)Math.Abs(velocity.X) < 0.8)
				{
					petAnimIdle[localAI0].Update(ref this);
				}
				else
				{
					petAnimMove[localAI0].Update(ref this);
				}
			}
			else if (velocity.Y < 0f)
			{
				petAnimFall[localAI0].Update(ref this);
			}
			else if (velocity.Y > 0f)
			{
				petAnimJump[localAI0].Update(ref this);
			}
			velocity.Y += 0.4f;
			if (velocity.Y > 10f)
			{
				velocity.Y = 10f;
			}
		}

		private void FlyingPetAI()
		{
			Player player = Main.PlayerSet[owner];
			if (isLocal())
			{
				if (player.IsDead)
				{
					player.pet = -1;
				}
				else if (player.pet >= 0)
				{
					timeLeft = 2;
				}
			}
			tileCollide = false;
			Vector2 vector = new Vector2(position.X + width * 0.5f, position.Y + height * 0.5f);
			float num = player.Position.X + (Player.width / 2) - vector.X;
			float num2 = player.Position.Y + (Player.height / 2) - vector.Y;
			float num3 = (float)Math.Sqrt(num * num + num2 * num2);
			float num4 = 10f;
			if (num3 < 200f && player.velocity.Y == 0f && position.Y + height <= player.Position.Y + Player.height)
			{
				Vector2 Velocity = velocity;
				Collision.TileCollision(ref position, ref Velocity, width, height);
				tileCollide = velocity.X != Velocity.X || velocity.Y != Velocity.Y;
				if (!tileCollide)
				{
					ai0 = 0f;
					if (velocity.Y < -6f)
					{
						velocity.Y = -6f;
					}
				}
			}
			if (num3 < 60f)
			{
				num = velocity.X;
				num2 = velocity.Y;
			}
			else
			{
				num3 = num4 / num3;
				num *= num3;
				num2 *= num3;
			}
			if (velocity.X < num)
			{
				velocity.X += 0.2f;
				if (velocity.X < 0f)
				{
					velocity.X += 0.3f;
				}
			}
			if (velocity.X > num)
			{
				velocity.X -= 0.2f;
				if (velocity.X > 0f)
				{
					velocity.X -= 0.3f;
				}
			}
			if (velocity.Y < num2)
			{
				velocity.Y += 0.2f;
				if (velocity.Y < 0f)
				{
					velocity.Y += 0.3f;
				}
			}
			if (velocity.Y > num2)
			{
				velocity.Y -= 0.2f;
				if (velocity.Y > 0f)
				{
					velocity.Y -= 0.3f;
				}
			}
			petAnimFly[localAI0].Update(ref this);
			if (velocity.X > 0.5)
			{
				spriteDirection = -1;
			}
			else if (velocity.X < -0.5)
			{
				spriteDirection = 1;
			}
		}

		private unsafe void ArrowAI()
		{
			if (ai1 == 0)
			{
				ai1 = 1;
				if (type == (byte)EntityID.ProjectileID.EYE_LASER || type == (byte)EntityID.ProjectileID.DEATH_LASER)
				{
					Main.PlaySound(2, XYWH.X, XYWH.Y, 33);
				}
				else if (type == (byte)EntityID.ProjectileID.BULLET_SNOWMAN)
				{
					Main.PlaySound(2, XYWH.X, XYWH.Y, 11);
				}
				else if (type == (byte)EntityID.ProjectileID.PINK_LASER)
				{
					Main.PlaySound(2, XYWH.X, XYWH.Y, 12);
				}
				else if (type == (byte)EntityID.ProjectileID.POISON_DART)
				{
					Main.PlaySound(2, XYWH.X, XYWH.Y, 17);
				}
				else if (type == (byte)EntityID.ProjectileID.WOODEN_ARROW_HOSTILE || type == (byte)EntityID.ProjectileID.FLAMING_ARROW)
				{
					Main.PlaySound(2, XYWH.X, XYWH.Y, 5);
				}
			}
			switch ((EntityID.ProjectileID)type)
			{
				case EntityID.ProjectileID.HELLFIRE_ARROW:
					Dust* ptr = Main.DustSet.NewDust(31, ref XYWH, 0.0, 0.0, 100, default, 1.6f);
					if (ptr != null)
					{
						ptr->NoGravity = true;
						ptr = Main.DustSet.NewDust(6, ref XYWH, 0.0, 0.0, 100, default, 2.0);
						if (ptr != null)
						{
							ptr->NoGravity = true;
						}
					}
					break;
				case EntityID.ProjectileID.VULCAN_BOLT:
					Dust* ptr2 = Main.DustSet.NewDust(31, ref XYWH, 0.0, 0.0, 100, default, 1.6f);
					if (ptr2 != null)
					{
						ptr2->NoGravity = true;
						ptr2 = Main.DustSet.NewDust(64, ref XYWH, 0.0, 0.0, 100, default, 2.0);
						if (ptr2 != null)
						{
							ptr2->NoGravity = true;
						}
					}
					break;
				case EntityID.ProjectileID.STINGER:
					Dust* ptr3 = Main.DustSet.NewDust(18, ref XYWH, 0.0, 0.0, 0, default, 0.9f);
					if (ptr3 != null)
					{
						ptr3->NoGravity = true;
					}
					break;
				case EntityID.ProjectileID.HOLY_ARROW:
					if (Main.Rand.Next(3) == 0)
					{
						int num = ((Main.Rand.Next(2) != 0) ? 58 : 15);
						Dust* ptr4 = Main.DustSet.NewDust(num, ref XYWH, velocity.X * 0.25f, velocity.Y * 0.25f, 150, default, 0.9f);
						if (ptr4 != null)
						{
							ptr4->Velocity.X *= 0.25f;
							ptr4->Velocity.Y *= 0.25f;
						}
					}
					break;
				case EntityID.ProjectileID.PURPLE_LASER:
					if (alpha > 10)
					{
						alpha -= 10;
					}
					else
					{
						alpha = 0;
					}
					break;
				case EntityID.ProjectileID.GREEN_LASER:
				case EntityID.ProjectileID.BULLET:
				case EntityID.ProjectileID.METEOR_SHOT:
				case EntityID.ProjectileID.EYE_LASER:
				case EntityID.ProjectileID.PINK_LASER:
				case EntityID.ProjectileID.CRYSTAL_BULLET:
				case EntityID.ProjectileID.DEATH_LASER:
				case EntityID.ProjectileID.CURSED_BULLET:
				case EntityID.ProjectileID.BULLET_SNOWMAN:
					if (alpha > 15)
					{
						alpha -= 15;
					}
					else
					{
						alpha = 0;
					}
					break;
			}
			rotation = (float)(Math.Atan2(velocity.Y, velocity.X) + 1.57);
			if (type != (byte)EntityID.ProjectileID.JESTERS_ARROW && type != (byte)EntityID.ProjectileID.BULLET && type != (byte)EntityID.ProjectileID.GREEN_LASER && type != (byte)EntityID.ProjectileID.METEOR_SHOT && type != (byte)EntityID.ProjectileID.HARPY_FEATHER && type != (byte)EntityID.ProjectileID.STINGER && type != (byte)EntityID.ProjectileID.EYE_LASER && type != (byte)EntityID.ProjectileID.PINK_LASER && type != (byte)EntityID.ProjectileID.PURPLE_LASER && type != (byte)EntityID.ProjectileID.CRYSTAL_BULLET && type != (byte)EntityID.ProjectileID.POISON_DART && type != (byte)EntityID.ProjectileID.DEATH_LASER && type != (byte)EntityID.ProjectileID.CURSED_BULLET && type != (byte)EntityID.ProjectileID.BULLET_SNOWMAN)
			{
				if ((ai0 += 1f) == 9f)
				{
					if (type == (byte)EntityID.ProjectileID.VULCAN_BOLT && isLocal() && Main.Rand.Next(4) == 0)
					{
						int num2 = NewClonedProjectile((int)EntityID.ProjectileID.VULCAN_BOLT);
						if (num2 >= 0)
						{
							double num3 = velocity.Length();
							double num4 = rotation - Main.Rand.Next(10, 28) * (Math.PI / 180.0);
							double num5 = rotation + Main.Rand.Next(10, 28) * (Math.PI / 180.0);
							double num6 = 0.0 - Math.Cos(num4);
							double num7 = Math.Sin(num4);
							double num8 = num3 * num7;
							double num9 = num3 * num6;
							Main.ProjectileSet[num2].velocity.X = (float)num8;
							Main.ProjectileSet[num2].velocity.Y = (float)num9;
							Main.ProjectileSet[num2].ai0 = 9f;
							Main.ProjectileSet[num2].ai1 = 1;
							num6 = 0.0 - Math.Cos(num5);
							num7 = Math.Sin(num5);
							num8 = num3 * num7;
							num9 = num3 * num6;
							velocity.X = (float)num8;
							velocity.Y = (float)num9;
							NetMessage.SendProjectile(num2);
						}
					}
				}
				else if (ai0 >= 15f)
				{
					if (type == (byte)EntityID.ProjectileID.WOODEN_ARROW_HOSTILE || type == (byte)EntityID.ProjectileID.HOLY_ARROW)
					{
						if (ai0 >= 20f)
						{
							velocity.Y += 0.07f;
						}
					}
					else
					{
						velocity.Y += 0.1f;
					}
				}
			}
			if (velocity.Y > 16f)
			{
				velocity.Y = 16f;
			}
		}

		private unsafe void BoomerangAI()
		{
			if (soundDelay == 0)
			{
				soundDelay = 8;
				Main.PlaySound(2, XYWH.X, XYWH.Y, 7);
			}
			if (type == (byte)EntityID.ProjectileID.FLAMARANG)
			{
				for (int i = 0; i < 2; i++)
				{
					Dust* ptr = Main.DustSet.NewDust(6, ref XYWH, velocity.X * 0.2f, velocity.Y * 0.2f, 100, default, 2.0);
					if (ptr == null)
					{
						break;
					}
					ptr->NoGravity = true;
					ptr->Velocity.X *= 0.3f;
					ptr->Velocity.Y *= 0.3f;
				}
			}
			else if (type == (byte)EntityID.ProjectileID.THORN_CHAKRAM)
			{
				if (Main.Rand.Next(2) == 0)
				{
					Dust* ptr2 = Main.DustSet.NewDust(40, ref XYWH, velocity.X * 0.25f, velocity.Y * 0.25f, 0, default, 1.4f);
					if (ptr2 != null)
					{
						ptr2->NoGravity = true;
					}
				}
			}
			else if (type == (byte)EntityID.ProjectileID.ENCHANTED_BOOMERANG && Main.Rand.Next(6) == 0)
			{
				int num;
				switch (Main.Rand.Next(3))
				{
					case 0:
						num = 15;
						break;
					case 1:
						num = 57;
						break;
					default:
						num = 58;
						break;
				}
				Main.DustSet.NewDust(num, ref XYWH, velocity.X * 0.25f, velocity.Y * 0.25f, 150, default, 0.7f);
			}
			if (ai0 == 0f)
			{
				ai1++;
				if (type == (byte)EntityID.ProjectileID.LIGHT_DISC)
				{
					if (ai1 >= 45)
					{
						ai0 = 1f;
						ai1 = 0;
						netUpdate = true;
					}
				}
				else if (ai1 >= 30)
				{
					ai0 = 1f;
					ai1 = 0;
					netUpdate = true;
				}
			}
			else
			{
				tileCollide = false;
				float num2 = 9f;
				float num3 = 0.4f;
				if (type == (byte)EntityID.ProjectileID.FLAMARANG)
				{
					num2 = 13f;
					num3 = 0.6f;
				}
				else if (type == (byte)EntityID.ProjectileID.THORN_CHAKRAM)
				{
					num2 = 15f;
					num3 = 0.8f;
				}
				else if (type == (byte)EntityID.ProjectileID.LIGHT_DISC)
				{
					num2 = 16f;
					num3 = 1.2f;
				}
				Vector2 vector = new Vector2(position.X + (width >> 1), position.Y + (height >> 1));
				float num4 = Main.PlayerSet[owner].Position.X + (Player.width / 2) - vector.X;
				float num5 = Main.PlayerSet[owner].Position.Y + (Player.height / 2) - vector.Y;
				float num6 = (float)Math.Sqrt(num4 * num4 + num5 * num5);
				if (num6 > 3000f)
				{
					Kill();
				}
				num6 = num2 / num6;
				num4 *= num6;
				num5 *= num6;
				if (velocity.X < num4)
				{
					velocity.X += num3;
					if (velocity.X < 0f && num4 > 0f)
					{
						velocity.X += num3;
					}
				}
				else if (velocity.X > num4)
				{
					velocity.X -= num3;
					if (velocity.X > 0f && num4 < 0f)
					{
						velocity.X -= num3;
					}
				}
				if (velocity.Y < num5)
				{
					velocity.Y += num3;
					if (velocity.Y < 0f && num5 > 0f)
					{
						velocity.Y += num3;
					}
				}
				else if (velocity.Y > num5)
				{
					velocity.Y -= num3;
					if (velocity.Y > 0f && num5 < 0f)
					{
						velocity.Y -= num3;
					}
				}
				if (isLocal() && new Rectangle(XYWH.X, XYWH.Y, width, height).Intersects(Main.PlayerSet[owner].XYWH))
				{
					Kill();
				}
			}
			if (type == (byte)EntityID.ProjectileID.LIGHT_DISC)
			{
				rotation += 0.3f * direction;
			}
			else
			{
				rotation += 0.4f * direction;
			}
		}

		private unsafe void ShurikenAI()
		{
			if (type == (byte)EntityID.ProjectileID.MAGIC_DAGGER && Main.Rand.Next(5) == 0)
			{
				Dust* ptr = Main.DustSet.NewDust(57, ref XYWH, velocity.X * 0.2f + direction * 3, velocity.Y * 0.2f, 100, default, 0.3f);
				if (ptr != null)
				{
					ptr->Velocity *= 0.3f;
				}
			}
			rotation += (Math.Abs(velocity.X) + Math.Abs(velocity.Y)) * 0.03f * direction;
			ai0 += 1f;
			if (type == (byte)EntityID.ProjectileID.HOLY_WATER || type == (byte)EntityID.ProjectileID.UNHOLY_WATER)
			{
				if (ai0 >= 10f)
				{
					velocity.Y += 0.25f;
					velocity.X *= 0.99f;
				}
			}
			else if (ai0 >= 20f)
			{
				velocity.Y += 0.4f;
				velocity.X *= 0.97f;
			}
			else if (type == (byte)EntityID.ProjectileID.THROWING_KNIFE || type == (byte)EntityID.ProjectileID.POISONED_KNIFE || type == (byte)EntityID.ProjectileID.MAGIC_DAGGER)
			{
				rotation = (float)Math.Atan2(velocity.Y, velocity.X) + 1.57f;
			}
			if (velocity.Y > 16f)
			{
				velocity.Y = 16f;
			}
			if (type == (byte)EntityID.ProjectileID.POISONED_KNIFE && Main.Rand.Next(20) == 0)
			{
				Main.DustSet.NewDust(40, ref XYWH, velocity.X * 0.1f, velocity.Y * 0.1f, 0, default, 0.75);
			}
		}

		private unsafe void VilethornAI()
		{
			rotation = (float)Math.Atan2(velocity.Y, velocity.X) + 1.57f;
			if (ai0 == 0f)
			{
				alpha -= 50;
				if (alpha > 0)
				{
					return;
				}
				alpha = 0;
				ai0 = 1f;
				if (ai1 == 0)
				{
					ai1 = 1;
					position.X += velocity.X;
					position.Y += velocity.Y;
					XYWH.X = (int)position.X;
					XYWH.Y = (int)position.Y;
				}
				if (type == (byte)EntityID.ProjectileID.VILETHORN_BASE && isLocal())
				{
					int num = NewClonedProjectile((ai1 >= 6) ? (int)EntityID.ProjectileID.VILETHORN_TIP : (int)EntityID.ProjectileID.VILETHORN_BASE);
					if (num >= 0)
					{
						Main.ProjectileSet[num].position.X += velocity.X;
						Main.ProjectileSet[num].position.Y += velocity.Y;
						Main.ProjectileSet[num].XYWH.X = (int)Main.ProjectileSet[num].position.X;
						Main.ProjectileSet[num].XYWH.Y = (int)Main.ProjectileSet[num].position.Y;
						Main.ProjectileSet[num].ai1 = ai1 + 1;
						NetMessage.SendProjectile(num);
					}
				}
				return;
			}
			alpha += 5;
			if (alpha >= 170 && alpha < 175)
			{
				for (int i = 0; i < 2; i++)
				{
					Main.DustSet.NewDust(18, ref XYWH, velocity.X * 0.025f, velocity.Y * 0.025f, 170, default, 1.2);
				}
				Main.DustSet.NewDust(14, ref XYWH, 0.0, 0.0, 170, default, 1.1);
			}
			else if (alpha >= 255)
			{
				Kill();
			}
		}

		private unsafe void StarfuryAI()
		{
			if (type == (byte)EntityID.ProjectileID.HALLOW_STAR)
			{
				if (XYWH.Y > ai1)
				{
					tileCollide = true;
				}
			}
			else
			{
				if (ai1 == 0 && !Collision.SolidCollision(ref position, width, height))
				{
					ai1 = 1;
					netUpdate = true;
				}
				if (ai1 != 0)
				{
					tileCollide = true;
				}
			}
			if (soundDelay == 0)
			{
				soundDelay = (short)(20 + Main.Rand.Next(40));
				Main.PlaySound(2, XYWH.X, XYWH.Y, 9);
			}
			if (localAI0 == 0)
			{
				localAI0 = 1;
			}
			int num = alpha + 25 * localAI0;
			if (num > 200)
			{
				alpha = 200;
				localAI0 = -1;
			}
			else if (num < 0)
			{
				alpha = 0;
				localAI0 = 1;
			}
			else
			{
				alpha = (byte)num;
			}
			rotation += (Math.Abs(velocity.X) + Math.Abs(velocity.Y)) * 0.01f * direction;
			if (ai1 == 1 || type == (byte)EntityID.ProjectileID.HALLOW_STAR)
			{
				light = 0.9f;
				if (Main.Rand.Next(12) == 0)
				{
					Main.DustSet.NewDust(58, ref XYWH, velocity.X * 0.5f, velocity.Y * 0.5f, 150, default, 1.2);
				}
				if (Main.Rand.Next(24) == 0)
				{
					Gore.NewGore(position, new Vector2(velocity.X * 0.2f, velocity.Y * 0.2f), Main.Rand.Next((int)EntityID.GoreID.FALLEN_STAR_PARTICLE1, (int)EntityID.GoreID.FALLEN_STAR_PARTICLE2 + 1));
				}
			}
		}

		private unsafe void PowderAI()
		{
			velocity.X *= 0.95f;
			velocity.Y *= 0.95f;
			ai0 += 1f;
			if (ai0 == 180f)
			{
				Kill();
			}
			if (ai1 == 0)
			{
				ai1 = 1;
				for (int i = 0; i < 24; i++)
				{
					Main.DustSet.NewDust((byte)EntityID.ProjectileID.PURIFICATION_POWDER + type, ref XYWH, velocity.X, velocity.Y, 50);
				}
			}
			if (!isLocal())
			{
				return;
			}
			int num = (XYWH.X >> 4) - 1;
			int num2 = (XYWH.X + width >> 4) + 2;
			int num3 = (XYWH.Y >> 4) - 1;
			int num4 = (XYWH.Y + height >> 4) + 2;
			if (num < 0)
			{
				num = 0;
			}
			if (num2 > Main.MaxTilesX)
			{
				num2 = Main.MaxTilesX;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num4 > Main.MaxTilesY)
			{
				num4 = Main.MaxTilesY;
			}
			Vector2 vector = default;
			for (int j = num; j < num2; j++)
			{
				for (int k = num3; k < num4; k++)
				{
					vector.X = j * 16;
					vector.Y = k * 16;
					if (!(position.X + width > vector.X) || !(position.X < vector.X + 16f) || !(position.Y + height > vector.Y) || !(position.Y < vector.Y + 16f) || Main.TileSet[j, k].IsActive == 0)
					{
						continue;
					}
					int num5 = Main.TileSet[j, k].Type;
					if (type == (byte)EntityID.ProjectileID.PURIFICATION_POWDER)
					{
						switch ((EntityID.TileID)num5)
						{
							case EntityID.TileID.CORRUPT_GRASS:
								Main.TileSet[j, k].Type = (byte)EntityID.TileID.GRASS;
								WorldGen.SquareTileFrame(j, k);
								NetMessage.SendTile(j, k);
								break;
							case EntityID.TileID.EBONSTONE:
								Main.TileSet[j, k].Type = (byte)EntityID.TileID.STONE;
								WorldGen.SquareTileFrame(j, k);
								NetMessage.SendTile(j, k);
								break;
							case EntityID.TileID.EBONSAND:
								Main.TileSet[j, k].Type = (byte)EntityID.TileID.SAND;
								WorldGen.SquareTileFrame(j, k);
								NetMessage.SendTile(j, k);
								break;
						}
					}
					else
					{
						switch ((EntityID.TileID)num5)
						{
							case EntityID.TileID.HALLOWED_GRASS:
								Main.TileSet[j, k].Type = (byte)EntityID.TileID.GRASS;
								WorldGen.SquareTileFrame(j, k);
								NetMessage.SendTile(j, k);
								break;
							case EntityID.TileID.PEARLSAND:
								Main.TileSet[j, k].Type = (byte)EntityID.TileID.SAND;
								WorldGen.SquareTileFrame(j, k);
								NetMessage.SendTile(j, k);
								break;
							case EntityID.TileID.PEARLSTONE:
								Main.TileSet[j, k].Type = (byte)EntityID.TileID.STONE;
								WorldGen.SquareTileFrame(j, k);
								NetMessage.SendTile(j, k);
								break;
						}
					}
				}
			}
		}

		private void GrapplingAI()
		{
			if (Main.PlayerSet[owner].IsDead)
			{
				Kill();
				return;
			}
			Vector2 vector = new Vector2(position.X + width * 0.5f, position.Y + height * 0.5f);
			float num = Main.PlayerSet[owner].Position.X + 10f - vector.X;
			float num2 = Main.PlayerSet[owner].Position.Y + 21f - vector.Y;
			float num3 = (float)Math.Sqrt(num * num + num2 * num2);
			rotation = (float)Math.Atan2(num2, num) - 1.57f;
			if (ai0 == 0f)
			{
				if ((num3 > 300f && type == (byte)EntityID.ProjectileID.HOOK) || (num3 > 400f && type == (byte)EntityID.ProjectileID.IVY_WHIP) || (num3 > 440f && type == (byte)EntityID.ProjectileID.DUAL_HOOK_BLUE) || (num3 > 440f && type == (byte)EntityID.ProjectileID.DUAL_HOOK_RED))
				{
					ai0 = 1f;
				}
				int num4 = (XYWH.X >> 4) - 1;
				int num5 = (XYWH.X + width >> 4) + 2;
				int num6 = (XYWH.Y >> 4) - 1;
				int num7 = (XYWH.Y + height >> 4) + 2;
				if (num4 < 0)
				{
					num4 = 0;
				}
				if (num5 > Main.MaxTilesX)
				{
					num5 = Main.MaxTilesX;
				}
				if (num6 < 0)
				{
					num6 = 0;
				}
				if (num7 > Main.MaxTilesY)
				{
					num7 = Main.MaxTilesY;
				}
				Vector2 vector2 = default;
				for (int i = num4; i < num5; i++)
				{
					for (int j = num6; j < num7; j++)
					{
						vector2.X = i * 16;
						vector2.Y = j * 16;
						if (!(position.X + width > vector2.X) || !(position.X < vector2.X + 16f) || !(position.Y + height > vector2.Y) || !(position.Y < vector2.Y + 16f) || Main.TileSet[i, j].IsActive == 0 || !Main.TileSolid[Main.TileSet[i, j].Type])
						{
							continue;
						}
						if (Main.PlayerSet[owner].grapCount < 10)
						{
							Main.PlayerSet[owner].grappling[Main.PlayerSet[owner].grapCount] = whoAmI;
							Main.PlayerSet[owner].grapCount++;
						}
						if (isLocal())
						{
							int num8 = 0;
							int num9 = -1;
							int num10 = 100000;
							if (type == (byte)EntityID.ProjectileID.DUAL_HOOK_BLUE || type == (byte)EntityID.ProjectileID.DUAL_HOOK_RED)
							{
								for (int k = 0; k < MaxNumProjs; k++)
								{
									if (k != whoAmI && Main.ProjectileSet[k].active != 0 && Main.ProjectileSet[k].owner == owner && Main.ProjectileSet[k].aiStyle == (byte)EntityID.ProjStyleID.GRAPPLING_HOOK && Main.ProjectileSet[k].ai0 == 2f)
									{
										Main.ProjectileSet[k].Kill();
									}
								}
							}
							else
							{
								for (int l = 0; l < MaxNumProjs; l++)
								{
									if (Main.ProjectileSet[l].active != 0 && Main.ProjectileSet[l].owner == owner && Main.ProjectileSet[l].aiStyle == (byte)EntityID.ProjStyleID.GRAPPLING_HOOK)
									{
										if (Main.ProjectileSet[l].timeLeft < num10)
										{
											num9 = l;
											num10 = Main.ProjectileSet[l].timeLeft;
										}
										num8++;
									}
								}
								if (num8 > 3)
								{
									Main.ProjectileSet[num9].Kill();
								}
							}
						}
						WorldGen.KillTile(i, j, KillToFail: true, EffectOnly: true);
						Main.PlaySound(0, i * 16, j * 16);
						velocity.X = 0f;
						velocity.Y = 0f;
						ai0 = 2f;
						position.X = (XYWH.X = i * 16 + 8 - (width >> 1));
						position.Y = (XYWH.Y = j * 16 + 8 - (height >> 1));
						damage = 0;
						netUpdate = true;
						if (isLocal())
						{
							NetMessage.CreateMessage1(13, owner);
							NetMessage.SendMessage();
						}
						break;
					}
					if (ai0 == 2f)
					{
						break;
					}
				}
			}
			else if (ai0 == 1f)
			{
				float num11 = 11f;
				if (type == (byte)EntityID.ProjectileID.IVY_WHIP)
				{
					num11 = 15f;
				}
				if (type == (byte)EntityID.ProjectileID.DUAL_HOOK_BLUE || type == (byte)EntityID.ProjectileID.DUAL_HOOK_RED)
				{
					num11 = 17f;
				}
				if (num3 < 24f)
				{
					Kill();
				}
				num3 = num11 / num3;
				num *= num3;
				num2 *= num3;
				velocity.X = num;
				velocity.Y = num2;
			}
			else
			{
				if (ai0 != 2f)
				{
					return;
				}
				int num12 = (XYWH.X >> 4) - 1;
				int num13 = (XYWH.X + width >> 4) + 2;
				int num14 = (XYWH.Y >> 4) - 1;
				int num15 = (XYWH.Y + height >> 4) + 2;
				if (num12 < 0)
				{
					num12 = 0;
				}
				if (num13 > Main.MaxTilesX)
				{
					num13 = Main.MaxTilesX;
				}
				if (num14 < 0)
				{
					num14 = 0;
				}
				if (num15 > Main.MaxTilesY)
				{
					num15 = Main.MaxTilesY;
				}
				bool flag = true;
				Vector2 vector3 = default;
				for (int m = num12; m < num13; m++)
				{
					for (int n = num14; n < num15; n++)
					{
						vector3.X = m * 16;
						vector3.Y = n * 16;
						if (position.X + (width >> 1) > vector3.X && position.X + (width >> 1) < vector3.X + 16f && position.Y + (height >> 1) > vector3.Y && position.Y + (height >> 1) < vector3.Y + 16f && Main.TileSet[m, n].IsActive != 0 && Main.TileSolid[Main.TileSet[m, n].Type])
						{
							flag = false;
						}
					}
				}
				if (flag)
				{
					ai0 = 1f;
				}
				else if (Main.PlayerSet[owner].grapCount < 10)
				{
					Main.PlayerSet[owner].grappling[Main.PlayerSet[owner].grapCount] = whoAmI;
					Main.PlayerSet[owner].grapCount++;
				}
			}
		}

		private unsafe void BallOfFireAI()
		{
			if (type == (byte)EntityID.ProjectileID.CURSED_FLAME_HOSTILE && localAI0 == 0)
			{
				localAI0 = 1;
				Main.PlaySound(2, XYWH.X, XYWH.Y, 20);
			}
			if (type == (byte)EntityID.ProjectileID.WATER_BOLT)
			{
				Dust* ptr = Main.DustSet.NewDust((int)(position.X + velocity.X), (int)(position.Y + velocity.Y), width, height, 29, velocity.X, velocity.Y, 100, default, 3.0);
				if (ptr != null)
				{
					ptr->NoGravity = true;
					if (Main.Rand.Next(12) == 0)
					{
						Main.DustSet.NewDust(29, ref XYWH, velocity.X, velocity.Y, 100, default, 1.4f);
					}
				}
			}
			else if (type == (byte)EntityID.ProjectileID.CURSED_FLAME_FRIENDLY || type == (byte)EntityID.ProjectileID.CURSED_FLAME_HOSTILE)
			{
				Dust* ptr2 = Main.DustSet.NewDust((int)(position.X + velocity.X), (int)(position.Y + velocity.Y), width, height, 75, velocity.X, velocity.Y, 100, default, 3f * scale);
				if (ptr2 != null)
				{
					ptr2->NoGravity = true;
				}
			}
			else
			{
				for (int i = 0; i < 2; i++)
				{
					Dust* ptr3 = Main.DustSet.NewDust(6, ref XYWH, velocity.X * 0.2f, velocity.Y * 0.2f, 100, default, 2.0);
					if (ptr3 == null)
					{
						break;
					}
					ptr3->NoGravity = true;
					ptr3->Velocity.X *= 0.3f;
					ptr3->Velocity.Y *= 0.3f;
				}
			}
			if (type != (byte)EntityID.ProjectileID.WATER_BOLT && type != (byte)EntityID.ProjectileID.CURSED_FLAME_HOSTILE && ++ai1 >= 20)
			{
				velocity.Y += 0.2f;
			}
			rotation += 0.3f * direction;
			if (velocity.Y > 16f)
			{
				velocity.Y = 16f;
			}
		}

		private unsafe void MagicMissileAI()
		{
			if (type == (byte)EntityID.ProjectileID.FLAMELASH)
			{
				Dust* ptr = Main.DustSet.NewDust(6, ref XYWH, velocity.X * 0.2f, velocity.Y * 0.2f, 100, default, 3.5);
				if (ptr != null)
				{
					ptr->NoGravity = true;
					ptr->Velocity.X *= 1.4f;
					ptr->Velocity.Y *= 1.4f;
					Main.DustSet.NewDust(6, ref XYWH, velocity.X * 0.2f, velocity.Y * 0.2f, 100, default, 1.5);
				}
			}
			else if (type == (byte)EntityID.ProjectileID.RAINBOW_ROD_BULLET)
			{
				if (soundDelay == 0 && Math.Abs(velocity.X) + Math.Abs(velocity.Y) > 2f)
				{
					soundDelay = 10;
					Main.PlaySound(2, XYWH.X, XYWH.Y, 9);
				}
				Dust* ptr2 = Main.DustSet.NewDust(66, ref XYWH, 0.0, 0.0, 100, new Color(Main.DiscoRGB), 2.5);
				if (ptr2 != null)
				{
					ptr2->Velocity.X *= 0.1f;
					ptr2->Velocity.Y *= 0.1f;
					ptr2->Velocity.X += velocity.X * 0.2f;
					ptr2->Velocity.Y += velocity.Y * 0.2f;
					ptr2->Position.X = XYWH.X + (width >> 1) + 4 + Main.Rand.Next(-2, 3);
					ptr2->Position.Y = XYWH.Y + (height >> 1) + Main.Rand.Next(-2, 3);
					ptr2->NoGravity = true;
				}
			}
			else
			{
				if (soundDelay == 0 && Math.Abs(velocity.X) + Math.Abs(velocity.Y) > 2f)
				{
					soundDelay = 10;
					Main.PlaySound(2, XYWH.X, XYWH.Y, 9);
				}
				Dust* ptr3 = Main.DustSet.NewDust(15, ref XYWH, 0.0, 0.0, 100, default, 2.0);
				if (ptr3 != null)
				{
					ptr3->Velocity.X *= 0.3f;
					ptr3->Velocity.Y *= 0.3f;
					ptr3->Position.X = XYWH.X + (width >> 1) + 4 + Main.Rand.Next(-4, 5);
					ptr3->Position.Y = XYWH.Y + (height >> 1) + Main.Rand.Next(-4, 5);
					ptr3->NoGravity = true;
				}
			}
			if (ai0 == 0f)
			{
				Player player = Main.PlayerSet[owner];
#if VERSION_INITIAL && !IS_PATCHED
				if (player.isLocal() && player.channel)
				{
					float num = ((type == (byte)EntityID.ProjectileID.MAGIC_MISSILE) ? 15 : 12);
					Vector2 vector = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
					float num2 = (float)(player.ui.MouseX + player.CurrentView.ScreenPosition.X) - vector.X;
					float num3 = (float)(player.ui.MouseY + player.CurrentView.ScreenPosition.Y) - vector.Y;
					float num4 = (float)Math.Sqrt(num2 * num2 + num3 * num3);
					if (num4 > num)
					{
						num4 = num / num4;
						num2 *= num4;
						num3 *= num4;
					}
					int num5 = (int)(num2 * 1000f);
					int num6 = (int)(velocity.X * 1000f);
					int num7 = (int)(num3 * 1000f);
					int num8 = (int)(velocity.Y * 1000f);
					if (num5 != num6 || num7 != num8)
					{
						netUpdate = true;
					}
					velocity.X = num2;
					velocity.Y = num3;
				}
				else
				{
					ai0 = 1f;
					netUpdate = true;
					float num9 = 12f;
					Vector2 vector2 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
					float num10 = (float)(player.ui.MouseX + player.CurrentView.ScreenPosition.X) - vector2.X;
					float num11 = (float)(player.ui.MouseY + player.CurrentView.ScreenPosition.Y) - vector2.Y;
					float num12 = (float)Math.Sqrt(num10 * num10 + num11 * num11);
					if (num12 == 0f)
					{
						vector2 = new Vector2(player.Position.X + 10f, player.Position.Y + 21f);
						num10 = position.X + (float)(int)width * 0.5f - vector2.X;
						num11 = position.Y + (float)(int)height * 0.5f - vector2.Y;
						num12 = (float)Math.Sqrt(num10 * num10 + num11 * num11);
					}
					num12 = num9 / num12;
					num10 *= num12;
					num11 *= num12;
					velocity.X = num10;
					velocity.Y = num11;
					if (velocity.X == 0f && velocity.Y == 0f)
					{
						Kill();
					}
				}
#else
				if (player.isLocal())
				{
					if (player.channel)
					{
						float num = ((type == (byte)EntityID.ProjectileID.MAGIC_MISSILE) ? 15 : 12);
						Vector2 vector = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
						float num2 = (float)(player.ui.MouseX + player.CurrentView.ScreenPosition.X) - vector.X;
						float num3 = (float)(player.ui.MouseY + player.CurrentView.ScreenPosition.Y) - vector.Y;
						float num4 = (float)Math.Sqrt(num2 * num2 + num3 * num3);
						if (num4 > num)
						{
							num4 = num / num4;
							num2 *= num4;
							num3 *= num4;
						}
						int num5 = (int)(num2 * 1000f);
						int num6 = (int)(velocity.X * 1000f);
						int num7 = (int)(num3 * 1000f);
						int num8 = (int)(velocity.Y * 1000f);
						if (num5 != num6 || num7 != num8)
						{
							netUpdate = true;
						}
						velocity.X = num2;
						velocity.Y = num3;
					}
					else
					{
						ai0 = 1f;
						netUpdate = true;
						Vector2 vector2 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
						float num9 = (float)(player.ui.MouseX + player.CurrentView.ScreenPosition.X) - vector2.X;
						float num10 = (float)(player.ui.MouseY + player.CurrentView.ScreenPosition.Y) - vector2.Y;
						float num11 = (float)Math.Sqrt(num9 * num9 + num10 * num10);
						if (num11 == 0f)
						{
							vector2 = new Vector2(player.Position.X + 10f, player.Position.Y + 21f);
							num9 = position.X + (float)(int)width * 0.5f - vector2.X;
							num10 = position.Y + (float)(int)height * 0.5f - vector2.Y;
							num11 = (float)Math.Sqrt(num9 * num9 + num10 * num10);
						}
						num11 = 12f / num11;
						num9 *= num11;
						num10 *= num11;
						velocity.X = num9;
						velocity.Y = num10;
						if (velocity.X == 0f && velocity.Y == 0f)
						{
							Kill();
						}
					}
				}
#endif
			}

			if (type == (byte)EntityID.ProjectileID.FLAMELASH)
			{
				Projectile projectile = this;
				projectile.rotation += 0.3f * direction;
			}
			else if (velocity.X != 0f || velocity.Y != 0f)
			{
				rotation = (float)Math.Atan2(velocity.Y, velocity.X) - 2.355f;
			}
			if (velocity.Y > 16f)
			{
				velocity.Y = 16f;
			}
		}

		private unsafe void DirtBallAI()
		{
			if (type == (byte)EntityID.ProjectileID.SAND_BALL_FALLING && ai0 != 2f)
			{
				if (Main.Rand.Next(3) == 0)
				{
					Dust* ptr = Main.DustSet.NewDust(32, ref XYWH, 0.0, velocity.Y * 0.5f);
					if (ptr != null)
					{
						ptr->Velocity.X *= 0.4f;
					}
				}
			}
			else
			{
				switch ((EntityID.ProjectileID)type)
				{
					case EntityID.ProjectileID.MUD_BALL:
						if (Main.Rand.Next(3) == 0)
						{
							Dust* ptr2 = Main.DustSet.NewDust(38, ref XYWH, 0.0, velocity.Y * 0.5f);
							if (ptr2 != null)
							{
								ptr2->Velocity.X *= 0.4f;
							}
						}
						break;
					case EntityID.ProjectileID.ASH_BALL_FALLING:
						if (Main.Rand.Next(3) == 0)
						{
							Dust* ptr3 = Main.DustSet.NewDust(36, ref XYWH, 0.0, velocity.Y * 0.5f);
							if (ptr3 != null)
							{
								ptr3->Velocity.X *= 0.4f;
								ptr3->Velocity.Y *= 0.4f;
							}
						}
						break;
					case EntityID.ProjectileID.SAND_BALL_GUN:
					case EntityID.ProjectileID.SAND_BALL_FALLING:
						if (Main.Rand.Next(3) == 0)
						{
							Dust* ptr4 = Main.DustSet.NewDust(32, ref XYWH);
							if (ptr4 != null)
							{
								ptr4->Velocity.X *= 0.4f;
							}
						}
						break;
					case EntityID.ProjectileID.EBONSAND_BALL_FALLING:
					case EntityID.ProjectileID.EBONSAND_BALL_GUN:
						if (Main.Rand.Next(3) == 0)
						{
							Dust* ptr5 = Main.DustSet.NewDust(14, ref XYWH);
							if (ptr5 != null)
							{
								ptr5->Velocity.X *= 0.4f;
							}
						}
						break;
					case EntityID.ProjectileID.PEARL_SAND_BALL_FALLING:
					case EntityID.ProjectileID.PEARL_SAND_BALL_GUN:
						if (Main.Rand.Next(3) == 0)
						{
							Dust* ptr6 = Main.DustSet.NewDust(51, ref XYWH);
							if (ptr6 != null)
							{
								ptr6->Velocity.X *= 0.4f;
							}
						}
						break;
					case EntityID.ProjectileID.SILT_BALL:
						if (Main.Rand.Next(3) == 0)
						{
							Dust* ptr7 = Main.DustSet.NewDust(53, ref XYWH);
							if (ptr7 != null)
							{
								ptr7->Velocity.X *= 0.4f;
							}
						}
						break;
					default:
						if (type != (byte)EntityID.ProjectileID.SNOW_BALL_HOSTILE && Main.Rand.Next(24) == 0)
						{
							Main.DustSet.NewDust(0, ref XYWH);
						}
						break;

				}
			}
			if (ai0 == 0f)
			{
				Player player = Main.PlayerSet[owner];
				if (player.isLocal() && player.channel)
				{
					float num = 12f;
					Vector2 vector = new Vector2(position.X + width * 0.5f, position.Y + height * 0.5f);
					float num2 = player.ui.MouseX + player.CurrentView.ScreenPosition.X - vector.X;
					float num3 = player.ui.MouseY + player.CurrentView.ScreenPosition.Y - vector.Y;
					float num4 = (float)Math.Sqrt(num2 * num2 + num3 * num3);
					num4 = (float)Math.Sqrt(num2 * num2 + num3 * num3);
					if (num4 > num)
					{
						num4 = num / num4;
						num2 *= num4;
						num3 *= num4;
					}
					if (num2 != velocity.X || num3 != velocity.Y)
					{
						netUpdate = true;
					}
					velocity.X = num2;
					velocity.Y = num3;
				}
				else
				{
					ai0 = 1f;
					netUpdate = true;
				}
			}
			if (type != (byte)EntityID.ProjectileID.SNOW_BALL_HOSTILE)
			{
				if (ai0 == 1f)
				{
					if (type == (byte)EntityID.ProjectileID.SAND_BALL_GUN || type == (byte)EntityID.ProjectileID.EBONSAND_BALL_GUN || type == (byte)EntityID.ProjectileID.PEARL_SAND_BALL_GUN)
					{
						if (++ai1 >= 60)
						{
							velocity.Y += 0.2f;
						}
					}
					else
					{
						velocity.Y += 0.41f;
					}
				}
				else if (ai0 == 2f)
				{
					velocity.Y += 0.2f;
					if (velocity.X < -0.04)
					{
						velocity.X += 0.04f;
					}
					else if (velocity.X > 0.04)
					{
						velocity.X -= 0.04f;
					}
					else
					{
						velocity.X = 0f;
					}
				}
			}
			rotation += 0.1f;
			if (velocity.Y > 10f)
			{
				velocity.Y = 10f;
			}
		}

		private void OrbOfLightAI()
		{
			rotation += 0.02f;
			if (isLocal() && Main.PlayerSet[owner].lightOrb)
			{
				timeLeft = 2;
			}
			if (!Main.PlayerSet[owner].IsDead)
			{
				Vector2 vector = new Vector2(position.X + width * 0.5f, position.Y + height * 0.5f);
				float num = Main.PlayerSet[owner].Position.X + (Player.width / 2) - vector.X;
				float num2 = Main.PlayerSet[owner].Position.Y + (Player.height / 2) - vector.Y;
				float num3 = (float)Math.Sqrt(num * num + num2 * num2);
				num3 = (float)Math.Sqrt(num * num + num2 * num2);
				if (num3 > 800f)
				{
					position.X = (XYWH.X = Main.PlayerSet[owner].XYWH.X + (Player.width / 2) - (width >> 1));
					position.Y = (XYWH.Y = Main.PlayerSet[owner].XYWH.Y + (Player.height / 2) - (height >> 1));
				}
				else if (num3 > 70f)
				{
					num3 = 2.5f / num3;
					num *= num3;
					num2 *= num3;
					velocity.X = num;
					velocity.Y = num2;
				}
				else
				{
					velocity.X = 0f;
					velocity.Y = 0f;
				}
			}
			else
			{
				Kill();
			}
		}

		private unsafe void FairyAI()
		{
			if (velocity.X > 0f)
			{
				spriteDirection = -1;
			}
			else if (velocity.X < 0f)
			{
				spriteDirection = 1;
			}
			rotation = velocity.X * 0.1f;
			if (++frameCounter >= 4)
			{
				frameCounter = 0;
				frame = (byte)((uint)(frame + 1) & 3u);
			}
			if (Main.Rand.Next(6) == 0)
			{
				int num = 56;
				if (type == (byte)EntityID.ProjectileID.PINK_FAIRY)
				{
					num = 73;
				}
				else if (type == (byte)EntityID.ProjectileID.GREEN_FAIRY)
				{
					num = 74;
				}
				Dust* ptr = Main.DustSet.NewDust(num, ref XYWH, 0.0, 0.0, 200, default, 0.8f);
				if (ptr != null)
				{
					ptr->Velocity.X *= 0.3f;
					ptr->Velocity.Y *= 0.3f;
				}
			}
			if (isLocal() && Main.PlayerSet[owner].fairy)
			{
				timeLeft = 2;
			}
			if (!Main.PlayerSet[owner].IsDead)
			{
				Vector2 vector = new Vector2(position.X + width * 0.5f, position.Y + height * 0.5f);
				float num2 = Main.PlayerSet[owner].Position.X + (Player.width / 2) - vector.X;
				float num3 = Main.PlayerSet[owner].Position.Y + (Player.height / 2) - vector.Y;
				float num4 = (float)Math.Sqrt(num2 * num2 + num3 * num3);
				if (num4 > 800f)
				{
					position.X = (XYWH.X = Main.PlayerSet[owner].XYWH.X + (Player.width / 2) - (width >> 1));
					position.Y = (XYWH.Y = Main.PlayerSet[owner].XYWH.Y + (Player.height / 2) - (height >> 1));
				}
				else if (num4 > 40f)
				{
					num4 = 3.5f / num4;
					num2 *= num4;
					num3 *= num4;
					velocity.X = num2;
					velocity.Y = num3;
				}
				else
				{
					velocity.X = 0f;
					velocity.Y = 0f;
				}
			}
			else
			{
				Kill();
			}
		}

		private unsafe void BlueFlameAI()
		{
			scale -= 0.04f;
			if (scale <= 0f)
			{
				Kill();
			}
			if (ai0 > 4f)
			{
				alpha = 150;
				light = 0.8f;
				Dust* ptr = Main.DustSet.NewDust(29, ref XYWH, velocity.X, velocity.Y, 100, default, 2.5);
				if (ptr != null)
				{
					ptr->NoGravity = true;
					Main.DustSet.NewDust(29, ref XYWH, velocity.X, velocity.Y, 100, default, 1.5);
				}
			}
			else
			{
				ai0 += 1f;
			}
			rotation += 0.3f * direction;
		}

		private void HarpoonAI()
		{
			if (Main.PlayerSet[owner].IsDead)
			{
				Kill();
				return;
			}
			Main.PlayerSet[owner].itemAnimation = 5;
			Main.PlayerSet[owner].itemTime = 5;
			if (XYWH.X + (width >> 1) > Main.PlayerSet[owner].XYWH.X + 10)
			{
				Main.PlayerSet[owner].direction = 1;
			}
			else
			{
				Main.PlayerSet[owner].direction = -1;
			}
			Vector2 vector = new Vector2(position.X + width * 0.5f, position.Y + height * 0.5f);
			float num = Main.PlayerSet[owner].Position.X + 10f - vector.X;
			float num2 = Main.PlayerSet[owner].Position.Y + 21f - vector.Y;
			float num3 = (float)Math.Sqrt(num * num + num2 * num2);
			if (ai0 == 0f)
			{
				if (num3 > 700f)
				{
					ai0 = 1f;
				}
				rotation = (float)Math.Atan2(velocity.Y, velocity.X) + 1.57f;
				if (++ai1 > 2)
				{
					alpha = 0;
					if (ai1 >= 10)
					{
						velocity.Y += 0.3f;
					}
				}
			}
			else if (ai0 == 1f)
			{
				tileCollide = false;
				rotation = (float)Math.Atan2(num2, num) - 1.57f;
				float num4 = 20f;
				if (num3 < 50f)
				{
					Kill();
				}
				num3 = num4 / num3;
				num *= num3;
				num2 *= num3;
				velocity.X = num;
				velocity.Y = num2;
			}
		}

		private void SpikyBallAI()
		{
			if (type == (byte)EntityID.ProjectileID.STICKY_GLOWSTICK)
			{
				int num = (XYWH.X >> 4) - 1;
				int num2 = (XYWH.X + width >> 4) + 2;
				int num3 = (XYWH.Y >> 4) - 1;
				int num4 = (XYWH.Y + height >> 4) + 2;
				if (num < 0)
				{
					num = 0;
				}
				if (num2 > Main.MaxTilesX)
				{
					num2 = Main.MaxTilesX;
				}
				if (num3 < 0)
				{
					num3 = 0;
				}
				if (num4 > Main.MaxTilesY)
				{
					num4 = Main.MaxTilesY;
				}
				Vector2 vector = default;
				for (int i = num; i < num2; i++)
				{
					for (int j = num3; j < num4; j++)
					{
						if (Main.TileSet[i, j].CanStandOnTop())
						{
							vector.X = i * 16;
							vector.Y = j * 16;
							if (position.X + width > vector.X && position.X < vector.X + 16f && position.Y + height > vector.Y && position.Y < vector.Y + 16f)
							{
								velocity.X = 0f;
								velocity.Y = -0.2f;
							}
						}
					}
				}
			}
			ai0 += 1f;
			if (ai0 > 5f)
			{
				ai0 = 5f;
				if (velocity.Y == 0f && velocity.X != 0f)
				{
					velocity.X *= 0.97f;
					if (velocity.X > -0.01 && velocity.X < 0.01)
					{
						velocity.X = 0f;
						netUpdate = true;
					}
				}
				velocity.Y += 0.2f;
			}
			rotation += velocity.X * 0.1f;
			if (velocity.Y > 16f)
			{
				velocity.Y = 16f;
			}
		}

		private unsafe void FlailAI()
		{
			if (type == (byte)EntityID.ProjectileID.BALL_O_HURT)
			{
				if (Main.Rand.Next(16) == 0)
				{
					Main.DustSet.NewDust(14, ref XYWH, 0.0, 0.0, 150, default, 1.3f);
				}
			}
			else if (type == (byte)EntityID.ProjectileID.BLUE_MOON)
			{
				Dust* ptr = Main.DustSet.NewDust(29, ref XYWH, velocity.X * 0.4f, velocity.Y * 0.4f, 100, default, 2.5);
				if (ptr != null)
				{
					ptr->NoGravity = true;
					ptr->Velocity.X *= 0.5f;
					ptr->Velocity.Y *= 0.5f;
				}
			}
			else if (type == (byte)EntityID.ProjectileID.SUNFURY)
			{
				Dust* ptr2 = Main.DustSet.NewDust(6, ref XYWH, velocity.X * 0.4f, velocity.Y * 0.4f, 100, default, 3.0);
				if (ptr2 != null)
				{
					ptr2->NoGravity = true;
					ptr2->Velocity.X *= 2f;
					ptr2->Velocity.Y *= 2f;
				}
			}
			if (Main.PlayerSet[owner].IsDead)
			{
				Kill();
				return;
			}
			Main.PlayerSet[owner].itemAnimation = 10;
			Main.PlayerSet[owner].itemTime = 10;
			if (XYWH.X + (width >> 1) > Main.PlayerSet[owner].XYWH.X + 10)
			{
				Main.PlayerSet[owner].direction = 1;
				direction = 1;
			}
			else
			{
				Main.PlayerSet[owner].direction = -1;
				direction = -1;
			}
			Vector2 vector = new Vector2(position.X + width * 0.5f, position.Y + height * 0.5f);
			float num = Main.PlayerSet[owner].Position.X + 10f - vector.X;
			float num2 = Main.PlayerSet[owner].Position.Y + 21f - vector.Y;
			float num3 = (float)Math.Sqrt(num * num + num2 * num2);
			if (ai0 == 0f)
			{
				float num4 = 160f;
				if (type == (byte)EntityID.ProjectileID.THE_DAO_OF_POW)
				{
					num4 *= 1.5f;
				}
				tileCollide = true;
				if (num3 > num4)
				{
					ai0 = 1f;
					netUpdate = true;
				}
				else if (!Main.PlayerSet[owner].channel)
				{
					if (velocity.Y < 0f)
					{
						velocity.Y *= 0.9f;
					}
					velocity.Y += 1f;
					velocity.X *= 0.9f;
				}
			}
			else if (ai0 == 1f)
			{
				float num5 = 14f / Main.PlayerSet[owner].meleeSpeed;
				float num6 = 0.9f / Main.PlayerSet[owner].meleeSpeed;
				float num7 = 300f;
				if (type == (byte)EntityID.ProjectileID.THE_DAO_OF_POW)
				{
					num7 *= 1.5f;
					num5 *= 1.5f;
					num6 *= 1.5f;
				}
				Math.Abs(num);
				Math.Abs(num2);
				if (ai1 == 1)
				{
					tileCollide = false;
				}
				if (!Main.PlayerSet[owner].channel || num3 > num7 || !tileCollide)
				{
					ai1 = 1;
					if (tileCollide)
					{
						netUpdate = true;
					}
					tileCollide = false;
					if (num3 < 20f)
					{
						Kill();
					}
				}
				if (!tileCollide)
				{
					num6 *= 2f;
				}
				if (num3 > 60f || !tileCollide)
				{
					num3 = num5 / num3;
					num *= num3;
					num2 *= num3;
					new Vector2(velocity.X, velocity.Y);
					float num8 = num - velocity.X;
					float num9 = num2 - velocity.Y;
					float num10 = (float)Math.Sqrt(num8 * num8 + num9 * num9);
					num10 = num6 / num10;
					num8 *= num10;
					num9 *= num10;
					velocity.X *= 0.98f;
					velocity.Y *= 0.98f;
					velocity.X += num8;
					velocity.Y += num9;
				}
				else
				{
					if (Math.Abs(velocity.X) + Math.Abs(velocity.Y) < 6f)
					{
						velocity.X *= 0.96f;
						velocity.Y += 0.2f;
					}
					if (Main.PlayerSet[owner].velocity.X == 0f)
					{
						velocity.X *= 0.96f;
					}
				}
			}
			rotation = (float)Math.Atan2(num2, num) - velocity.X * 0.1f;
		}

		private unsafe void BombAI()
		{
			if (type == (byte)EntityID.ProjectileID.EXPLOSIVES)
			{
				ai0 += 1f;
				if (ai0 > 3f)
				{
					Kill();
				}
			}
			if (type == (byte)EntityID.ProjectileID.STICKY_BOMB)
			{
				int num = (XYWH.X >> 4) - 1;
				int num2 = (XYWH.X + width >> 4) + 2;
				int num3 = (XYWH.Y >> 4) - 1;
				int num4 = (XYWH.Y + height >> 4) + 2;
				if (num < 0)
				{
					num = 0;
				}
				if (num2 > Main.MaxTilesX)
				{
					num2 = Main.MaxTilesX;
				}
				if (num3 < 0)
				{
					num3 = 0;
				}
				if (num4 > Main.MaxTilesY)
				{
					num4 = Main.MaxTilesY;
				}
				Vector2 vector = default;
				for (int i = num; i < num2; i++)
				{
					for (int j = num3; j < num4; j++)
					{
						if (Main.TileSet[i, j].CanStandOnTop())
						{
							vector.X = i * 16;
							vector.Y = j * 16;
							if (position.X + width - 4f > vector.X && position.X + 4f < vector.X + 16f && position.Y + height - 4f > vector.Y && position.Y + 4f < vector.Y + 16f)
							{
								velocity.X = 0f;
								velocity.Y = -0.2f;
							}
						}
					}
				}
			}
			if (type == (byte)EntityID.ProjectileID.BOMB_SKELETRON_PRIME)
			{
				if (velocity.Y > 10f)
				{
					velocity.Y = 10f;
				}
				if (localAI0 == 0)
				{
					localAI0 = 1;
					Main.PlaySound(2, XYWH.X, XYWH.Y, 10);
				}
				if (++frameCounter > 3)
				{
					frameCounter = 0;
					frame ^= 1;
				}
				if (velocity.Y == 0f && width != 128)
				{
					position.X += width >> 1;
					position.Y += height >> 1;
					XYWH.Width = (width = 128);
					XYWH.Height = (height = 128);
					position.X -= 64f;
					position.Y -= 64f;
					XYWH.X = (int)position.X;
					XYWH.Y = (int)position.Y;
					damage = 40;
					knockBack = 8f;
					timeLeft = 3;
					netUpdate = true;
				}
			}
			if (timeLeft <= 3 && isLocal())
			{
				ai1 = 0;
				alpha = 255;
				if (type == (byte)EntityID.ProjectileID.BOMB || type == (byte)EntityID.ProjectileID.STICKY_BOMB || type == (byte)EntityID.ProjectileID.HAPPY_BOMB)
				{
					if (width != 128)
					{
						position.X += width >> 1;
						position.Y += height >> 1;
						XYWH.Width = (width = 128);
						XYWH.Height = (height = 128);
						position.X -= 64f;
						position.Y -= 64f;
						XYWH.X = (int)position.X;
						XYWH.Y = (int)position.Y;
						damage = 100;
						knockBack = 8f;
					}
				}
				else if (type == (byte)EntityID.ProjectileID.DYNAMITE)
				{
					if (width != 250)
					{
						position.X += width >> 1;
						position.Y += height >> 1;
						XYWH.Width = (width = 250);
						XYWH.Height = (height = 250);
						position.X -= 125f;
						position.Y -= 125f;
						XYWH.X = (int)position.X;
						XYWH.Y = (int)position.Y;
						damage = 250;
						knockBack = 10f;
					}
				}
				else if (type == (byte)EntityID.ProjectileID.GRENADE && width != 128)
				{
					position.X += width >> 1;
					position.Y += height >> 1;
					XYWH.Width = (width = 128);
					XYWH.Height = (height = 128);
					position.X -= 64f;
					position.Y -= 64f;
					XYWH.X = (int)position.X;
					XYWH.Y = (int)position.Y;
					knockBack = 8f;
				}
			}
			else if (type != (byte)EntityID.ProjectileID.GRENADE)
			{
				if (type != (byte)EntityID.ProjectileID.EXPLOSIVES)
				{
					damage = 0;
				}
				if (Main.Rand.Next(5) == 0)
				{
					Main.DustSet.NewDust(6, ref XYWH, 0.0, 0.0, 100);
				}
			}
			ai0 += 1f;
			if ((type == (byte)EntityID.ProjectileID.GRENADE && ai0 > 10f) || (type != (byte)EntityID.ProjectileID.GRENADE && ai0 > 5f))
			{
				if (velocity.Y == 0f && velocity.X != 0f)
				{
					velocity.X *= 0.97f;
					if (type == (byte)EntityID.ProjectileID.DYNAMITE)
					{
						velocity.X *= 0.99f;
					}
					if (velocity.X > -0.01 && velocity.X < 0.01)
					{
						velocity.X = 0f;
						netUpdate = true;
					}
				}
				velocity.Y += 0.2f;
			}
			rotation += velocity.X * 0.1f;
		}

		private void TombstoneAI()
		{
			if (velocity.Y == 0f)
			{
				velocity.X *= 0.98f;
			}
			rotation += velocity.X * 0.1f;
			velocity.Y += 0.2f;
			if (!isLocal())
			{
				return;
			}
			int num = XYWH.X + (width >> 1) >> 4;
			int num2 = XYWH.Y + height - 4 >> 4;
			if (Main.TileSet[num, num2].IsActive == 0 && WorldGen.PlaceTile(num, num2, (int)EntityID.TileID.TOMBSTONE))
			{
				NetMessage.CreateMessage5((int)NetMessageId.MSG_WORLD_CHANGED, 1, num, num2, (int)EntityID.TileID.TOMBSTONE);
				NetMessage.SendMessage();
				int num3 = Sign.ReadSign(num, num2);
				if (num3 >= 0)
				{
					Main.SignSet[num3].SetText(tombstoneText[tombstoneTextId]);
				}
				Kill();
			}
		}

		private unsafe void DemonSickleAI()
		{
			if (ai1 == 0 && type == (byte)EntityID.ProjectileID.DEMON_SICKLE)
			{
				ai1 = 1;
				Main.PlaySound(2, XYWH.X, XYWH.Y, 8);
			}
			rotation += direction * 0.8f;
			if (!((ai0 += 1f) < 30f))
			{
				if (ai0 < 100f)
				{
					velocity.X *= 1.06f;
					velocity.Y *= 1.06f;
				}
				else
				{
					ai0 = 200f;
				}
			}
			for (int i = 0; i < 2; i++)
			{
				Dust* ptr = Main.DustSet.NewDust(27, ref XYWH, 0.0, 0.0, 100);
				if (ptr == null)
				{
					break;
				}
				ptr->NoGravity = true;
			}
		}

		private unsafe void SpearAI()
		{
			direction = Main.PlayerSet[owner].direction;
			Main.PlayerSet[owner].heldProj = whoAmI;
			Main.PlayerSet[owner].itemTime = (byte)Main.PlayerSet[owner].itemAnimation;
			position.X = Main.PlayerSet[owner].Position.X + (20 - width >> 1);
			position.Y = Main.PlayerSet[owner].Position.Y + (42 - height >> 1);
			switch ((EntityID.ProjectileID)type)
			{
				case EntityID.ProjectileID.DARK_LANCE:
					if (ai0 == 0f)
					{
						ai0 = 3f;
						netUpdate = true;
					}

					if (Main.PlayerSet[owner].itemAnimation < Main.PlayerSet[owner].itemAnimationMax / 3)
					{
						ai0 -= 1.6f;
					}
					else
					{
						ai0 += 1.4f;
					}
					break;
				case EntityID.ProjectileID.GUNGNIR:
				case EntityID.ProjectileID.TONBOGIRI:
					if (ai0 == 0f)
					{
						ai0 = 3f;
						netUpdate = true;
					}

					if (Main.PlayerSet[owner].itemAnimation < Main.PlayerSet[owner].itemAnimationMax / 3)
					{
						ai0 -= 2.4f;
					}
					else
					{
						ai0 += 2.1f;
					}
					break;
				case EntityID.ProjectileID.TRIDENT:
					if (ai0 == 0f)
					{
						ai0 = 4f;
						netUpdate = true;
					}

					if (Main.PlayerSet[owner].itemAnimation < Main.PlayerSet[owner].itemAnimationMax / 3)
					{
						ai0 -= 1.2f;
					}
					else
					{
						ai0 += 0.9f;
					}
					break;
				case EntityID.ProjectileID.SPEAR:
					if (ai0 == 0f)
					{
						ai0 = 4f;
						netUpdate = true;
					}

					if (Main.PlayerSet[owner].itemAnimation < Main.PlayerSet[owner].itemAnimationMax / 3)
					{
						ai0 -= 1.1f;
					}
					else
					{
						ai0 += 0.85f;
					}
					break;
				case EntityID.ProjectileID.MYTHRIL_HALBERD:
					spriteDirection = (sbyte)(-direction);
					if (ai0 == 0f)
					{
						ai0 = 3f;
						netUpdate = true;
					}

					if (Main.PlayerSet[owner].itemAnimation < Main.PlayerSet[owner].itemAnimationMax / 3)
					{
						ai0 -= 1.9f;
					}
					else
					{
						ai0 += 1.7f;
					}
					break;
				case EntityID.ProjectileID.ADAMANTITE_GLAIVE:
				case EntityID.ProjectileID.COBALT_NAGINATA:
					spriteDirection = (sbyte)(-direction);
					if (ai0 == 0f)
					{
						ai0 = 3f;
						netUpdate = true;
					}

					if (Main.PlayerSet[owner].itemAnimation < Main.PlayerSet[owner].itemAnimationMax / 3)
					{
						ai0 -= 2.1f;
					}
					else
					{
						ai0 += 1.9f;
					}
					break;
				/*
				case EntityID.ProjectileID.COBALT_NAGINATA:
					// Prior to switch-case conversion, this was an if-else-if section, and this segment was included, but the problem is this case is already handled above.
					// I have no idea what this is for, so it may be an error.
					spriteDirection = (sbyte)(-direction);
					if (ai0 == 0f)
					{
						ai0 = 3f;
						netUpdate = true;
					}

					if (Main.PlayerSet[owner].itemAnimation < Main.PlayerSet[owner].itemAnimationMax / 3)
					{
						ai0 -= 1.6f;
					}
					else
					{
						ai0 += 1.4f;
					}
					break;
				*/
			}
			position.X += velocity.X * ai0;
			position.Y += velocity.Y * ai0;
			XYWH.X = (int)position.X;
			XYWH.Y = (int)position.Y;
			if (Main.PlayerSet[owner].itemAnimation == 0)
			{
				Kill();
			}
			rotation = (float)(Math.Atan2(velocity.Y, velocity.X) + 2.355);
			if (spriteDirection == -1)
			{
				rotation -= 1.57f;
			}
			if (type == (byte)EntityID.ProjectileID.DARK_LANCE)
			{
				if (Main.Rand.Next(6) == 0)
				{
					Main.DustSet.NewDust(14, ref XYWH, 0.0, 0.0, 150, default, 1.4f);
				}
				Dust* ptr = Main.DustSet.NewDust(27, ref XYWH, velocity.X * 0.2f + direction * 3, velocity.Y * 0.2f, 100, default, 1.2);
				if (ptr != null)
				{
					ptr->NoGravity = true;
					ptr->Velocity.X *= 0.5f;
					ptr->Velocity.Y *= 0.5f;
					ptr = Main.DustSet.NewDust((int)(position.X - velocity.X * 2f), (int)(position.Y - velocity.Y * 2f), width, height, 27, 0.0, 0.0, 150, default, 1.4f);
					if (ptr != null)
					{
						ptr->Velocity.X *= 0.2f;
						ptr->Velocity.Y *= 0.2f;
					}
				}
			}
			else if (type == (byte)EntityID.ProjectileID.GUNGNIR)
			{
				if (Main.Rand.Next(4) == 0)
				{
					Dust* ptr2 = Main.DustSet.NewDust(57, ref XYWH, velocity.X * 0.2f, velocity.Y * 0.2f, 200, default, 1.2);
					if (ptr2 != null)
					{
						ptr2->Velocity.X += velocity.X * 0.3f;
						ptr2->Velocity.Y += velocity.Y * 0.3f;
						ptr2->Velocity.X *= 0.2f;
						ptr2->Velocity.Y *= 0.2f;
					}
				}
				if (Main.Rand.Next(5) == 0)
				{
					Dust* ptr3 = Main.DustSet.NewDust(43, ref XYWH, 0.0, 0.0, 254, default, 0.3);
					if (ptr3 != null)
					{
						ptr3->Velocity.X += velocity.X * 0.5f;
						ptr3->Velocity.Y += velocity.Y * 0.5f;
						ptr3->Velocity.X *= 0.5f;
						ptr3->Velocity.Y *= 0.5f;
					}
				}
			}
			else
			{
				if (type != (byte)EntityID.ProjectileID.TONBOGIRI)
				{
					return;
				}
				if (Main.Rand.Next(3) == 0)
				{
					Dust* ptr4 = Main.DustSet.NewDust(57, ref XYWH, velocity.X * 0.2f, velocity.Y * 0.2f, 200, default, 1.2);
					if (ptr4 != null)
					{
						ptr4->Velocity.X += velocity.X * 0.3f;
						ptr4->Velocity.Y += velocity.Y * 0.3f;
						ptr4->Velocity.X *= 0.2f;
						ptr4->Velocity.Y *= 0.2f;
					}
				}
				if (Main.Rand.Next(4) == 0)
				{
					Dust* ptr5 = Main.DustSet.NewDust(43, ref XYWH, 0.0, 0.0, 254, default, 0.3);
					if (ptr5 != null)
					{
						ptr5->Velocity.X += velocity.X * 0.5f;
						ptr5->Velocity.Y += velocity.Y * 0.5f;
						ptr5->Velocity.X *= 0.5f;
						ptr5->Velocity.Y *= 0.5f;
					}
				}
			}
		}

		private unsafe void ChainsawAI()
		{
			if (soundDelay <= 0)
			{
				Main.PlaySound(2, XYWH.X, XYWH.Y, 22);
				soundDelay = 30;
			}
			Player player = Main.PlayerSet[owner];
			if (player.isLocal())
			{
				if (player.channel)
				{
					float num = player.Inventory[player.SelectedItem].ShootSpeed * scale;
					Vector2 vector = new Vector2(player.Position.X + 10f, player.Position.Y + 21f);
					float num2 = player.ui.MouseX + player.CurrentView.ScreenPosition.X - vector.X;
					float num3 = player.ui.MouseY + player.CurrentView.ScreenPosition.Y - vector.Y;
					float num4 = num2 * num2 + num3 * num3;
					if (num4 > 0f)
					{
						num4 = (float)Math.Sqrt(num4);
						num4 = num / num4;
						num2 *= num4;
						num3 *= num4;
					}
					if (num2 != velocity.X || num3 != velocity.Y)
					{
						netUpdate = true;
					}
					velocity.X = num2;
					velocity.Y = num3;
				}
				else
				{
					Kill();
				}
			}
			if (velocity.X > 0f)
			{
				direction = 1;
			}
			else if (velocity.X < 0f)
			{
				direction = -1;
			}
			spriteDirection = direction;
			player.direction = direction;
			player.heldProj = whoAmI;
			player.itemTime = 2;
			player.itemAnimation = 2;
			position.X = player.Position.X + 10f - (width >> 1);
			position.Y = player.Position.Y + 21f - (height >> 1);
			XYWH.X = (int)position.X;
			XYWH.Y = (int)position.Y;
			rotation = (float)(Math.Atan2(velocity.Y, velocity.X) + (Math.PI / 2f));
			player.itemRotation = (float)Math.Atan2(velocity.Y * direction, velocity.X * direction);
			velocity.X *= 1f + Main.Rand.Next(-3, 4) * 0.01f;
			if (Main.Rand.Next(8) == 0)
			{
				float num5 = Main.Rand.Next(6, 10) * 0.1f;
				Dust* ptr = Main.DustSet.NewDust((int)(position.X + velocity.X * num5) - 4, (int)(position.Y + velocity.Y * num5), width, height, 31, 0.0, 0.0, 80, default, 1.4f);
				if (ptr != null)
				{
					ptr->NoGravity = true;
					ptr->Velocity.X *= 0.2f;
					ptr->Velocity.Y = -Main.Rand.Next(7, 13) * 0.15f;
				}
			}
		}

		private unsafe void NoteAI()
		{
			rotation = velocity.X * 0.1f;
			spriteDirection = (sbyte)(-direction);
			if (Main.Rand.Next(4) == 0)
			{
				Dust* ptr = Main.DustSet.NewDust(27, ref XYWH, 0.0, 0.0, 80);
				if (ptr != null)
				{
					ptr->NoGravity = true;
					ptr->Velocity.X *= 0.2f;
					ptr->Velocity.Y *= 0.2f;
				}
			}
			if (ai1 == 1)
			{
				ai1 = 0;
				Main.HarpNote = ai0;
				Main.PlaySound(2, XYWH.X, XYWH.Y, 26);
			}
		}

		private unsafe void IceBlockAI()
		{
			if (velocity.X == 0f && velocity.Y == 0f)
			{
				alpha = 255;
			}
			if (ai1 < 0)
			{
				if (velocity.X > 0f)
				{
					rotation += 0.3f;
				}
				else
				{
					rotation -= 0.3f;
				}
				int num = (XYWH.X >> 4) - 1;
				int num2 = (XYWH.X + width >> 4) + 2;
				int num3 = (XYWH.Y >> 4) - 1;
				int num4 = (XYWH.Y + height >> 4) + 2;
				if (num < 0)
				{
					num = 0;
				}
				if (num2 > Main.MaxTilesX)
				{
					num2 = Main.MaxTilesX;
				}
				if (num3 < 0)
				{
					num3 = 0;
				}
				if (num4 > Main.MaxTilesY)
				{
					num4 = Main.MaxTilesY;
				}
				int num5 = XYWH.X + 4;
				int num6 = XYWH.Y + 4;
				Vector2 vector = default;
				for (int i = num; i < num2; i++)
				{
					for (int j = num3; j < num4; j++)
					{
						if (Main.TileSet[i, j].IsActive == 0)
						{
							continue;
						}
						int num7 = Main.TileSet[i, j].Type;
						if (num7 != (int)EntityID.TileID.ICE && Main.TileSolidNotSolidTop[num7])
						{
							vector.X = i * 16;
							vector.Y = j * 16;
							if (num5 + 8 > vector.X && num5 < vector.X + 16f && num6 + 8 > vector.Y && num6 < vector.Y + 16f)
							{
								Kill();
							}
						}
					}
				}
				Dust* ptr = Main.DustSet.NewDust(67, ref XYWH);
				if (ptr != null)
				{
					ptr->NoGravity = true;
					ptr->Velocity.X *= 0.3f;
					ptr->Velocity.Y *= 0.3f;
				}
				return;
			}
			if (ai0 < 0f)
			{
				if (ai0 == -1f)
				{
					for (int k = 0; k < 8; k++)
					{
						Dust* ptr2 = Main.DustSet.NewDust(67, ref XYWH, 0.0, 0.0, 0, default, 1.1f);
						if (ptr2 == null)
						{
							break;
						}
						ptr2->NoGravity = true;
						ptr2->Velocity.X *= 1.3f;
						ptr2->Velocity.Y *= 1.3f;
					}
				}
				else if (Main.Rand.Next(32) == 0)
				{
					Dust* ptr3 = Main.DustSet.NewDust(67, ref XYWH, 0.0, 0.0, 100);
					if (ptr3 != null)
					{
						ptr3->Velocity.X *= 0.2f;
						ptr3->Velocity.Y *= 0.2f;
					}
				}
				int num8 = XYWH.X >> 4;
				int num9 = XYWH.Y >> 4;
				if (Main.TileSet[num8, num9].IsActive == 0)
				{
					Kill();
				}
				if ((ai0 -= 1f) <= -300f && isLocal() && Main.TileSet[num8, num9].Type == (int)EntityID.TileID.ICE && Main.TileSet[num8, num9].IsActive != 0)
				{
					WorldGen.KillTile(num8, num9);
					NetMessage.CreateMessage5((int)NetMessageId.MSG_WORLD_CHANGED, 0, num8, num9, 0);
					NetMessage.SendMessage();
					Kill();
				}
				return;
			}
			int num10 = (XYWH.X >> 4) - 1;
			int num11 = (XYWH.X + width >> 4) + 2;
			int num12 = (XYWH.Y >> 4) - 1;
			int num13 = (XYWH.Y + height >> 4) + 2;
			if (num10 < 0)
			{
				num10 = 0;
			}
			if (num11 > Main.MaxTilesX)
			{
				num11 = Main.MaxTilesX;
			}
			if (num12 < 0)
			{
				num12 = 0;
			}
			if (num13 > Main.MaxTilesY)
			{
				num13 = Main.MaxTilesY;
			}
			int num14 = XYWH.X + 4;
			int num15 = XYWH.Y + 4;
			Vector2 vector2 = default;
			for (int l = num10; l < num11; l++)
			{
				for (int m = num12; m < num13; m++)
				{
					if (Main.TileSet[l, m].IsActive != 0 && Main.TileSet[l, m].Type != (int)EntityID.TileID.ICE && Main.TileSolidNotSolidTop[Main.TileSet[l, m].Type])
					{
						vector2.X = l * 16;
						vector2.Y = m * 16;
						if (num14 + 8 > vector2.X && num14 < vector2.X + 16f && num15 + 8 > vector2.Y && num15 < vector2.Y + 16f)
						{
							Kill();
						}
					}
				}
			}
			if (lavaWet)
			{
				Kill();
			}
			if (active == 0)
			{
				return;
			}
			Dust* ptr4 = Main.DustSet.NewDust(67, ref XYWH);
			if (ptr4 != null)
			{
				ptr4->NoGravity = true;
				ptr4->Velocity.X *= 0.3f;
				ptr4->Velocity.Y *= 0.3f;
			}
			int num16 = (int)ai0;
			int num17 = ai1;
			if (velocity.X > 0f)
			{
				rotation += 0.3f;
			}
			else
			{
				rotation -= 0.3f;
			}
			if (!isLocal())
			{
				return;
			}
			int num18 = XYWH.X + (width >> 1) >> 4;
			int num19 = XYWH.Y + (height >> 1) >> 4;
			if ((num18 == num16 && num19 == num17) || (((velocity.X <= 0f && num18 <= num16) || (velocity.X >= 0f && num18 >= num16)) && ((velocity.Y <= 0f && num19 <= num17) || (velocity.Y >= 0f && num19 >= num17))))
			{
				if (WorldGen.PlaceTile(num16, num17, (int)EntityID.TileID.ICE, ToMute: false, IsForced: false, owner))
				{
					NetMessage.CreateMessage5((int)NetMessageId.MSG_WORLD_CHANGED, 1, (int)ai0, ai1, (int)EntityID.TileID.ICE);
					NetMessage.SendMessage();
					damage = 0;
					ai0 = -1f;
					velocity.X = 0f;
					velocity.Y = 0f;
					alpha = 255;
					position.X = (XYWH.X = num16 * 16);
					position.Y = (XYWH.Y = num17 * 16);
					netUpdate = true;
				}
				else
				{
					ai1 = -1;
				}
			}
		}

		private unsafe void FlameAI()
		{
			if (timeLeft > 60)
			{
				timeLeft = 60;
			}
			if (ai0 > 7f)
			{
				float num = 1f;
				if (ai0 == 8f)
				{
					num = 0.25f;
				}
				else if (ai0 == 9f)
				{
					num = 0.5f;
				}
				else if (ai0 == 10f)
				{
					num = 0.75f;
				}
				ai0 += 1f;
				int num2 = ((type == (byte)EntityID.ProjectileID.EYE_FIRE) ? 75 : 6);
				if (num2 == 6 || Main.Rand.Next(3) == 0)
				{
					Dust* ptr = Main.DustSet.NewDust(num2, ref XYWH, velocity.X * 0.2f, velocity.Y * 0.2f, 100);
					if (ptr != null)
					{
						if (Main.Rand.Next(3) != 0 || (num2 == 75 && Main.Rand.Next(3) == 0))
						{
							ptr->NoGravity = true;
							ptr->Scale *= 3f;
							ptr->Velocity.X *= 2f;
							ptr->Velocity.Y *= 2f;
						}
						ptr->Scale *= num * 1.5f;
						ptr->Velocity.X *= 1.2f;
						ptr->Velocity.Y *= 1.2f;
						if (num2 == 75)
						{
							ptr->Velocity.X += velocity.X;
							ptr->Velocity.Y += velocity.Y;
							if (!ptr->NoGravity)
							{
								ptr->Velocity.X *= 0.5f;
								ptr->Velocity.Y *= 0.5f;
							}
						}
					}
				}
			}
			else
			{
				ai0 += 1f;
			}
			rotation += 0.3f * direction;
		}

		private unsafe void CrystalShardAI()
		{
			light = scale * 0.5f;
			rotation += velocity.X * 0.2f;
			ai1++;
			if (type == (byte)EntityID.ProjectileID.CRYSTAL_STORM)
			{
				if (Main.Rand.Next(4) == 0)
				{
					Dust* ptr = Main.DustSet.NewDust(70, ref XYWH);
					if (ptr != null)
					{
						ptr->NoGravity = true;
						ptr->Velocity.X *= 0.5f;
						ptr->Velocity.Y *= 0.5f;
						ptr->Scale *= 0.9f;
					}
				}
				velocity.X *= 0.985f;
				velocity.Y *= 0.985f;
				if (ai1 > 130)
				{
					scale -= 0.05f;
					if (scale <= 0.2)
					{
						scale = 0.2f;
						Kill();
					}
				}
				return;
			}
			velocity.X *= 0.96f;
			velocity.Y *= 0.96f;
			if (ai1 > 15)
			{
				scale -= 0.05f;
				if (scale <= 0.2)
				{
					scale = 0.2f;
					Kill();
				}
			}
		}

		private void BoulderAI()
		{
			if (ai0 != 0f && velocity.Y <= 0f && velocity.X == 0f)
			{
				int i = XYWH.X - 8 >> 4;
				int num = XYWH.Y >> 4;
				bool flag = WorldGen.SolidTile(i, num) || WorldGen.SolidTile(i, num + 1);
				i = XYWH.X + width + 8 >> 4;
				bool flag2 = flag || WorldGen.SolidTile(i, num) || WorldGen.SolidTile(i, num + 1);
				if (flag)
				{
					velocity.X = 0.5f;
				}
				else if (flag2)
				{
					velocity.X = -0.5f;
				}
				else
				{
					i = XYWH.X - 8 - 16 >> 4;
					num = XYWH.Y >> 4;
					flag = WorldGen.SolidTile(i, num) || WorldGen.SolidTile(i, num + 1);
					i = XYWH.X + width + 8 + 16 >> 4;
					flag2 = flag || WorldGen.SolidTile(i, num) || WorldGen.SolidTile(i, num + 1);
					if (flag)
					{
						velocity.X = 0.5f;
					}
					else if (flag2)
					{
						velocity.X = -0.5f;
					}
					else
					{
						i = XYWH.X + 4 >> 4;
						num = XYWH.Y + height + 8 >> 4;
						if (!WorldGen.SolidTile(i, num) && !WorldGen.SolidTile(i, num + 1))
						{
							velocity.X = 0.5f;
						}
						else
						{
							velocity.X = -0.5f;
						}
					}
				}
			}
			rotation += velocity.X * 0.06f;
			ai0 = 1f;
			if (velocity.Y > 16f)
			{
				velocity.Y = 16f;
			}
			else if (velocity.Y <= 6f)
			{
				if (velocity.X > 0f && velocity.X < 7f)
				{
					velocity.X += 0.05f;
				}
				else if (velocity.X < 0f && velocity.X > -7f)
				{
					velocity.X -= 0.05f;
				}
			}
			velocity.Y += 0.3f;
		}

		public unsafe void Kill()
		{
			if (active == 0)
			{
				return;
			}
			timeLeft = 0;
			int num = (XYWH.X = (int)position.X);
			int num2 = (XYWH.Y = (int)position.Y);
			switch ((EntityID.ProjectileID)type)
			{
				case EntityID.ProjectileID.WOODEN_ARROW_FRIENDLY:
				case EntityID.ProjectileID.WOODEN_ARROW_HOSTILE:
				case EntityID.ProjectileID.POISON_DART:
					Main.PlaySound(0, num, num2);
					for (int i = 0; i < 8; i++)
					{
						Main.DustSet.NewDust(7, ref XYWH);
					}
					break;
				case EntityID.ProjectileID.MAGIC_DAGGER:
					Main.PlaySound(0, num, num2);
					for (int j = 0; j < 8; j++)
					{
						Dust* ptr = Main.DustSet.NewDust(57, ref XYWH, 0.0, 0.0, 100, default, 0.5);
						if (ptr == null)
						{
							break;
						}

						ptr->Velocity *= 2f;
					}
					break;
				case EntityID.ProjectileID.BOULDER:
					Main.PlaySound(0, num, num2);
					for (int k = 0; k < 24; k++)
					{
						Dust* ptr2 = Main.DustSet.NewDust(1, ref XYWH);
						if (ptr2 == null)
						{
							break;
						}

						if (Main.Rand.Next(2) == 0)
						{
							ptr2->Scale *= 1.4f;
						}

						velocity.X *= 1.9f;
						velocity.Y *= 1.9f;
					}
					break;
				case EntityID.ProjectileID.HOLY_ARROW:
				case EntityID.ProjectileID.HALLOW_STAR:
					Main.PlaySound(2, num, num2, 10);
					for (int l = 0; l < 8; l++)
					{
						Main.DustSet.NewDust(58, ref XYWH, velocity.X * 0.1f, velocity.Y * 0.1f, 150, default, 1.2f);
					}

					for (int m = 0; m < 3; m++)
					{
						Gore.NewGore(position, new Vector2(velocity.X * 0.05f, velocity.Y * 0.05f), Main.Rand.Next((int)EntityID.GoreID.FALLEN_STAR_PARTICLE1, (int)EntityID.GoreID.FALLEN_STAR_PARTICLE2 + 1));
					}

#if (!IS_PATCHED && VERSION_INITIAL) // I know it is Star-related, but why was this here???
					if (type == (byte)EntityID.ProjectileID.FALLING_STAR && damage < 500)
					{
						for (int n = 0; n < 8; n++)
						{
							Main.DustSet.NewDust(57, ref XYWH, velocity.X * 0.1f, velocity.Y * 0.1f, 150, default(Color), 1.2f);
						}
						for (int num3 = 0; num3 < 3; num3++)
						{
							Gore.NewGore(position, new Vector2(velocity.X * 0.05f, velocity.Y * 0.05f), Main.Rand.Next((int)EntityID.GoreID.FALLEN_STAR_PARTICLE1, (int)EntityID.GoreID.FALLEN_STAR_PARTICLE2 + 1));
						}
					}
#endif
					if ((type == (byte)EntityID.ProjectileID.HOLY_ARROW || (type == (byte)EntityID.ProjectileID.HALLOW_STAR && ai0 > 0f)) && isLocal())
					{
						int num4 = NewClonedProjectile((byte)EntityID.ProjectileID.HALLOW_STAR);
						if (num4 >= 0)
						{
							float num5 = Main.Rand.Next(-400, 400);
							float num6 = -Main.Rand.Next(600, 900);
							Main.ProjectileSet[num4].position.X += num5;
							Main.ProjectileSet[num4].position.Y += num6;
							float num7 = (float)Math.Sqrt(num5 * num5 + num6 * num6);
							num7 = 22f / num7;
							num5 *= num7;
							num6 *= num7;
							Main.ProjectileSet[num4].velocity.X = num5;
							Main.ProjectileSet[num4].velocity.Y = num6;
							if (type == (byte)EntityID.ProjectileID.HOLY_ARROW)
							{
								Main.ProjectileSet[num4].damage >>= 1;
								Main.ProjectileSet[num4].ai0 = 1f;
							}

							Main.ProjectileSet[num4].ai1 = num2;
							NetMessage.SendProjectile(num4);
						}
					}
					break;
				case EntityID.ProjectileID.CRYSTAL_BULLET:
					Main.PlaySound(0, num, num2);
					for (int num8 = 0; num8 < 3; num8++)
					{
						Dust* ptr3 = Main.DustSet.NewDust(68, ref XYWH);
						if (ptr3 == null)
						{
							break;
						}

						ptr3->NoGravity = true;
						ptr3->Velocity.X *= 1.5f;
						ptr3->Velocity.Y *= 1.5f;
						ptr3->Scale *= 0.9f;
					}

					if (isLocal())
					{
						for (int num9 = 0; num9 < 3; num9++)
						{
							float num10 = (0f - velocity.X) * Main.Rand.Next(40, 70) * 0.01f + Main.Rand.Next(-20, 21) * 0.4f;
							float num11 = (0f - velocity.Y) * Main.Rand.Next(40, 70) * 0.01f + Main.Rand.Next(-20, 21) * 0.4f;
							NewProjectile(position.X + num10, position.Y + num11, num10, num11, (byte)EntityID.ProjectileID.CRYSTAL_SHARD, (int)(damage * 0.6), 0f, owner);
						}
					}
					break;
				case EntityID.ProjectileID.ICE_BLOCK:
					if (ai0 >= 0f)
					{
						Main.PlaySound(2, num, num2, 27);
						for (int num12 = 0; num12 < 8; num12++)
						{
							Main.DustSet.NewDust(67, ref XYWH);
						}
					}

					int num13 = num >> 4;
					int num14 = num2 >> 4;
					if (Main.TileSet[num13, num14].Type == (byte)EntityID.TileID.ICE && Main.TileSet[num13, num14].IsActive != 0)
					{
						WorldGen.KillTile(num13, num14);
					}
					break;
				case EntityID.ProjectileID.QUARTER_NOTE:
				case EntityID.ProjectileID.EIGHTH_NOTE:
				case EntityID.ProjectileID.TIED_EIGHTH_NOTE:
					for (int num15 = 0; num15 < 4; num15++)
					{
						Dust* ptr4 = Main.DustSet.NewDust(27, ref XYWH, 0.0, 0.0, 80, default, 1.5);
						if (ptr4 == null)
						{
							break;
						}

						ptr4->NoGravity = true;
					}
					break;
				case EntityID.ProjectileID.STINGER:
					for (int num16 = 0; num16 < 4; num16++)
					{
						Dust* ptr5 = Main.DustSet.NewDust(18, ref XYWH, 0.0, 0.0, 0, default, 1.5);
						if (ptr5 == null)
						{
							break;
						}

						ptr5->NoGravity = true;
					}
					break;
				case EntityID.ProjectileID.SEED:
					Main.PlaySound(0, num, num2);
					for (int num17 = 0; num17 < 4; num17++)
					{
						Main.DustSet.NewDust(0, ref XYWH, 0.0, 0.0, 0, default, 0.7f);
					}
					break;
				case EntityID.ProjectileID.FIRE_ARROW:
				case EntityID.ProjectileID.FLAMING_ARROW:
					Main.PlaySound(0, num, num2);
					for (int num18 = 0; num18 < 16; num18++)
					{
						Main.DustSet.NewDust(6, ref XYWH, 0.0, 0.0, 100);
					}
					break;
				case EntityID.ProjectileID.CURSED_ARROW:
					Main.PlaySound(0, num, num2);
					for (int num19 = 0; num19 < 14; num19++)
					{
						Dust* ptr6 = Main.DustSet.NewDust(75, ref XYWH, 0.0, 0.0, 100);
						if (ptr6 == null)
						{
							break;
						}

						if (Main.Rand.Next(2) == 0)
						{
							ptr6->Scale *= 2.5f;
							ptr6->NoGravity = true;
							ptr6->Velocity.X *= 5f;
							ptr6->Velocity.Y *= 5f;
						}
					}
					break;
				case EntityID.ProjectileID.SHURIKEN:
				case EntityID.ProjectileID.THROWING_KNIFE:
				case EntityID.ProjectileID.POISONED_KNIFE:
					Main.PlaySound(0, num, num2);
					for (int num20 = 0; num20 < 7; num20++)
					{
						Main.DustSet.NewDust(1, ref XYWH, velocity.X * 0.1f, velocity.Y * 0.1f, 0, default, 0.75);
					}
					break;
				case EntityID.ProjectileID.UNHOLY_ARROW:
					Main.PlaySound(0, num, num2);
					for (int num21 = 0; num21 < 7; num21++)
					{
						Main.DustSet.NewDust(14, ref XYWH, 0.0, 0.0, 150, default, 1.1f);
					}
					break;
				case EntityID.ProjectileID.JESTERS_ARROW:
					Main.PlaySound(2, num, num2, 10);
					for (int num22 = 0; num22 < 48; num22++)
					{
						int num23;
						switch (Main.Rand.Next(3))
						{
							case 0:
								num23 = 15;
								break;
							case 1:
								num23 = 57;
								break;
							default:
								num23 = 58;
								break;
						}

						Main.DustSet.NewDust(num23, ref XYWH, velocity.X * 0.5f, velocity.Y * 0.5f, 150, default, 1.5);
					}
					break;
				case EntityID.ProjectileID.STARFURY:
				case EntityID.ProjectileID.FALLING_STAR:
					Main.PlaySound(2, num, num2, 10);
					for (int num24 = 0; num24 < 8; num24++)
					{
						Main.DustSet.NewDust(58, ref XYWH, velocity.X * 0.1f, velocity.Y * 0.1f, 150, default, 1.2);
					}

					for (int num25 = 0; num25 < 3; num25++)
					{
						Gore.NewGore(position, new Vector2(velocity.X * 0.05f, velocity.Y * 0.05f), Main.Rand.Next((int)EntityID.GoreID.FALLEN_STAR_PARTICLE1, (int)EntityID.GoreID.FALLEN_STAR_PARTICLE2 + 1));
					}

					if (type == (byte)EntityID.ProjectileID.FALLING_STAR && damage < 100)
					{
						for (int num26 = 0; num26 < 8; num26++)
						{
							Main.DustSet.NewDust(57, ref XYWH, velocity.X * 0.1f, velocity.Y * 0.1f, 150, default, 1.2);
						}

						for (int num27 = 0; num27 < 3; num27++)
						{
							Gore.NewGore(position, new Vector2(velocity.X * 0.05f, velocity.Y * 0.05f), Main.Rand.Next((int)EntityID.GoreID.FALLEN_STAR_PARTICLE1, (int)EntityID.GoreID.FALLEN_STAR_PARTICLE2 + 1));
						}
					}
					break;
				case EntityID.ProjectileID.BULLET:
				case EntityID.ProjectileID.GREEN_LASER:
				case EntityID.ProjectileID.METEOR_SHOT:
				case EntityID.ProjectileID.EYE_LASER:
				case EntityID.ProjectileID.PINK_LASER:
				case EntityID.ProjectileID.DEATH_LASER:
				case EntityID.ProjectileID.BULLET_SNOWMAN:
					Collision.HitTiles(position, velocity, width, height);
					Main.PlaySound(2, num, num2, 10);
					break;
				case EntityID.ProjectileID.BALL_OF_FIRE:
				case EntityID.ProjectileID.FLAMELASH:
					Main.PlaySound(2, num, num2, 10);
					for (int num28 = 0; num28 < 16; num28++)
					{
						Dust* ptr7 = Main.DustSet.NewDust(6, ref XYWH, velocity.X * -0.2f, velocity.Y * -0.2f, 100, default, 2.0);
						if (ptr7 == null)
						{
							break;
						}

						ptr7->NoGravity = true;
						ptr7->Velocity.X *= 2f;
						ptr7->Velocity.Y *= 2f;
						ptr7 = Main.DustSet.NewDust(6, ref XYWH, velocity.X * -0.2f, velocity.Y * -0.2f, 100);
						if (ptr7 == null)
						{
							break;
						}

						ptr7->Velocity.X *= 2f;
						ptr7->Velocity.Y *= 2f;
					}
					break;
				case EntityID.ProjectileID.CURSED_FLAME_FRIENDLY:
				case EntityID.ProjectileID.CURSED_FLAME_HOSTILE:
					Main.PlaySound(2, num, num2, 10);
					for (int num29 = 0; num29 < 16; num29++)
					{
						Dust* ptr8 = Main.DustSet.NewDust(75, ref XYWH, velocity.X * -0.2f, velocity.Y * -0.2f, 100, default, 2f * scale);
						if (ptr8 == null)
						{
							break;
						}

						ptr8->NoGravity = true;
						ptr8->Velocity.X *= 2f;
						ptr8->Velocity.Y *= 2f;
						ptr8 = Main.DustSet.NewDust(75, ref XYWH, velocity.X * -0.2f, velocity.Y * -0.2f, 100, default, 1f * scale);
						if (ptr8 == null)
						{
							break;
						}

						ptr8->Velocity.X *= 2f;
						ptr8->Velocity.Y *= 2f;
					}
					break;
				case EntityID.ProjectileID.RAINBOW_ROD_BULLET:
					Main.PlaySound(2, num, num2, 10);
					for (int num30 = 0; num30 < 12; num30++)
					{
						Dust* ptr9 = Main.DustSet.NewDust(66, ref XYWH, 0.0, 0.0, 100, new Color(Main.DiscoRGB), 2.0);
						if (ptr9 == null)
						{
							break;
						}

						ptr9->NoGravity = true;
						ptr9->Velocity.X *= 4f;
						ptr9->Velocity.Y *= 4f;
					}
					break;
				case EntityID.ProjectileID.MAGIC_MISSILE:
					Main.PlaySound(2, num, num2, 10);
					for (int num31 = 0; num31 < 12; num31++)
					{
						Dust* ptr10 = Main.DustSet.NewDust((int)(position.X - velocity.X), (int)(position.Y - velocity.Y), width, height, 15, 0.0, 0.0, 100, default, 2.0);
						if (ptr10 == null)
						{
							break;
						}

						ptr10->NoGravity = true;
						ptr10->Velocity.X *= 2f;
						ptr10->Velocity.Y *= 2f;
						Main.DustSet.NewDust((int)(position.X - velocity.X), (int)(position.Y - velocity.Y), width, height, 15, 0.0, 0.0, 100);
					}
					break;
				case EntityID.ProjectileID.DIRT_BALL:
					Main.PlaySound(0, num, num2);
					for (int num32 = 0; num32 < 2; num32++)
					{
						Main.DustSet.NewDust(0, ref XYWH);
					}
					break;
				case EntityID.ProjectileID.SAND_BALL_FALLING:
				case EntityID.ProjectileID.SAND_BALL_GUN:
					Main.PlaySound(0, num, num2);
					for (int num33 = 0; num33 < 2; num33++)
					{
						Dust* ptr11 = Main.DustSet.NewDust(32, ref XYWH);
						if (ptr11 == null)
						{
							break;
						}

						ptr11->Velocity.X *= 0.6f;
						ptr11->Velocity.Y *= 0.6f;
					}
					break;
				case EntityID.ProjectileID.SNOW_BALL_HOSTILE:
					Main.PlaySound(0, num, num2);
					for (int num34 = 0; num34 < 3; num34++)
					{
						Dust* ptr12 = Main.DustSet.NewDust(51, ref XYWH, 0.0, 0.0, 0, default, 0.6);
						if (ptr12 == null)
						{
							break;
						}

						ptr12->Velocity.X *= 0.6f;
						ptr12->Velocity.Y *= 0.6f;
					}
					break;
				case EntityID.ProjectileID.MUD_BALL:
					Main.PlaySound(0, num, num2);
					for (int num35 = 0; num35 < 3; num35++)
					{
						Dust* ptr13 = Main.DustSet.NewDust(38, ref XYWH);
						if (ptr13 == null)
						{
							break;
						}

						ptr13->Velocity.X *= 0.6f;
						ptr13->Velocity.Y *= 0.6f;
					}
					break;
				case EntityID.ProjectileID.SILT_BALL:
					Main.PlaySound(0, num, num2);
					for (int num36 = 0; num36 < 3; num36++)
					{
						Dust* ptr14 = Main.DustSet.NewDust(53, ref XYWH);
						if (ptr14 == null)
						{
							break;
						}

						ptr14->Velocity.X *= 0.6f;
						ptr14->Velocity.Y *= 0.6f;
					}
					break;
				case EntityID.ProjectileID.ASH_BALL_FALLING:
					Main.PlaySound(0, num, num2);
					for (int num37 = 0; num37 < 3; num37++)
					{
						Dust* ptr15 = Main.DustSet.NewDust(36, ref XYWH);
						if (ptr15 == null)
						{
							break;
						}

						ptr15->Velocity.X *= 0.6f;
						ptr15->Velocity.Y *= 0.6f;
					}
					break;
				case EntityID.ProjectileID.BONE:
					Main.PlaySound(0, num, num2);
					for (int num38 = 0; num38 < 8; num38++)
					{
						Main.DustSet.NewDust(26, ref XYWH, 0.0, 0.0, 0, default, 0.8);
					}
					break;
				case EntityID.ProjectileID.SPIKY_BALL:
					for (int num39 = 0; num39 < 6; num39++)
					{
						Main.DustSet.NewDust(1, ref XYWH, velocity.X * 0.1f, velocity.Y * 0.1f, 0, default, 0.75);
					}
					break;
				case EntityID.ProjectileID.WATER_BOLT:
					Main.PlaySound(2, num, num2, 10);
					for (int num40 = 0; num40 < 20; num40++)
					{
						Dust* ptr16 = Main.DustSet.NewDust(29, ref XYWH, velocity.X * 0.1f, velocity.Y * 0.1f, 100, default, 3.0);
						if (ptr16 == null)
						{
							break;
						}

						ptr16->NoGravity = true;
						Main.DustSet.NewDust(29, ref XYWH, velocity.X * 0.1f, velocity.Y * 0.1f, 100, default, 2.0);
					}
					break;
				case EntityID.ProjectileID.HARPY_FEATHER:
					for (int num41 = 0; num41 < 6; num41++)
					{
						Main.DustSet.NewDust(42, ref XYWH, velocity.X * 0.1f, velocity.Y * 0.1f);
					}
					break;
				case EntityID.ProjectileID.DEMON_SICKLE:
				case EntityID.ProjectileID.DEMON_SCYTHE:
					Main.PlaySound(2, num, num2, 10);
					for (int num42 = 0; num42 < 18; num42++)
					{
						Dust* ptr17 = Main.DustSet.NewDust(27, ref XYWH, velocity.X, velocity.Y, 100, default, 1.7);
						if (ptr17 == null)
						{
							break;
						}

						ptr17->NoGravity = true;
						Main.DustSet.NewDust(27, ref XYWH, velocity.X, velocity.Y, 100);
					}
					break;
				case EntityID.ProjectileID.HELLFIRE_ARROW:
				case EntityID.ProjectileID.VULCAN_BOLT:
					// While there is an entry for a Vulcan bolt, there is not one for a Spectral arrow.
					Main.PlaySound(2, num, num2, 14);
					for (int num43 = 0; num43 < 6; num43++)
					{
						Dust* ptr18 = Main.DustSet.NewDust(31, ref XYWH, 0.0, 0.0, 100, default, 1.5);
						if (ptr18 == null)
						{
							break;
						}
					}

					int num44 = ((type == (byte)EntityID.ProjectileID.VULCAN_BOLT) ? 64 : 6);
					for (int num45 = 0; num45 < 3; num45++)
					{
						Dust* ptr18 = Main.DustSet.NewDust(num44, ref XYWH, 0.0, 0.0, 100, default, 2.5);
						if (ptr18 == null)
						{
							break;
						}

						ptr18->NoGravity = true;
						ptr18->Velocity.X *= 3f;
						ptr18->Velocity.Y *= 3f;
						ptr18 = Main.DustSet.NewDust(num44, ref XYWH, 0.0, 0.0, 100, default, 1.5);
						if (ptr18 == null)
						{
							break;
						}

						ptr18->Velocity.X *= 2f;
						ptr18->Velocity.Y *= 2f;
					}

					int num46 = Gore.NewGore(position, default, Main.Rand.Next((int)EntityID.GoreID.SMOKE_WHITE1, (int)EntityID.GoreID.SMOKE_WHITE3 + 1));
					Main.GoreSet[num46].Velocity *= 0.4f;
					Main.GoreSet[num46].Velocity.X += Main.Rand.Next(-10, 11) * 0.1f;
					Main.GoreSet[num46].Velocity.Y += Main.Rand.Next(-10, 11) * 0.1f;
					num46 = Gore.NewGore(position, default, Main.Rand.Next((int)EntityID.GoreID.SMOKE_WHITE1, (int)EntityID.GoreID.SMOKE_WHITE3 + 1));
					Main.GoreSet[num46].Velocity *= 0.4f;
					Main.GoreSet[num46].Velocity.X += Main.Rand.Next(-10, 11) * 0.1f;
					Main.GoreSet[num46].Velocity.Y += Main.Rand.Next(-10, 11) * 0.1f;
					if (isLocal())
					{
						penetrate = -1;
						position.X += width >> 1;
						position.Y += height >> 1;
						XYWH.Width = (width = 64);
						XYWH.Height = (height = 64);
						position.X -= width >> 1;
						position.Y -= height >> 1;
						num = (XYWH.X = (int)position.X);
						num2 = (XYWH.Y = (int)position.Y);
						Damage();
					}
					break;
				case EntityID.ProjectileID.BOMB:
				case EntityID.ProjectileID.GRENADE:
				case EntityID.ProjectileID.STICKY_BOMB:
				case EntityID.ProjectileID.HAPPY_BOMB:
				case EntityID.ProjectileID.BOMB_SKELETRON_PRIME:
					Main.PlaySound(2, num, num2, 14);
					position.X += width >> 1;
					position.Y += height >> 1;
					XYWH.Width = (width = 22);
					XYWH.Height = (height = 22);
					position.X -= width >> 1;
					position.Y -= height >> 1;
					num = (XYWH.X = (int)position.X);
					num2 = (XYWH.Y = (int)position.Y);
					for (int num47 = 0; num47 < 16; num47++)
					{
						Dust* ptr19 = Main.DustSet.NewDust(31, ref XYWH, 0.0, 0.0, 100, default, 1.5);
						if (ptr19 == null)
						{
							break;
						}

						ptr19->Velocity.X *= 1.4f;
						ptr19->Velocity.Y *= 1.4f;
					}

					for (int num48 = 0; num48 < 7; num48++)
					{
						Dust* ptr20 = Main.DustSet.NewDust(6, ref XYWH, 0.0, 0.0, 100, default, 2.5);
						if (ptr20 == null)
						{
							break;
						}

						ptr20->NoGravity = true;
						ptr20->Velocity.X *= 5f;
						ptr20->Velocity.Y *= 5f;
						ptr20 = Main.DustSet.NewDust(6, ref XYWH, 0.0, 0.0, 100, default, 1.5);
						if (ptr20 == null)
						{
							break;
						}

						ptr20->Velocity.X *= 3f;
						ptr20->Velocity.Y *= 3f;
					}

					int num49 = Gore.NewGore(position, default, Main.Rand.Next((int)EntityID.GoreID.SMOKE_WHITE1, (int)EntityID.GoreID.SMOKE_WHITE3 + 1));
					Main.GoreSet[num49].Velocity *= 0.4f;
					Main.GoreSet[num49].Velocity.X += 1f;
					Main.GoreSet[num49].Velocity.Y += 1f;
					num49 = Gore.NewGore(position, default, Main.Rand.Next((int)EntityID.GoreID.SMOKE_WHITE1, (int)EntityID.GoreID.SMOKE_WHITE3 + 1));
					Main.GoreSet[num49].Velocity *= 0.4f;
					Main.GoreSet[num49].Velocity.X -= 1f;
					Main.GoreSet[num49].Velocity.Y += 1f;
					num49 = Gore.NewGore(position, default, Main.Rand.Next((int)EntityID.GoreID.SMOKE_WHITE1, (int)EntityID.GoreID.SMOKE_WHITE3 + 1));
					Main.GoreSet[num49].Velocity *= 0.4f;
					Main.GoreSet[num49].Velocity.X += 1f;
					Main.GoreSet[num49].Velocity.Y -= 1f;
					num49 = Gore.NewGore(position, default, Main.Rand.Next((int)EntityID.GoreID.SMOKE_WHITE1, (int)EntityID.GoreID.SMOKE_WHITE3 + 1));
					Main.GoreSet[num49].Velocity *= 0.4f;
					Main.GoreSet[num49].Velocity.X -= 1f;
					Main.GoreSet[num49].Velocity.Y -= 1f;
					break;
				case EntityID.ProjectileID.DYNAMITE:
				case EntityID.ProjectileID.EXPLOSIVES:
					Main.PlaySound(2, num, num2, 14);
					if (type == (byte)EntityID.ProjectileID.DYNAMITE)
					{
						position.X += (width >> 1) - 100;
						position.Y += (height >> 1) - 100;
						num = (XYWH.X = (int)position.X);
						num2 = (XYWH.Y = (int)position.Y);
						XYWH.Width = (width = 200);
						XYWH.Height = (height = 200);
					}

					for (int num50 = 0; num50 < 40; num50++)
					{
						Dust* ptr21 = Main.DustSet.NewDust(31, ref XYWH, 0.0, 0.0, 100, default, 2.0);
						if (ptr21 == null)
						{
							break;
						}

						ptr21->Velocity.X *= 1.4f;
						ptr21->Velocity.Y *= 1.4f;
					}

					for (int num51 = 0; num51 < 64; num51++)
					{
						Dust* ptr22 = Main.DustSet.NewDust(6, ref XYWH, 0.0, 0.0, 100, default, 3.0);
						if (ptr22 == null)
						{
							break;
						}

						ptr22->NoGravity = true;
						ptr22->Velocity.X *= 5f;
						ptr22->Velocity.Y *= 5f;
						ptr22 = Main.DustSet.NewDust(6, ref XYWH, 0.0, 0.0, 100, default, 2.0);
						if (ptr22 == null)
						{
							break;
						}

						ptr22->Velocity.X *= 3f;
						ptr22->Velocity.Y *= 3f;
					}

					for (int num52 = 0; num52 < 2; num52++)
					{
						int num53 = Gore.NewGore(num + (width >> 1) - 24, num2 + (height >> 1) - 24, default, Main.Rand.Next((int)EntityID.GoreID.SMOKE_WHITE1, (int)EntityID.GoreID.SMOKE_WHITE3 + 1));
						Main.GoreSet[num53].Scale = 1.5f;
						Main.GoreSet[num53].Velocity.X += 1.5f;
						Main.GoreSet[num53].Velocity.Y += 1.5f;
						num53 = Gore.NewGore(num + (width >> 1) - 24, num2 + (height >> 1) - 24, default, Main.Rand.Next((int)EntityID.GoreID.SMOKE_WHITE1, (int)EntityID.GoreID.SMOKE_WHITE3 + 1));
						Main.GoreSet[num53].Scale = 1.5f;
						Main.GoreSet[num53].Velocity.X -= 1.5f;
						Main.GoreSet[num53].Velocity.Y += 1.5f;
						num53 = Gore.NewGore(num + (width >> 1) - 24, num2 + (height >> 1) - 24, default, Main.Rand.Next((int)EntityID.GoreID.SMOKE_WHITE1, (int)EntityID.GoreID.SMOKE_WHITE3 + 1));
						Main.GoreSet[num53].Scale = 1.5f;
						Main.GoreSet[num53].Velocity.X += 1.5f;
						Main.GoreSet[num53].Velocity.Y -= 1.5f;
						num53 = Gore.NewGore(num + (width >> 1) - 24, num2 + (height >> 1) - 24, default, Main.Rand.Next((int)EntityID.GoreID.SMOKE_WHITE1, (int)EntityID.GoreID.SMOKE_WHITE3 + 1));
						Main.GoreSet[num53].Scale = 1.5f;
						Main.GoreSet[num53].Velocity.X -= 1.5f;
						Main.GoreSet[num53].Velocity.Y -= 1.5f;
					}

					position.X += (width >> 1) - 5;
					position.Y += (height >> 1) - 5;
					num = (XYWH.X = (int)position.X);
					num2 = (XYWH.Y = (int)position.Y);
					XYWH.Width = (width = 10);
					XYWH.Height = (height = 10);
					break;
				case EntityID.ProjectileID.HOLY_WATER:
					Main.PlaySound(13, num, num2);
					for (int num54 = 0; num54 < 3; num54++)
					{
						Main.DustSet.NewDust(num, num2, width, height, 13);
					}

					for (int num55 = 0; num55 < 20; num55++)
					{
						Dust* ptr23 = Main.DustSet.NewDust(num, num2, width, height, 33, 0.0, -2.0, 0, default, 1.1);
						if (ptr23 == null)
						{
							break;
						}

						ptr23->Alpha = 100;
						ptr23->Velocity.X *= 4.5f;
						ptr23->Velocity.Y *= 3f;
					}
					break;
				case EntityID.ProjectileID.UNHOLY_WATER:
					Main.PlaySound(13, num, num2);
					for (int num56 = 0; num56 < 3; num56++)
					{
						Main.DustSet.NewDust(num, num2, width, height, 13);
					}

					for (int num57 = 0; num57 < 20; num57++)
					{
						Dust* ptr24 = Main.DustSet.NewDust(num, num2, width, height, 52, 0.0, -2.0, 0, default, 1.1);
						if (ptr24 == null)
						{
							break;
						}

						ptr24->Alpha = 100;
						ptr24->Velocity.X *= 4.5f;
						ptr24->Velocity.Y *= 3f;
					}
					break;
				case EntityID.ProjectileID.PET_BUNNY:
				case EntityID.ProjectileID.PET_SLIME:
				case EntityID.ProjectileID.PET_TIPHIA:
				case EntityID.ProjectileID.PET_BAT:
				case EntityID.ProjectileID.PET_WEREWOLF:
				case EntityID.ProjectileID.PET_ZOMBIE:
					int num58 = Gore.NewGore(new Vector2(num - (width >> 1), num2 - (height >> 1)), default, Main.Rand.Next((int)EntityID.GoreID.SMOKE_BLUE1, (int)EntityID.GoreID.SMOKE_BLUE3 + 1), scale);
					Main.GoreSet[num58].Velocity *= 0.1f;
					break;
			}
			if (isLocal())
			{
				if (type == (byte)EntityID.ProjectileID.BOMB || type == (byte)EntityID.ProjectileID.DYNAMITE || type == (byte)EntityID.ProjectileID.STICKY_BOMB || type == (byte)EntityID.ProjectileID.HAPPY_BOMB || type == (byte)EntityID.ProjectileID.EXPLOSIVES)
				{
					int num59 = 3;
					if (type == (byte)EntityID.ProjectileID.DYNAMITE)
					{
						num59 = 7;
					}
					else if (type == (byte)EntityID.ProjectileID.EXPLOSIVES)
					{
						num59 = 10;
					}
					int num60 = num >> 4;
					int num61 = num2 >> 4;
					int num62 = num60 - num59;
					int num63 = num60 + num59;
					int num64 = num61 - num59;
					int num65 = num61 + num59;
					if (num62 < 0)
					{
						num62 = 0;
					}
					if (num63 > Main.MaxTilesX)
					{
						num63 = Main.MaxTilesX;
					}
					if (num64 < 0)
					{
						num64 = 0;
					}
					if (num65 > Main.MaxTilesY)
					{
						num65 = Main.MaxTilesY;
					}
					bool flag = false;
					for (int num66 = num62; num66 <= num63; num66++)
					{
						for (int num67 = num64; num67 <= num65; num67++)
						{
							int num68 = Math.Abs(num66 - num60);
							int num69 = Math.Abs(num67 - num61);
							int num70 = num68 * num68 + num69 * num69;
							if (num70 < num59 * num59 && Main.TileSet[num66, num67].WallType == (byte)EntityID.WallID.NONE)
							{
								flag = true;
								break;
							}
						}
					}
					for (int num71 = num62; num71 <= num63; num71++)
					{
						for (int num72 = num64; num72 <= num65; num72++)
						{
							int num73 = Math.Abs(num71 - num60);
							int num74 = Math.Abs(num72 - num61);
							int num75 = num73 * num73 + num74 * num74;
							if (num75 >= num59 * num59)
							{
								continue;
							}
							bool flag2 = true;
							if (Main.TileSet[num71, num72].IsActive != 0)
							{
								int num76 = Main.TileSet[num71, num72].Type;
								if (num76 == (byte)EntityID.TileID.CHEST || num76 == (byte)EntityID.TileID.DEMON_ALTAR || num76 == (byte)EntityID.TileID.COBALT_ORE || num76 == (byte)EntityID.TileID.MYTHRIL_ORE || num76 == (byte)EntityID.TileID.ADAMANTITE_ORE || Main.TileDungeon[num76])
								{
									flag2 = false;
								}
								else if (num76 == (byte)EntityID.TileID.HELLSTONE && !Main.InHardMode)
								{
									flag2 = false;
								}
								else if (WorldGen.KillTile(num71, num72))
								{
									NetMessage.CreateMessage5((int)NetMessageId.MSG_WORLD_CHANGED, 0, num71, num72, 0);
									NetMessage.SendMessage();
								}
							}
							if (!flag2 || !flag)
							{
								continue;
							}
							for (int num77 = num71 - 1; num77 <= num71 + 1; num77++)
							{
								for (int num78 = num72 - 1; num78 <= num72 + 1; num78++)
								{
									if (Main.TileSet[num77, num78].WallType > 0)
									{
										WorldGen.KillWall(num77, num78);
										if (Main.TileSet[num77, num78].WallType == (byte)EntityID.WallID.NONE)
										{
											NetMessage.CreateMessage5((int)NetMessageId.MSG_WORLD_CHANGED, 2, num77, num78, 0);
											NetMessage.SendMessage();
										}
									}
								}
							}
						}
					}
				}
				NetMessage.CreateMessage2(29, identity, owner);
				NetMessage.SendMessage();
				int num79 = -1;
				if (aiStyle == (byte)EntityID.ProjStyleID.DIRT_BALL)
				{
					int num80 = 0;
					int num81 = 0;
					switch ((EntityID.ProjectileID)type)
					{
						case EntityID.ProjectileID.SAND_BALL_FALLING:
						case EntityID.ProjectileID.SAND_BALL_GUN:
							num80 = (byte)EntityID.TileID.SAND;
							break;
						case EntityID.ProjectileID.MUD_BALL:
							num80 = (byte)EntityID.TileID.MUD;
							num81 = (int)EntityID.ItemID.MUD_BLOCK;
							break;
						case EntityID.ProjectileID.ASH_BALL_FALLING:
							num80 = (byte)EntityID.TileID.ASH;
							num81 = (int)EntityID.ItemID.ASH_BLOCK;
							break;
						case EntityID.ProjectileID.EBONSAND_BALL_FALLING:
						case EntityID.ProjectileID.EBONSAND_BALL_GUN:
							num80 = (byte)EntityID.TileID.EBONSAND;
							break;
						case EntityID.ProjectileID.PEARL_SAND_BALL_FALLING:
						case EntityID.ProjectileID.PEARL_SAND_BALL_GUN:
							num80 = (byte)EntityID.TileID.PEARLSAND;
							break;
						case EntityID.ProjectileID.SILT_BALL:
							num80 = (byte)EntityID.TileID.SILT;
							break;
						case EntityID.ProjectileID.SNOW_BALL_HOSTILE:
							num80 = (byte)EntityID.TileID.SNOW;
							break;
						default:
							num79 = Item.NewItem(num, num2, width, height, (int)EntityID.ItemID.DIRT_BLOCK);
							break;
					}

					if (num80 > 0)
					{
						int num82 = num + (width >> 1) >> 4;
						int num83 = num2 + (width >> 1) >> 4;
						if (Main.TileSet[num82, num83].IsActive == 0 && WorldGen.PlaceTile(num82, num83, num80, ToMute: false, IsForced: true))
						{
							NetMessage.CreateMessage5((int)NetMessageId.MSG_WORLD_CHANGED, 1, num82, num83, num80);
							NetMessage.SendMessage();
						}
						else if (num81 > 0)
						{
							num79 = Item.NewItem(num, num2, width, height, num81);
						}
					}
				}
				if (type == (byte)EntityID.ProjectileID.WOODEN_ARROW_FRIENDLY)
				{
					if (Main.Rand.Next(3) == 0)
					{
						num79 = Item.NewItem(num, num2, width, height, (int)EntityID.ItemID.WOODEN_ARROW);
					}
				}
				else if (type == (byte)EntityID.ProjectileID.FIRE_ARROW)
				{
					if (Main.Rand.Next(3) == 0)
					{
						num79 = ((Main.Rand.Next(3) != 0) ? Item.NewItem(num, num2, width, height, (int)EntityID.ItemID.WOODEN_ARROW) : Item.NewItem(num, num2, width, height, (int)EntityID.ItemID.FLAMING_ARROW));
					}
				}
				else if (type == (byte)EntityID.ProjectileID.CURSED_ARROW)
				{
					if (Main.Rand.Next(6) == 0)
					{
						num79 = ((Main.Rand.Next(3) != 0) ? Item.NewItem(num, num2, width, height, (int)EntityID.ItemID.WOODEN_ARROW) : Item.NewItem(num, num2, width, height, (int)EntityID.ItemID.CURSED_ARROW));
					}
				}
				else if (type == (byte)EntityID.ProjectileID.SPECTRAL_ARROW)
				{
					if (Main.Rand.Next(4) == 0)
					{
						num79 = Item.NewItem(num, num2, width, height, (int)EntityID.ItemID.SPECTRAL_ARROW);
					}
				}
				else if (type == (byte)EntityID.ProjectileID.HOLY_ARROW && Main.Rand.Next(6) == 0)
				{
					num79 = Item.NewItem(num, num2, width, height, (int)EntityID.ItemID.HOLY_ARROW);
				}
				else if (type == (byte)EntityID.ProjectileID.GLOWSTICK && Main.Rand.Next(3) == 0)
				{
					num79 = Item.NewItem(num, num2, width, height, (int)EntityID.ItemID.GLOWSTICK);
				}
				else if (type == (byte)EntityID.ProjectileID.STICKY_GLOWSTICK && Main.Rand.Next(3) == 0)
				{
					num79 = Item.NewItem(num, num2, width, height, (int)EntityID.ItemID.STICKY_GLOWSTICK);
				}
				else if (type == (byte)EntityID.ProjectileID.THROWING_KNIFE && Main.Rand.Next(2) == 0)
				{
					num79 = Item.NewItem(num, num2, width, height, (int)EntityID.ItemID.THROWING_KNIFE);
				}
				else if (type == (byte)EntityID.ProjectileID.POISONED_KNIFE && Main.Rand.Next(2) == 0)
				{
					num79 = Item.NewItem(num, num2, width, height, (int)EntityID.ItemID.POISONED_KNIFE);
				}
				else if (type == (byte)EntityID.ProjectileID.SHURIKEN && Main.Rand.Next(2) == 0)
				{
					num79 = Item.NewItem(num, num2, width, height, (int)EntityID.ItemID.SHURIKEN);
				}
				else if (type == (byte)EntityID.ProjectileID.UNHOLY_ARROW && Main.Rand.Next(4) == 0)
				{
					num79 = Item.NewItem(num, num2, width, height, (int)EntityID.ItemID.UNHOLY_ARROW);
				}
				else if (type == (byte)EntityID.ProjectileID.FALLING_STAR && damage > 100)
				{
					// BUG: If you can manage to increase the Star Cannon's power to beyond 100, fired stars will be reusable at night. This bug is present in all Pre-1.3 versions, despite PC 1.2 fixing it.
					// This will functionally provide the user with limitless ammo, as it will always drop a star upon firing and occasionally never use a star, due to the >=100 damage condition almost always requiring a loadout with an ammo-saving chance. 
					num79 = Item.NewItem(num, num2, width, height, (int)EntityID.ItemID.FALLEN_STAR);
				}
				else if (type == (byte)EntityID.ProjectileID.HOLY_WATER || type == (byte)EntityID.ProjectileID.UNHOLY_WATER)
				{
					int num84 = num + (width >> 1) >> 4;
					int num85 = num2 + (height >> 1) >> 4;
					for (int num86 = num84 - 4; num86 <= num84 + 4; num86++)
					{
						for (int num87 = num85 - 4; num87 <= num85 + 4; num87++)
						{
							if (Math.Abs(num86 - num84) + Math.Abs(num87 - num85) >= 6)
							{
								continue;
							}
							int num88 = Main.TileSet[num86, num87].Type;
							int num89 = 0;
							if (type == (byte)EntityID.ProjectileID.HOLY_WATER)
							{
								switch ((EntityID.TileID)num88)
								{
									case EntityID.TileID.GRASS:
									case EntityID.TileID.CORRUPT_GRASS:
										num89 = (int)EntityID.TileID.HALLOWED_GRASS;
										break;
									case EntityID.TileID.STONE:
									case EntityID.TileID.EBONSTONE:
										num89 = (int)EntityID.TileID.PEARLSTONE;
										break;
									case EntityID.TileID.SAND:
									case EntityID.TileID.EBONSAND:
										num89 = (int)EntityID.TileID.PEARLSAND;
										break;
								}
							}
							else
							{
								switch ((EntityID.TileID)num88)
								{
									case EntityID.TileID.GRASS:
									case EntityID.TileID.HALLOWED_GRASS:
										num89 = (int)EntityID.TileID.CORRUPT_GRASS;
										break;
									case EntityID.TileID.STONE:
									case EntityID.TileID.PEARLSTONE:
										num89 = (int)EntityID.TileID.EBONSTONE;
										break;
									case EntityID.TileID.SAND:
									case EntityID.TileID.PEARLSAND:
										num89 = (int)EntityID.TileID.EBONSAND;
										break;
								}
							}
							if (num89 > 0)
							{
								Main.TileSet[num86, num87].Type = (byte)num89;
								WorldGen.SquareTileFrame(num86, num87);
								NetMessage.SendTile(num86, num87);
							}
						}
					}
				}
				else if (type == (byte)EntityID.ProjectileID.BONE && Main.Rand.Next(2) == 0)
				{
					num79 = Item.NewItem(num, num2, width, height, (int)EntityID.ItemID.BONE);
				}
				if (num79 >= 0)
				{
					NetMessage.CreateMessage2(21, UI.MainUI.MyPlayer, num79);
					NetMessage.SendMessage();
				}
			}
			active = 0;
		}

		public Color GetAlpha(Color newColor)
		{
			if (type == (byte)EntityID.ProjectileID.FLAMELASH || type == (byte)EntityID.ProjectileID.BALL_OF_FIRE || type == (byte)EntityID.ProjectileID.MAGIC_DAGGER || type == (byte)EntityID.ProjectileID.CRYSTAL_STORM || type == (byte)EntityID.ProjectileID.CURSED_FLAME_FRIENDLY || type == (byte)EntityID.ProjectileID.CURSED_FLAME_HOSTILE || (type == (byte)EntityID.ProjectileID.BOMB_SKELETRON_PRIME && alpha < 255))
			{
				return new Color(200, 200, 200, 25);
			}
			if (type == (byte)EntityID.ProjectileID.EYE_LASER || type == (byte)EntityID.ProjectileID.PURPLE_LASER || type == (byte)EntityID.ProjectileID.CRYSTAL_BULLET || type == (byte)EntityID.ProjectileID.CRYSTAL_SHARD || type == (byte)EntityID.ProjectileID.DEATH_LASER || type == (byte)EntityID.ProjectileID.CURSED_BULLET)
			{
				if (alpha < 200)
				{
					return new Color(255 - alpha, 255 - alpha, 255 - alpha, 0);
				}
				return default;
			}
			if (type == (byte)EntityID.ProjectileID.FLAMELASH || type == (byte)EntityID.ProjectileID.SUNFURY || type == (byte)EntityID.ProjectileID.BALL_OF_FIRE || type == (byte)EntityID.ProjectileID.FLAMARANG || type == (byte)EntityID.ProjectileID.DEMON_SICKLE || type == (byte)EntityID.ProjectileID.DEMON_SCYTHE)
			{
				return Color.White;
			}
			if (type == (byte)EntityID.ProjectileID.RAINBOW_ROD_BULLET)
			{
				return default;
			}
			int r;
			int g;
			int b;
			if (type == (byte)EntityID.ProjectileID.STARFURY || type == (byte)EntityID.ProjectileID.BALL_OF_FIRE || type == (byte)EntityID.ProjectileID.FLAMELASH || type == (byte)EntityID.ProjectileID.GLOWSTICK || type == (byte)EntityID.ProjectileID.STICKY_GLOWSTICK || type == (byte)EntityID.ProjectileID.QUARTER_NOTE || type == (byte)EntityID.ProjectileID.EIGHTH_NOTE || type == (byte)EntityID.ProjectileID.TIED_EIGHTH_NOTE || type == (byte)EntityID.ProjectileID.HALLOW_STAR || type == (byte)EntityID.ProjectileID.HOLY_ARROW)
			{
				r = newColor.R - alpha / 3;
				g = newColor.G - alpha / 3;
				b = newColor.B - alpha / 3;
			}
			else if (type == (byte)EntityID.ProjectileID.MAGIC_MISSILE || type == (byte)EntityID.ProjectileID.SHADOW_ORB || type == (byte)EntityID.ProjectileID.DEMON_SICKLE || type == (byte)EntityID.ProjectileID.DEMON_SCYTHE)
			{
				r = newColor.R;
				g = newColor.G;
				b = newColor.B;
			}
			else
			{
				if (type == (byte)EntityID.ProjectileID.FALLING_STAR || type == (byte)EntityID.ProjectileID.BLUE_FAIRY || type == (byte)EntityID.ProjectileID.PINK_FAIRY || type == (byte)EntityID.ProjectileID.GREEN_FAIRY)
				{
					return new Color(255, 255, 255, newColor.A - alpha);
				}
				r = newColor.R - alpha;
				g = newColor.G - alpha;
				b = newColor.B - alpha;
			}
			int num = newColor.A - alpha;
			if (num < 0)
			{
				num = 0;
			}
			if (num > 255)
			{
				num = 255;
			}
			return new Color(r, g, b, num);
		}

		public unsafe void Draw(WorldView view)
		{
			Player player = Main.PlayerSet[owner];
			Vector2 pos;
			if (type == (byte)EntityID.ProjectileID.IVY_WHIP)
			{
				Vector2 vector = new Vector2(position.X + width * 0.5f, position.Y + height * 0.5f);
				float num = player.Position.X + 10f - vector.X;
				float num2 = player.Position.Y + 21f - vector.Y;
				float rotCenter = (float)Math.Atan2(num2, num) - 1.57f;
				bool flag = true;
				if (num == 0f && num2 == 0f)
				{
					flag = false;
				}
				else
				{
					float num3 = (float)Math.Sqrt(num * num + num2 * num2);
					num3 = 8f / num3;
					num *= num3;
					num2 *= num3;
					vector.X -= num;
					vector.Y -= num2;
					num = player.Position.X + 10f - vector.X;
					num2 = player.Position.Y + 21f - vector.Y;
				}
				while (flag)
				{
					float num4 = num * num + num2 * num2;
					if (num4 < 784f)
					{
						flag = false;
						continue;
					}
					float num5 = 28f / (float)Math.Sqrt(num4);
					num *= num5;
					num2 *= num5;
					vector.X += num;
					vector.Y += num2;
					num = player.Position.X + 10f - vector.X;
					num2 = player.Position.Y + 21f - vector.Y;
					pos = vector;
					pos.X -= view.ScreenPosition.X;
					pos.Y -= view.ScreenPosition.Y;
					SpriteSheet<_sheetSprites>.DrawRotated((int)_sheetSprites.ID.CHAIN5, ref pos, view.Lighting.GetColor((int)vector.X >> 4, (int)vector.Y >> 4), rotCenter);
				}
			}
			else if (type == (byte)EntityID.ProjectileID.DUAL_HOOK_BLUE)
			{
				Vector2 vector2 = new Vector2(position.X + width * 0.5f, position.Y + height * 0.5f);
				float num6 = player.Position.X + 10f - vector2.X;
				float num7 = player.Position.Y + 21f - vector2.Y;
				float rotCenter2 = (float)Math.Atan2(num7, num6) - 1.57f;
				bool flag2 = true;
				while (flag2)
				{
					float num8 = num6 * num6 + num7 * num7;
					if (num8 < 625f)
					{
						flag2 = false;
						continue;
					}
					float num9 = 12f / (float)Math.Sqrt(num8);
					num6 *= num9;
					num7 *= num9;
					vector2.X += num6;
					vector2.Y += num7;
					num6 = player.Position.X + 10f - vector2.X;
					num7 = player.Position.Y + 21f - vector2.Y;
					pos = vector2;
					pos.X -= view.ScreenPosition.X;
					pos.Y -= view.ScreenPosition.Y;
					SpriteSheet<_sheetSprites>.DrawRotated((int)_sheetSprites.ID.CHAIN8, ref pos, view.Lighting.GetColor((int)vector2.X >> 4, (int)vector2.Y >> 4), rotCenter2);
				}
			}
			else if (type == (byte)EntityID.ProjectileID.DUAL_HOOK_RED)
			{
				Vector2 vector3 = new Vector2(position.X + width * 0.5f, position.Y + height * 0.5f);
				float num10 = player.Position.X + 10f - vector3.X;
				float num11 = player.Position.Y + 21f - vector3.Y;
				float rotCenter3 = (float)Math.Atan2(num11, num10) - 1.57f;
				bool flag3 = true;
				while (flag3)
				{
					float num12 = num10 * num10 + num11 * num11;
					if (num12 < 625f)
					{
						flag3 = false;
						continue;
					}
					float num13 = 12f / (float)Math.Sqrt(num12);
					num10 *= num13;
					num11 *= num13;
					vector3.X += num10;
					vector3.Y += num11;
					num10 = player.Position.X + 10f - vector3.X;
					num11 = player.Position.Y + 21f - vector3.Y;
					pos = vector3;
					pos.X -= view.ScreenPosition.X;
					pos.Y -= view.ScreenPosition.Y;
					SpriteSheet<_sheetSprites>.DrawRotated((int)_sheetSprites.ID.CHAIN9, ref pos, view.Lighting.GetColor((int)vector3.X >> 4, (int)vector3.Y >> 4), rotCenter3);
				}
			}
			else if (aiStyle == (byte)EntityID.ProjStyleID.GRAPPLING_HOOK)
			{
				Vector2 vector4 = new Vector2(position.X + width * 0.5f, position.Y + height * 0.5f);
				float num14 = player.Position.X + 10f - vector4.X;
				float num15 = player.Position.Y + 21f - vector4.Y;
				float rotCenter4 = (float)Math.Atan2(num15, num14) - 1.57f;
				bool flag4 = true;
				while (flag4)
				{
					float num16 = num14 * num14 + num15 * num15;
					if (num16 < 625f)
					{
						flag4 = false;
						continue;
					}
					float num17 = 12f / (float)Math.Sqrt(num16);
					num14 *= num17;
					num15 *= num17;
					vector4.X += num14;
					vector4.Y += num15;
					num14 = player.Position.X + 10f - vector4.X;
					num15 = player.Position.Y + 21f - vector4.Y;
					pos = vector4;
					pos.X -= view.ScreenPosition.X;
					pos.Y -= view.ScreenPosition.Y;
					SpriteSheet<_sheetSprites>.DrawRotated((int)_sheetSprites.ID.CHAIN, ref pos, view.Lighting.GetColor((int)vector4.X >> 4, (int)vector4.Y >> 4), rotCenter4);
				}
			}
			else if (aiStyle == (byte)EntityID.ProjStyleID.HARPOON)
			{
				float num18 = position.X + 8f;
				float num19 = position.Y + 2f;
				float x = velocity.X;
				float y = velocity.Y;
				float num20 = (float)Math.Sqrt(x * x + y * y);
				num20 = 20f / num20;
				if (ai0 == 0f)
				{
					num18 -= velocity.X * num20;
					num19 -= velocity.Y * num20;
				}
				else
				{
					num18 += velocity.X * num20;
					num19 += velocity.Y * num20;
				}
				Vector2 vector5 = new Vector2(num18, num19);
				x = player.Position.X + 10f - vector5.X;
				y = player.Position.Y + 21f - vector5.Y;
				float rotCenter5 = (float)Math.Atan2(y, x) - 1.57f;
				if (alpha == 0)
				{
					int num21 = -1;
					if (position.X + (width >> 1) < player.Position.X + 10f)
					{
						num21 = 1;
					}
					player.itemRotation = (float)Math.Atan2(y * num21, x * num21);
				}
				while (true)
				{
					float num22 = x * x + y * y;
					if (num22 < 625f)
					{
						break;
					}
					num22 = 12f / (float)Math.Sqrt(num22);
					x *= num22;
					y *= num22;
					vector5.X += x;
					vector5.Y += y;
					x = player.Position.X + 10f - vector5.X;
					y = player.Position.Y + 21f - vector5.Y;
					pos = vector5;
					pos.X -= view.ScreenPosition.X;
					pos.Y -= view.ScreenPosition.Y;
					SpriteSheet<_sheetSprites>.DrawRotated((int)_sheetSprites.ID.CHAIN, ref pos, view.Lighting.GetColor((int)vector5.X >> 4, (int)vector5.Y >> 4), rotCenter5);
				}
			}
			else if (aiStyle == (byte)EntityID.ProjStyleID.FLAIL)
			{
				Vector2 vector6 = new Vector2(position.X + (width >> 1), position.Y + (height >> 1));
				float num23 = player.Position.X + 10f - vector6.X;
				float num24 = player.Position.Y + 21f - vector6.Y;
				float rotCenter6 = (float)Math.Atan2(num24, num23) - 1.57f;
				if (alpha == 0)
				{
					int num25 = -1;
					if (XYWH.X + (width >> 1) < player.XYWH.X + 10)
					{
						num25 = 1;
					}
					player.itemRotation = (float)Math.Atan2(num24 * num25, num23 * num25);
				}
				bool flag5 = true;
				do
				{
					float num26 = num23 * num23 + num24 * num24;
					if (num26 < 625f)
					{
						flag5 = false;
						continue;
					}
					num26 = 12f / (float)Math.Sqrt(num26);
					num23 *= num26;
					num24 *= num26;
					vector6.X += num23;
					vector6.Y += num24;
					num23 = player.Position.X + 10f - vector6.X;
					num24 = player.Position.Y + 21f - vector6.Y;
					pos = vector6;
					pos.X -= view.ScreenPosition.X;
					pos.Y -= view.ScreenPosition.Y;
					int id = (int)_sheetSprites.ID.CHAIN3;
					if (type == (byte)EntityID.ProjectileID.BALL_O_HURT)
					{
						id = (int)_sheetSprites.ID.CHAIN2;
					}
					else if (type == (byte)EntityID.ProjectileID.SUNFURY)
					{
						id = (int)_sheetSprites.ID.CHAIN6;
					}
					else if (type == (byte)EntityID.ProjectileID.THE_DAO_OF_POW)
					{
						id = (int)_sheetSprites.ID.CHAIN7;
					}
					SpriteSheet<_sheetSprites>.DrawRotated(id, ref pos, view.Lighting.GetColor((int)vector6.X >> 4, (int)vector6.Y >> 4), rotCenter6);
				}
				while (flag5);
			}
			Color newColor = ((type == (byte)EntityID.ProjectileID.BULLET) ? Color.White : ((!hide) ? view.Lighting.GetColor(XYWH.X + (width >> 1) >> 4, XYWH.Y + (height >> 1) >> 4) : view.Lighting.GetColor(player.XYWH.X + 10 >> 4, player.XYWH.Y + 21 >> 4)));
			int num27 = (int)_sheetSprites.ID.PROBE + type;
			int num28 = SpriteSheet<_sheetSprites>.Source[num27].Width >> 1;
			int num29 = num28;
			int num30 = 0;
			switch ((EntityID.ProjectileID)type)
			{
				case EntityID.ProjectileID.MAGIC_MISSILE:
					num30 = 6;
					break;
				case EntityID.ProjectileID.DIRT_BALL:
				case EntityID.ProjectileID.SAND_BALL_FALLING:
					num30 = 2;
					break;
				case EntityID.ProjectileID.BALL_O_HURT:
				case EntityID.ProjectileID.BLUE_MOON:
				case EntityID.ProjectileID.SUNFURY:
				case EntityID.ProjectileID.THE_DAO_OF_POW:
					num30 = 6;
					num29 -= 6;
					break;
				case EntityID.ProjectileID.BOMB:
				case EntityID.ProjectileID.STICKY_BOMB:
				case EntityID.ProjectileID.HAPPY_BOMB:
					num30 = 8;
					break;
				case EntityID.ProjectileID.DYNAMITE:
					num30 = 11;
					break;
				case EntityID.ProjectileID.TOMBSTONE:
					num30 = 4;
					break;
				case EntityID.ProjectileID.HOLY_WATER:
				case EntityID.ProjectileID.UNHOLY_WATER:
					num30 = 4;
					num29 += 4;
					break;
				case EntityID.ProjectileID.GLOWSTICK:
				case EntityID.ProjectileID.STICKY_GLOWSTICK:
					num29 -= 8;
					break;
				case EntityID.ProjectileID.BLUE_FAIRY:
				case EntityID.ProjectileID.PINK_FAIRY:
				case EntityID.ProjectileID.GREEN_FAIRY:
					num29 -= 16;
					num30 = 8;
					break;
				case EntityID.ProjectileID.DUAL_HOOK_RED:
					num29 -= 6;
					break;
				case EntityID.ProjectileID.BOULDER:
					num30 = 1;
					break;
				case EntityID.ProjectileID.PET_BUNNY:
				case EntityID.ProjectileID.PET_SLIME:
				case EntityID.ProjectileID.PET_TIPHIA:
				case EntityID.ProjectileID.PET_BAT:
				case EntityID.ProjectileID.PET_WEREWOLF:
				case EntityID.ProjectileID.PET_ZOMBIE:
					num30 = (projFrameH[type] >> 1) - 2;
					num29 -= 16;
					break;
			}

			SpriteEffects e = ((spriteDirection == -1) ? SpriteEffects.FlipHorizontally : SpriteEffects.None);
			pos = new Vector2(position.X - view.ScreenPosition.X + num29, position.Y - view.ScreenPosition.Y + (height >> 1));
			Vector2 pivot = new Vector2(num28, (height >> 1) + num30);
			Color color = GetAlpha(newColor);
			int num31 = projFrameH[type];
			if (num31 > 0)
			{
				int sy = num31 * frame;
				SpriteSheet<_sheetSprites>.Draw(num27, ref pos, sy, num31, color, rotation, ref pivot, scale, e);
				return;
			}
			if (aiStyle == (byte)EntityID.ProjStyleID.SPEAR)
			{
				pos.X -= pivot.X;
				pos.X += width >> 1;
				if (spriteDirection == -1)
				{
					pivot.X *= 2f;
				}
				else
				{
					pivot.X = 0f;
				}
				pivot.Y = 0f;
				SpriteSheet<_sheetSprites>.Draw(num27, ref pos, color, rotation, ref pivot, scale, e);
				return;
			}
			if (type == (byte)EntityID.ProjectileID.CRYSTAL_STORM && ai1 > 6)
			{
				fixed (float* ptr = oldPos)
				{
					for (int i = 0; i < 10; i++)
					{
						Color c = color;
						float num32 = (9 - i) * 0.1112f;
						c.R = (byte)(c.R * num32);
						c.G = (byte)(c.G * num32);
						c.B = (byte)(c.B * num32);
						c.A = (byte)(c.A * num32);
						Vector2 pos2 = new Vector2(ptr[i << 1] - view.ScreenPosition.X + num29, ptr[(i << 1) + 1] - view.ScreenPosition.Y + (height >> 1));
						SpriteSheet<_sheetSprites>.Draw(num27, ref pos2, c, rotation, ref pivot, scale * num32, e);
					}
				}
			}
			SpriteSheet<_sheetSprites>.Draw(num27, ref pos, color, rotation, ref pivot, scale, e);
			if (type == (byte)EntityID.ProjectileID.LIGHT_DISC)
			{
				color.R = 200;
				color.G = 200;
				color.B = 200;
				color.A = 0;
				SpriteSheet<_sheetSprites>.Draw((int)_sheetSprites.ID.LIGHT_DISC, ref pos, color, rotation, ref pivot, scale, e);
			}
		}
	}
}
