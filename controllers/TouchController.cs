using Godot;

public partial class TouchController : Node
{
    [Signal]
    public delegate void SwipeRightEventHandler(float strength);
    [Signal]
    public delegate void SwipeLeftEventHandler(float strength);

    Vector2 _touchPosition;
    int swipeThreshold = 250; // Minimum distance to consider a swipe
    public override void _Ready()
    {
        GD.Print("TouchController: Ready");
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event is InputEventScreenTouch touchEvent)
        {
            if (touchEvent.Pressed)
            {
                _touchPosition = touchEvent.Position;
            }
            else
            {
                Vector2 releasePosition = touchEvent.Position;
                Vector2 dragVector = releasePosition - _touchPosition;
                if (dragVector.X > swipeThreshold)
                {
                    EmitSignal(SignalName.SwipeRight, dragVector.X);
                }
                else if (dragVector.X < -swipeThreshold)
                {
                    EmitSignal(SignalName.SwipeLeft, -dragVector.X);
                }
            }
        }
    }
}
