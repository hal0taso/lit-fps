using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject sparks;
	public GameObject playerCamera;
	public GameObject hitsound;
	public AudioSource audio;
	Ray ray;
	RaycastHit hit;

	float shotInterval = 0.1f;
	
	// Update is called once per frame
	void Update () {

		//when mouse button down
		if (Input.GetMouseButtonDown(0)){
			sparks.SetActive(true);
		}

		//when mouse button up
		if (Input.GetMouseButtonUp (0)) {
			sparks.SetActive (false);
		}
		//between mouse button down
		if (Input.GetMouseButton(0)){
			shotInterval -= Time.deltaTime;
			if (shotInterval < 0) {
				shotInterval =0.1f;
				Shot();
			}
		}
	}

	void Shot () {
		audio.PlayOneShot (audio.clip);
		Vector3 center = new Vector3 (Screen.width / 2, Screen.height / 2, 0);
		ray = playerCamera.camera.ScreenPointToRay (center);
		if (Physics.Raycast (ray,out hit,100)) {
			//Debug.Log (hit.point);
			GameObject se = Instantiate (hitsound, hit.point, Quaternion.identity) as GameObject;
			Destroy(se.gameObject, 0.6f);

		}
		Debug.DrawLine (ray.origin, ray.direction * 100, Color.yellow);
	}
}
