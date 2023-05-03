package dreamteam.json;

import java.io.File;  // Import the File class
import java.io.FileNotFoundException;  // Import this class to handle errors
import java.net.URL;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner; // Import the Scanner class to read text files

public class FileParser {
    public ArrayList<ArrayList<String>> getFile(String filepath) {
        try {
            URL url = getClass().getClassLoader().getResource("GDPPerCapita.csv");
            File myObj = new File(url.getPath());
            Scanner myReader = new Scanner(myObj);
            ArrayList<ArrayList<String>> rows = new ArrayList<>();
            while (myReader.hasNextLine()) {
                String row = myReader.nextLine();
                String[] rowElements= row.split(",");
                ArrayList<String> rowElements2 = new ArrayList<>(Arrays.asList(rowElements));
                rows.add(rowElements2);
            }

            myReader.close();
            return rows;

        } catch (FileNotFoundException e) {
            System.out.println("An error occurred.");
            e.printStackTrace();
            return null;
        }
    }
}
