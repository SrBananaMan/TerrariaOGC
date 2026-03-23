#if !USE_ORIGINAL_CODE
using System;
using System.Collections.Generic;

namespace Terraria.Achievements
{
	public class AchievementDetails
	{
		public List<AchievementSystem.TerrariaAchievement> Details = new List<AchievementSystem.TerrariaAchievement>();
		public AchievementDetails()
		{
			Details.Add(new AchievementSystem.TerrariaAchievement("Terraria Expert", "You have completed the tutorial!"));
			Details.Add(new AchievementSystem.TerrariaAchievement("Terraria Student", "You have begun the tutorial!"));
			Details.Add(new AchievementSystem.TerrariaAchievement("Home Sweet Home", "The Guide has moved in!"));
			Details.Add(new AchievementSystem.TerrariaAchievement("All in the Family", "Every NPC has moved in!"));
			Details.Add(new AchievementSystem.TerrariaAchievement("Rock Bottom", "You have reached the bottom of the World!"));
			Details.Add(new AchievementSystem.TerrariaAchievement("Exterminator", "You have defeated every boss!"));
			Details.Add(new AchievementSystem.TerrariaAchievement("Slimer", "You have killed every type of slime!"));
			Details.Add(new AchievementSystem.TerrariaAchievement("Challenge Accepted", "You have unlocked Hard Mode!"));
			Details.Add(new AchievementSystem.TerrariaAchievement("Maxed Out", "You have the maximum health and mana!"));
			Details.Add(new AchievementSystem.TerrariaAchievement("Corruptible", "Your world is corrupt!"));
			Details.Add(new AchievementSystem.TerrariaAchievement("Hallowed Be Thy Name", "Your world is hallowed!"));
			Details.Add(new AchievementSystem.TerrariaAchievement("Ophthalmologist", "You have defeated The Twins!"));
			Details.Add(new AchievementSystem.TerrariaAchievement("Bona Fide", "You have defeated Skeletron Prime!"));
			Details.Add(new AchievementSystem.TerrariaAchievement("Ride The Worm", "You have defeated The Destroyer!"));
			Details.Add(new AchievementSystem.TerrariaAchievement("Marathon Runner", "You have traveled over 42km on the ground!"));
			Details.Add(new AchievementSystem.TerrariaAchievement("Landscaper", "You have removed more than 10,000 blocks!"));
			Details.Add(new AchievementSystem.TerrariaAchievement("Crowd Control", "You have defeated the Goblin Army!"));
			Details.Add(new AchievementSystem.TerrariaAchievement("Survivor", "You survived the first night!"));
			Details.Add(new AchievementSystem.TerrariaAchievement("Icarus", "You have reached the top of the world!"));
			Details.Add(new AchievementSystem.TerrariaAchievement("Vanity of Vanities", "Looking good!"));
			Details.Add(new AchievementSystem.TerrariaAchievement("Pet Hoarder", "You seem to like the pets."));
			Details.Add(new AchievementSystem.TerrariaAchievement("Be Prepared", "You are ready for battle!"));
			Details.Add(new AchievementSystem.TerrariaAchievement("Airtime", "Enjoy the view."));
			Details.Add(new AchievementSystem.TerrariaAchievement("Blacksmith", "You are a master smith!"));
			Details.Add(new AchievementSystem.TerrariaAchievement("I'm Smelting!", "You have smelted 10,000 bars of metal!"));
			Details.Add(new AchievementSystem.TerrariaAchievement("A Knight in Shining Armors", "Obtain every type of armor available."));
			Details.Add(new AchievementSystem.TerrariaAchievement("Engineer", "You have placed 100 wires!"));
			Details.Add(new AchievementSystem.TerrariaAchievement("Red Moon Rises", "You have survived the Blood Moon!"));
			Details.Add(new AchievementSystem.TerrariaAchievement("Crafty", "You have used every crafting station!"));
			Details.Add(new AchievementSystem.TerrariaAchievement("To Hell and Back", "You have gone to The Underworld and back without dying!"));
			Details.Add(new AchievementSystem.TerrariaAchievement("Back for Seconds", "You have defeated all the prime bosses twice!"));
			Details.Add(new AchievementSystem.TerrariaAchievement("Is This Heaven?", "You have found a floating island!"));
			// The below one was originally called "Leap a tall building in a single bound", how boring...
			Details.Add(new AchievementSystem.TerrariaAchievement("Superman Jump", "Jump really, really high."));
			Details.Add(new AchievementSystem.TerrariaAchievement("Safe Fall", "You have landed safely."));
			Details.Add(new AchievementSystem.TerrariaAchievement("Hellevator", "Go from the surface to The Underworld in under a minute."));
			Details.Add(new AchievementSystem.TerrariaAchievement("Gone in 60 seconds", "You ran continuously for 60 seconds!"));
			Details.Add(new AchievementSystem.TerrariaAchievement("Appease the Volcano Gods", "You sacrificed The Guide in boiling hot magma!"));
			Details.Add(new AchievementSystem.TerrariaAchievement("Homicidal", "You killed The Guide, you maniac!"));
			Details.Add(new AchievementSystem.TerrariaAchievement("Completionist", "All accomplishments have been unlocked!"));



			/* Just a few ideas I had for OGC-exclusive achievements
			Details.Add(new AchievementSystem.TerrariaAchievement("The Strongest...", "You have defeated Ocram, in an era where it reigned supreme...")); // Perhaps pre-1.03 exclusive?
			Details.Add(new AchievementSystem.TerrariaAchievement("Legacy Legend", "You fought Ocram and the prime bosses all at once and came out on top!"));
			Details.Add(new AchievementSystem.TerrariaAchievement("An Act of God", "A falling star has ended one of your boss battles."));
			Details.Add(new AchievementSystem.TerrariaAchievement("I Will Survive", "You drowned for 30 seconds... and still didn't die."));
			Details.Add(new AchievementSystem.TerrariaAchievement("Worth the Risk?", "You killed a Dungeon Guardian! No, you do not get anything for it.")); // Also pre-1.03 exclusive, so no hoiks.

			// Y'know that old collector's edition for the console version? It had a poster labelling the exclusive weapons as associates of the exclusive armours.
			// Hence these 3 difficult achievements...
			Details.Add(new AchievementSystem.TerrariaAchievement("Dragonborn", "You bested The Destroyer with the might of the Tizona and the Dragon armor!"));
			Details.Add(new AchievementSystem.TerrariaAchievement("20/20 Deadeye", "You bested The Twins using only the Tonbogiri while wearing Titan armor!"));
			Details.Add(new AchievementSystem.TerrariaAchievement("Phantom Anomaly", "You bested Skeletron Prime with the Sharanga or Vulcan Repeater robed in Spectral armor!"));
			*/
		}
	}
}
#endif