// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Tilemaps;
// public class HighlighterMouseTile : MonoBehaviour
// {
//     public Tilemap highlightMap;
//        // public    Tilemap tilemap;

//     public TileBase highlightTile;

//     void Start()
//     {
//         Vector3Int previousTileCoordinate = Vector3Int.zero;

//     }
//     void Update()
//     {
//          //set the previously highlighted tile back to null
//          if(previousTileCoordinate != null)
//          {
//              highlightMap.SetTile(previousTileCoordinate, null);
//          }
 
 
//          //We need to highlight the tile on mousover. First get the curent position
//          Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//          Vector3Int tileCoordinate = highlightMap.WorldToCell(mouseWorldPos);
//          //store the current position for the next frame
//          previousTileCoordinate = tileCoordinate;
//          //set the current tile to the highlighted version
//          highlightMap.SetTile(tileCoordinate, highlightTile);
//  }
//       //This line outside the Update 
// //   public TileBase highlightTile;
  
  
// //   void Update() { 
        
// //       Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
// //       Vector3Int tileCoordinate = highlightMap.WorldToCell(mouseWorldPos);
  
// //       if(tileCoordinate != previousTileCoordinate ){
// //           highlightMap.SetTile(previousTileCoordinate, null);
// //           highlightMap.SetTile(tileCoordinate,highlightTile);
// //           previousTileCoordinate = tileCoordinate;     
// //       }
  
//     // Start is called before the first frame update



//     // Update is called once per frame

// }
