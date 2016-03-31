using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour
{

    public int columns = 5;
    public int rows = 5;

    public GameObject tile;
    public Transform BoardParent;
    public Texture2D source;
    public List<Tile> Grids = new List<Tile>();

    public byte[] result;

    public void Start()
    {
        string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "source.jpg");

        result = System.IO.File.ReadAllBytes(filePath);
        source = new Texture2D(50, 50);
        source.LoadImage(result);
        SetupScene();
    }

    public void SetupBoard()
    {
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                GameObject instance = Instantiate(tile, new Vector2(i, j), Quaternion.identity) as GameObject;
                instance.transform.SetParent(BoardParent);
                instance.name = i + " x " + j;
                Grids.Add(instance.GetComponent<Tile>());
                instance.GetComponent<SpriteRenderer>().color = GetColorPerPixel(i, j);
                instance.GetComponent<Animator>().SetTrigger(Random.Range(1, 5).ToString());
            }
        }
    }



    public void SetupScene()
    {
        SetupBoard();
        //BoardParent.transform.position = new Vector2(-columns / 2, -rows / 2);
    }
    public Color GetColorPerPixel(int x, int y)
    {
        return source.GetPixel(x, y);
    }
    public Color GetColorPerPixel(Vector2 pos)
    {
        return source.GetPixel((int)pos.x, (int)pos.y);
    }
}
