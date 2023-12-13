using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript_C : MonoBehaviour //we extend the MonoBehaviour class (class to manage game objects)
                                                  //with the class GameControllerScript
{
    //define the number of col and rows
    public const int columns = 8;
    public const int rows = 5;
    //define the interspace between the cards
    public const float Xspace = 2f;
    public const float Yspace = -2f;

    [SerializeField] private Main_C startObject; //reference for the 1st card-->we will link to this variable the star sprite.
                                               //We notice also that
    [SerializeField] private Sprite[] images; //reference for the images to be used on the cards
    [SerializeField] public GameObject win;
    [SerializeField] public GameObject lose;
    [SerializeField] private TextMesh Win_text;
    [SerializeField] private GameObject lose_text;
    [SerializeField] private GameObject restart_button;
    [SerializeField] private GameObject SkyPia_button;









    //Randomiser function
    private int[] Randomiser(int[] locations) //N.B. that this function wants in input an array
    {
        int[] array = locations.Clone() as int[]; //we copy the input array into an array of integers
        for (int i = 0; i < array.Length; i++)
        {
            //we randomly change the positions of the array's elements in the
            //array (in order to change the cards' order everytime we restart the game)
            int newArray = array[i];
            int j = Random.Range(i, array.Length);
            array[i] = array[j];
            array[j] = newArray;
        }
        return array;
    }







    //this below is the unique function that this script calls. It calls it when we run the scene
    private void Start()
    {
        SkyPia_button.SetActive(false);
        win.SetActive(false);
        lose.SetActive(false);
        lose_text.SetActive(false);
        string path = Application.dataPath + "/save.txt";
        if (File.Exists(path))
        {
            keys = int.Parse(File.ReadAllText(path));
        }
        else
        {
            keys = 0;
        }
        int[] locations = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11, 12, 12, 13, 13, 14, 14, 15, 15, 16, 16, 17, 17, 18, 18, 19, 19 };
        locations = Randomiser(locations); //we randomize the locations vector's elements

        Vector3 startPosition = startObject.transform.position; //get the position of the star card that i put on the scene

        //this code's part creates as many cards as specified in the rows and columns sizes and randomizes the cards in the scenario
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                Main_C gameImage; //gameImage is variable that we will put equal to startObject and so to the star card.  It is a Main variable because 
                                //we will use a function "ChangeSprite" that is enounced in Main
                if (i == 0 && j == 0) //if it is the 1st card
                {
                    gameImage = startObject; //as first card we put the start object
                }
                else
                {
                    gameImage = Instantiate(startObject) as Main_C; //the next object is created equal to the 1st card
                }
                int index = j * columns + i;
                int id = locations[index];
                gameImage.ChangeSprite(id, images[id]); //we randomly change the sprite (card)

                float positionX = (Xspace * i) + startPosition.x;
                float positionY = (Yspace * j) + startPosition.y;

                gameImage.transform.position = new Vector3(positionX, positionY, startPosition.z); //we put the card in its assigned position
            }
        }

    }







    //We initialize some variables that we will use in the functions below

    //If we wrote Main firstOpen it would have been a public variable and so visible also by other scripts
    private Main_C firstOpen;
    private Main_C secondOpen;
    public int keys;
    //firstOpen and secondOpen initialized are like set == null

    public int score = 0;
    private int attempts = 0;

    [SerializeField] private TextMesh scoreText;
    [SerializeField] private TextMesh attemptsText;

    public bool canOpen //public so can be seen also by Main script
    {
        get { return secondOpen == null; } //canOpen is true if secondOpen==null (so if there are no 2 cards yet opened)
    }








    //this function (imageOpened), that contains CheckGuessed, is evoked here but called in Main
    public void imageOpened(Main_C startObject) //this function is called in the main function when the user open a card
    {
        if (firstOpen == null) { firstOpen = startObject; } //if there are no cards yet opened, the opened card is the card we are opening now
        else { secondOpen = startObject; StartCoroutine(CheckGuessed()); } //if yet a card was opened then the card we are opening now is the 2nd one.
                                                                           //Moreover compare the 2 opened images, if the image we are opening is the second
    }
    private IEnumerator CheckGuessed()  //i write the function like this (IEnumerator) to use it as a Coroutine
    {
        if (firstOpen.spriteId == secondOpen.spriteId) //Compares the 2 objects 
        {
            score++; // add score
            scoreText.text = "Score: " + score;
            if (score == 20)
            {
                if (attempts <= 60)
                {
                    restart_button.SetActive(false);
                    SkyPia_button.SetActive(true);
                    win.SetActive(true);

                    keys++;
                    //string json = JsonUtility.ToJson(keys.ToString());
                    string path = Application.dataPath + "/save.txt";
                    File.WriteAllText(path, keys.ToString());
                    if (keys == 1)
                    {
                        Win_text.text = "You have unlocked a memory! Let's look for it!";
                    }
                    yield return new WaitForSeconds(5f);
                    win.SetActive(false);
                    Win_text.text = "";
                }
                else
                {
                    lose.SetActive(true);
                    //lose_text.SetActive(true);
                    yield return new WaitForSeconds(8f);
                    lose.SetActive(false);
                    //lose_text.SetActive (false);
                }

            }
        }
        else
        {
            yield return new WaitForSeconds(0.5f); // start timer

            firstOpen.Close();
            secondOpen.Close();
        }
        attempts++;
        attemptsText.text = "Attempts: " + attempts;

        firstOpen = null;
        secondOpen = null;
    }






    //this function is called in ButtonScript
    public void Restart()
    {
        SceneManager.LoadScene("memory_game c");
    }
}



//Notice that a variable must be seen by the script where the variable is used in an function that we are evoking. It is not required 
//that the variable can be seen in a script where the function is only called. Remember that a private variable can be seen only in its
//script, instead a public variable in all the scripts
