using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trust : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject thePlayer = GameObject.Find("Player");
        PlayerMovement player = thePlayer.GetComponent<PlayerMovement>();
        GetComponent<UnityEngine.UI.Text>().text ="Trust: " + player.trust + " / 4";
    }

     public void helpVillage(){
         Time.timeScale = 1f;
         
         GameObject thePlayer = GameObject.Find("Player");
        PlayerMovement player = thePlayer.GetComponent<PlayerMovement>();
        
        if(player.trust <5){
            
            player.trust ++;
        }

        GameObject choice = GameObject.Find("ChoiceMenu");
        choice.SetActive(false);
        CountdownTimer.choiceShow = false;
    }

    public void upgradeWeapon(){
        Time.timeScale = 1f;
        
        GameObject thePlayer = GameObject.Find("Player");
        PlayerMovement player = thePlayer.GetComponent<PlayerMovement>();
        if(player.trust >0){
            player.strengthArrow ++;
            player.trust --;
        }
        GameObject choice = GameObject.Find("ChoiceMenu");
        choice.SetActive(false);
        CountdownTimer.choiceShow = false;
    }
}
