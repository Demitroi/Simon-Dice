using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simon_Dice
{
    class simon
    {
        List<string> Secuencia = new List<string>();
        Random Num = new Random();
        int Posicion = 0;
        int PosComprobar = 0;

        public void NuevoNumero()
        {
            Secuencia.Add(Num.Next(1, 5).ToString());
            Posicion = 0;
        }

        public string ComprobarNumero(string Dato)
        {
            if (Dato == Secuencia[PosComprobar])
            {
                if (Secuencia.Count == (PosComprobar+1))
                {
                    PosComprobar = 0;
                    return "2";
                }
                else
                {
                    PosComprobar++;
                    return "1";
                }
            }
            else
            {
                PosComprobar = 0;
                return "0";
            }
        }

        public void Error()
        {
            Secuencia.Clear();
            Posicion = 0;
        }

        public string Recorrer()
        {
            if (Secuencia.Count > Posicion)
            {
                string Resultado = Secuencia[Posicion];
                Posicion++;
                return Resultado;
            }
            else
            {
                return "0";
            }
            
        }

        public void Numeros()
        {
            Secuencia.Add("1");
            Secuencia.Add("2");
            Secuencia.Add("3");
            Secuencia.Add("4");
        }

        public int Aciertos()
        {
            return Secuencia.Count;
        }
    }
}
