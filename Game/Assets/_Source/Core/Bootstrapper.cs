using NPCSystem;
using TMPro;
using UnityEngine;
using Random = System.Random;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private Human[] humans;
        [SerializeField] private GameObject parasitePrefab;
        [SerializeField] private GameObject resultPanel;
        [SerializeField] private TMP_Text text;

        private readonly Random _random = new();

        private Game _game;
        
        private void Start()
        {
            _game = new Game(humans.Length, resultPanel, text);
            
            int index = _random.Next(0, humans.Length);
            Instantiate(parasitePrefab, humans[index].transform);
            humans[index].gameObject.layer = 7;
            humans[index].Infection();
            humans[index].WhereGoing();
        }
    }
}
