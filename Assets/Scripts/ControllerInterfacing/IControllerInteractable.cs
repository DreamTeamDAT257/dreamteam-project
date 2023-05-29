using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControllerInteractable
{
    /**What to do if object goes from no interaction to hover**/
    void Hover();

    /**What to do if object goes from hover to no interaction**/
    void EndHover();

    /**What to do if object goes from no interaction to click**/
    void Click();

    /**What to do if object goes from click to no interaction**/
    void EndClick();

    /**What to do if object goes from hover to click**/
    void HoverToClick();

    /**What to do if object goes from click to hover**/
    void ClickToHover();
}
