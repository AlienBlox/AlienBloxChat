using AlienBloxChat.ChatOverride.ChatPlayer;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.GameInput;
using Terraria.Localization;
using Terraria.UI;

namespace AlienBloxChat
{
    public static class AlienBloxChatSpecials
    {
        public static string Colorize(this string s, Color color)
        {
            return $"[c/{color.Hex3()}:{s}]";
        }

        public static Vector2 Size(this CalculatedStyle style)
        {
            return new(style.Width, style.Height);
        }

        public static byte ToNumber(bool b)
        {
            return (byte)(b ? 1 : 0);
        }

        /// <summary>
        /// Quickly inserts a text into an UI element
        /// </summary>
        /// <param name="element">The element to insert into</param>
        /// <param name="text">The text</param>
        /// <param name="textScale">The text scale</param>
        /// <param name="large">Should the text be large</param>
        /// <returns>The created text.</returns>
        public static UIText InsertText(this UIElement element, string text, float textScale = 1, bool large = false)
        {
            UIText textElement = new(text, textScale, large);

            textElement.Width.Set(0, 1);
            textElement.Height.Set(0, 1);
            textElement.VAlign = textElement.HAlign = 0.5f;

            element.Append(textElement);

            return textElement;
        }

        /// <summary>
        /// Quickly inserts a text into an UI element
        /// </summary>
        /// <param name="element">The element to insert into</param>
        /// <param name="text">The localized text</param>
        /// <param name="textScale">The text scale</param>
        /// <param name="large">Should the text be large</param>
        /// <returns>The created text.</returns>
        public static UIText InsertText(this UIElement element, LocalizedText text, float textScale = 1, bool large = false)
        {
            UIText textElement = new(text, textScale, large);

            textElement.Width.Set(0, 1);
            textElement.Height.Set(0, 1);
            textElement.VAlign = textElement.HAlign = 0.5f;
            textElement.TextOriginY = 0.5f;

            element.Append(textElement);

            return textElement;
        }

        public static bool IsCommand(this string s)
        {
            return s.ToLower() switch
            {
                "/clear" => true,
                _ => false,
            };
        }

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