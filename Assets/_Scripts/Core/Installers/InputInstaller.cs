using UnityEngine;
using Zenject;

namespace Core.Installers
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<Input>()
                .AsSingle()
                .NonLazy();
        }
    }
}