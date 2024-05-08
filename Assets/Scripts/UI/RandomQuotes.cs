using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomQuotes : MonoBehaviour
{

    public TextMeshProUGUI txtSubGame;
    private string[] quotes = {"War does not determine who is right - only who is left.",
                                "When you do crazy things, expect crazy results",
                                "I dream of a better tomorrow, where chickens can cross the road and not be quested about their motives",
                                "No I didn't trip, the floor looked like it needed a hug",
                                "Better late than never, but never late is better",
                                "I was standing in the park wondering why frisbees got bigger as they get closer. Then it hit me.",
                                "When tempted to fight fire with fire, remember that the fire department generally uses water.",
                                "Some cause happiness wherever they go, others whenever they go.",
                                "Never underestimate the power of stupid people in large groups",
                                "Behind every great man is a woman rolling her eyes.",
                                "Perfection is not attainable, but if we chase perfection we can catch excellence.",
                                "An idea isn't responsible for the people who believe in it.",
                                "I would like to die on Mars. Just not on impact.",
                                "If women ran the world we wouldn't have wars, just intense negotiations every 28 days. [Robin Williams]",
                                "Between two evils, I always pick the one I never tried before.",
                                "If two wrongs don't make a right, try three.",	
                                "Man cannot live by bread alone, he must have peanut butter.",
                                "A pessimist is a person who has had to listen to too many optimists.",
                                "All men are equal before fish.",
                                "I've never been married, but I tell people I'm divorced so they won't think something is wrong with me.",
                                "O Lord, help me to be pure, but not yet.",
                                "Any kid will run any errand for you, if you ask at bedtime.",
                                "We owe to the Middle Ages the two worst inventions of humanity - romantic love and gunpowder.",
                                "Guilt: the gift that keeps on giving.",
                                "The point of war is not to die for your country, but to make the noob on the other side die for his",
                                "Always borrow money from a pessimist. He won't expect it back.",
                                "Friendship is like peeing on yourself: everyone can see it, but only you get the warm feeling that it brings.",
                                "Dogs have masters. Cats have staff.",
                                "Knowledge is knowing a tomato is a fruit, wisdom is not putting it in a fruit salad.",
                                "Why do people say 'no offense' right before they're about to offend you?",
                                "I asked God for a bike, but I know God doesn't work that way. So I stole a bike and asked for forgiveness.",
                                "The best way to lie is to tell the truth . . . carefully edited truth.",
                                "Do not argue with an idiot. He will drag you down to his level and beat you with experience.",
                                "The only mystery in life is why the kamikaze pilots wore helmets.",
                                "Going to church doesn't make you a Christian any more than standing in a garage makes you a car.",
                                "A bargain is something you don't need at a price you can't resist.",
                                "If you steal from one author, it's plagiarism, if you steal from many, it's research.",
                                "If you think nobody cares if you're alive, try missing a couple of car payments.",
                                "How is it one careless match can start a forest fire, but it takes a whole box to start a campfire?",
                                "God gave us our relatives, thank God we can choose our friends.",
                                "Nothing sucks more than that moment during an argument when you realize you're wrong.",
                                "By the time a man realizes that his father was right, he has a son who thinks he's wrong.",
                                "Women who seek to be equal with men lack ambition.",
                                "Those people who think they know everything are a great annoyance to those of us who do.",
                                "By working faithfully eight hours a day you may eventually get to be boss and work twelve hours a day.",
                                "When tempted to fight fire with fire, remember that the Fire Department usually uses water.",
                                "America is a country where half the money is spent buying food, and the other half is spent trying to lose weight.",
                                "A bank is a place that will lend you money, if you can prove that you don't need it.",
                                "You love flowers, but you cut them. You love animals, but you eat them. You tell me you love me, so now I'm scared!",
                                "I don't need a hair stylist, my pillow gives me a new hairstyle every morning.",
                                "Don't worry if plan A fails, there are 25 more letters in the alphabet.",
                                "Studying means 10% reading and 90% complaining to your friends that you have to study.",
                                "If you want your wife to listen to you, then talk to another woman, she will be all ears.",
                                "You never realize how boring your life is until someone asks what you like to do for fun.",
                                "In the morning you beg to sleep more, in the afternoon you are dying to sleep, and at night you refuse to sleep.",
                                "When I said that I cleaned my room, I just meant I made a path from the doorway to my bed.",
                                "Life isn't measured by the number of breaths you take, but by the number of moments that take your breath away.",
                                "The great pleasure in life is doing what people say you cannot do.",
                                "If we were on a sinking ship, and there was only one life vest... I would miss you so much.",
                                "All my life I thought air was free, until I bought a bag of chips.",
                                "Long time ago I used to have a life, until someone told me to create a Facebook account.",
                                "Never take life seriously. Nobody gets out alive anyway.",
                                "Just because I give you advice, it doesn't mean I know more than you. It just means I've done more stupid shit.",
                                "Dear math, I'm tired of trying to find your x and y she left. Please move on and solve your problems.",
                                "Violence for the sake of others makes it admirable.",
                                "The problem with being faster than light... is that you can only live in darkness.",
                                "Never gonna give you up..."};

    public void getRandomQuotes(){
        this.gameObject.SetActive(true);
        txtSubGame.text = ChooseRandom(quotes);
        

    }

    string ChooseRandom (string[] quotes) {
        int total = 0;
        int quotesLength = quotes.Length;

        foreach (string i in quotes) {
            total += 1;
        }

        float randomPoint = Random.value * total;
        Debug.Log("RandomPoint = " + randomPoint);

        int j = quotesLength - 1;
        for (int i=0; i < quotesLength; i++) {
            if (randomPoint <= i) {
                return quotes[i - 1];
            } else if (randomPoint >= j){
                return quotes[j];
            }            

            j--;
            
        }

        return quotes[total - 1];
    }


}
