using UnityEngine;

public class WASDSpaceshipController  : AbstractSpaceshipController
{
    protected override bool InputUp()
    {
        return Input.GetKey(KeyCode.W);
    }
    protected override bool InputDown()
    {
        return Input.GetKey(KeyCode.S);
    }

    protected override bool InputLeft()
    {
        return Input.GetKey(KeyCode.A);
    }

    protected override bool InputRight()
    {
        return Input.GetKey(KeyCode.D);
    }
}

