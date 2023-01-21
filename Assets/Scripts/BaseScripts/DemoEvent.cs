using UnityEngine;

/*
 * This script should **NEVER** be used directly. 
 * I've left this here as an example of how you create an event and interface with my Event base class
 */

/// <summary>
/// This is an example of a script that you might make for an event to 'swap' two game objects with each other.
/// Note that we inherit from Event and not MonoBehaviour on line 14
/// This assumes some setup in the editor where this script is on an empty parent object and the two objects that are being swapped are children of that empty object.
/// See the screenshot in the documentation for a better visual if you're confused.
/// </summary>
public class SwapObjects : Event
{
    //In this instance, the originalObject is the normal office prop.
    //Note that both of these GameObjects would need to be assigned in the editor as they are public in this case.
    public GameObject originalObject;
    //This would be the new weird object that would replace it.
    public GameObject newObject;

    /// <summary>
    /// Whenever you make an event, everything that you want to happen should occur in this PeformEvent function.
    /// PerformEvent is a function that you inherit from the Event class
    /// Always make sure to include at the very beginning the a call to the version of the function that exists in the base class like on line 29: 'base.PerformEvent();'
    /// </summary>
    protected override void PerformEvent()
    {
        //Always make sure this base call comes first.
        base.PerformEvent();
        
        //This is the super simple way to make two objects appear to swap.
        //First, set the original object as inactive and then immediately set the new object as active instead.
        //This works because both are in the same location in the game but only one of them is active at any given time.
        originalObject.SetActive(false);
        newObject.SetActive(true);
        
        //Always make sure to call FinishEvent at the end of your PerformEvent function otherwise the manager will not know your event is over.
        FinishEvent();
    }
}
