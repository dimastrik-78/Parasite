namespace LevelSystem.PlaceStrategy
{
    public class ChoseAction
    {
        private readonly Hospital _hospital;
        
        public ChoseAction()
        {
            _hospital = new Hospital();
        }
        
        public void Action(Places places)
        {
            switch (places)
            {
                case Places.Hospital:
                {
                    _hospital.Action();
                    break;
                }
            }
        }
    }
}