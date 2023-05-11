package dreamteam.json.json;

import com.neovisionaries.i18n.CountryCode;
import dreamteam.json.FileParser;
import org.json.JSONArray;
import org.json.JSONObject;

import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;

public class MainButJSON {

    public static void main(String[] args) throws IOException {

        System.out.println("Hello World!");

        JSONObject hi = getJsonObject("data.csv");

        //System.out.println(hi.toString());

        CountryCode cc = CountryCode.getByAlpha3Code("ALB");

        System.out.println(cc.getName());

        //System.out.println();

        whenWriteStringUsingBufferedWritter_thenCorrect("newJSON.txt", hi.toString());

    }


    private static JSONObject getJsonObject(String filepath) {

        JSONArray countries = new JSONArray();

        FileParser fp = new FileParser();
        ArrayList<ArrayList<String>> file = fp.getFile(filepath);

        for (ArrayList<String> line : file) {

            addToJSON(countries, line);


        }

        JSONObject result = new JSONObject();

        result.put("country", countries);

        return result;

    }

    private static JSONArray addToJSON(JSONArray countries, ArrayList<String> line) {

        if(line.get(0).equals("code")) {
            return null;
        }

        String country = line.get(0);
        String year = line.get(1);
        String data = line.get(2);
        String type = translateType(line.get(3));

        boolean countryExists = false;
        int countryIndex = -1;

        for (int i = 0 ; i < countries.length() ; i++) {
            if(countries.getJSONObject(i).get("country-code").equals(country)) {
                countryExists = true;
                countryIndex = i;
                break;
            }
        }

        if(!countryExists) {
            JSONObject newCountry = new JSONObject();
            newCountry.put("country-code", country);
            if(country.equals("CHI")) {                     //The library I imported doesn't seem to recognise Chile?
                newCountry.put("name", "Chile");
            } else {
                newCountry.put("name", CountryCode.getByAlpha3Code(country).getName());
            }

            JSONObject yearObject = new JSONObject();

            yearObject.put("year", year);

            JSONObject information = new JSONObject();
            information.put(type, data);

            yearObject.put("information", information);

            JSONArray yearsArray = new JSONArray();
            yearsArray.put(yearObject);

            newCountry.put("years", yearsArray);

            countries.put(newCountry);

            return countries;
        }

        JSONObject countryGotten = countries.getJSONObject(countryIndex);       //Get the country.


        JSONArray years = countryGotten.getJSONArray("years");              //Get the list of years.

        boolean yearExists = false;                                             //Assume year does not exist.
        int yearIndex = -1;

        for (int i = 0 ; i < years.length() ; i++) {
            if(years.getJSONObject(i).get("year") == year) {
                yearExists = true;
                yearIndex = i;
                break;
            }
        }

        if(!yearExists) {

            JSONObject newYear = new JSONObject();
            newYear.put("year", year);

            JSONObject information = new JSONObject();
            information.put(type, data);

            newYear.put("information", information);

            countryGotten.getJSONArray("years").put(newYear);

            return countries;

        }

        //if the country exists, but that year already has data points.

        JSONObject gottenYear = years.getJSONObject(yearIndex);

        JSONObject information = gottenYear.getJSONObject("information");

        information.put(type, data);

        return countries;

    }

    private static String translateType(String input) {

        return switch (input) {
            case "CME_MRY0T4: Under-five mortality rate" -> "mortality";
            case "DM_LIFE_EXP: Life expectancy" -> "life_expectancy";
            case "DM_POP_TOT: Total population" -> "population";
            case "ECON_GVT_EDU_EXP_PTGDP: government expenditure on education (% GDP)" -> "education_spending";
            case "ECON_GVT_HLTH_EXP_PTGDP: government expenditure on health (% GDP)" -> "health_spending";
            case "ED_15-24_LR: Youth literacy rate for 15-24 years" -> "youth_literacy";
            case "ED_CR_L1: Completion rate for children of primary school age" -> "primary_school_rate";
            case "ED_CR_L2: Completion rate for adolescents of lower secondary school age" -> "secondary_school_rate";
            case "\"NT_SANT_10_19_BAZ_NE2_MOD: Prevalence of thinness among children aged 10-19 years" -> "thinness";
            case "SPP_GDPPC: GDP per capita (current US$)" -> "gdp";
            default -> null;
        };

    }

    public static void whenWriteStringUsingBufferedWritter_thenCorrect(String fileName, String text)
            throws IOException {
        BufferedWriter writer = new BufferedWriter(new FileWriter(fileName));
        writer.write(text);

        writer.close();
    }


}
