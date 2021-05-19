using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPathNode
{
    private MazeGrid<AIPathNode> grid;
    public int x;
    public int y;

    public int gCost;
    public int hCost;
    public int fCost;

    public bool isWalkable;
    public AIPathNode cameFromNode;

    public AIPathNode(MazeGrid<AIPathNode> _grid, int _x, int _y)
    {
        this.grid = _grid;
        this.x = _x;
        this.y = _y;
        isWalkable = true;
    }

    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }

    public void SetIsWalkable(bool isWalkable)
    {
        this.isWalkable = isWalkable;
        //grid.TriggerGridObjectChanged(x, y);
    }

    public override string ToString()
    {
        return x + ", " + y;
    }
}
