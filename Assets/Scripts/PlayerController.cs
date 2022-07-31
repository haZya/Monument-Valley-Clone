using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private NavMeshLink navMeshLink;

    private PlayerInput input;
    private NavMeshAgent agent;
    private ThirdPersonCharacter character;

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void Awake()
    {
        input = new PlayerInput();
        agent = GetComponent<NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter>();
    }

    private void Start()
    {
        agent.updateRotation = false;
    }

    private void Update()
    {
        input.Player.Move.performed += OnMovement;
        Move();
        ChangeAgentLinkMover();
    }

    private void OnMovement(InputAction.CallbackContext obj)
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            agent.SetDestination(hit.point);
        }
    }

    private void Move()
    {
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }
    }

    private void ChangeAgentLinkMover()
    {
        bool isSplitPlatform = agent.isOnOffMeshLink && agent.currentOffMeshLinkData.startPos == navMeshLink.startPoint;
        agent.GetComponent<AgentLinkMover>().m_Method = isSplitPlatform ? OffMeshLinkMoveMethod.CustomTeleport : OffMeshLinkMoveMethod.Parabola;
    }
}
