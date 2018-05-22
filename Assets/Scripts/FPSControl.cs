using UnityEngine;
using System.Collections;

public class FPSControl : MonoBehaviour {

	[SerializeField] private SpaceControl space_control;

	[SerializeField] private float _walk = 5.0f;
	[SerializeField] private float _run = 12.0f;
	//[SerializeField] private float _gravity = -9.0f;
	[SerializeField] private float _JumpForce = 200.0f;
	[SerializeField] private bool _running = false;

	private bool _vertical = false;
	private bool _horizontal = false;
	private bool _jump = false;
	public bool _canjump = false;
	private float _deltaX;
	private float _deltaZ;
	private Vector3 _movement;

	Rigidbody _rb;
	Animator _animator;

	//private bool _pause = false;
	void Start () {
		_rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {

		if (!space_control.PAUSE) {
			//Коррекция скорости пемерещения
			float _speed = 0.0f;
			_vertical = Input.GetButton("Vertical");
			_horizontal = Input.GetButton("Horizontal");
			_running = Input.GetButton ("Run");
			_speed = !_running ? _walk : _run;
			//упарвление ходьбой
			_deltaZ = Input.GetAxis ("Vertical")*_speed;
			_deltaX = Input.GetAxis ("Horizontal")*_speed;

			_movement = new Vector3(_deltaX, 0, _deltaZ);
			_movement = Vector3.ClampMagnitude(_movement, _speed);
			_movement = transform.TransformDirection(_movement);

			//Событие 
			_jump = Input.GetButtonDown("Jump");



			if (_vertical || _horizontal) {
				transform.position += _movement * Time.deltaTime;

				//респаун
				if (transform.position.y < -20)
					transform.position = new Vector3 (0, 0, 0);
			}

			if(_jump & _canjump) {
				_canjump = false;
				_rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
				_rb.AddForce(0, _JumpForce, 0);

			}
		}
	}
		
	void OnCollisionStay(Collision colinfo)
	{
		_canjump = true;
	}
}