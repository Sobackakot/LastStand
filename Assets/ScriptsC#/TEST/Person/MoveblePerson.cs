
using Zenject;

public class MoveblePerson : ITickable
{   
    private MoveblePerson(IInputMove inputMove, ICharacter character)
    {
        this.inputMove = inputMove;
        this.character = character;
    }
    private IInputMove inputMove;
    private ICharacter character;

    void ITickable.Tick()
    {
        float z = inputMove.Vertical(); 
        float x = inputMove.Horizontal();
        bool isKeyDown = inputMove.IsKeyDownSpace();
        character.Move(x,z);
        character.Jump(isKeyDown);
    }
}
