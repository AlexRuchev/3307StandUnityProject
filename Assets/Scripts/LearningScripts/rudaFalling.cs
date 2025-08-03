using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rudaFalling : MonoBehaviour
{
    private GameObject[] ruda;
    private Vector3 startPosition;
    private void Start()
    {
        ruda = GameObject.FindGameObjectsWithTag("Ruda");
        startPosition = ruda[0].transform.position;
    }

    // Update is called once per frame
    public void Falling()
    {
        
        StartCoroutine(Fall());
    }
    IEnumerator Fall()
    {
        int i= 0;
        while (i<ruda.Length)
        {

            float timeDelay = Random.Range(1,4);
            float quantityStone = Random.Range(1, 5);
            Debug.Log(quantityStone);
            for(int ii=0; ii < quantityStone;  ii+=1) {
                ruda[i].GetComponent<Rigidbody>().isKinematic = false;
                i += 1;
                if (!(i < ruda.Length)){
                    break;
                }
            }
            yield return new WaitForSeconds(timeDelay);

        }
        BackToStartPosition();
        
    }
    public void BackToStartPosition()
    {
        foreach(GameObject stone in ruda)
        {
            stone.GetComponent<Rigidbody>().isKinematic = true;
            stone.transform.position = startPosition;
        }
    }
}
