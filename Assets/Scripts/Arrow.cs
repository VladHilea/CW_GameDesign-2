using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    public float speed;
    public Rigidbody2D myRigidbody2D;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetUp(Vector2 velocity, Vector3 direction)
    {
        myRigidbody2D.velocity = velocity.normalized * speed;
        transform.rotation = Quaternion.Euler(direction);
    }

//when hits something it dissaperes
    public void OnTriggerEnter2D(Collider2D other){
        Debug.Log("ceva");
        
        Destroy(this.gameObject);

       
    }

    

   
}
