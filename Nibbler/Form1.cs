using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nibbler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Griglia S;

        int Rb = 0, Cb = 0, Rts = 5, Cts = 5, Rm, Cm;
        bool CambiaDirezione = true;
        Serpente Vipera;


        private void btnGioca_Click(object sender, EventArgs e)
        {
            S = new Griglia();
            Vipera = new Serpente();
            S.Visualizza(this);
            Vipera.InsCoda(5, 5);
            S.Serp(5, 5);
            S.Mela(out Rm, out Cm);
            Vipera.SetDirezione(4);
            timer1.Enabled = true;
            timer2.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            S.TogliBomba(Rb, Cb);
            S.Bomba(out Rb, out Cb);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //Cambio la posizione delle coordinate
            // della testa del serpente in base
            // alla direzione del serpente
            switch (Vipera.GetDirezione())
            {
                case 8:
                    Rts--;
                    break;
                case 2: 
                    Rts++;
                    break;
                case 4: 
                    Cts--;
                    break;
                case 6: 
                    Cts++;
                    break;
            }
            // se non supero il bordo
            if (Rts >= 0 && Cts >= 0 && Rts <= 9 && Cts <= 9)
            {
                //Cerco il tipo di oggetto che si trova
                // nella nuova posizione della testa
                int O = S.CercaOggetto(Rts, Cts);
                // Inserisco la Nuova posizione della testa nella coda
                Vipera.InsCoda(Rts, Cts);
                //Accendo sullo schermo la nuova testa
                S.Serp(Rts, Cts);
                // Controllo se l'oggetto è una bomba oppure è
                // un pezzo del serpente in questi casi il gioco termina
                if (O == 1 || O == 3)
                    this.Close();
                // Se è una posizione vuota
                if (O != 2)
                {
                    int Rcs, Ccs;
                    //Trova la posizione della fine del serpente
                    Vipera.GetCodaS(out Rcs, out Ccs);
                    //Cancella l'ultimo pezzo dallo schermo
                    S.TogliBomba(Rcs, Ccs);
                    //Tolgo dalla coda l'ultimo pezzo del serpente
                    Vipera.CancCoda();
                }
                else
                {
                    // se volessi aumentare la velocità 
                    // quando il serpente mangia la mela
                    //timer2->Interval=timer2->Interval-5;

                    //Se ho mangiato la mela ne creo un'altra            
                    S.Mela(out Rm, out Cm);
                }
            }
            else
            {
                // Controllo se sono uscito dallo schermo
                // riporto la testa del serpente nella posizione
                //precedente
                if (Cts < 0)
                    Cts++;
                else
                    if (Cts > 9)
                        Cts--;
                    else
                        if (Rts < 0)
                            Rts++;
                        else
                            if (Rts > 9)
                                Rts--;


            }

            CambiaDirezione = true;	 
		     	 

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int Dir = e.KeyChar - 48;
            //Non permetto di andare nella direzione opposta
            if (CambiaDirezione)
            {
                if ((Dir == 8 && Vipera.GetDirezione() != 2) ||
                    (Dir == 2 && Vipera.GetDirezione() != 8) ||
                    (Dir == 4 && Vipera.GetDirezione() != 6) ||
                    (Dir == 6 && Vipera.GetDirezione() != 4))
                    Vipera.SetDirezione(Dir);
                CambiaDirezione = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
