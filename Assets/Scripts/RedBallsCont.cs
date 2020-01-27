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
        /*     Transform[] allChildren = GetComponentsInChildren<Transform>();
             List<Transform> list = new List<Transform>();
             for (int i = 0; i < GO.transform.childCount; i++)
              {
                  list.Add(GO.transform.GetChild(i).gameObject);
              }
             return list;*/
       //     GameObject[] allChildren = GetComponentsInChildren<GameObject>();
       //     return allChildren;
             List<GameObject> list = new List<GameObject>();
             foreach (Transform child in transform)
             {
                 list.Add(child.gameObject);
                 // do whatever you want with child transform object here
             }
             return list;
    }

}