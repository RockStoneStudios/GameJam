using UnityEngine;

public class TankPlacement : MonoBehaviour
{
    public LayerMask placementMask;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && TankCard.selectedCard != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, placementMask))
            {
                if (GridManager.Instance.GetGridCell(hit.point, out Vector3 cellCenter, out int col, out int row))
                {
                    if (!GridManager.Instance.IsCellOccupied(col, row) && TankCard.selectedCard.TryUseCard())
                    {
                        GameObject tank = TankPool.Instance.GetTank(cellCenter);
                        if (tank != null)
                        {
                            GridManager.Instance.PlaceAtCell(col, row, tank);
                            TankCard.selectedCard = null;
                        }
                    }
                }
            }
        }
    }
}