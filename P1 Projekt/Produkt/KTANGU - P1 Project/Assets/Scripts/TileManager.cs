using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    [SerializeField] Tilemap hazardTilemap;
    [SerializeField] Tilemap safeTilemap;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3Int tilePos = new Vector3Int(0,0,0); 
            MakeHazardSafe(tilePos);
        }
    }

    public void MakeHazardSafe(Vector3Int tilePos)
    {
        TileBase hazardTile = hazardTilemap.GetTile(tilePos);
        hazardTilemap.SetTile(tilePos, null);

        safeTilemap.SetTile(tilePos, hazardTile);
    }
}
