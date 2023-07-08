using UnityEngine;
using System.Collections;

namespace Core
{
    public class EndScene : MonoBehaviour
    {
        [SerializeField] private float _exitTime;

        private IEnumerator ExitTheGame()
        {
            yield return new WaitForSeconds(_exitTime);

            Application.Quit();
        }
    }
}