using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Puissance4
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Puissance4 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ObjetPuissance4 cadre;
        ObjetPuissance4 pionjaune;
        ObjetPuissance4 pionrouge;
        int[,] damier;
        const int VX = 6;
        const int VY = 7;
        bool joueur;
        ObjetPuissance4 jetonjaune;
        int positionjaune;
        bool touche_up;
        int etat;
        int niveau;


        public Puissance4()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            damier = new int[VX, VY]{
                {0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0}
            };
            joueur = true;
            positionjaune = 3;
            touche_up = true;
            etat = 0;
            niveau = 1;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            graphics.PreferredBackBufferWidth = 7 * 57 - 1;
            graphics.PreferredBackBufferHeight = 6 * 57 - 1 + 80;
            graphics.ApplyChanges();
            // on charge un objet mur 
            cadre = new ObjetPuissance4(Content.Load<Texture2D>("objets\\cadre"), new Vector2(0f, 0f), new Vector2(100f, 100f));
            pionjaune = new ObjetPuissance4(Content.Load<Texture2D>("objets\\pionjaune"), new Vector2(0f, 0f), new Vector2(100f, 100f));
            pionrouge = new ObjetPuissance4(Content.Load<Texture2D>("objets\\pionrouge"), new Vector2(0f, 0f), new Vector2(100f, 100f));
            jetonjaune = new ObjetPuissance4(Content.Load<Texture2D>("objets\\jetonjaune"), new Vector2(0f, 0f), new Vector2(100f, 100f));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            KeyboardState keyboard = Keyboard.GetState();
            if (etat >= 2)
            {
                if (keyboard.IsKeyDown(Keys.Enter))
                {
                    damier = new int[VX, VY]{
                        {0, 0, 0, 0, 0, 0, 0},
                        {0, 0, 0, 0, 0, 0, 0},
                        {0, 0, 0, 0, 0, 0, 0},
                        {0, 0, 0, 0, 0, 0, 0},
                        {0, 0, 0, 0, 0, 0, 0},
                        {0, 0, 0, 0, 0, 0, 0}
                    };
                    joueur = true;
                    positionjaune = 3;
                    touche_up = true;
                    etat = 0;
                    niveau++;
                }
            }

            else if (joueur)
            {
                if (keyboard.IsKeyDown(Keys.Right) && positionjaune < VX && touche_up)
                {
                    positionjaune++;
                    touche_up = false;
                }
                if (keyboard.IsKeyDown(Keys.Left) && positionjaune >0 && touche_up)
                {
                    positionjaune--;
                    touche_up = false;
                }
                if (keyboard.IsKeyDown(Keys.Down) && touche_up)
                {
                    etat =jouer(positionjaune);
                    touche_up = false;
                }
                if (keyboard.IsKeyUp(Keys.Left) && keyboard.IsKeyUp(Keys.Right) && keyboard.IsKeyUp(Keys.Down) && !touche_up)
                    touche_up = true;
            }
            else
            {
                etat =jouer(IA(niveau));
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            // TODO: Add your drawing code here
            int offsetX = 80;
            int offsetY = 0;
            SpriteFont _font;
            _font = Content.Load<SpriteFont>("AfficherText");
            Vector2 text =new Vector2(160, 0);

            for (int x = 0; x < VX; x++)
            {
                for (int y = 0; y < VY; y++)
                {
                    int xpos, ypos;
                    xpos = offsetX + x * 57;
                    ypos = offsetY + y * 57;
                    Vector2 pos = new Vector2(ypos, xpos);
                    if (damier[x, y] == 0)
                        spriteBatch.Draw(cadre.Texture, pos, Color.White);
                    else if (damier[x, y] == 2)
                        spriteBatch.Draw(pionrouge.Texture, pos, Color.White);
                    else if (damier[x, y] == 1)
                        spriteBatch.Draw(pionjaune.Texture, pos, Color.White);
                }
            }
            if (joueur)
            {
                Vector2 pos = new Vector2(offsetY + positionjaune * 57, 20);
                spriteBatch.Draw(jetonjaune.Texture, pos, Color.White);
            }
            if (etat == 2)
            {
                if (joueur)
                    spriteBatch.DrawString(_font, "Gagne !!!", text, Color.White);
                else
                    spriteBatch.DrawString(_font, "Perdu ...", text, Color.White);
            }
            else if (etat == 3)
                spriteBatch.DrawString(_font, "Match nul", text, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public int IA(int niveau)
        {
            // Niveau max d'IA !!!
            if (niveau > 2)
                niveau = 2;

            Random rnd = new Random();
            if (niveau == 1)
                return rnd.Next(7);
            else if (niveau == 2)
                return rnd.Next(3) + rnd.Next(4);
            // Ajouter des vraies IA 
            return -1;
        }


        // 0 = pion non jouer, 1 = jouer, 2 = gagné, 3 = plein
        public int jouer(int colonne)
        {
            if (colonne >= VY || colonne < 0)
                return 0;
            else if (damier[0, colonne] != 0)
                return 0;
            else
            {
                int i = VX -1;
                while (damier[i, colonne] != 0)
                    i--;
                if (joueur)
                    damier[i, colonne] = 1;
                else
                    damier[i, colonne] = 2;

                if (testvictoire(i, colonne))
                    return 2;
                if (testfin())
                    return 3;

                joueur = !joueur;
                return 1;
            }
        }

        public bool testvictoire(int ligne, int colonne)
        {
            return testligne(ligne, colonne) || testcolonne(ligne, colonne) || testdiag(ligne, colonne);
        }

        public bool testligne(int ligne, int colonne)
        {
            int couleur = damier[ligne, colonne];
            int cpt = 0;
            colonne = 0;
            while (cpt < 4 && colonne < VY)
            {
                if (damier[ligne, colonne] == couleur)
                    cpt++;
                else
                    cpt = 0;
                colonne++;
            }

            if (cpt == 4)
                return true;
            else
                return false;
        }

        public bool testcolonne(int ligne, int colonne)
        {
            int couleur = damier[ligne, colonne];
            int cpt = 0;
            ligne = 0;
            while (cpt < 4 && ligne < VX)
            {
                if (damier[ligne, colonne] == couleur)
                    cpt++;
                else
                    cpt = 0;
                ligne++;
            }
            if (cpt == 4)
                return true;
            else
                return false;
        }

        public bool testdiag(int ligne, int colonne)
        {
            int couleur = damier[ligne, colonne];
            int cpt = 0;
            int x = ligne;
            int y = colonne;
            while (x < VX - 1 && y > 0)
            {
                x++;
                y--;
            }

            while (x >= 0 && y < VY && cpt < 4)
            {
                if (damier[x, y] == couleur)
                    cpt++;
                else
                    cpt = 0;
                x--;
                y++;
            }
            if (cpt == 4)
                return true;

            cpt = 0;
            x = ligne;
            y = colonne;
            while (x < VX - 1 && y < VY - 1)
            {
                x++;
                y++;
            }

            while (x >= 0 && y >= 0 && cpt < 4)
            {
                if (damier[x, y] == couleur)
                    cpt++;
                else
                    cpt = 0;
                x--;
                y--;
            }
            if (cpt == 4)
                return true;

            return false;

        }

        public bool testfin()
        {
            bool plein = true;
            for(int i=0;i<VY;i++)
                if (damier[0,i] ==0)
                    plein = false;

            return plein;
        }
    }
}
