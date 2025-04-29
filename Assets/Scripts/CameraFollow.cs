using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    public Transform target; // transform of the character
    public Vector3 offset;   // distance between camera and character

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }
}