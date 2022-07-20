using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private Button button;
    private Playercontroller playerController;
    

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<Playercontroller>();
        button = GetComponent<Button>();
        button.onClick.AddListener(StartTheGame);
    }

    /* When a button is clicked, call the StartGame() method
     * and pass it the difficulty value (1, 2, 3) from the button 
    */
    void StartTheGame()
    {
        Debug.Log(button.gameObject.name + " was clicked");
        playerController.StartGame();
    }



}
