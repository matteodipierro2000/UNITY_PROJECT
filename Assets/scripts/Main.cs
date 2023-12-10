using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//code for the 1st card in the memory matching game: this code is used in the principle one (the GameControllerScript).
public class Main : MonoBehaviour
{
    [SerializeField] private GameObject question_mark; //reference for the question mark card
    [SerializeField] private GameControllerScript gameController; //reference for the GameControllerScript istance that controls the game logic

    public void OnMouseDown()
    {
        if (question_mark.activeSelf && gameController.canOpen) //if the card is face down and there are no 2 cards yet opened
        {
            question_mark.SetActive(false);  //open the card (remove the question mark over the card)
            gameController.imageOpened(this); //tell the gameController the card we push is opened
        }
    }


    private int _spriteId; 

    //When we will acess to the spriteId variable in the (last script's rows of) GameController script, thanks to the fact that is public, we will retrieve 
    // the _spriteId variable that it will have been updated with the image's id in the start method in the GameController script.
    public int spriteId 
    {
        get { return _spriteId; } 

    }






    //initialize some functions that will be called in the GameControllerScript
    public void ChangeSprite(int id, Sprite image) //method to change the sprite(image) on the card
    {
        _spriteId = id; //we update the variable _spriteId with the given id to change the sprite (image) on the card
        GetComponent<SpriteRenderer>().sprite = image; //get the SpriteRenderer component to change the sprite shown on the card
    }

public void Close() //this function is called in the GameController script's imageOpened function. This imageOpened function is called in this 
                    //Main script
    {
        question_mark.SetActive(true); //hide the card
    }
}