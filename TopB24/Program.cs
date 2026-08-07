public static int gridlandMetro(int n, int m, int k, List<List<int>> track)
{
    // Group tracks by row
    Dictionary<int, List<(int start, int end)>> rows =
        new Dictionary<int, List<(int start, int end)>>();

    foreach (var t in track)
    {
        int row = t[0];
        int start = t[1];
        int end = t[2];

        if (!rows.ContainsKey(row))
        {
            rows[row] = new List<(int start, int end)>();
        }

        rows[row].Add((start, end));
    }

    long occupied = 0;

    // Process each row
    foreach (var row in rows)
    {
        // Sort tracks by starting column
        row.Value.Sort((a, b) => a.start.CompareTo(b.start));

        int currentStart = row.Value[0].start;
        int currentEnd = row.Value[0].end;

        for (int i = 1; i < row.Value.Count; i++)
        {
            int start = row.Value[i].start;
            int end = row.Value[i].end;

            // Overlapping or adjacent track
            if (start <= currentEnd + 1)
            {
                currentEnd = Math.Max(currentEnd, end);
            }
            else
            {
                // Finish current merged interval
                occupied += currentEnd - currentStart + 1;

                // Start new interval
                currentStart = start;
                currentEnd = end;
            }
        }

        // Add the last interval
        occupied += currentEnd - currentStart + 1;
    }

    long totalCells = (long)n * m;

    return (int)(totalCells - occupied);
}