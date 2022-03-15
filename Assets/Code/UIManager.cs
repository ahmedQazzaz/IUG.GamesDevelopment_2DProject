using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private static UIManager shared;
    int score = 0;

    [SerializeField]
    Text scoreText;


    public static UIManager SharedManager()
    {
        return UIManager.shared;
    }

    // Start is called before the first frame update
    void Start()
    {
        UIManager.shared = GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score;
        
    }

}
