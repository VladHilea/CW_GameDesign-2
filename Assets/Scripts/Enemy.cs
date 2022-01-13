using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
        private Vector2 antimovement;

    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        rb= this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement=direction;

        Vector3 antidirection = player.position + transform.position;
        antidirection.Normalize();
        antimovement=antidirection;
    }

     void FixedUpdate() {
        MoveCharacter(movement, antimovement);
        Invert(movement);
    }

    void MoveCharacter( Vector2 direction, Vector2 antidirection){
         GameObject thePlayer = GameObject.Find("Player");
        PlayerMovement player = thePlayer.GetComponent<PlayerMovement>();
        if(!player.immune){
        rb.MovePosition((Vector2)transform.position + (direction *moveSpeed *Time.deltaTime));
        } else {
            rb.MovePosition((Vector2)transform.position + (antidirection *moveSpeed *Time.deltaTime));
        }
    }

    void Invert(Vector2 direction){
        if (movement.x > 0 ) {
            GetComponent<SpriteRenderer>().flipX = true;
        } else {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "arrow"){
            Destroy(this.gameObject);
        }

        if(other.gameObject.tag == "Player"){
            
            GameObject thePlayer = GameObject.Find("Player");
        PlayerMovement player = thePlayer.GetComponent<PlayerMovement>();
        if(!player.immune){

            Destroy(this.gameObject);
        }
        }
    }
}
