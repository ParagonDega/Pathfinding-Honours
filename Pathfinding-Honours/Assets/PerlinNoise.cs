
using UnityEngine;

public class PerlinNoise : MonoBehaviour {

    public int width = 256, height = 256;
    public float scale = 20, offsetX =100.0f, offsetY=100.0f;

    private void Start()
    {
        offsetX = Random.Range(0.0f, 99999.0f);
        offsetY = Random.Range(0.0f, 99999.0f);
    }

    private void Update()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = GenerateTexture();
    }
    Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(width, height);
        
        for(int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color colour = CalculateColour(x, y);
                texture.SetPixel(x, y, colour);
            }
        }
        texture.Apply();
        return texture;
    }
    Color CalculateColour(int x, int y)
    {
        float xCoord = (float)x / width * scale + offsetX, yCoord = (float)y / height * scale + offsetY;
        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        return new Color(sample, sample, sample);
    }
}
