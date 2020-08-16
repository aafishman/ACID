using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Toolbox;
public class FollowPath : MonoBehaviour
{
    // Start is called before the first frame update
    List<Vector3> path;
    LevelBuilder levelBuilder;

    public Vector3 cntLoc;
    void Start()
    {
        levelBuilder = GetComponent<LevelBuilder>();
        StartCoroutine (Wander());
    }
    Vector3 crntPathStart;
    Vector3 crntPathEnd;
    public bool pathReset = false;
    public int crntPathIndex = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            advance = true;
                        print("space key was pressed");

        }
        else advance = false;

        //move these to fixed or on coroutine\
        //names are confusing, should all just be path
        //some o these can be eliminated likely

        //crntPathStart = levelBuilder.startCircle.position;

        //crntPathStart = levelBuilder.endCircle.position;
        //path

        if (levelBuilder.crntPath != null && path != levelBuilder.crntPath) //if path has changed
        {
            crntPathStart = levelBuilder.startCircle.position;
            crntPathStart = levelBuilder.endCircle.position;
            path = levelBuilder.crntPath; //set to new path (this is inefficient listener whatever fix 4 real guy)
            pathReset = true;  //prolly won't need, index thing below is better...
            crntPathIndex = 0;

        }

        //     if (levelBuilder.crntPath != path)
        // {

        // }            path = levelBuilder.crntPath;
        // }
        // }
    }
    //need a reset for path stuff like when the path actually changes...
    //just also set if crnt path changes, doing it dumb anyawys right now...
    //just have this calculated per movement anyways...
    //should still use the linepath renderer stuff too tho
    public bool advance = true;
    IEnumerator Wander()
    {
        while (true)
        {
            if (advance == true)
            // while (advance == true)
            {
                //walk along path
                //advance location along path positions
                if (crntPathIndex + 1 < path.Count)
                {
                    //advance damn you!
                    transform.position = path[crntPathIndex];
                }
                //crntPathIndex += 1;
                yield return new WaitForEndOfFrame();
            }
        }
        //yield return new WaitForSeconds()
    }

    // //public void Wander()
    // {
    //     // foreach 
    //     // transform.Translate(path([i]);\
    //     //start at the beginning of the path
    //     //start walking towards the end point, along the path
    //     //stop at the end of the path or whatever
    //     //decide how to do the tick movement - if it is everyone on screen moves per tick and moves a distance
    //         //or is it people don't all move on the same tick structure
    //         //the first idea is the only one that will work if people don't all move at the same time
    //         //yeah going with this for now
    // }
}
