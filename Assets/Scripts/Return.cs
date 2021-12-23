using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Return : MonoBehaviour
{

    [SerializeField] GameObject MenuLose;

    public void Scenes(int numberScenes)
    {
        SceneManager.LoadScene(numberScenes);

    }

    public void Restart()
    {
        MenuLose.SetActive(false);
    }
}
