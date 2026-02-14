using AlienBloxChat.ChatOverride.FrontendHelpers;
using AlienBloxChat.ChatOverride.UI.ChatRenders;
using AlienBloxChat.ChatOverride.UI.GeneralElements;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.Localization;
using Terraria.UI;

namespace AlienBloxChat.ChatOverride.UI.ChatElements
{
    public class ChatV2 : UIState
    {
        public UIPanel TextBarBacking, SettingsCard, SettingsTopBar, SettingsBody;

        public ItemBoxRender CommandsButton, ItemPickerButton, TextColorButton, SettingsButton, ClosePanel;

        public UIElement TextRenderBox, Backing, ChatHistoryBacking;

        public UIText ChatText, Header;

        public UIList ChatHistory;

        public FixedUIScrollbar Scroller;

        public int HideFull;

        public bool HideUI, ShowCard, AlwaysShow;

        public override void OnInitialize()
        {
            CommandsButton = new(ItemID.PaperAirplaneA, Language.GetOrRegister("Mods.AlienBloxChat.UI.CommandsButton"));
            ItemPickerButton = new(ItemID.DirtBlock, Language.GetOrRegister("Mods.AlienBloxChat.UI.ItemPicker"));
            TextColorButton = new(ItemID.RainbowCursor, Language.GetOrRegister("Mods.AlienBloxChat.UI.TextColorButton"));
            SettingsButton = new(ItemID.Cog, Language.GetOrRegister("Mods.AlienBloxChat.UI.SettingsButton"));
            ClosePanel = new(ItemID.ClosedVoidBag, Language.GetOrRegister("Mods.AlienBloxChat.UI.CloseButton"));
            ChatText = new(string.Empty);
            TextRenderBox = new();
            Backing = new();
            ChatHistoryBacking = new();
            TextBarBacking = new();
            Scroller = new(UserInterface.ActiveInstance);
            SettingsCard = new();
            SettingsBody = new();
            SettingsTopBar = new();
            Header = new(Language.GetOrRegister("Mods.AlienBloxChat.UI.Header"));
            ChatHistory = [];

            //Backing.BackgroundColor = Backing.BorderColor = new(0, 0, 0, 0);
            SettingsBody.SetPadding(0);
            SettingsCard.SetPadding(0);
            SettingsTopBar.SetPadding(0);
            SettingsBody.Width.Set(0, 1);
            SettingsBody.Height.Set(0, .9f);
            SettingsBody.VAlign = 1;

            SettingsTopBar.Width.Set(0, 1);
            SettingsTopBar.Height.Set(0, .1f);
            SettingsTopBar.VAlign = 0;
            Header.Width.Set(0, 1);
            Header.Height.Set(0, 1);
            Header.TextOriginY = .5f;
            SettingsTopBar.Append(Header);
            ClosePanel.Width.Set(30, 0);
            ClosePanel.Height.Set(0, 1);
            SettingsTopBar.Append(ClosePanel);

            SettingsCard.Append(SettingsBody);
            SettingsCard.Append(SettingsTopBar);

            SettingsButton.Width = CommandsButton.Width = ItemPickerButton.Width = TextColorButton.Width = new(50, 0);
            SettingsButton.Height = CommandsButton.Height = ItemPickerButton.Height = TextColorButton.Height = new(0, 1);
            SettingsButton.BackgroundColor = CommandsButton.BackgroundColor = ItemPickerButton.BackgroundColor = TextColorButton.BackgroundColor = SettingsButton.BorderColor = CommandsButton.BorderColor = ItemPickerButton.BorderColor = TextColorButton.BorderColor = new(0, 0, 0, 0);

            CommandsButton.HAlign = 1;
            ItemPickerButton.HAlign = 1;
            ItemPickerButton.Left.Set(-50, 0);
            TextColorButton.HAlign = 1;
            TextColorButton.Left.Set(-100, 0);
            SettingsButton.HAlign = 1;
            SettingsButton.Left.Set(-150, 0);

            Backing.SetPadding(0);
            ChatHistoryBacking.SetPadding(0);
            TextBarBacking.SetPadding(0);

            Scroller.Height.Set(0, 1);
            Scroller.HAlign = 1;

            ChatHistory.Width.Set(0, 1);
            ChatHistory.Height.Set(0, 1);
            ChatHistory.SetScrollbar(Scroller);
            ChatHistory.ManualSortMethod = (_) => { };

            ChatHistoryBacking.Append(Scroller);

            ChatHistoryBacking.Width.Set(0, 1);
            ChatHistoryBacking.Height.Set(0, 1);
            ChatHistoryBacking.VAlign = 0;
            ChatHistoryBacking.Append(ChatHistory);
            //ChatHistoryBacking.BackgroundColor.A = 0;
            TextBarBacking.BackgroundColor.A = 255;
            TextBarBacking.Width.Set(0, 1);
            TextBarBacking.Height.Set(0, .1f);
            TextBarBacking.VAlign = 1;
            TextBarBacking.BackgroundColor = new(0, 0, 0);

            ChatText.Width.Set(0, 1);
            ChatText.Height.Set(0, 1);
            ChatText.TextOriginX = 0;
            TextRenderBox.SetPadding(15);
            TextRenderBox.Width.Set(0, 1f);
            TextRenderBox.Height.Set(0, 1);
            TextRenderBox.HAlign = 0;
            TextRenderBox.Append(ChatText);

            SettingsCard.Width.Set(-20, .25f);
            SettingsCard.Height.Set(-50, .9f);
            SettingsCard.Left.Set(-20, 0);
            SettingsCard.Top.Set(-20, .1f);
            SettingsCard.VAlign = 0;
            SettingsCard.HAlign = 1;
            SettingsCard.MaxWidth.Set(350, 0);

            ChatHistoryBacking.Append(SettingsCard);

            Backing.Width.Set(0, .85f);
            Backing.Height.Set(500, 0);
            Backing.Top.Set(-40, 0);
            Backing.VAlign = 1;
            Backing.HAlign = .5f;

            TextBarBacking.Append(TextRenderBox);
            TextBarBacking.Append(CommandsButton);
            TextBarBacking.Append(ItemPickerButton);
            TextBarBacking.Append(TextColorButton);
            TextBarBacking.Append(SettingsButton);

            SettingsButton.OnLeftClick += (_, _) =>
            {
                CreateSettingsPage();
            };

            ClosePanel.OnLeftClick += (_, _) =>
            {
                ShowCard = false;
                SettingsBody.RemoveAllChildren();
                SettingsCard.Remove();
            };

            Backing.Append(ChatHistoryBacking);
            Backing.Append(TextBarBacking);

            Append(Backing);
        }

        public void SetSettingsCard(bool Enabled, UIElement elem)
        {
            if (elem == null)
            {
                ShowCard = false;
                SettingsBody.RemoveAllChildren();

                return;
            }

            ShowCard = Enabled;
            SettingsBody.RemoveAllChildren();
            SettingsBody.Append(elem);

            if (Enabled)
            {
                ChatHistoryBacking.Append(SettingsCard);
            }
            else
            {
                SettingsCard.Remove();
            }
        }

        public UIList CreateSettingsPage()
        {
            UIList SettingsThing = [];
            FixedUIScrollbar Scroller = new(UserInterface.ActiveInstance);

            SettingsThing.Width.Set(0, 1);
            SettingsThing.Height.Set(0, 1);
            SettingsThing.ManualSortMethod = (_) => { };
            SettingsThing.Clear();
            SettingsThing.SetScrollbar(Scroller);

            SettingsBody.Append(Scroller);

            UIPanel ClearChat = MenuKit.CreateButton(Language.GetOrRegister("Mods.AlienBloxChat.UI.SettingsTab.ClearChat"));
            CheckBoxToggle AlwaysShowButton = MenuKit.CreateCheckbox(Language.GetOrRegister("Mods.AlienBloxChat.UI.SettingsTab.AlwaysShow"));

            AlwaysShowButton.Check = AlwaysShow;

            ClearChat.OnLeftClick += (_, _) =>
            {
                ChatV2Render.Clear();
            };

            AlwaysShowButton.OnLeftClick += (_, _) =>
            {
                AlwaysShow = AlwaysShowButton.Check;
            };

            SettingsThing.AddRange([ClearChat, AlwaysShowButton]);

            SetSettingsCard(true, SettingsThing);

            return SettingsThing;
        }

        public override void Update(GameTime gameTime)
        {
            bool showPipe = (int)(gameTime.TotalGameTime.TotalSeconds / 1f) % 2 == 0;
            char pipe = (showPipe ? '|' : ' ');

            TextBarBacking.BorderColor = Main.DiscoColor;
            ChatText.SetText(Main.chatText + pipe);

            if (!Main.drawingPlayerChat)
            {
                TextBarBacking.Remove();
            }
            else
            {
                HideUI = false;
                HideFull = 0;
                Backing.Append(TextBarBacking);
                Append(Backing);
            }

            if (AlwaysShow)
            {
                HideUI = false;
                HideFull = 0;

                base.Update(gameTime);

                return;
            }

            if (!HideUI)
            {
                if (HideFull++ >= 60 * 3)
                {
                    HideUI = true;
                    HideFull = 0;
                    Append(Backing);
                }
            }
            else
            {
                Backing.Remove();
            }

            if (!ShowCard)
            {
                SettingsCard.Remove();
            }
            else
            {
                ChatHistoryBacking.Append(SettingsCard);
            }

            base.Update(gameTime);
        }
    }
}