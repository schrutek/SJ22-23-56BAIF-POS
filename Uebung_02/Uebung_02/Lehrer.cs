namespace ExProperties.App
{
    internal class Lehrer
    {
        public string Vorname { get; set; }

        public string Zuname { get; set; } = string.Empty;

        public decimal? Bruttogehalt
        {
            get { return _bruttogehalt; }
            set
            {
                if (_bruttogehalt is not null)
                {
                    _bruttogehalt = value;
                }
                else
                { }
            }
        }
        private decimal? _bruttogehalt;

        public string Kuerzel
        {
            get 
            {
                if (Zuname?.Length < 3)
                {
                    return Zuname?.ToUpper() ?? string.Empty;
                }
                return Zuname?[..3]?.ToUpper() ?? string.Empty;
            }
        }

        public decimal Nettogehalt => (_bruttogehalt ?? 0) * 0.8M;
    }
}