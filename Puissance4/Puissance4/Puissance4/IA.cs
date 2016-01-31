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
    class IA
    {
        Random rnd;
        int niveau;
        Plateau damier;

        public IA(Plateau damier)
        {
            rnd = new Random();
            this.niveau = 1;
            this.damier = damier;
        }

        public int Niveau
        {
            get { return niveau; }
            set { niveau = value; }
        }

        public int faireChoix()
        {
            // Niveau max d'IA
            if (niveau > 2)
                niveau = 2;

            // Choix de l'IA
            switch (niveau)
            {
                case 1: return IA1();
                case 2: return IA2();
                default: return -1;
            }
        }

        public int IA1()
        {           
            return rnd.Next(3) + rnd.Next(4);
        }

        public int IA2()
        {
            int n = -1;

            if ((n = trouveColonne(false)) != -1) // cherche a gagner
                return n;
            else if ((n = trouveColonne(true)) != -1) // cherche a defendre
                return n;
            else
                return rnd.Next(3) + rnd.Next(4); // sinon joue aléatoirement
        }

        public int trouveColonne(bool joueur)
        {
            Plateau damierTest = new Plateau();
            damier.faireCopie(damierTest); // copie damier dans damierTest

            for (int colonne = 0; colonne < damierTest.getVX(); colonne++)
            {
                if(damierTest.jouer(colonne, joueur) == 2){
                    return colonne;
                }
                damier.faireCopie(damierTest);
            }
            return -1;
        }
        
    }
} 
