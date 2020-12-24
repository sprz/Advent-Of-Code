using System;

namespace day11
{
    internal class Seat
    {
        bool? _occupied;
        bool? _lastOccupiedStatus;
        public Seat(char v, int x, int y)
        {
            if (v == 'L') Occupied = false;
            else if (v == '#') Occupied = true;
            else if (v == '.') Occupied = null;
            else throw new NotImplementedException();

            X = x;
            Y = y;
        }

        public void CheckNextState()
        {

        }
        public bool? NextOccupiedStatus { get; set; }

        public bool? Occupied
        {
            get
            {
                return _occupied;
            }
            set
            {
                _lastOccupiedStatus = _occupied;
                _occupied = value;
            }
        }
        public int X { get; }
        public int Y { get; }
        public bool IsOccupied => Occupied.HasValue && Occupied.Value;
        public bool StatusChanged => _lastOccupiedStatus != _occupied;

        internal void UpdateOccupiedStatus()
        {
            Occupied = NextOccupiedStatus;
        }
    }
}