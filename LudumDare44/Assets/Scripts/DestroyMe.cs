using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DestroyMe : MonoBehaviour
{
	bool Used = false;
	public virtual int SleepTime { get; protected set; }
	protected abstract void Activate();
	public void RunAndPlaySound()
	{
		if (!Used)
		{
			Used = true;
			Activate();
		}
	}
}
