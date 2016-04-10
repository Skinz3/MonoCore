using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using MonoCore.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MonoCore.Managers
{
    public class Manager
    {
        /// <summary>
        /// Extensions de fichier pour les sprites autorisés
        /// </summary>
        public static string[] SpriteExtensions = new string[] { ".gif", ".png", ".jpg", ".jpeg",".bmp" };

        /// <summary>
        /// Gestionaire de contenu XNA (pour charger les textures)
        /// </summary>
        public static ContentManager ContentManager { get; set; }
        /// <summary>
        /// Polices chargés
        /// </summary>
        private static Dictionary<string, SpriteFont> Fonts = new Dictionary<string, SpriteFont>();
        /// <summary>
        /// Liste des sprites chargables
        /// </summary>
        public static List<Sprite> Sprites = new List<Sprite>();
        /// <summary>
        /// Liste des sprites chargés
        /// </summary>
        static List<Sprite> LoadedSprites = new List<Sprite>();
        /// <summary>
        /// SpriteBatch
        /// </summary>
        public static MonoBatch Batch { get; set; }
        /// <summary>
        /// Methode utilisé dans la classe derivée de Game: CoreGame
        /// </summary>
        /// <param name="content"></param>
        /// <param name="batch"></param>
        public static void LoadContent(ContentManager content, MonoBatch batch)
        {
            ContentManager = content;
            Batch = batch;
            LoadSprites();
        }
        /// <summary>
        /// Charge les sprites en memoire
        /// </summary>
        static void LoadSprites()
        {
            if (Directory.Exists(ContentManager.RootDirectory))
            {
                foreach (var file in Directory.GetFiles(ContentManager.RootDirectory))
                {
                    AddSprite(file);
                }
                foreach (var directory in Directory.GetDirectories(ContentManager.RootDirectory))
                {
                    foreach (var file in Directory.GetFiles(directory))
                    {
                        AddSprite(file);
                    }
                }
            }
        }

        public static List<string> GetSubfoldersNames()
        {
            List<string> results = new List<string>();
            foreach (var sprite in Sprites)
            {
                string dirName = Path.GetDirectoryName(sprite.Path);
                if (dirName != "Content")
                    results.Add(dirName.Split('\\').Last());
            }
            return results.Distinct().ToList();
        }
       /// <summary>
       /// Decharge les données d'un sprite en mémoire
       /// </summary>
       /// <param name="name"></param>
        public static void Unload(string name)
        {
            Sprite sprite = Sprites.Find(x => x.Name == name);
            sprite.Unload();
            LoadedSprites.Remove(sprite);
        }
        /// <summary>
        /// Charge un sprite en mémoire, Utilisé avec la méthode GetSprite()
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static Sprite Load(string name)
        {
            Sprite sprite = Sprites.Find(x => x.Name == name);
            if (sprite == null)
                return null;
            sprite.TryLoad();
            LoadedSprites.Add(sprite);
            return sprite;
        }
        static void AddSprite(string file)
        {
            string name = Path.GetFileNameWithoutExtension(file);
            string extension = Path.GetExtension(file);

            if (SpriteExtensions.Contains(extension))
            {
                Sprite sprite = new Sprite(name, extension, file);
                Sprites.Add(sprite);
            }
        }
        /// <summary>
        /// Retourne le GFX d'un sprite a partir d'un path.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static Texture2D ReadTexture(string file)
        {
            return Texture2D.FromStream(Batch.GraphicsDevice, new MemoryStream(File.ReadAllBytes(file)));
        }
        /// <summary>
        /// Permet de charger en mémoire puis d'obtenir un sprite
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Sprite GetSprite(string name)
        {
            Load(name);
            return LoadedSprites.Find(x => x.Name == name);
        }

    }
}
