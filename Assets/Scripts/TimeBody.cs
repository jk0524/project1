using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour {

	bool isRewinding = false;

	public float recordTime = 5f;

	List<Vector3> positions;


	// Use this for initialization
	void Start () {
		positions = new List<Vector3>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return))
			StartRewind();
		if (Input.GetKeyUp(KeyCode.Return))
			StopRewind();
	}

	void FixedUpdate ()
	{
		if (isRewinding)
			Rewind();
		else
			Record();
	}

	void Rewind ()
	{
		if (positions.Count > 0)
		{
			Vector3 pointInTime = positions[0];
            transform.position = pointInTime;
			positions.RemoveAt(0);
		} else
		{
			StopRewind();
		}
		
	}

	void Record ()
	{
		if (positions.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
		{
			positions.RemoveAt(positions.Count - 1);
		}

		positions.Insert(0, transform.position);
	}

	public void StartRewind ()
	{
		isRewinding = true;
	}

	public void StopRewind ()
	{
		isRewinding = false;
	}
}