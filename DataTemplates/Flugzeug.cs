using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTemplates
{
    public class Flugzeug
    {
        public enum FlugzeugTyp { Passagier, Fracht, Agrar, Lösch, Militär }

        private string _typenName;
        public string TypenName
        {
            get { return _typenName; }
            set { _typenName = value; }
        }

        private double _spannweite;
        /// <summary>
        /// Spannweite in Metern
        /// </summary>
        public double Spannweite
        {
            get { return _spannweite; }
            set { _spannweite = value; }
        }

        private FlugzeugTyp _typ;
        public FlugzeugTyp Typ
        {
            get { return _typ; }
            set { _typ = value; }
        }

        private string _fotoUrl;
        public string FotoUrl
        {
            get { return _fotoUrl; }
            set { _fotoUrl = value; }
        }

        public Flugzeug(string typenName, double spannweite, FlugzeugTyp typ, string fotoUrl)
        {
            TypenName = typenName;
            Spannweite = spannweite;
            Typ = typ;
            FotoUrl = fotoUrl;
        }

        public Flugzeug()
        {

        }

    }
}
