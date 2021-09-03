using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameUIDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text speedText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speedText.text = Mathf.FloorToInt(ShipMovement.CurrentSpeed).ToString();
    }
}
