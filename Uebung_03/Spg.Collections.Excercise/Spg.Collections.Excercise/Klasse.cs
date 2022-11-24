namespace ExCollection.App
{
    public class Klasse
    {
        // TODO: Erstelle ein Property Schuelers, welches alle Schüler der Klasse in einer
        //       Liste speichert.
        private List<Schueler> _schuelerList = new();
        public IReadOnlyList<Schueler> Schuelers { get { return _schuelerList; } }

        public string Name { get; set; } = string.Empty;
        public string KV { get; set; } = string.Empty;
        /// <summary>
        /// Fügt den Schüler zur Liste hinzu und setzt das Property KlasseNavigation
        /// des Schülers korrekt auf die aktuelle Instanz.
        /// </summary>
        /// <param name="s"></param>
        public void AddSchueler(Schueler s)
        {
            if (s is not null)
            {
                foreach (Schueler schueler in Schuelers)
                {
                    if (schueler.Id == s.Id)
                    {
                        throw new ArgumentException("Schüler bereits vorhanden!");
                    }
                }

                if (Schuelers.Any(schueler => schueler.Id == s.Id))
                {
                    throw new ArgumentException("Schüler bereits vorhanden!");
                }

                s.KlasseNavigation = this;
                _schuelerList.Add(s);
            }
            else
            {
                throw new ArgumentNullException("Schüler war NULL!");
            }
        }

        public void RemoveSchueler(Schueler s)
        {
            _schuelerList.Remove(s);
        }
    }
}