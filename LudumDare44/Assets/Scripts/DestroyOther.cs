using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOther : DestroyMe
{
	public int SleepingTime;
	public override int SleepTime {
		get => SleepingTime;
		protected set { }
	}
    protected override void Activate()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<ShadowMode>().enabled = false;
        foreach (Transform child in transform)
        {
            child.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        GetComponent<SpriteRenderer>().enabled = false;
    }
}

