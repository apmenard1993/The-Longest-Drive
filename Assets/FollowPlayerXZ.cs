using UnityEngine;
using System.Collections;

public class FollowPlayerXZ : MonoBehaviour {
	public GameObject car;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = new Vector3 (car.transform.position.x, transform.position.y, car.transform.position.z);
		transform.position = pos;

	}
}
