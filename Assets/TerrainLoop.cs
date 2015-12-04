using UnityEngine;
using System.Collections;

public class TerrainLoop : MonoBehaviour {

	public GameObject[] levelParts;
	public GameObject car;
	private int size;
	// Use this for initialization
	void Start () {
		size = levelParts.Length;
	}
	
	// Update is called once per frame
	void Update () {
		//if car position comes within 100 of the last piece
		//take first and move to end, rotating the list appropriately and setting the coins to active again
		if ((levelParts [size - 1].transform.position.z - car.transform.position.z) < 100) {
			Vector3 newPos = levelParts[0].transform.position;
			newPos.z += 100*levelParts.Length;
			levelParts[0].transform.position = newPos;

			foreach(Transform child in levelParts[0].transform){
				if(child.name == "Coins"){
					foreach(Transform coin in child.transform){
						coin.gameObject.SetActive(true);
					}
				}
			}

			GameObject holder = levelParts[0];
			for(int i = 0; i < size - 1; i++){
				levelParts[i] = levelParts[i+1];
			}
			levelParts[size - 1] = holder;
		}
	}
}
