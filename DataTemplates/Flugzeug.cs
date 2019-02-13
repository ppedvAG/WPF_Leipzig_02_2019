using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTemplates
{
    public class Flugzeug : INotifyPropertyChanged
    {
        public enum FlugzeugTyp { Passagier, Fracht, Agrar, Lösch, Militär }

        private string _typenName;
        public string TypenName
        {
            get { return _typenName; }
            set { _typenName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TypenName)));
            }
        }

        private double _spannweite;
        /// <summary>
        /// Spannweite in Metern
        /// </summary>
        public double Spannweite
        {
            get { return _spannweite; }
            set { _spannweite = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Spannweite)));
            }
        }

        private FlugzeugTyp _typ;
        public FlugzeugTyp Typ
        {
            get { return _typ; }
            set { _typ = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Typ)));
            }
        }

        private string _fotoUrl;

        public event PropertyChangedEventHandler PropertyChanged;

        public string FotoUrl
        {
            get { return _fotoUrl; }
            set { _fotoUrl = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FotoUrl)));
            }
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
