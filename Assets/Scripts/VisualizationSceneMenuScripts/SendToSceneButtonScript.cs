using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SendToSceneButtonScript : BaseButtonScript
{
    public int toScene = 1;

    public override void ClickToHover()
    {
        SceneManager.LoadScene(toScene);
    }
}
