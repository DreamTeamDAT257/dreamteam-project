using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeScaleScript : MonoBehaviour
{
    public GameObject cubePrefab;
    public float timesBigger = 17;
    public float cubesPerSide;

    // Start is called before the first frame update
    void Start()
    {

        cubesPerSide = Mathf.Ceil(Mathf.Pow(timesBigger, 1f / 3f));
        int cubeCounter = 0;
        for (int i = 0; i < cubesPerSide; i++)
        {
            for (int k = 0; k < cubesPerSide; k++)
            {
                for (int j = 0; j < cubesPerSide; j++)
                {
                    if(cubeCounter < timesBigger) { 
                        MakeCube(i*1.1f, j*1.1f, k*1.1f);
                        cubeCounter++;
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
