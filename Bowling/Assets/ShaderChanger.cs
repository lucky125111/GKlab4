using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderChanger : MonoBehaviour
{
    public Material m1;

    public Material m2;

    public Shader ConstPhong;
    public Shader ConstBlinn;
    public Shader GourardPhong;
    public Shader GourardBlinn;
    public Shader Phong;
    public Shader PhongBlinn;
    public Shader Static;
    public Shader Triangle;

    public GameObject Collection;

    // Use this for initialization
    void Start () {
        Collection.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Q))
	    {
	        m1.SetFloat("_Shininess", 3);
	        m2.SetFloat("_Shininess", 3);

            m1.shader = ConstPhong;
	        m2.shader = ConstPhong;
        }
	    if (Input.GetKey(KeyCode.W))
	    {
	        m1.SetFloat("_Shininess", 10);
	        m2.SetFloat("_Shininess", 10);

            m1.shader = ConstBlinn;
	        m2.shader = ConstBlinn;
	    }
	    if (Input.GetKey(KeyCode.E))
	    {
	        m1.SetFloat("_Shininess", 3);
	        m2.SetFloat("_Shininess", 3);

            m1.shader = GourardPhong;
	        m2.shader = GourardPhong;
	    }
	    if (Input.GetKey(KeyCode.R))
	    {
	        m1.SetFloat("_Shininess", 10);
	        m2.SetFloat("_Shininess", 10);

            m1.shader = GourardBlinn;
	        m2.shader = GourardBlinn;
	    }
	    if (Input.GetKey(KeyCode.T))
	    {
	        m1.SetFloat("_Shininess", 3);
	        m2.SetFloat("_Shininess", 3);

            m1.shader = Phong;
	        m2.shader = Phong;
	    }
	    if (Input.GetKey(KeyCode.Y))
	    {
	        m1.SetFloat("_Shininess", 10);
	        m2.SetFloat("_Shininess", 10);

            m1.shader = PhongBlinn;
	        m2.shader = PhongBlinn;
        }
	    if (Input.GetKey(KeyCode.U))
	    {

	        m1.shader = Static;
	        m2.shader = Static;
	    }
	    if (Input.GetKey(KeyCode.I))
	    {
	        m1.SetFloat("_Shininess", 10);
	        m2.SetFloat("_Shininess", 10);

            m1.shader = Triangle;
	        m2.shader = Triangle;
	    }
    }
}
