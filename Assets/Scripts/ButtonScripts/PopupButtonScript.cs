using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PopupButtonScript : BaseButtonScript
{
    public GameObject ObjectToHide;

    public override void ClickToHover()
    {
        ObjectToHide.SetActive(!ObjectToHide.activeSelf);
        base.ClickToHover();
    }
}
