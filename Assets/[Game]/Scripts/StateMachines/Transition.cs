namespace Game.StateMachines
{
    public class Transition
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