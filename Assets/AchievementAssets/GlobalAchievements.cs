using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalAchievements : MonoBehaviour
{

    //General Variables
    public GameObject achNote;
    public AudioSource achSound;
    public GameObject achTitle;
    public GameObject achDesc;
    public bool achActive = false;
    
    //Achivement 01 Specific
    public static int ach01Check;
    public int ach01Trigger = 8;
    public int ach01Code = 0;

    void Start()
    {
        PlayerPrefs.DeleteAll();
        
    }

    // Update is called once per frame
    void Update()
    {
        ach01Code = PlayerPrefs.GetInt("Ach01");
        if (ach01Check == ach01Trigger && ach01Code != 12345)
        {
            StartCoroutine(Trigger01Ach());
        }
    }

    IEnumerator Trigger01Ach()
    {
        achActive = true;
        ach01Code = 12345;
        PlayerPrefs.SetInt("Ach01", ach01Code);
        achSound.Play();
        achTitle.GetComponent<Text>().text = "Gotta Go Fast!";
        achDesc.GetComponent<Text>().text = "Reach a Speed of 8";
        achNote.SetActive(true);
        yield return new WaitForSeconds(6);
        //Resetting Achievement Panel
        achNote.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDesc.GetComponent<Text>().text = "";
        achActive = false;
    }
}
