using UnityEngine;
using UnityEngine.UI;

public class HPBarHandler : MonoBehaviour
{
    private Character characterScript;
    public GameObject CharacterObj;
    public Image HPBar;
    private void Start()
    {
        characterScript = CharacterObj.GetComponent<Character>();

    }
    void Update()
    {
        float percentage = characterScript.Health/characterScript.MaxHealth;
        float value = percentage * 5;
        HPBar.rectTransform.sizeDelta = new Vector2(value, HPBar.rectTransform.sizeDelta.y);
    }
}
