using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusScript : MonoBehaviour
{
    public VirusGenerator virusGenerator;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * virusGenerator.currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("nextLine")) {
            virusGenerator.GenerateNextVirusWithGap();
        }

        if(collision.gameObject.CompareTag("FinishLine")) {
            Destroy(this.gameObject);
        }
    }
}
