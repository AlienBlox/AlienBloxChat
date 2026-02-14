using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;

namespace AlienBloxChat.ChatOverride.UI.GeneralElements
{
    public class CheckBoxToggle : UIPanel
    {
        public Asset<Texture2D> Texture;

        public UIElement DrawPoint;

        public UIText Text;

        public bool Check;

        public CheckBoxToggle(string text = "Puppy")
        {
            Texture = ModContent.Request<Texture2D>("AlienBloxChat/Assets/CheckBox");

            SetPadding(0);
            DrawPoint = new();
            DrawPoint.Width.Set(20, 0);
            DrawPoint.Height.Set(20, 0);
            DrawPoint.VAlign = .5f;
            DrawPoint.HAlign = 1;
            DrawPoint.Left.Set(-20, 0);

            Text = new(text);
            Text.Width.Set(0, 1);
            Text.Height.Set(0, 1);
            Text.TextOriginY = .5f;
            Text.TextOriginX = 0.1f;

            Append(Text);
            Append(DrawPoint);
        }

        public CheckBoxToggle(LocalizedText text)
        {
            Texture = ModContent.Request<Texture2D>("AlienBloxChat/Assets/CheckBox");

            SetPadding(0);
            DrawPoint = new();
            DrawPoint.Width.Set(20, 0);
            DrawPoint.Height.Set(20, 0);
            DrawPoint.VAlign = .5f;
            DrawPoint.HAlign = 1;
            DrawPoint.Left.Set(-20, 0);

            Text = new(text);
            Text.Width.Set(0, 1);
            Text.Height.Set(0, 1);
            Text.TextOriginY = .5f;
            Text.TextOriginX = 0.1f;

            Append(Text);
            Append(DrawPoint);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);

            Rectangle rect = new(0, 20 * Check.ToInt(), 20, 20);

            spriteBatch.Draw(Texture.Value, (DrawPoint?.GetDimensions().Position()).GetValueOrDefault(), rect, Main.DiscoColor);
        }

        public override void LeftClick(UIMouseEvent evt)
        {
            Check = !Check;
            SoundEngine.PlaySound(SoundID.MenuTick);

            base.LeftClick(evt);
        }
    }
}