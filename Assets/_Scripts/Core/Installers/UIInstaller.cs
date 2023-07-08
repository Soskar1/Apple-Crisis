using Core.UI;
using UnityEngine;
using Zenject;

namespace Core.Installers
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private HintArrow _hintArrow;

        public override void InstallBindings()
        {
            Container
                .Bind<HintArrow>()
                .FromInstance(_hintArrow)
                .AsSingle();
        }
    }
}