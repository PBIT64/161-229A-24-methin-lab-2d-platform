using System;
using UnityEditor;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    // Attributes
    private string name;
    private int health;
    private int atk_power = 1;
    protected int max_health = 100;
    public string Name
    {
        get => name;
        private set => name = (string.IsNullOrEmpty(value) ? "Unknown" : value);
    }
    public int Health { get; protected set; }
    public int AttackPower { get; protected set; }

    // No Contructor
    public virtual void Initialize(string newName, int newHP, int newATK)
    {
        Name = newName;
        Health = newHP;
        AttackPower = newATK;
    }
    // Functions
    public void TakeDamage(int damage)
    {
        Debug.Log($"{Name} Take Damage {damage}");
        Health = Mathf.Clamp(Health - damage, 0, max_health);
        ShowStats();
    }
    /*public virtual void Attack(Character Target)
    {
        Target.TakeDamage(AttackPower);
    }*/
    public abstract void Attack(Character Target);
    public abstract void Attack(Character Target,int bonusDMG);
    public abstract void OnDefeat();
    public abstract void OnDefeat(Hero hero);
    public bool IsAlive()
    {
        return Health > 0;
    }
    public virtual void ShowStats()
    {
        Debug.Log($"Name : {Name} | HP : {Health}");
    }
}
