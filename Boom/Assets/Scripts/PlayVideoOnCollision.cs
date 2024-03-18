using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideoOnCollision : MonoBehaviour
{
    public VideoPlayer videoPlayer; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "TV")
        {
            videoPlayer.Play();
            
        }//Play the video when player achieves the destination.  
    }
}
//Tomato egg stir-fry
//Start by cutting tomatoes into small wedges.Be sure to remove the stems.
//Finely chop the scallion. Then crack 4 eggs into a bowl and season with ¼ teaspoon salt, ¼ teaspoon white pepper, ½ teaspoon sesame oil, and 1 teaspoon Shaoxing wine. Beat eggs for a minute.
//Preheat the wok over medium heat until it just starts to smoke. Then add 2 tablespoons of oil and immediately add the eggs. Scramble the eggs and remove from the wok immediately. Set aside.
//Add 1 more tablespoon oil to the wok, turn up the heat to high, and add the tomatoes and scallions.
//Stir-fry for 1 minute, and then add 2 teaspoons sugar, 1/2 teaspoon salt (or to taste), and ¼ cup water (if your stove gets very hot and liquid tends to cook off very quickly in your wok, add a little more water). Add the cooked eggs.