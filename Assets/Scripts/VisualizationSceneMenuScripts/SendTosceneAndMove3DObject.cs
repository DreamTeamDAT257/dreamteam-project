using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SendTosceneAndMove3DObject : BaseButtonScript
    
{
        public int toScene = 1;

        public override void ClickToHover()
        {
            SceneManager.LoadScene(toScene);
        }
    
}
