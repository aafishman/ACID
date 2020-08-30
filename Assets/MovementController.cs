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
    private Vector3 lasDir;

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
        direction = Vector3.zero;
    }
    bool hasMoved;
    void Update()
    {
        if (movementInput.x == 0 && movementInput.y == 0)
       //if (direction ) //if a new button is pressed... yeah if a new button is pressed in, not about it letting go, so not just changin?, so if something was zero and isn't now.... ok?
       //if (lasDir.x !)
      // if (direction.x != movementInput.x)
        {
            hasMoved = false;
        }
        //TODO: how to get movement to go right lol....r n one has to wait for the first key to come up before hitting a second key that will register input - not printed either i think (like actualy is just not registere)
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
        //Keyboard.current[Key.Space].wasPressedThisFrame
        // if (Keyboard.current[Key.A].wasPressedThisFrame)
        // {
        //     print(" Akey pressed");
        //     direction = new Vector3(-(gridX), 0f);//(-1f,0f)

        //     if (!Physics2D.OverlapCircle(transform.position + direction, 0.2f, obstacleMask))
        //     {
        //         transform.position += direction;
        //     }
        // }
        // if (Keyboard.current[Key.D].wasPressedThisFrame)
        // {
        //     print(" Dkey pressed");
        //     if (!Physics2D.OverlapCircle(transform.position + direction, 0.2f, obstacleMask))
        //     {
        //         transform.position += direction;
        //     }
        // }
        // if (Keyboard.current[Key.W].wasPressedThisFrame)
        //     direction = new Vector3(gridX, 0f);//(1f,0f);
        // if (!Physics2D.OverlapCircle(transform.position + direction, 0.2f, obstacleMask))
        // {
        //     transform.position += direction;
        // }
        // {
        //     print("W key pressed");
        // }
        // if (Keyboard.current[Key.S].wasPressedThisFrame)
        //     direction = new Vector3(0f, gridY);//(0f, 1.5f);
        // if (!Physics2D.OverlapCircle(transform.position + direction, 0.2f, obstacleMask))
        // {
        //     transform.position += direction;
        // }
        // {
        //     print("S key pressed");
        //     direction = new Vector3(0f, -(gridY));//(0f,-1.5f); //should set these programatically (get cell size)
        //     if (!Physics2D.OverlapCircle(transform.position + direction, 0.2f, obstacleMask))
        //     {
        //         transform.position += direction;
        //     }
        // }

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
    public void Move(Vector3 direction)
    {
        if (!Physics2D.OverlapCircle(transform.position + direction, 0.2f, obstacleMask))
        {
            transform.position += direction;
        }
    }
    public void GetFourGridMovementDirection()
    {

        //consider something like the below instead of moving actual grid amouts, I think the idea is it counts grid postions and moves cell row, then converts it back
        //also this is NOT using dumb wierd input system that may or may not be the issue...
    //        private void Update()
    // {
    //     if (Input.GetKey(KeyCode.D))
    //     {
    //         Vector3Int positionInGrid = gridLayout.WorldToCell(transform.position);
    //         positionInGrid += new Vector3Int(1, 0, 0);
    //         transform.position = gridLayout.CellToWorld(positionInGrid);
    //     }
    // }
        if (movementInput.x < 0)
        {
            direction = new Vector3(-(gridX), 0f);//(-1f,0f)
            print(direction);
        }

        if (movementInput.x > 0)
        {
            direction = new Vector3(gridX, 0f);//(1f,0f);
            print(direction);
            
        }
        if (movementInput.y < 0)
        {
            direction = new Vector3(0f, -(gridY));//(0f,-1.5f); //should set these programatically (get cell size)
            print(direction);

        }
        if (movementInput.y > 0)
        {
            direction = new Vector3(0f, gridY);//(0f, 1.5f);
            print(direction);

        }
        Move(direction);
        // if (!Physics2D.OverlapCircle(transform.position + direction, 0.2f, obstacleMask))
        // {
        //     transform.position += direction;
        // }

        if (useFoW == true) UpdateFogOfWar();
    }
    public bool useFoW = false;
    public void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.position -= direction;
    }

    public int vision = 2;

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
