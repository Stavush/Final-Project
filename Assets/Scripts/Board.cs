using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private int columns;
    [SerializeField] private int rows;
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private GameObject allTiles;
    [SerializeField] private GameObject[] squares;
    [SerializeField] private GameObject[,] allSquares;

    private Tile[,] tiles;

    void Start()
    {
        tiles = new Tile[columns, rows];
        allSquares = new GameObject[columns, rows];
        Launch();
    }


    private void Launch()
    {
        for (int col = 0; col < columns; col++)
        {
            for (int row = 0; row < rows; row++)
            {
                Vector2 tempPosition = new Vector2(col, row);
                GameObject tile = Instantiate(tilePrefab, tempPosition, Quaternion.identity) as GameObject;
                tile.transform.parent = this.transform;
                tile.name = "(" + col+", "+ row+ ")";
                int squareToUse = Random.Range(0, squares.Length);
                GameObject square = Instantiate(squares[squareToUse], tempPosition, Quaternion.identity);
                square.transform.parent = this.transform;
                square.name = "(" + col + ", " + row + ")";
                allSquares[col, row] = square;
            }
        }
    }
}
