using UnityEngine;

namespace NPCSystem.HumanStateMachine
{
    public class Normal : AHumanState
    {
        private readonly StateMachine _owner;
        private GameObject _human;
        
        public Normal(StateMachine owner, GameObject human) : base(owner)
        {
            _owner = owner;
            _human = human;
        }

        public override HumanState State()
        {
            return HumanState.Normal;
        }

        public override void Request()
        {
            _owner.ChangeState(HumanState.Infected);
            _human.layer = 7;
        }
    }
}