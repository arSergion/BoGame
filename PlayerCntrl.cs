using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerCntrl : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody _rd;
    public Text scoreText;
    private int _score;
    private void Awake() {
        _rd = GetComponent<Rigidbody>();
    }
    private void FixedUpdate() {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        _rd.AddForce(new Vector3(h, 1, v) * speed * Time.fixedDeltaTime);
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "CollectiveCube"){
            _score++;
            Destroy(other.gameObject);
            if(_score != 8)
                scoreText.text = "Score: " + _score;
            else
                scoreText.text = "You win!";
        }
    }
}
