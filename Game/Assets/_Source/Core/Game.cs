using TMPro;
using UnityEngine;
using Utils;
using Utils.Event;

namespace Core
{
    public class Game
    {
        private readonly GameObject _panel;
        private readonly TMP_Text _text;
        
        private int _humanCount;
        
        public Game(int humanCount, GameObject panel, TMP_Text text)
        {
            _humanCount = humanCount;
            _panel = panel;
            _text = text;
            Registration();
        }
        
        private void Registration()
        {
            Signals.Get<LoseGameSignal>().AddListener(LoseGame);
            Signals.Get<HumanDieSignal>().AddListener(HumanDie);
        }

        private void Unsubscribe()
        {
            Signals.Get<LoseGameSignal>().RemoveListener(LoseGame);
            Signals.Get<HumanDieSignal>().RemoveListener(HumanDie);
        }

        private void HumanDie()
        {
            _humanCount--;
            
            if (Check())
            {
                WinGame();
            }
        }

        private bool Check()
        {
            if (_humanCount <= 1)
            {
                return true;
            }
            
            return false;
        }

        private void WinGame()
        {
            Time.timeScale = 0;
            _panel.SetActive(true);
            _text.text = "Win";
            Unsubscribe();
        }

        private void LoseGame()
        {
            Time.timeScale = 0;
            _panel.SetActive(true);
            _text.text = "Lose";
            Unsubscribe();
        }
    }
}