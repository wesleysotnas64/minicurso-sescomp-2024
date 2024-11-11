using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector2 direction;
    public float speed;
    public bool isActive;

    // Pontos Colaterais (Intermediários)
    private Vector2 nordeste = new Vector2(0.707f, 0.707f);   // Nordeste (NE)
    private Vector2 sudeste = new Vector2(0.707f, -0.707f);   // Sudeste (SE)
    private Vector2 sudoeste = new Vector2(-0.707f, -0.707f); // Sudoeste (SW)
    private Vector2 noroeste = new Vector2(-0.707f, 0.707f);  // Noroeste (NW)

    // Pontos Subcolaterais (Intermediários dos Intermediários)
    private Vector2 lesteNordeste = new Vector2(0.924f, 0.383f);   // Leste-Nordeste (ENE)
    private Vector2 lesteSudeste = new Vector2(0.924f, -0.383f);   // Leste-Sudeste (ESE)
    private Vector2 oesteSudoeste = new Vector2(-0.924f, -0.383f); // Oeste-Sudoeste (WSW)
    private Vector2 oesteNoroeste = new Vector2(-0.924f, 0.383f);  // Oeste-Noroeste (WNW)

    public List<Vector2> directions = new List<Vector2>();

    void Start()
    {
        isActive = false;
        direction = Vector2.zero;

        directions.Add(nordeste);
        directions.Add(sudeste);
        directions.Add(sudoeste);
        directions.Add(noroeste);

        directions.Add(lesteNordeste);
        directions.Add(lesteSudeste);
        directions.Add(oesteSudoeste);
        directions.Add(oesteNoroeste);
    }

    
    void Update()
    {
        if(isActive == true)
        {
            direction = direction.normalized * speed * Time.deltaTime;
            transform.Translate(direction.x, direction.y, 0);

            if(transform.position.x >= 8 || transform.position.x <= -8) Point();
        }

        

        if(Input.GetKeyDown(KeyCode.Space)) InitBall();
    }

    public void Point()
    {
        isActive = false;
        direction = Vector2.zero;
        transform.position = new Vector3(0, -0.5f, 0);
    }

    public void InitBall()
    {
        isActive = true;

        float y = Random.Range(-3.0f, 2.0f);

        int dir = Random.Range(0, 8);

        transform.position = new Vector3(0, y, 0);
        
        direction = directions[dir];
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D");
        string tag = col.gameObject.tag;

        if(tag == "Wall")
        {
            direction = ReflectDirection(direction.normalized, col.gameObject.transform.up);
        }
        else if(tag == "Player")
        {
            direction = ReflectDirection(direction, col.gameObject.transform.right);
        }
        
    }

    private Vector2 ReflectDirection(Vector2 _direction, Vector2 _normal)
    {
        return _direction - 2 * Vector2.Dot(_direction, _normal) * _normal;
    }
}
