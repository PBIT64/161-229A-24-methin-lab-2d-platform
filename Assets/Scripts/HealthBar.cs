using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] GameObject HealthBar_Prefab;

    Character character;
    GameObject healthBar;
    GameObject BGBar;
    GameObject HPBar;
    public void HealthInitialize()
    {
        character = GetComponent<Character>();
        healthBar = Instantiate(HealthBar_Prefab, transform);
        BGBar = healthBar.transform.GetChild(0).gameObject;
        HPBar = BGBar.transform.GetChild(0).gameObject;
        // Set Health Bar Position
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        float posY = transform.position.y + 0.25f + (collider.size.y / 2);
        healthBar.transform.position = new Vector3(transform.position.x,posY,transform.position.z);
    }
    public virtual void Update()
    {
        // Flip
        BGBar.transform.localScale = new Vector2(transform.localScale.x, BGBar.transform.localScale.y);
        // Health Bar Update
        float percentageHP = character.Health / character.MaxHealth;
        HPBar.transform.localScale = new Vector2(percentageHP, HPBar.transform.localScale.y);
    }
    
}
