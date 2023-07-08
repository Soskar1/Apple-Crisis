using UnityEngine;

namespace Core.UI
{
    public class MainMenu : MonoBehaviour
    {
        public void Play() => Level.NextLevel();

        public void Exit() => Application.Quit();
    }
}