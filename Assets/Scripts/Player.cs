using UnityEngine;

public class Player : Character
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Initialize(100);
    }

    public void OnHitWith(Enemy enemy) => TakeDamage(enemy.DamageHit);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null) {
            Debug.Log($"{this.name} been hit by {enemy.name}|HP left: {this.Health}");
            OnHitWith(enemy);
        }
    }
}
