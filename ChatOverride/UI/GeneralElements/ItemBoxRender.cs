using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.UI.Elements;

namespace AlienBloxChat.ChatOverride.UI.GeneralElements
{
    public class ItemBoxRender : UIPanel
    {
        private readonly UIItemIcon _icon;

        private readonly string _hoverText;

        public ItemBoxRender(int item, string hoverText)
        {
            _icon = new(new(item), false);
            _icon.Width.Set(0, 1);
            _icon.Height.Set(0, 1);
            _hoverText = hoverText;

            Append(_icon);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            this.SetUIBase(_hoverText);

            base.DrawSelf(spriteBatch);
        }
    }
}