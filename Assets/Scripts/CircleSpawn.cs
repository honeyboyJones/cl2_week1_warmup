using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CircleSpawn : MonoBehaviour
{
    public GameObject circle;
    public Sprite[] sprites;
    //public GameObject go; //not needed

    public int score = 0; //holds score
    public TMP_Text scoreText; //access TMP score text box

    //simple singleton, not sure if needed, but i think they are important for 
    //manager-type scripts that are used to hold and recieve things from other scritps
    public static CircleSpawn instance;
    public static CircleSpawn GetInstance()
    {
        return instance;
    }

    //part of the singleton that maintains one single instance of this script
    //DontDestroyOnLoad maintains this gameObject when loading a new scene
    //There is only one scene here now, but this is what i used for the singleton before
    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    //called before the first frame update
    void Start()
    {
        //Instantiate(Resources.Load("Prefabs/Circle"));
        InvokeRepeating("Spawn", 1, 1);
    }

    //called once per frame
    void Update()
    {
        //converts score number to string to be printed in TMPro box on screen
        scoreText.text = "SCORE: " + score.ToString();

        //this needs to be done somewhere else
        // if(Input.GetMouseButton(0))
        // {
        //     print("DESTROYED");
        //     //DestroyPrefab();
        // }
    }

    public void Spawn()
    {
        //float screenX, screenY;
        //Vector3 pos = transform.position + randPos;

        //to randomize the X and Y positions between the edges of the screen, used when
        //instantiating a new circle
        var position = new Vector3(Random.Range(-10, 10), Random.Range(-5, 5), 0);

        //GameObject go = Instantiate(Resources.Load("Prefabs/Circle")) as GameObject;
        GameObject go = Instantiate(circle, position, transform.rotation);
        int num = GetComponent<ColorPicker>().SetSprite();
        go.GetComponent<SpriteRenderer>().sprite = sprites[num];

        //MeshCollider col = go.GetComponent<MeshCollider>();

        //screenX = Random.Range(col.bounds.min.x, col.bounds.max.x);
        //screenY = Random.Range(col.bounds.min.y, col.bounds.max.y);
        //Vector3 randPos = new Vector3(screenX, screenY, 0);
    }

    //isnt actually working, needs to be done on a different script
    // void DestroyPrefab()
    // {
    //     Destroy(go);
    // }

    //for adding points to the score
    public void AddPoint()
    {
        score += 1;
    }
}
