using AlienBloxChat.ChatOverride.System;
using AlienBloxChat.ChatOverride.UI.ChatRenders;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Chat;
using Terraria.ModLoader;

namespace AlienBloxChat
{
	// Please read https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide#mod-skeleton-contents for more information about the various files in a mod.
	public class AlienBloxChat : Mod
	{
        public AlienBloxChat Instance { get; private set; }

        /// <summary>
        /// Don't see this or you will exception out
        /// </summary>
        public AlienBloxChat()
        {
            Instance = this;
        }

        /// <summary>
        /// Freaks in sheets
        /// </summary>
        ~AlienBloxChat()
        {
            Instance = null;
        }

        public override void Load()
        {
            On_Main.NewText_string_byte_byte_byte += ChatOutput;
            On_Main.NewText_object_Nullable1 += ChatOutput;
            On_Main.NewTextMultiline += ChatOutput;
            On_ChatCommandProcessor.ProcessIncomingMessage += ChatOutput;
            On_ChatCommandProcessor.CreateOutgoingMessage += ChatV2Commands;
        }

        public override void Unload()
        {
            On_Main.NewText_string_byte_byte_byte -= ChatOutput;
            On_Main.NewText_object_Nullable1 -= ChatOutput;
            On_Main.NewTextMultiline -= ChatOutput;
            On_ChatCommandProcessor.ProcessIncomingMessage -= ChatOutput;
            On_ChatCommandProcessor.CreateOutgoingMessage -= ChatV2Commands;
        }

        public static void ChatOutput(On_Main.orig_NewText_string_byte_byte_byte orig, string newText, byte R, byte G, byte B)
        {
            ChatCache.ChatOutput.Add((newText, new(R, G, B)));

            orig(newText, R, G, B);
        }

        public static void ChatOutput(On_Main.orig_NewText_object_Nullable1 orig, object o, Color? color)
        {
            if (color == null)
            {
                color = Color.White;
            }
            
            ChatCache.ChatOutput.Add((o.ToString(), color.GetValueOrDefault()));

            orig(o, color);
        }

        public static void ChatOutput(On_Main.orig_NewTextMultiline orig, string text, bool force, Color color, int WidthLimit)
        {
            ChatCache.ChatOutput.Add((text, color));

            orig(text, force, color, WidthLimit);
        }

        public static void ChatOutput(On_ChatCommandProcessor.orig_ProcessIncomingMessage orig, ChatCommandProcessor self, ChatMessage message, int clientId)
        {
            if (message.Text.IsCommand())
            {
                return;
            }

            ChatCache.ChatOutput.Add(($"[{Main.player[clientId].name}]: " + message.Text, Color.White));

            ChatV2Render.WriteLine($"[{Main.player[clientId].name}]: " + message.Text);

            orig(self, message, clientId);
        }

        public static ChatMessage ChatV2Commands(On_ChatCommandProcessor.orig_CreateOutgoingMessage orig, ChatCommandProcessor self, string text)
        {
            switch (text.ToLower())
            {
                case "/clear":
                    ChatV2Render.Clear();
                    break;
            }

            return orig(self, text);
        }
    }
}
