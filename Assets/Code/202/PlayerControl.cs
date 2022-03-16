using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    [SerializeField]
    float speed = 4;

    [SerializeField]
    float jumpForce = 100;

    bool canJump = true;

    Vector2 startPoint;
    int respawnCount = 0;
    bool shouldRespawn = false;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (shouldRespawn)
        {
            respawnCount += 1;
            if (respawnCount == 90)
            {
                transform.position = startPoint;
                shouldRespawn = false;
            }
        }

        float value = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(value, 0) * Time.deltaTime * speed);

        GameObject cam = GameObject.Find("Main Camera");
        Camera camComponent = cam.GetComponent<Camera>();
        camComponent.orthographicSize =  5 + Mathf.Abs(value);


        if (Input.GetKeyDown(KeyCode.UpArrow) && canJump)
        {
            Rigidbody2D body = GetComponent<Rigidbody2D>();
            body.AddForce(new Vector2(0, jumpForce));
            canJump = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

       

        Vector2 normal =  collision.contacts[0].normal;

        if (normal.y > 0)
        {
            canJump = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "DeathLine")
        {
            //Destory this object.

            //Create new version.

            //OR Jump to start point.
            shouldRespawn = true;
            return;
        }

        int v = collision.gameObject.GetComponent<CoinScript>().value;
        Destroy(collision.gameObject);
        GameObject eventSystem = GameObject.Find("EventSystem");
        UIEvents events = eventSystem.GetComponent<UIEvents>();
        events.addScore(v);
    }
}
