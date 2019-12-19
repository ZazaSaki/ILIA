using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{   
    public Transform Dysplay;
    public Health playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
    }

    private void UpdateHealth(){
        int num = 0, i = 0;
        num = (Dysplay.childCount - 1);

        num = (int)(playerHealth.maxhealth/num);

        foreach (Transform bar in Dysplay)
        {
            if (playerHealth.health > num * i){
                bar.gameObject.SetActive(true);
            }else
                bar.gameObject.SetActive(false);
            
            i++;
        }
            
        
    }
}
