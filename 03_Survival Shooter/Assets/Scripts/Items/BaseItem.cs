using UnityEngine;

public abstract class BaseItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !other.isTrigger)
        {
            OnItemCollected(other.gameObject);
        }
    }

    protected abstract void OnItemCollected(GameObject player);
}
