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
        public double mortality;
        public double life_expectancy;
        public double population;
        public double education_spending;
        public double health_spending;
        public double youth_literacy;
        public double primary_school_rate;
        public double secondary_school_rate;
        public double thinness;
        public double gdp;

        public double getMortality()
        {
            return mortality;
        }

        public double getLifeExpectancy()
        {
            return life_expectancy;
        }

        public double getPopulation()
        {
            return population;
        }

        public double getEducationSpending()
        {
            return education_spending;
        }

        public double getHealthSpending()
        {
            return health_spending;
        }

        public double getYouthLiteracy()
        {
            return youth_literacy;
        }

        public double getPrimarySchoolRate()
        {
            return primary_school_rate;
        }

        public double getSecondarySchoolRate()
        {
            return secondary_school_rate;
        }

        public double getThinness()
        {
            return thinness;
        }

        public double getGDP()
        {
            return gdp;
        }



        public double getSpecificInformation(string info)
        {
            switch (info)
            {
                case "mortality":
                    return getMortality();

                case "life_expectancy":
                    return getLifeExpectancy();

                case "population":
                    return getPopulation();

                case "education_spending":
                    return getEducationSpending();

                case "health_spending":
                    return getHealthSpending();

                case "youth_literacy":
                    return getYouthLiteracy();

                case "primary_school_rate":
                    return getPrimarySchoolRate();

                case "secondary_school_rate":
                    return getSecondarySchoolRate();

                case "thinness":
                    return getThinness();

                case "gdp":
                    return getGDP();

                default:
                    return 0;
            }
        }

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
                if (country.name.ToUpper().Equals(name.ToUpper()))
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

        public Information getMostRecentYear(string name)
        {
            Country c = getCountryByName(name);
            Debug.Log(c);
            int year = 0;
            foreach(Years years in c.years)
            {
                if(years.year > year)
                {
                    year = years.year;
                }
            }
            return getInformation(name, year);
        }

    }

    public CountryList myCountryList = new CountryList();

    // Start is called before the first frame update
    void Start()
    {
        myCountryList = JsonUtility.FromJson<CountryList>(JsonFile.text);

        Debug.Log(myCountryList.getCountryByName("Japan").years[0].information.getSpecificInformation("mortality"));

        //Debug.Log(myCountryList.getMostRecentYear("Japan").trees);

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
