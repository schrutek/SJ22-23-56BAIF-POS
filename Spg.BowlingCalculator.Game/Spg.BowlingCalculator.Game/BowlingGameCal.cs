using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.BowlingCalculator.Game
{
    /// <summary>Tolle Bowling-Klasse</summary>
    /// <remarks>
    /// 1. Summiere thrownPins auf und gib Ergebis zurück.
    /// </remarks>
    public class BowlingGameCal
    {
        private int _sum;

        /// <summary>Rechnet die Summe eines Bowlingspiels aus.</summary>
        /// <remarks>
        /// Detailierte Beschreibung dieser Methode...
        /// </remarks>
        /// <see cref="Game.BowlingState"/>
        /// <param name="thrownPins">Die Anzahl der, von der Kugel umgestoßenen Kegel</param>
        /// <returns>Gibt die errechnete Gesamtsumme zurück</returns>
        /// <exception cref="NotImplementedException">Wird geworfen wenn die Implementierung vergessen wurde.</exception>
        public int Roll(int thrownPins)
        {
            // Auf Anzahl der Kegel checken
            if (thrownPins > 10 || thrownPins < 0)
            {
                throw new BowlingGameException("Es müssen zwischen 0 und 10  Kegel sein! (Schlingel)");
            }

            // Strike
            // Spare
            // Das perfekte Spiel (300), hier gibt es 12 würfe.
            // Frame, besteht aus 2 Würfen.

            _sum = _sum + thrownPins;
            return _sum;
        }
    }
}
