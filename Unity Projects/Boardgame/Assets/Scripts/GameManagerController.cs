using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManagerController : MonoBehaviour {
    public Sprite[] sprites;
    public CardController[] cards;
    public int cardsUp = 0;
    private int card1Index;
    private int card2Index;


    void Start() {

        int[]random = RandomSpriteIndex();

        for(int i = 0; i < cards.Length; i++) {
            cards[i].front = sprites[random[i]];
            cards[i].spriteIndex = random[i];
        }
    }
    
    void Update() {
        
        if (cardsUp == 2) {
            if (CardsAreEqual()) {
                cardsUp = 0;
                Invoke("DestroyEqualCards", 0.6f);
            } else {
                Invoke("FlipBack", 0.6f);
            }
        }
        
    }

    private void FlipBack() {
        foreach (CardController card in cards) {
            //If the spriteRenderer has not been destroyed then it flips the card
            if(card.spriteRenderer != null)
                card.ShowBack();
        }
        cardsUp = 0;
    }

    private bool CardsAreEqual() {
        int[] indexesToCompare = new int[2];
        int counter = 0;

        //If 2 cards are up we find those cards indexes and store them
        for (int i = 0; i < cards.Length; i++) {
            if(cards[i] != null) {
                if (cards[i].isShowingFront == true) {
                    indexesToCompare[counter] = i;
                    counter++;
                }
            }
        }
        card1Index = indexesToCompare[0];
        card2Index = indexesToCompare[1];
        //If the cards in the previous obtained indexes have the same spriteIndex identifier we destroy them
        if (cards[card1Index].spriteIndex == cards[card2Index].spriteIndex) {
            return true;
        }
        return false;
    }

    private void DestroyEqualCards() {
        //We only destroy the spriteRenderer, however the cards GameObject still exists, we need to set 
        //their boolean properties as if it was showing it's back in order to avoid counting them as if they were up
        cards[card1Index].isShowingFront = false;
        cards[card2Index].isShowingFront = false;
        Destroy(cards[card1Index].spriteRenderer);
        Destroy(cards[card2Index].spriteRenderer);
    }
    private int[] RandomSpriteIndex() {
        int[] random = new int[sprites.Length * 2];
        int[] spriteIndexes = new int[sprites.Length * 2];

        int spriteIdx = 0;
        int i = 0;

        while (spriteIdx < sprites.Length) {
            spriteIndexes[i] = spriteIdx;
            spriteIndexes[i + 1] = spriteIdx;

            i += 2;
            spriteIdx++;
        }
        //-1 represents an empty space in the array instead of 0 since we will be storing indexes
        for (i = 0; i < random.Length; i++) {
            random[i] = -1;
        }
        for (i = 0; i < spriteIndexes.Length; i++) {
            int randIndex = UnityEngine.Random.Range(0, random.Length);

            while (random[randIndex] != -1)
                randIndex = UnityEngine.Random.Range(0, random.Length);

            random[randIndex] = spriteIndexes[i];
        }

        return random;
    }
}
