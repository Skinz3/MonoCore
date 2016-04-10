using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoCore.Managers
{
    public class Sprite
    {
        /// <summary>
        /// Nom du fichier sans l'extension
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Texture du sprite
        /// </summary>
        public Texture2D Gfx { get; set; }
        /// <summary>
        /// Extension du fichier
        /// </summary>
        public string Extension { get; set; }
        /// <summary>
        /// Emplacement du sprite
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// Represente le fait que le sprite soit chargé en mémoire ou non
        /// </summary>
        public bool Loaded { get { return Gfx != null; } }

        public Sprite(string name, string extension, string path)
        {
            this.Name = name;
            this.Extension = extension;
            this.Path = path;
        }
        /// <summary>
        /// Décharge les données du sprite
        /// </summary>
        public void Unload()
        {
            this.Gfx = null;
        }
        /// <summary>
        /// Charge les données du sprite
        /// </summary>
        public void TryLoad()
        {
            if (!Loaded)
                this.Gfx = Manager.ReadTexture(Path);
        }
        /// <summary>
        /// Redimensione le sprite et retourne un nouvel objet correspondant au sprite redimensioné
        /// </summary>
        /// <param name="percent"></param>
        /// <returns></returns>
        public ResizedSprite Resize(sbyte percent)
        {
            double ratio = (double)percent / (double)100;
            var newWidth = (double)this.Gfx.Bounds.Width * (double)ratio;
            var newHeight = (double)this.Gfx.Bounds.Height * (double)ratio;
            ResizedSprite sprite = new ResizedSprite(this, (int)newWidth, (int)newHeight);
            return sprite;
        }
        /// <summary>
        /// Dessine de façon primaire un sprite en conservant sa couleur d'origine, et sa taille d'origine
        /// </summary>
        /// <param name="position">Position du sprite</param>
        /// <param name="manageBatch">Do Begin End ?</param>
        public void EasyDraw(Point position,bool manageBatch = true) // Methode a virer? a mettre dans une classe dérivée de WObject?
        {
            if (manageBatch)
            Manager.Batch.Begin();
            Manager.Batch.Draw(Gfx, new Rectangle(position.X, position.Y, Gfx.Bounds.Width, Gfx.Bounds.Height), Color.White);
            if (manageBatch)
            Manager.Batch.End();
        }
    }
}
