using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    private Button button;
    private Playercontroller playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<Playercontroller>();
        button = GetComponent<Button>();
        button.onClick.AddListener(RestartTheGame);
    }

    // Update is called once per frame
    void RestartTheGame()
    {
        Debug.Log(button.gameObject.name + " was clicked");
        playerController.RestartGame();
    }
}
