using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UISystem
{
    public class ResultPanel : MonoBehaviour
    {
        [SerializeField] private Button resetButton;

        private void OnEnable()
        {
            resetButton.onClick.AddListener(ResetGame);
        }

        private void OnDisable()
        {
            resetButton.onClick.RemoveListener(ResetGame);
        }

        private void ResetGame()
        {
            SceneManager.LoadScene(0);
        }
    }
}