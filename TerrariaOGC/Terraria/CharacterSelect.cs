#if !VERSION_INITIAL
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Text;

namespace Terraria
{
	public static class CharacterSelect
	{
		private const int MaxCharacters = UI.MAX_LOAD_PLAYERS;

		private static Player[] LoadedPlayers = UI.MainUI.loadPlayer;

		private static sbyte hoveredCharacter;

		private static bool WaitNeeded = false;

		public static void Update(UI LocalInstance)
		{
			if (LocalInstance != UI.MainUI)
			{
				WaitNeeded = true;
			}

			if (UI.MainUI.loadPlayerPath[hoveredCharacter] != null && LoadedPlayers[hoveredCharacter].difficulty != (byte)CreateCharacter.Difficulty.INVALID)
			{
				UI.MainUI.showPlayer = hoveredCharacter;
			}

			if (UI.MainUI.IsBackButtonTriggered() && (Netplay.gamersWhoReceivedInvite.Count < 2 || !Netplay.gamersWhoReceivedInvite.Contains(UI.MainUI.SignedInGamer)))
			{
				Netplay.gamersWhoReceivedInvite.Remove(UI.MainUI.SignedInGamer);
				Main.PlaySound(11);
				if (Netplay.gamersWhoReceivedInvite.Count == 0)
				{
					Netplay.isJoiningRemoteInvite = false;
					Netplay.gamersWaitingToJoinInvite.Clear();
				}
				else
				{
					Netplay.gamersWaitingToJoinInvite.Remove(UI.MainUI.SignedInGamer);
				}
				UI.MainUI.SetMenu(MenuMode.TITLE, rememberPrevious: false, reset: true);
			}
			else
			{
				if (UI.MainUI.IsButtonTriggered(Buttons.A) && LoadedPlayers[hoveredCharacter].difficulty != (byte)CreateCharacter.Difficulty.INVALID)
				{
					UI.MainUI.selectedPlayer = hoveredCharacter;
					Main.PlaySound(10);
					SelectCharacter();
				}

				if (UI.MainUI.IsButtonTriggered(Buttons.X) && UI.MainUI.loadPlayerPath[hoveredCharacter] != null)
				{
					UI.MainUI.selectedPlayer = hoveredCharacter;
					Main.PlaySound(10);
					UI.MainUI.SetMenu(MenuMode.CONFIRM_DELETE_CHARACTER);
				}
			}
		}

		public static void UpdateCursor(int dy)
		{   
			// This function doesn't appear to exist, as the code is implanted in UpdateMouse() directly.
			// I just did it for consistency with current code. A few other functions also get this treatment.

			if (dy != 0)
			{
				Main.PlaySound(12);
				dy += hoveredCharacter;
				if (dy < 0)
				{
					dy += MaxCharacters;
				}
				else if (dy >= MaxCharacters)
				{
					dy -= MaxCharacters;
				}
				hoveredCharacter = (sbyte)dy;
			}
			return;		
		}

		public static void Draw(WorldView view)
		{
			int Spacing = 53;
			int TextAdjust = 212 + Spacing;
			int EntryWidth = 432;
			int EntryHeight = 35;
			int SALeftAdd = 288;
			int SATopAdd = 188;

			switch (Main.ScreenHeightPtr)
			{
				case ScreenHeights.HD:
					EntryWidth = 576; // *= 1.3
					SALeftAdd = 384; // *= 1.3
					SATopAdd = 251; // Close to *= 1.3
					break;

				case ScreenHeights.FHD:
					EntryWidth *= 2;
					SALeftAdd *= 2;
					SATopAdd *= 2;
					break;
			}

			Rectangle rect = default;
			rect.X = view.SafeAreaOffsetLeft + SALeftAdd;
			rect.Y = view.SafeAreaOffsetTop + SATopAdd;
			rect.Width = EntryWidth;
			rect.Height = EntryHeight;
			for (int k = 0; k < MaxCharacters; k++)
			{
				int texId2 = (int)_sheetSprites.ID.INVENTORY_BACK12;
				int alpha2 = 255;
				if (k == hoveredCharacter)
				{
					alpha2 = UI.MouseTextBrightness;
					texId2 = (int)_sheetSprites.ID.INVENTORY_BACK10;
				}
				else if (UI.MainUI.loadPlayerPath[k] == null)
				{
					alpha2 = 212;
					texId2 = (int)_sheetSprites.ID.INVENTORY_BACK;
				}
				Main.DrawRect(texId2, rect, alpha2);
				rect.Y += Spacing;
			}

			rect.Y -= TextAdjust;

			for (int l = 0; l < MaxCharacters; l++)
			{
				string NameOrEmpty = (UI.MainUI.loadPlayerPath[l] == null) ? Lang.MenuText[79] : (LoadedPlayers[l].difficulty == (byte)CreateCharacter.Difficulty.INVALID) ? LoadedPlayers[l].Name : LoadedPlayers[l].CharacterName;

				Color NameColour = new Color(255, 255, 255, 255);

				if (UI.MainUI.loadPlayerPath[l] == null)
				{
					NameColour = new Color(200, 200, 220, 255);
				}
				else
				{
					switch ((CreateCharacter.Difficulty)LoadedPlayers[l].difficulty) // ADDITION: 1.01 and above made character select akin to the world select, but unfortunately, it packed up colouring for different difficulties in exchange.
					{
						// In TerrariaOGC, it has returned.
						case CreateCharacter.Difficulty.MEDIUMCORE:
							NameColour = new Color(UI.mcColorR, UI.mcColorG, UI.mcColorB);
							break;
						case CreateCharacter.Difficulty.HARDCORE:
							NameColour = new Color(UI.hcColorR, UI.hcColorG, UI.hcColorB);
							break;
						case CreateCharacter.Difficulty.INVALID:
							NameColour = new Color(120, 120, 120);
							break;
					}
				}

				UI.DrawStringCC(UI.BoldSmallFont, NameOrEmpty, rect.Center.X, rect.Center.Y, NameColour);
				rect.Y += Spacing;
			}
		}

		public static void ControlDescription(StringBuilder strBuilder)
		{
			if (UI.MainUI.loadPlayerPath[hoveredCharacter] == null)
			{
				strBuilder.Append(Lang.Controls(Lang.CONTROLS.CREATE_CHARACTER));
				strBuilder.Append(' ');
			}
			else if (LoadedPlayers[hoveredCharacter].difficulty != (byte)CreateCharacter.Difficulty.INVALID)
			{
				strBuilder.Append(Lang.Controls(Lang.CONTROLS.SELECT));
				strBuilder.Append(' ');
			}
			strBuilder.Append(Lang.Controls(Lang.CONTROLS.BACK));
			strBuilder.Append(' ');
			if (UI.MainUI.loadPlayerPath[hoveredCharacter] != null)
			{
				strBuilder.Append(Lang.MenuText[17]);
				strBuilder.Append(' ');
			}
		}

		private static void SelectCharacter()
		{
			if (UI.MainUI.loadPlayerPath[hoveredCharacter] != null)
			{
				UI.MainUI.SetPlayer(LoadedPlayers[hoveredCharacter].DeepCopy());
				UI.MainUI.playerPathName = UI.MainUI.loadPlayerPath[hoveredCharacter];

				if (Netplay.isJoiningRemoteInvite)
				{
					UI.MainUI.SetMenu(MenuMode.NETPLAY);
					UI.MainUI.statusText = Lang.MenuText[75];
				}
				else if (WaitNeeded)
				{
					UI.MainUI.SetMenu(MenuMode.WAITING_SCREEN);
				}
				else
				{
					UI.MainUI.SetMenu(MenuMode.WORLD_SELECT);
				}
			}
			else
			{
				LoadedPlayers[hoveredCharacter] = new Player();
				LoadedPlayers[hoveredCharacter].CharacterName = UI.MainUI.SignedInGamer.Gamertag;
				LoadedPlayers[hoveredCharacter].Inventory[0].SetDefaults("Copper Shortsword");
				LoadedPlayers[hoveredCharacter].Inventory[0].SetPrefix(-1);
				LoadedPlayers[hoveredCharacter].Inventory[1].SetDefaults("Copper Pickaxe");
				LoadedPlayers[hoveredCharacter].Inventory[1].SetPrefix(-1);
				LoadedPlayers[hoveredCharacter].Inventory[2].SetDefaults("Copper Axe");
				LoadedPlayers[hoveredCharacter].Inventory[2].SetPrefix(-1);
				UI.MainUI.CreateCharacterGUI.ApplyDefaultAttributes(LoadedPlayers[hoveredCharacter]);
				UI.MainUI.SetMenu(MenuMode.CREATE_CHARACTER);
			}
		}
	}
}
#endif