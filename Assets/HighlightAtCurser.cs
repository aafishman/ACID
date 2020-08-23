using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HighlightAtCurser : MonoBehaviour
{
    public Tile highlightTile;
    public Tilemap highlightMap;
    public Grid grid;

    private Vector3Int previous;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //could add function here to have the little guy go to where we presss, guess could just add all this on that person too - make them a 'click makes a new path for them,' and space moves them along it
    }
    private void LateUpdate()
    {

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int currentCell = grid.WorldToCell(mouseWorldPos);


        // get current grid location
        // Vector3Int currentCell = highlightMap.WorldToCell(transform.position);

        // add one in a direction (you'll have to change this to match your directional control)
        //currentCell.x += 1;
        //lol this was just the direction, just get rid of to do under the char...
        //could use simple thing like this to start for picking where you are going to move next..

        // if the position has changed
        if (currentCell != previous)
        {
            // set the new tile
            highlightMap.SetTile(currentCell, highlightTile);

            // erase previous
            highlightMap.SetTile(previous, null);

            // save the new position for next frame
            previous = currentCell;
        }
    }
}
