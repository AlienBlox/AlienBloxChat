using Microsoft.Xna.Framework;
using System.Collections.ObjectModel;
using Terraria.ModLoader;

namespace AlienBloxChat.ChatOverride.System
{
    public class ChatCache : ModSystem
    {
        public static ObservableCollection<(string, Color)> ChatOutput;

        public override void Load()
        {
            ChatOutput = [];
        }

        public override void Unload()
        {
            ChatOutput?.Clear();
            ChatOutput = null;
        }
    }
}