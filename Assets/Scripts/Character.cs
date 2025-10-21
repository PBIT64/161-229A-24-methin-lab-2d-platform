using UnityEngine;

public abstract class Character : MonoBehaviour
{
    
    private int health; public int Health { get { return health; } private set { health = Mathf.Clamp(value,0,100); } }

    protected Animator animator;
    protected Rigidbody2D rb2d;

    public void TakeDamage(int dmg)
    {
        Health -= dmg;
        Debug.Log($"{this.name} took damage {dmg}, HP: {Health}");
        IsDead();
    }

    public bool IsDead()
    {
        if (Health <= 0)
        {
            GameObject.Destroy(this);
            Debug.Log($"{this.name} is dead");
            return true;
        }
        return false;
    }


    public void Initialize(int startHealth)
    {
        Health = startHealth;
        Debug.Log($"{this.name} initialized with HP: {Health}");
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }
}
