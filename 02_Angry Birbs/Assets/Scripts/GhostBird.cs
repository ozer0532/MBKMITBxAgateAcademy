using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBird : Bird
{
    public float explosionRadius;
    public float explosionStrength;
    public AudioClip audioClip;
    public AudioSource audioSource;

    protected override void OnCollide(Collision2D col)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D collider in colliders)
        {
            Rigidbody2D rb2d = collider.GetComponent<Rigidbody2D>();
            if (rb2d)
            {
                Vector2 direction = collider.transform.position - transform.position;
                Vector2 explosionForce = direction.normalized * Mathf.Lerp(explosionStrength, 0, direction.magnitude / explosionStrength);
                rb2d.AddForceAtPosition(explosionForce, transform.position);
            }
        }
        audioSource.PlayOneShot(audioClip);
        Destroy(gameObject);
    }
}
