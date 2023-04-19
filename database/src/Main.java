package src;

import java.sql.*;
import java.util.ArrayList;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {

        System.out.println("Hello World!");

        connectMySQL("SELECT * FROM country");

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

            System.out.println("Hello");

        } catch (Exception e) {
            System.out.println(e);
        }

    }


}
