using UnityEngine;
using UnityEngine.UI;

public abstract class Character : MonoBehaviour
{
    private float maxhealth; public float MaxHealth { get { return maxhealth; } private set { maxhealth = Mathf.Clamp(value, 0, 100); } }
    private float health; public float Health { get { return health; } private set { health = Mathf.Clamp(value,0,100); } }
    protected Animator animator;
    protected Rigidbody2D rb2d;

    public void TakeDamage(float dmg)
    {
        Health -= dmg;
        Debug.Log($"{this.name} took damage {dmg}, HP: {Health}");
        IsDead();
    }

    public bool IsDead()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log($"{this.name} is dead");
            return true;
        }
        return false;
    }


    public void Initialize(float startHealth)
    {
        Health = startHealth;
        Debug.Log($"{this.name} initialized with HP: {Health}");
        MaxHealth = Health;
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    
}
