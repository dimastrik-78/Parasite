using UnityEngine;

namespace NPCSystem.HumanStateMachine
{
    public class Infected : AHumanState
    {
        private GameObject _human;
        
        public Infected(StateMachine owner, GameObject human) : base(owner)
        {
            _human = human;
        }
        
        public override HumanState State()
        {
            return HumanState.Infected;
        }

        public override void Request()
        {
            _human.SetActive(false);
        }
    }
}