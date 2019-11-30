using UnityEngine;

public class SwordObstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {        
        Unit unit = collider.GetComponent<Unit>();

        if (unit && unit is Character)
        {
            unit.ReceiveDamage();
        }
    }
}
