using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControllerInteractable
{
    void Hover();
    void EndHover();
    void Click();
    void EndClick();
    void HoverToClick();
    void ClickToHover();
}
