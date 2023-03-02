using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PieceManager : MonoBehaviour, IWhite, IBlack 
{

    #region params
    
    [Header("Player unit")]
    [Space(3)] 
    [Header("White Team Pieces")] 
    [SerializeField] private Piece whitePawn;
    [SerializeField] private Piece whiteRook;
    [SerializeField] private Piece whiteKnight;
    [SerializeField] private Piece whiteBishop;
    [SerializeField] private Piece whiteQueen;
    [SerializeField] private Piece whiteKing;

    [Space(3)] 
    [Header("Black Team Pieces")] 
    [SerializeField] private Piece blackPawn;
    [SerializeField] private Piece blackRook;
    [SerializeField] private Piece blackKnight;
    [SerializeField] private Piece blackBishop;
    [SerializeField] private Piece blackQueen;
    [SerializeField] private Piece blackKing;

    [Space(3)] 
    [Header("Piece container")] 
    [SerializeField] public GameObject whiteParentPrefabs;
    [SerializeField] public GameObject blackParentPrefabs;
    
    public static PieceManager Instance;
    public static Piece SelectedPiece;
    
    private List<Piece> _list;

    #endregion


    private void Awake()
    {
        Instance = this;
    }
    

    #region Spawn Pieces

    public void SpawnWhitePieces()
    {
        Vector2 currentPos = IWhite.FirstPawn;

        do
        {
            SpawnPiece(currentPos, whitePawn, whiteParentPrefabs);

            currentPos = new Vector2(currentPos.x + 1, currentPos.y);

        } while (currentPos.x <= IWhite.LastPawn.x);

        SpawnPiece(IWhite.King, whiteKing, whiteParentPrefabs);
        SpawnPiece(IWhite.Queen, whiteQueen, whiteParentPrefabs);

        SpawnPiece(IWhite.Bishop1, whiteBishop, whiteParentPrefabs);
        SpawnPiece(IWhite.Bishop2, whiteBishop, whiteParentPrefabs);
        SpawnPiece(IWhite.Rook1, whiteRook, whiteParentPrefabs);
        SpawnPiece(IWhite.Rook2, whiteRook, whiteParentPrefabs);
        SpawnPiece(IWhite.Knight1, whiteKnight, whiteParentPrefabs);
        SpawnPiece(IWhite.Knight2, whiteKnight, whiteParentPrefabs);
        
}
    
    public void SpawnBlackPieces()
    {
        Vector2 currentPos = IBlack.FirstPawn;

        do
        {
            SpawnPiece(currentPos, blackPawn, blackParentPrefabs);

            currentPos = new Vector2(currentPos.x + 1, currentPos.y);

        } while (currentPos.x <= IBlack.LastPawn.x);

        SpawnPiece(IBlack.King, blackKing, blackParentPrefabs);
        SpawnPiece(IBlack.Queen, blackQueen, blackParentPrefabs);

        SpawnPiece(IBlack.Bishop1, blackBishop, blackParentPrefabs);
        SpawnPiece(IBlack.Bishop2, blackBishop, blackParentPrefabs);
        SpawnPiece(IBlack.Rook1, blackRook, blackParentPrefabs);
        SpawnPiece(IBlack.Rook2, blackRook, blackParentPrefabs);
        SpawnPiece(IBlack.Knight1, blackKnight, blackParentPrefabs);
        SpawnPiece(IBlack.Knight2, blackKnight, blackParentPrefabs);
        
    }

    #endregion

    
    public static void SetSelectedPiece(Piece piece)
    {
        if (piece is null)
        {
            SelectedPiece = null;
            MenuManager.Instance.ShowSelectedPiece(null);
            return;
        }
        
        SelectedPiece = piece;
        MenuManager.Instance.ShowSelectedPiece(piece);

    }

    /// <summary>
    /// Spawn piece on tile
    /// </summary>
    /// <param name="pos">Position of tile that piece lay on it.</param>
    /// <param name="piece">Piece Prefabs</param>
    /// <param name="parentPiece">Parent piece gameObject</param>
    public static void SpawnPiece(Vector2 pos, Piece piece, GameObject parentPiece)
    {
        Piece spawnPiece = Instantiate(piece, parentPiece.transform, true);
        Tile spawnAtTile = TileManager.Instance.GetTile(pos);

        spawnPiece.pos = spawnAtTile.GetPos();
        spawnPiece.isFirstMove = true;
        
        spawnAtTile.SetPiece(spawnPiece);
        
    }
    

}
