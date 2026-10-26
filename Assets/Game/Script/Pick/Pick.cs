using Zenject;

public class Pick : MonoInstaller
{
    public  PickAnimation _animation;
    public  InputReader _inputReader;
    public  PickAttack  _pickAttack;

    public override void InstallBindings()
    {
        Container.Bind<PickAnimation>().FromInstance(_animation).AsSingle();      
        Container.Bind<PickAttack>().FromInstance(_pickAttack).AsSingle();           
        Container.Bind<InputReader>().FromInstance(_inputReader).AsSingle();           
    }
}
