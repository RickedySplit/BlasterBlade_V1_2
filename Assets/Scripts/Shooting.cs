using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shooting : MonoBehaviour
{
    public GameObject player;
    public Sprite playerThisGunSprite; //The Sprite that shows the player holding the weapon (E.G. if this sprite is for an AK, sprite will show player holding an AK)

    public Transform firePoint; //Original Place the bullets come from
    public Transform newFirePoint; //New Place the bullets come from
    public GameObject bulletPrefab; //Prefab of bullet (Might want to add variables to THIS script so damage can be changed through this script? Would allow every bullet to be generic and become special through the script itself.)

    //Sounds (Usually Comes from firePoint)
    public GameObject muzzleSource;

    public AudioClip gunFiringSound;
    public AudioClip gunReloadingSound;

    public float maxSpreadAngle = 15f;
    public float minSpreadAngle = -15f;

    public float setTimeBetweenAttacks = 0.1f; //Time Until player can shoot again
    //How Much time "currentTimeUntilAbleToShoot" should go up to"
    public float currentTimeUntilAbleToShoot = 0f; //Current Time Until player can shoot again
    //Resets to "setTimeBetweenAttacks" number when shooting and goes down back to 0
    public bool canShoot = true; 
    public float bulletForce = 20f; //Force of the projectile being shot/Projectile Speed
    public float reloadTime = 0.5f; //Time it takes to reload
    public bool reloading = false;

    public int currentMagAmmo = 30; //Current amount of ammo the gun's magazine/clip is holding.
    //public Text currentMagAmmoText;
    public int MaxMagAmmo = 30; //Maximum amount of ammo the gun's magazine/clip can hold.
    public int emptySpaceInMag = 0; //Current empty space in the gun's magazine/clip, Used in reload calculation.
    public int reserveAmmo = 90; //Current amount of reserve ammo.
    //public Text reserveAmmoText;
    public int ammoCostPerShot = 1; //How much ammo the gun costs to shoot (Probably won't be used much, but cool to have just in case?)
    public TextMeshProUGUI ammunitionDisplay;

    public ParticleSystem muzzleFlash;

    public GameObject Flashlight;
    public bool IsLightOn = true;

    public GameObject WeaponWallet; //Weapon Wallet object

    public float newMoveSpeed = 6.5f;


    void Start()
    {
        player.GetComponent<PlayerMovement>().moveSpeed = newMoveSpeed; //Sets the player's movement speed while weapon is equipped (e.g. so while holding Minigun, player is slow)
        player.GetComponent<SpriteRenderer>().sprite = playerThisGunSprite; //Sets the player's sprite to the one of them holding the gun.
    }

    void OnEnable()
    {
        player.GetComponent<PlayerMovement>().moveSpeed = newMoveSpeed; //Sets the player's movement speed while weapon is equipped (e.g. so while holding Minigun, player is slow)
        player.GetComponent<SpriteRenderer>().sprite = playerThisGunSprite; //Sets the player's sprite to the one of them holding the gun.
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (IsLightOn == false)
            {
                Flashlight.SetActive(true);
                IsLightOn = true;
            }
            else if (IsLightOn == true)
            {
                Flashlight.SetActive(false);
                IsLightOn = false;
            }
        }

        emptySpaceInMag = MaxMagAmmo - currentMagAmmo;


        //Reloading - I LOVE TO RELOAD DURING A BATTLE
        if (Input.GetKeyDown(KeyCode.R) && currentMagAmmo < MaxMagAmmo && !reloading)
        {
            Reload();
        }
        else if (Input.GetKeyDown(KeyCode.R) && currentMagAmmo < MaxMagAmmo && reloading)
        {
            Debug.Log("You're already reloading!");
        }
        else if (Input.GetKeyDown(KeyCode.R) && currentMagAmmo == MaxMagAmmo)
        {
            Debug.Log("Can't reload, your magazine is full!");
        }
        else if (Input.GetKeyDown(KeyCode.R) && reserveAmmo == 0)
        {
            Debug.Log("Can't reload, you have no reserve ammo!");
        }


        if (ammunitionDisplay != null)
            ammunitionDisplay.SetText(currentMagAmmo + " / " + reserveAmmo);

        if (Input.GetButton("Fire1"))
        {
            //trying to shoot
            if ((canShoot == true) && (reloading == false))
            {
                if (currentMagAmmo <= 0)
                {
                    Debug.Log("Reload You Tosser!");
                }
                else if (currentMagAmmo > 0)
                {
                    Shoot();
                }
            }
            else if (canShoot == false)
            {
                Debug.Log("Can't Shoot Yet");
            }
        }
        //Fire1 = Mouse1

        if (currentTimeUntilAbleToShoot > 0f)
        {
            currentTimeUntilAbleToShoot -= Time.deltaTime;
            canShoot = false;
        }
        else if (currentTimeUntilAbleToShoot <= 0)
        {
            canShoot = true;
        }
    }

    private void Reload()
    {
        WeaponWallet.GetComponent<WeaponWallet>().isReloading = true;
        reloading = true;
        muzzleSource.GetComponent<AudioSource>().PlayOneShot(gunReloadingSound, 1f);
        Invoke("ReloadFinished", reloadTime);
    }
    private void ReloadFinished()
    {
        if (emptySpaceInMag >= reserveAmmo)
        {
            currentMagAmmo += reserveAmmo;
            reserveAmmo = 0;
        }
        else if(emptySpaceInMag < reserveAmmo)
        {
            reserveAmmo -= emptySpaceInMag;
            currentMagAmmo = MaxMagAmmo;
        }

        reloading = false;
        WeaponWallet.GetComponent<WeaponWallet>().isReloading = false;
    }

    void Shoot()
    {
        //Quaternion currentSpread = Quaternion.Euler(0f, 0f, Random.Range(minSpreadAngle, maxSpreadAngle));
        float currentSpreadAngle = Random.Range(minSpreadAngle, maxSpreadAngle);
        Debug.Log("Current Spread = " + currentSpreadAngle.ToString());

        currentMagAmmo -= ammoCostPerShot;
        currentTimeUntilAbleToShoot = setTimeBetweenAttacks;

        muzzleSource.GetComponent<AudioSource>().PlayOneShot(gunFiringSound, 1f);

        Vector3 rot = newFirePoint.rotation.eulerAngles;
        rot = new Vector3(rot.x, rot.y, rot.z + currentSpreadAngle);
        newFirePoint.rotation = Quaternion.Euler(rot);

        GameObject bullet = Instantiate(bulletPrefab, newFirePoint.position, newFirePoint.rotation);
        //Bullet instantiated, named "Bullet"
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //Bullet accesses Rigidbody2D component, component named "rb"

        rb.AddForce(newFirePoint.up * bulletForce, ForceMode2D.Impulse);
        //rb used to access "Addforce function

        newFirePoint.rotation = firePoint.rotation;
        newFirePoint.position = firePoint.position;

        muzzleFlash.Play();

    }

}
