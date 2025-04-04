# Homework

## Homework from 3/30/2025

Right now, we have the following routes:

 * `/Home/Easy` play an Easy Game
 * `/Home/Medium` play a Medium Game
 * `/Home/Hard` play a hard game

When the user wins the game, they just get redirected to `/Home` and there's no celebration or happy message. Also, once the user is at a certain difficulty route, they can't easily switch to another difficulty, they have to go home or know that they can change the difficulty in the URL.

Another issue right now is that even though we have a dynamic template, we have three separate routes per difficulty.

### Assignment
 - [X] Set up a singular route `/Home` with the following capabilities
 - [ ] Dynamically generate a set of buttons tha the user can click to select difficulty. These buttons are populated from the values on the Enum:
    _Motivation_ the motivation behind this is that if we add a new difficulty level to the Enum (like "Super ridiculously hard"), the HTML will automatically show that as an option that the user can select.
 - [ ] Once the selected difficulty is defined in the state (either via temp data, session, etc.) then render the game where they can guess.
 - [X] If they win, keep the level selected, but just show them a congratulations message. At this point, if the user selects a new difficulty, then reset the state.
 - [X] Have a "Reset" button if the user guesses correctly, and reset to the original state.
 - [ ] **BONUS** add styling! Use Colors! Use CSS! Talk to copilot to make this happen
 - [ ] **2nd BONUS** add a new difficulty level to the difficulty level enum, the new button should appear!

### Things to help guide
 * Search online or talk to copilot about strategies for managing "state" of a single view. How do people define that state (classes?) and how do they reset that state (default values on classes?)
 * Think about making the UX (user experience) good and friendly.
 * Talk to Copilot about how to iterate through values of an Enum to generate the buttons
 * In the Route function where you populate and check the guess, you'll want to map the Difficulty Level to the correct range, so think about how you can store the boundaries associated with a particular level so that you can reference them in all parts of the code (for instance, there are lots of parts of the code that "knows" that the upper bound of a Medium level is 100. These are called "Magic Numbers", we want to try to get rid of them).