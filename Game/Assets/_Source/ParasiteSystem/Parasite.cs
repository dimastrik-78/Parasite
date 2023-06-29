using System.Collections;
using UnityEngine;

namespace ParasiteSystem
{
    public class Parasite : MonoBehaviour
    {
        [SerializeField] private int restoringMovementTime;
        [SerializeField] private LayerMask human;

        private bool _canTransition = true;

        private const float WAIT = 1f;

        void Update()
        {
            RaycastHit2D[] hit = Physics2D.CircleCastAll(transform.position, 2f, Vector2.up, 0, human);
            
            if (hit.Length > 0
                && Input.GetMouseButtonDown(0)
                && _canTransition)
            {
                transform.parent.gameObject.SetActive(false);
                transform.parent = hit[0].transform;
                transform.parent.gameObject.layer = 7;
                transform.localPosition = Vector3.zero;
                StartCoroutine(RestoringMovement());
            }
        }

        private IEnumerator RestoringMovement()
        {
            _canTransition = false;
            
            int time = restoringMovementTime;
            while (time != 0)
            {
                yield return new WaitForSeconds(WAIT);
                time--;
            }

            _canTransition = true;
        }
    }
}
