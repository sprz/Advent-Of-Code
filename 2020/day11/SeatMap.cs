using System;
using System.Collections.Generic;
using System.Linq;

namespace day11
{
    internal class SeatMap
    {
        public Seat[,] Seats { get; set; }
        private int xLen => Seats.GetLength(0);
        private int yLen => Seats.GetLength(1);
        public int SeatsOccupationChangedCount => ListOfSeats.Count(x => x.StatusChanged);
        public int OccupiedSeats => ListOfSeats.Count(x => x.IsOccupied);

        public bool IsPartOne { get; internal set; }

        public List<Seat> ListOfSeats = new List<Seat>();

        internal static SeatMap Parse(string[] lines)
        {
            SeatMap map = new SeatMap(lines.Length,lines[0].Length);

            for(int i=0;i<lines.Length;i++)
                for(int k=0;k<lines[0].Length;k++)
                {
                    var seat = new Seat(lines[i][k],i,k);
                    map.ListOfSeats.Add(seat);
                    map.Seats[i, k] = seat;
                }

            return map;
        }
        internal void PrepareNextStates()
        {
            for(int i=0;i<xLen;i++)
                for(int k=0;k<yLen;k++)
                {
                    var seat = Seats[i, k];
                    if (seat.Occupied == null) continue;

                    var OccupiedCount = 0;

                    if (IsPartOne)
                    {
                        var xDown = i > 0;
                        var xUp = i < xLen - 1;

                        var yDown = k > 0;
                        var yUp = k < yLen - 1;


                        if (xDown) OccupiedCount += Seats[i - 1, k].IsOccupied ? 1 : 0;
                        if (xUp) OccupiedCount += Seats[i + 1, k].IsOccupied ? 1 : 0;

                        if (yDown) OccupiedCount += Seats[i, k - 1].IsOccupied ? 1 : 0;
                        if (yUp) OccupiedCount += Seats[i, k + 1].IsOccupied ? 1 : 0;

                        if (xDown && yDown) OccupiedCount += Seats[i - 1, k - 1].IsOccupied ? 1 : 0;
                        if (xDown && yUp) OccupiedCount += Seats[i - 1, k + 1].IsOccupied ? 1 : 0;

                        if (xUp && yDown) OccupiedCount += Seats[i + 1, k - 1].IsOccupied ? 1 : 0;
                        if (xUp && yUp) OccupiedCount += Seats[i + 1, k + 1].IsOccupied ? 1 : 0;

                        if (seat.IsOccupied && OccupiedCount >= 4) seat.NextOccupiedStatus = false;
                        if (seat.IsOccupied == false && OccupiedCount == 0) seat.NextOccupiedStatus = true;
                    }
                    else
                    {
                        OccupiedCount += CheckOccupationInSpecificDirection(i, k, -1, 0) ? 1 : 0;
                        OccupiedCount += CheckOccupationInSpecificDirection(i, k, 1, 0) ? 1 : 0;

                        OccupiedCount += CheckOccupationInSpecificDirection(i, k, 0, -1) ? 1 : 0;
                        OccupiedCount += CheckOccupationInSpecificDirection(i, k, 0, 1) ? 1 : 0;

                        OccupiedCount += CheckOccupationInSpecificDirection(i, k, -1, -1) ? 1 : 0;
                        OccupiedCount += CheckOccupationInSpecificDirection(i, k, -1, 1) ? 1 : 0;

                        OccupiedCount += CheckOccupationInSpecificDirection(i, k, 1, -1) ? 1 : 0;
                        OccupiedCount += CheckOccupationInSpecificDirection(i, k, 1, 1) ? 1 : 0;

                        if (seat.IsOccupied && OccupiedCount >=5) seat.NextOccupiedStatus = false;
                        if (seat.IsOccupied == false && OccupiedCount == 0) seat.NextOccupiedStatus = true;
                    }
                }
        }

        internal void DOIT()
        {
            ListOfSeats.Where( x=> x.Occupied != null).ToList().ForEach(x => x.UpdateOccupiedStatus());
        }

        private bool CheckOccupationInSpecificDirection(int x, int y, int xDirection, int yDirection)
        {
            while ((x += xDirection) >= 0 && x < xLen && (y += yDirection) >= 0 && y < yLen)
            {
                var nextSeat = Seats[x, y];

                if (nextSeat.Occupied != null) return nextSeat.IsOccupied;
            }
            

            return false;
        }


        private SeatMap(int x, int y)
        {
            Seats = new Seat[x, y];
        }
    }
}