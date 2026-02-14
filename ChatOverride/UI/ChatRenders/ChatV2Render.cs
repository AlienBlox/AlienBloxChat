using AlienBloxChat.ChatOverride.System;
using AlienBloxChat.ChatOverride.UI.ChatElements;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;

namespace AlienBloxChat.ChatOverride.UI.ChatRenders
{
    [Autoload(Side = ModSide.Client)]
    public class ChatV2Render : ModSystem
    {
        public static ChatV2Render Instance => ModContent.GetInstance<ChatV2Render>();

        internal ChatV2 Element;

        private UserInterface _element;

        public override void Load()
        {
            Element = new();
            Element.Activate();
            _element = new UserInterface();
            _element.SetState(Element);
        }

        public override void UpdateUI(GameTime gameTime)
        {
            /*
            if (Main.drawingPlayerChat)
            {
                if (_element?.CurrentState == null)
                {
                    _element?.SetState(Element);
                }

                _element?.Update(gameTime);
            }
            else
            {
                _element?.SetState(null);
            }
            */
            _element?.Update(gameTime);
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            GameInterfaceLayer ChatLayer = layers.Find(layer => layer.Name.Equals("Vanilla: Player Chat"));

            if (mouseTextIndex != -1)
            {
                layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                    "AlienBloxChat: AlienBlox's Chat",
                    delegate
                    {
                        _element.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }

            if (ChatLayer != null)
            {
                ChatLayer.Active = false;
            }
        }

        public static void WriteLine(string text)
        {
            string[] lines = text.Split('\n');

            if (Instance.Element == null)
            {
                return;
            }

            List<UIText> computeLines = [];
            computeLines.Clear();

            foreach (var line in lines)
            {
                UIText TextObj = new(line);

                TextObj.Width.Set(-30, 1);
                TextObj.Height.Set(30, 0);
                TextObj.TextOriginX = 0;
                TextObj.HAlign = 1;

                computeLines.Add(TextObj);
            }

            Instance.Element.ChatHistory.AddRange(computeLines);
        }

        public static void Clear()
        {
            if (Instance.Element == null)
            {
                return;
            }

            Instance.Element.ChatHistory.Clear();
            ChatCache.ChatOutput.Clear();
        }
    }
}