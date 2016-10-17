using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cards : MonoBehaviour {

    // Train card draw pile
    public static Deck<ResourceCard> resourceDeck = new Deck<ResourceCard>();

    // Route card pile
    public static Deck<RouteCard> routeDeck = new Deck<RouteCard>(); 

    // River
    public static ResourceCard[] river = new ResourceCard[5];

    // Always use TakeFromRiver() to take a card from the river. Don't directly reference Cards.river[someNumber].
    public static ResourceCard TakeFromRiver(int desiredCardIndex, bool canDrawLocomotive)
    {
        // Ensure the card you want exists
        ResourceCard desiredCard = river[desiredCardIndex];
        if (desiredCard == null)
        {
            Debug.LogWarning("You can't take \"nothing\" from a blank river slot");
            return null;
        }
        // You can restrict the player from taking locomotives
        if (desiredCard.color == ResourceColor.Wild && !canDrawLocomotive)
        {
            Debug.Log("The player can't take this locomotive");
            return null;
        }
        // Take the card out of the river
        river[desiredCardIndex] = null;

        // Replenish the river if possible
        river[desiredCardIndex] = resourceDeck.Draw();

        return desiredCard;
    }

    public static string StringRiver()
    {
        System.Text.StringBuilder stringbuilder = new System.Text.StringBuilder("River:");
        foreach (ResourceCard riverCard in river)
            stringbuilder.Append(riverCard.ToString());
        return stringbuilder.ToString();
    }

	void Start () {

        // Add 12 of each card to the deck
        resourceDeck.Add(ResourceCard.CreateSeveralResourceCards(12, ResourceColor.Black));
        resourceDeck.Add(ResourceCard.CreateSeveralResourceCards(12, ResourceColor.Blue));
        resourceDeck.Add(ResourceCard.CreateSeveralResourceCards(12, ResourceColor.Green));
        resourceDeck.Add(ResourceCard.CreateSeveralResourceCards(12, ResourceColor.Orange));
        resourceDeck.Add(ResourceCard.CreateSeveralResourceCards(12, ResourceColor.Pink));
        resourceDeck.Add(ResourceCard.CreateSeveralResourceCards(12, ResourceColor.Red));
        resourceDeck.Add(ResourceCard.CreateSeveralResourceCards(12, ResourceColor.White));
        resourceDeck.Add(ResourceCard.CreateSeveralResourceCards(12, ResourceColor.Yellow));

        // 14 wild cards
        resourceDeck.Add(ResourceCard.CreateSeveralResourceCards(14, ResourceColor.Wild));

        // Shuffle Train cards***************
        resourceDeck.Shuffle();
        Debug.Log("Resource deck:" + resourceDeck.ToString());

        // Draws River***********************
        for (int i = 0; i < river.Length; i++)
            river[i] = resourceDeck.Draw();
        Debug.Log(StringRiver());

        // Creates the Route Deck 
        // Need to implement this 
    }
}

// May not end up using this class
public class Card
{
    public Texture2D frontImage;
    public Texture2D backImage;
}

public enum ResourceColor { Wild, Red, Green, Blue, Orange, Yellow, Pink, White, Black }
public class ResourceCard : Card
{
    public ResourceColor color;
    // Constructor
    public ResourceCard(ResourceColor initColor)
    {
        color = initColor;
    }

    public static List<ResourceCard> CreateSeveralResourceCards(int count, ResourceColor color)
    {
        List<ResourceCard> bunchOfCards = new List<ResourceCard>();
        for (int i = 0; i < count; i++)
            bunchOfCards.Add(new ResourceCard(color));
        return bunchOfCards;
    }

    public override string ToString()
    {
        // (Red)
        return "(" + color.ToString() + ")";
    }

}

public class RouteCard : Card
{
    public int city1;
    public int city2;
    public int value;

    // Constructor
    public RouteCard(int _city1, int _city2, int _value)
    {
        city1 = _city1;
        city2 = _city2;
        value = _value;
    }

    public override string ToString()
    {
        // (city1 <-> city2 [9])
        return "(" + city1 + " <-> " + city2 + " [" + value + "])";
    }
}

public class Deck<T>
{
    List<T> stack = new List<T>();

    public void Add(T thing)
    {
        stack.Add(thing);
    }

    public void Add(List<T> things)
    {
        foreach (T thing in things)
            stack.Add(thing);
    }

    public void Shuffle()
    {
        List<T> randomStack = new List<T>();
        while (stack.Count > 0)
        {
            T randomElement = stack[Random.Range(0, stack.Count)];
            randomStack.Add(randomElement);
            stack.Remove(randomElement);
        }
        stack = randomStack;

    }

    // Removes and returns a card
    public T Draw()
    {
        // If there are no cards, replenish the deck from the discard pile
        if (IsEmpty())
            Replenish();

        // If it's still empty, we are out of cards
        if (IsEmpty())
        {
            Debug.LogWarning("The deck is empty");
            return default(T);
        }
        T drawnThing = stack[0];
        stack.Remove(drawnThing);
        return drawnThing;
    }

    // Removes and returns a bunch of cards at one time
    public List<T> Draw(int numtoDraw)
    {
        List<T> drawnSet = new List<T>();
        for (int i = 0; i < numtoDraw; i++)
            drawnSet.Add(Draw());
        return drawnSet;
    }

    public bool IsEmpty()
    {
        return stack.Count < 1;
    }

    public override string ToString()
    {
        System.Text.StringBuilder stringbuilder = new System.Text.StringBuilder();
        foreach (T thing in stack)
            stringbuilder.Append(thing.ToString());
        return stringbuilder.ToString();
    }

    List<T> discardPile = new List<T>();
    public void Discard(T toDiscard)
    {
        if (stack.Contains(toDiscard))
            stack.Remove(toDiscard);
        discardPile.Add(toDiscard);
    }

    public void Replenish()
    {
        while (discardPile.Count > 0)
        {
            T toMove = discardPile[0];
            stack.Add(toMove);
            discardPile.Remove(toMove);
        }
        Shuffle();
    }
}

// Class is used to represent a players hand
// T will either be type ResourceCard or RouteCard
// Will be initialized for each player in PlayerList and managed there
public class Hand<T>
{
    List<T> stack = new List<T>();

    // Add a card to the hand
    public void Add(T thing)
    {
        stack.Add(thing);
    }

    // Add a list of cards to the hand 
    public void Add(List<T> things)
    {
        foreach (T thing in things)
            stack.Add(thing);
    }

    // Will remove the card from the players hand
    // Will need to also add this to the card discarded pile
    //      Do not need to check type here as only resource cards will ever be "removed" from a players hand
    public void RemoveCard(T toRemove)
    {
        // Need to implement Removal of Cards
        
    }
}