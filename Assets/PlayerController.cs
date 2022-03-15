using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    [SerializeField]
    float speed = 1;

    [SerializeField]
    float jumpForce = 200;

    bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float value = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(value, 0) * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.UpArrow) && canJump)
        {
            Rigidbody2D body = GetComponent<Rigidbody2D>();
            body.AddForce(new Vector2(0, jumpForce));
            canJump = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }
}
