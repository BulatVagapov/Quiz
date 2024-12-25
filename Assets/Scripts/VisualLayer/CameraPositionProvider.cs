using Quiz.GameLayer;
using UnityEngine;
using VContainer;

namespace Quiz.VisualLayer
{
    public class CameraPositionProvider
    {
        private Camera cam;
        private LevelGenerator levelGenerator;

        [Inject]
        public CameraPositionProvider(Camera cam, LevelGenerator levelGenerator)
        {
            this.cam = cam;
            this.levelGenerator = levelGenerator;
        }

        public void SetPosition()
        {
            SetCameraPosition(levelGenerator.Grid.GridCenter);
        }

        public void SetCameraPosition(Vector3 camPosition)
        {
            camPosition.z = -10;
            cam.transform.position = camPosition;
        }
    }
}