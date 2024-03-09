using Godot;
using Godot.Collections;

namespace _svetlogo.Entities.Static;
public partial class DecayingTiles : TileMap
{
	private bool enabled;
	public void Set(bool value = false)
	{
		for (int i = 0; i < GetLayersCount(); i++)
		{
			SetLayerEnabled(i,value);

		}
		enabled = value;
	}
	public void Toggle()
	{
		enabled = !enabled;
        for (int i = 0; i < GetLayersCount(); i++)
        {
            SetLayerEnabled(i, enabled);
        }
    }
}
