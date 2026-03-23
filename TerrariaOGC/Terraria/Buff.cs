namespace Terraria
{
	public struct Buff
	{
		public const int MaxNumBuffs = (int)EntityID.BuffID.NUM_BUFFS;

		public const int MaxNumBuffStrings = (int)EntityID.BuffID.NUM_BUFFS + 5;	// All the potential buff types, including the Pet Guinea Pig and the 5 alternatives.

		public static string[] BuffName = new string[MaxNumBuffStrings];

		public static string[] BuffTip = new string[MaxNumBuffStrings];

		public ushort Type;

		public ushort Time;

		public bool IsPvpBuff()
		{
			switch (Type)
			{
				case (int)EntityID.BuffID.POISONED:
				case (int)EntityID.BuffID.ON_FIRE:
				case (int)EntityID.BuffID.BLEED:
				case (int)EntityID.BuffID.CONFUSED:
				case (int)EntityID.BuffID.ON_FIRE_2:
					return true;
				default:
					return false;
			}
		}

		public static bool IsDebuff(int type)
		{
			switch (type)
			{
				case (int)EntityID.BuffID.POISONED:
				case (int)EntityID.BuffID.POTION_DELAY:
				case (int)EntityID.BuffID.BLIND:
				case (int)EntityID.BuffID.NO_ITEMS:
				case (int)EntityID.BuffID.ON_FIRE:
				case (int)EntityID.BuffID.DRUNK:
				case (int)EntityID.BuffID.WEREWOLF: // Apparently this and merfolk are debuffs???
				case (int)EntityID.BuffID.BLEED:
				case (int)EntityID.BuffID.CONFUSED:
				case (int)EntityID.BuffID.SLOW:
				case (int)EntityID.BuffID.WEAK:
				case (int)EntityID.BuffID.MERFOLK:
				case (int)EntityID.BuffID.SILENCE:
				case (int)EntityID.BuffID.BROKEN_ARMOR:
				case (int)EntityID.BuffID.HORRIFIED:
				case (int)EntityID.BuffID.TONGUED:
				case (int)EntityID.BuffID.ON_FIRE_2:
					return true;
				default:
					return false;
			}
		}

		public bool IsDebuff()
		{
			return IsDebuff(Type);
		}

		public bool IsHealable()
		{
			switch (Type)
			{
				case (int)EntityID.BuffID.POISONED:
				case (int)EntityID.BuffID.POTION_DELAY:
				case (int)EntityID.BuffID.BLIND:
				case (int)EntityID.BuffID.NO_ITEMS:
				case (int)EntityID.BuffID.ON_FIRE:
				case (int)EntityID.BuffID.DRUNK:
				case (int)EntityID.BuffID.BLEED:
				case (int)EntityID.BuffID.CONFUSED:
				case (int)EntityID.BuffID.SLOW:
				case (int)EntityID.BuffID.WEAK:
				case (int)EntityID.BuffID.SILENCE:
				case (int)EntityID.BuffID.BROKEN_ARMOR:
				case (int)EntityID.BuffID.HORRIFIED:
				case (int)EntityID.BuffID.TONGUED:
				case (int)EntityID.BuffID.ON_FIRE_2:
					return Time > 0;
				default:
					return false;
			}
		}

		public void Init()
		{
			Type = 0;
			Time = 0;
		}
	}
}
