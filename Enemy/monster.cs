using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class monster : MonoBehaviour
{
    [SerializeField] private int maxHp = 100;
    private int _curHp = 0;
    private int curHp 
    {
        get 
        {
            return _curHp;
        }

        set
        {
            _curHp = value;

            if (_curHp < 0)
                _curHp = 0;

            if(_curHp > maxHp)
                _curHp = maxHp;
        }
    }

    [SerializeField] private Image fillImage;

    private void Awake()
    {

    }

    private void OnEnable()
    {
        _curHp = maxHp;
    }

    private void Update()
    {
        float scaleX = (float)curHp / (float)maxHp;
        fillImage.transform.localScale = new Vector3(scaleX, fillImage.transform.localScale.y, fillImage.transform.localScale.z);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            other.gameObject.SetActive(false);
            curHp -= other.GetComponent<Bullet>().attackAmount;
        }
    }


}
