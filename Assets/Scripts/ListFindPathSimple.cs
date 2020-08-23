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
public Toolbox.LinePath linePath; //
public List<Vector3> vector3Path;
public List<Vector3Int> intPath;
    public void GetPathNow()
    {
       startPos = startCircle.position;
       endPos = endCircle.position;
        vector3Path = AStar.FindPath(tilemap, startPos, endPos); //? why isn't this working at all.... tilemap all normal and stuff?

    }

    public void GetNextStep()
    {
        //gets best next square on way to path, this way don't have to hold every tile in memory incase things get out of hand
        //just do another ai type search to store next step
        //oh wait need this called recursively based on how many moves they have and stuff
        //ok so we will combine functions later
        //this is just simple next step
    //            startPos = startCircle.position;
    //    endPos = endCircle.position;
    //     print(AStar.OpenCells(tilemap,startPos,endPos));
                //things returns 'opencells' i think is just one... could be the right way?
                //lollll so all that stuff i thikn is for findin the closest cell to the end point? wait still waht  i want...
             // print("closest cell is: " + AStar.ClosestCell(tilemap,startPos,endPos));

          // print("closest cell to enxt node is: " +  AStar.ClosestCell(AStar.OpenCells(tilemap, vector3Path[1], vector3Path[2]), start, goal);

    //get next node
    //

    }
    // Start is called before the first frame update
    void Start()
    {
//test
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
