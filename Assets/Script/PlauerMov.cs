using System;
using System.Collections;
using System.Collections.Generic;
using Script.Core;
using Script.UIVIew;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlauerMov : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField]
    private float directForce;
    [SerializeField] 
    private float turnForce;
    [SerializeField] 
    private float maxSpeed;
    [SerializeField] public int coins;
    [SerializeField] private Text coinsText;
    public static float CoinDisp;

    //[SerializeField] private GameOverRunnerUIView GameOverRunner;
    

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
        
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(0, 0, directForce * Time.fixedTime);
        var velocity = _rigidbody.velocity;
        _rigidbody.velocity = new Vector3(velocity.x, velocity.y, Math.Min(velocity.z, maxSpeed));
    
    
        if (Input.GetKey(KeyCode.D))
        {
            _rigidbody.AddForce(turnForce * Time.fixedTime, 0, directForce);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _rigidbody.AddForce(-turnForce * Time.fixedTime, 0, directForce);
        }
        if (_rigidbody.transform.position.y < -10)
        {    
            Debug.Log("game over");
            GameContext.Instance.ShowView(nameof(GameOverRunnerUIView));
            var scene = SceneManager.GetActiveScene().name;
            GameContext.Instance.SceneService.UnLoadScene(scene);
            Debug.Log(scene);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        coins--;
        coinsText.text = coins.ToString();
        CoinDisp = coins;
    }
    

}
