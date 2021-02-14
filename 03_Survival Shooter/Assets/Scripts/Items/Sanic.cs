using System.Collections;
using UnityEngine;

public class Sanic : BaseItem
{
    public float delay;
    public float newSpeed;
    private static bool isActive;

    protected override void OnItemCollected(GameObject player)
    {
        // Hindari powerup terpakai selama masih ada yang efeknya masih aktif
        if (!isActive)
        {
            PlayerMovement movement = player.GetComponent<PlayerMovement>();
            movement.StartCoroutine(ResetSpeed(movement));
            Destroy(gameObject);
        }
    }

    private IEnumerator ResetSpeed(PlayerMovement movement)
    {
        float oldSpeed = movement.speed;
        movement.speed = newSpeed;
        yield return new WaitForSeconds(delay);
        movement.speed = oldSpeed;
    }
}
