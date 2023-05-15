using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseButtonScript : MonoBehaviour, IControllerInteractable
{
    public UnityEvent<BaseButtonScript> triggerEvent;

    public Material defaultMaterial;
    public Material hoverMaterial;
    public Material clickMaterial;
    public MeshRenderer meshRender;



    public virtual void UninteractButton()
    {
        meshRender.material = defaultMaterial;
    }

    public virtual void HoveringButton()
    {
        meshRender.material = hoverMaterial;
    }

    public virtual void ClickingButton()
    {
  wa      meshRender.material = clickMaterial;
    }



    #region interface implementation
    public virtual void Click()
    {
        ClickingButton();
    }

    public virtual void ClickToHover()
    {
        triggerEvent.Invoke(this);
        HoveringButton();
    }

    public virtual void EndClick()
    {
        UninteractButton();
    }

    public virtual void EndHover()
    {
        UninteractButton();
    }

    public virtual void Hover()
    {
        HoveringButton();
    }

    public virtual void HoverToClick()
    {
        ClickingButton();
    }
    #endregion
}
