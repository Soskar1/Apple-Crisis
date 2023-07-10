using System.Collections;
using UnityEngine;

namespace Core
{
    public class BackgroundMusic : MonoBehaviour
    {
        [SerializeField] private AudioSource _source;
        private static BackgroundMusic _instance;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                _source.Play();
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}