namespace Terraria.Achievements
{
	public enum Trigger
	{
		HighestPosition,
		HouseGuide,
		HousedAllNPCs,
		LowestPosition,
		AllSlimesKilled,
		AllBossesKilled,
		UnlockedHardMode,
		MaxHealthAndMana,
		CorruptedWorld,
		HallowedWorld,
		FirstTutorialTaskCompleted,
		AllTutorialTasksCompleted,
		KilledTheTwins,
		KilledSkeletronPrime,
		KilledDestroyer,
		Walked42KM,
		RemovedLotsOfTiles,
		KilledGoblinArmy,
		Sunrise,
		SunriseAfterBloodMoon,
		AllVanitySlotsEquipped,
		CreatedLotsOfBars,
		Has5Buffs,
		SpawnedAllPets,
		CollectedAllArmor,
		UsedLotsOfAnvils,
		UsedAllCraftingStations,
		PlacedLotsOfWires,
		WentDownAndUpWithoutDyingOrWarping,
		InTheSky,
#if !USE_ORIGINAL_CODE	// These could not be recovered, so they were made based off of the Achievement enum.
		BackForSeconds,
		CouldThisBeHeaven,
		LeapTallBuildingInSingleBound,
		SafeFall,
		Hellevator,
		GoneIn60Seconds,
		OldFashioned,
		Homicidal,
		MadLad,	// Hence this name here.
#endif
		NumTriggers
	}
}
