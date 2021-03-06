using System.Collections.Generic;

using PoeHUD.Models.Enums;

using SharpDX;

namespace PoeHUD.Hud.Loot
{
    public sealed class AlertDrawStyle
    {
        private static readonly Dictionary<ItemRarity, Color> colors = new Dictionary<ItemRarity, Color>
        {
            { ItemRarity.White, Color.White },
            { ItemRarity.Magic, HudSkin.MagicColor },
            { ItemRarity.Rare, HudSkin.RareColor },
            { ItemRarity.Unique, HudSkin.UniqueColor },
        };

        public AlertDrawStyle(object colorRef, int frameWidth, string text, int iconIndex)
        {
            FrameWidth = frameWidth;
            Text = text;
            IconIndex = iconIndex;

            if (colorRef is Color)
            {
                AlertColor = (Color)colorRef;
            }
            else
            {
                Color tempColor;
                AlertColor = colors.TryGetValue((ItemRarity)colorRef, out tempColor) ? tempColor : Color.White;
            }
        }

        public Color AlertColor { get; private set; }

        public int FrameWidth { get; private set; }

        public string Text { get; private set; }

        public int IconIndex { get; private set; }
    }
}