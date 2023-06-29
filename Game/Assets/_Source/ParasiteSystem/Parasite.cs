using UnityEngine;

namespace ParasiteSystem
{
    public class Parasite : MonoBehaviour
    {
        [SerializeField] private LayerMask human;

        void Update()
        {
            RaycastHit2D[] hit = Physics2D.CircleCastAll(transform.position, 4f, Vector2.up, 0, human);
            // Debug.Log(hit[0].transform.name);
            if (hit.Length > 0
                && Input.GetMouseButtonDown(0))
            {
                // Debug.Log(hit[0].transform.name);
                transform.parent.gameObject.SetActive(false);
                transform.parent = hit[0].transform;
                transform.localPosition = Vector3.zero;
            }
        }
    }
}
