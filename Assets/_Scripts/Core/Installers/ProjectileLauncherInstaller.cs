using Core.Projectiles;
using UnityEngine;
using Zenject;

namespace Core.Installers
{
    public class ProjectileLauncherInstaller : MonoInstaller
    {
        [SerializeField] private DeathZone _deathZone;
        [SerializeField] private ProjectileLauncher _projectileLauncher;

        public override void InstallBindings()
        {
            BindProjectileLauncher();
            BindDeathZone();
        }

        private void BindProjectileLauncher()
        {
            Container
                .Bind<ProjectileLauncher>()
                .FromInstance(_projectileLauncher)
                .AsSingle();
        }

        private void BindDeathZone()
        {
            Container
                .Bind<DeathZone>()
                .FromInstance(_deathZone)
                .AsSingle();
        }
    }
}