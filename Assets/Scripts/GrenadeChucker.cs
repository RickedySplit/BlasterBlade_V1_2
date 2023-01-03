using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrenadeChucker : MonoBehaviour
{
    public Transform grenadeThrowPos; //Position where grenade is thrown from
    public GameObject currentGrenade; //Current Grenade Prefab
    public int GrenadeAmount = 3; //Amount of Grenades
    public float throwForce = 20f; //Force of the grenade being thrown/Projectile Speed
    public TextMeshProUGUI nadeDisplay; //HUD Element displaying amount of grenades

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nadeDisplay != null)
            nadeDisplay.SetText("Grenades: " + GrenadeAmount);

        if (Input.GetKeyDown(KeyCode.G))
        {
            if(GrenadeAmount >= 1)
            {
                ThrowGrenade();
                Debug.Log("Grenade Out!");
            }
            else if(GrenadeAmount <= 0)
            {
                Debug.Log("You have no grenades!");
            }
        }
    }

    void ThrowGrenade()
    {
        GrenadeAmount--;
        GameObject nade = Instantiate(currentGrenade, grenadeThrowPos.position, grenadeThrowPos.rotation);
        //Bullet instantiated, named "Bullet"
        Rigidbody2D rb = nade.GetComponent<Rigidbody2D>();
        //Bullet accesses Rigidbody2D component, component named "rb"

        rb.AddForce(grenadeThrowPos.up * throwForce, ForceMode2D.Impulse);
    }
}
