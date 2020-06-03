using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonationBox : MonoBehaviour
{
    public GameObject script;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            print("ChargeCoin");
            script.GetComponent<Store>().decreaseAmount();
            StartCoroutine(respwanCoin(other.gameObject));
        }
    }

    IEnumerator respwanCoin(GameObject Coin) {
        Coin.SetActive(false);
        yield return new WaitForSeconds(2f);
        Coin.transform.position = new Vector3(-1.2f, 1.1f, -0.08f);
        Coin.SetActive(true);
    }
}
