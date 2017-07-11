public class GameGrid
{
    private readonly int GRID_ROWS;
    private readonly int GRID_COL;
    private int[][] grid;

    public GameGrid(int col, int row)
    {
        GRID_COL = col;
        GRID_ROWS = row;
        grid = new int[GRID_COL][];
        for (int i = 0; i < GRID_COL; i++)
        {
            grid[i] = new int[GRID_ROWS];
        }
    }

    public bool IsFree(int x, int y)
    {
        return grid[x][y] == 0;
    }

    public bool Update(int x, int y)
    {
        if (IsFree(x, y))
        {
            grid[x][y] = 1;
            return true;
        }
        return false;
    }

    override public string ToString()
    {
        string output = string.Empty;
        for (int y = GRID_ROWS - 1; y >= 0 ; y--)
        {
            for (int x = 0; x < GRID_COL; x++)
            {
                output += "[" + grid[x][y] + "]";
            }
            output += "\n";
        }
        return output;
    }
}
