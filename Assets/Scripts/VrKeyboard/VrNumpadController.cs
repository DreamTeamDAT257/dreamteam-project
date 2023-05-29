using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class VrNumpadController : MonoBehaviour
{
    public UnityEvent<int> inputListeners;

    public TextMeshPro displayText;

    private string currentText = "";

    /**Activated when number is typed**/
    public void TypeNum(BaseButtonScript pressed)
    {
        if(currentText.Length < 4)
        {
            currentText += ((VrKey)pressed).character;
        }
        
    }


    /**Sends typed number to listeners**/
    public void SendNumb()
    {
        //gör om text till int
        int currentNum = int.Parse(currentText);
        inputListeners.Invoke(currentNum);
        
    }

    /**Removes most rightward number**/
    public void RemoveLetter()
    {
        if (currentText.Length > 0)
        {
            currentText = currentText.Remove(currentText.Length - 1);
        }
    }

    /**Refreshes display**/
    public void UpdateDisplayTest()
    {
        if ((Time.fixedTime*2) % 2 > 0.5)
        {
            displayText.text = " " + currentText + "|";
        }
        else
        {
            displayText.text = currentText;
        }
    }

    private void FixedUpdate()
    {
        UpdateDisplayTest();
    }
}
