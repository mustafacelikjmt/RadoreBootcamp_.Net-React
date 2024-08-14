namespace Radore_OOP.Constructors
{
    public class Head
    {
        // composition

        public Eye eye;
        public Ear ear;
        public Nose nose;

        public Head(Eye eye, Ear ear, Nose nose)
        {
            this.nose = nose;
            this.ear = ear;
            this.eye = eye;
        }
    }
}