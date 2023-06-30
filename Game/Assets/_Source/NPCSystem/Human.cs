using System.Collections.Generic;
using _Source.NPCSystem;
using LevelSystem;
using NPCSystem.HumanStateMachine;
using UnityEngine;
using Utils;
using Utils.Event;
using Random = System.Random;

namespace NPCSystem
{
    public class Human : MonoBehaviour
    {
        [SerializeField] private MovementPoints[] mainPoint;

        private Movement _movement;
        private StateMachine _stateMachine;
        private Random _random;
        private MovementPoints _startPosition;
        private MovementPoints _target;
        private List<Transform> _targetPosition = new();
        private int _pointPassed;
        
        void Awake()
        {
            Init();
        }

        private void Update()
        {
            _movement.Move(transform, _targetPosition, ref _pointPassed);

            if (transform.position == _target.transform.position)
            {
                Signals.Get<HumanCameIntoPlaceSignal>().Dispatch(this);
                ChooseNewPoints();
            }
        }

        private void Init()
        {
            _movement = new Movement();
            _stateMachine = new StateMachine(gameObject);
            _random = new Random();

            _startPosition = mainPoint[_random.Next(0, mainPoint.Length)];
            transform.position = _startPosition.transform.position;
            ChooseNewPoints();
        }

        private void ChooseNewPoints()
        {
            _pointPassed = 0;
            var oldTarget = _target ? _target : _startPosition;
            _target = ChoseNewTarget(oldTarget);
            _targetPosition = _movement.FindPath(oldTarget, _target);
        }

        private MovementPoints ChoseNewTarget(MovementPoints position)
        {
            var point = mainPoint[_random.Next(0, mainPoint.Length)];
            while (point == position)
            {
                point = mainPoint[_random.Next(0, mainPoint.Length)];
            }

            return point;
        }

        public void ChangeState()
        {
            _stateMachine.Request();
        }

        public HumanState GetState()
        {
            return _stateMachine.State();
        }
    }
}
