using Core.Projectiles;
using UnityEngine;
using Zenject;

namespace Core.Installers
{
    public class ProjectileLauncherInstaller : MonoInstaller
    {
        [SerializeField] private ProjectileLauncher _projectileLauncher;

        public override void InstallBindings()
        {
            Container
                .Bind<ProjectileLauncher>()
                .FromInstance(_projectileLauncher)
                .AsSingle();
        }
    }
}