using UnityEngine;
using UnityEngine.Tilemaps;
 
public class HighLightCrntCell : MonoBehaviour
{
    public Tile highlightTile;
    public Tilemap highlightMap;
 
    private Vector3Int previous;
 
    // do late so that the player has a chance to move in update if necessary
    private void LateUpdate()
    {
        // get current grid location
        Vector3Int currentCell = highlightMap.WorldToCell(transform.position);
        // add one in a direction (you'll have to change this to match your directional control)
        //currentCell.x += 1;
        //lol this was just the direction, just get rid of to do under the char...
        //could use simple thing like this to start for picking where you are going to move next..
 
        // if the position has changed
        if(currentCell != previous)
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