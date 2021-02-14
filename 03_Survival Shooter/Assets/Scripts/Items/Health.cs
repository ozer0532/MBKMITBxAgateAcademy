using UnityEngine;

public class Health : BaseItem
{
    public int healthUp;

    protected override void OnItemCollected(GameObject player)
    {
        PlayerHealth health = player.GetComponent<PlayerHealth>();

        health.Heal(healthUp);
        Destroy(gameObject);
    }
}
