using UnityEngine;
using Utils;
using Utils.Event;

namespace NPCSystem.HumanStateMachine
{
    public class Infected : AHumanState
    {
        private readonly GameObject _human;
        
        public Infected(StateMachine owner, GameObject human) : base(owner)
        {
            _human = human;
        }
        
        public override HumanState State()
        {
            return HumanState.Infected;
        }

        public override void Exit()
        {
            Signals.Get<HumanDieSignal>().Dispatch();
            _human.SetActive(false);
        }
    }
}