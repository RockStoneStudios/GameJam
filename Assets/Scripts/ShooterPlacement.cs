using UnityEngine;

public class ShooterPlacement : MonoBehaviour
{
    public LayerMask placementMask;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ShooterCard.selectedCard != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, placementMask))
            {
                if (GridManager.Instance.GetGridCell(hit.point, out Vector3 cellCenter, out int col, out int row))
                {
                    if (!GridManager.Instance.IsCellOccupied(col, row) && ShooterCard.selectedCard.TryUseCard())
                    {
                        GameObject shooter = ShooterPool.Instance.GetShooter(cellCenter);
                        if (shooter != null)
                        {
                            GridManager.Instance.PlaceAtCell(col, row, shooter);
                            ShooterCard.selectedCard = null;
                        }
                    }
                }
            }
        }
    }
}