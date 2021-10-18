using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ach01Trigger : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
      GlobalAchievements.ach01Check = Mathf.FloorToInt(ShipMovement.CurrentSpeed);
      Rewards01.rewardCheck = Mathf.FloorToInt(ShipMovement.CurrentSpeed);
    }
}
