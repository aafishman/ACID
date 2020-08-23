using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private LayerMask obstacleMask;
    public enum movementType { hex, fourGrid, diaGrid };
    public movementType moveType = movementType.fourGrid;
    //Stores input from the PlayerInput
    private Vector2 movementInput;

    private Vector3 direction;

    public Tilemap fogOfWar;
    public Grid mainGrid;
    public Vector3 gridCellSize;
    public float gridX;
    public float gridY;
    public float gridZ;


    // private void Move(Vector3 direction) {
    //         Vector3 newPosition = movePoint.position + direction;
    //         if (!Physics2D.OverlapCircle(newPosition, 0.2f, obstacleMask)) {
    //             movePoint.position = newPosition;



    void Start()
    {
        gridCellSize = mainGrid.cellSize;
        gridX = gridCellSize.x;
        gridY = gridCellSize.y;
        gridZ = gridCellSize.z;
    }
    bool hasMoved;
    void Update()
    {
        if (movementInput.x == 0 && movementInput.y == 0)
        {
            hasMoved = false;
        }
        else if ((movementInput.x != 0 && !hasMoved) || (movementInput.y != 0 && !hasMoved))
        //else if ((movementInput.x != 0 ||(movementInput.y != 0 ))) //lol use this to watch him fly, does slightly fix issues lol as in one can see its on the right track...

        {
            hasMoved = true;


            //TODO: make hexmovement use cell grid size, test it out at some point i guess, look at 4grid
            if (moveType == movementType.hex)
                GetHexMovementDirection();
            else if (moveType == movementType.fourGrid)
                GetFourGridMovementDirection();
            else if (moveType == movementType.diaGrid)
                print("no diag movement created yet, make some code for it ok?");
        }

    }

    public void GetHexMovementDirection()
    {
        if (movementInput.x < 0)
        {
            if (movementInput.y > 0)
            {
                direction = new Vector3(-0.5f, 0.5f);
            }
            else if (movementInput.y < 0)
            {
                direction = new Vector3(-0.5f, -0.5f);
            }
            else
            {
                direction = new Vector3(-1, 0, 0);
            }
            transform.position += direction;
            UpdateFogOfWar();
        }
        else if (movementInput.x > 0)
        {
            if (movementInput.y > 0)
            {
                direction = new Vector3(0.5f, 0.5f);
            }
            else if (movementInput.y < 0)
            {
                direction = new Vector3(0.5f, -0.5f);
            }
            else
            {
                direction = new Vector3(1, 0, 0);
            }

            transform.position += direction;
            UpdateFogOfWar();
        }
    }
    //oh my bad movement is because of this?
    public void GetFourGridMovementDirection()
    {
        if (movementInput.x < 0)
        {
            direction = new Vector3(-(gridX), 0f);//(-1f,0f);
        }

        if (movementInput.x > 0)
        {
            direction = new Vector3(gridX, 0f);//(1f,0f);
        }
        if (movementInput.y < 0)
        {
            direction = new Vector3(0f, -(gridY));//(0f,-1.5f); //should set these programatically (get cell size)
        }
        if (movementInput.y > 0)
        {
            direction = new Vector3(0f, gridY);//(0f, 1.5f);
        }
        if (!Physics2D.OverlapCircle(transform.position + direction, 0.2f, obstacleMask))
        {
            transform.position += direction;
        }

        UpdateFogOfWar();
    }

    public void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.position -= direction;
    }

    public int vision = 1;

    void UpdateFogOfWar()
    {
        Vector3Int currentPlayerTile = fogOfWar.WorldToCell(transform.position);

        //Clear the surrounding tiles
        for (int x = -vision; x <= vision; x++)
        {
            for (int y = -vision; y <= vision; y++)
            {
                fogOfWar.SetTile(currentPlayerTile + new Vector3Int(x, y, 0), null);
            }

        }

    }
}
