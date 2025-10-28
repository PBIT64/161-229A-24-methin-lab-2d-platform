using UnityEngine;

public class Rock : Weapon
{
    public Rigidbody2D rb2d;
    public Vector2 force;
    public override void OnHitWith(Character target)
    {
        if (target is Player)
        {
            target.TakeDamage(this.damage);
            Destroy(gameObject);
        }
    }
    public override void Move()
    {
        rb2d.AddForce(force);
    }
    private void Start()
    {
        damage = 20;
        force = new Vector2(GetShootDirection() * 90, 400);
        Move();
    }
}
