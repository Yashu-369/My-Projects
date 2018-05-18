/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */


/**
 *
 * @author YASHU
 */
public class Card 
{
    //initialized the spades, hearts, diamonds, clubs
     public final static int SPADES = 0;     
     public final static int DIAMONDS = 1;
     public final static int HEARTS = 2;
     public final static int CLUBS = 3;
           
     //intialized the face card values
     public final static int ACE = 1, JACK = 10, QUEEN = 10,KING = 10; 
     
     //values initialized to select suit and value 
     private  int value;  
     private  int suit;                           
                        
                             
    public Card(int theValue, int theSuit) 
    {      
        //as soon as the card object is created the value and suit are assigned with passed parameters
        this.value = theValue;
        this.suit = theSuit;
    }
    
    public int getValue() 
    {        
        //returns the card value, including the face value
        return value;
    }
    
    public int getSuit() 
    {           
        //returns the face value of suit 
        return suit;
    }
    
    public String getValue1() 
    {
        //used to locate the string to image folder      
        switch ( this.value ) 
        {
           case 1:   return "Ace";
           case 2:   return "2";
           case 3:   return "3";
           case 4:   return "4";
           case 5:   return "5";
           case 6:   return "6";
           case 7:   return "7";
           case 8:   return "8";
           case 9:   return "9";
           case 10:  return "10";
           case 11:  return "Jack";
           case 12:  return "Queen";
           case 13:  return "King";
           default:  return "value not valid";
        }
    }
    
    public String getSuit1() 
    {    
        //used to locate the string to card value in the image folder
        switch ( this.suit ) 
        {
           case SPADES:   return "Spades";
           case HEARTS:   return "Hearts";
           case DIAMONDS: return "Diamonds";
           case CLUBS:    return "Clubs";
           default:       return "Invalid Suit Code";
        }
    }
    
    public String toString() 
    {     
        //returns the complete path of the image as a single string 
        return getValue1() + " of " + getSuit1();
    }

}