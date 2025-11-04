using UnityEngine;
using UnityEngine.UI;

public class HPBarHandler : MonoBehaviour
{
    private Character characterScript;
    public GameObject CharacterObj;
    public Image HPBar;
    public Image BGBar;
    private void Start()
    {
        characterScript = CharacterObj.GetComponent<Character>();
    }
    void Update()
    {
        // Flip
        Transform FlipScale = CharacterObj.transform;
        BGBar.transform.localScale = new Vector2(FlipScale.localScale.x, BGBar.rectTransform.localScale.y);

        // HealthBar Update
        float percentage = characterScript.Health/characterScript.MaxHealth;
        float value = percentage * 5;
        HPBar.rectTransform.sizeDelta = new Vector2(value, HPBar.rectTransform.sizeDelta.y);
    }
}
