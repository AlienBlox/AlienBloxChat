using AlienBloxChat.ChatOverride.ChatPlayer;
using Terraria;
using Terraria.GameInput;
using Terraria.UI;

namespace AlienBloxChat
{
    public static class AlienBloxChatSpecials
    {
        public static ChatPlayer GetChatPlr(this Player plr)
        {
            return plr.GetModPlayer<ChatPlayer>();
        }

        /// <summary>
        /// Does the base locking action for the UI like setting mouseInterface
        /// </summary>
        /// <param name="Element">The element to do for</param>
        /// <param name="textToDisplay">What text should be displayed when you hover over the UI</param>
        /// <param name="ApplyToChildren">Should this be applied to children elements</param>
        /// <param name="fix"></param>
        public static void SetUIBase(this UIElement Element, string textToDisplay, bool ApplyToChildren = false, bool fix = false)
        {
            if (Element.IsMouseHovering && !fix)
            {
                Main.hoverItemName = textToDisplay;
            }

            if (Element.ContainsPoint(Main.screenPosition) && fix)
            {
                Main.hoverItemName = textToDisplay;
            }

            if (Element.ContainsPoint(Main.MouseScreen))
            {
                Main.LocalPlayer.mouseInterface = true;
            }

            if (Element.IsMouseHovering)
            {
                PlayerInput.LockVanillaMouseScroll("AlienBloxUtility/ScrollListA"); // The passed in string can be anything.
            }

            if (ApplyToChildren)
            {
                foreach (UIElement elementSub in Element.Children)
                {
                    if (elementSub.ContainsPoint(Main.MouseScreen))
                    {
                        Main.LocalPlayer.mouseInterface = true;
                    }

                    if (elementSub.IsMouseHovering)
                    {
                        PlayerInput.LockVanillaMouseScroll("AlienBloxUtility/ScrollListB"); // The passed in string can be anything.
                    }
                }
            }
        }
    }
}