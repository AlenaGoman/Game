using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballscore : MonoBehaviour
{
    public GameController gameController;

    public void OnCollisionEnter(Collision collision)
    {
        gameController.AddScore();
    }
}
