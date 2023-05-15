using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class VrKeyboardController : MonoBehaviour
{
    public UnityEvent<string> inputListeners;
    public UnityEvent<int> inputListeners2;
    public TextMeshPro displayText;

    private string currentText = "";

    public void TypeLetter(BaseButtonScript pressed)
    {
        currentText += ((VrKey)pressed).character;
    }

    public void SendTyped()
    {
        inputListeners.Invoke(currentText);
    }

    public void SendNumb()
    {
        //gör om text till int
        int currentNum = int.Parse(currentText);
        inputListeners2.Invoke(currentNum);
        
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
