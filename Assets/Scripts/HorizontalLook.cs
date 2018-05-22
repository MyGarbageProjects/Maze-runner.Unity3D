using UnityEngine;
using System.Collections;

public class HorizontalLook : MonoBehaviour {

	[SerializeField] Transform characterTransform;
	[SerializeField] private SpaceControl space_control;

	void FixedUpdate (){
		if (!space_control.PAUSE) {
			characterTransform.Rotate(0, Input.GetAxis("Mouse X") * SpaceControl.sensitivity,0);
		}
	}
}
