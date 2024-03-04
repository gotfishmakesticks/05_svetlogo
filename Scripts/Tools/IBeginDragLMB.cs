using Godot;
using _svetlogo.Entities;

namespace _svetlogo.Tools
{
    public interface IBeginDragLMB
    {
        void BeginDragLMB(Vector2 mousePosition, Entity clickedEntity);
    }
}
