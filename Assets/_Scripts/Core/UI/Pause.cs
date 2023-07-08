using UnityEngine;

namespace Core.UI
{
    public class Pause : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseMenu;

        public void Enter()
        {
            _pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }

        public void ExitPause()
        {
            _pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }

        public void ExitTheGame() => Application.Quit();
    }
}