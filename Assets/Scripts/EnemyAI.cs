using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{

		// Fix a range how early u want your enemy detect the obstacle.
		private int range;
		private float speed ;
		private bool isThereAnyThing = false;
		public GameObject target;
		private float rotationSpeed ;
		// Use this for initialization
		void Start ()
		{
				range = 80;
				speed = 10f;
				rotationSpeed = 15f;
		}
	
		// Update is called once per frame
		void Update ()
		{
				//Look At Somthly Towards the Target.
				if (!isThereAnyThing) {
						Vector3 relativePos = target.transform.position - transform.position;
						Quaternion rotation = Quaternion.LookRotation (relativePos);
						transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime);
				}
				// Enemy translate in forward direction.
				transform.Translate (Vector3.forward * Time.deltaTime * speed);

		

				//Checking for any Obstacle in front.
				// Two rays left and right to the object to detect the obstacle.
				Transform leftRay = transform;
				Transform rightRay = transform;

				//Use Phyics.RayCast to detect the obstacle 

				if (Physics.Raycast (leftRay.position + (transform.right * 7), transform.forward, range)) {
						isThereAnyThing = true;
						transform.Rotate (Vector3.up * Time.deltaTime * rotationSpeed);
				}

				if (Physics.Raycast (rightRay.position - (transform.right * 7), transform.forward, range)) {
						isThereAnyThing = true;
						transform.Rotate (Vector3.up * Time.deltaTime * rotationSpeed);
				}

				// Now Two More RayCast At The End of Object to detect that object has already overcome the obsatacle.

				if (Physics.Raycast (transform.position - (transform.forward * 4), transform.right, 10)) {
						// Just making this boolean variable false it means there is nothing in front of object.
						isThereAnyThing = false;
				}

				if (Physics.Raycast (transform.position - (transform.forward * 4), -transform.right, 10)) {
						// Just making this boolean variable false it means there is nothing in front of object.
						isThereAnyThing = false;
				}

		// Use to debug the Physics.RayCast.
				Debug.DrawRay (transform.position + (transform.right * 7), transform.forward * 20, Color.red);

				Debug.DrawRay (transform.position - (transform.right * 7), transform.forward * 20, Color.red);

				Debug.DrawRay (transform.position - (transform.forward * 4), - transform.right * 20, Color.yellow);

				Debug.DrawRay (transform.position - (transform.forward * 4), transform.right * 20, Color.yellow);


	
		}
}
