using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONCreator : MonoBehaviour
{

    public TextAsset JsonFile;

    [System.Serializable]
    public class Information
    {
        public int year;
        public int gdp;
        public int trees;
        public int deaths;
    }

    [System.Serializable]
    public class Country
    {
        public string code;
        public string name;
        public List<Information> information;

        public List<Information> getInformation()
        {
            return information;
        }
    }

    [System.Serializable]
    public class CountryList
    {
        public Country[] country;
    }

    public CountryList myCountryList = new CountryList();

    // Start is called before the first frame update
    void Start()
    {
        myCountryList = JsonUtility.FromJson<CountryList>(JsonFile.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
