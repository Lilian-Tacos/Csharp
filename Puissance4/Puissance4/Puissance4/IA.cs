using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puissance4
{
    class IA
    {
        Random rnd;
        int niveau;

        public IA()
        {
            rnd = new Random();
            this.niveau = 1;
        }

        public int Niveau
        {
            get { return niveau; }
            set { niveau = value; }
        }

        public int faireChoix(int[,] damier)
        {
            // Niveau max d'IA
            if (niveau > 2)
                niveau = 2;

            // Choix de l'IA
            switch (niveau)
            {
                case 1: return IA1();
                case 2: return IA2(damier);
                default: return -1;
            }
        }

        public int IA1()
        {           
            return rnd.Next(3) + rnd.Next(4);
        }

        public int IA2(int[,] damier)
        {
            int n = -1;

            if ((n = trouveColonne(damier, false)) != -1) // cherche a gagner
                return n;
            else if ((n = trouveColonne(damier, true)) != -1) // cherche a defendre
                return n;
            else
                return rnd.Next(3) + rnd.Next(4); // sinon joue aléatoirement
        }

        public int trouveColonne(int[,] damier, bool joueur)
        {
            int VX = 6;
            int VY = 7;
            int[,] damierTest =  new int[VX, VY];
            faireCopie(damier, damierTest);

            for (int colonne = 0; colonne < 7; colonne++)
            {
                if(jouer(colonne, damierTest, joueur) == 2){
                    return colonne;
                }
                faireCopie(damier, damierTest);
            }
            return -1;
        }

        public void faireCopie(int[,] damier, int[,] damierTest)
        {
            int VX = 6;
            int VY = 7;
            for (int i=0; i < VX; i++)
            {
                for(int j=0; j< VY ; j++)
                {
                    damierTest[i, j] = damier[i, j];
                }

            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        // test victoire

        public int jouer(int colonne, int[,] damier, bool joueur)
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
                if(joueur)
                    damier[i, colonne] = 1;
                else
                    damier[i, colonne] = 2;

                    if (testvictoire(i, colonne, damier))
                    return 2;

                return 1;
            }
        }

        public bool testvictoire(int ligne, int colonne, int[,] damier)
        {
            return testligne(ligne, colonne, damier) || testcolonne(ligne, colonne, damier) || testdiag(ligne, colonne, damier);
        }

        public bool testligne(int ligne, int colonne, int[,] damier)
        {
            int VY = 7;

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

        public bool testcolonne(int ligne, int colonne, int[,] damier)
        {
            int VX = 6;

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

        public bool testdiag(int ligne, int colonne, int[,] damier)
        {
            int VX = 6;
            int VY = 7;

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
    }
}
