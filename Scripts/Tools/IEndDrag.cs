using Godot;
using _svetlogo.Entities;

namespace _svetlogo.Tools
{
    public interface IEndDrag
    {
        void EndDrag(Vector2 mousePosition, Entity clickedEntity);
    }
}
