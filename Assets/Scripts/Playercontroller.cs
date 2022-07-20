using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Playercontroller : MonoBehaviour
{
    private float speed = 10;
    private float time;
   
    public float verticalInput;
    public GameObject projectilePrefab;

    public float botBound = 2;
    public float topBound = 17;
    public bool isGameActive;
    public GameObject titleScreen;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public TextMeshProUGUI timeText;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {


            MovePlayer();
            RestrainPlayer();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Launch the projectile from the player.
                Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            }
        }
    }
    void MovePlayer()
    {
        //horizontalInput = Input.GetAxis("Horizontal");
       verticalInput = Input.GetAxis("Vertical");

       transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);
        //transform.Translate(Vector3.forward * speed * horizontalInput * Time.deltaTime);

    }

    //Contain player movement
    void RestrainPlayer()
    {
        
        if (transform.position.y < botBound)
        {
            transform.position = new Vector3(transform.position.x, botBound, transform.position.z);
        }
        if (transform.position.y > topBound)
        {
            transform.position = new Vector3(transform.position.x, topBound, transform.position.z);
        }
      
    }
    public void StartGame()
    {

        isGameActive = true;
        titleScreen.gameObject.SetActive(false);
        time = 60;
        InvokeRepeating("Timer", 0, 1);
       
    }
    public void GameOver()
    {
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Timer()
    {
        if (isGameActive)
        {
            if (time == 0)
            {
                GameOver();
            }
            timeText.text = "Time: " + time;
            time--;
        }

    }
}

