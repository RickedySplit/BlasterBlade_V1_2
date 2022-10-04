using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MeleeAttacking : MonoBehaviour
{
    public GameObject player;
    public GameObject hitBoxObject;

    public bool isSwinging = false;
    public float swingTime = 0.07f; //Time it takes to swing

    private Animator animComponent;
    public Sprite playerThisWeaponSprite; //The Sprite that shows the player holding the weapon (E.G. if this sprite is for an Axe, sprite will show player holding an Axe)
    public Sprite invisWeaponSprite; //Invis Sprite that is used when animation is played (This is probably a shit way of doing this, but it'll work for now)
    public string attackAnimName;

    public TextMeshProUGUI ammunitionDisplay;

    public GameObject WeaponWallet; //Weapon Wallet object

    public AudioClip meleeSwingingSound;

    public float newMoveSpeed = 6.5f;

    void OnEnable()
    {
        player.GetComponent<PlayerMovement>().moveSpeed = newMoveSpeed; //Sets the player's movement speed while weapon is equipped (e.g. so while holding Minigun, player is slow)
        player.GetComponent<SpriteRenderer>().sprite = playerThisWeaponSprite; //Sets the player's sprite to the one of them holding the gun.
    }

    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<PlayerMovement>().moveSpeed = newMoveSpeed; //Sets the player's movement speed while weapon is equipped (e.g. so while holding Minigun, player is slow)
        animComponent = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ammunitionDisplay.SetText("N/A");

        if ((Input.GetButtonDown("Fire1") && isSwinging == false))
        {
            //Insert Funny Swingers joke here
            SwingWeapon();
        }
    }

    void SwingWeapon()
    {
        animComponent.Play(attackAnimName);
        WeaponWallet.GetComponent<WeaponWallet>().isReloading = true; //This is just so the player can't switch weapon mid-swing, causing fuckery (Just using Reloading Bool because I'm a lazy bastard).
        player.GetComponent<SpriteRenderer>().sprite = invisWeaponSprite;
        isSwinging = true;
        animComponent.enabled = true;
        hitBoxObject.SetActive(true);
        hitBoxObject.GetComponent<AudioSource>().PlayOneShot(meleeSwingingSound, 1f);
        Invoke("StopSwing", swingTime);
    }

    void StopSwing()
    {
        //animComponent.Play("Fire Axe Swing_V1 Idle");
        player.GetComponent<SpriteRenderer>().sprite = playerThisWeaponSprite;
        isSwinging = false;
        animComponent.enabled = false;
        hitBoxObject.SetActive(false);
        WeaponWallet.GetComponent<WeaponWallet>().isReloading = false; //Allows the player to switch weapon again
    }
}
