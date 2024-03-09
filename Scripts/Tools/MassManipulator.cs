using _svetlogo.Entities;
using Godot;
using System;

namespace _svetlogo.Tools
{
    [GlobalClass]
    public partial class MassManipulator : Tool, IBeginDragLMB, IBeginDragRMB, IEndDragLMB, IEndDragRMB
    {
        [Export] private float minMass;
        [Export] private float sand;
        [Export] private float manipulationSpeed;
        private WorkMode _workMode;
        private Entity _entityToManipulate;

        public void BeginDragLMB(Vector2 mousePosition, Entity clickedEntity)
        {
            if (clickedEntity == null) return;
            _workMode = WorkMode.OUT;


            _entityToManipulate = clickedEntity;
        }

        public void BeginDragRMB(Vector2 mousePosition, Entity clickedEntity)
        {
            if (clickedEntity == null) return;
            _workMode = WorkMode.IN;

            _entityToManipulate = clickedEntity;
        }

        public void EndDragLMB(Vector2 mousePosition, Entity clickedEntity)
        {
            Reset();
        }

        public void EndDragRMB(Vector2 mousePosition, Entity clickedEntity)
        {
            Reset();
        }

        private void Reset()
        {
            _workMode = WorkMode.IDLE;
            _entityToManipulate = null;
        }
        public override void Process(double delta)
        {
            if (_entityToManipulate == null) return;

            if (_entityToManipulate.Mass <= minMass || sand <= 0 || sand - manipulationSpeed < 0 || _entityToManipulate.Mass - manipulationSpeed < 0) return;

            switch (_workMode)
            {
                case WorkMode.IN:
                    _entityToManipulate.AddMass(-manipulationSpeed * (float)delta);
                    sand += manipulationSpeed * (float)delta;
                    break;
                case WorkMode.OUT:
                    sand -= manipulationSpeed * (float)delta;
                    _entityToManipulate.AddMass(manipulationSpeed * (float)delta);
                    break;
            }
        }

        public override void OnDeselect()
        {
        }

        public override void OnSelect()
        {
        }
        enum WorkMode
        {
            IDLE,
            IN,
            OUT
        }
    }
}
