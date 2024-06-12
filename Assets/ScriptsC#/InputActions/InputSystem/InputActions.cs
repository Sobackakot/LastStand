//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/ScriptsC#/InputActions/InputSystem/InputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""ActionMaps"",
            ""id"": ""89318a0d-5fac-4bae-8a45-e1864cd3f3dc"",
            ""actions"": [
                {
                    ""name"": ""LeftMouseButton"",
                    ""type"": ""Button"",
                    ""id"": ""052ac51d-9e48-42c0-8677-53b73711a6cc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RightMouseButton"",
                    ""type"": ""Button"",
                    ""id"": ""76d3468f-5202-440f-aae7-29a8af6c07aa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MiddleMouseButton"",
                    ""type"": ""Button"",
                    ""id"": ""e621fafb-20ac-4e54-b9da-fd3865281073"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""LookMouseDelta"",
                    ""type"": ""Value"",
                    ""id"": ""5c59092f-4892-4e0a-9f46-0eef74f7ac1f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ScrollMouse"",
                    ""type"": ""Value"",
                    ""id"": ""7627ea27-3582-448b-8e1d-a5e7a3405147"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""CtrlButton"",
                    ""type"": ""Button"",
                    ""id"": ""70f8a4f9-efde-4c29-9014-cfd4fe68f07e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SpaceButton"",
                    ""type"": ""Button"",
                    ""id"": ""02786148-0a1d-4aa4-ace9-3b2eb2900d90"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""GetAxisDirectionMove"",
                    ""type"": ""Value"",
                    ""id"": ""62aa50ca-70e1-449c-adcc-9c4af55776e3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""SelectMouseDelta"",
                    ""type"": ""Value"",
                    ""id"": ""ccf5d9d7-9fc0-48d3-bbcc-a4bf2ab1b73f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""InventoryKey"",
                    ""type"": ""Button"",
                    ""id"": ""1f090498-89ba-4045-82fa-57f5e1220324"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fd8b9f90-f516-4e2b-bebe-4b0f0bfb15f8"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Hold,Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftMouseButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a8d17041-d353-475b-ab6a-6360b26079f4"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightMouseButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e9a5c631-4c75-491d-a376-489d68bc1a7d"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2"",
                    ""groups"": """",
                    ""action"": ""LookMouseDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7a69d33-9f55-4177-9fb4-1aed5f97e456"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ScrollMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0731ef01-32a8-48ff-ae81-69726013f1fd"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MiddleMouseButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03b6e8fe-3a76-40a4-9000-fb9a6754ce68"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CtrlButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5eb4ad00-eb76-473d-ae57-a536e751e445"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpaceButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""749e29cd-4c65-4618-82e5-d4e35602b6af"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GetAxisDirectionMove"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""dfc78298-8252-4fcb-9c73-5d01a3e3317d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GetAxisDirectionMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b9d57ae9-a497-4526-aee8-446eaad0663f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GetAxisDirectionMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8d546463-9811-4138-a95e-84f7fad421e6"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GetAxisDirectionMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""51194cc2-4930-4c85-aa03-286fb34ce864"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GetAxisDirectionMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""961f98b8-7d64-4322-9143-5a3558062fd8"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2"",
                    ""groups"": """",
                    ""action"": ""SelectMouseDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""15e67ab6-6658-4b9f-bba2-52c1d61874d3"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InventoryKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ActionMaps
        m_ActionMaps = asset.FindActionMap("ActionMaps", throwIfNotFound: true);
        m_ActionMaps_LeftMouseButton = m_ActionMaps.FindAction("LeftMouseButton", throwIfNotFound: true);
        m_ActionMaps_RightMouseButton = m_ActionMaps.FindAction("RightMouseButton", throwIfNotFound: true);
        m_ActionMaps_MiddleMouseButton = m_ActionMaps.FindAction("MiddleMouseButton", throwIfNotFound: true);
        m_ActionMaps_LookMouseDelta = m_ActionMaps.FindAction("LookMouseDelta", throwIfNotFound: true);
        m_ActionMaps_ScrollMouse = m_ActionMaps.FindAction("ScrollMouse", throwIfNotFound: true);
        m_ActionMaps_CtrlButton = m_ActionMaps.FindAction("CtrlButton", throwIfNotFound: true);
        m_ActionMaps_SpaceButton = m_ActionMaps.FindAction("SpaceButton", throwIfNotFound: true);
        m_ActionMaps_GetAxisDirectionMove = m_ActionMaps.FindAction("GetAxisDirectionMove", throwIfNotFound: true);
        m_ActionMaps_SelectMouseDelta = m_ActionMaps.FindAction("SelectMouseDelta", throwIfNotFound: true);
        m_ActionMaps_InventoryKey = m_ActionMaps.FindAction("InventoryKey", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // ActionMaps
    private readonly InputActionMap m_ActionMaps;
    private List<IActionMapsActions> m_ActionMapsActionsCallbackInterfaces = new List<IActionMapsActions>();
    private readonly InputAction m_ActionMaps_LeftMouseButton;
    private readonly InputAction m_ActionMaps_RightMouseButton;
    private readonly InputAction m_ActionMaps_MiddleMouseButton;
    private readonly InputAction m_ActionMaps_LookMouseDelta;
    private readonly InputAction m_ActionMaps_ScrollMouse;
    private readonly InputAction m_ActionMaps_CtrlButton;
    private readonly InputAction m_ActionMaps_SpaceButton;
    private readonly InputAction m_ActionMaps_GetAxisDirectionMove;
    private readonly InputAction m_ActionMaps_SelectMouseDelta;
    private readonly InputAction m_ActionMaps_InventoryKey;
    public struct ActionMapsActions
    {
        private @InputActions m_Wrapper;
        public ActionMapsActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftMouseButton => m_Wrapper.m_ActionMaps_LeftMouseButton;
        public InputAction @RightMouseButton => m_Wrapper.m_ActionMaps_RightMouseButton;
        public InputAction @MiddleMouseButton => m_Wrapper.m_ActionMaps_MiddleMouseButton;
        public InputAction @LookMouseDelta => m_Wrapper.m_ActionMaps_LookMouseDelta;
        public InputAction @ScrollMouse => m_Wrapper.m_ActionMaps_ScrollMouse;
        public InputAction @CtrlButton => m_Wrapper.m_ActionMaps_CtrlButton;
        public InputAction @SpaceButton => m_Wrapper.m_ActionMaps_SpaceButton;
        public InputAction @GetAxisDirectionMove => m_Wrapper.m_ActionMaps_GetAxisDirectionMove;
        public InputAction @SelectMouseDelta => m_Wrapper.m_ActionMaps_SelectMouseDelta;
        public InputAction @InventoryKey => m_Wrapper.m_ActionMaps_InventoryKey;
        public InputActionMap Get() { return m_Wrapper.m_ActionMaps; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ActionMapsActions set) { return set.Get(); }
        public void AddCallbacks(IActionMapsActions instance)
        {
            if (instance == null || m_Wrapper.m_ActionMapsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ActionMapsActionsCallbackInterfaces.Add(instance);
            @LeftMouseButton.started += instance.OnLeftMouseButton;
            @LeftMouseButton.performed += instance.OnLeftMouseButton;
            @LeftMouseButton.canceled += instance.OnLeftMouseButton;
            @RightMouseButton.started += instance.OnRightMouseButton;
            @RightMouseButton.performed += instance.OnRightMouseButton;
            @RightMouseButton.canceled += instance.OnRightMouseButton;
            @MiddleMouseButton.started += instance.OnMiddleMouseButton;
            @MiddleMouseButton.performed += instance.OnMiddleMouseButton;
            @MiddleMouseButton.canceled += instance.OnMiddleMouseButton;
            @LookMouseDelta.started += instance.OnLookMouseDelta;
            @LookMouseDelta.performed += instance.OnLookMouseDelta;
            @LookMouseDelta.canceled += instance.OnLookMouseDelta;
            @ScrollMouse.started += instance.OnScrollMouse;
            @ScrollMouse.performed += instance.OnScrollMouse;
            @ScrollMouse.canceled += instance.OnScrollMouse;
            @CtrlButton.started += instance.OnCtrlButton;
            @CtrlButton.performed += instance.OnCtrlButton;
            @CtrlButton.canceled += instance.OnCtrlButton;
            @SpaceButton.started += instance.OnSpaceButton;
            @SpaceButton.performed += instance.OnSpaceButton;
            @SpaceButton.canceled += instance.OnSpaceButton;
            @GetAxisDirectionMove.started += instance.OnGetAxisDirectionMove;
            @GetAxisDirectionMove.performed += instance.OnGetAxisDirectionMove;
            @GetAxisDirectionMove.canceled += instance.OnGetAxisDirectionMove;
            @SelectMouseDelta.started += instance.OnSelectMouseDelta;
            @SelectMouseDelta.performed += instance.OnSelectMouseDelta;
            @SelectMouseDelta.canceled += instance.OnSelectMouseDelta;
            @InventoryKey.started += instance.OnInventoryKey;
            @InventoryKey.performed += instance.OnInventoryKey;
            @InventoryKey.canceled += instance.OnInventoryKey;
        }

        private void UnregisterCallbacks(IActionMapsActions instance)
        {
            @LeftMouseButton.started -= instance.OnLeftMouseButton;
            @LeftMouseButton.performed -= instance.OnLeftMouseButton;
            @LeftMouseButton.canceled -= instance.OnLeftMouseButton;
            @RightMouseButton.started -= instance.OnRightMouseButton;
            @RightMouseButton.performed -= instance.OnRightMouseButton;
            @RightMouseButton.canceled -= instance.OnRightMouseButton;
            @MiddleMouseButton.started -= instance.OnMiddleMouseButton;
            @MiddleMouseButton.performed -= instance.OnMiddleMouseButton;
            @MiddleMouseButton.canceled -= instance.OnMiddleMouseButton;
            @LookMouseDelta.started -= instance.OnLookMouseDelta;
            @LookMouseDelta.performed -= instance.OnLookMouseDelta;
            @LookMouseDelta.canceled -= instance.OnLookMouseDelta;
            @ScrollMouse.started -= instance.OnScrollMouse;
            @ScrollMouse.performed -= instance.OnScrollMouse;
            @ScrollMouse.canceled -= instance.OnScrollMouse;
            @CtrlButton.started -= instance.OnCtrlButton;
            @CtrlButton.performed -= instance.OnCtrlButton;
            @CtrlButton.canceled -= instance.OnCtrlButton;
            @SpaceButton.started -= instance.OnSpaceButton;
            @SpaceButton.performed -= instance.OnSpaceButton;
            @SpaceButton.canceled -= instance.OnSpaceButton;
            @GetAxisDirectionMove.started -= instance.OnGetAxisDirectionMove;
            @GetAxisDirectionMove.performed -= instance.OnGetAxisDirectionMove;
            @GetAxisDirectionMove.canceled -= instance.OnGetAxisDirectionMove;
            @SelectMouseDelta.started -= instance.OnSelectMouseDelta;
            @SelectMouseDelta.performed -= instance.OnSelectMouseDelta;
            @SelectMouseDelta.canceled -= instance.OnSelectMouseDelta;
            @InventoryKey.started -= instance.OnInventoryKey;
            @InventoryKey.performed -= instance.OnInventoryKey;
            @InventoryKey.canceled -= instance.OnInventoryKey;
        }

        public void RemoveCallbacks(IActionMapsActions instance)
        {
            if (m_Wrapper.m_ActionMapsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IActionMapsActions instance)
        {
            foreach (var item in m_Wrapper.m_ActionMapsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ActionMapsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ActionMapsActions @ActionMaps => new ActionMapsActions(this);
    public interface IActionMapsActions
    {
        void OnLeftMouseButton(InputAction.CallbackContext context);
        void OnRightMouseButton(InputAction.CallbackContext context);
        void OnMiddleMouseButton(InputAction.CallbackContext context);
        void OnLookMouseDelta(InputAction.CallbackContext context);
        void OnScrollMouse(InputAction.CallbackContext context);
        void OnCtrlButton(InputAction.CallbackContext context);
        void OnSpaceButton(InputAction.CallbackContext context);
        void OnGetAxisDirectionMove(InputAction.CallbackContext context);
        void OnSelectMouseDelta(InputAction.CallbackContext context);
        void OnInventoryKey(InputAction.CallbackContext context);
    }
}
