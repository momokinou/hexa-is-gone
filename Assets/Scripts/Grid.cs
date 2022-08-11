using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public float waterLevel = .4f;
    public float scale = .1f;
    public int size = 100;

    Cell[,] grid;
    private void Start()
    {
        float[,] noiseMap = new float[size, size];
        float xOffSet = Random.Range(-10000f, 10000f);
        float yOffSet = Random.Range(-10000f, 10000f);
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                float noiseValue = Mathf.PerlinNoise(x * scale + xOffSet, y * scale + yOffSet);
                noiseMap[x, y] = noiseValue;
            }
        }


                grid = new Cell[size, size];
        for(int y = 0; y < size; y++) {
            for (int x = 0; x < size; x++) {
                Cell cell = new Cell();
                float noiseValue = noiseMap[x, y];
                cell.isWater = noiseValue < waterLevel;
                grid[x, y] = cell;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                Cell cell = grid[x, y];
                if (cell.isWater)
                    Gizmos.color = Color.blue;
                else
                    Gizmos.color = Color.green;
                Vector3 pos = new Vector3(x, 0, y);
                Gizmos.DrawCube(pos, Vector3.one);
            }

        }
    }
}
