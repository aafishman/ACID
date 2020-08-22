using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toolbox;
using UnityEngine.Tilemaps;

public class ListFindPathSimple : MonoBehaviour
{
    public Transform startCircle;
    public Transform endCircle;
public Vector3 startPos;
public Vector3 endPos;
public Tilemap tilemap;
public Toolbox.LinePath path; //List<Vector3> path;
    public void GetPathNow()
    {
       startPos = startCircle.position;
       endPos = endCircle.position;
        path = AStar.FindLinePath(tilemap, startPos, endPos); //? why isn't this working at all.... tilemap all normal and stuff?

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GetPathNow();
        }
    }
}
