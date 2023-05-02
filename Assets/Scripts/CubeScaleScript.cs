using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeScaleScript : MonoBehaviour
{
    public GameObject cubePrefab;
    //public float timesBigger = 173;
    public float cubesPerSide;
    public float specialCubeSide;
    //public GameObject largeCube;
    //public GameObject largeCubeFinal;

    // Start is called before the first frame update
    void Start()
    {
        //ScaleCube(1000);
        //largeCube = new GameObject();

        

        //largeCubeFinal = Instantiate(largeCube);
        //Destroy(largeCube);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScaleCube(float timesBigger, GameObject parent)
    {

        // calculation to check how the cube should be constructed
        cubesPerSide = Mathf.Floor(Mathf.Pow(timesBigger, 1f / 3f));
        float minReferenceCube = Mathf.Pow(cubesPerSide, 3f);
        minReferenceCube = minReferenceCube * (4f / 3f);
        Mathf.Floor(minReferenceCube);
        if (timesBigger <= minReferenceCube)
        {
            specialCubeSide = Mathf.Ceil((timesBigger / (Mathf.Pow(cubesPerSide, 2f))));
        }
        else
        {
            cubesPerSide = Mathf.Ceil(Mathf.Pow(timesBigger, 1f / 3f));
            specialCubeSide = cubesPerSide;
        }

        // perhaps add an if-statement to check so that an extra cube isnt added
        // the loop that spawns the cubes
        int cubeCounter = 0;
        for (int i = 0; i < specialCubeSide; i++)
        {
            for (int k = 0; k < cubesPerSide; k++)
            {
                for (int j = 0; j < cubesPerSide; j++)
                {
                    if (cubeCounter < timesBigger)
                    {
                        MakeCube(i * 1.1f, j * 1.1f, k * 1.1f, parent);
                        cubeCounter++;
                    }


                }
            }

        }

    }

    // the method that creates a cube
    public void MakeCube(float x, float y, float z, GameObject parent)
    {
        GameObject cube = Instantiate(cubePrefab);
        cube.transform.position = new Vector3(x, y, z);
        cube.transform.parent = parent.transform;

    }

}
