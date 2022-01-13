using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HouseLoot : MonoBehaviour
{
    private bool visited;
    private GameObject plushealth;
    private GameObject minushealth;

    private GameObject plus5ammo;
    private GameObject plus10ammo;
    private GameObject plus20ammo;

    private GameObject textvisited;



    // Start is called before the first frame update
    void Start()
    {
        visited = false;
        plushealth = GameObject.FindGameObjectsWithTag("+1health")[0];
        
        plus5ammo = GameObject.FindGameObjectsWithTag("+5ammo")[0];
        plus10ammo = GameObject.FindGameObjectsWithTag("+10ammo")[0];
        plus20ammo = GameObject.FindGameObjectsWithTag("+20ammo")[0];
        textvisited = GameObject.FindGameObjectsWithTag("visitedtext")[0];



        plushealth.GetComponent<Text>().enabled = false;
        
        plus5ammo.GetComponent<Text>().enabled = false;
        plus10ammo.GetComponent<Text>().enabled = false;
        plus20ammo.GetComponent<Text>().enabled = false;

        
        textvisited.GetComponent<Image>().enabled = false;
        textvisited.GetComponent<Image>().GetComponentsInChildren<Text>()[0].enabled = false;




    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator OnTriggerEnter2D( Collider2D other){

        GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);
        Debug.Log(other.gameObject.tag);
        if(!visited){
            if(other.gameObject.tag == "Player") {
                Debug.Log("Hit a house");

                

                visited = true;

                plushealth.GetComponent<Text>().enabled = false;
                
                plus5ammo.GetComponent<Text>().enabled = false;
                plus10ammo.GetComponent<Text>().enabled = false;
                plus20ammo.GetComponent<Text>().enabled = false;
                textvisited.GetComponent<Image>().enabled = false;
                textvisited.GetComponent<Image>().GetComponentsInChildren<Text>()[0].enabled = false;
                

                float temp = Random.value;

                
                if( temp < .5f){
                    GameObject thePlayer = GameObject.Find("Player");
    PlayerMovement player = thePlayer.GetComponent<PlayerMovement>();
                    player.ammo= player.ammo + 1 + player.trust;
                    Debug.Log(temp);

                    plus5ammo.GetComponent<Text>().enabled = true;
                    yield return new  WaitForSeconds(2f);
                    plus5ammo.GetComponent<Text>().enabled = false;


                } else if (temp < .7f) {
                    GameObject thePlayer = GameObject.Find("Player");
    PlayerMovement player = thePlayer.GetComponent<PlayerMovement>();
                    player.ammo = player.ammo + 2 + player.trust;
                    Debug.Log(temp);

                    plus10ammo.GetComponent<Text>().enabled = true;
                    yield return new  WaitForSeconds(2f);
                    plus10ammo.GetComponent<Text>().enabled = false;

                } else if (temp < .8f) {
                    GameObject thePlayer = GameObject.Find("Player");
    PlayerMovement player = thePlayer.GetComponent<PlayerMovement>();
                    player.ammo = player.ammo + 3 + player.trust;
                    Debug.Log(temp);

                    plus20ammo.GetComponent<Text>().enabled = true;
                    yield return new  WaitForSeconds(2f);
                    plus20ammo.GetComponent<Text>().enabled = false;

                } else {
                    GameObject thePlayer = GameObject.Find("Player");
    PlayerMovement player = thePlayer.GetComponent<PlayerMovement>();
                    
                            player.health = player.health + 1 ;
                    
                    
                    Debug.Log(temp);

                    plushealth.GetComponent<Text>().enabled = true;
                    yield return new  WaitForSeconds(2f);
                    plushealth.GetComponent<Text>().enabled = false;

                }
            }
        } else{
            
            if(other.gameObject.tag == "Player") {
                Debug.Log("Already visited");

                 if(textvisited.GetComponent<Image>().enabled == false){
                    textvisited.GetComponent<Image>().enabled = true;
                    textvisited.GetComponent<Image>().GetComponentsInChildren<Text>()[0].enabled = true;
                    
                }
            }
        }
    }

   

    public void OnTriggerExit2D(Collider2D collision){

        if(collision.gameObject.tag=="Player"){
           
                if(textvisited.GetComponent<Image>().enabled == true){
                    textvisited.GetComponent<Image>().enabled = false;
                    textvisited.GetComponent<Image>().GetComponentsInChildren<Text>()[0].enabled = false;
                    
                }
            
        }
    }

   
}
