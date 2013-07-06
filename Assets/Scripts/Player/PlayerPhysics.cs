using UnityEngine;
using System.Collections;

public class PlayerPhysics : MonoBehaviour
{
    public float playerSpeed = 10.0f;

    public int xGridSize = 4;
    public int yGridSize = 4;

    private int frameDir = 0;
    public int currentFrame = 0;

    private float xGridPos = 0.0f;
    private float yGridPos = 0.0f;

    private float frameDur = 0.0f;
    private float nextTimeFrame = 0.0f;

    // Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetMotion();
	}

    void GetMotion()
    {
        float input = Input.GetAxisRaw("Vertical") * playerSpeed * Time.deltaTime;

        if (input != 0)
        {
            frameDir = (int)input;
        }

        xGridPos = 1.0f / xGridSize;
        yGridPos = 0.5f;

        renderer.material.mainTextureScale = new Vector2(frameDir * xGridPos, yGridPos);

        if (Time.time - nextTimeFrame > frameDur)
        {
            nextTimeFrame = frameDur + Time.time;

            currentFrame += frameDir;

            renderer.material.mainTextureOffset = new Vector2(frameDir * ((currentFrame) % xGridSize + 1) * xGridPos, 1);
        }
    }
}
