namespace Terraria.CreateCharacter
{
	public enum Difficulty
	{
		SOFTCORE,
		MEDIUMCORE,
		HARDCORE,
		DIFFICULTY_COUNT,
#if !USE_ORIGINAL_CODE
		INVALID = 67
#endif
	}
}
