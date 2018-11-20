
using UnityEngine;

public class TerrainGenerator : MonoBehaviour {

    public int width = 256, height = 256, depth = 20;
    public float scale = 20.0f, offsetX = 100.0f, offsetY = 100.0f;

    private void Update()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;

        terrainData.size = new Vector3(width, depth, height);

        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
    }

    float[,] GenerateHeights()
    {
        float[,] heights = new float[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = CalculateHeights(x,y);
            }
        }
        return heights;
    }

    float CalculateHeights(int x, int y)
    {
        float xCoord = (float)x / width * scale + offsetX, yCoord = (float)y / height * scale + offsetY;
        return Mathf.PerlinNoise(xCoord, yCoord);
    }

}
