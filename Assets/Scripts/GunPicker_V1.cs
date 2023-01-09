using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPicker_V1 : MonoBehaviour
{
    public GameObject[] weapons; //Weapons Array
    public GameObject chosenWeapon; //Weapon Chosen to be Instantiated
    int index; //Number for Random.Range

    public GameObject WeaponWallet;



    // Awake is called when the script instance is being loaded.
    void Start()
    {
        index = Random.Range (0, weapons.Length);
        chosenWeapon = weapons[index];
        Instantiate(chosenWeapon, transform.position, transform.rotation, WeaponWallet.transform);
        //WeaponWallet.transform it used, so the instantiated Gun is the child of WeaponWallet
        //This is because WeaponWallet cycles through it's child objects (It also makes things neat!)
    }

    // Update is called once per frame
    void Update()
    {

        if (WeaponWallet == null)
        {
            WeaponWallet = GameObject.FindGameObjectWithTag("WeaponHolsterTag");
        }
    }
}
