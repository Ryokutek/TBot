namespace TBot.Core.Telegram;

public class MaskPosition
{
	public string Point { get; set; }
	public float XShift { get; set; }
	public float YShift { get; set; }
	public float Scale { get; set; }

	public MaskPosition(
		string point,
		float xShift,
		float yShift,
		float scale)
	{
		Point = point;
		XShift = xShift;
		YShift = yShift;
		Scale = scale;
	}
}