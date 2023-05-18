using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComparisonScript : MonoBehaviour
{

    public float val1 = 0;
    public float val2 = 0;

    public string visualDataType = null;
    
    public int year1 = 0;
    public int year2 = 0;
    
    public string countryName1 = null;
    public string countryName2 = null;

    public GameObject firstCube;
    public GameObject secondCube;

    Dictionary<string, float> optionValues = new Dictionary<string, float>();

    //public GameObject cubeScaleObject;
    //public GameObject mergeCubeObject;
    //public GameObject jsonCreatorObject;

    public CubeScaleScript cubeScaleScript;
    public MergeCubesScript mergeCubesScript;
    public JSONCreator jsonCreator;

    public void getVisualDataType(string dataType)
    {
        if(dataType == "mortality" || dataType == "life_expectancy" || dataType == "population" || dataType == "education_spending" || dataType == "health_spending" || dataType == "youth_literacy" || dataType == "primary_school_rate" || dataType == "secondary_school_rate" || dataType == "thinness" || dataType == "gdp")
        {
            visualDataType = dataType;
            checkFinishedInput();
        }
        
    }

    public void getFirstYear(int year)
    {
        year1 = year;
        if(jsonCreator.myCountryList.getInformation(countryName1, year1) != null)
        {
            checkFinishedInput();
        }
        
    }

    public void getSecondYear(int year)
    {
        year2 = year;
        if(jsonCreator.myCountryList.getInformation(countryName2, year2) != null)
        {
            checkFinishedInput();
        }
        
    }

    public void getFirstName(string countryName)
    {
        if(jsonCreator.myCountryList.getCountryByName(countryName) != null)
        {
            countryName1 = countryName;
            checkFinishedInput();
        }
        
    }

    public void getSecondName(string countryName)
    {
        if(jsonCreator.myCountryList.getCountryByName(countryName) != null)
        {
            countryName2 = countryName;
            checkFinishedInput();
        }
        
    }

    public void checkFinishedInput()
    {
        if (year1 != 0 && year2 != 0 && countryName1 != null && countryName2 != null && visualDataType != null )
        {
            val1 = (float) jsonCreator.myCountryList.getInformation(countryName1, year1).getSpecificInformation(visualDataType);
            val2 = (float) jsonCreator.myCountryList.getInformation(countryName2, year2).getSpecificInformation(visualDataType);
            if ((val1 > 0) && (val2 > 0))
            {
                CompareNumbers(val1, val2);
            }
        }
            
    }
    
    /*
    public void GetFirstDropdownValue(string countryName)
    {
        val1 = (float) jsonCreator.myCountryList.getMostRecentYear(countryName).getSpecificInformation(visualDataType);
        //val1 = optionValues[countryName];
        
        
        if((val1 != -1) && (val2 != -1))
        {
            CompareNumbers(val1, val2);
        } 
        
    }
    public void GetSecondDropdownValue(string countryName)
    {

        //dropdown.options[dropdown.value].text
        //val2 = optionValues[countryName];
        val2 = (float) jsonCreator.myCountryList.getMostRecentYear(countryName).getSpecificInformation(visualDataType);
        if ((val1 != -1) && (val2 != -1))
        {
            CompareNumbers(val1, val2);
        }
        


    }
    */
    public void CompareNumbers(float firstVal, float secondVal)
    {
        ClearAllChildren(firstCube);
        ClearAllChildren(secondCube);
        GameObject firstHolderCube = new GameObject();
        firstHolderCube.transform.parent = firstCube.transform;
        //firstHolderCube.transform.position = new Vector3(0f, 0f, 0f);
        firstHolderCube.transform.position = firstCube.transform.position;
        GameObject secondHolderCube = new GameObject();
        secondHolderCube.transform.parent = secondCube.transform;
        //secondHolderCube.transform.position = new Vector3((5f + Mathf.Pow(firstVal, 1f / 3f)), 0f, 0f);
        secondHolderCube.transform.position = secondCube.transform.position;
        //secondHolderCube.transform.position += new Vector3((5f + Mathf.Pow(firstVal, 1f / 3f)), 0f, 0f);



        if (firstVal > secondVal)
        {
            if (firstVal/secondVal < Mathf.Pow(firstVal, 1f / 3f))
            {
                secondHolderCube.transform.position += new Vector3(5f + firstVal / secondVal, 0f, 0f);
            }
            else
            {
                secondHolderCube.transform.position += new Vector3((5f + Mathf.Pow(firstVal, 1f / 3f)), 0f, 0f);
            }
            /*cubeScaleScript.ScaleCube(1f, secondHolderCube);
            mergeCubesScript.MergeCube(secondHolderCube);
            cubeScaleScript.ScaleCube((firstVal/secondVal), firstHolderCube);
            mergeCubesScript.MergeCube(firstHolderCube);*/
            InitializeCubes(secondHolderCube, firstHolderCube, (firstVal / secondVal));

        }
        else
        {
            secondHolderCube.transform.position += new Vector3(5f, 0f, 0f);
            /*cubeScaleScript.ScaleCube(1f, firstHolderCube);
            mergeCubesScript.MergeCube(firstHolderCube);
            cubeScaleScript.ScaleCube((secondVal/firstVal), secondHolderCube);
            mergeCubesScript.MergeCube(secondHolderCube);*/
            InitializeCubes(firstHolderCube, secondHolderCube, (secondVal / firstVal));
        }


    }

    public void InitializeCubes(GameObject smallerCube, GameObject largerCube, float timesBigger)
    {
        cubeScaleScript.ScaleCube(1f, smallerCube);
        mergeCubesScript.MergeCube(smallerCube);
        cubeScaleScript.ScaleCube(timesBigger, largerCube);
        mergeCubesScript.MergeCube(largerCube);
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
        //cubeScaleScript = new CubeScaleScript();
        //mergeCubesScript = new MergeCubesScript();
        /*
        val1 = -1;
        val2 = -1;
        optionValues["Sweden"] = 3f;
        optionValues["Norge"] = 9000f;
        optionValues["Denmark"] = 12000f;
        //optionValues[2] = 143f;
    */

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
