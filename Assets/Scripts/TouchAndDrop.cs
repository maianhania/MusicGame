using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchAndDrop : MonoBehaviour {

    GameObject[] targets;
    // touch offset allows ball not to shake when it starts moving
    float deltaX, deltaY;

    //instantiate(respawnprefab, respawn.transform.position, respawn.transform.rotation);

    // reference to Rigidbody2D component
    Rigidbody2D rb;
    Collider2D col;

    // ball movement not allowed if you touches not the ball at the first time
    //bool moveAllowed = false;

    Vector2 originalPosition;
    Vector2 targetPosition;
    GameObject targetToAttach;
    private float threshold = 1;
    bool targetPositionChanged;
    Vector2 lastTouchPosition;

    public GameObject smilePrefab;
    //public Sprite sprite1;
    //public Sprite sprite2;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
        originalPosition = this.transform.position;
        Debug.Log("Original position: " + originalPosition);
    }

    // Update is called once per frame
    void Update()
    {

        HandleTouch();
    }

    void HandleTouch()
    {
        // Initiating touch event
        // if touch event takes place
        if (Input.touchCount > 0)
        {
            Debug.Log("Time " + Time.time);
            Debug.Log("Last touch position " + lastTouchPosition);

            // get touch to deal with
            Touch touch = Input.GetTouch(0);

            // obtain touch position
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            Debug.Log("Touch position: " + touchPos);

            Debug.Log("Original position" + originalPosition);

            if (Vector2.Distance(lastTouchPosition, originalPosition) < threshold)
            {
                Debug.Log("Template note picked up");
                targets = GameObject.FindGameObjectsWithTag("Target");
                float minDistance = float.MaxValue;
                int idx = 0;
                targetPosition = originalPosition;
                List<Vector2> targetPositions = new List<Vector2>();
                //targetPosition = this.transform.position;
                foreach (GameObject target in targets)
                {
                    //SpriteRenderer sr = target.GetComponent<SpriteRenderer>();
                    //Vector2 curTargetPosition = Camera.main.ScreenToWorldPoint(target.transform.position);

                    //record target position in target list
                    targetPositions.Add(target.transform.position);

                    Vector2 curTargetPosition = target.transform.position;
                    //Debug.Log("target " + idx + " position  " + curTargetPosition);
                    float distance = Vector2.Distance(curTargetPosition, this.transform.position);
                    //Debug.Log("Distance " + distance);
                    if (distance < minDistance && distance < threshold)
                    {
                        //Color old = sr.color;
                        //sr.sprite = sprite2;
                        //sr.color = new Color(0, 0, 0);
                        //yield return new WaitForSeconds(0.05f);
                        minDistance = distance;
                        targetPosition = curTargetPosition;
                        targetToAttach = target;
                        targetPositionChanged = true; // what does this do?
                        Debug.Log("Next target position using target " + idx);
                        Debug.Log("Next position is then " + targetPosition);
                        //instantiate(respawnprefab, respawn.transform.position, respawn.transform.rotation);
                    }
                    idx++;
                } 
                this.transform.position = targetPosition;
                Debug.Log("This will be the target position: " + (Vector2)this.transform.position);
                this.transform.SetParent(targetToAttach.transform);
                if ((Vector2)this.transform.position != originalPosition && (Vector2)this.transform.position != new Vector2(0.0f, 0.0f))
                {
                    // Need to replicate the note for next dragging

                    Instantiate(smilePrefab, originalPosition, Quaternion.identity);
                    Debug.Log("Smile prefab instantiated at " + originalPosition);
                }
            }

            // processing touch phases
            

            lastTouchPosition = touchPos;
        }
    }
}
