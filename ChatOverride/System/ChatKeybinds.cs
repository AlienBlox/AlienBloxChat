using Microsoft.Xna.Framework.Input;
using Terraria.ModLoader;

namespace AlienBloxChat.ChatOverride.System
{
    public class ChatKeybinds : ModSystem
    {
        public static ModKeybind OpenChat { get; set; }

        public override void Load()
        {
            OpenChat = KeybindLoader.RegisterKeybind(Mod, "OpenChat", Keys.Enter);
        }
    }
}