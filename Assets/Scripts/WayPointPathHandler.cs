using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* THIS SCRIPT ONLY RUN IN EDITOR MODE */
public class WayPointPathHandler : MonoBehaviour
{
    public Color drawColor;

    private List<Transform> wayPointList = new List<Transform>();

    // Similar with Update(), but works only in Editor,
    // called when scene view updated
    private void OnDrawGizmos() {
        
        // Set color
        Gizmos.color = drawColor;

        // Return array of transform, from it's children
        Transform[] pathTransform = GetComponentsInChildren<Transform>();

        // Reset wayPointList in each update
        wayPointList = new List<Transform>();

        for (int i = 0; i < pathTransform.Length; i++) {
            // Add to wayPointList,
            // If not transform of this gameobject (parent)
            if (pathTransform[i] != transform) {
                wayPointList.Add(pathTransform[i]);
            }
        }

        int size = wayPointList.Count;

        for (int i = 0; i < wayPointList.Count; i++) {
            Vector3 currentPoint = wayPointList[i].position;
            Vector3 previousPoint = wayPointList[(size - 1 + i) % size].position;

            // Draw line between two given points
            Gizmos.DrawLine(previousPoint, currentPoint);
            Gizmos.DrawWireSphere(currentPoint, 0.5f);
        }
    }
}
