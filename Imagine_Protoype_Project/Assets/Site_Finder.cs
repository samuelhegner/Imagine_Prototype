using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Site_Finder : MonoBehaviour {

    GameObject[] sites;

    GameObject closestSite;

    float closestSiteDist;
    public float viewingDistance;

    void Awake(){
        sites = GameObject.FindGameObjectsWithTag("Site");
        closestSiteDist = Vector3.Distance(transform.position, sites[0].transform.position);
    }

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
        closestSiteDist = float.MaxValue;

        for (int i = 0; i < sites.Length; i++) {

            GameObject site = sites[i];
            site.transform.GetChild(0).gameObject.SetActive(false);
            if (Vector3.Distance(transform.position, site.transform.position) < closestSiteDist)
            {
                closestSiteDist = Vector3.Distance(transform.position, site.transform.position);
                closestSite = site;
            }
        }

        if (Vector3.Distance(transform.position, closestSite.transform.position) < viewingDistance)
        {
            closestSite.transform.GetChild(0).gameObject.SetActive(true);
        }
        else {
            closestSite.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
