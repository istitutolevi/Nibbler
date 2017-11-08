using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nibbler
{
    class Griglia
    {
        Label[] Sfondo;

        public Griglia()
        {
            Sfondo = new Label[100];
            for (int I = 0; I < 100; I++)
            {
                Sfondo[I] = new Label();

                /*Per capire la differenza di sintassi
                  nel caso io abbia un oggetto di tipo Label
                  oppure un Puntatore ad un oggetto di tipo Label

                  System.Windows.Forms.Label X;
                  X.Text="Ciao";
     
                  System.Windows.Forms.Label^ Y;
                  Y=gcnew System.Windows.Forms.Label(); 
       
	   
                  Y.Text="Ciao";
                */

                int Riga = I / 10;
                int Colonna = I % 10;

                Sfondo[I].AutoSize = false;
                Sfondo[I].BackColor = System.Drawing.Color.Lime;
                Sfondo[I].Location = new System.Drawing.Point(30 * Colonna, 60 + 30 * Riga);
                Sfondo[I].Name = "Label" + I.ToString();
                Sfondo[I].Size = new System.Drawing.Size(30, 30);
                Sfondo[I].TabIndex = 0;
                Sfondo[I].Text = " ";
            }
        }

        public void Visualizza(Form F)
        {
            for (int I = 0; I < 100; I++)
                F.Controls.Add(Sfondo[I]);
        }

        Random random = new Random();

        //Metodo che genera la Bomba nello schermo
        public void Bomba(out int R,out int C)
        {
            int I;
            do
            {
                R = random.Next(10);
                C = random.Next(10);
                I = R * 10 + C;
            } while (Sfondo[I].BackColor != System.Drawing.Color.Lime);

            Sfondo[I].BackColor = System.Drawing.Color.Red;
        }

        //Metodo Che toglie un oggetto dallo schermo
        public void TogliBomba(int R, int C)
        {
            int I;
            I = R * 10 + C;
            Sfondo[I].BackColor = System.Drawing.Color.Lime;
        }
        public void Spegni(Form F)
        {

            for (int I = 0; I < 100; I++)
                F.Controls.Remove(Sfondo[I]);
        }

        public int CercaOggetto(int R, int C)
        {
            int I;
            I = R * 10 + C;
            int Risp = 0;





            if (Sfondo[I].BackColor == System.Drawing.Color.Lime)
                Risp = 0;
            if (Sfondo[I].BackColor == System.Drawing.Color.Red)
                Risp = 1;
            if (Sfondo[I].BackColor == System.Drawing.Color.Yellow)
                Risp = 2;
            if (Sfondo[I].BackColor == System.Drawing.Color.Blue)
                Risp = 3;

            return Risp;
        }
        public void MuoviSerpente(int C1, int R1, int C2, int R2)
        {
            if (R1 >= 0 && R1 < 10 && C1 >= 0 && C1 < 10 &&
               R2 >= 0 && R2 < 10 && C2 >= 0 && C2 < 10)
            {
                int I;
                I = R1 * 10 + C1;
                Sfondo[I].BackColor = System.Drawing.Color.Red;
                I = R2 * 10 + C2;
                Sfondo[I].BackColor = System.Drawing.Color.Lime;

                //TlabG[R2][C2].Color=clWhite;
                //TlabG[R1][C1].Color=clGreen;
            }
        }
        public void Serp(int R, int C)
        {
            int I = R * 10 + C;
            Sfondo[I].BackColor = System.Drawing.Color.Blue;
        }
        public void Mela(out int R,out int C)
        {
            int I;
            do
            {
                R = random.Next(10);
                C = random.Next(10);
                I = R * 10 + C;
            } while (Sfondo[I].BackColor != System.Drawing.Color.Lime);

            Sfondo[I].BackColor = System.Drawing.Color.Yellow;

        }



    }
}
