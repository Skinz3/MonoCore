using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoCore.Objects
{
    /// <summary>
    /// Classe dont doit hériter tout sprite
    /// </summary>
    public abstract class WObject : IObject
    {
        public Point Position = new Point();

        public SpriteEffects SpriteEffect = SpriteEffects.None;

        public float Rotation = 0;

        public Vector2 RotationOrigin = Vector2.Zero;

        public Color Color = Color.White;

        public float ContrastPercent = 100;

        public abstract void Update(GameTime time);

        public abstract void Draw(GameTime time);

        public void AddTransparency(sbyte percentage)
        {
            if (ContrastPercent - percentage <= 0)
                ContrastPercent = 0;
            else
                ContrastPercent -= percentage;
        }
        public void RemoveTransparency(sbyte percentage = 100)
        {
            if (percentage >= 100)
                ContrastPercent = 100;
            else
                ContrastPercent += percentage;
        }


    }
}
