using NPCSystem;
using UnityEngine;
using Random = System.Random;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private Human[] humans;
        [SerializeField] private GameObject parasitePrefab;

        private readonly Random _random = new();
        
        void Awake()
        {
            int index = _random.Next(0, humans.Length);
            Instantiate(parasitePrefab, humans[index].transform);
            humans[index].gameObject.layer = 7;
            humans[index].ChangeState();
        }
    }
}
