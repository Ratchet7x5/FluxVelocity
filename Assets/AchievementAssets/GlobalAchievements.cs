using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalAchievements : MonoBehaviour
{
    // General Variables
    public GameObject achNote;
    public AudioSource achSound;
    public GameObject achTitle;
    public GameObject achDesc;
    public bool achActive = false;
    public static int achReset;
    
    // Achivement 01 Specific
    public static int ach01Check;
    public int ach01Trigger = 10;
    public int ach01Code = 0;

    // Achivement 02 Specific
    public static int ach02Check;
    public int ach02Trigger = 1;
    public int ach02Code = 0;

    // Achivement 03 Specific
    public static int ach03Check;
    public int ach03Trigger = 1;
    public int ach03Code = 0;

    // Achivement 04 Specific
    public static int ach04Check;
    public int ach04Trigger = 1;
    public int ach04Code = 0;

    // Update is called once per frame
    void Update()
    {
        // Resets Achievements Earned Upon Starting Game
        if(achReset == 0)
        {
            PlayerPrefs.DeleteAll();
            achReset = 12345;
        }

        // When an achievement is triggered the achievement's corresponding function will run
        ach01Code = PlayerPrefs.GetInt("Ach01");
        if (ach01Check == ach01Trigger && ach01Code != 12345)
        {
            StartCoroutine(Trigger01Ach());
        }
        ach02Code = PlayerPrefs.GetInt("Ach02");
        if (ach02Check == ach02Trigger && ach02Code != 12345)
        {
            StartCoroutine(Trigger02Ach());
        }
        ach03Code = PlayerPrefs.GetInt("Ach03");
        if (ach03Check == ach03Trigger && ach03Code != 12345)
        {
            StartCoroutine(Trigger03Ach());
        }
        ach04Code = PlayerPrefs.GetInt("Ach04");
        if (ach04Check == ach04Trigger && ach04Code != 12345)
        {
            StartCoroutine(Trigger04Ach());
        }
    }

    // Displays appropriate information for the achievement earned - Sets the achievement code so player can only earn achievement once
    IEnumerator Trigger01Ach()
    {
        achActive = true;
        ach01Code = 12345;
        PlayerPrefs.SetInt("Ach01", ach01Code);
        achSound.Play();
        achTitle.GetComponent<Text>().text = "Gotta Go Fast!";
        achDesc.GetComponent<Text>().text = "Reach a Speed of 10.";
        achNote.SetActive(true);
        yield return new WaitForSeconds(5);
        //Resetting Achievement Panel
        achNote.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDesc.GetComponent<Text>().text = "";
        achActive = false;
    }

    IEnumerator Trigger02Ach()
    {
        achActive = true;
        ach02Code = 12345;
        PlayerPrefs.SetInt("Ach02", ach02Code);
        achSound.Play();
        achTitle.GetComponent<Text>().text = "Learning the Ropes";
        achDesc.GetComponent<Text>().text = "Complete the Flux Velocity Tutorial.";
        achNote.SetActive(true);
        yield return new WaitForSeconds(6);
        //Resetting Achievement Panel
        achNote.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDesc.GetComponent<Text>().text = "";
        achActive = false;
    }

    IEnumerator Trigger03Ach()
    {
        achActive = true;
        ach03Code = 12345;
        PlayerPrefs.SetInt("Ach03", ach03Code);
        achSound.Play();
        achTitle.GetComponent<Text>().text = "Stadium Victory";
        achDesc.GetComponent<Text>().text = "Win a Race on 'Stadium'";
        achNote.SetActive(true);
        yield return new WaitForSeconds(6);
        //Resetting Achievement Panel
        achNote.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDesc.GetComponent<Text>().text = "";
        achActive = false;
    }

    IEnumerator Trigger04Ach()
    {
        achActive = true;
        ach04Code = 12345;
        PlayerPrefs.SetInt("Ach04", ach04Code);
        achSound.Play();
        achTitle.GetComponent<Text>().text = "8-Bit Victory";
        achDesc.GetComponent<Text>().text = "Win a Race on '8-Bit'";
        achNote.SetActive(true);
        yield return new WaitForSeconds(6);
        //Resetting Achievement Panel
        achNote.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDesc.GetComponent<Text>().text = "";
        achActive = false;
    }
}
