using AlienBloxChat.ChatOverride.UI.GeneralElements;
using Terraria.GameContent.UI.Elements;
using Terraria.Localization;

namespace AlienBloxChat.ChatOverride.FrontendHelpers
{
    public static class MenuKit
    {
        public static UIPanel CreateButton()
        {
            UIPanel button = new();

            button.Width.Set(0, 1);
            button.Height.Set(30, 0);

            return button;
        }

        public static UIPanel CreateButton(string text)
        {
            return (UIPanel)CreateButton().InsertText(text).Parent;
        }

        public static UIPanel CreateButton(LocalizedText text)
        {
            return (UIPanel)CreateButton().InsertText(text).Parent;
        }

        public static CheckBoxToggle CreateCheckbox(string text)
        {
            CheckBoxToggle toggle = new(text);

            toggle.Width.Set(0, 1);
            toggle.Height.Set(30, 0);

            return toggle;
        }

        public static CheckBoxToggle CreateCheckbox(LocalizedText text)
        {
            CheckBoxToggle toggle = new(text);

            toggle.Width.Set(0, 1);
            toggle.Height.Set(30, 0);

            return toggle;
        }
    }
}