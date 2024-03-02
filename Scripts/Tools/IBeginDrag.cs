using Godot;
using _svetlogo.Entities;

namespace _svetlogo.Tools
{
    public interface IBeginDrag
    {
        void BeginDrag(Vector2 mousePosition, Entity clickedEntity);
    }
}
