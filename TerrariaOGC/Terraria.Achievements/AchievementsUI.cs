#if !USE_ORIGINAL_CODE
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.Achievements
{
	internal class AchievementsUI
	{
		private const int RowSpacing = 9;

		private static readonly int RowHeight = (int)(86 * Main.ScreenMultiplier),
			RowWidth = (int)(900 * Main.ScreenMultiplier),
			BackgroundX = (int)(20 * Main.ScreenMultiplier),
			ImageX = (int)(84 * Main.ScreenMultiplier),
			NameLabelX = (int)(126 * Main.ScreenMultiplier),
			DescLabelX = (int)(446 * Main.ScreenMultiplier),
			MaxRowsPerScreen = 4;

		private readonly AchievementData Data;

		private readonly UI ParentUI;

		private int UIDelay;

		private readonly Texture2D[] AchIcons;

		public AchievementsUI(UI ParentUI)
		{
			Data = new AchievementData(MaxRowsPerScreen);
			UIDelay = 0;
			this.ParentUI = ParentUI;
			AchIcons = Assets.Advancements;
		}

		public void InitializeData()
		{
			Data.LoadLeaderboard();
		}

		public void Update()
		{
			if (!Data.Update())
			{
				MessageBox.Show(ParentUI.controller, Lang.MenuText[5], Lang.InterfaceText[36], new string[1] { Lang.MenuText[90] });
				ParentUI.PrevMenu();
			}
			else if (UIDelay > 0)
			{
				UIDelay--;
			}
			else if (Data.Ready)
			{
				bool MoveReq = false;
				if (ParentUI.IsDownButtonDown())
				{
					MoveReq = Data.MoveDown();
				}
				else if (ParentUI.IsUpButtonDown())
				{
					MoveReq = Data.MoveUp();
				}
				if (MoveReq)
				{
					UIDelay = 8;
					Main.PlaySound(12);
				}
			}
		}

		public void Draw(WorldView View)
		{
			SpriteFont FontSmallOutline = UI.BigFont;
			UI.DrawStringCT(FontSmallOutline, "Achievements", Main.ResolutionWidth / 2, View.SafeAreaOffsetTop - 16, Color.White);

			Vector2 Vector = default;
			Vector.Y = View.SafeAreaOffsetTop + (95f * Main.ScreenMultiplier);

			AchievementData.Row[] Rows = Data.GetRows();
			for (int Index = 0; Index < Rows.Length; Index++)
			{
				int Selection = Index + Data.BatchStart;
				int TexID = (Selection == Data.Selected) ? (int)_sheetSprites.ID.INVENTORY_BACK10 : (int)_sheetSprites.ID.INVENTORY_BACK;
				short WrapWidth = (short)(300 * Main.ScreenMultiplier);
				short WrapWidth2 = (short)(475 * Main.ScreenMultiplier);
				Main.DrawRect(TexID, new Rectangle(BackgroundX + 22, (int)(Vector.Y - (25 * Main.ScreenMultiplier)) + 8, RowWidth - 16, RowHeight - 16), 192);

				AchievementData.Row Row = Rows[Index];
				int AchievementIdx = Row.Rank - 1;
				Texture2D AchIcon = AchIcons[AchievementIdx];
				if (AchievementIdx == 0)
				{
					AchievementIdx = 39;
				}
				AchievementSystem.TerrariaAchievement Achievement = Data.GetAchievement((Achievement)AchievementIdx - 1);
				bool HasEarned = Achievement.GetStatus();

				if (Row != null && Row.Available)
				{
					Vector2 Position = new Vector2(ImageX >> 1, Vector.Y - (13f * Main.ScreenMultiplier));
					Main.SpriteBatch.Draw(AchIcon, Position, null, Color.White, 0f, default, Main.ScreenMultiplier, SpriteEffects.None, 0f);

					if (!HasEarned)
					{
						// Little something I cooked up. Gives an achievement icon a darkened image while keeping it's gold border if not earned. Will revise with a different image in 1.2
						Main.SpriteBatch.Draw(AchIcon, new Vector2(Position.X + (2 * Main.ScreenMultiplier), Position.Y + (2 * Main.ScreenMultiplier)), new Rectangle(2, 2, AchIcon.Width - 4, AchIcon.Height - 4), new Color(32, 32, 32, 255), 0f, default, Main.ScreenMultiplier, SpriteEffects.None, 0f);
					}

					CompiledText Name = new CompiledText("<i>Name:</i> " + Achievement.Name, WrapWidth, UI.BoldSmallTextStyle);
					CompiledText Description = new CompiledText("<i>Description:</i> " + Achievement.Description, WrapWidth2, UI.BoldSmallTextStyle);
					string EarnString = HasEarned ? Achievement.EarnedDate.ToLongDateString() : "Not yet earned";
					Color EarnStatus = HasEarned ? new Color(64, 255, 128, 255) : new Color(255, 128, 128, 255);
					CompiledText Date = new CompiledText("<i>Earned:</i> " + EarnString, WrapWidth, UI.BoldSmallTextStyle);

					Vector2i NameVector = new Vector2i(NameLabelX, (int)Vector.Y - 16);
					Vector2i DescriptionVector = new Vector2i(DescLabelX - 16, (int)Vector.Y - 16);
					Vector2i DateVector = new Vector2i(NameLabelX, (int)(Vector.Y + (16 * Main.ScreenMultiplier)));
					Name.Draw(Main.SpriteBatch, new Rectangle(NameVector.X, NameVector.Y, WrapWidth, Main.ResolutionHeight), Color.White, new Color(255, 212, 64, 255));
					Description.Draw(Main.SpriteBatch, new Rectangle(DescriptionVector.X, DescriptionVector.Y, WrapWidth2, Main.ResolutionHeight), Color.White, new Color(255, 212, 64, 255));
					Date.Draw(Main.SpriteBatch, new Rectangle(DateVector.X, DateVector.Y, WrapWidth, Main.ResolutionHeight), Color.White, EarnStatus);
				}
				Vector.Y += 11f * RowSpacing * Main.ScreenMultiplier;
			}
		}
	}
}
#endif