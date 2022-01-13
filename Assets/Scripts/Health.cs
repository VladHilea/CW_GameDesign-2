using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
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
        GetComponent<UnityEngine.UI.Text>().text ="Lives: " + player.health;
    }
}
