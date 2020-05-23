using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poetry : MonoBehaviour
{
    public GameObject poetryFortune;
    bool isStickOut;
    List<string> allowName = new List<string> { "First", "Second", "Third", "Fourth", "Fifth", "Sixth", "Eighth", "Ninth", "Tenth", "Eleventh", "Twelfth", "Thirteenth" };
    // Start is called before the first frame update
    void Start()
    {
        isStickOut = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        //other.gameObject.name
        if (!isStickOut&& allowName.Contains(other.gameObject.name))
        {
            StartCoroutine(showFortune(other.gameObject.name));
        }
    }
    IEnumerator showFortune(string name) {
        isStickOut = true;
        print("++++++");
        print(name);
        print("/" + poetryFortune.name + "/" + name);
        GameObject number = poetryFortune.transform.Find(name).gameObject;
        //GameObject[] numbers = poetryFortune.GetComponentsInChildren<GameObject>();
        //print(numbers);
        //foreach(GameObject i in numbers) {
        //    if (i.name == name) {
        //        print(i.name);
        //        i.GetComponent<Menu>().isActive();
        //        break;
        //    }
        //}

        //GameObject number = GameObject.Find("/MenuFollower"+"/"+poetryFortune.name+"/"+name);
        print(number.name);
        print("~~~~~");
        poetryFortune.GetComponent<Menu>().isActive();
        number.GetComponent<Menu>().isActive();
        yield return new WaitForSeconds(1);
    }
    public void ResetPoetry()
    {
        isStickOut = false;
    }
}
