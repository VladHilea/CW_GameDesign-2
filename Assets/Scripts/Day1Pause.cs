using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day1Pause : MonoBehaviour
{

    public GameObject introstory;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown (KeyCode.Return)){
            introstory.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
