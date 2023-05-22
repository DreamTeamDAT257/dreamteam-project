using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrNum : BaseButtonScript
{
    public int integer;

    /**Type number when clicking is first activated**/
    public override void HoverToClick()
    {
        ClickingButton();
        triggerEvent.Invoke(this);
    }

    /**Return to hover**/
    public override void ClickToHover()
    {
        HoveringButton();
    }
}
