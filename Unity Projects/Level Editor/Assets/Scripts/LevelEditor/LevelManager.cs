using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]
public struct Tile{
    public float x, y, z;
    public int id;

    public Tile(float x, float y, float z, int id){
        this.x = x;
        this.y = y;
        this.z = z;
        this.id = id;
    }
}

//This script is attached to the tile editor object
public class LevelManager : MonoBehaviour{
    
    public TileManager[] tilesPrefabs;
    public string path = @"C:\Levels\MyLevel.bin";

    TileManager[] tiles;
    
    public void Save(){
        Debug.Log("Saving...");

        tiles = GameObject.FindObjectsOfType<TileManager>();
        Tile[] save = new Tile[tiles.Length];

        for(int i = 0; i < save.Length; i++){
            save[i] = new Tile(tiles[i].transform.position.x,
                tiles[i].transform.position.y,
                tiles[i].transform.position.z,
                tiles[i].id
            );
        }

        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(path,
                                    FileMode.Create,
                                    FileAccess.Write,
                                    FileShare.None);
        formatter.Serialize(stream, save);
        stream.Close();
    }

    public void Load(){
        Debug.Log("Loading...");
        Clear();
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(path,
                                    FileMode.Open,
                                    FileAccess.Read,
                                    FileShare.Read);
        var loadTiles = (Tile[])formatter.Deserialize(stream);
        stream.Close();

        for(int i = 0; i < loadTiles.Length; i++){
            Instantiate(tilesPrefabs[loadTiles[i].id], 
                        new Vector3(loadTiles[i].x, loadTiles[i].y, loadTiles[i].z),
                        Quaternion.identity);
        }
    }

    private void Clear(){
        tiles = GameObject.FindObjectsOfType<TileManager>();
        foreach(var x in tiles){
            Destroy(x.gameObject);
        }
    }
}
