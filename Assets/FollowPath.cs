using UnityEngine;
using System.Collections;

using System.Linq;
using System.Text;



public class FollowPath : MonoBehaviour {

	public int NumberOfWayPoints = 9;
	public bool Looped = false;

	//List<Vector3> WayPoints = new List<Vector3>();
	Vector3[] WayPoints = new Vector3[10];
	bool Complete = false;
	int CurrentWayPoint = 0;
	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {
	
	}





	public Vector3 NextWayPoint(Vector3 CurrentPos)
	{
		float x = Random.Range (CurrentPos.x - 5.0f, CurrentPos.x + 5.0f);
		float y = Random.Range (CurrentPos.y - 5.0f, CurrentPos.y + 5.0f);
		float z = Random.Range (CurrentPos.z - 5.0f, CurrentPos.z + 5.0f);
		
		Vector3 waypoint = new Vector3 (x, y, z);
		return waypoint;

		//return null;
		}


	public bool IsLast()
	{
		if (NumberOfWayPoints >= CurrentWayPoint) {
			CurrentWayPoint = 0;
			Complete = true;
			return true;
				} 
		else {
			return false;
				}
	}


	public Vector3 AdvancedToNext(Vector3 position)
	{

		if (!Complete) {
			WayPoints[CurrentWayPoint] = NextWayPoint(position);
		}

		//float step = Speed * Time.deltaTime;
		//transform.position = Vector3.MoveTowards(transform.position, WayPoints., step);
		Vector3 temp = WayPoints [CurrentWayPoint];

		CurrentWayPoint++;
		IsLast ();
		Debug.Log ("Current:" + temp);
		return temp;
			
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(WayPoints [CurrentWayPoint], 0.5f);
	}



}
