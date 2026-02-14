using Microsoft.Xna.Framework;
using Terraria.GameContent.UI.Elements;

namespace AlienBloxChat.ChatOverride.UI.GeneralElements
{
    public class UIColorPicker : UIPanel
    {
        public UIPanel ColorPreview, ColorBar;

        public UIColoredSliderSimple /*UISliderBase*/ RScroll, GScroll, BScroll;

        public byte R, G, B;

        public Color SavedColor { get => new(R, G, B); set { R = value.R; G = value.G; B = value.B; } }

        public UIColorPicker()
        {
            SetPadding(0);

            Width.Set(1, 0);
            Height.Set(1, 0);

            ColorBar = new();
            ColorPreview = new();
            RScroll = new();
            GScroll = new();
            BScroll = new();
            
            RScroll.UseImmediateMode = true;
            GScroll.UseImmediateMode = true;
            BScroll.UseImmediateMode = true;

            RScroll.FilledColor = Color.Red;
            BScroll.FilledColor = Color.Blue;
            GScroll.FilledColor = Color.Green;

            RScroll.EmptyColor = Color.Black;
            GScroll.EmptyColor = Color.Black;
            BScroll.EmptyColor = Color.Black;

            RScroll.Height.Set(10, 0);
            GScroll.Height.Set(10, 0);
            BScroll.Height.Set(10, 0);

            RScroll.Width.Set(0, 1);
            GScroll.Width.Set(0, 1);
            BScroll.Width.Set(0, 1);

            RScroll.VAlign = 0;
            GScroll.VAlign = .5f;
            BScroll.VAlign = 1;

            ColorPreview.Width.Set(0, .5f);
            ColorPreview.Height.Set(0, 1);

            ColorBar.Width.Set(0, .5f);
            ColorBar.Height.Set(0, 1);
            ColorBar.HAlign = 1;

            ColorBar.Append(RScroll);
            ColorBar.Append(GScroll);
            ColorBar.Append(BScroll);

            Append(ColorPreview);
            Append(ColorBar);
        }

        public override void Update(GameTime gameTime)
        {
            R = (byte)(RScroll.FillPercent * 255);
            G = (byte)(GScroll.FillPercent * 255);
            B = (byte)(BScroll.FillPercent * 255);

            ColorPreview.BackgroundColor = SavedColor;

            base.Update(gameTime);
        }
    }
}