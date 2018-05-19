/*
 * This sample shows how to insert into the WIU_Faculty table, and then
 * display all of its rows.
 *
 * This program was originally adapted from one of the samples supplied
 * with Oracle; however, it has been substantially rewritten.
 *
 * Author: Martin Maskarinec
 *
 */
// You need to import the java.sql package to use JDBC
import java.sql.*;
import java.io.*;

class project {

    static BufferedReader keyboard; // Needed for keyboard I/O.
    static Connection conn; // A connection to the DB must be established
    // before requests can be handled.  You should
    // have only one connection.
    static Statement stmt; // Requests are sent via Statements.  You need
    // one statement for every request you have
    // open at the same time.




    // "main" is where the connection to the database is made, and
    // where I/O is presented to allow the user to direct requests to
    // the methods that actually do the work.

    public static void main(String args[])
    throws IOException, SQLException {
        String username = "ym104", password = "gx63mQTy";


        keyboard = new BufferedReader(new InputStreamReader(System.in));

        try { //Errors will throw a "SQLException" (caught below)

            // Load the Oracle JDBC driver
            DriverManager.registerDriver(new oracle.jdbc.driver.OracleDriver());

            System.out.println("Registered the driver...");

            // Connect to the database.  The first argument is the
            // connection string, the second is your username, the third is
            // your password. 
            conn = DriverManager.getConnection(
                "jdbc:oracle:thin:@oracle1.wiu.edu:1521/toolman.wiu.edu",
                username, password);

            conn.setAutoCommit(false);

            System.out.println("logged into oracle as " + username);

            // Create a Statement; again, you may have/need more than one.
            stmt = conn.createStatement();
                Q1();
                q2();
                q3();
               q4();
                q5();
               q6();
              q7();
               q8();
            q9();
            q10();
            q11();
            //	ResultSet rset=stmt.executeQuery ("select TNAME from TAB");
            UserInputMethod();
        } catch (SQLException e) {
            System.out.println("Caught SQL Exception: \n     " + e);
        }
    }

public static void UserInputMethod() throws IOException, SQLException {
        System.out.println();
        System.out.println("----------------------------------------------------");
        System.out.println("Enter 1 for database");
        System.out.println("Enter 2 to exit");
        System.out.println("enter your input");
        keyboard = new BufferedReader(new InputStreamReader(System.in));
        int choice = Integer.parseInt(keyboard.readLine());
        switch (choice) { //switch case
            case 1:
                System.out.println("connected to database......");
                database();
                break;
            case 2:
                System.exit(0);
            default:
                break;
        } 
    } 

      public static void database() throws IOException, SQLException {
        int choice = 0;
        while (choice < 12) {
            System.out.println("\n ********************************* MENU **************************************** \n"); //menu section
            System.out.println("\n1.promts the user for player id,age and country name:"); //prompting user to enter player name
            System.out.println("2.Displays the sport id  and sport type of the player"); //displays the sport id and sport type 
            System.out.println("3.Displays the details about the player id,age and name represented like group"); //details about the group of the player
            System.out.println("4.Displays the player name,country name,sport name and tournament name"); //details about player,sport and country 
            System.out.println("5.Displays stadium name and city"); //Display values from stadium table
            System.out.println("6.Displays the player id and age"); //Displays the player age and id
            System.out.println("7.display sport name and sport type");// this Displays sport type and the sport name
            System.out.println("8.Displays the tournament name and the number of teams based on sport type"); //display tournament name and sport type
            System.out.println("9.Inserts and Displays the stadium id,city,name and the sport id"); //displays the stadium details
            System.out.println("10.Update the stadium id,city and sport id");// updates the stadium details with their sport id
            System.out.println("11.Delete the stadium id,city and sport id"); // deletes the given row in the stadium details
            System.out.println("12.EXIT"); //exits 

            System.out.print("Enter Your Choice:");
            choice = Integer.parseInt(keyboard.readLine());
            while (choice > 13 || choice < 0) {
                System.out.println("\n WRONG Choice. TRY AGAIN\n");
                System.out.print("Enter Your Choice:");
                choice = Integer.parseInt(keyboard.readLine());
            }

            switch (choice) {
                case 1:
                    Q1(); //calling q1 method
                    UserInputMethod();
                    break;

                case 2:
                    q2(); //calling q2 method
                    UserInputMethod();
                    break;
                case 3:
                    q3(); //calling query3 method
                    UserInputMethod();
                    break;

                case 4:
                    q4(); //calling query4 method
                    UserInputMethod();
                    break;
                case 5:
                    q5(); //calling query5 method
                    UserInputMethod();
                    break;
                case 6:
                    q6(); //calling query6 method
                    UserInputMethod();
                    break;
                case 7:
                    q7();//calling query7 method
                    UserInputMethod();
                    break;
                case 8:
                	q8();//calling query 8method
                    UserInputMethod();
                    break;
                case 9:
                    q9(); //calling query9 method
                    UserInputMethod();
                    break;
                case 10:
                    q10();//calling query10 method
                    UserInputMethod();
                    break;
                case 11:
                	q11();//calling query11 method
                    UserInputMethod();
                    break;
                default:
                    break;
            }
        }
    } 
    public static void Q1() throws IOException, SQLException //creating method query1
        {
            System.out.println("enter playername: ");
            String Playername = keyboard.readLine();
            System.out.println("P_id \t P_age \t c_name ");

            //Q1
            String input1 = "select player.p_id,p_age,c_name from player,country where p_name='JULY' and player.p_id=country.p_id";


            ResultSet rset = stmt.executeQuery(input1);
            ResultSetMetaData rsmd = rset.getMetaData();
            int colcount = rsmd.getColumnCount();

            while (rset.next()) {
                for (int i = 1; i <= colcount; i++) {

                    System.out.println(rset.getString(i) + " \t" + "\n");
                    // System.out.print();
                }
            }
            rset.close();
        }

     public static void q2() throws SQLException //CREATING METHOD QUERY2
        {
            System.out.print("st_id     st_type \t ");
            System.out.println();

            //Q2
            String simple = "select st_id,st_type from sport_iot where st_id>222";
            ResultSet rset = stmt.executeQuery(simple);
            ResultSetMetaData rsmd = rset.getMetaData();
            int colcount = rsmd.getColumnCount();

            while (rset.next()) {
                for (int i = 1; i <= colcount; i++) {

                    System.out.print(rset.getString(i) + " \t");

                }
                System.out.println();
            }
            rset.close();
        }
     
     public static void q3() throws SQLException //CREATING METHOD QUERY3
        {
            System.out.println("p_name" + "\t" + "P_id" + "P_age" );

            //Q3
            String decode = " select p_name,p_id,p_age,DECODE(floor(p_age/10),0,'FRESHMAN',1,'FRESHMAN',2,'JUNIOR',3,'SENIOR',4,'SUPERSENIOR') from player";
            ResultSet res = stmt.executeQuery(decode); // statement to exeute query 
            while (res.next()) {
                if (Integer.parseInt(res.getString(3)) / 10 <= 1) {
                    System.out.println(" " + res.getString(1) + "\t  " + res.getString(2) + "\t" + res.getString(3) + "\t"  + "FRESHMAN ");
                }
                if (Integer.parseInt(res.getString(3)) / 10 == 2) {
                    System.out.println(" " + res.getString(1) + " \t  " + res.getString(2) + res.getString(3) + "\t"  + "JUNIOR ");
                }
                if (Integer.parseInt(res.getString(3)) / 10 == 3) {
                    System.out.println(" " + res.getString(1) + "\t  " + res.getString(2) + "\t" + res.getString(3) + "\t"  + "SENIOR");
                }
                if (Integer.parseInt(res.getString(3)) / 10 == 4) {
                    System.out.println(" " + res.getString(1) + "\t  " + res.getString(2) + "\t" + res.getString(3) + "\t"  + " SUPERSENIOR");
                }
           
            }
        }
 static void q4() throws SQLException //CREATING METHOD QUERY4
        {
            System.out.println("P_Name" + "\t" + "c_name" + "\t" + "st_name" + "\t" + "T_name");

            //Q4
            String join = "select p_name,c_name,st_name,t_name from player,country,sport_iot,tournament where player.p_id=country.p_id and player.p_id=sport_iot.p_id and sport_iot.st_id=tournament.st_id";
            ResultSet rset = stmt.executeQuery(join);
            ResultSetMetaData rsmd = rset.getMetaData();
            int colcount = rsmd.getColumnCount();

            while (rset.next()) {
                for (int i = 1; i <= colcount; i++) {

                    System.out.print(rset.getString(i) + " \t");

                }
                System.out.println();
            }
            rset.close();
        }

    public static void q5() throws IOException, SQLException //CREATING METHOD QUERY5
        {
            System.out.println("S_NAME" + "/t" + "city");
           
            //Q5
            String simple1 = "select s_name,city from stadium where s_id=101";
            ResultSet rset = stmt.executeQuery(simple1);
            ResultSetMetaData rsmd = rset.getMetaData();
            int colcount = rsmd.getColumnCount();

            while (rset.next()) {
                for (int i = 1; i <= colcount; i++) {

                    System.out.print(rset.getString(i) + " \t" + "\n");
                    // System.out.print();
                }
            }
            rset.close();
        }
    
    public static void q6() throws SQLException //CREATING METHOD QUERY6
        {
            System.out.println("P_NAME" + "\t" + "P_AGE");

            //Q6
            String simple2 = "select p_name,p_age from player,country where p_sex='F' and player.p_id=country.p_id";
            ResultSet rset = stmt.executeQuery(simple2);
            ResultSetMetaData rsmd = rset.getMetaData();
            int colcount = rsmd.getColumnCount();

            while (rset.next()) {
                for (int i = 1; i <= colcount; i++) {

                    System.out.print(rset.getString(i) + " \t");
                }
                System.out.println();

            }
            rset.close();
        }
    public static void q7() throws SQLException //CREATING METHOD QUERY6
    {
        System.out.println("st_name" + "\t" + "st_type");

        //Q7
        String join2 = " select st_name,st_type from sponsor join sport_iot on sponsor.sp_id=sport_iot.sp_id";
        ResultSet rset = stmt.executeQuery(join2);
        ResultSetMetaData rsmd = rset.getMetaData();
        int colcount = rsmd.getColumnCount();

        while (rset.next()) {
            for (int i = 1; i <= colcount; i++) {

                System.out.print(rset.getString(i) + " \t");
            }
            System.out.println();

        }
        rset.close();
    }

    public static void q8() throws SQLException //CREATING METHOD QUERY6
    {
        System.out.println("t_date" + "\t" + "# of Teams");

        //Q8
        String groupby= " select st_name,count(p_id) from sport_iot group by st_name";
        ResultSet rset = stmt.executeQuery(groupby);
        ResultSetMetaData rsmd = rset.getMetaData();
        int colcount = rsmd.getColumnCount();

        while (rset.next()) {
            for (int i = 1; i <= colcount; i++) {

                System.out.print(rset.getString(i) + " \t");
            }
            System.out.println();

        }
        rset.close();
    }



    static void q9() throws SQLException //CREATING METHOD QUERY7
        {
            System.out.println("S_ID" + "\t" + "S_NAME" + "\t" + "CITY" + "\t" + "ST_ID" + "\t" );

            //Q9
            String insert = " insert into stadium values(104,'DEF','TEXAS',111)";
            conn.commit();
            stmt.executeQuery(insert);
            String JAVA1 = "select * from STADIUM";
            ResultSet rset = stmt.executeQuery(JAVA1);
            ResultSetMetaData rsmd = rset.getMetaData();
            int colcount = rsmd.getColumnCount();
            while (rset.next()) {
                for (int i = 1; i <= colcount; i++)
                    System.out.print(rset.getString(i) + " \t");
                System.out.println();

            }
            rset.close();
        }
 
    public static void q10() throws SQLException //CREATING METHOD QUERY8
        {
            System.out.println("S_ID" + "\t" + "S_NAME" + "\t" + "CITY" + "\t" + "ST_ID" + "\t" );

            //Q10
            String update ="UPDATE STADIUM SET CITY='MICHIGAN'WHERE S_NAME='LB'";
            Statement is = conn.createStatement();
            is.executeUpdate(update);
            String JAVA2 = "select * from stadium";
            ResultSet rset = is.executeQuery(JAVA2);

            ResultSetMetaData rsmd = rset.getMetaData();
            int colcount = rsmd.getColumnCount();
            while (rset.next()) {
                for (int i = 1; i <= colcount; i++)
                    System.out.print(rset.getString(i) + " \t");
                System.out.print(rset.getString(1) + " \t" + "\n");
                System.out.println();

            }
            rset.close();
        }
    static void q11() throws SQLException //CREATING METHOD QUERY7
    {
        System.out.println("S_ID" + "\t" + "S_NAME" + "\t" + "CITY" + "\t" + "ST_ID" + "\t" );

        //Q11
        String delete =  "DELETE FROM STADIUM WHERE S_ID=104" ;
        conn.commit();
        stmt.executeQuery(delete);
        String JAVA3 = "select * from STADIUM";
        ResultSet rset = stmt.executeQuery(JAVA3);
        ResultSetMetaData rsmd = rset.getMetaData();
        int colcount = rsmd.getColumnCount();
        while (rset.next()) {
            for (int i = 1; i <= colcount; i++)
                System.out.print(rset.getString(i) + " \t");
            System.out.println();

        }
        rset.close();
    }
}   
   