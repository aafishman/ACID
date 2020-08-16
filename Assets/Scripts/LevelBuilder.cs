using System.Collections;
using System.Collections.Generic;
using Toolbox;
using UnityEngine;
using UnityEngine.Tilemaps;
  
public class LevelBuilder : MonoBehaviour
{
    public int width = 100;
    public int height = 100;
    public float perlinScale = 10f;
    public float wallThreshold = 0.5f;
    public int minPathLength = 10;
    public Tile wall;
    public float duration = 1f;
    public bool findPathOpenCell = true;

    public LineRenderer lineRenderer;
    public Transform startCircle;
    public Transform endCircle;

    Tilemap tilemap;
    List<Vector3Int> wallTiles;
    List<Vector3Int> groundTiles;

    public bool waitForWanderer = true;
    //feature flag above to switch it to not regenerating the map unless the wandere has made it to the end
    //will split off into its own thing for a person moving testing etc.

    void Start()
    {
        tilemap = GetComponent<Tilemap>();

        wallTiles = new List<Vector3Int>();
        groundTiles = new List<Vector3Int>();

        PerlinNoiseGrid noise = new PerlinNoiseGrid(width, height, perlinScale);

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector3Int pos = new Vector3Int(i, j, 0);

                if (noise[i, j] < wallThreshold)
                {
                    tilemap.SetTile(pos, wall);
                    wallTiles.Add(pos);
                }
                else
                {
                    groundTiles.Add(pos);
                }
            }
        }

        StartCoroutine(NextPath());
        //StartCoroutine(TickMove());
    }

//function to go through a path and insert nodes at all grid intersection points
//or in the center of each grid tile that it goes through

public void InsertPathInters(Vector3 path)
{
//takes a path and returns a path with all the interesections spliced in to use to travel and stuff so its not just the nodes
//so what, draw lines, check for tiles in the way... how would I do that... is that the best way to do it?
//could just move something real fast along the path and try to see what tiles on the grid are picked up?
//or do it so that the person moves towards the next way point, but get stopped at each center of new grid they get to?
//that should be better? Otherwise storing huge paths for people all the time...could be huge differences/distances, so many?
//can't think of way to just generate without tracking soemthing moving on it anyawys? So this way at least just one thing moving?
//hrm so...what it checks at each spot if it should stop or not based on its movement speed? Since tick based?

//ok so some movement questions
//does diagonal cost same as one more or is it two?
//its not along a path right? it should just be each actual grid?
//can do both in actuality...

//can advance them a long the path an amount relative to their speed OR
//advance them only in factors of grid, 0,1,2,3 and do something like use the remainder to decide if they get to advance in addition to the integer
//.8 movement speed, initial tick no move, next tick (.8 + .8 =1.6) is one square since over 1, next tick is (.6 +.8) = (1.4) so one more, then .4 +.8 = 1.2, then .2 + .8 = 1, then 0 = .8 = ZERO MOVE THIS TIME NICE
//1.4 movement speed, initial tick 1 move, next tick .4 + 1.4 = (1.8), one move, next tick is .8 + 1.4 = 2.2 so TWO MOVES (or spaces or grids or whatever), next one is .2 + 1.4 = 1.6 so one move ETC!!!
//yeah i kind of like this, it lets you try to time things to lol i like it yeah lets do that...

}

    public bool triggerNew = false;

    public GameObject wanderer; //the object that wanders.... or should this just be the damn sprite lol....
    //yeah lets just make it the sprite
    //should justh ave had that the whole time....

    //lol k
    //just add a 'move the sprite along the path thing...'
    //smae problem - is it continues or ticks per space or something
    //yeah still do the space thing?
public int crntIndex;
    // IEnumerator TickMove()
    // {
    //     while (true)
    //     {
    //         //get the crnt index we on
    //         //lol now i want it back on its own script ugh.
    //         wanderer.transform.position = crntPath[crntIndex];
    //         // print("wanderer.transform.position is: " + wanderer.transform.position);
    //         // print(crntPath.Count);

    //         if (crntIndex + 1 < crntPath.Count)
    //         {
    //             crntIndex += 1;
    //             // if (triggerNew == true)
    //             // {
    //             //     crntIndex = 0;
    //             //     triggerNew = false;
    //             // }
    //         }
    //         yield return new WaitForSeconds(.05f);
    //     }
    // }
    public Vector3 nextLoc;
    public float distToNextNode;
    public float denizonSpd = 1.5f; //will be set in denizon, just here to build.
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            wanderer.transform.position = crntPath[crntIndex];
            // print("wanderer.transform.position is: " + wanderer.transform.position);
            // print(crntPath.Count);

            if (crntIndex + 1 < crntPath.Count)
            {
                                nextLoc = crntPath[crntIndex+1];
                print ("distnace to next way point it: " + (wanderer.transform.position - nextLoc) + " OR " + Vector3.Distance(wanderer.transform.position, nextLoc));
                distToNextNode = Vector3.Distance(wanderer.transform.position, nextLoc);
                crntIndex += 1;
                // if (triggerNew == true)
                // {
                //     crntIndex = 0;
                //     triggerNew = false;
                // }

                //ok this is where i would start to build my goofy 'check distance to next node' and diretion and whatever and move towards it, keep going to if you have some moves left and it was too close?
                //get next node

            }
        }
    }
    
    public void WandererInit()
    {
      //  triggerNew = true;
        crntIndex = 0;
        wanderer.transform.position = crntPath[crntIndex];

    }

    IEnumerator NextPath()
    {
        while (true)
        {
        Vector3 start;
        Vector3 end;
        List<Vector3> path;

        do
        {
            start = tilemap.GetCellCenterWorld(RandomElement(groundTiles));

            List<Vector3Int> list = findPathOpenCell ? groundTiles : wallTiles;
            end = tilemap.GetCellCenterWorld(RandomElement(list));

           path = AStar.FindPathClosest(tilemap, start, end); //but how could I get the path of all nodes, like more ineffient in the code this comes from?
        } while (start == end || path == null || path.Count < minPathLength);
        path.Add(end);

        lineRenderer.positionCount = path.Count;
        lineRenderer.SetPositions(path.ToArray());
        crntPath = path;
        startCircle.position = start;
        endCircle.position = end;

        //triggerNew = true;
        WandererInit();
        yield return new WaitForSeconds(duration);
      //  print ("crnt index is: " +crntIndex);
        print ("path count is: " + crntPath.Count);
        //if (waitForWanderer == true && crntIndex == (crntPath.Count -1))//waits until the person gets to the end to restart - could add another sleep timer here if always want it to wait or something...
        
        //if (crntIndex == crntPath.Count)
        //StartCoroutine(NextPath()); //doesn't this actually restart it? Should be a while loop instead... This makes a NEW one dummies! Why people still do this? I'm not wrong... am i? amiii?
        
        //just make it a while loop when we actulaly do sopmethign with it
    }
    }
        public List<Vector3> crntPath;

    Vector3Int RandomElement(List<Vector3Int> list)
    {
        return list[Random.Range(0, list.Count)];
    }
}

