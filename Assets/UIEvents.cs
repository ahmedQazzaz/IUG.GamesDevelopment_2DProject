using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEvents : MonoBehaviour
{

    int score = 0;

    [SerializeField]
    Text txt_score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore(int value)
    {
        score += value;
        txt_score.text = "Score: " + score;
    }
}
