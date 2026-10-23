using Zenject;

public class Pick : MonoInstaller
{
    public InputReader _inputReader;
    public  PickAnimation _animation;

    public override void InstallBindings()
    {
        Container.Bind<PickAnimation>()
          .FromInstance(_animation)
          .AsSingle();

        Container.Bind<InputReader>()
            .FromInstance(_inputReader)
            .AsSingle();
    }
}
