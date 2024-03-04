using Godot;
using _svetlogo.Entities;

namespace _svetlogo.Tools
{
    public interface IBeginDragRMB
    {
        void BeginDragRMB(Vector2 mousePosition, Entity clickedEntity);
    }
}
