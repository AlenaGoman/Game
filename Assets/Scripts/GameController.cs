using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;

    public void AddScore()
    {
        score += 10;
        scoreText.text = "Î×ÊÈ: " + score;
    }

}
