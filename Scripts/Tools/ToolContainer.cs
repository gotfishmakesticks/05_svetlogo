using Godot;
using Godot.Collections;

namespace _svetlogo.Tools
{
    public partial class ToolContainer : Node
    {

        [Export] private Array<Tool> avaiableTools = new();
        private int currentTool = 0;

        public override void _Process(double delta)
        {
            GD.Print(avaiableTools.Count);
            if (avaiableTools.Count == 0) return;
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

        public Tool GetTool()
        {
            return avaiableTools[currentTool];
        }

        public void AddTool(Tool tool)
        {
            avaiableTools.Add(tool);
        }
        
        public void RemoveTool(Tool tool)
        {
            avaiableTools.Remove(tool);
        }

    }

}