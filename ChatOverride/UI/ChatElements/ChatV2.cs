using AlienBloxChat.ChatOverride.UI.GeneralElements;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.UI;

namespace AlienBloxChat.ChatOverride.UI.ChatElements
{
    public class ChatV2 : UIState
    {
        public UIPanel ChatHistoryBacking, TextBarBacking;

        public ItemBoxRender CommandsButton, ItemPickerButton, TextColorButton;

        public UIElement TextRenderBox, Backing;

        public UIText ChatText;

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

            ChatHistoryBacking.Width.Set(0, 1);
            ChatHistoryBacking.Height.Set(0, 1);
            ChatHistoryBacking.VAlign = 0;
            ChatHistoryBacking.BackgroundColor.A = 0;
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
        }

        public override void Update(GameTime gameTime)
        {
            TextBarBacking.BorderColor = Main.DiscoColor;
            ChatText.SetText(Main.chatText);

            if (!Main.drawingPlayerChat)
            {
                TextBarBacking.Remove();
            }
            else
            {
                Backing.Append(TextBarBacking);
            }

            base.Update(gameTime);
        }
    }
}