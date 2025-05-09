using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyWave : MonoBehaviour
{
    // Start is called before the first frame update.
    void Start()
    {
        // Detaches all child objects (children) of this object from the parent object.
        transform.DetachChildren();
        // Disappears this object from the scene.
        Destroy(gameObject);
    }

    // Update is called once per frame.
    void Update()
    {
    }
}
