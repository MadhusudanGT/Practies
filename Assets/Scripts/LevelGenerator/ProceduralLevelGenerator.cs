using UnityEngine;

public class ProceduralLevelGenerator : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public int gridWidth = 10;
    public int gridHeight = 10;
    public float tileSize = 1f;
    public Transform parent;

    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Vector3 position = new Vector3(x * tileSize, 0, y * tileSize);
                GameObject tile = tilePrefabs[Random.Range(0, tilePrefabs.Length)];
                GameObject obj = Instantiate(tile, position, Quaternion.identity);
                obj.transform.SetParent(parent);
            }
        }
    }
}
