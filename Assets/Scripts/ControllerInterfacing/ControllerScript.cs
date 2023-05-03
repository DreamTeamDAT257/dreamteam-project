using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    public bool isRightController;
    public GameObject aimAidObject;

    private static readonly int layerMask = 1 << 6;

    private IControllerInteractable currentlyInteracting;
    private bool currentlyClicking;

    private int aimableCount;

    private void FixedUpdate()
    {
        // Usage
        RaycastHit hit;
        IControllerInteractable newInteracting;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10, layerMask))
        {
            newInteracting = hit.collider.gameObject.GetComponent<IControllerInteractable>();
        }
        else
        {
            newInteracting = null;
        }

        bool newClicking;
        if (isRightController)
        {
            newClicking = Input.GetAxis("XRI_Right_Trigger") > 0.5f;
        }
        else
        {
            newClicking = Input.GetAxis("XRI_Left_Trigger") > 0.5f;
        }

        if (currentlyInteracting != null)
        {
            if (newInteracting != null)
            {
                #region controller was pointing at object but might have switched to another
                if (newInteracting == currentlyInteracting)
                {
                    if (currentlyClicking != newClicking)
                    {
                        if (newClicking)
                        {
                            newInteracting.HoverToClick();
                        }
                        else
                        {
                            newInteracting.ClickToHover();
                        }
                    }
                }
                else
                {
                    if (currentlyClicking)
                    {
                        currentlyInteracting.EndClick();
                    }
                    else
                    {
                        currentlyInteracting.EndHover();
                    }
                    if (newClicking)
                    {
                        newInteracting.Click();
                    }
                    else
                    {
                        newInteracting.Hover();
                    }
                }
                #endregion
            }
            else
            {
                #region controller was pointing at object but no longer is
                if (currentlyClicking)
                {
                    currentlyInteracting.EndClick();
                }
                else
                {
                    currentlyInteracting.EndHover();
                }
                #endregion
            }
        }
        else
        {
            if (newInteracting != null)
            {
                #region controller was not pointing at object and now is
                if (newClicking)
                {
                    newInteracting.Click();
                }
                else
                {
                    newInteracting.Hover();
                }
                #endregion
            }
            else
            {
                #region controller was not pointing at object and still is not
                #endregion
            }
        }
        currentlyInteracting = newInteracting;
        currentlyClicking = newClicking;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("aaaa");
        if (other.gameObject.layer == 6)
        {
            aimableCount++;
            gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            aimableCount--;
            if (aimableCount <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
