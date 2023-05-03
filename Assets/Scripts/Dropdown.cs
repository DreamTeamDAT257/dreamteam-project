using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dropdown : MonoBehaviour
{

    public GameObject cubePrefab;
    public float timesBigger2;
    public float cubesPerSide2;

    // Start is called before the first frame update
    //#kan använda singelton för cuben vi jobbar på. Måste ta bort kuberna innan - nu lägger jag bara till
    
    public void HandleInputData(int val)
    {

        if(val == 0)
        {
            timesBigger2 = 100;
            cubesPerSide2 = Mathf.Ceil(Mathf.Pow(timesBigger2, 1f / 3f));
            int cubeCounter = 0;
            for (int i = 0; i < cubesPerSide2; i++)
            {  
                for (int k = 0; k < cubesPerSide2; k++)
                {
                    for (int j = 0; j < cubesPerSide2; j++)
                    {
                        if(cubeCounter < timesBigger2) { 
                            MakeCube(i*1.1f, j*1.1f, k*1.1f);
                            cubeCounter++;
                        }
                  
                    
                    }
                }

            }
        }
        if(val == 1)
        {
            timesBigger2 = 200;
            cubesPerSide2 = Mathf.Ceil(Mathf.Pow(timesBigger2, 1f / 3f));
            int cubeCounter = 0;
            for (int i = 0; i < cubesPerSide2; i++)
            {  
                for (int k = 0; k < cubesPerSide2; k++)
                {
                    for (int j = 0; j < cubesPerSide2; j++)
                    {
                        if(cubeCounter < timesBigger2) { 
                            MakeCube(i*1.1f, j*1.1f, k*1.1f);
                            cubeCounter++;
                        }
                  
                    
                    }
                }

            }
        }
        if(val == 2)
        {
            timesBigger2 = 5;
            cubesPerSide2 = Mathf.Ceil(Mathf.Pow(timesBigger2, 1f / 3f));
            int cubeCounter = 0;
            for (int i = 0; i < cubesPerSide2; i++)
            {  
                for (int k = 0; k < cubesPerSide2; k++)
                {
                    for (int j = 0; j < cubesPerSide2; j++)
                    {
                        if(cubeCounter < timesBigger2) { 
                            MakeCube(i*1.1f, j*1.1f, k*1.1f);
                            cubeCounter++;
                        }
                  
                    
                    }
                }

            }
        }

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeCube(float x, float y, float z)
    {
        GameObject cube = Instantiate(cubePrefab);
        cube.transform.position = new Vector3(x, y, z);

    }

    
}
