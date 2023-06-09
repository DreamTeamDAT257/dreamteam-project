package dreamteam.json;

import org.json.JSONArray;
import org.json.JSONObject;

import java.sql.*;
import java.text.DecimalFormat;
import java.util.ArrayList;

public class Main {

    public static void main(String[] args) {

        System.out.println("Hello World!");
        //connectMySQL("SELECT * FROM country");
       // ArrayList<ArrayList<String>> file = FileParser.getFile("../data/GDPPerCapita.csv");
       // importGDP(file);
    }

    static private void connectMySQL(String statement) {

        try{
            Class.forName("com.mysql.cj.jdbc.Driver");
            Connection con = DriverManager.getConnection("jdbc:mysql://127.0.0.1:3306/world","root", ")(nETjhnklb6inF");
            Statement stmt = con.createStatement();
            ResultSet result = stmt.executeQuery(statement);

            while(result.next()) {
                System.out.println(result.getString(2));
            }

        } catch (Exception e) {
            System.out.println(e);
        }
    }

    private static void importGDP(ArrayList<ArrayList<String>> input) {

        String preamble = "INSERT INTO GDPPerCapita (countryCode, GDPPC, year) VALUES ('";

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
    }
}
