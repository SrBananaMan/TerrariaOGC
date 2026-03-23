using System;
using System.Collections;

namespace Terraria
{
	public class Statistics
	{
		private const int FirstNonSlimeIndex = 19;

		private const int FirstBossIndex = 18;

		private const int LastBossIndex = 26;

#if !USE_ORIGINAL_CODE
		public bool AllSlimeTypesKilled, AllBossesKilled, MechBossesKilledTwice;
#else
		public bool AllSlimeTypesKilled, AllBossesKilled;
#endif

		private readonly BitArray SlimesKilled, BossesKilled;

		private readonly uint[] Counters;

		public uint this[StatisticEntry Statistic] => Counters[(int)Statistic];

		public static StatisticEntry GetStatisticEntryFromNetID(short NetID)
		{
			StatisticEntry NPCEntry = StatisticEntry.Unknown;
			switch ((EntityID.NPCID)NetID)
			{
				case EntityID.NPCID.SLIME:
					NPCEntry = StatisticEntry.BlueSlime;
					break;
				case EntityID.NPCID.SLIMELING:
					NPCEntry = StatisticEntry.Slimeling;
					break;
				case EntityID.NPCID.SLIMER2:
					NPCEntry = StatisticEntry.Slimer;
					break;
				case EntityID.NPCID.GREEN_SLIME:
					NPCEntry = StatisticEntry.GreenSlime;
					break;
				case EntityID.NPCID.PINKY:
					NPCEntry = StatisticEntry.Pinky;
					break;
				case EntityID.NPCID.BABY_SLIME:
					NPCEntry = StatisticEntry.BabySlime;
					break;
				case EntityID.NPCID.BLACK_SLIME:
					NPCEntry = StatisticEntry.BlackSlime;
					break;
				case EntityID.NPCID.PURPLE_SLIME:
					NPCEntry = StatisticEntry.PurpleSlime;
					break;
				case EntityID.NPCID.RED_SLIME:
					NPCEntry = StatisticEntry.RedSlime;
					break;
				case EntityID.NPCID.YELLOW_SLIME:
					NPCEntry = StatisticEntry.YellowSlime;
					break;
				case EntityID.NPCID.JUNGLE_SLIME:
					NPCEntry = StatisticEntry.JungleSlime;
					break;
				case EntityID.NPCID.SLIMELING2:
					NPCEntry = StatisticEntry.Slimeling;
					break;
				case EntityID.NPCID.MOTHER_SLIME:
					NPCEntry = StatisticEntry.MotherSlime;
					break;
				case EntityID.NPCID.LAVA_SLIME:
					NPCEntry = StatisticEntry.LavaSlime;
					break;
				case EntityID.NPCID.CORRUPT_SLIME:
					NPCEntry = StatisticEntry.CorruptSlime;
					break;
				case EntityID.NPCID.TOXIC_SLUDGE:
					NPCEntry = StatisticEntry.ToxicSludge;
					break;
				case EntityID.NPCID.SLIMER:
					NPCEntry = StatisticEntry.Slimer;
					break;
				case EntityID.NPCID.SHADOW_SLIME:
					NPCEntry = StatisticEntry.ShadowSlime;
					break;
				case EntityID.NPCID.ILLUMINANT_SLIME:
					NPCEntry = StatisticEntry.IlluminantSlime;
					break;
				case EntityID.NPCID.DUNGEON_SLIME:
					NPCEntry = StatisticEntry.DungeonSlime;
					break;
			}
			return NPCEntry;
		}

		public static StatisticEntry GetBossStatisticEntryFromNetID(short NetID)
		{
			StatisticEntry BossEntry = StatisticEntry.Unknown;
			switch ((EntityID.NPCID)NetID)
			{
				case EntityID.NPCID.KING_SLIME:
					BossEntry = StatisticEntry.KingSlime;
					break;
				case EntityID.NPCID.EYE_OF_CTHULHU:
					BossEntry = StatisticEntry.EyeOfCthulhu;
					break;
				case EntityID.NPCID.EATER_OF_WORLDS_HEAD:
				case EntityID.NPCID.EATER_OF_WORLDS_BODY:
				case EntityID.NPCID.EATER_OF_WORLDS_TAIL:
					BossEntry = StatisticEntry.EaterOfWorlds;
					break;
				case EntityID.NPCID.SKELETRON_HEAD:
					BossEntry = StatisticEntry.Skeletron;
					break;
				case EntityID.NPCID.WALL_OF_FLESH:
					BossEntry = StatisticEntry.WallOfFlesh;
					break;
				case EntityID.NPCID.RETINAZER:
				case EntityID.NPCID.SPAZMATISM:
					BossEntry = StatisticEntry.TheTwins;
					break;
				case EntityID.NPCID.THE_DESTROYER_HEAD:
					BossEntry = StatisticEntry.TheDestroyer;
					break;
				case EntityID.NPCID.SKELETRON_PRIME:
					BossEntry = StatisticEntry.SkeletronPrime;
					break;
				case EntityID.NPCID.OCRAM:
					BossEntry = StatisticEntry.Ocram;
					break;
			}
			return BossEntry;
		}

		public static Statistics Create()
		{
			BitArray SlimeTypesKilled = new BitArray(FirstNonSlimeIndex);
			BitArray BossTypesKilled = new BitArray(LastBossIndex - FirstBossIndex + 1);
			uint[] StatCounters = new uint[(int)StatisticEntry.NumEntries];
			return new Statistics(SlimeTypesKilled, BossTypesKilled, StatCounters);
		}

		public Statistics(BitArray SlimeTypesKilled, BitArray BossTypesKilled, uint[] StatCounters)
		{
			SlimesKilled = SlimeTypesKilled;
			BossesKilled = BossTypesKilled;
			Counters = StatCounters;
			UpdateAllSlimesKilled();
			UpdateAllBossesKilled();
#if USE_ORIGINAL_CODE
		}
#else
			UpdateMechBossesKilledTwice();
		}

		private void UpdateMechBossesKilledTwice() // This looks like it might be akin to the 1.2 method, which is the fixed version.
		{
			bool Pass = true;
			if (Counters[(int)StatisticEntry.TheTwins] < 2)
			{
				Pass = false;
			}
			if (Counters[(int)StatisticEntry.TheDestroyer] < 2)
			{
				Pass = false;
			}
			if (Counters[(int)StatisticEntry.SkeletronPrime] < 2)
			{
				Pass = false;
			}
			MechBossesKilledTwice = Pass;
		}
#endif

		private void UpdateAllSlimesKilled()
		{
			AllSlimeTypesKilled = true;
			for (int TypeIdx = 0; TypeIdx < SlimesKilled.Count; TypeIdx++)
			{
				AllSlimeTypesKilled &= SlimesKilled[TypeIdx];
			}
		}

		private void UpdateAllBossesKilled()
		{
			AllBossesKilled = true;
			for (int TypeIdx = 0; TypeIdx < BossesKilled.Count; TypeIdx++)
			{
				AllBossesKilled &= BossesKilled[TypeIdx];
			}
		}

		public void IncreaseStat(StatisticEntry Entry)
		{
			if (Entry != StatisticEntry.Unknown)
			{
				if (Entry < StatisticEntry.EyeOfCthulhu)
				{
					SlimesKilled.Set((int)Entry, value: true);
					UpdateAllSlimesKilled();
				}
				if (Entry < StatisticEntry.AirTravel && Entry >= StatisticEntry.KingSlime)
				{
					int index = (int)(Entry - FirstBossIndex);
					BossesKilled.Set(index, value: true);
					UpdateAllBossesKilled();
				}
				Counters[(int)Entry]++;
#if !USE_ORIGINAL_CODE
				if (Entry == StatisticEntry.TheTwins || Entry == StatisticEntry.TheDestroyer || Entry == StatisticEntry.SkeletronPrime)
				{
					UpdateMechBossesKilledTwice();
				}
#endif
			}
		}

		public void IncreaseWoodStat(uint Count)
		{
			Counters[(int)StatisticEntry.Wood] += Count;
		}

		private uint CreateChecksum()
		{
			uint Checksum = 0;
			uint[] CurrentCounters = Counters;
			foreach (uint Counter in CurrentCounters)
			{
				Checksum ^= Counter;
			}
			return Checksum;
		}

		public byte[] Serialize()
		{
			uint Checksum = CreateChecksum();
			int CounterLength = Buffer.ByteLength(Counters);
			byte[] DestArr = new byte[CounterLength + 4];
			Buffer.BlockCopy(Counters, 0, DestArr, 0, CounterLength);
			Buffer.BlockCopy(new uint[1]
			{
				Checksum
			}, 0, DestArr, CounterLength, 4);
			return DestArr;
		}

		public void Deserialize(byte[] StatStream)
		{
			if (StatStream.Length == 0)
			{
				Array.Clear(Counters, 0, Counters.Length);
				return;
			}
			int num2 = StatStream.Length - 4;
			Buffer.BlockCopy(StatStream, 0, Counters, 0, num2);
			uint[] DestArr = new uint[1];
			Buffer.BlockCopy(StatStream, num2, DestArr, 0, 4);
			uint Checksum = CreateChecksum();
			if (Checksum != DestArr[0])
			{
				Array.Clear(Counters, 0, Counters.Length);
			}
			for (int CounterIdx = 0; CounterIdx < Counters.Length; CounterIdx++)
			{
				bool IsActive = Counters[CounterIdx] != 0;
				if (CounterIdx < FirstNonSlimeIndex && IsActive)
				{
					SlimesKilled.Set(CounterIdx, value: true);
				}
				if (CounterIdx < (LastBossIndex + 1) && CounterIdx >= FirstBossIndex && IsActive)
				{
					int BossIdx = CounterIdx - FirstBossIndex;
					BossesKilled.Set(BossIdx, value: true);
				}
			}
			UpdateAllSlimesKilled();
			UpdateAllBossesKilled();
#if !USE_ORIGINAL_CODE
			UpdateMechBossesKilledTwice();
#endif
		}

		public static int CalculateSerialisationSize()
		{
			return sizeof(uint) * (int)StatisticEntry.NumEntries + 4;
		}

		public void Init()
		{
#if !USE_ORIGINAL_CODE
			MechBossesKilledTwice = false;
#endif
			AllSlimeTypesKilled = false;
			AllBossesKilled = false;
			SlimesKilled.SetAll(value: false);
			BossesKilled.SetAll(value: false);
			for (int CounterIdx = (int)StatisticEntry.NumEntries - 1; CounterIdx >= 0; CounterIdx--)
			{
				Counters[CounterIdx] = 0;
			}
		}
	}
}
