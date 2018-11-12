using UnityEngine;

public class FollowAgent : MonoBehaviour {

    public Transform agent;
    public Vector3 offset;

	// Update is called once per frame
	private void Update () {
        transform.position = agent.position + offset;

	}
}
