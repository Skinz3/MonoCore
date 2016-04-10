using Microsoft.Xna.Framework;
using MonoCore;
using MonoCore.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenGLTest
{
    public class MyGame : CoreGame
    {
        protected override void LoadContent()
        {
            base.LoadContent();

            // Charger votre contenu ici (Manager.GetSprite())

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.MediumVioletRed);
            Manager.Batch.Begin();

            // Votre code dessin ici

            Manager.Batch.End();
            base.Draw(gameTime);
        }
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            // Code d'update ici
        }
    }
}
