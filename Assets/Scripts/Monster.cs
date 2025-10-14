using System;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterType
{
    Zombie,
    Creeper,
    Skeleton,
    Enderman,
}

public class Monster : Character
{
    MonsterType MonsterType;

    System.Random random = new System.Random();
    private int GoldDrop = 50;
    private List<string> server_loottable = new List<string> { 
        "Gem Stone","Poop","Trash","Scrap","Emerald"
    };
    bool isDefeated = false;
    private string getLootItem()
    {
        return server_loottable[random.Next(0, server_loottable.Count)];
    }
    public void SetMonsterType(MonsterType monsterType)
    {
        MonsterType = monsterType;
        switch (monsterType) { 
            case MonsterType.Zombie: Initialize("Zombie",20,5); GoldDrop = 20; break;
            case MonsterType.Creeper: Initialize("Creeper", 20, 5); GoldDrop = 20; break;
            case MonsterType.Enderman: Initialize("Enderman", 20, 5); GoldDrop = 20; break;
            case MonsterType.Skeleton: Initialize("Skeleton", 20, 5); GoldDrop = 20; break;
        }
    }
    public void DropReward(List<Hero> Heroes)
    {
        for (int i = 0; i < Heroes.Count; i++)
        {
            Hero hero = Heroes[i];
            hero.EarnGold(GoldDrop);
        }
    }
    public void DropLoot(List<Hero> Heroes)
    {

        for (int i = 0; i < Heroes.Count; i++)
        {
            Hero hero = Heroes[i];
            Debug.Log($"{hero.Name} Looted {getLootItem()}");
        }
    }
    public override void ShowStats()
    {
        base.ShowStats();
        Debug.Log($"{Name} : Drops {getLootItem()}");
    }
    public override void Attack(Character Target)
    {
        Target.TakeDamage(AttackPower);
        Debug.Log($"{Name} Crushs {Target.Name}| Deal {AttackPower} DMG");
    }
    public override void Attack(Character Target, int bonusDMG)
    {
        Target.TakeDamage((AttackPower*2) + (bonusDMG/2));
        Debug.Log($"{Name} Crushs {Target.Name}| Deal {AttackPower} DMG");
    }
    public override void OnDefeat() { }
    public override void OnDefeat(Hero hero)
    {
        Debug.Log($"{Name} died");
        DropReward(new List<Hero> { hero });
    }
}
