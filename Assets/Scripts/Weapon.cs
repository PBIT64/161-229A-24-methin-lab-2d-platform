using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    public int damage;
    public IShootable Shooter;
    public abstract void Move();
    public abstract void OnHitWith(Character character);
    public void InitWeapon(int newDamage, IShootable newShooter)
    {
        damage = newDamage;
        Shooter = newShooter;
    }
    public int GetShootDirection()
    {
        float ShootPos = Shooter.ShootPoint.position.x;
        float PlayerPos = Shooter.ShootPoint.parent.position.x;
        float v = ShootPos - PlayerPos;
        if (v < 0)
        {
            return -1;
        }else return 1;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Character character = collision.GetComponent<Character>();
        if (character != null) { 
            OnHitWith(character);
            Destroy(this.gameObject,5);
        }
    }
}
