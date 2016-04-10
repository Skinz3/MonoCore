using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoCore.Objects
{
    /// <summary>
    /// Représente un objet dessinable et updatable
    /// </summary>
    public interface IObject
    {
        void Draw(GameTime time);
        void Update(GameTime time);
    }
}
