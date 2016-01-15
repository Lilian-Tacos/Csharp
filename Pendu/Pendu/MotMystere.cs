using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pendu
{
    class MotMystere
    {
        String mot;
        String motflou;
        int fautes;
        bool encours;

        public MotMystere()
        {
            this.mot = "";
            this.motflou = "";
            this.fautes = 0;
            encours = true;
        }

        public void init()
        {
            string text = System.IO.File.ReadAllText(@"..\..\Dictionnaire.txt");
            string[] choix = text.Split(' ', '\n');
            Random rnd = new Random();
            this.mot = choix[rnd.Next(choix.Length)].ToUpper();
            this.motflou = "";
            for (int i = 0; i < mot.Length; i++)
            {
                if (mot[i] >= 'A' && mot[i] <= 'Z')
                {
                    this.motflou += "~";
                }
                else
                {
                    this.motflou += mot[i];
                }
            }
            this.fautes = 0;
            encours = true;
        }

        public String getmotflou()
        {
            return this.motflou;
        }

        public String getmot()
        {
            return this.mot;
        }

        public int getfautes()
        {
            return this.fautes;
        }

        public bool getetat()
        {
            return this.encours;
        }

        public void revelelettre(char l)
        {
            if (encours)
            {
                l = majuscule(l);
                bool b = true;
                if (l != '0')
                {
                    String newmot = "";
                    for (int i = 0; i < mot.Length; i++)
                    {
                        if (this.mot[i] == l)
                        {
                            newmot += mot[i];
                            b = false;
                        }
                        else
                        {
                            newmot += motflou[i];
                        }
                    }
                    motflou = newmot;
                    if (b)
                    {
                        perdvie();
                    }

                    if (mot.CompareTo(motflou) == 0)
                    {
                        encours = false;
                    }
                }
            }
        }

        public char majuscule(char c)
        {
            if (c >= 'A' && c <= 'Z')
            {
                return c;
            }
            else if (c >= 'a' && c <= 'z')
            {
                return c.ToString().ToUpper()[0];
            }
            else
            {
                return '0';
            }
        }

        public void revelemot(String s)
        {
            if (encours)
            {
                s = s.ToUpper();
                if (mot.CompareTo(s) == 0)
                {
                    motflou = mot;
                    encours = false;
                }
                else
                {
                    perdvie();
                }
            }
        }

        public bool gagner()
        {
            if (mot.CompareTo(motflou) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void perdvie()
        {
            fautes++;
            if (fautes >= 10)
            {
                encours = false;
            }
        }
    }
}
