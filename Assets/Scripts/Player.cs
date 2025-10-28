using Unity.VisualScripting;
using UnityEngine;

public class Player : Character, IShootable
{
    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform ShootPoint { get; set; }
    public float ReloadTime {  get; set; }
    public float WaitTime { get; set; }

    public void OnHitWith(Enemy enemy) => TakeDamage(enemy.DamageHit);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null) {
            Debug.Log($"{this.name} been hit by {enemy.name}|HP left: {this.Health}");
            OnHitWith(enemy);
        }
    }
    void Start()
    {
        Initialize(999999);
        
        ReloadTime = 1;
        WaitTime = 0;
    }
    private void FixedUpdate()
    {
        WaitTime += Time.deltaTime;
    }
    private void Update()
    {
        Shoot();
    }
    public void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && WaitTime >= ReloadTime)
        {
            var bullet = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
            Banana banana = bullet.GetComponent<Banana>();
            if (banana != null)
                banana.InitWeapon(200, this);
            WaitTime = 0;
        }
    }

}
