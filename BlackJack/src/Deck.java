
import java.util.*;
/**
 *
 * @author YASHU
 */
public class Deck 
{
  private final  LinkedList<Card> cardDeck;   
  private int numberOfCards; 
  
  public Deck()
  {
      //creates the linked list array to hold the cards
      cardDeck = new LinkedList<>();
      numberOfCards = 0;
      int m,n;
     
      //adds cards with the respective suit and face values to the linked list
      for(m = 0; m < 4; m++)      
         for(n = 1; n <= 13; n++)
         {
               this.cardDeck.add(new Card(n,m));
         }
       //incrementing cards  
        numberOfCards++ ;                         
  }
  
  public Card draw()
  {
      //each time this is called the card gets popped
      return cardDeck.pop();
      
  } 
  
  public void shuffle()
  {
      //inbuilt linked list function to shuffle cards
      Collections.shuffle(this.cardDeck);
  }
  
  public int getCardsCount()
  {      
      return numberOfCards;     
  } 
  
}