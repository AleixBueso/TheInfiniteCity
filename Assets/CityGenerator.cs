using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=xkuniXI3SEE

public class CityGenerator : MonoBehaviour {

    [Header("GameObjects")]
    public GameObject[] buildings;
    public GameObject xStreet;
    public GameObject zStreet;
    public GameObject crossStreet;

    [Header("Preferences")]
    public bool perlinNoise = true;
    public int mapWidth;
    public int mapHeight;
    int buildingFootprint = 3;
    public int[] rotations;

    [Header("Hierarchy")]
    public GameObject buildingsParent;
    public GameObject streetParent;

    [Header("Map")]
    public int[,] MapMatrix = new int[20, 20];

    int[,] mapGrid;



    // Use this for initialization
    void Start () {

        GenerateCity(perlinNoise);
    }

    void GenerateCity(bool perlin)
    {
        mapGrid = new int[mapWidth, mapHeight];

        if (perlin)
        {
            //Generate map data
            for (int h = 0; h < mapHeight; h++)
            {
                for (int w = 0; w < mapWidth; w++)
                {
                    mapGrid[w, h] = (int)(Mathf.PerlinNoise(w / 10.0f, h / 10.0f) * 10);
                }
            }
        }

        else
        {
            //Generate map data
            for (int h = 0; h < mapHeight; h++)
            {
                for (int w = 0; w < mapWidth; w++)
                {
                    mapGrid[w, h] = Random.Range(0, 10);
                }
            }
        }

        //Build streets
        int x = 0;

        for (int i = 0; i < 50; i++)
        {
            for (int h = 0; h < mapHeight; h++)
                mapGrid[x, h] = -1;

            x += Random.Range(2, 10);
            if (x >= mapWidth)
                break;
        }

        int z = 0;

        for (int i = 0; i < 50; i++)
        {
            for (int w = 0; w < mapWidth; w++)
            {
                if (mapGrid[w, z] == -1)
                    mapGrid[w, z] = -3;
                else
                    mapGrid[w, z] = -2;
            }

            z += Random.Range(2, 10);
            if (z >= mapHeight)
                break;
        }

        //Generate city
        for (int h = 0; h < mapHeight; h++)
        {
            for (int w = 0; w < mapWidth; w++)
            {
                int gridVal = mapGrid[w, h];
                Vector3 pos = new Vector3(w * buildingFootprint, 0, h * buildingFootprint);

                if (gridVal < -2)
                    Instantiate(crossStreet, pos, crossStreet.transform.rotation, streetParent.transform);
                else if (gridVal < -1)
                    Instantiate(xStreet, pos + new Vector3(-3, 0, 0), xStreet.transform.rotation, streetParent.transform);
                else if (gridVal < 0)
                    Instantiate(zStreet, pos + new Vector3(0, 0, -3), zStreet.transform.rotation, streetParent.transform);
                else if (gridVal < 2)
                    Instantiate(buildings[0], pos, Quaternion.Euler(0, rotations[Random.Range(0, rotations.Length)], 0), buildingsParent.transform);
                else if (gridVal < 4)
                    Instantiate(buildings[1], pos, Quaternion.Euler(0, rotations[Random.Range(0, rotations.Length)], 0), buildingsParent.transform);
                else if (gridVal < 6)
                    Instantiate(buildings[2], pos, Quaternion.Euler(0, rotations[Random.Range(0, rotations.Length)], 0), buildingsParent.transform);
                else if (gridVal < 8)
                    Instantiate(buildings[3], pos, Quaternion.Euler(0, rotations[Random.Range(0, rotations.Length)], 0), buildingsParent.transform);
                else if (gridVal < 10)
                    Instantiate(buildings[4], pos, Quaternion.Euler(0, rotations[Random.Range(0, rotations.Length)], 0), buildingsParent.transform);
            }

        }
    }
}
