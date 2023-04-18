package src;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {

        System.out.println("Hello World!");

        connectMySQL("SELECT * FROM country");

    }

    static private void connectMySQL(String statement) {

        try{
            Class.forName("com.mysql.cj.jdbc.Driver");
            Connection con = DriverManager.getConnection("jdbc:mysql://127.0.0.1:3306/world","root", "password");
            Statement stmt = con.createStatement();
            ResultSet result = stmt.executeQuery(statement);

            System.out.println("Hello");

        } catch (Exception e) {
            System.out.println(e);
        }

    }


}
