using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{

    public float scale = 1.01f;
    private int frameCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < 1000; i++)
        {
            transform.localScale *= scale;
            Debug.Log(frameCounter);
            frameCounter++;
        }

        for (int i = 0; i < 1000; i++)
        {
            transform.localScale /= scale;
        }

    }
}
