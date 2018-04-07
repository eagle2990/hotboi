using UnityEngine;

public class DoubleDamagePowerUp : MonoBehaviour {
    public PlayerBaseData playerStats;
    [Range(5f, 30f)]
    public float damageDuration = 10f;
    public float damageMultiplier = 2f;
    public WeaponBasicData doubleDamageStats;

    public void Appear() {
    }

    public void Consumed() {
        //change weapon
        GameObject.FindGameObjectsWithTag("Player")[0].transform.parent.gameObject.GetComponentInChildren<InflictDamage>().weaponStats = doubleDamageStats;
        //set weapon timer to given time
        GameObject.FindGameObjectsWithTag("Player")[0].transform.parent.gameObject.GetComponentInChildren<WeaponTimer>().SetDoubleDamageTimer(damageDuration);
    }

    public void Disappear() {
    }

    private GameObject[] FindPlayer() {
        return GameObject.FindGameObjectsWithTag("Player");
    }

}
