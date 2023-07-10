using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class ApplicationBootstrap : MonoBehaviour
    {
        private void Awake()
        {
            Screen.SetResolution(1920, 1080, true);
            Application.targetFrameRate = 60;
        }
    }
}