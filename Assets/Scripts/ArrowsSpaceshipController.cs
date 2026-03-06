using UnityEngine;

public class ArrowsSpaceshipController : AbstractSpaceshipController
{
    protected override bool InputUp()
    {
        return Input.GetKey(KeyCode.UpArrow);
    }
    protected override bool InputDown()
    {
        return Input.GetKey(KeyCode.DownArrow);
    }

    protected override bool InputLeft()
    {
        return Input.GetKey(KeyCode.LeftArrow);
    }

    protected override bool InputRight()
    {
        return Input.GetKey(KeyCode.RightArrow);
    }
}
