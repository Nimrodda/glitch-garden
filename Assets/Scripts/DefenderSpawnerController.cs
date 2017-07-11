public class DefenderSpawnerController
{
    private DefenderSpawner view;
    private GameGrid gameGrid = new GameGrid(9, 5);

    public DefenderSpawnerController(DefenderSpawner view)
    {
        this.view = view;
    }

    public void OnGridClicked(float x, float y)
    {
        if (view.HasSufficientFunds() && gameGrid.Update((int)x, (int)y))
        {
            view.SpawnDefenderAtPosition(x, y);
            view.UpdateFunds();
        }
    }
}
