using UnityEngine;
using System.Collections;
using System.IO;
using System.Linq;

public class Maze{
	GameObject PrefabWall;
	public Maze(GameObject PrefabWall){
		this.PrefabWall = PrefabWall;
	}

//	public byte[][] LoadMaze(string path){
//		string read_d = File.ReadAllText(path);
//		string[] separator = { "\r\n" };
//		string[] _tempGraph = read_d.Split(separator, System.StringSplitOptions.None);
//		byte[][] matrix_maze = new byte[_tempGraph.Length][];//Matrix maze
//
//		for (int i = 0; i < matrix_maze.Length; i++)
//		{
//			Debug.Log (_tempGraph [i]);
//			matrix_maze[i] = _tempGraph[i].Trim().Split().Select<string,byte>(byte.Parse).ToArray();
//		}
//
//		return matrix_maze;
//	}

	public char[][] LoadMaze2(string path){
		string read_d = File.ReadAllText(path);
		string[] separator = { "\r\n" };
		string[] _tempGraph = read_d.Split(separator, System.StringSplitOptions.None);
		char[][] matrix_maze = new char[_tempGraph.Length][];//Matrix maze

		for (int i = 0; i < matrix_maze.Length; i++)
		{
			matrix_maze[i] = _tempGraph[i].Trim().Split().Select<string,char>(char.Parse).ToArray();
		}

		return matrix_maze;
	}

//	public void DrawMaze(byte[][] MatrixMaze){
//		//GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
//		//Debug.Log (MatrixMaze.GetLength(1).ToString ());
//		int w = MatrixMaze.Length;
//		int h = MatrixMaze [0].Length;
//		//cube.transform.localScale = new Vector3 (w, -0.1f,h);//Ширина-высота-длинна
//		//MonoBehaviour.Instantiate (cube, new Vector3 (5, 0, 5),Quaternion.identity);
//
//		GameObject wall = GameObject.CreatePrimitive (PrimitiveType.Cube);
//		wall.transform.localScale = new Vector3 (1, 3, 1);
//
//		for (int x = w/2*-1,i=0; i < MatrixMaze.Length; x++,i++) {
//			for (int y = h/2,j=0; j < MatrixMaze[0].Length; y--,j++) {
//				if (MatrixMaze [i] [j] == 1) {
//					MonoBehaviour.Instantiate (wall, new Vector3 (x, wall.transform.localScale.y/2 , y),Quaternion.identity);
//				}
//				//Debug.Log (string.Format ("X:{0} Y:{1}", x, y));
//			}
//			//break;
//		}
//	}


	public int[] DrawMaze2(char[][] MatrixMaze){

		int[] posPlayer = new int[2];

		int w = MatrixMaze.Length;
		int h = MatrixMaze [0].Length;


		GameObject start = GameObject.CreatePrimitive(PrimitiveType.Cube);
		GameObject finish = GameObject.CreatePrimitive(PrimitiveType.Cube);
		start.transform.localScale = new Vector3 (1, 0.01f, 1);
		finish.transform.localScale = new Vector3 (1, 0.01f, 1);
		MonoBehaviour.Destroy (start);
		MonoBehaviour.Destroy (finish);

		Material mstart = (start as GameObject).GetComponent<Renderer> ().material;
		Material mfinish = (finish as GameObject).GetComponent<Renderer> ().material;
		mstart.color = Color.red;
		mfinish.color = Color.green;
		start.GetComponent<BoxCollider> ().enabled = false;
		finish.GetComponent<BoxCollider> ().enabled = false;

		for (int x = w/2*-1,i=0; i < MatrixMaze.Length; x++,i++) {
			for (int y = h/2,j=0; j < MatrixMaze[0].Length; y--,j++) {

				if (MatrixMaze [i] [j] == 'S') {
					//start.transform.localPosition = new Vector3 (x, 0.05f, y);
					MonoBehaviour.Instantiate (start, new Vector3 (x, 0.05f, y), Quaternion.identity);
					posPlayer [0] = x;posPlayer [1] = y;
				}

				else if (MatrixMaze [i] [j] == 'F')
					MonoBehaviour.Instantiate (finish, new Vector3 (x, 0.05f, y), Quaternion.identity);
					//finish.transform.localPosition = new Vector3 (x, 0.05f, y);

				if (MatrixMaze [i] [j] == '1') {
					MonoBehaviour.Instantiate (PrefabWall, new Vector3 (x, PrefabWall.transform.localScale.y/2 , y),Quaternion.identity);
				}
			}
		}

		return posPlayer;
	}
}
