using Utils;
using Utils.Event;

namespace LevelSystem.PlaceStrategy
{
    public class Hospital : IPlaceStrategy
    {
        public void Action()
        {
            Signals.Get<LoseGameSignal>().Dispatch();
        }
    }
}