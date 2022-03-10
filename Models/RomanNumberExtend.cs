class RomanNumberExtend : RomanNumber
{
    public RomanNumberExtend(string? num) 
	    : base(RomanToNumber(num))
    {
	    if (num == null)
		    throw new RomanNumberException("Arg should not be null!");
    }
}
