namespace Game.StateMachines
{
    /// <summary>
    /// Transition between two States in one direction.
    /// Is automatically created on runtime based on a StateMachine's required Transitions.
    /// Should not be extended from.
    /// </summary>
    public sealed class Transition
    {
        private readonly State from;
        private readonly State to;

        public Transition(State from, State to)
        {
            this.from = from;
            this.to = to;
        }

        public State Do()
        {
            from.Exit();
            to.Enter();

            return to;
        }
    }
}