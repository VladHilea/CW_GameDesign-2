using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{

    public float speedMov;
    private Rigidbody2D playerRbody;
    private Vector3 change;
    private Animator animator;
    public Camera sceneCamera;
    private Vector2 mousePosition;
    public GameObject projectile;
    public int strengthArrow;
    private string state;
    public  int health = 1;
    public int ammo;
    public int trust;
    public bool immune = false ;
    private AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        transform.position = new Vector2(0,0);
        animator = GetComponent<Animator>();
        playerRbody= GetComponent<Rigidbody2D>();
        state = "noattack";
        audioSrc = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        //Debug.Log(change);

        
        
        if(!PauseMenu.isPaused){
        if(Input.GetButtonDown("attack")){
            if(state.Equals("noattack"))
            if(ammo > 0){
                ammo--;
            StartCoroutine(Attack());
            }
        }
        }

    }

     void FixedUpdate() {
        MoveAnimation();
    }

    void MovementCharacter()
    {
        
        playerRbody.MovePosition(
            transform.position + change * speedMov * Time.deltaTime);
    }

    void MoveAnimation(){
        if(change != Vector3.zero){
        MovementCharacter();
        animator.SetFloat("MoveX", change.x);
        animator.SetFloat("MoveY", change.y);
        animator.SetBool("Moving", true);
        } else {
            animator.SetBool("Moving", false);
        }
    }

//attacking method. change waitforseconds() to have more time between shots. it was created so you don't shoot one arrow after another
    private IEnumerator Attack(){
        state = "attack";
        audioSrc.Play();
        StartCoroutine(MakeArrow());
        yield return new WaitForSeconds(0.5f);
        state = "noattack";
        
    }

   

//this creates a new arrow. if the strength is bigger it will send more arrows.
    private IEnumerator MakeArrow(){
        Vector2 temp = new Vector2(animator.GetFloat("MoveX"), animator.GetFloat("MoveY"));
        Debug.Log(temp);
        if(temp.x == 0 && temp.y == 0){
            temp.x = 1f;
        }
        Vector3 directiontemp = chooseArrowDirection();
                Vector3 temp1 = transform.position;

        for(int i = 0; i<strengthArrow;i++){
            if(i!=0){
            if(i==1){
        temp1.y= temp1.y +0.6f;
        } else if(i==2) {
            temp1.y= temp1.y -1.2f;
        } else if(i==3) {
            temp1.y= temp1.y +1.8f;
        }
        else if(i==4) {
            temp1.y= temp1.y -2.4f;
        }
            }
        Arrow arrow = Instantiate(projectile, temp1, Quaternion.identity).GetComponent<Arrow>();
        arrow.SetUp(temp, directiontemp);
        
        yield return new WaitForSeconds(0f);
        }
    }

    Vector3 chooseArrowDirection()
    {
        float temp = Mathf.Atan2(animator.GetFloat("MoveY"), animator.GetFloat("MoveX"))* Mathf.Rad2Deg;
        return new Vector3(0,0,temp);
    }

     void OnEnable() {
         SceneManager.sceneLoaded += OnLevelFinishedLoading;
        transform.position= new Vector2(0,0);
    }

     void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
             {
                 transform.position= new Vector2(0,0);
             }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Enemy"){
            if(!immune){
                if(health > 1){
                    health --;
                    transform.position = new Vector2(0,0);
                    
                    StartCoroutine(startImunity());

                } else {
                    Destroy(this.gameObject);
                    SceneManager.LoadScene("GameOver");
                    
                }
            } 
        }
    }

    IEnumerator startImunity(){
        immune = true;
        GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0.5f);
        yield return new WaitForSeconds(1.5f);
        immune = false;
        GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
    }

   

    
}
