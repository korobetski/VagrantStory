using UnityEngine;



namespace VagrantStory.Component
{


    [RequireComponent(typeof(BoxCollider))]
    public class MapSwitcher : MonoBehaviour
    {
        public GameObject destinationMap;
        public string sourceMapId;


        private BoxCollider _collider;
        private GameObject _mapContainer;
        private GameObject _destinationMarker;

        private void Start()
        {
            _collider = GetComponent<BoxCollider>();
            _collider.isTrigger = true;

            _mapContainer = gameObject.transform.parent.parent.parent.gameObject;
        }

        private void OnTriggerEnter(Collider other)
        {
            GameObject player = GameObject.FindWithTag("Player");
            player.transform.parent = _mapContainer.transform;

            // cleanning
            foreach (Transform child in _mapContainer.transform)
            {
                if (child.gameObject.tag != "Player")
                {
                    Destroy(child.gameObject);
                }
            }

            GameObject newMap = Instantiate(destinationMap);
            _destinationMarker = GameObject.Find(string.Concat("Marker Map #", sourceMapId));

            newMap.transform.parent = _mapContainer.transform;
            player.transform.parent = newMap.transform;
            player.transform.localPosition = _destinationMarker.transform.localPosition;
        }
    }

}