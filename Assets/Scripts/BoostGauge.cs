using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[ExecuteInEditMode()]
public class BoostGauge : MonoBehaviour
{
    public int maximum;
    public int current;
    public Image mask;
    
    // Start is called before the first frame update
    void Start()
    {
        maximum = 500;        
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        if (Input.GetKey("space") && current > 0) 
        {
            current = current - 2;
        }
        else
        {
            if (current < 500)
            {
                current++;
            }
        }
        
        float fillAmount = (float)current / (float) maximum;
        mask.fillAmount = fillAmount;
        
        
    }
}
