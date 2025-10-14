public interface IMap
{
    int GetRandomPositionToTopo();
    void SaveTopo(PointToTopo topo);
    void SaveFruit(PointToFruit pointToFruit);
}