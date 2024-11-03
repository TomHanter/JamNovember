using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; // Не забудьте добавить этот using для LINQ
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.WSA;

//public class Map
//{
//    private const int Rows = 16;
//    private const int Columns = 16;
//    public Cell[,] Cells { get; private set; }

//    public Map()
//    {
//        Cells = new Cell[Rows, Columns]; // Инициализация матрицы 16x16
//    }

//    public void AppendCellInMap(int row, int column, Cell cell)
//    {
//        // Проверка на границы матрицы
//        if (row < 0 || row >= Rows || column < 0 || column >= Columns)
//        {
//            Debug.LogError("Индекс выходит за пределы матрицы.");
//            return;
//        }

//        Cells[row, column] = cell; // Устанавливаем ячейку в матрицу
//    }

//    public Cell GetCell(int row, int column)
//    {
//        // Проверка на границы матрицы
//        if (row < 0 || row >= Rows || column < 0 || column >= Columns)
//        {
//            Debug.LogError("Индекс выходит за пределы матрицы.");
//            return null;
//        }

//        return Cells[row, column]; // Возвращаем ячейку из матрицы
//    }

//    public Cell[,] GetSortedCellsByPosition()
//    {
//        // Создаем список для хранения всех ячеек
//        List<Cell> cellList = new List<Cell>();

//        // Извлекаем все ячейки из матрицы
//        for (int row = 0; row < Rows; row++)
//        {
//            for (int column = 0; column < Columns; column++)
//            {
//                Cell cell = Cells[row, column];
//                if (cell != null) // Добавляем только непустые ячейки
//                {
//                    cellList.Add(cell);
//                }
//            }
//        }

//        // Сортируем ячейки по позиции
//        var sortedCells = cellList.OrderBy(cell => cell.Position.magnitude).ToList();

//        // Создаем новую матрицу для отсортированных ячеек
//        Cell[,] sortedMatrix = new Cell[Rows, Columns];

//        // Заполняем отсортированную матрицу
//        for (int i = 0; i < sortedCells.Count; i++)
//        {
//            int row = i / Columns; // Определяем строку
//            int column = i % Columns; // Определяем колонку

//            if (row < Rows)
//            {
//                sortedMatrix[row, column] = sortedCells[i];
//            }
//        }

//        return sortedMatrix; // Возвращаем отсортированную матрицу
//    }
//}

//public class Cell
//{
//    public int Id { get; private set; }
//    public Vector3 Position { get; private set; }

//    public Cell(int id, Vector3 position)
//    {
//        Id = id;
//        Position = position;
//    }
//}

public class TilemapManager : MonoBehaviour
{
    public Tilemap tilemap; // Ссылка на ваш Tilemap

    void Start()
    {
        GetAllTiles();
    }

    void GetAllTiles()
    {
        // Получаем границы Tilemap
        BoundsInt bounds = tilemap.cellBounds;

        // Выводим границы
        Debug.Log($"Tilemap Bounds: {bounds}");

        // Получаем массив тайлов
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);
        Debug.Log($"Total tiles: {allTiles.Length}"); // Выводим общее количество тайлов

        // Проходим по всем тайлам и выводим информацию
        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                // Для 3D тайлов используем z координату (если она требуется)
                for (int z = 0; z < bounds.size.z; z++)
                {
                    TileBase tile = allTiles[x + y * bounds.size.x + z * bounds.size.x * bounds.size.y];
                    if (tile != null)
                    {
                        Debug.Log($"Tile at ({x}, {y}, {z}): {tile.name}");
                    }
                }
            }
        }
    }
}