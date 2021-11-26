using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int width, height;
	private int[,] gridArray;

	public Grid(int wid, int hei)
	{
		width = wid;
		height = hei;
		gridArray = new int[width, height];
	}
}
