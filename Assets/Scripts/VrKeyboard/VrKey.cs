using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrKey : BaseButtonScript
{
    public char character;

    // Moved activation of button from ClickToHover() to HoverToClick, makes typing more smooth
    public override void HoverToClick()
    {
        ClickingButton();
        triggerEvent.Invoke(this);
    }

    public override void ClickToHover()
    {
        HoveringButton();
    }
}
