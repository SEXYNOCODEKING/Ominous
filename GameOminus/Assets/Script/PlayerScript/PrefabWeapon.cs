using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabWeapon : MonoBehaviour
{
	public float fireRate = 0.6f;
	public Transform firePoint;
	public GameObject bulletPrefab;
	public Animator Gun;

	float timeUntiFire;
	Player pm;

    private void Start()
    {
		pm = gameObject.GetComponent<Player>();  
    }
    // Update is called once per frame
    private void Update()
	{
		if (Input.GetKeyDown(KeyCode.F) && timeUntiFire < Time.time && Player.instance.Bullet > 0 )
		{
			Shoot();
			timeUntiFire = Time.time + fireRate;
		}
	}

	void Shoot()
	{
		Gun.SetTrigger("GunATK");
		Player.instance.Bullet--;
		float angle = pm.isFacingRight ? 0f : 180f;
		Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
	}
}
