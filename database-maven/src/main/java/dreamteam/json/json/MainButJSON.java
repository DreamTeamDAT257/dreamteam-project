package dreamteam.json.json;

import dreamteam.json.FileParser;
import org.json.JSONArray;
import org.json.JSONObject;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;
import java.util.ArrayList;

public class MainButJSON {

    public static void main(String[] args) {

        System.out.println("Hello World!");

        JSONArray hi = getJsonArray("data.csv");



        //System.out.println(jsonObject.toString());

    }


    private static JSONArray getJsonArray(String filepath) {

        JSONArray countries = new JSONArray();

        FileParser fp = new FileParser();
        ArrayList<ArrayList<String>> file = fp.getFile(filepath);

        for (ArrayList<String> line : file) {

            addToJSON(countries, line);


        }
    return null;
    }

    private static JSONArray addToJSON(JSONArray countries, ArrayList<String> line) {

        findOrCreateCountry(countries, "USA");

        String country = line.get(0);
        String year = line.get(1);
        String data = line.get(2);
        String type = translateType(line.get(3));

        //if(countries.)

        System.out.println("hi");
        return null;
    }

    private static int findOrCreateCountry(JSONArray countries, String country) {

        JSONObject countryObject = new JSONObject();
        countryObject.append("country_code", country);

        /*for(int i = 0 ; i <= countries.length() ; i++) {
            if(countries.get(i).equals())
        }*/
        return -1;
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
            case "NT_SANT_10_19_BAZ_NE2_MOD: Prevalence of thinness among children aged 10-19 years, BMI < -2 standard deviations below the median (Crude estimate)" -> "thinness";
            case "SPP_GDPPC: GDP per capita (current US$)" -> "gdp";
            default -> null;
        };

    }

    private static void importGDP(ArrayList<ArrayList<String>> input) {

        //JSONObject jsonObject = new JSONObject;

        /*

        ArrayList<String> rowStatements = new ArrayList<>();

        String countryCode;
        String output;
        ArrayList<String> years = input.get(0);
        int start;

        for (ArrayList<String> row : input) {
            if(row.get(3).contains("\"")){
                countryCode = row.get(4);
                output = countryCode + "',";
                start = 5;
            }
            else{
                countryCode = row.get(3);
                output = countryCode + "',";
                start = 4;
            }

            for(int i = start ; i < row.size() - 1 && years.get(i) != row.get(i) ; i++) {

                output = preamble + countryCode + "', ";
                String checker = row.get(i);

                if(checker.equals("..")) {
                    output += "NULL";
                } else {
                    double GDP = Double.parseDouble(checker);
                    DecimalFormat df = new DecimalFormat("#.##");
                    output += df.format(GDP);
                }

                output += ",";
                output += years.get(i);
                output += ");";
                output += "\n";

                rowStatements.add(output);
            }
        }
        System.out.println(rowStatements);

         */
    }
}
