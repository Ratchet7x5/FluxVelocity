using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public AudioSource audioSource;

    /*
    This mehtod make sure that the music (gameObject) will not be destroyed,
    when the game SCENE changed
    Note : In Unity Awake() invoked before Start()
    */
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
