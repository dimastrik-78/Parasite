using System.Collections.Generic;
using UnityEngine;

namespace NPCSystem.HumanStateMachine
{
    public class StateMachine
    {
        private AHumanState _currentPlayerState;
        
        private readonly Dictionary<HumanState, AHumanState> _states;
        
        private int _stateID;

        public StateMachine(Human human, GameObject humanObject)
        {
            _states = new Dictionary<HumanState, AHumanState>
            {
                { HumanState.Normal, new Normal(this, human, humanObject) },
                { HumanState.Infected, new Infected(this, humanObject) }
            };
            
            ChangeState(HumanState.Normal);
        }

        public HumanState State()
        {
            return _currentPlayerState.State();
        }

        public void Request()
        {
            _currentPlayerState.Exit();
        }
        
        public void ChangeState(HumanState state)
        {
            _currentPlayerState = _states[state];
        }
    }
}