using Newtonsoft.Json;

namespace ExCollection.App
{
    public class Schueler
    {
        // TODO: Erstelle ein Proeprty KlasseNavigation vom Typ Klasse, welches auf
        //       die Klasse des Schülers zeigt.
        // Füge dann über das Proeprty die Zeile
        // [JsonIgnore]
        // ein, damit der JSON Serializer das Objekt ausgeben kann.
        [JsonIgnore]
        public Klasse KlasseNavigation { get; set; } = default!;
        public int Id { get; set; }
        public string Zuname { get; set; }
        public string Vorname { get; set; }
        /// <summary>
        /// Ändert die Klassenzugehörigkeit, indem der Schüler
        /// aus der alten Klasse, die in KlasseNavigation gespeichert ist, entfernt wird.
        /// Danach wird der Schüler in die neue Klasse mit der korrekten Navigation eingefügt.
        /// </summary>
        /// <param name="k"></param>
        public void ChangeKlasse(Klasse k)
        {
            if (k is not null)
            {
                KlasseNavigation.RemoveSchueler(this);
                KlasseNavigation = k;

                k.AddSchueler(this);
            }
            else
            {
                throw new ArgumentException("Klasse war NULL!");
            }
        }
    }
}