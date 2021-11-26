using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
	[SerializeField] Transform PlayerGrid, EnemyGrid;
	Transform[,] GridSpaces;
	[SerializeField] int GridHeight = 4, HalfGridWidth = 3;

    // Start is called before the first frame update
    void Awake()
    {
		GridSpaces = new Transform[HalfGridWidth * 2, GridHeight];
        for (int i = 0; i < PlayerGrid.childCount; i++)
			GridSpaces[i % HalfGridWidth, i / HalfGridWidth] = PlayerGrid.GetChild(i);
		for (int i = 0; i < EnemyGrid.childCount; i++)
			GridSpaces[(i % HalfGridWidth) + HalfGridWidth, i / HalfGridWidth] = EnemyGrid.GetChild(i);
		/*
		for (int i = 0; i < GridSpaces.GetLength(1); i++)
			for (int j = 0; j < GridSpaces.GetLength(0); j++)
				Debug.Log(GridSpaces[j,i] + " "+j + " "+ i + GridSpaces[j, i].position);
		*/		
	}

	// Update is called once per frame
	void Update()
    {
        
    }

	public Vector2 GetPositionAt(Transform tile)
	{
		for (int i = 0; i < GridSpaces.GetLength(1); i++)
			for (int j = 0; j < GridSpaces.GetLength(0); j++)
				if (GridSpaces[j, i] == tile)
					return new Vector2(j, i);
		return Vector2.one * -1;
	}

	public bool TileAtPos(Vector2 pos, out Transform foundTile)
	{
		if (pos.x < GridSpaces.GetLength(0) && pos.y < GridSpaces.GetLength(1) && pos.x >= 0 && pos.y >= 0)
		{
			foundTile = GridSpaces[(int)pos.x, (int)pos.y];
			return true;
		}
		foundTile = null;
		return false;
	}

	public void Refresh()
	{
		foreach (Transform tile in GridSpaces)
		{
			tile.GetComponent<MeshRenderer>().material.color = Color.white;
		}
	}
	public void DisplayAttack(Vector2 Position, Vector2[] spots)
	{
		foreach (Vector2 spot in spots)
		{
			Transform returnedTile;
			if (TileAtPos(spot + Position, out returnedTile))
				returnedTile.GetComponent<MeshRenderer>().material.color = Color.red;
		}
	}
}
