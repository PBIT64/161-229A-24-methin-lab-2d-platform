using Unity.Mathematics;
using UnityEngine;

public class Crocodile : Enemy,IShootable
{
    [SerializeField] private float atkRange;
    public Player player;

    [field: SerializeField]
    public GameObject Bullet { get; set; }
    [field: SerializeField]
    public Transform ShootPoint { get; set; }
    public float WaitTime { get; set; }
    public float ReloadTime { get; set; }

    public void Start()
    {
        base.Initialize(50);
        DamageHit = 20;

        atkRange = 6f;
        player = GameObject.FindFirstObjectByType<Player>();

        WaitTime = 0;
        ReloadTime = 1f;
    }
    private void FixedUpdate() {
        WaitTime += Time.deltaTime;
        Behavior();
    }
    public override void Behavior()
    {
        if (player == null) {
            return;
        }
        Vector2 distance = transform.position - player.transform.position;
        if (distance.magnitude <= atkRange)
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        if (WaitTime >= ReloadTime) 
        {
            animator.SetTrigger("Shoot");
            var bullet = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
            Rock rock = bullet.GetComponent<Rock>();
            rock.InitWeapon(5, this);
            WaitTime = 0;
        }
    }
}
