using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointCreator : MonoBehaviour
{
    [SerializeField]
    private float _WaypointDistance = 0.01f;    //DISTANCE REQUIRED TO MOVE TO NEXT WAYPOINT
    [SerializeField]
    private float _MovementSpeed = 0.1f;          //TRAVEL SPEED

    private Vector3[] _Waypoints;               //COLLECTION OF WAYPOINTS
    private int _CurrentWaypointIndex;          //TRACKS WAYPOINT INDEX
    private Vector3 _CurrentWaypoint;           //TRACKS CURRENT WAYPOINT TO MOVE TO

    void Start()
    {
        _Waypoints = new Vector3[]                              //INITIALIZE WAYPOINTS
        {
            new Vector3(1.66f, 9.18f, -2.37f),                               //WAYPOINT 1
            new Vector3(1.60f, 9.25f, -2.60f),                              //WAYPOINT 2
            new Vector3(1.43f, 9.17f, -2.86f),                             //WAYPOINT 3
            new Vector3(1.22f, 9.43f, -3.10f),                              //WAYPOINT 4
            new Vector3(4.84f, 4.69f, 8.09f),
            new Vector3(5.30f, 4.70f, 10.07f),
            new Vector3(4.05f, 4.11f, 11.81f),
            new Vector3(3.62f, 4.02f, 12.60f),
            new Vector3(1.95f, 3.14f, 13.49f)
        };
        _CurrentWaypointIndex = 0;                              //INITIAL WAYPOINT INDEX
        _CurrentWaypoint = _Waypoints[_CurrentWaypointIndex];   //INTIAL WAYPOINT
    }

    void Update()
    {
        if (Vector3.Distance(_CurrentWaypoint, transform.position) < _WaypointDistance) //IF WAYPOINT REACHED -> UPDATE WAYPOINT
        {
            _CurrentWaypointIndex++;                                                    //INCREMENT INDEX

            if (_CurrentWaypointIndex < 0)                                              //CURRENT INDEX WENT NEGATIVE
                _CurrentWaypointIndex = 0;                                              //RESET WAYPOINT

            _CurrentWaypoint = _Waypoints[_CurrentWaypointIndex % _Waypoints.Length];   //GET NEXT WAYPOINT
        }
        else
            transform.position = Vector3.MoveTowards(                                   //MOVE TO WAYPOINT
                                transform.position,
                                _CurrentWaypoint,
                                _MovementSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()                         //DEBUGGING DISPLAY
    {
        if (_Waypoints != null)                          //IF WAYPOINTS EXIST
        {
            foreach (Vector3 waypoint in _Waypoints)    //ITERATE ALL WAYPOINTS
            {
                Gizmos.DrawSphere(waypoint, 0.1f);      //DRAW SPHERE AT CURRENT WAYPOINT
            }
        }
    }
}
