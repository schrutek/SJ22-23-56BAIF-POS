namespace ExProperties.App
{
    internal class Rechteck
    {
        private int _laenge;
        private int _breite;

        public int Laenge
        {
            get { return _laenge; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Ungültige Länge");
                }
                else
                {
                    _laenge = value;
                }
            }
        }

        public int Breite
        {
            get { return _breite; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Ungültige Breite");
                }
                else
                {
                    _breite = value;
                }
            }
        }

        public int Flaeche => Laenge * Breite;
    }
}