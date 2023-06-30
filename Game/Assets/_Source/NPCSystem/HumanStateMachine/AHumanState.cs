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

        public virtual void Check() { }
        
        public virtual void Request() { }
    }
}