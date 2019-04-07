using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public Transform to;
    public float speed = 10f;
    public float dis = 10f;
    public Rigidbody rb;
    public float t;

    void move(Vector3 s, Vector3 dir, int speed,float d)
    {
        float p = d/speed;
        for(int i = 0; i < speed; i++)
        {
            transform.position += dir * p;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        

        if ((transform.position.x % 5 == 0 && transform.position.x % 10 != 0) && (transform.position.z % 5 == 0 && transform.position.z % 10 != 0))
        {

            Ray rf = new Ray(transform.position, transform.forward);
            RaycastHit rfinfo;
            bool fm = false;
            Ray rbw = new Ray(transform.position, transform.forward * -1);
            RaycastHit rbwinfo;
            bool bm = false;
            Ray rl = new Ray(transform.position, transform.right * -1);
            RaycastHit rlinfo;
            bool lm = false;
            Ray rr = new Ray(transform.position, transform.right);
            RaycastHit rrinfo;
            bool mr = false;




            if (Physics.Raycast(rf, out rfinfo) && Mathf.Abs(rfinfo.transform.position.z - transform.position.z) > 5)
            {
                fm = true;
            }
            else { fm = false; }

            if (Physics.Raycast(rbw, out rbwinfo) && Mathf.Abs(rbwinfo.transform.position.z - transform.position.z) > 5)
            {
                bm = true;
            }
            else { bm = false; }

            if (Physics.Raycast(rl, out rlinfo) && Mathf.Abs(rlinfo.transform.position.x - transform.position.x) > 5)
            {
                lm = true;
            }
            else { lm = false; }

            if (Physics.Raycast(rr, out rrinfo) && Mathf.Abs(rrinfo.transform.position.x - transform.position.x) > 5)
            {
                mr = true;
            }
            else { mr = false; }

            Dictionary<string, bool> motioncons = new Dictionary<string, bool>();
            motioncons.Add("F", fm);
            motioncons.Add("B", bm);
            motioncons.Add("L", lm);
            motioncons.Add("R", mr);
            List<string> key = new List<string>();

            foreach (KeyValuePair<string, bool> entry in motioncons)
            {
                if (entry.Value == true)
                {
                    key.Add(entry.Key);
                }
            }
            for (int j = 0; j < key.Count; j++)
            {
                Debug.Log(key[j] + "j");

            }
            int ind = Random.Range(0, key.Count - 1);
            string rand = key[ind];
            Vector3 v = transform.position;

            if (rand == "F")
            {
                Debug.Log("OKF");
                move(v, transform.forward, 10 , 10f);


            }
            else if (rand == "B")
            {
                Debug.Log("OKB");
                move(v, -transform.forward, 1000, 10f);

            }
            else if (rand == "L")
            {
                Debug.Log("OKL");
                move(v, -transform.right, 10, 10f);
            }
            else if (rand == "R")
            {
                Debug.Log("OKR");
                move(v, transform.right, 10, 10f);
            }

        }
    }
}
