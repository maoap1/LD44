using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.01f;
    public int shift = 10;
    
    public float timer = 500.0f;

    public GameObject segment;

    public List<GameObject> tail;
    public GameObject head;
    public Vector3 direction;
    public int iteration = 0;

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {
        if (iteration >= shift)
        {
            Instantiate(segment, transform.position, transform.rotation);
            tail.Add(segment);
            iteration = 0;
        }
        else
        {
            iteration++;
        }
        transform.position += speed * direction;
    }

  
}
