using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PathWalker : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform startCircle;
    public Transform endCircle;

    //path given now, will be generated on future denizon
    public List<Vector3> path;
    public LevelBuilder levelBuilder; //just doing this here with path above since its already set, will pull out on to its own denizon later
    //or have it auto gen new path and next thing each time too idk

    public int crntIndex;
    public void WandererInit()
    {
        //  triggerNew = true;
        //crntIndex = 0;
        //wanderer.transform.position = crntPath[crntIndex];

    }


    private Vector3 direction;

    // public Tilemap fogOfWar;
    public Grid mainGrid;
    public Vector3 gridCellSize;
    public float gridX;
    public float gridY;
    public float gridZ;



    void Start()
    {
        //  path = levelBuilder.crntPath; //must wait for the path to actualyl be made HEEHEE
        crntIndex = 0;
        gridCellSize = mainGrid.cellSize;
        gridX = gridCellSize.x;
        gridY = gridCellSize.y;
        gridZ = gridCellSize.z;
    }
    public int lastIndex;
    void PathLoad()
    {
        path = levelBuilder.crntPath;
        crntIndex = 0; //last visited index?
        lastIndex = 0;
        transform.position = path[0];
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            PathLoad();
        }
        if (Input.GetKeyDown("space"))
        {
            if (transform.position.x < path[crntIndex + 1].x)
            {
                direction = new Vector3((gridX), 0f);//(-1f,0f);
                transform.position += direction;
            }

            if (transform.position.x > path[crntIndex + 1].x)
            {
                direction = new Vector3(-gridX, 0f);//(1f,0f);
                transform.position += direction;
            }
            if (transform.position.y < path[crntIndex + 1].y)
            {
                direction = new Vector3(0f, (gridY));//(0f,-1.5f); //should set these programatically (get cell size)
                transform.position += direction;
            }
            if (transform.position.y > path[crntIndex + 1].y)
            {
                direction = new Vector3(0f, -gridY);//(0f, 1.5f);
                transform.position += direction;

            }

            if (transform.position == path[crntIndex+1])
            {
                crntIndex +=1;
            }

            // if (transform.position.x < path[crntIndex + 1].x)
            // {
            //     transform.position += new Vector3(1f, 0, 0);//if my x is less than path's x, move RIGHT to get closer
            //     if (transform.position.x >= path[crntIndex + 1].x)
            //     {
            //         crntIndex += 1;
            //     }
            // }
            // else if (transform.position.x > path[crntIndex + 1].x)
            // {
            //     transform.position += new Vector3(-1f, 0, 0);//if my x is less than path's x, move RIGHT to get closer
            //     if (transform.position.x <= path[crntIndex + 1].x)
            //     {
            //         crntIndex += 1;
            //     }
            // }
            // else if (transform.position.y < path[crntIndex + 1].y)
            // {
            //     transform.position += new Vector3(0, -1.5f, 0);//if my x is less than path's x, move RIGHT to get closer
            //     if (transform.position.y >= path[crntIndex + 1].y)
            //     {
            //         crntIndex += 1;
            //     }
            // }
            // else if (transform.position.y > path[crntIndex + 1].y)
            // {
            //     transform.position += new Vector3(0, 1.5f, 0);//if my x is less than path's x, move RIGHT to get closer
            //     if (transform.position.y <= path[crntIndex + 1].y)
            //     {
            //         crntIndex += 1;
            //     }
            // }
        }



        //stand-in for events that trigger movement or doing stuff or whatever...
        //may be flags or user input on otherscripts or whatevsies

        // path = levelBuilder.crntPath; //get the path
        //determine if you need to move 
        //if next node is not near you?
        //if () //hm need to think of each node too...
        // 
        //if move, move towards next node by one space (for now, will add speed and recursion in a bit)
        //transform.position =+


        //if next node x is more than lat node x, move in x towards it, that kind of stuff?
        //need to do these things one at a time in case two or more moves would make it turn during,

    }

}


