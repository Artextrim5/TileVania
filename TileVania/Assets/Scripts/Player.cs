using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 13f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] Vector2 dethKick = new Vector2(10f, 10f);

    bool isAlive = true;

    Animator myAnimator;
    Rigidbody2D myRigitbudy;
    CapsuleCollider2D myBodyCollider2D;
    BoxCollider2D myFeet;
    float gravityScaleOnStart;

    // Start is called before the first frame update
    void Start()
    {
        myRigitbudy = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider2D = GetComponent<CapsuleCollider2D>();
        gravityScaleOnStart = myRigitbudy.gravityScale;
        myFeet = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive) { return; }

        Run();
        ClimbLadder();
        Jump();
        FlipSprite();
        PlayerDie();
    }

    private void Run()
    {
        float controlThrow = Input.GetAxis("Horizontal");
        Vector2 playarVelosity = new Vector2(controlThrow * runSpeed, myRigitbudy.velocity.y);
        myRigitbudy.velocity = playarVelosity;

        bool playerHorizontalSpeed = Mathf.Abs(myRigitbudy.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Is Runing", playerHorizontalSpeed);
    }

    private void Jump()
    {
        if (myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            if (Input.GetButtonDown("Jump"))
            {
                Vector2 jumpVelosityTooAdd = new Vector2(0f, jumpSpeed);
                myRigitbudy.velocity += jumpVelosityTooAdd;
            }
        }               
    }

    private void ClimbLadder()
    {
        if (myFeet.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            float controlThrow = Input.GetAxis("Vertical");
            Vector2 climbVelosity = new Vector2(myRigitbudy.velocity.x, controlThrow * climbSpeed);
            myRigitbudy.velocity = climbVelosity;
            myRigitbudy.gravityScale = 0f;

            bool playerHasVerticalSpeed = Mathf.Abs(myRigitbudy.velocity.y) > Mathf.Epsilon;
            myAnimator.SetBool("Is Climing", playerHasVerticalSpeed);
        }
        else
        {
            myAnimator.SetBool("Is Climing", false);
            myRigitbudy.gravityScale = gravityScaleOnStart;
            return;
        }
    }

    private void PlayerDie()
    {
        if (myBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazerds")))
        {
            isAlive = false;
            myAnimator.SetTrigger("Die");
            GetComponent<Rigidbody2D>().velocity = dethKick;
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }
    }


    private void FlipSprite()
    {
        bool playerHorizontalSpeed = Mathf.Abs(myRigitbudy.velocity.x) > Mathf.Epsilon;
        if (playerHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigitbudy.velocity.x), 1f);
        }
    }

}
