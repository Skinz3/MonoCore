using Microsoft.Xna.Framework;
using MonoCore.Graphics;
using MonoCore.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoCore
{
    /// <summary>
    /// Skinz 2016, le but de MonoCore est de simplifier et d'ajouter des fonctionalités au moteur de jeu MonoGame lui même repris 
    /// du moteur XNA développé par Microsoft
    /// MonoGame: http://www.monogame.net/
    /// Tout droits reservés
    /// </summary>
    public class CoreGame : Game
    {
        GraphicsDeviceManager graphics;

        MonoBatch Batch { get; set; }

        public CoreGame()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
        }
        protected override void LoadContent()
        {
            Batch = new MonoBatch(GraphicsDevice);
            Manager.LoadContent(Content, Batch);
            base.LoadContent();
        }
    }
}
