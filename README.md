# Super Mega Baseball 4 Stat Tracker

Hello,

My name is Wes Anderson. A current student and avid Super Mega Baseball player. I hope you find this tool useful for your franchise experience!

## Vision
The game is great, but in franchise mode I feel like the stats can be displayed a bit better.

My hope is that you can track individual player's stats against individual teams/pitchers/players. 
* For example hits against `insert pitcher name` or predict hits that this player will get in the upcoming game against `insert pitcher name`

## Approach
This is definitely possible...But only for games that you as a player play. This is because Super Mega Baseball has a save game feature that creates a season.sav file which stores a lot of information about the game. My program will detect changes in a season.sav file `(after every play is concluded)` and use those changes to show stats that are not showed in the regular game.

With the update the season.sav files store more data about previous pitches so we can now track pitchers and what they like to throw (both on a specific count and also where).

## Problems
I am currently experiencing trouble accessing data in the season.sav file. If anyone knows what compression format it is in please let me know. The other .sav file formats (master and league) are compressed using zlib, but the season.sav files are not compressed the same.

PLEASE PLEASE PLEASE contact me if you find bugs or have questions my email is wesoa012@gmail.com
