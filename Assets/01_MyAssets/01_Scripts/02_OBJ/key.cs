using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class key : Interactable
{
	public GameObject particle;

	public override void Interact()
	{
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.IsKey = true;
            gameObject.SetActive(false);
        }
    }
}