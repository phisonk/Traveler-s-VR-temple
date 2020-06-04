using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEditor;
using UnityEngine.Purchasing;
using Models;
using Proyecto26;
using UnityEngine.Networking;
using TMPro;
using System;

[System.Serializable]
public class walletAmount
{
    public int amount;
    public List<object> wallet;

    public int amounts() 
    {
        return amount;
    }
}
[System.Serializable]
public class returnData 
{
    public _writetime _writeTime;
}
[System.Serializable]
public class _writetime 
{
    public int _seconds;
    public int _nanoseconds;
}
public class Store : MonoBehaviour
{
    private readonly string basePath = "https://vr-traveler-back.web.app";
    private RequestHelper currentRequest;
    public TextMeshProUGUI text;
    int amount = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Amount : " + amount.ToString() + " Bath";
    }

    public void addAmount(int quantity)
    {
        amount += quantity;
    }
    public void chargeCoin(int credit)
    {
        if (amount > 10)
        {
            amount -= credit;
        }
    }
    public void update()
    {

        // We can add default request headers for all requests
        //RestClient.DefaultRequestHeaders["Authorization"] = "Bearer ...";

        RequestHelper requestOptions = null;
        RestClient.Get<walletAmount>(basePath+"/amount?name=phison").Then(res =>
        {
            //res = JsonUtility.ToJson(res, true);
            int divider = 100;
            int newamount = res.amount;
            print(amount.GetType());
            amount += (newamount / divider)-amount;
            print(amount);
        }).Catch(err => print("Error" + err.Message));
        //return true;
    }
    /*IEnumerator updateData()
    {
        yield return new WaitUntil(update);
    }
    IEnumerator decrease() 
    {
        yield return new WaitUntil(decreaseAmount);
    }*/
    public void decreaseAmount() 
    {
        RestClient.Get<returnData>(basePath+"/decreaseAmount?name=phison&amount=-1000").Then(res =>
        {
            if (res._writeTime._seconds > 0) {
                print(res._writeTime._seconds);
                chargeCoin(-10);
            }
        }).Catch(err => print("Error" + err.Message));
        //return true;
    }
    
}
