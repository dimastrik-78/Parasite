using LevelSystem.PlaceStrategy;
using NPCSystem;
using NPCSystem.HumanStateMachine;
using UnityEngine;
using Utils;
using Utils.Event;

namespace LevelSystem
{
    public class Place : MonoBehaviour
    {
        [SerializeField] private Places places;

        private ChoseAction _choseAction;

        private void Awake()
        {
            _choseAction = new ChoseAction();
        }

        private void OnEnable()
        {
            Signals.Get<HumanCameIntoPlaceSignal>().AddListener(Action);
        }

        private void OnDisable()
        {
            Signals.Get<HumanCameIntoPlaceSignal>().RemoveListener(Action);
        }

        private void Action(Human human)
        {
            if (human.transform.position == transform.position
                && human.GetState() == HumanState.Infected)
            {
                _choseAction.Action(places);
            }
        }
    }
}