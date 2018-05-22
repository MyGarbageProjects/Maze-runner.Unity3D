using UnityEngine;
using System.Collections;

public class VerticalLook : MonoBehaviour {

	//public float sensitivityVert = 9.0f;
	public float minimumVert = -45.0f;
	public float maxumumVert = 45.0f;
	private float angleX = 0.0f;
	[SerializeField] private SpaceControl space_control;

	void FixedUpdate () {
		if (!space_control.PAUSE) {
			angleX -= Input.GetAxis("Mouse Y") * SpaceControl.sensitivity;
			angleX = Mathf.Clamp(angleX, minimumVert, maxumumVert);

			float rotationY = transform.localEulerAngles.y;

			transform.localEulerAngles = new Vector3(angleX, rotationY, 0);
		}
	}
}
