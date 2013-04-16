Potato potato;
//... 
if (potato != null)
   if(potato.HasBeenPeeled && potato.IsFresh)
	Cook(potato);

//

bool inBoundariesX = (MIN_X <= x && x =< MAX_X);
bool inBoundariesY = (MIN_Y <= y && y <= MAX_Y);

if (inBoundariesX && inBoundariesY && shouldVisitCell)
{
   VisitCell();
}
