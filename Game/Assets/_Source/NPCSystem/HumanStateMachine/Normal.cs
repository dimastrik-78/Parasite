using UnityEngine;

namespace NPCSystem.HumanStateMachine
{
    public class Normal : AHumanState
    {
        private readonly StateMachine _owner;
        private readonly Human _human;
        private readonly GameObject _humanObjectObject;
        
        public Normal(StateMachine owner, Human human, GameObject humanObject) : base(owner)
        {
            _owner = owner;
            _human = human;
            _humanObjectObject = humanObject;
        }

        public override HumanState State()
        {
            return HumanState.Normal;
        }

        public override void Exit()
        {
            _owner.ChangeState(HumanState.Infected);
            _human.WhereGoing();
            _humanObjectObject.layer = 7;
        }
    }
}