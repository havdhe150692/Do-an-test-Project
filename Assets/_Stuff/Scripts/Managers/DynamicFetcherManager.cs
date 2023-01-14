using System.Collections;
using System.Collections.Generic;
using _Stuff.Scripts.Managers.DynamicFetcher;
using UnityEngine;

public class DynamicFetcherManager : MonoBehaviour
{
    [SerializeField] public ToadSoloDetailFetcher toadSoloDetailFetcher;
    [SerializeField] public ToadGenerationFetcher toadGenerationFetcher;
    [SerializeField] public TokenFetcher tokenFetcher;
    [SerializeField] public StatusActionFetcher statusActionFetcher;
}
