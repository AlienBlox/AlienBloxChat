using AlienBloxChat.ChatOverride.UI.ChatRenders;
using Terraria.ModLoader;

namespace AlienBloxChat.ChatOverride.ChatPlayer
{
    public class ChatPlayer : ModPlayer
    {
        public override void OnEnterWorld()
        {
            ChatV2Render.Clear();
        }
    }
}