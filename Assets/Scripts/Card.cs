using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Card_data data;

    public string card_name;
    public string description;
    public int health;
    public int uses;
    public int damage;
    public Sprite sprite;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI usesText;
    public TextMeshProUGUI damageText;
    public Image spriteImage;
    int useCount =0;
    GameManager GM;
        

    // Start is called before the first frame update
    void Start()
    {
        card_name = data.card_name;
        description = data.description;
        health = data.health;
        uses = data.uses;
        damage = data.damage;
        sprite = data.sprite;
        nameText.text = card_name;
        descriptionText.text = description;
        healthText.text = health.ToString();
        usesText.text = uses.ToString();
        damageText.text = damage.ToString();
        spriteImage.sprite = sprite;
        GM = FindAnyObjectByType<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if(useCount>=uses)
        {
            GM.player_hand.Remove(data);
            GM.discard_pile.Add(data);
            Destroy(this.gameObject);
        }
    }



}
