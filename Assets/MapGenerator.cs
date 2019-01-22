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

        RandomizeMap();
    }

    void RandomizeMap() {
        if (randomMap) {
            seed = Time.time.ToString();
        }

        System.Random rng = new System.Random(seed.GetHashCode()); //Not a proper random number generator

        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                if (x == 0 || x == width - 1 || y == 0 || y == height - 1) { 
                    map[x, y] = 1; //fill border of Map Generator Object with black
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
                    Vector3 pos = new Vector3(-width / 2 + x + 0.5f, 0, -height / 2 + y + 0.5f); //Center map generator obj from top down view
                    Gizmos.DrawCube(pos, Vector3.one);
                }
            }
        }
    }
}
