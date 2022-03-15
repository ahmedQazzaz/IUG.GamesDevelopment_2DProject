using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    GameObject camera;

    public float playerSpeed = 4;
    public float jumpPower = 12;
    bool canJump = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float HAxes = Input.GetAxis("Horizontal");

        transform.Translate(new Vector2(HAxes, 0) * Time.deltaTime * playerSpeed);

        Camera cObj = camera.GetComponent<Camera>();
        cObj.orthographicSize = 8.676287f + (Mathf.Abs(HAxes) * 0.5f);


        if (Input.GetKeyDown(KeyCode.UpArrow) && canJump)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpPower));
            canJump = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        var normal = collision.contacts[0].normal;

        if (normal.y > 0)
        {
            canJump = true;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        UIManager.SharedManager().AddScore(1);
    }





}
