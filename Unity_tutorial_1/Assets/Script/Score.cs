using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI scoreText = null;
    private int oldScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        if (GManager.instance != null)
        {
            scoreText.text = "Score " + GManager.instance.score;
        }
        else
        {
            Debug.Log("ゲームマネージャー置き忘れてるよ！");
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (oldScore != GManager.instance.score)
        {
            scoreText.text = "Score " + GManager.instance.score;
            oldScore = GManager.instance.score;
        }
    }
}