using Zenject;

public class Sours : MonoInstaller
{
    public Resource _resource;
    public ViewResourse _viewResourse;

    public override void InstallBindings()
    {
        Container.Bind<Resource>().FromInstance(_resource).AsSingle();
        Container.Bind<ViewResourse>().FromInstance(_viewResourse).AsSingle();
    }
}