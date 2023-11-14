using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class BulletControllor : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject parentObject;

    [SerializeField] private Transform targetPosition;
    [SerializeField] private Transform firePosition;

    [SerializeField] private float bulletSpeed = 100f;
    private float curTime = 0f;
    private const float maxTime = 0.25f;

    private const int numOfBullet = 300;




    private void Awake()
    {
        for (int i = 0; i < numOfBullet; i++)
        {
            var obj = Instantiate(bulletPrefab, parentObject.transform);
            obj.SetActive(false);
        }
    }


    private void Update()
    {
        curTime += Time.deltaTime;

        if (curTime < maxTime)
            return;

        if (Input.GetKey(KeyCode.Space) == false)
            return;

        for (int i = 0; i < numOfBullet; i++)
        {   
            var bullet = parentObject.transform.GetChild(i).gameObject;

            if(bullet.activeSelf == false)
            {
                bullet.SetActive(true);
                bullet.transform.position = firePosition.position;

                var bulletDirection = (targetPosition.position - firePosition.position).normalized;
                var angle = Mathf.Atan2(bulletDirection.y, bulletDirection.x) * Mathf.Rad2Deg;
                var rigidBody = bullet.GetComponent<Rigidbody>();

                rigidBody.velocity = bulletDirection * bulletSpeed;

                break;
            }
        }

        curTime = 0;

    }
}
