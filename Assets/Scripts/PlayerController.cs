using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private NavMeshLink navMeshLink;

    private PlayerInput input;
    //private NavMeshAgent agent;
    private ThirdPersonCharacter character;
    private Animator animator;

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
        //agent = GetComponent<NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        input.Player.Move.performed += OnMovement;
    }

    private void Update()
    {
        animator.SetBool("OnGround", true);
        //Move();
    }

    private void OnMovement(InputAction.CallbackContext obj)
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            //agent.SetDestination(hit.point);
        }
    }

    private void Move()
    {
        //if (agent.remainingDistance > agent.stoppingDistance)
        //{
        //    character.Move(agent.desiredVelocity, false, false);
        //}
        //else
        //{
        //    character.Move(Vector3.zero, false, false);
        //}
    }
}
