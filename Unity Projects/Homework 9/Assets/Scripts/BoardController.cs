using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    public static BoardController instance;

    [Header("Tile Prefab")]
    public GameObject tile;
    public int height = 0;
    public int width = 0;
    [SerializeField] 
    private GameObject[] board;
    public int[] selectedTiles;
    public int counter;

    private void Start()
    {
        instance = this;
        GenerateBoard(3,3);
    }
    
    public void GenerateBoard(int height, int width)
    {
        this.height = height;
        this.width = width;
        
        GameObject[] tiles = new GameObject[height*width];
        for (int i = 0; i < height*width; i++)
        {
            tiles[i] = tile;
        }
        board = tiles;

        DisplayBoard();
    }
    private void DisplayBoard()
    {
        int i = 0;
        for (int w = 0; w < width; w++)
        {
            for (int h = height; h > 0; h--)
            {
                Vector3 position = new Vector3(w-width/2, h-height, 0);
                board[i] = Instantiate(tile, position, Quaternion.identity);
                i+=1;
            }
        }

        HiglightTiles();
    }

    private void HiglightTiles()
    {
        int[] randomTilesIndex = Random(height * width);
        int score = ScoreController.currentScore;
        int tilesNum = ((width/2)+score);

        selectedTiles = new int[tilesNum];

        Debug.Log("Tiles num: " + tilesNum);

        for(int i = 0; i < tilesNum; i++)
        {
            TileController tempTile = board[randomTilesIndex[i]].GetComponentInChildren<TileController>();
            tempTile.HiglightTile();
            tempTile.isPattern = true;
            selectedTiles[i] = randomTilesIndex[i];

        }
    }

    private int[] Random(int n){
        int[] nums = new int[n];
        int[] tmp = new int[n];

        for(int i = 0; i < n; i++)
        {
            nums[i] = i;
        }

        for (int t = 0; t < nums.Length; t++ )
        {
            tmp[t] = nums[t];
            int r = UnityEngine.Random.Range(0,nums.Length);
            nums[t] = nums[r];
            nums[r] = tmp[t];
        }
        return nums;
    }
}
