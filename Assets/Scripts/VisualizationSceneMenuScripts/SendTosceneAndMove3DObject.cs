using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SendTosceneAndMove3DObject : BaseButtonScript
    
    {
        public UnityEvent<BaseButtonScript> triggerEvent;

        public Material defaultMaterial;
        public Material hoverMaterial;
        public Material clickMaterial;
        public MeshRenderer meshRender;

        public int toScene = 1;



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
        meshRender.material = clickMaterial;
    }




    #region interface implementation
    public virtual void Click()
    {
        ClickingButton();
    }

    public virtual void ClickToHover()
    {
        SceneManager.LoadScene(toScene); //Not from baseButtonScript
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
