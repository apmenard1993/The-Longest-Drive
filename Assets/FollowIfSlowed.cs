using UnityEngine;
using System.Collections;

public class FollowIfSlowed : MonoBehaviour {
	public GameObject car;
	public GameObject kzBase;
	private float increase = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = new Vector3 (car.transform.position.x, car.transform.position.y, kzBase.transform.position.z - 50f);
		float cVel = car.GetComponent<Rigidbody> ().velocity.magnitude;
		print ("cVel= " + cVel);
		print ("increase= " + increase);
		if (cVel < 15){
			increase += 0.1f;
		}
		if (cVel > 20) {
			increase = 0.0f;
		}
		Vector3 inc = new Vector3 (0, 0, increase);
		pos += inc;
		transform.position = pos;
	}
}
