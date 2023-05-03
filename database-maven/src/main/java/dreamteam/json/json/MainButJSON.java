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
        //connectMySQL("SELECT * FROM country");

        JSONArray hi = getJsonArray();

        JSONObject jsonObject = new JSONObject();
        jsonObject.append("country", "hi");

        System.out.println(jsonObject.toString());

        //importGDP(file);
    }


    private static JSONArray getJsonArray() {

        FileParser fp = new FileParser();
        ArrayList<ArrayList<String>> file = fp.getFile("data.csv");

        for (ArrayList<String> line : file) {

            System.out.println("hi");

        }
    return null;
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
