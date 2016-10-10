using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		transform.Rotate (new Vector3 (0, 0, -moveHorizontal*100) * Time.deltaTime);
	}
}
