using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    public AudioSource audioSource;

    /*
    This mehtod make sure that the music (gameObject) will not be destroyed,
    when the game SCENE changed

    Note : In Unity Awake() invoked before Start()

    */
    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

}
