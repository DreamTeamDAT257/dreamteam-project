using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeScaleScript : MonoBehaviour
{
    public GameObject cubePrefab;
    public float timesBigger = 173;
    public float cubesPerSide;
    public float specialCubeSide;
    public GameObject largeCube;
    //public GameObject largeCubeFinal;

    // Start is called before the first frame update
    void Start()
    {
        //largeCube = new GameObject();

        cubesPerSide = Mathf.Floor(Mathf.Pow(timesBigger, 1f / 3f));
        float minReferenceCube = Mathf.Pow(cubesPerSide, 3f);
        minReferenceCube = minReferenceCube * (4f/3f);
        Mathf.Floor(minReferenceCube);
        if (timesBigger <= minReferenceCube){
            specialCubeSide = Mathf.Ceil((timesBigger/(Mathf.Pow(cubesPerSide, 2f))));
        }
        else{
            cubesPerSide = Mathf.Ceil(Mathf.Pow(timesBigger, 1f / 3f));
            specialCubeSide = cubesPerSide;
        }


        int cubeCounter = 0;
        for (int i = 0; i < specialCubeSide; i++)
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

        //largeCubeFinal = Instantiate(largeCube);
        //Destroy(largeCube);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeCube(float x, float y, float z)
    {
        GameObject cube = Instantiate(cubePrefab);
        cube.transform.position = new Vector3(x, y, z);
        cube.transform.parent = largeCube.transform;

    }

}
