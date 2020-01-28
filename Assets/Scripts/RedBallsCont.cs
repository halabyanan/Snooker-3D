using System.Collections;
using System.Collections.Generic;
using UnityEngine;

   public class RedBallsCont : MonoBehaviour{
    // Start is called before the first frame update
     void Start()
    {
        
    }

   
    // Update is called once per frame
     void Update()
    {
        
    }

     public List<GameObject> GetAllChilds()
         {
      
             List<GameObject> list = new List<GameObject>();
             foreach (Transform child in transform)
             {
                 list.Add(child.gameObject);
                
             }
             return list;
    }

}