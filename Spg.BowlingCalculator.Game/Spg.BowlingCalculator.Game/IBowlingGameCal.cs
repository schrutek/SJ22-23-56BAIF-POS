namespace Spg.BowlingCalculator.Game
{
    public interface IBowlingGameCal
    {
        int CurrentFrame { get; }
        int Roll(int thrownPins);
    }
}