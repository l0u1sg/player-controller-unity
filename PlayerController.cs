using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rigid;
    public float jumpForce;
    public Animator animator;
    private bool isFactingRight = true;
    private int score;
    public Text scoreText;
    public GameObject Death;
    private bool isDead;
    private bool finish;
    public GameObject Finish;
    


    private bool isJumping = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        if(move > 0 && isFactingRight == false)
        {
            transform.Rotate(0f, 180, 0f);
            isFactingRight = true;
        }else if(move < 0 && isFactingRight == true)
        {
            transform.Rotate(0f, 180, 0f);
            isFactingRight = false;
        }
        transform.Translate(Vector3.right * move * speed * Time.deltaTime, Space.World);

        if(Input.GetKeyDown(KeyCode.Space) == true && isJumping == false)
        {
            Jump();
        }

     if (move != 0)
        {
            animator.SetBool("Mooving", true);
        }
        else
        {
            animator.SetBool("Mooving", false);
        }

    }

   

    private void Jump() 
    {
        rigid.velocity += Vector2.up * jumpForce;
        isJumping = true;
        animator.SetTrigger("Jumping");
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Ground") == true) 
        {
            isJumping = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
    if(other.CompareTag("Key") == true )
    {
      Destroy(other.gameObject);
      AddScore();
      
        }
    if(other.CompareTag("Respawn") == true) {
        Diying();
    }
    if(other.CompareTag("Finish") == true && score >= 5) {
        Diying2();
    }
    
     }
  
  
  private void AddScore(){
    score += 1;
    Debug.Log(score);
    scoreText.text = "Score : "  + score.ToString();
  } 

  private void Diying(){
      Death.SetActive(true);
      isDead = true;
  }
  private void Diying2(){
      Finish.SetActive(true);
      finish = true;
  }

  
    

}
