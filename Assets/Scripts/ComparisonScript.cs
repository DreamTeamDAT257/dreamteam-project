using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComparisonScript : MonoBehaviour
{

    public float val1;
    public float val2;
    public GameObject firstCube;
    public GameObject secondCube;
    Dictionary<int, float> optionValues = new Dictionary<int, float>();
    public GameObject cubeScaleObject;
    public GameObject mergeCubeObject;
    public CubeScaleScript cubeScaleScript;
    public MergeCubesScript mergeCubesScript;

    public void GetFirstDropdownValue(int option)
    {
        val1 = optionValues[option];
        CompareNumbers(val1, val2);

        
        
    }
    public void GetSecondDropdownValue(int option)
    {
        val2 = optionValues[option];
        CompareNumbers(val1, val2);


    }
    public void CompareNumbers(float firstVal, float secondVal)
    {
        ClearAllChildren(firstCube);
        ClearAllChildren(secondCube);
        GameObject firstHolderCube = new GameObject();
        firstHolderCube.transform.parent = firstCube.transform;
        firstHolderCube.transform.position = new Vector3(0f, 0f, 0f);
        GameObject secondHolderCube = new GameObject();
        secondHolderCube.transform.parent = secondCube.transform;
        secondHolderCube.transform.position = new Vector3((5f + Mathf.Pow(firstVal, 1f / 3f)), 0f, 0f);
        

        if (firstVal > secondVal)
        {
            cubeScaleScript.ScaleCube(1f, secondHolderCube);
            mergeCubesScript.MergeCube(secondHolderCube);
            cubeScaleScript.ScaleCube((firstVal/secondVal), firstHolderCube);
            mergeCubesScript.MergeCube(firstHolderCube);

        }
        else
        {
            cubeScaleScript.ScaleCube(1f, firstHolderCube);
            mergeCubesScript.MergeCube(firstHolderCube);
            cubeScaleScript.ScaleCube((secondVal/firstVal), secondHolderCube);
            mergeCubesScript.MergeCube(secondHolderCube);

        }


    }

    public void ClearAllChildren(GameObject parent)
    {
        foreach (Transform child in parent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        cubeScaleScript = cubeScaleObject.GetComponent<CubeScaleScript>();
        mergeCubesScript = mergeCubeObject.GetComponent<MergeCubesScript>();
        //cubeScaleScript = new CubeScaleScript();
        //mergeCubesScript = new MergeCubesScript();
        val1 = 3;
        val2 = 3;
        optionValues[0] = 3f;
        optionValues[1] = 14f;
        optionValues[2] = 143f;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //gör en metod som jämför två tal och uppdatera och ta bort kuberna utefter det
    
}
