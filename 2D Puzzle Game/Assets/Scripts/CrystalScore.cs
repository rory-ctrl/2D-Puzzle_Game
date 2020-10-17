using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystalScore : MonoBehaviour
{

    private PlatformerCharacter2D player;
    private Text scoreText;

    void Start(){
        player = GameObject.Find("TimeAgentPlayer").GetComponent<PlatformerCharacter2D>();
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        // scoreText.text = player.getCrystals().ToString();
        scoreText.text = GameValues.score.ToString();
    }
}
