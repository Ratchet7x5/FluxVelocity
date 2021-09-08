using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameUIDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text speedText;

    // Update is called once per frame
    void Update()
    {
        speedText.text = Mathf.FloorToInt(ShipMovement.CurrentSpeed).ToString();
    }
}
