using Godot;
using _svetlogo.Entities;

namespace _svetlogo.Tools
{
    public interface IEndDragLMB
    {
        void EndDragLMB(Vector2 mousePosition, IEntity clickedEntity);
    }
}
