using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingMoney : MonoBehaviour
{
	public List<GameObject> coins;
	public List<GameObject> bankNotes;

	System.Random r = new System.Random();
	int rint => r.Next();
	float rfloat => rint * 2f / (int.MaxValue * 5f);

	int probability = 1000000000;
	// Update is called once per frame
	void Update()
	{
		//      if(rint < probability * 3)
		//{
		GameObject newCoin = Instantiate(coins[rint % coins.Count]);
		newCoin.transform.position = new Vector3(rint * rfloat % 19 - 9, 5.3f, 0);
		newCoin.GetComponent<Rigidbody2D>().gravityScale = rfloat + 0.8f;
		//}
		if (rint < probability)
		{
			GameObject newBankNote = Instantiate(coins[rint % bankNotes.Count]);
			newBankNote.transform.position = new Vector3(rint % 19 - 9, 5.3f, 0);
			newBankNote.GetComponent<Rigidbody2D>().gravityScale = rfloat + 0.4f;
		}
	}
}
