using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] float movementSpeed = 2f;
    
    Rigidbody2D myRigitbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigitbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFacingRight())
        {
            myRigitbody.velocity = new Vector2(movementSpeed, 0f);
        }
        else
        {
            myRigitbody.velocity = new Vector2(-movementSpeed, 0f);
        }
    }


    bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }

    
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigitbody.velocity.x)), 1f);
    }

}
