using System.Collections.Generic;
using BlankProject;
using Dragon;
using Improbable;
using Improbable.Gdk.Core;
using Improbable.Gdk.PlayerLifecycle;
using Improbable.Gdk.TransformSynchronization;

namespace Playground
{
    public static class PlayerTemplate
    {
        public static EntityTemplate CreatePlayerEntityTemplate(string workerId, Improbable.Vector3f position)
        {
            var clientAttribute = $"workerId:{workerId}";

            var template = new EntityTemplate();
            template.AddComponent(new Position.Snapshot(), clientAttribute);
            template.AddComponent(new Metadata.Snapshot { EntityType = "Player" }, UnityGameLogicConnector.WorkerType);
            template.AddComponent(new PlayerInput.Snapshot(), clientAttribute);
            TransformSynchronizationHelper.AddTransformSynchronizationComponents(template, clientAttribute);
            PlayerLifecycleHelper.AddPlayerLifecycleComponents(template, workerId, clientAttribute,
                UnityGameLogicConnector.WorkerType);

            template.SetReadAccess(UnityGameLogicConnector.WorkerType, UnityClientConnector.WorkerType);
            template.SetComponentWriteAccess(EntityAcl.ComponentId, UnityGameLogicConnector.WorkerType);

            return template;
        }
    }
}
