using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenScript : MonoBehaviour
{

    public int yTreshold = -10;
    void Update()
    {
        if (transform.position.y < yTreshold)
        {
            Destroy(gameObject);
        }
    }
}
