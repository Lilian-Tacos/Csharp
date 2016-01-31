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
    class Plateau
    {
        int[,] damier;
        const int VX=6;
        const int VY=7;        
        bool joueur;

        public Plateau(){
            joueur = true;
            damier = new int[VX, VY]{
                {0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0}
            };
        }

        public void nouvellePartie()
        {
            joueur = true;
            damier = new int[VX, VY]{
                {0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0}
            };
        }

        public int getVX()
        {
            return VX;
        }

        public bool Joueur
        {
            get { return joueur; }
            set { joueur = value; }
        }

        public int getVY()
        {
            return VY;
        }

        public int getCase(int x, int y)
        {
            return damier[x, y];
        }

        public void setCase(int x, int y, int value)
        {
            damier[x, y]= value;
        }

        public void faireCopie(Plateau damierTest)
        {
            for (int i = 0; i < VX; i++)
            {
                for (int j = 0; j < VY; j++)
                {
                    damierTest.setCase(i, j, this.getCase(i, j));
                }

            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// test Victoire

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
            for (int i = 0; i < VY; i++)
                if (getCase(0, i) == 0)
                    plein = false;

            return plein;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Jouer

        // 0 = pion non jouer, 1 = jouer, 2 = gagné, 3 = plein
        public int jouer(int colonne)
        {
            if (colonne >= VY || colonne < 0)
                return 0;
            else if (getCase(0, colonne) != 0)
                return 0;
            else
            {
                int i = VX - 1;
                while (getCase(i, colonne) != 0)
                    i--;
                if (joueur)
                    setCase(i, colonne, 1);
                else
                   setCase(i, colonne, 2);

                if (testvictoire(i, colonne))
                    return 2;
                if (testfin())
                    return 3;

                joueur = !joueur;
                return 1;
            }
        }

        public int jouer(int colonne, bool player)
        {
            int VX = 6;
            int VY = 7;

            if (colonne >= VY || colonne < 0)
                return 0;
            else if (damier[0, colonne] != 0)
                return 0;
            else
            {
                int i = VX - 1;
                while (damier[i, colonne] != 0)
                    i--;
                if (player)
                    damier[i, colonne] = 1;
                else
                    damier[i, colonne] = 2;

                if (testvictoire(i, colonne))
                    return 2;

                return 1;
            }
        }
    }
}
