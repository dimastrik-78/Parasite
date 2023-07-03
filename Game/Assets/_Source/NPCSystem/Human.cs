using System.Collections.Generic;
using LevelSystem;
using NPCSystem.HumanStateMachine;
using TMPro;
using UnityEngine;
using Utils;
using Utils.Event;
using Random = System.Random;

namespace NPCSystem
{
    public class Human : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private MovementPoints[] mainPoint;
        [SerializeField] private TMP_Text text;
        
        private readonly List<Place> _places = new();

        private Movement _movement;
        private StateMachine _stateMachine;
        private Random _random;
        private MovementPoints _startPosition;
        private MovementPoints _target;
        private List<Transform> _targetPosition = new();
        private int _pointPassed;
        private int _randomNumber;
        
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
                WhereGoing();
            }
        }

        private void Init()
        {
            _movement = new Movement(speed);
            _stateMachine = new StateMachine(this, gameObject);
            _random = new Random();

            _randomNumber = _random.Next(0, mainPoint.Length);
            
            _startPosition = mainPoint[_randomNumber];
            transform.position = _startPosition.transform.position;

            SetListPlace();
            ChooseNewPoints();
            WhereGoing();
        }

        private void SetListPlace()
        {
            for (int i = 0; i < mainPoint.Length; i++)
            {
                _places.Add(mainPoint[i].GetComponent<Place>());
            }
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
            _randomNumber = _random.Next(0, mainPoint.Length);
            var point = mainPoint[_randomNumber];
            while (point == position)
            {
                _randomNumber = _random.Next(0, mainPoint.Length);
                point = mainPoint[_randomNumber];
            }

            return point;
        }

        public void Infection()
        {
            _stateMachine.Request();
        }

        public HumanState GetState()
        {
            return _stateMachine.State();
        }
        
        public void WhereGoing()
        {
            text.text = _places[_randomNumber].Places.ToString();
        }
    }
}
