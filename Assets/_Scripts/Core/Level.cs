using UnityEngine.SceneManagement;

namespace Core
{
    public static class Level
    {
        public static void NextLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        public static void RestartLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}