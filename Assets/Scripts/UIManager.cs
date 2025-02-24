using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject damageText;
    public GameObject healthText;

    public Canvas gameCan;

    private void Awake()
    {
        gameCan = FindObjectOfType<Canvas>();
    }

    private void OnEnable()
    {
        CharacterEvents.characterDamage+=(CharacterTookDamage);
        CharacterEvents.characterHeal += (CharacterTookHeal);
    }

    private void OnDisable()
    {
        CharacterEvents.characterDamage -= (CharacterTookDamage);
        CharacterEvents.characterHeal -= (CharacterTookHeal);
    }


    public void CharacterTookDamage(GameObject character, int damage)
    {
        Vector3 spawnPosition = Camera.main.WorldToScreenPoint(character.transform.position);

        TMP_Text tmpText = Instantiate(damageText, spawnPosition, Quaternion.identity, gameCan.transform).GetComponent<TMP_Text>();

        tmpText.text = damage.ToString();
    }

    public void CharacterTookHeal(GameObject character, int heal)
    {
        Vector3 spawnPosition = Camera.main.WorldToScreenPoint(character.transform.position);

        TMP_Text tmpText = Instantiate(healthText, spawnPosition, Quaternion.identity, gameCan.transform).GetComponent<TMP_Text>();

        tmpText.text = heal.ToString();
    }
}
