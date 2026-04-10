## Drawing Cirlcels in PDF

We do not have graphic operator to draw cirles in PDF, 
but we can approximate circle using Cubic Bezier Curve  

For details about how to draw Cubic Bezier Curves in PDF refer bellow PDF Reference  
<https://opensource.adobe.com/dc-acrobat-sdk-docs/pdfstandards/pdfreference1.4.pdf>  
In above reference you can find how to draw Bezier Curves in Chapter 4, page number 164  
For our purpose we will draw curve using 'c' operator  
If you are not familiar with Cubic Bezier Curve  
I would suggest you should take a look at figure 4.8 in above mentioned PDF Reference before you go any further.  

For details about how to approximate cirlce using Cubic Bezier Curve refer bellow linked article  
<https://spencermortensen.com/articles/bezier-circle/>  

Following is my understand from above aritcle  
If center is (x, y) and radius is r  
then our points for bezier curve for right top arc of circle will be  
P0 => [ x, y + r]  
P1 => [ x + ( r * 0.55 ), y + ( r * 0.99 ) ]  
P2 => [ x + ( r * 0.99 ), y + ( r * 0.55 ) ]  
P3 => [ x + r, y ]  

TODO : Add image for this  

If we consider (x, y) as center of circle,   
we can start drawing circle from 4 points on either X or Y Axis, but here we will start at +ve Y axis,
and draw arc in first quadrant.  
so for this we will move to the point on +ve Y Axis.  
then draw cubic bezier curve with end point on +ve X Axis.  

For this our first control point will be (x+r*0.55, y+r*0.99) and second control point will be (x+r*0.99, y+r*0.55)
so our operator will look like bellow.  

x y+r m // move to the first point  
x+r*0.55 y+r*0.99 x+r*0.99 y+r*0.55 x+r y c // draw curve till last point with 2 control points  

With this we are done drawing arc in first quadrant, in the same way we can draw arc for all the quadrants and complete our cirlce,
but as we are already on +ve X Axis we will draw arc in fourth quadrant, in fourth quadrant our Y axis points are less than y ( codinate of center ) we will subtract r*0.55 and r*0.99 from y
also for previous arc we were drawing from Y Axis to X Axis,
but for fourth quadrant we are drawing from X Axis to Y Axis so we will add r*0.99 first to x and then r*0.55
so for drawing arc in fourth quadrant our operator will look like bellow.  

x+r*0.99 y-r*0.55 x+r*0.55 y-r*0.99 x y-r c // draw curve till last point with 2 control points  

Now we are at -ve Y Axis so as we will draw arc for the third quadrant
third quadrant is similar to first quarant just in apposite direction so all the points
will move as first quadrant, we only need to substract factors rather than adding them.
so for drawing arc in third quadrant our operator will look like bellow.  

x-r*0.55 y-r*0.99 x-r*0.99 y-r*0.55 x-r y c // draw curve till last point with 2 control points  

now we are the -ve X axis, and only quadrant left is the second quadrant
and second quadrant is similar to fourth quadrant just the thing is that second quadratn is apposite
to first quadrant so instead of adding we will have to substract and insead of substracting we will have
to add the factors
so for drawing arc in third quadrant our operator will look like bellow.  

x+r*0.99 y-r*0.55 x+r*0.55 y-r*0.99 x y+r c // draw curve till last point with 2 control points  

so our final operation will look like bellow  

---  
x y+r m // move to the first point  
x+r*0.55 y+r*0.99 x+r*0.99 y+r*0.55 x+r y c // draw arc in first quadrant  
x+r*0.99 y-r*0.55 x+r*0.55 y-r*0.99 x y-r c // draw arc in fourth quadrant  
x-r*0.55 y-r*0.99 x-r*0.99 y-r*0.55 x-r y c // draw arc in third quadrant  
x+r*0.99 y-r*0.55 x+r*0.55 y-r*0.99 x y+r c // draw arc in second quadrant  
S // stroke this will draw line or to fill the cirlce we can use 'f' or to do both we can use 'B' instead of S for more details refere section 4.4.2 Path-Painting Operators of above mentioned PDF Specifications
---  
