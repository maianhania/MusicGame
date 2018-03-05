using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragScript : MonoBehaviour
{
    public GameObject scrollBar;
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
        scrollBar.GetComponent<Scrollbar>().onValueChanged.AddListener(ScrollbarCallBack);
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
        originalPosition = this.transform.position;
        Debug.Log("Original position: " + originalPosition);
    }

    private void ScrollbarCallBack(float arg0)
    {
        Debug.Log("Scrollbar being used");
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

            // get touch to deal with
            Touch touch = Input.GetTouch(0);

            // obtain touch position
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            
            //if (touchPos.x > -8 && touchPos.x < 6.5 )


            Debug.Log("Touch position: " + touchPos);

            // processing touch phases
            switch (touch.phase)
            {

                // if you touches the screen
                case TouchPhase.Began:
                    Debug.Log("TouchPhase began");

                    // if you touch the ball
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        Debug.Log("Template note touched");
                        //GetComponent<CanvasGroup>().blocksRaycasts = false;

                        // get the offset between position you touhes
                        // and the center of the game object
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;

                        // if touch begins within the ball collider
                        // then it is allowed to move
                        //moveAllowed = true;

                        // restrict some rigidbody properties so it moves
                        // more smoothly and correctly
                        //rb.freezeRotation = true;
                        //rb.velocity = new Vector2(0, 0);
                        //rb.gravityScale = 0;
                    }
                    break;

                // you move your finger
                case TouchPhase.Moved:
                    Debug.Log("TouchPhase moved");
                    // if you touches the ball and movement is allowed then move
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        //if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos) && moveAllowed)
                        rb.MovePosition(new Vector2(touchPos.x - deltaX, touchPos.y - deltaY));
                        //col.enabled = false; // disable interacting with targets
                    }
                    targets = GameObject.FindGameObjectsWithTag("Target");
                    //GameObject[] targetGameObjects = FindObjectsOfType(GameObject) as GameObject[];
                    foreach(GameObject target in targets) {
                        if (target.name.Contains("Note-E5"))
                        {
                            Debug.Log("Found Note-E5");
                        }
                    }

                    float minDistance = float.MaxValue;
                    int idx = 0;
                    targetPosition = originalPosition;
                    //targetPosition = this.transform.position;
                    foreach (GameObject target in targets)
                    {
                        //SpriteRenderer sr = target.GetComponent<SpriteRenderer>();
                        //Vector2 curTargetPosition = Camera.main.ScreenToWorldPoint(target.transform.position);
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
                            targetPositionChanged = true;
                            Debug.Log("Next target position using target " + idx);
                            Debug.Log("Next position is then " + targetPosition);
                            //instantiate(respawnprefab, respawn.transform.position, respawn.transform.rotation);
                        }
                        idx++;
                    }

                    break;

                // you release your finger
                case TouchPhase.Ended:
                    Debug.Log("TouchPhase ended");
                    this.transform.position = targetPosition;
                    this.transform.SetParent(targetToAttach.transform);
                    Debug.Log("This will be the target position: " + (Vector2) targetToAttach.transform.position);
                    targetToAttach.GetComponent<SpriteRenderer>().color = targetToAttach.GetComponent<Note>().color;
                    //targetToAttach.GetComponent<CircleCollider2D>().enabled = true;
                    if ((Vector2) this.transform.position != (Vector2)  originalPosition 
                        && (Vector2)this.transform.position != new Vector2(0.0f,0.0f) 
                        && (Vector2)this.transform.position != new Vector2(7.0f, 2.2f))
                    {
                        // Need to replicate the note for next dragging

                        Instantiate(smilePrefab, originalPosition, Quaternion.identity);
                        Debug.Log("Smile prefab instantiated at " + originalPosition);
                    }
                    //col.enabled = true; // enable interacting with targets
                    // restore initial parameters
                    // when thouch is ended
                    //GetComponent<CanvasGroup>().blocksRaycasts = true;
                    //moveAllowed = false;
                    //rb.freezeRotation = false;
                    break;
            }

            lastTouchPosition = touchPos;
        }
    }
}