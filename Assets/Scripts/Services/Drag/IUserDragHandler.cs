namespace Services.Drag
{
    public interface IUserDragHandler
    {
        event System.Action OnBeginDragging;
        event System.Action<DragDto> OnDragging;
        event System.Action<DragDto> OnEndDragging;
        
        
        void StartHandlingDrag();
        void StopHandlingDrag();
    }
}