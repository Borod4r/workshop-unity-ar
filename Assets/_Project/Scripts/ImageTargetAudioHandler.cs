using UnityEngine;
using System.Collections;
using Vuforia;

public class ImageTargetAudioHandler : MonoBehaviour, ITrackableEventHandler
{
    [SerializeField]
    private AudioSource _audio;
    private TrackableBehaviour _trackableBehaviour;

    public void Awake()
    {
        _trackableBehaviour = GetComponent<TrackableBehaviour>();
    }

    protected void Start()
    {
        if (_trackableBehaviour) _trackableBehaviour.RegisterTrackableEventHandler(this);
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.TRACKED || newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            // Play audio when target is found
            _audio.Play();
        }
        else
        {
            // Stop audio when target is lost
            _audio.Stop();
        }
    }
}
