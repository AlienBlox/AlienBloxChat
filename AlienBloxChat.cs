using AlienBloxChat.ChatOverride.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace AlienBloxChat
{
	// Please read https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide#mod-skeleton-contents for more information about the various files in a mod.
	public class AlienBloxChat : Mod
	{
        public override void Load()
        {
            On_Main.NewText_string_byte_byte_byte += ChatOutput;
        }

        public override void Unload()
        {
            On_Main.NewText_string_byte_byte_byte -= ChatOutput;
        }

        public static void ChatOutput(On_Main.orig_NewText_string_byte_byte_byte orig, string newText, byte R, byte G, byte B)
        {
            ChatCache.ChatOutput.Add((newText, new(R, G, B)));
        }
	}
}
