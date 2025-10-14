using UnityEngine;

public class Hero : Character
{
    // Attributes
    private int gold;

    private int max_gold = 999;
    public int Gold
    { // Value Properties V2
        get { return gold; }
        private set { gold = Mathf.Clamp(value,0,max_gold) ; }
    }
    // Contructor Unsetable
    public void Initialize(string new_Hero_Name, int new_Hero_Hp, int ATKPower)
    {
        base.Initialize(new_Hero_Name, new_Hero_Hp, ATKPower);
        Gold = 0;
    }

    // Functions
    public void EarnGold(int newGold)
    {
        Gold += newGold;
    }
    public override void ShowStats()
    {
        base.ShowStats();
        Debug.Log($"{Name} | Gold :{Gold}");
    }

    public void Heal(int healing)
    {
        Health = Mathf.Clamp(Health + healing, 0, 100);
    }
    public override void Attack(Character Target)
    {
        Target.TakeDamage(AttackPower);
        Debug.Log($"{Name} Slashes {Target.Name}| Deal {AttackPower} DMG");
    }
    public override void Attack(Character Target, int bonusDMG)
    {
        Target.TakeDamage(AttackPower + bonusDMG);
        Debug.Log($"{Name} Slashes {Target.Name}| Deal {AttackPower} DMG");
    }
    public override void OnDefeat()
    {
        Debug.Log($"{Name} is defeated : Game Over");
    }
    public override void OnDefeat(Hero hero) {}
}