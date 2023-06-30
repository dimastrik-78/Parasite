using System.Collections.Generic;
using UnityEngine;

namespace NPCSystem.HumanStateMachine
{
    public class StateMachine
    {
        protected internal AHumanState CurrentPlayerState;
        
        private readonly Dictionary<HumanState, AHumanState> _states;
        
        private int _stateID;

        public StateMachine(GameObject human)
        {
            _states = new Dictionary<HumanState, AHumanState>
            {
                { HumanState.Normal, new Normal(this, human) },
                { HumanState.Infected, new Infected(this, human) }
            };
            
            ChangeState(HumanState.Normal);
        }

        public HumanState State()
        {
            return CurrentPlayerState.State();
        }

        public void Request()
        {
            CurrentPlayerState.Request();
        }
        
        public void ChangeState(HumanState state)
        {
            CurrentPlayerState = _states[state];
        }
    }
}