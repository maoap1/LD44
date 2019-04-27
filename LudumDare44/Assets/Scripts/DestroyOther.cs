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
	public override void Run() => Destroy(gameObject);
}

