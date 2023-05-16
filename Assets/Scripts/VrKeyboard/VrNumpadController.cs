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

    public void TypeNum(BaseButtonScript pressed)
    {
        if(currentText.Length < 4)
        {
            currentText += ((VrKey)pressed).character;
        }
        
    }


    public void SendNumb()
    {
        //gör om text till int
        int currentNum = int.Parse(currentText);
        inputListeners.Invoke(currentNum);
        
    }

    public void RemoveLetter()
    {
        if (currentText.Length > 0)
        {
            currentText = currentText.Remove(currentText.Length - 1);
        }
    }

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
