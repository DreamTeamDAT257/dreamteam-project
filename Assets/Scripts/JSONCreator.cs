using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONCreator : MonoBehaviour
{

    public TextAsset JsonFile;

    [System.Serializable]
    public class Years
    {
        public int year;
        public Information information;
    }


    [System.Serializable]
    public class Information
    {
        public int gdp;
        public int deaths;
        public int trees;

    }

    [System.Serializable]
    public class Country
    {
        public string name;
        public string country_code;
        public List<Years> years;

        public Information getInformationByYear(int year)
        {
            foreach (Years years in years)
            {
                if (years.year == year)
                {
                    return years.information;
                }
            }
            return null;
        }
    }

    [System.Serializable]
    public class CountryList
    {
        public Country[] country;

        public Country getCountryByName(string name)
        {
            foreach (Country country in country)
            {
                if (country.name.Equals(name))
                {
                    return country;
                }
            }
            return null;
        }

        public Information getInformation(string country_name, int year)
        {
            Country c = getCountryByName(country_name);
            return c.getInformationByYear(year);
        }

    }

    public CountryList myCountryList = new CountryList();

    // Start is called before the first frame update
    void Start()
    {
        myCountryList = JsonUtility.FromJson<CountryList>(JsonFile.text);

        /* foreach(Country country in myCountryList.country)
        {
            Debug.Log(country.country_code);
        }

        Debug.Log(myCountryList.getInformation("Japan", 2000).deaths);
        */

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
