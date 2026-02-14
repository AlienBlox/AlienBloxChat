using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.UI.Elements;
using Terraria.Localization;

namespace AlienBloxChat.ChatOverride.UI.GeneralElements
{
    public class ItemBoxRender : UIPanel
    {
        private readonly UIItemIcon _icon;

        private readonly LocalizedText _text;

        private readonly string _hoverText;

        public readonly int itemID;
        
        public ItemBoxRender(int item, string hoverText)
        {
            _icon = new(new(item), false);
            _icon.Width.Set(0, 1);
            _icon.Height.Set(0, 1);
            _hoverText = hoverText;
            itemID = item;

            Append(_icon);
        }

        public ItemBoxRender(int item, LocalizedText text)
        {
            _icon = new(new(item), false);
            _icon.Width.Set(0, 1);
            _icon.Height.Set(0, 1);
            _text = text;
            itemID = item;

            Append(_icon);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            if (_text != null)
                this.SetUIBase(_text.Value);
            else
                this.SetUIBase(_hoverText);

            base.DrawSelf(spriteBatch);
        }
    }
}