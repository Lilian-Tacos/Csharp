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
        ObjetPuissance4 jetonjaune;

        Plateau damier;
        int positionjaune;
        bool touche_up;
        int etat;
        IA ordi;


        public Puissance4()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            damier = new Plateau();
            positionjaune = 3;
            touche_up = true;
            etat = 0;

            ordi = new IA(damier);
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
            spriteBatch = new SpriteBatch(GraphicsDevice);

            graphics.PreferredBackBufferWidth = 7 * 57 - 1;
            graphics.PreferredBackBufferHeight = 6 * 57 - 1 + 80;
            graphics.ApplyChanges();

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
                    damier.nouvellePartie();
                    positionjaune = 3;
                    touche_up = true;
                    etat = 0;
                    ordi.Niveau++;
                }
            }

            else if (damier.Joueur)
            {
                if (keyboard.IsKeyDown(Keys.Right) && positionjaune < damier.getVX() && touche_up)
                {
                    positionjaune++;
                    touche_up = false;
                }
                else if (keyboard.IsKeyDown(Keys.Left) && positionjaune >0 && touche_up)
                {
                    positionjaune--;
                    touche_up = false;
                }
                else if (keyboard.IsKeyUp(Keys.Left) && keyboard.IsKeyUp(Keys.Right) && keyboard.IsKeyUp(Keys.Down) && !touche_up)
                    touche_up = true;

                else if (keyboard.IsKeyDown(Keys.Down) && touche_up)
                {
                    etat = damier.jouer(positionjaune);
                    touche_up = false;
                }
            }
            else
            {
                etat = damier.jouer(ordi.faireChoix());
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
            Vector2 text =new Vector2(30, 0);

            for (int x = 0; x < damier.getVX(); x++)
            {
                for (int y = 0; y < damier.getVY(); y++)
                {
                    int xpos, ypos;
                    xpos = offsetX + x * 57;
                    ypos = offsetY + y * 57;
                    Vector2 pos = new Vector2(ypos, xpos);
                    if (damier.getCase(x, y) == 0)
                        spriteBatch.Draw(cadre.Texture, pos, Color.White);
                    else if (damier.getCase(x, y) == 2)
                        spriteBatch.Draw(pionrouge.Texture, pos, Color.White);
                    else if (damier.getCase(x, y) == 1)
                        spriteBatch.Draw(pionjaune.Texture, pos, Color.White);
                }
            }
            if (damier.Joueur)
            {
                Vector2 pos = new Vector2(offsetY + positionjaune * 57, 20);
                spriteBatch.Draw(jetonjaune.Texture, pos, Color.White);
            }
            if (etat == 2)
            {
                if (damier.Joueur)
                {
                    spriteBatch.DrawString(_font, "Vous avez gagne, faites entree", text, Color.White);
                   // spriteBatch.DrawString(_font, "Appuyer sur entré pour continuer.", text, Color.White);
                }
                else
                {
                    spriteBatch.DrawString(_font, "Vous avez perdu, faites entree", text, Color.White);
                   // spriteBatch.DrawString(_font, "Appuyer sur entré pour recommencer.", text, Color.White);
                }
            }
            else if (etat == 3)
                spriteBatch.DrawString(_font, "Match nul, faites entree", text, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }      
        
    }
}
