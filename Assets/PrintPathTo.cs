using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Toolbox;

public class PrintPathTo : MonoBehaviour
{
    //public void ListPath
    public Tilemap tilemap;
    public Vector3 startPos;
    public Vector3 endPos;
    // Start is called before the first frame update

    
    void Start()
    {
    startPos = gameObject.transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        //List<Vector3> path = AStar.FindPath(tilemap, startPos, endPos);
        //print ("path is: " + path[0]);
        print (AStar.FindPath(tilemap, startPos, endPos));
    }
}
