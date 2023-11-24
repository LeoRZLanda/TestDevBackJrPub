namespace Cons_2.Servicios{
    
    public class ServicioIsDigit{

        public static bool IsDigit(string value)
        {
            foreach (char c in value)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

    }

}