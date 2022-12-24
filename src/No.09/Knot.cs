// (c) 2022 Ervin Peters (coder@ervnet.de)

using System;

namespace No._09
{
    public class Knot
    {
        public readonly char id;
        private Knot? previousKnot;
        public Knot? nextKnot;

        public int x;
        public int y;

        private readonly Playground playground;

        public Knot(char id, Playground playground, Knot? previous)
        {
            this.playground = playground;
            this.id = id;
            this.previousKnot = previous;
            if (previous != null)
            {
                this.nextKnot = previous.nextKnot;
                previous.nextKnot = this;
            }

            if (this.nextKnot != null)
                this.nextKnot.previousKnot = this;
        }

        public void stepX(int dX)
        {
            int step = dX > 0 ? 1 : -1;
            while (dX != 0)
            {
                this.x += step;
                if (this.nextKnot == null)
                    this.playground.touch(this.x, this.y);
                else
                    this.nextKnot.movedX(step);
                dX -= step;
            }
        }

        public void stepY(int dY)
        {
            int step = dY > 0 ? 1 : -1;
            while (dY != 0)
            {
                this.y += step;
                if (this.nextKnot == null)
                    this.playground.touch(this.x, this.y);
                else
                    this.nextKnot.movedY(step);
                dY -= step;
            }
        }

        private void step(int dx, int dy)
        {
            this.x += dx;
            this.y += dy;
            if (this.nextKnot == null)
                this.playground.touch(this.x, this.y);
            else
                this.nextKnot.moved();
        }

        private void moved()
        {
            if (this.previousKnot is null)
                throw new InvalidOperationException("should not be reached!");

            if (this.dist(this.previousKnot) <= 1)
                return;

            int dx = this.previousKnot.x - this.x;
            int dy = this.previousKnot.y - this.y;
            int stepx = dx > 0 ? 1 : -1;
            int stepy = dy > 0 ? 1 : -1;

            if (dy == 0)
                this.stepX(dx - stepx);
            else if (dx == 0)
                this.stepY(dy - stepy);
            else
                this.step(stepx, stepy);
        }

        private void movedY(int step)
        {
            if (this.dist(this.previousKnot) <= 1)
                return;

            if (this.previousKnot!.x != this.x)
                this.step(this.previousKnot.x - this.x, step);

            if (this.previousKnot.y - step - this.y != 0)
                this.stepY(this.previousKnot.y - step - this.y);
        }

        private void movedX(int step)
        {
            if (this.dist(this.previousKnot) <= 1)
                return;

            if (this.previousKnot!.y != this.y)
            {
                this.step(step, this.previousKnot.y - this.y);
            }

            if (this.previousKnot.x - step - this.x != 0)
                this.stepX(this.previousKnot.x - step - this.x);
        }

        private int dist(Knot? other)
        {
            if (other == null)
                return 0;
            int dx = Math.Abs(other.x - this.x);
            int dy = Math.Abs(other.y - this.y);
            return Math.Max(dx, dy);
        }
    }
}