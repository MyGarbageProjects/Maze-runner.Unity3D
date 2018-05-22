using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SpaceControl : MonoBehaviour {
	public static float sensitivity = 1.5f;
	[SerializeField] bool _pause = false;
	[SerializeField] bool _mapShow = false;
	[SerializeField] bool win = false;
	[SerializeField] GameObject PlayerCam;
	[SerializeField] GameObject MapCam;
	[SerializeField] GameObject GUIMenu;

	void Start(){
		SetCursorState (false);
	}

	void SetCursorState(bool show) {
		Cursor.lockState = show?CursorLockMode.Confined:CursorLockMode.Locked;
		Cursor.visible = show?true:false;
	}

	public bool PAUSE{
		set{ _pause = value; }
		get{return _pause; }
	}

	public bool MAP_SHOW{
		set{ _mapShow = value; }
		get{return _mapShow; }
	}
		
	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (!win) {
				PAUSE = !PAUSE;
				if (PAUSE)
					ShowMenu ();
				else
					HideMenu ();
			}
		}

		if (Input.GetKeyDown (KeyCode.M)) {
			MAP_SHOW = !MAP_SHOW;
			if (MAP_SHOW) {
				MapCam.SetActive (true);
				PlayerCam.SetActive (false);
			} else {
				PlayerCam.SetActive (true);
				MapCam.SetActive (false);
			}
				
		}
	}

	public void Win(){
		PAUSE = true;
		win = true;
		ShowMenu (); 
	}

	public void Replay(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void CloseApp(){
		Application.Quit ();
	}

	private void ShowMenu(){
		GUIMenu.SetActive(true);
		SetCursorState (true);
	}

	private void HideMenu(){
		GUIMenu.SetActive(false);
		SetCursorState (false);
	}
}
