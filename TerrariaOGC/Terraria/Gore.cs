using Microsoft.Xna.Framework;

namespace Terraria
{
	public struct Gore
	{
		public const int MaxNumGoreTypes = (int)EntityID.GoreID.NUM_TYPES;

		public const int MaxNumGore = 128;

		public const int GoreTime = 360;

		private static int LastGoreIndex;

		public Vector2 Position;

		public Vector2 Velocity;

		public float Rotation;

		public float Scale;

		public float Light;

		public byte Active;

		public byte Type;

		public bool Sticky;

		public short Alpha;

		public short TimeLeft;

		public void Init()
		{
			Active = 0;
		}

		public void Update()
		{
			if ((Type >= (int)EntityID.GoreID.SMOKE_BLUE1 && Type <= (int)EntityID.GoreID.SMOKE_BLUE3) || (Type >= (int)EntityID.GoreID.SMOKE_WHITE1 && Type <= (int)EntityID.GoreID.SMOKE_WHITE3) || Type == (int)EntityID.GoreID.SMOKE_BLACK)
			{
				Velocity.Y *= 0.98f;
				Velocity.X *= 0.98f;
				Scale -= 0.007f;
				if (Scale < 0.1f)
				{
					Active = 0;
					return;
				}
			}
#if VERSION_101
			else if (Type >= (int)EntityID.GoreID.SMOKE_PURPLE1 && Type <= (int)EntityID.GoreID.SMOKE_PURPLE3)
			{
				Velocity.Y *= 0.98f;
				Velocity.X *= 0.98f;
				Scale -= 0.007f;
				if (Scale < 0.1f)
				{
					Active = 0;
					return;
				}
			}
#endif
			else if (Type == (int)EntityID.GoreID.FALLEN_STAR_PARTICLE1 || Type == (int)EntityID.GoreID.FALLEN_STAR_PARTICLE2)
			{
				Velocity.Y *= 0.98f;
				Velocity.X *= 0.98f;
				Scale -= 0.01f;
				if (Scale < 0.1f)
				{
					Active = 0;
					return;
				}
			}
			else
			{
				Velocity.Y += 0.2f;
			}
			Rotation += Velocity.X * 0.1f;
			if (Sticky)
			{
				int SpriteWidth = SpriteSheet<_sheetSprites>.Source[(int)_sheetSprites.ID.GORE_0 + Type].Width;
				if (SpriteSheet<_sheetSprites>.Source[(int)_sheetSprites.ID.GORE_0 + Type].Height < SpriteWidth)
				{
					SpriteWidth = SpriteSheet<_sheetSprites>.Source[(int)_sheetSprites.ID.GORE_0 + Type].Height;
				}
				SpriteWidth = (int)(SpriteWidth * Scale * 0.9f);
				Collision.TileCollision(ref Position, ref Velocity, SpriteWidth, SpriteWidth);
				if (Velocity.Y == 0f)
				{
					Velocity.X *= 0.97f;
					if (Velocity.X > -0.01f && Velocity.X < 0.01f)
					{
						Velocity.X = 0f;
					}
				}
				if (TimeLeft > 0)
				{
					TimeLeft--;
				}
				else
				{
					Alpha++;
				}
			}
			else
			{
				Alpha += 2;
			}
			if (Alpha >= 255)
			{
				Active = 0;
				return;
			}
			Position.X += Velocity.X;
			Position.Y += Velocity.Y;
			if (Light > 0f)
			{
				float BaseColour = Light * Scale;
				Vector3 RGB = new Vector3(BaseColour, BaseColour, BaseColour);
				if (Type == (int)EntityID.GoreID.FALLEN_STAR_PARTICLE1)
				{
					RGB.Y *= 0.8f;
					RGB.Z *= 0.3f;
				}
				else if (Type == (int)EntityID.GoreID.FALLEN_STAR_PARTICLE2)
				{
					RGB.X *= 0.3f;
					RGB.Y *= 0.6f;
				}
				Lighting.AddLight((int)(Position.X + SpriteSheet<_sheetSprites>.Source[(int)_sheetSprites.ID.GORE_0 + Type].Width * Scale * 0.5f) >> 4, (int)(Position.Y + SpriteSheet<_sheetSprites>.Source[(int)_sheetSprites.ID.GORE_0 + Type].Height * Scale * 0.5f) >> 4, RGB);
			}
		}

		public unsafe static int NewGore(Vector2 Position, Vector2 Velocity, int Type, double Scale = 1.0)
		{
			int GoreIdx = LastGoreIndex++ & 0x7F;
			fixed (Gore* ActiveGore = &Main.GoreSet[GoreIdx])
			{
				ActiveGore->Position = Position;
				ActiveGore->Velocity = Velocity;
				ActiveGore->Velocity.Y -= Main.Rand.Next(10, 31) * 0.1f;
				ActiveGore->Velocity.X += Main.Rand.Next(-20, 21) * 0.1f;
				ActiveGore->Type = (byte)Type;
				ActiveGore->Active = 1;
				ActiveGore->Rotation = 0f;
				if (Type == (int)EntityID.GoreID.FALLEN_STAR_PARTICLE1 || Type == (int)EntityID.GoreID.FALLEN_STAR_PARTICLE2)
				{
					ActiveGore->Sticky = false;
					ActiveGore->Alpha = 100;
					ActiveGore->Scale = 0.7f;
					ActiveGore->Light = 1f;
					return GoreIdx;
				}
				if ((Type >= (int)EntityID.GoreID.SMOKE_BLUE1 && Type <= (int)EntityID.GoreID.SMOKE_BLUE3) || (Type >= (int)EntityID.GoreID.SMOKE_WHITE1 && Type <= (int)EntityID.GoreID.SMOKE_WHITE3) || Type == (int)EntityID.GoreID.SMOKE_BLACK)
				{
					ActiveGore->Sticky = false;
				}
				else
				{
					ActiveGore->Sticky = true;
					ActiveGore->TimeLeft = GoreTime;
				}
				ActiveGore->Scale = (float)Scale;
				ActiveGore->Alpha = 0;
				ActiveGore->Light = 0f;

#if VERSION_101
				if (Type >= (int)EntityID.GoreID.SMOKE_PURPLE1 && Type <= (int)EntityID.GoreID.SMOKE_PURPLE3)
				{
					ActiveGore->Alpha = 100;
					ActiveGore->Sticky = false;
				}
#endif
			}
			return GoreIdx;
		}

		public unsafe static int NewGore(int X, int Y, Vector2 Velocity, int Type)
		{
			return NewGore(new Vector2(X, Y), Velocity, Type); // This was originally a full duplicate function, I got no clue why they did that.
		}

		public Color GetAlpha(Color GoreColour)
		{
			int R;
			int G;
			int B;
			if (Type == (int)EntityID.GoreID.FALLEN_STAR_PARTICLE1 || Type == (int)EntityID.GoreID.FALLEN_STAR_PARTICLE2)
			{
				R = GoreColour.R;
				G = GoreColour.G;
				B = GoreColour.B;
			}
			else
			{
				double AlphaAdjust = (255.0 - Alpha) / 255;
				R = (int)(GoreColour.R * AlphaAdjust);
				G = (int)(GoreColour.G * AlphaAdjust);
				B = (int)(GoreColour.B * AlphaAdjust);
			}
			int A = GoreColour.A - Alpha;
			if (A < 0)
			{
				A = 0;
			}
			if (A > 255)
			{
				A = 255;
			}
			return new Color(R, G, B, A);
		}
	}
}
