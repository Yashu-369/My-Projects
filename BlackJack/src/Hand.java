
import java.util.LinkedList;
/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author YASHU
 */
public class Hand 
{   //to create hidden cards the dealer has this class is used
    private LinkedList<Card> hand = new LinkedList<>();
    private int handValue=0;
    private int count=0;
      
    //each time the dealer takes a card,it is not shown to us but it gets stored in this linked list.
    public void addCardToHand(Card c)
    {
        this.hand.add(c);
        
        handValue += c.getValue();
        count++;
        
    }
    
    //get the latest card that is added to the list. Each time we get the latest card that goes into the list.
    public Card lastCard()
    {
        return hand.getLast();
    }
    
    //to return the current value of the card, where it is being pointed to.
    public int getHandValue()
    {
        return handValue;
    }
    
    //as the total number of cards in the list gets increased, the count of this is increased and it takes the 
    //cards until the stand is clicked. 
    public int getNumberOfCards()
    {
        return count;
        
    }
    
}
