using System;
using System.Collections.Generic;
using _Source.LevelSystem;
using UnityEngine;
using Random = System.Random;

namespace _Source.NPCSystem
{
    public class Human : MonoBehaviour
    {
        [SerializeField] private MovementPoints[] points;
        // [SerializeField] private MovementPoints points1;
        // [SerializeField] private MovementPoints points2;

        private Movement _movement;
        private Random _random;
        private MovementPoints _startPosition;
        private MovementPoints _target;
        private List<Transform> _targetPosition = new List<Transform>();
        private Transform _position;
        private int _pointPassed;
        
        void Awake()
        {
            Init();
        }

        private void Update()
        {
            _movement.Move(transform, _targetPosition, ref _pointPassed);
            // Debug.Log(transform.position);
            // Debug.Log(_targetPosition[^1].position + " " + _targetPosition.Count);
            // Debug.Log(_pointPassed);
            Debug.Log(_targetPosition.Count);

            if (transform.position == _target.transform.position)
            {
                // _pointPassed = 0;
                ChooseNewPoint();
            }
        }

        private void Init()
        {
            _movement = new Movement();
            _random = new Random();

            _startPosition = points[_random.Next(0, points.Length)];
            transform.position = _startPosition.transform.position;
            ChooseNewPoint();
            // transform.position = _startPosition.transform.position;
            // _target = points[_random.Next(0, points.Length)];
            
            // _startPosition = points1;
            // transform.position = _startPosition.transform.position;
            // _target = points2;
            
            // if (_movement.CanMove(_startPosition, _target))
            // {
            //     _targetPosition = _target.transform;
            // }
            // _targetPosition = _movement.FindPath(_startPosition, _target);
            // foreach (var VARIABLE in d)
            // {
            //     Debug.Log(VARIABLE.position);
            // }
            // Debug.Log(_targetPosition.Count);
            // for (int i = 0; i < _targetPosition.Count; i++)
            // {
            //     Debug.Log(_targetPosition[i].position);
            // }
        }

        private void ChooseNewPoint()
        {
            _pointPassed = 0;
            _target = points[_random.Next(0, points.Length)];
            _targetPosition = _movement.FindPath(_startPosition, _target);
        }
    }
}
