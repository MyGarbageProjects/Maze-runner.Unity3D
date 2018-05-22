using UnityEngine;
using System.Collections;
using System;

public class GameLogic : MonoBehaviour {
	// Use this for initialization
	[SerializeField] GameObject PrefabWall;
	[SerializeField] Transform Player;
	[SerializeField] Camera Minimap;
	[SerializeField] SpaceControl space_control;
	[SerializeField] Transform FinishLight;
	private int size = 0;
	void Start () {
		Maze maze = new Maze (PrefabWall);
		string str = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory +"maze.maze");
		char[][] matrix_maze = maze.LoadMaze2(AppDomain.CurrentDomain.BaseDirectory +"mazes/"+str);
		int[] posPlayer = maze.DrawMaze2 (matrix_maze);
		Player.localPosition = new Vector3 (posPlayer [0], Player.position.y ,posPlayer [1]);
		Minimap.orthographicSize = matrix_maze.Length / 2;
		size = matrix_maze.Length / 2;
		//Debug.Log (String.Format("Size cam:{0}",matrix_maze.Length/2));
		FinishLight.position = new Vector3(size, FinishLight.position.y, -size);
	}
	
	// Update is called once per frame
	void Update () {
		if (!space_control.PAUSE) {
			float x = Player.position.x;
			float y = Player.position.z;

			if (((x < -size) && (y > size)) || ((x > size) && (y > size)) || ((x < -size) && (y < -size)) || ((x > size) && (y < -size))) {
				space_control.Win ();
			}
		}
	}
}
