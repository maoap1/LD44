using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const int ID_UP = 1;
    const int ID_LEFT = 2;
    const int ID_RIGHT = 3;
    const int ID_DOWN = 4;

    public float speed = 0.01f;
    public int shiftUp = 27;
    public int shiftDown = 27;
    public int shiftLeft = 27;
    public int shiftRight = 27;
    public Vector3 handUpOffset = new Vector3(0.07f,-0.7f,0);
    public Vector3 handDownOffset = new Vector3(-0.07f,-0.07f,0);
    public Vector3 handLeftOffset = new Vector3(0.7f,0.07f,0);
    public Vector3 handRightOffset = new Vector3(-0.7f,-0.07f, 0);
    public float timer = 500.0f;

    public GameObject segment;

    public List<GameObject> tail;
    public Vector3 direction;
    public int iteration = 27;
    public int lastDirection;
    public Vector3 handOffset;
    public int shift;

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector3.up;
        lastDirection = ID_UP;
        shift = shiftUp;
        handOffset = handUpOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButtonDown("Left")) && (lastDirection != ID_LEFT) && (lastDirection != ID_RIGHT))
        {
            handOffset = handLeftOffset;
            iteration = 0;
            shift = shiftLeft;
            direction = Vector3.left;
            if (lastDirection == ID_UP)
            {
                transform.Rotate(0, 0, 90);
                transform.position += handRightOffset;
            }
            else if(lastDirection == ID_DOWN)
            {
                transform.Rotate(0, 0, -90);
            }
            lastDirection = ID_LEFT;
        }
        if ((Input.GetButtonDown("Right")) && (lastDirection != ID_RIGHT) && (lastDirection != ID_LEFT))
        {
            handOffset = handRightOffset;
            iteration = 0;
            shift = shiftRight;
            direction = Vector3.right;
            if (lastDirection == ID_UP)
            {
                transform.Rotate(0, 0, -90);
            }
            else if (lastDirection == ID_DOWN)
            {
                transform.Rotate(0, 0, 90);
            }
            lastDirection = ID_RIGHT;
        }
        if ((Input.GetButtonDown("Up")) && (lastDirection != ID_UP) && (lastDirection != ID_DOWN))
        {
            handOffset = handUpOffset;
            iteration = 0;
            shift = shiftUp;
            direction = Vector3.up;
            if (lastDirection == ID_LEFT)
            {
                transform.Rotate(0, 0, -90);
            }
            else if (lastDirection == ID_RIGHT)
            {
                transform.Rotate(0, 0, 90);
            }
            lastDirection = ID_UP;
        }
        if ((Input.GetButtonDown("Down")) && (lastDirection != ID_DOWN) && (lastDirection != ID_UP))
        {
            handOffset = handDownOffset;
            iteration = 0;
            shift = shiftDown;
            direction = Vector3.down;
            if (lastDirection == ID_LEFT)
            {
                transform.Rotate(0, 0, 90);
            }
            else if (lastDirection == ID_RIGHT)
            {
                transform.Rotate(0, 0, -90);
            }
            lastDirection = ID_DOWN;
        }
        if (iteration >= shift)
        {
            GameObject newSegment = Instantiate(segment, transform.position, transform.rotation);
            GameObject lastSegment = tail[tail.Count - 1];
            foreach (Transform child in lastSegment.transform)
            {
                if (child.gameObject.tag == "Hand")
                {
                    child.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                }
            }
            tail.Add(newSegment);
            iteration = 0;
        }
        else
        {
            iteration++;
        }
        transform.position += speed * direction;
    }

	float sleepStartingTime;
	bool isSleeping = false;
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("Money"))
		{
			//CoinsAmmountDisplay.dictionary[collision.collider.GetComponent<DestroyCoin>().myType]++;
		}
		isSleeping = true;
	}

}
