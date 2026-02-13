using AlienBloxChat.ChatOverride.System;
using AlienBloxChat.ChatOverride.UI.GeneralElements;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Specialized;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.UI;

namespace AlienBloxChat.ChatOverride.UI.ChatElements
{
    public class ChatV2 : UIState
    {
        public UIPanel TextBarBacking;

        public ItemBoxRender CommandsButton, ItemPickerButton, TextColorButton;

        public UIElement TextRenderBox, Backing, ChatHistoryBacking;

        public UIText ChatText;

        public UIList ChatHistory;

        public FixedUIScrollbar Scroller;

        public int HideFull;

        public bool HideUI;

        public override void OnInitialize()
        {
            CommandsButton = new(ItemID.PaperAirplaneA, "Commands");
            ItemPickerButton = new(ItemID.DirtBlock, "Item Picker");
            TextColorButton = new(ItemID.RainbowCursor, "Text Color Selector");
            ChatText = new(string.Empty);
            TextRenderBox = new();
            Backing = new();
            ChatHistoryBacking = new();
            TextBarBacking = new();
            Scroller = new(UserInterface.ActiveInstance);
            ChatHistory = [];

            //Backing.BackgroundColor = Backing.BorderColor = new(0, 0, 0, 0);

            CommandsButton.Width = ItemPickerButton.Width = TextColorButton.Width = new(50, 0);
            CommandsButton.Height = ItemPickerButton.Height = TextColorButton.Height = new(0, 1);
            CommandsButton.BackgroundColor = ItemPickerButton.BackgroundColor = TextColorButton.BackgroundColor = CommandsButton.BorderColor = ItemPickerButton.BorderColor = TextColorButton.BorderColor = new(0, 0, 0, 0);

            CommandsButton.HAlign = 1;
            ItemPickerButton.HAlign = 1;
            ItemPickerButton.Left.Set(-50, 0);
            TextColorButton.HAlign = 1;
            TextColorButton.Left.Set(-100, 0);

            Backing.SetPadding(0);
            ChatHistoryBacking.SetPadding(0);
            TextBarBacking.SetPadding(0);

            Scroller.Height.Set(0, 1);

            ChatHistory.Width.Set(0, 1);
            ChatHistory.Height.Set(0, 1);
            ChatHistory.SetScrollbar(Scroller);

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

            ChatText.Width.Set(0, 1);
            ChatText.Height.Set(0, 1);
            ChatText.TextOriginX = 0;
            TextRenderBox.SetPadding(15);
            TextRenderBox.Width.Set(0, 1f);
            TextRenderBox.Height.Set(0, 1);
            TextRenderBox.HAlign = 0;
            TextRenderBox.Append(ChatText);

            Backing.Width.Set(0, .85f);
            Backing.Height.Set(500, 0);
            Backing.Top.Set(-40, 0);
            Backing.VAlign = 1;
            Backing.HAlign = .5f;

            TextBarBacking.Append(TextRenderBox);
            TextBarBacking.Append(CommandsButton);
            TextBarBacking.Append(ItemPickerButton);
            TextBarBacking.Append(TextColorButton);

            Backing.Append(ChatHistoryBacking);
            Backing.Append(TextBarBacking);

            Append(Backing);

            ChatCache.ChatOutput.CollectionChanged += OnChatThing;
        }

        public void OnChatThing(object sender, NotifyCollectionChangedEventArgs e)
        {
            /*
            try
            {
                foreach (var item in e.NewItems)
                {
                    if (item is ValueTuple<string, Color> value)
                    {
                        UIText content = new($"[c/{value.Item2.Hex3()}:{value.Item1}");

                        content.Width.Set(0, 1);
                        content.Height.Set(30, 0);
                        ChatHistory.Add(content);
                        SoundEngine.PlaySound(SoundID.MenuTick);
                    }
                }
            }
            catch
            {

            }
            */
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

            base.Update(gameTime);
        }
    }
}