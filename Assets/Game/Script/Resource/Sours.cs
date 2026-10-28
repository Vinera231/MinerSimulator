using Zenject;

public class Sours : MonoInstaller
{
    public Resource _resource;
    public ViewResourseRock _viewResourseRock;
    public ViewResourseOre _viewResourseOre;

    public override void InstallBindings()
    {
        Container.Bind<Resource>().FromInstance(_resource).AsSingle();
        Container.Bind<ViewResourseRock>().FromInstance(_viewResourseRock).AsSingle();
        Container.Bind<ViewResourseOre>().FromInstance(_viewResourseOre).AsSingle();
    }
}