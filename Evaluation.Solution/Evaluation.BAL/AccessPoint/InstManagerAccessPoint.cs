namespace Evaluation.BAL.AccessPoint
{
    public static class InstManagerAccessPoint
    {
        public static IAccessPoint GetNewAccessPoint()
        {
            return new AccessPoint();
        }
    }
}
