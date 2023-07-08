using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Zenject;

namespace Core.UI
{
    public class Pause : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseMenu;
        private Input _input;

        [Inject]
        private void Construct(Input input) => _input = input;

        private void OnEnable() => _input.Controls.Target.Pause.performed += Enter;
        private void OnDisabe()
        {
            _input.Controls.Target.Pause.performed -= Enter;
            _input.Controls.Target.Pause.performed -= ExitPause;
        }

        private void Enter(InputAction.CallbackContext ctx)
        {
            _input.Controls.Target.Pause.performed -= Enter;
            _input.Controls.Target.Pause.performed += ExitPause;
            
            _pauseMenu.SetActive(true);
            Time.timeScale = 0f;

            ShowCursor();
        }

        private void ExitPause(InputAction.CallbackContext ctx)
        {
            _input.Controls.Target.Pause.performed -= ExitPause;
            _input.Controls.Target.Pause.performed += Enter;

            ExitPause();
        }

        public void ExitPause()
        {
            _pauseMenu.SetActive(false);
            Time.timeScale = 1f;

            HideCursor();
        }

        public void EnterMainMenu() => SceneManager.LoadScene(0);

        public void ExitTheGame() => Application.Quit();

        private void HideCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void ShowCursor()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}