LightShow

You run lightshows at events, with a large display of one million lights in a 1000x1000 grid. 
Customers provide instructions on how they want the lights to be turned on during the event. 
 
Your lights are numbered from 0 to 999 in each direction, identified by a pair of coordinates. For example, the corners are at (0,0), (999,0), (0,999) and (999,999). The instructions identify inclusive ranges of coordinates, forming the opposite corners of a rectangle. For example, "0,0 through 2,2" refers to the 9 lights in a 3x3 grid in the bottom left corner. All lights start turned off. 
 
 
PART 1 
 
The aim is to write a program which reads a sequence of instructions from the attached input file, then calculates how many lights are on at the end. 
 
There are three types of instructions: "turn on", "turn off", and "toggle", followed by a coordinate range. For example: 
turn on 0,0 through 999,999 	This turns on every light. Lights that were already on are unaffected. 
turn off 499,499 through 500,500 	This turns off the four lights in the middle. Lights already off are unaffected. 
toggle 0,499 through 999,500 	This inverts the two lines of lights in the middle. Lights that were on would turn off, and lights that were off would turn on 
 
If those instructions were done in order, this would be the result: 
Instruction 	Number of lights on 
turn on 0,0 through 999,999 	1000000 
turn off 499,499 through 500,500 	999996 
toggle 0,499 through 999,500 	998004 (final result) 
 
Please write your code in Java or Python, including unit tests. It should read the input file, and print the number of lights on at the end. 
 
 
PART 2 
 
Your lights system has been upgraded! Your lights now have individual brightness levels, with a brightness level of 0 or higher. All lights start at brightness 0. 
 
The meaning of the instructions has now changed: 
turn on 	Increase the brightness of the specified lights by 1 
turn off 	Decrease the brightness by 1, with a minimum of 0 
toggle 	Increase the brightness by 2 
 
With the new meaning, the result from the example instructions from part 1 is 1003996. As before, the program should read the input file and print the number of lights on at the end. 
