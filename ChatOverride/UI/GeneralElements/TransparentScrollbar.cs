using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace AlienBloxChat.ChatOverride.UI.GeneralElements
{
    public class TransparentScrollbar(UserInterface userInterface) : FixedUIScrollbar(userInterface)
    {
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            //Don't draw the scrollbar background or the scroll thumb, making it effectively invisible.
        }
    }
}