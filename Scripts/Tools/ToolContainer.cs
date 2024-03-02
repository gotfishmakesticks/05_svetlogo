using Godot;
using Godot.Collections;

namespace _svetlogo.Tools
{
	public partial class ToolContainer : Node
	{

		private Array<Tool> avaiableTools = new();
        private int currentTool = 0;

        public override void _Process(double delta)
        {
            avaiableTools[currentTool].Process(delta);
        }

        public void SelectTool(int tool)
        {
            if (tool < 0 || tool > avaiableTools.Count)
            {
                return;
            }

            avaiableTools[currentTool].OnDeselect();
            
            currentTool = tool;

            avaiableTools[currentTool].OnSelect();
        }

    }

}