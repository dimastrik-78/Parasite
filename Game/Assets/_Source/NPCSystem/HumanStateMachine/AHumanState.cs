namespace NPCSystem.HumanStateMachine
{
    public abstract class AHumanState
    {
        protected StateMachine Owner;
        protected AHumanState(StateMachine owner)
        {
            Owner = owner;
        }

        public virtual HumanState State() => default;

        public virtual void Enter() { }
        
        public virtual void Exit() { }
    }
}