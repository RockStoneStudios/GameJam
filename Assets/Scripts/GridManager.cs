using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;

    public Vector3 gridOrigin = Vector3.zero;
    public float cellWidth = 1.5f;
    public float cellHeight = 1.5f;
    public int rows = 5;
    public int columns = 9;

    private GameObject[,] gridOccupancy;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        gridOccupancy = new GameObject[columns, rows];
    }

    public bool GetGridCell(Vector3 worldPosition, out Vector3 cellCenter, out int col, out int row)
    {
        Vector3 local = worldPosition - gridOrigin;

        col = Mathf.FloorToInt(local.x / cellWidth);
        row = Mathf.FloorToInt(local.z / cellHeight);

        // Clamp to valid grid bounds (optional safety check)
        if (col < 0 || col >= columns || row < 0 || row >= rows)
        {
            cellCenter = Vector3.zero;
            return false; // Invalid cell
        }

        // Calculate center of the cell
        float centerX = gridOrigin.x + col * cellWidth + cellWidth / 2f;
        float centerZ = gridOrigin.z + row * cellHeight + cellHeight / 2f;
        cellCenter = new Vector3(centerX, gridOrigin.y, centerZ);

        return true;
    }

    public bool IsCellOccupied(int col, int row)
    {
        return gridOccupancy[col, row] != null;
    }

    public void PlaceAtCell(int col, int row, GameObject unit)
    {
        gridOccupancy[col, row] = unit;
    }
    // reusar ClearCell() luego si se muere una unidad para que el grid se pueda usar otra vez.
    public void ClearCell(int col, int row)
    {
        gridOccupancy[col, row] = null;
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (int x = 0; x < columns; x++)
        {
            for (int z = 0; z < rows; z++)
            {
                float cx = gridOrigin.x + x * cellWidth + cellWidth / 2f;
                float cz = gridOrigin.z + z * cellHeight + cellHeight / 2f;
                Vector3 center = new Vector3(cx, gridOrigin.y, cz);
                Gizmos.DrawSphere(center, 0.1f);
            }
        }
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(gridOrigin, 0.2f);
        Gizmos.color = Color.yellow;
        for (int x = 0; x < columns; x++)
        {
            for (int z = 0; z < rows; z++)
            {
                float cx = gridOrigin.x + x * cellWidth + cellWidth / 2f;
                float cz = gridOrigin.z + z * cellHeight + cellHeight / 2f;
                Vector3 center = new Vector3(cx, gridOrigin.y, cz);
                Gizmos.DrawWireCube(center, new Vector3(cellWidth, 0.1f, cellHeight));
            }
        }
    }
}
