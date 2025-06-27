using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NoiseGen : MonoBehaviour
{
  public BoundsInt tileBounds = new BoundsInt(0, 0, 0, 100, 100, 1);
  public Tilemap Terrain, Blockables, Unwalkable, LargeObjects, SmallDecals;
  public List<float> octaves, weights;
  private float[,] _data, _data2;
  public List<TileBase> tiles;
  public List<float> tileThresholds;
  // Start is called before the first frame update
  void Start()
  {
    if (octaves.Count > weights.Count) return;
    _data = new float[tileBounds.size.x, tileBounds.size.y];
    //Zero out all of our data
    for (int i = 0; i < tileBounds.size.x; i++)
    {
      for (int j = 0; j < tileBounds.size.y; j++)
      {
        _data[i, j] = 0;
      }
    }
    //Assigning a value to seed randomizes our terrain. Without this,
    //it's the same "random" orientation every time.
    SimplexNoise.Noise.Seed = (int)DateTime.Now.Ticks;
    //For each octave
    for (int z = 0; z < octaves.Count; z++)
    {
      //Calculate a noise map
      _data2 = SimplexNoise.Noise.Calc2D(tileBounds.size.x, tileBounds.size.y, octaves[z]);
      //Then apply it to our terrain data by weight
      for (int i = 0; i < tileBounds.size.x; i++)
        for (int j = 0; j < tileBounds.size.y; j++)
          _data[i, j] += _data2[i, j] * weights[z];
    }
    int tileIndex = 0;
    for (int i = 0; i < tileBounds.size.x; i++)
    {
      for (int j = 0; j < tileBounds.size.y; j++)
      {
        //_data[i,j] = 0-255
        for (int k = 0; k < tileThresholds.Count; k++)
        {
          if (_data[i, j] > tileThresholds[k]) continue;
          else { tileIndex = k; break; }
        }
        //if (tileIndex > 0)//todo: put in logic to let the user determine if a particular block is blockable or not
        {
          Terrain.SetTile(new Vector3Int(tileBounds.position.x + i, tileBounds.position.y + j, 0), tiles[tileIndex]);
          Terrain.SetTileFlags(new Vector3Int(tileBounds.position.x + i, tileBounds.position.y + j, 0), TileFlags.None);
          Terrain.SetColor(new Vector3Int(tileBounds.position.x + i, tileBounds.position.y + j, 0), new Color((_data[i, j] / 255f), (_data[i, j] / 255f), (_data[i, j] / 255f)));
          Debug.Log($"Tile at ({i}, {j}) set to index {tileIndex} with value {_data[i, j]}");
        }
        /*else
        {
            Unwalkable.SetTile(new Vector3Int(i, j, 0), tiles[tileIndex]);
            Unwalkable.SetTileFlags(new Vector3Int(i, j, 0), TileFlags.None);
            //Unwalkable.SetColor(new Vector3Int(i, j, 0), new Color((_data[i, j] / 255f), (_data[i, j] / 255f), (_data[i, j] / 255f)));
        }*/
      }
    }
  }

  // Update is called once per frame
  void Update()
  {

  }
}
