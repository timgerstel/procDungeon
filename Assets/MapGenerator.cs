using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {
    int[,] map;

    public int width, height;
    public string seed;
    public bool randomMap;

    [Range(0, 100)]
    public int randomFillPercent;

    void Start(){
        GenerateMap();
    }


    void Update(){
        if (Input.GetMouseButton(0))
        {
            GenerateMap();
        }
    }

    void GenerateMap(){
        map = new int[width, height];

        GenerateRandomMap();
    }

    void GenerateRandomMap() {
        if (randomMap) {
            seed = Time.time.ToString();
        }

        System.Random rng = new System.Random(seed.GetHashCode());

        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                if (x == 0 || x == width - 1 || y == 0 || y == height - 1) { 
                    map[x, y] = 1;
                } else {
                    map[x, y] = (rng.Next(0, 100) < randomFillPercent) ? 1 : 0;
                }
            }
        }
    }

    private void OnDrawGizmos(){
        if(map != null){
            for(int x = 0; x < width; x++){
                for(int y = 0; y < height; y++)
                {
                    Gizmos.color = (map[x, y] == 1) ? Color.black : Color.white;
                    Vector3 pos = new Vector3(-width / 2 + x + 0.5f, 0, -height / 2 + y + 0.5f);
                    Gizmos.DrawCube(pos, Vector3.one);
                }
            }
        }
    }
}
