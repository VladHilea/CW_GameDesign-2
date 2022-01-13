using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public string levelToLoad;
    public float timer = 10f;
    public float spawnSeconds;
    private Text timerSeconds;
    private float temp;
    public GameObject enemy;

    public GameObject choiceMenu;
    
    private bool night = false;
    private bool choiceDay = false;
    public static bool choiceShow = false;

    // Start is called before the first frame update
    void Start()
    {
        
        
        timerSeconds = GetComponent<Text>();
        string thisScene = SceneManager.GetActiveScene().name;
        if(thisScene == "Night1" || thisScene == "Night2" ||thisScene == "Night3" || thisScene == "Night4" || thisScene == "Night5"){
            night = true;
            temp = spawnSeconds;
        } else {
            night = false;
        }

        if(thisScene == "Day2" || thisScene == "Day3" || thisScene == "Day4" || thisScene == "Day5"){
            choiceDay = true;
            Debug.Log("Choice Day");
            
        } else {
            choiceDay = false;
            Debug.Log("Not Choice Day");
        }

        if(choiceDay){
            choiceMenu.SetActive(false);
            choiceMenu.SetActive(true);
            choiceShow = true;
            Time.timeScale = 0f;
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        timer -=Time.deltaTime;
        timerSeconds.text = timer.ToString("f0");
        if(timer<=0){
             GameObject thePlayer = GameObject.Find("Player");
                PlayerMovement player = thePlayer.GetComponent<PlayerMovement>();
            if(SceneManager.GetActiveScene().name != "Night5"){
            SceneManager.LoadScene(levelToLoad);
            } else {
                if(player.trust >=2){
                    SceneManager.LoadScene("EndStory");
                } else {
                     SceneManager.LoadScene("EndStory2");
                }
            }
        }

        if(night) {
            spawnSeconds -=Time.deltaTime;
            if(spawnSeconds<=0){
                if(SceneManager.GetActiveScene().name == "Night1"){
                Enemy enemy4 = Instantiate(enemy, new Vector3(46.4f,14.8f, 0f), Quaternion.identity).GetComponent<Enemy>();
                Enemy enemy1 = Instantiate(enemy, new Vector3(47f,-19f, 0f), Quaternion.identity).GetComponent<Enemy>();
                Enemy enemy2 = Instantiate(enemy, new Vector3(-49.8f,18.2f, 0f), Quaternion.identity).GetComponent<Enemy>();
                Enemy enemy3 = Instantiate(enemy, new Vector3(-52f,-21f, 0f), Quaternion.identity).GetComponent<Enemy>();
              spawnSeconds = temp;
                } else if(SceneManager.GetActiveScene().name == "Night2" || SceneManager.GetActiveScene().name == "Night3" ) {
                    Enemy enemy4 = Instantiate(enemy, new Vector3(46.4f,14.8f, 0f), Quaternion.identity).GetComponent<Enemy>();
                Enemy enemy1 = Instantiate(enemy, new Vector3(47f,-19f, 0f), Quaternion.identity).GetComponent<Enemy>();
                Enemy enemy2 = Instantiate(enemy, new Vector3(-49.8f,18.2f, 0f), Quaternion.identity).GetComponent<Enemy>();
                Enemy enemy3 = Instantiate(enemy, new Vector3(-52f,-21f, 0f), Quaternion.identity).GetComponent<Enemy>();
                Enemy enemy5 = Instantiate(enemy, new Vector3(-38f,5f, 0f), Quaternion.identity).GetComponent<Enemy>();
                spawnSeconds = temp;
                }
                else if(SceneManager.GetActiveScene().name == "Night4" || SceneManager.GetActiveScene().name == "Night5" ) {
                    Enemy enemy4 = Instantiate(enemy, new Vector3(46.4f,14.8f, 0f), Quaternion.identity).GetComponent<Enemy>();
                Enemy enemy1 = Instantiate(enemy, new Vector3(47f,-19f, 0f), Quaternion.identity).GetComponent<Enemy>();
                Enemy enemy2 = Instantiate(enemy, new Vector3(-49.8f,18.2f, 0f), Quaternion.identity).GetComponent<Enemy>();
                Enemy enemy3 = Instantiate(enemy, new Vector3(-52f,-21f, 0f), Quaternion.identity).GetComponent<Enemy>();
                Enemy enemy5 = Instantiate(enemy, new Vector3(-38f,5f, 0f), Quaternion.identity).GetComponent<Enemy>();
                Enemy enemy6 = Instantiate(enemy, new Vector3(46.9f,-5.5f, 0f), Quaternion.identity).GetComponent<Enemy>();
                spawnSeconds = temp;

                }
            }
        }
    }

    
}
