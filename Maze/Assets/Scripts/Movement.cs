using UnityEngine;


public class Movement : MonoBehaviour {
    public float speed;
    public Rigidbody rb;
    public float f;
    // Update is called once per frame
    void Update()
    {
        float trans = Input.GetAxis("Vertical") * speed;
        float move = Input.GetAxis("Horizontal") * speed;
        trans *= Time.deltaTime;
        move *= Time.deltaTime;
            transform.Translate(move, 0, trans);
    }
}
