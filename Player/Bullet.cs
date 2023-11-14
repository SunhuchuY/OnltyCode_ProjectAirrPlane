using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Bullet : MonoBehaviour
{

    private int _attackAmount = 10;
    public int attackAmount
    {
        get 
        {
            return _attackAmount;
        }
        private set 
        {
            _attackAmount = value;
        }


    }

    async void OnEnable()
    {
        // 5√  ¥Î±‚
        await DelayAsync(10000);

        gameObject.SetActive(false);
    }

    async Task DelayAsync(int milliseconds)
    {
        await Task.Delay(milliseconds);
    }
}
