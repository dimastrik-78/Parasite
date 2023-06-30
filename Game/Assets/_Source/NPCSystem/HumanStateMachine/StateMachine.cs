using System.Collections.Generic;
using UnityEngine;

namespace NPCSystem.HumanStateMachine
{
    public class StateMachine
    {
        private AHumanState _currentPlayerState;
        
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
            return _currentPlayerState.State();
        }

        public void Request()
        {
            _currentPlayerState.Request();
        }
        
        public void ChangeState(HumanState state)
        {
            _currentPlayerState = _states[state];
        }
    }
}