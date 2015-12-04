using UnityEngine;
using System.Collections;

public class CameraFollowPlayer : MonoBehaviour {
    public Transform player;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2, player.transform.position.z - 5);
		this.transform.LookAt (player.position);
	}
}
