using System;
using System.Collections.Generic;
using UnityEngine;
public class Main : MonoBehaviour
{    
    //List<Hero> HeroList = new List<Hero>();
    public List<Monster> MonsterPrefabs = new List<Monster>();
    public List<Monster> MonsterList = new List<Monster>();
    public Hero Hero;

    public Monster Monster1;
    public Monster Monster2;
    public Monster Monster3;
    Vector3 RandomPosition()
    {
        System.Random random = new System.Random();
        Vector3 Pos = new Vector3(random.Next(-10,10), random.Next(-10, 10), random.Next(-10, 10));
        return Pos;
    }
    void Start()
    {
        Monster1 = SpawnMonster(MonsterType.Zombie);
        Monster1.Initialize(MonsterPrefabs[0].transform.name, 50, 5);
        Monster1.ShowStats();
        Monster1.transform.position = RandomPosition();

        Monster2 = SpawnMonster(MonsterType.Skeleton);
        Monster2.Initialize(MonsterPrefabs[1].transform.name, 50, 5);
        Monster2.ShowStats();
        Monster2.transform.position = RandomPosition();

        Monster3 = SpawnMonster(MonsterType.Creeper);
        Monster3.Initialize(MonsterPrefabs[2].transform.name, 50, 5);
        Monster3.ShowStats();
        Monster3.transform.position = RandomPosition();


        Hero.Initialize("PBIT64", 100, 20);
        Hero.ShowStats();
        Hero.transform.position = RandomPosition();


    }

    Monster SpawnMonster(MonsterType monsterType)
    {
        Monster MonsterPrefab = MonsterPrefabs[(int)monsterType];
        Monster newMonster = Instantiate(MonsterPrefab);
        newMonster.SetMonsterType(monsterType);
        MonsterList.Add(newMonster);
        return newMonster;
    }
}
