using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PedresteAI : MonoBehaviour
{
    private bool isGamePaused = false;

    public GameObject[] targets;
    private GameObject target;

    public float maxSpeed = 10.0f;
    public float minSpeed = 3.0f;
    public float speed = 5.0f;
    public float maxForce = 15f;
    public float mass = 15f;
    private Vector3 velocity;
    private Vector2 position;
    public float MAX_AVOID_FORCE;
    private List<GameObject> listObjects = new List<GameObject>();
    public float offsetRay;
    public float raycastMultiplier;
    private Rigidbody2D rb;

    private float iniPositionY;

    void Start()
    {
        target = targets[Random.Range(0, 3)];
        //maxSpeed = Random.Range(maxSpeed - 4, maxSpeed);
        //speed = Random.Range(minSpeed, maxSpeed -5);
        position = transform.localPosition;
        iniPositionY = position.y;
        velocity = Vector3.zero;
        //Debug.Log("VeloInicial: " + velocity);
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isGamePaused)
        {
            rb.velocity = seekDirection();
        }
    }

    public void setPauseGame(bool pauseStatus)
    {
        isGamePaused = pauseStatus;
    }

    Vector2 seekDirection()
    {
        Vector3 desiredVelocity = ((target.gameObject.transform.localPosition - gameObject.transform.localPosition).normalized * maxSpeed);
        Vector3 steering = desiredVelocity - velocity;
        var avoid = avoidBehaviour();
        //Debug.Log(avoid);
        steering = steering + avoid;

        steering = Vector3.ClampMagnitude(steering, maxForce);
        steering /= mass;

        velocity = Vector3.ClampMagnitude(velocity + steering, speed);

        position.x = velocity.x;
        position.y = velocity.y;

        Debug.DrawRay(transform.position, velocity, Color.green);

        Debug.DrawRay(transform.position, desiredVelocity, Color.magenta);

        return position;
    }

    Vector3 avoidBehaviour()
    {
        Vector3 avoidance = Vector3.zero;

        Vector2 endPoint = Vector2.zero;

        Vector2 startPoint = gameObject.GetComponent<CapsuleCollider2D>().bounds.center;

        //int instanceID = castRayMid(startPoint, endPoint);
        avoidance += castRayTop(startPoint, endPoint);
        //Debug.Log("AVOID A: " + avoidance);
        avoidance += castRayBot(startPoint, endPoint);
        //Debug.Log("AVOID B: " + avoidance);
        avoidance += castRayMid(startPoint, endPoint);
        //avoidance += castRayMid(startPoint, endPoint);
        //Debug.Log("AVOID C:" + avoidance);

        
        /*if(listObjects.Count > 0)
        {
            // calc distance from center of collider to center of other collider
            // to discover which object is closer

            GameObject mostThreatning = null;
            float distance = 400.0f;

            for(int i = 0; i < listObjects.Count; i++)
            {
                GameObject targetTEMP = listObjects[i];
                float distanceTEMP = calcDistance(gameObject.GetComponent<CapsuleCollider2D>().bounds.center, 
                    targetTEMP.GetComponent<CapsuleCollider2D>().bounds.center);
                 
                if(distanceTEMP < distance)
                {
                    mostThreatning = targetTEMP;
                    distance = distanceTEMP;
                }
            }
            avoidance = (gameObject.GetComponent<CapsuleCollider2D>().bounds.center + (velocity * raycastMultiplier)) - mostThreatning.GetComponent<CapsuleCollider2D>().bounds.center;

            avoidance = avoidance * MAX_AVOID_FORCE;
            
        }
        //Debug.Log(avoidance);
        
        listObjects.Clear();*/

        Debug.Log("AVOID FINAL: " + (avoidance * MAX_AVOID_FORCE).normalized);

        return (avoidance * MAX_AVOID_FORCE).normalized;
    }

    Vector3 castRayTop(Vector2 startPoint, Vector2 endPoint)
    {
        endPoint.x = velocity.x * raycastMultiplier;
        startPoint.y = startPoint.y + offsetRay;

        Vector3 ahead = (startPoint + endPoint);

        Debug.DrawRay(startPoint, endPoint, Color.green);

        RaycastHit2D[] hitsUpper = Physics2D.RaycastAll(startPoint, endPoint);

        if (hitsUpper.Length > 0)
        {
            GameObject mostThreatning = null;
            float distance = 400.0f;

            foreach (RaycastHit2D r in hitsUpper)
            {
                if (r.collider.gameObject.CompareTag("Pedreste") || r.collider.gameObject.CompareTag("Player"))
                {
                    GameObject targetTEMP = r.collider.gameObject;
                    float distanceTEMP = calcDistance(gameObject.GetComponent<CapsuleCollider2D>().bounds.center,
                        targetTEMP.GetComponent<CapsuleCollider2D>().bounds.center);

                    if (distanceTEMP < distance)
                    {
                        mostThreatning = targetTEMP;
                        distance = distanceTEMP;
                    }
                }
            }

            if(mostThreatning != null)
            {
                Vector3 avoid = (ahead - mostThreatning.gameObject.GetComponent<CapsuleCollider2D>().bounds.center);
                avoid.y = Random.Range(-1, -2);
                return avoid.normalized;
            }

            //if (hitUpper.collider.CompareTag("Pedreste") || hitUpper.collider.CompareTag("Player"))
            //return (hitUpper.collider.gameObject.GetComponent<CapsuleCollider2D>().bounds.center - gameObject.GetComponent<CapsuleCollider2D>().bounds.center);
        }
        return Vector3.zero;
    }

    Vector3 castRayBot(Vector2 startPoint, Vector2 endPoint)
    {
        endPoint.x = velocity.x * raycastMultiplier;
        startPoint.y = startPoint.y - offsetRay;

        Vector3 ahead = (startPoint + endPoint);

        Debug.DrawRay(startPoint, endPoint, Color.red);
        RaycastHit2D[] hitsLower = Physics2D.RaycastAll(startPoint, endPoint);

        if (hitsLower.Length > 0)
        {
            GameObject mostThreatning = null;
            float distance = 400.0f;

            foreach (RaycastHit2D r in hitsLower)
            {
                if (r.collider.gameObject.CompareTag("Pedreste") || r.collider.gameObject.CompareTag("Player"))
                {
                    GameObject targetTEMP = r.collider.gameObject;
                    float distanceTEMP = calcDistance(gameObject.GetComponent<CapsuleCollider2D>().bounds.center,
                        targetTEMP.GetComponent<CapsuleCollider2D>().bounds.center);

                    if (distanceTEMP < distance)
                    {
                        mostThreatning = targetTEMP;
                        distance = distanceTEMP;
                    }
                }               
            }

            if (mostThreatning != null)
            {
                Vector3 avoid = (ahead - mostThreatning.gameObject.GetComponent<CapsuleCollider2D>().bounds.center);
                avoid.y = Random.Range(1, 2);
                return avoid.normalized;
            }
            //if(hitLower.collider.CompareTag("Pedreste") || hitLower.collider.CompareTag("Player"))
            //return (hitLower.collider.gameObject.GetComponent<CapsuleCollider2D>().bounds.center - gameObject.GetComponent<CapsuleCollider2D>().bounds.center);
        }

        return Vector3.zero;
    }

    Vector3 castRayMid(Vector2 startPoint, Vector2 endPoint)
    {
        
        //startPoint.x = startPoint.x;// + (offsetRay * 4);
        endPoint.x = velocity.x * 0.5f;

        Vector3 ahead = (startPoint + endPoint);

        Debug.DrawRay(startPoint, endPoint, Color.yellow);

        RaycastHit2D[] hitsMid = Physics2D.RaycastAll(startPoint, endPoint);
        if (hitsMid.Length > 0)
        {
            GameObject mostThreatning = null;
            float distance = 400.0f;

            foreach (RaycastHit2D r in hitsMid)
            {
                if (r.collider.gameObject.CompareTag("Pedreste") || r.collider.gameObject.CompareTag("Player"))
                {
                    GameObject targetTEMP = r.collider.gameObject;
                    float distanceTEMP = calcDistance(gameObject.GetComponent<CapsuleCollider2D>().bounds.center,
                        targetTEMP.GetComponent<CapsuleCollider2D>().bounds.center);

                    if (distanceTEMP < distance)
                    {
                        mostThreatning = targetTEMP;
                        distance = distanceTEMP;
                    }
                }
            }

            if (mostThreatning != null)
            {
                Vector3 avoid = (ahead - mostThreatning.gameObject.GetComponent<CapsuleCollider2D>().bounds.center);
                avoid.y = Random.Range(-2, 2);
                return avoid.normalized;
            }
            //if (hitMid.collider.CompareTag("Pedreste") || hitMid.collider.CompareTag("Player"))
            //return (hitMid.collider.gameObject.GetComponent<CapsuleCollider2D>().bounds.center - gameObject.GetComponent<CapsuleCollider2D>().bounds.center);
        }
        return Vector3.zero;
    }

    float calcDistance(Vector3 a, Vector3 b)
    {
        return Mathf.Sqrt((a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y));
    }

    public float getInitialPositionY()
    {
        return iniPositionY;
    }

    public void setNewSpeed()
    {
        //speed = Random.Range(minSpeed, maxSpeed - 2);
    }

    void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.tag == "Pedreste")
        {

        }
    }

    public void changeTarget()
    {
        target = targets[Random.Range(0, 3)];
    }

    /*
    private void OnDisable()
    {
        list.Clear();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Filter by using specific layers for this object and "others" instead of using tags
        if(col.gameObject.tag == "PedresteAvoid")
        {
            Debug.Log("avoid");
            list.Add(col.gameObject);
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        // Filter by using specific layers for this object and "others" instead of using tags
        if (col.gameObject.tag == "PedresteAvoid")
        {
            Debug.Log("notAvoid");
            list.Remove(col.gameObject);
        }

    }*/

    #region a
    /*
    Vector3 avoidanceCall()
    {

        Vector3 ahead = (position + velocity.normalized) * MAX_SEE_AHEAD;
        Vector3 ahead2 = ahead * 0.5f;

        Debug.DrawRay(position, ahead, Color.green);
        Debug.DrawRay(position, ahead2, Color.magenta);

        var mostThreatening = findObstacle(position3, ahead, ahead2);

        Vector3 avoidance = new Vector3(0, 0, 0);

        if (mostThreatening != null)
        {
            avoidance.x = ahead.x - mostThreatening.gameObject.transform.localPosition.x;
            avoidance.y = ahead.y - mostThreatening.gameObject.transform.localPosition.y;

            avoidance = avoidance.normalized * MAX_AVOID_FORCE;
        }
        else
        {
            avoidance = Vector3.zero; // nullify the avoidance force
        }

        return avoidance;
    }

    GameObject findObstacle(Vector3 positionTmp, Vector3 ahead, Vector3 ahead2)
    {
        GameObject mostThreatening = null;

        if (list.Count > 0)
        {
            for (int i = 0; i < list.Count; i++)
            {
                var obstacle = list[i];
                bool collision = lineIntersecsCircle(ahead, ahead2, obstacle.GetComponent<CapsuleCollider2D>());

                // "position" is the character's current position
                if (collision && (mostThreatening == null || calcDistance(positionTmp, obstacle.transform.localPosition)
                    < calcDistance(positionTmp, mostThreatening.transform.localPosition)))
                {
                    mostThreatening = obstacle;
                }
            }
        }
        return mostThreatening;
    }

    float calcDistance(Vector3 a, Vector3 b)
    {
        return Mathf.Sqrt((a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y));
    }

    bool lineIntersecsCircle(Vector3 ahead, Vector3 ahead2, CapsuleCollider2D aaa)
    {
        float radius = 0.5f * Mathf.Min(aaa.bounds.size.x, aaa.bounds.size.y);
        return calcDistance(aaa.bounds.center, ahead) <= radius || calcDistance(aaa.bounds.center, ahead2) <= radius;
    }
    */
    #endregion
}
