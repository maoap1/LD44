using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public struct TurnFromToOffsets
{
	public TurnFromToOffsets(Vector3 first, Vector3 second)
	{
		this.first = first;
		this.second = second;
	}
	public Vector3 first;
	public Vector3 second;
}

public class PlayerController : MonoBehaviour
{
	public float segmentsZ = 900;
    public string motherScene;

	const int ID_UP = 1;
	const int ID_LEFT = 2;
	const int ID_RIGHT = 3;
	const int ID_DOWN = 4;

    public AudioSource audioSource;

    public float speed = 0.05f;
	public int shift = 4;
    public int reverseShift = 1;
	public TurnFromToOffsets UpLeft = new TurnFromToOffsets(
        first: new Vector3(0.075f, -0.4606f, 0),
		second: new Vector3(-0.931f, -0.066f, 0)
		);
	public TurnFromToOffsets DownLeft = new TurnFromToOffsets(
        first: new Vector3(-0.075f, 0.4606f, 0),
		second: new Vector3(-0.931f, -0.066f, 0)
		);
	public TurnFromToOffsets UpRight = new TurnFromToOffsets(
        first: new Vector3(0.07f, -0.4606f, 0),
		second: new Vector3(0.931f, 0.0756f, 0)
		);
	public TurnFromToOffsets DownRight = new TurnFromToOffsets(
        first: new Vector3(-0.075f, 0.4606f, 0),
		second: new Vector3(0.931f, 0.066f, 0)
		);
	public TurnFromToOffsets RightUp = new TurnFromToOffsets(
		first: new Vector3(-0.4606f, -0.0756f, 0),
        second: new Vector3(-0.075f, 0.931f, 0)
        );
	public TurnFromToOffsets RightDown = new TurnFromToOffsets( 
        first: new Vector3(-0.4606f, -0.066f, 0), 
        second: new Vector3(0.075f, -0.931f, 0) 
        );
	public TurnFromToOffsets LeftUp = new TurnFromToOffsets( 
		first: new Vector3(0.4606f, 0.066f, 0),
		second: new Vector3(-0.075f, 0.931f, 0)
		);
	public TurnFromToOffsets LeftDown = new TurnFromToOffsets(
		first: new Vector3(0.4606f, 0.066f, 0),
		second: new Vector3(0.066f, -0.931f, 0)
		);

	public GameObject segment;
	public GameObject leftTurnSegment;
	public GameObject rightTurnSegment;

	public Stack<GameObject> tail;
	public Vector3 direction;
	public int iteration = 27;
	public int lastDirection;
	public Vector3 handOffset;
    public bool isReadyToTurn;
    public bool reverse;
    public bool reverseMusicPlaying;

	// Start is called before the first frame update
	void Start()
	{
		isSleeping = true;
		sleepingStartTime = Time.timeSinceLevelLoad;
		sleepTime = 1;
        reverseMusicPlaying = false;
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    void Awake()
    {
        direction = Vector3.down;
        lastDirection = ID_DOWN;
        isReadyToTurn = true;
        reverse = false;
        GameObject newSegment = Instantiate(segment, new Vector3( transform.position.x,
            transform.position.y, segmentsZ + 1), 
            transform.rotation);
        tail = new Stack<GameObject>();
        tail.Push(newSegment);
    }

	void OurInnerRotate(TurnFromToOffsets whereToTurn, int rotationZ, GameObject turnSegment)
	{
        GameObject lastSegment = tail.Peek();
		transform.position = lastSegment.transform.position + whereToTurn.first;
		GameObject newSegment = Instantiate(turnSegment, 
            new Vector3(transform.position.x, transform.position.y, segmentsZ),
            transform.rotation);
        segmentsZ -= 0.01f;
		transform.Rotate(0, 0, rotationZ);
		transform.position += whereToTurn.second;
        isReadyToTurn = false;
        tail.Push(newSegment);
    }

	void RotateClockwise(TurnFromToOffsets whereToTurn) => OurInnerRotate(whereToTurn, -90, rightTurnSegment);
	void RotateAntiClockwise(TurnFromToOffsets whereToTurn) => OurInnerRotate(whereToTurn, 90, leftTurnSegment);

	// Update is called once per frame
	void Update()
	{
        if (reverse)
        {
            if (!reverseMusicPlaying)
            {
                audioSource.Play();
                reverseMusicPlaying = true;
            }
            if (iteration >= reverseShift)
            {
                GameObject segment = tail.Pop();
                segment.SetActive(false);
                iteration = 0;
                if (tail.Count == 0)
                {
					if (CoinsAmmountDisplay.isWinGame)
						SceneManager.LoadScene("WinScene");
					else
						SceneManager.LoadScene(motherScene);
                    return;
                }
                segment = tail.Peek();
                while ((segment.tag == "TurnSegment") && (tail.Count > 1))
                {
                    tail.Pop().SetActive(false);
                    segment = tail.Peek();
                }
                foreach (Transform child in segment.transform)
                {
                    if (child.gameObject.tag == "Hand")
                    {
                        child.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    }
                }
            }
            else
            {
                iteration++;
            }
            return;
        }
		if (!isSleeping)
		{
            if (isReadyToTurn)
            {
                if (Input.GetButtonDown("Flee") ||
					(Input.GetKeyDown(KeyCode.Space)) ||
					(Input.GetKeyDown(KeyCode.KeypadEnter)) ||
					(Input.GetKeyDown(KeyCode.Escape)))
                {
                    reverse = true;
                    transform.position = new Vector3(0, 0, -15);
                    GameObject segment = tail.Peek();
                    foreach (Transform child in segment.transform)
                    {
                        if (child.gameObject.tag == "Hand")
                        {
                            child.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                        }
                    }
                    return;
                }
			    if ((Input.GetButtonDown("Left")) && (lastDirection != ID_LEFT) && (lastDirection != ID_RIGHT))
			    {
				    iteration = 0;
				    direction = Vector3.left;
				    if (lastDirection == ID_UP)
				    {
					    RotateAntiClockwise(UpLeft);
				    }
				    else if (lastDirection == ID_DOWN)
				    {
					    RotateClockwise(DownLeft);
				    }
				    lastDirection = ID_LEFT;
                }
			    if ((Input.GetButtonDown("Right")) && (lastDirection != ID_RIGHT) && (lastDirection != ID_LEFT))
			    {
				    iteration = 0;
				    direction = Vector3.right;
				    if (lastDirection == ID_UP)
				    {
					    RotateClockwise(UpRight);
				    }
				    else if (lastDirection == ID_DOWN)
				    {
					    RotateAntiClockwise(DownRight);
				    }
				    lastDirection = ID_RIGHT;
			    }
			    if ((Input.GetButtonDown("Up")) && (lastDirection != ID_UP) && (lastDirection != ID_DOWN))
			    {
				    //handOffset = handUpOffset;
				    iteration = 0;
				    direction = Vector3.up;
				    if (lastDirection == ID_LEFT)
				    {
					    RotateClockwise(LeftUp);
				    }
				    else if (lastDirection == ID_RIGHT)
				    {
					    RotateAntiClockwise(RightUp);
				    }
				    lastDirection = ID_UP;
			    }
			    if ((Input.GetButtonDown("Down")) && (lastDirection != ID_DOWN) && (lastDirection != ID_UP))
			    {
				    iteration = 0;
				    direction = Vector3.down;
				    if (lastDirection == ID_LEFT)
				    {
					    RotateAntiClockwise(LeftDown);
				    }
				    else if (lastDirection == ID_RIGHT)
				    {
					    RotateClockwise(RightDown);
				    }
				    lastDirection = ID_DOWN;
			    }
            }
            if (iteration >= shift)
			{
                isReadyToTurn = true;
				GameObject newSegment = Instantiate(segment
					, new Vector3(transform.position.x, transform.position.y, segmentsZ)
					, transform.rotation);
                segmentsZ -= 0.01f;
				GameObject lastSegment = tail.Peek();
				foreach (Transform child in lastSegment.transform)
				{
					if (child.gameObject.tag == "Hand")
					{
						child.gameObject.GetComponent<SpriteRenderer>().enabled = false;
					}
				}
                tail.Push(newSegment);
				iteration = 0;
			}
			else
			{
				iteration++;
			}
			transform.position += speed * direction;
		}

	}

	private void FixedUpdate()
	{
		if (isSleeping)
			if (isSleeping && sleepingStartTime + sleepTime < Time.timeSinceLevelLoad)
				isSleeping = false;
	}
	float sleepingStartTime;
	float sleepTime;
	bool isSleeping = false;
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Wall")
			SceneManager.LoadScene("GameOver");
		else
		{
			if (other.CompareTag("Money"))
			{
				CoinsAmmountDisplay.dictionary[other.GetComponent<DestroyCoin>().myType]++;
			}
			isSleeping = true;
			sleepingStartTime = Time.timeSinceLevelLoad;
			sleepTime = other.GetComponent<DestroyMe>().SleepTime;
			other.GetComponent<DestroyMe>().RunAndPlaySound();
		}
	}

}
