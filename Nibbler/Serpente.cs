using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nibbler
{
    class Serpente
    {
        Nodo Ultimo;
        Nodo Primo;
        int D;

        //Costruttore di default
        public Serpente()
        {
            Primo = Ultimo = null;
        }
        //---------------------------------------------------------------------------

        //Inserisce un elemento 
        //(LA NUOVA TESTA DEL SERPENTE) 
        public void InsCoda(int R, int C)
        {
            Nodo P;
            P = new Nodo();
            P.Riga = R;
            P.Col = C;
            if (Ultimo != null)
                Ultimo.Punt = P;
            Ultimo = P;
            if (Primo == null)
                Primo = P;
        }

        //---------------------------------------------------------------------------

        //Cancella un elemento dalla coda
        public void CancCoda()
        {
            if (Primo != null)
            {
                Nodo P = Primo;
                Primo = Primo.Punt;
            }
            if (Primo == null)
                Ultimo = null;
        }
        //---------------------------------------------------------------------------
        public void GetTestaS(out int R, out int C)
        {
            R = Ultimo.Riga;
            C = Ultimo.Col;
        }
        public void GetCodaS(out int R, out int C)
        {
            R = Primo.Riga;
            C = Primo.Col;
        }
        public void SetDirezione(int Dir)
        {
            D = Dir;
        }
        public int GetDirezione()
        {
            return D;
        }
        public bool Ricerca(int R, int C)
        {
            bool Trovato = false;
            Nodo P = Primo;
            while (!Trovato && P != Ultimo)
            {
                if (R == P.Riga && C == P.Col)
                    Trovato = true;
                P = P.Punt;
            }
            if (R == P.Riga && C == P.Col)
                Trovato = true;
            return Trovato;
        }


    }
}
