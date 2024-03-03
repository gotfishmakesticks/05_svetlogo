using Godot;
using _svetlogo.Entities;

namespace _svetlogo.Tools
{
    public interface IEndDragRMB
    {
        void EndDragRMB(Vector2 mousePosition, IEntity clickedEntity);
    }
}
