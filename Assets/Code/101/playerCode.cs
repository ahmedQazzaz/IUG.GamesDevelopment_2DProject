using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCode : MonoBehaviour
{

    public float speed = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float value = Input.GetAxis("Horizontal");

        transform.Translate(new Vector2(value, 0) * Time.deltaTime * speed);
    }



}
