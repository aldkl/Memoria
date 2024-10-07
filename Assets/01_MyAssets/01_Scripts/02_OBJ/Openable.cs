using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Openable : Interactable
{
	public GameObject particle;

    public override void Interact()
    {
		Debug.Log("asadsfzzx");
		GameObject aaa = Instantiate(particle, transform.position, Quaternion.identity);
		aaa.GetComponent<ParticleSystem>().Play();
	}

}