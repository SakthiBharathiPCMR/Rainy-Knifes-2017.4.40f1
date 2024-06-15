using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float movementSpeed = 3f;
    private bool canMove = true;
    private string horizontalAxis = "Horizontal";
    private SpriteRenderer sr;
    private Animator playerAnim;
    string walk_Anim = "Walk";
    //string idle_Anim = "Idle";
    [SerializeField]
    private float minX = -2.5f, maxX = 2.5f;
    string knifeTag = "Knife";
    string PlayScene = "GamePlay";

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();
    }

	// Use this for initialization
	void Start ()
    {
         	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Movement();
        PlayerBounds();
	}

    void Movement()
    {

        if (!canMove)       
            return; //stop executing from here.

        float h = Input.GetAxisRaw(horizontalAxis);
        Vector2 tempPos = transform.position;
        // Vector2 tempScale = transform.localScale;

        if (h > 0)
        {
            tempPos.x += movementSpeed * Time.deltaTime;
            sr.flipX = false;
            playerAnim.SetBool(walk_Anim, true);
            //tempScale.x = Mathf.Abs(tempScale.x);
            //playerAnim.Play(walk_Anim);
        }
        else if (h < 0)
        {
            tempPos.x -= movementSpeed * Time.deltaTime;
            sr.flipX = true;
            playerAnim.SetBool(walk_Anim, true);
            // tempScale.x = -Mathf.Abs(tempScale.x);
            //playerAnim.Play(walk_Anim);
        }
        else
        {
            playerAnim.SetBool(walk_Anim, false);
            //playerAnim.Play(idle_Anim); 
        }
        transform.position = tempPos;
        //transform.localScale = tempScale;

    }

    void PlayerBounds()
    {
        Vector2 tempPos = transform.position;
        if (tempPos.x>maxX)
        {
            tempPos.x = maxX;
        }
        else if (tempPos.x<minX)
        {
            tempPos.x = minX;
        }

        transform.position = tempPos;
    }
    IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = 1f;
        SceneManager.LoadScene(PlayScene);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(knifeTag))
        {
            Time.timeScale = 0f;
            canMove = false;
            StartCoroutine(RestartGame());
        }
    }
}
