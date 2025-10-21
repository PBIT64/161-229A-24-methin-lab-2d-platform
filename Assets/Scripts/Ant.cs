using Unity.VisualScripting;
using UnityEngine;

public class Ant : Enemy
{
    [SerializeField]
    Vector2 velocity;
    public Transform[] movePoints;

    void Start()
    {
        base.Initialize(20);
        DamageHit = 10;
        velocity = new Vector2(-2f, 0f);
    }
    public override void Behavior()
    {
        Rigidbody2D rb = base.rb2d;
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        
        if (velocity.x < 0 && rb.position.x <= movePoints[0].position.x)
        {
            Flip();
        }
        if (velocity.x > 0 && rb.position.x >= movePoints[1].position.x)
        {
            Flip();
        }
    }
    public void Flip()
    {
        velocity.x *= -1;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void FixedUpdate() => Behavior();
}
